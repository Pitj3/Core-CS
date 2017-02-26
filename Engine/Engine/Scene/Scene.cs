using System;
using System.Collections.Generic;
using System.IO;

using CoreEngine.Engine.Components;

using Newtonsoft.Json;

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

            string loaddata = "";

            if (!File.Exists(_path))
            {
                File.CreateText(_path).Close();
                return;
            }
            else
            {
                using (StreamReader sw = File.OpenText(_path))
                {
                    loaddata += sw.ReadToEnd();
                    sw.Close();
                }
            }


            if (loaddata.Length == 0)
                return;

            SaveGameObject[] sgoList = null;
            sgoList = JsonConvert.DeserializeObject<SaveGameObject[]>(loaddata);

            foreach (SaveGameObject sgo in sgoList)
            {
                GameObject go = GameObject.Instantiate(null, sgo.position, sgo.rotation) as GameObject;
                go.Name = sgo.Name;
                go.Static = sgo.Static;
                go.Parent = sgo.Parent;

                LoadChildren(sgo, go);

                foreach (CoreComponent comp in sgo.Components)
                {
                    go.AddComponent(comp.type);
                }
            }

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

                foreach (CoreComponent comp in saveObj.Components)
                {
                    goChild.AddComponent(comp.type);
                }

                LoadChildren(sgoChild, goChild);
            }
        }
        #endregion
    }
}
