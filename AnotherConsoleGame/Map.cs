using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class Map
    {
        char wallTile = '#';
        public char[,] map;
        public Map()
        {
            map = new char[Constants.mapSize.sizeX, Constants.mapSize.sizeY];
        }

        public void CreateMapFile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < Constants.mapSize.sizeY; y++)
            {
                for (int x = 0; x < Constants.mapSize.sizeX; x++)
                {
                    if (x == 0 || x == Constants.mapSize.sizeX - 1 || y == 0 || y == Constants.mapSize.sizeY - 1)
                    {
                        map[x, y] = wallTile;
                    }
                    else if (ShouldDrawRandomPoint(x, y))
                    {
                        map[x, y] = '.';
                    }
                    else
                    {
                        map[x, y] = ' ';
                    }
                    stringBuilder.Append(map[x, y]);
                }
                stringBuilder.AppendLine();
            }
            File.WriteAllText(Constants.mapPath, stringBuilder.ToString());
        }

        public char[,] GetMap()
        {
            return map;
        }
        private bool ShouldDrawRandomPoint(int x, int y)
        {
            return Constants.random.Next(100) < 5;
        }
    }
}
