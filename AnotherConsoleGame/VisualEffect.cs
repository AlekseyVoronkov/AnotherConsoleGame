using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class VisualEffect
    {
        public char Symbol { get; }
        public (int x, int y)[] Positions { get; }
        public ConsoleColor Color { get; }
        public DateTime ExpireTime { get; }

        public VisualEffect(char symbol, (int x, int y)[] positions, ConsoleColor color, int durationMs)
        {
            Symbol = symbol;
            Positions = positions;
            Color = color;
            ExpireTime = DateTime.Now.AddMilliseconds(durationMs);
        }

        public bool IsExpired => DateTime.Now >= ExpireTime;
    }
}
