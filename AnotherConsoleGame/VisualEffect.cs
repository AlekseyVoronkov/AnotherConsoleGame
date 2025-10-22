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
        public DateTime ExpireTime { get; }

        public VisualEffect(char symbol, (int x, int y)[] positions, int durationMs)
        {
            Symbol = symbol;
            Positions = positions;
            ExpireTime = DateTime.Now.AddMilliseconds(durationMs);
        }

        public bool IsExpired => DateTime.Now >= ExpireTime;
    }
}
