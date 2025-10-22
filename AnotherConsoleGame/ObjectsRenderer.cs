using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class ObjectsRenderer
    {
        char playerTile = 'A';
        public void DrawCycle(Player player, Map map, EffectManager effectManager)
        {
            Console.SetCursorPosition(0, 0);


            char[,] copiedMap = (char[,])map.map.Clone();

            foreach (var effect in effectManager.GetActiveEffects())
            {
                foreach (var pos in effect.Positions)
                {
                    if (pos.x >= 0 && pos.x < Constants.mapSize.sizeX &&
                        pos.y >= 0 && pos.y < Constants.mapSize.sizeY)
                    {
                        copiedMap[pos.x, pos.y] = effect.Symbol;
                    }
                }
            }

            StringBuilder screenBuffer = new StringBuilder();
            copiedMap[player.Position.coordinateX, player.Position.coordinateY] = playerTile;

            for (int y = 0; y < Constants.mapSize.sizeY; y++)
            {
                for (int x = 0; x < Constants.mapSize.sizeX; x++)
                {
                    screenBuffer.Append(copiedMap[x, y]);
                }
                screenBuffer.AppendLine();
            }

            Console.Write(screenBuffer.ToString());
        }

        private void DrawPlayer(Player player)
        {

        } 
    }
}
