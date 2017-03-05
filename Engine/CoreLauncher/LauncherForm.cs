using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Diagnostics;

using CoreEngine.Engine.Utils;


namespace CoreLauncher
{
    public partial class LauncherForm : Form
    {
        public string directory = "";
        public string fullpath = "";
        public string projectname = "";

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void ProjectNameBox_TextChanged(object sender, EventArgs e)
        {
            if (directory != "")
                fullpath = directory + "\\" + this.ProjectNameBox.Text;

            if(fullpath != "")
            {
                this.FullProjectPath.Text = fullpath;
            }

            projectname = this.ProjectNameBox.Text;
        }

        private void ProjectLocationBox_Click(object sender, System.EventArgs e)
        {
            DialogResult result = this.FolderBrowser.ShowDialog();
            if(result == DialogResult.OK)
            {
                directory = this.FolderBrowser.SelectedPath;
                this.ProjectLocationBox.Text = directory;

                fullpath = directory + "\\" + this.ProjectNameBox.Text;

                this.FullProjectPath.Text = fullpath;
            }
        }

        private void FolderBrowser_HelpRequest(object sender, EventArgs e)
        {

        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            // create the project
            if(fullpath != "" && projectname != "")
            {
                if(Directory.Exists(fullpath))
                {
                    // promt directory already exists
                }
                else
                {
                    Directory.CreateDirectory(fullpath);
                    Directory.CreateDirectory(fullpath + "/" + projectname + "/Content");
                    Directory.CreateDirectory(fullpath + "/" + projectname + "/Content/Shaders");

                    using (StreamWriter sw = File.CreateText(fullpath + "/" + projectname + ".sln"))
                    {
                        // Default SLN header
                        sw.Write("Microsoft Visual Studio Solution File, Format Version 12.00" + Environment.NewLine + 
                            "# Visual Studio 14" + Environment.NewLine + 
                            "VisualStudioVersion = 14.0.25420.1" + Environment.NewLine + 
                            "MinimumVisualStudioVersion = 10.0.40219.1");

                        sw.WriteLine();

                        // Add Engine Project
                        sw.Write("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC} \") = \"Engine\", \"Engine\\Engine.csproj\", \"{ 177033D3-6042-45FE-A791-A50355ABBEF4}\"" + Environment.NewLine + "EndProject");

                        sw.WriteLine();

                        // Add New Project
                        sw.Write("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"" + projectname + "\", \"" + projectname + "\\" + projectname + ".csproj\", \"{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}\"" + Environment.NewLine + "EndProject");

                        sw.WriteLine();

                        // Global section
                        sw.WriteLine("Global");

                        // Solution Configuration
                        sw.WriteLine("GlobalSection(SolutionConfigurationPlatforms) = preSolution");

                        sw.Write("Debug|Any CPU = Debug|Any CPU" + 
                            Environment.NewLine + "Debug | x64 = Debug | x64" + 
                            Environment.NewLine + "Debug | x86 = Debug | x86" +
                            Environment.NewLine + "Release | Any CPU = Release | Any CPU" + 
                            Environment.NewLine + "Release | x64 = Release | x64" + 
                            Environment.NewLine + "Release | x86 = Release | x86");

                        sw.WriteLine();

                        sw.WriteLine("EndGlobalSection");

                        // Project Configuration
                        sw.WriteLine("GlobalSection(ProjectConfigurationPlatforms) = postSolution");

                        // Engine Project Configuration
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|Any CPU.Build.0 = Debug|AnyCPU");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|x64.ActiveCfg = Debug|x64");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|x64.Build.0 = Debug|x64");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|x86.ActiveCfg = Debug|x86");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Debug|Debug|x86.Build.0 = Debug|x86");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|Any CPU.Build.0 = Release|Any CPU");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|x64.ActiveCfg = Release|x64");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|x64.Build.0 = Release|x64");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|x86.ActiveCfg = Release|x86");
                        sw.WriteLine("{177033D3-6042-45FE-A791-A50355ABBEF4}.Release|x86.Build.0 = Release|x86");

                        //New Project Configuration
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|Any CPU.Build.0 = Debug|Any CPU");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|x64.ActiveCfg = Debug|x64");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|x64.Build.0 = Debug|x64");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|x86.ActiveCfg = Debug|x86");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Debug|x86.Build.0 = Debug|x86");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|Any CPU.Build.0 = Release|Any CPU");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|x64.ActiveCfg = Release|x64");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|x64.Build.0 = Release|x64");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|x86.ActiveCfg = Release|x86");
                        sw.WriteLine("{3AF25EDB-865F-40F3-9A21-1D3FC90D647A}.Release|x86.Build.0 = Release|x86");


                        sw.WriteLine("EndGlobalSection");

                        // Solution Properties
                        sw.WriteLine("GlobalSection(SolutionProperties) = preSolution");
                        sw.WriteLine("HideSolutionNode = FALSE");
                        sw.WriteLine("EndGlobalSection");

                        sw.Write("EndGlobal");
                    }

                    Directory.CreateDirectory(fullpath + "/Engine");

                    string[] engineItems = DirectoryUtils.AllDirectoryFiles("../../../Engine");
                    foreach (string item in engineItems)
                    {
                        string newItemPath = item.TrimStart("../../../Engine\\\\".ToCharArray());

                        string[] arr = newItemPath.Split('\\');
                        string path = newItemPath.TrimEnd(arr[arr.Length - 1].ToCharArray());
                        if (!Directory.Exists(fullpath + "/Engine/" + path))
                        {
                            if(path != "" && path.Contains("bin") == false && path.Contains("obj") == false)
                                Directory.CreateDirectory(fullpath + "/Engine/" + path);
                        }

                        string root = newItemPath.Split('\\')[0];

                        if (!File.Exists(fullpath + "/Engine/" + newItemPath) && root.Contains("bin") == false && root.Contains("obj") == false)
                        {
                            if(item.Contains("csproj"))
                            {
                                newItemPath = "Engine.csproj";
                            }
                            File.Copy(item, fullpath + "/Engine/" + newItemPath);
                        }
                    }

                    Directory.CreateDirectory(fullpath + "/" + projectname);

                    string[] emptyProjectItems = DirectoryUtils.AllDirectoryFiles("../../../EmptyProject");
                    foreach (string item in emptyProjectItems)
                    { 
                        string newItemPath = item.Substring("../../../EmptyProject\\".Length);

                        string[] arr = newItemPath.Split('\\');
                        string path = newItemPath.TrimEnd(arr[arr.Length - 1].ToCharArray());
                        if (!Directory.Exists(fullpath + "/" + projectname + "/" + path))
                        {
                            if (path != "" && path.Contains("bin") == false && path.Contains("obj") == false)
                                Directory.CreateDirectory(fullpath + "/" + projectname + "/" + path);
                        }

                        string root = newItemPath.Split('\\')[0];

                        if (!File.Exists(fullpath + "/" + projectname + "/" + newItemPath) && root.Contains("bin") == false && root.Contains("obj") == false)
                        {
                            if (item.Contains("csproj"))
                            {
                                newItemPath = projectname + ".csproj";
                            }
                            if (item.Contains("csproj") && File.Exists(fullpath + "/" + projectname + "/" + newItemPath))
                                continue;

                            File.Copy(item, fullpath + "/" + projectname + "/" + newItemPath);
                        }
                    }

                    Process.Start(@fullpath);

                    Environment.Exit(0);
                }
            }
        }
    }
}
