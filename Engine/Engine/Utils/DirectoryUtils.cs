// Copyright (C) 2017 Roderick Griffioen
// This file is part of the "Core Engine".
// For conditions of distribution and use, see copyright notice in Core.cs

using System.IO;
using System.Collections.Generic;

namespace CoreEngine.Engine.Utils
{
    /// <summary>
    ///  Directory utilities
    /// </summary>
    public static class DirectoryUtils
    {
        #region Public API
        /// <summary>
        /// Returns the path to the file inside the directory (recursive)
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        public static string SearchDirectory(string directory, string filename)
        {
            if (!Directory.Exists(directory))
            {
                return "";
            }
            else
            {
                foreach (string d in Directory.GetFiles(directory))
                {
                    if (d.Contains(filename))
                    {
                        return d;
                    }
                }

                foreach (string d in Directory.GetDirectories(directory))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        if (f.Contains(filename))
                        {
                            return f;
                        }
                    }
                    SearchDirectory(d, filename);
                }
            }

            return "";
        }

        /// <summary>
        /// Returns all the paths to all the files in the directory (recursive)
        /// </summary>
        /// <param name="directory"></param>
        public static string[] AllDirectoryFiles(string directory)
        {
            List<string> items = new List<string>();
            if (!Directory.Exists(directory))
            {
                return items.ToArray();
            }
            else
            {
                foreach (string d in Directory.GetFiles(directory))
                {
                    items.Add(d);
                }

                foreach (string d in Directory.GetDirectories(directory))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        items.Add(f);
                    }

                    string[] recursive = AllDirectoryFiles(d);
                    if (recursive.Length > 0)
                        items.AddRange(recursive);
                }
            }

            return items.ToArray();
        }
        #endregion

    }
}
