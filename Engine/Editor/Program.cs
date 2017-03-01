using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

using CoreEngine.Engine.Application;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var threadEditor = new Thread(new ThreadStart(() =>
            {
                CoreEditor editor = new CoreEditor();
                Application.Run(new CoreEditor());
            }));
            threadEditor.Start();
        }
    }
}
