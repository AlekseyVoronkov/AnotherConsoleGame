using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal static class Constants
    {
        public static Random random = new Random();

        public static string mapPath = AppDomain.CurrentDomain.BaseDirectory + @"\map.txt";
        public static (int sizeX, int sizeY) mapSize = (90, 30);

        public static char[] solidObjects = ['#'];
        public static char playerTile = 'A';
        
        public static int DashMult = 3;

        public static int frameDelay = 50;
    }
}
