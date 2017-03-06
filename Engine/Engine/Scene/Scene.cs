// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs
using System.IO;
using System.Collections.Generic;

using CoreEngine.Engine.Components;

using Newtonsoft.Json;

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

        public GameObject CurrentObject;
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

            string[] arr = source.Split('/');
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
            //_path += Name;

            string savefile = "";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                jw.WriteStartArray();
                foreach (GameObject go in GameObjects)
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("GOID");
                    jw.WriteValue(go.ID);
                    jw.WriteEndObject();

                    go.Save();
                }
                jw.WriteEndArray();
            }

            savefile = sw.ToString();

            if (!File.Exists(_path))
            {
                using(StreamWriter writer = File.CreateText(_path))
                {
                    writer.Write(savefile);
                    writer.Close();
                }
            }
            else
            {
                File.WriteAllText(_path, savefile);
            }
        }

        #endregion

        #region GameObject API

        /// <summary>
        /// Loads the game objects and components
        /// </summary>
        public void LoadGameObjects()
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(_jsonData));
            while(reader.Read())
            {
                if(reader.Value != null)
                {
                    if(reader.TokenType == JsonToken.PropertyName)
                    {
                        if (reader.Value.ToString() == "GOID")
                        {
                            reader.Read();
                            int goid = int.Parse(reader.Value.ToString());

                            GameObject.Load(goid);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
