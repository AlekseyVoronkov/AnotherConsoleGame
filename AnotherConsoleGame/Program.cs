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
            ConsoleRenderer consoleRenderer = new ConsoleRenderer(Constants.mapSize.sizeX, Constants.mapSize.sizeY);
            Map map = new Map();
            map.CreateMapFile();
            
            Console.SetWindowSize(Constants.mapSize.sizeX, Constants.mapSize.sizeY);

            while (true)
            {
                InputHandler.HandleControll(player, map, effectManager);
                effectManager.Update();
                var mapData = map.GetMap();
                consoleRenderer.BeginFrame();

                for (int y = 0; y < Constants.mapSize.sizeY; y++)
                {
                    for (int x = 0; x < Constants.mapSize.sizeX; x++)
                    {
                        consoleRenderer.Draw(x, y, mapData[x, y], ConsoleColor.Gray);
                    }
                }

                foreach (var effect in effectManager.GetActiveEffects())
                {
                    foreach (var pos in effect.Positions)
                    {
                        consoleRenderer.Draw(pos.x, pos.y, effect.Symbol, effect.Color);
                    }
                }

                consoleRenderer.Draw(player.Position.coordinateX, player.Position.coordinateY, Constants.playerTile, ConsoleColor.DarkCyan);
                consoleRenderer.PresentFrame();

                Thread.Sleep(Constants.frameDelay);
            }
        }
    }
}
