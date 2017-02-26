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
        public string Name;

        private string _path = "Content/Scenes/";
        private string _jsonData = "";
        #endregion

        #region Constructors
        public Scene()
        {

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

            Name = source;
            _path += source + ".txt";

            if(!Directory.Exists("Content/Scenes/"))
            {
                Directory.CreateDirectory("Content/Scenes/");
            }

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

        /// <summary>
        /// Saves the scene
        /// </summary>
        public void Save()
        {
            string savefile = "";
            SaveGameObject[] sgoList = new SaveGameObject[GameObjects.Count];

            int i = 0;
            foreach (GameObject go in GameObjects)
            {
                sgoList[i] = go.Serialize();
                i++;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            settings.Converters.Add(new Vector2Converter());
            settings.Converters.Add(new Vector3Converter());
            settings.Converters.Add(new Vector4Converter());
            settings.Converters.Add(new QuaternionConverter());
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
                File.Delete(_path);
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
            sgoList = JsonConvert.DeserializeObject<SaveGameObject[]>(_jsonData);
            
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
                object t = token.ToObject(saveObj.Components[_currComp].systemType);
                parent.AddComponent(t);

                _currComp++;
            }
        }
        #endregion
    }
}
