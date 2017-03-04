// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System;
using System.Collections.Generic;
using System.IO;

using CoreEngine.Engine.Components;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CoreEngine.Engine.Core;

using OpenTK;

namespace CoreEngine.Engine.Scene
{
    /// <summary>
    /// Scene class
    /// </summary>
    public class Scene
    {
        #region Data
        public List<GameObject> GameObjects = new List<GameObject>();
        public string Name = "unnamed";

        private string _path = "Content/Scenes/";
        private string _jsonData = "";

        private JsonSerializer _jsonSerializer;
        private JsonConverter[] _converters;

        public GameObject CurrentObject;
        #endregion

        #region Constructors
        public Scene()
        {
            _jsonSerializer = new JsonSerializer();
            _jsonSerializer.Converters.Add(new VectorConverter());
            _jsonSerializer.Converters.Add(new QuaternionConverter());
            _jsonSerializer.Converters.Add(new Matrix4Converter());
            _jsonSerializer.Converters.Add(new MeshConverter());
            _jsonSerializer.Converters.Add(new ShaderConverter());
            _jsonSerializer.Converters.Add(new Texture2DConverter());
            _jsonSerializer.Converters.Add(new MaterialConverter());

            _converters = new JsonConverter[_jsonSerializer.Converters.Count];
            for (int j = 0; j < _jsonSerializer.Converters.Count; j++)
            {
                _converters[j] = _jsonSerializer.Converters[j];
            }
        }
        #endregion

        #region Public API

        /// <summary>
        /// Loads the scene
        /// </summary>
        /// <param name="source">Name of the scene</param>
        public void Load(string source)
        {
            // load objects and stuff from source.
            SceneManager.CurrentScene = this;

            string[] arr = source.Split('\\');
            Name = arr[arr.Length - 1];

            _path = source;

            if (!File.Exists(_path))
            {
                File.CreateText(_path).Close();
                return;
            }
            else
            {
                using (StreamReader sw = File.OpenText(_path))
                {
                    _jsonData += sw.ReadToEnd();
                    sw.Close();
                }
            }

            if (_jsonData.Length == 0)
                return;

            LoadGameObjects();

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Awake();
                }
            }

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Start();
                }
            }
        }

        public void LoadByString(string source, string path)
        {
            Name = path;
            _path += path + ".txt";

            // load objects and stuff from source.
            SceneManager.CurrentScene = this;

            _jsonData = source;

            if (_jsonData.Length == 0)
                return;

            LoadGameObjects();

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Awake();
                }
            }

            foreach (GameObject go in GameObjects)
            {
                foreach (CoreComponent comp in go.Components)
                {
                    comp.Start();
                }
            }
        }

        /// <summary>
        /// Saves the scene
        /// </summary>
        public void Save(string overridepath = "")
        {
            if(overridepath != "")
            {
                _path = overridepath;
                _path += Name;
            }

            string savefile = "";
            SaveGameObject[] sgoList = new SaveGameObject[GameObjects.Count];

            int i = 0;
            foreach (GameObject go in GameObjects)
            {
                sgoList[i] = go.Serialize();
                i++;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters = _converters;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            savefile = JsonConvert.SerializeObject(sgoList, Formatting.Indented, settings);

            if (!File.Exists(_path))
            {
                using(StreamWriter sw = File.CreateText(_path))
                {
                    sw.Write(savefile);
                    sw.Close();
                }
            }
            else
            {
                File.WriteAllText(_path, savefile);
            }
        }

        #endregion

        #region GameObject API

        private int _currentObject = 0;

        /// <summary>
        /// Loads the game objects and components
        /// </summary>
        public void LoadGameObjects()
        {
            _currentObject = 0;
            SaveGameObject[] sgoList = null;

            sgoList = JsonConvert.DeserializeObject<SaveGameObject[]>(_jsonData, _converters);
            
            foreach (SaveGameObject sgo in sgoList)
            {
                GameObject go = GameObject.Instantiate(null, sgo.position, sgo.rotation) as GameObject;
                go.Name = sgo.Name;
                go.Static = sgo.Static;
                go.Parent = sgo.Parent;

                LoadComponents(sgo, go);

                _currentObject++;
                LoadChildren(sgo, go);
            }
        }

        /// <summary>
        /// Loads the children of a savegameobject
        /// </summary>
        /// <param name="saveObj">Saved object</param>
        /// <param name="parent">Parent to load the children to</param>
        public void LoadChildren(SaveGameObject saveObj, GameObject parent)
        {
            foreach (SaveGameObject sgoChild in saveObj.Children)
            {
                GameObject goChild = GameObject.Instantiate(null, sgoChild.position, sgoChild.rotation) as GameObject;
                goChild.Name = sgoChild.Name;
                goChild.Static = sgoChild.Static;
                goChild.Parent = parent;

                LoadComponents(saveObj, parent);

                _currentObject++;
                LoadChildren(sgoChild, goChild);
            }
        }

        /// <summary>
        /// Loads the components of the supplied savegameobject
        /// </summary>
        /// <param name="saveObj">Components will be loaded from this savegameobject</param>
        /// <param name="parent">GameObject to parent the component to</param>
        public void LoadComponents(SaveGameObject saveObj, GameObject parent)
        {
            JArray arr = JArray.Parse(_jsonData);
            JToken comps = arr[_currentObject]["Components"];

            int _currComp = 0;

            foreach (JToken token in comps.Children()) // for every comp
            {
                object t = null;
                try
                {
                    t = token.ToObject(saveObj.Components[_currComp].systemType, _jsonSerializer);
                }
                catch(JsonException e)
                {
                    Console.WriteLine(e);
                }

                parent.AddComponent(t);

                _currComp++;
            }
        }
        #endregion
    }
}
