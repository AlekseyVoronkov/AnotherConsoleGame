using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            EffectManager effectManager = new EffectManager();
            ObjectsRenderer objectsRenderer = new ObjectsRenderer();
            Map map = new Map();
            map.CreateMapFile();
            
            Console.SetWindowSize(100, 40);

            while (true)
            {
                InputHandler.HandleControll(player, map, effectManager);
                effectManager.Update();
                objectsRenderer.DrawCycle(player, map, effectManager);
                Thread.Sleep(50);
            }
        }
    }
}
