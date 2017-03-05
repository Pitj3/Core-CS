using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Game app = new Game(1280, 720);

            app.Run();
        }
    }
}
