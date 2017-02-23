using CoreEngine.Engine;
using CoreEngine.Engine.Application;

namespace CoreEngine.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreApplication app = Core.CreateCoreApplication(1280, 720);
            app.Run();
        }
    }
}
