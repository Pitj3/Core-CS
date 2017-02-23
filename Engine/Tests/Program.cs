using CoreEngine.Engine;
using CoreEngine.Engine.Graphics;
using CoreEngine.Engine.Application;

namespace CoreEngine.Tests
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
