using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace CoreEngine.Engine.Utils
{
    public static class DirectoryUtils
    {
        public static string SearchDirectory(string directory, string filename)
        {
            if(!Directory.Exists(directory))
            {
                return "";
            }
            else
            {
                foreach (string d in Directory.GetFiles(directory))
                {
                    if(d.Contains(filename))
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
                    if(recursive.Length > 0)
                        items.AddRange(recursive);
                }
            }

            return items.ToArray();
        }
    }
}
