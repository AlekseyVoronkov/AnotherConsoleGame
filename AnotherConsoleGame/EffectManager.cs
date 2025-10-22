using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class EffectManager
    {
        private readonly List<VisualEffect> _effects = new();

        public void AddEffect(VisualEffect effect)
        {
            _effects.Add(effect);
        }

        public void Update()
        {
            _effects.RemoveAll(e => e.IsExpired);
        }

        public IReadOnlyList<VisualEffect> GetActiveEffects()
        {
            return _effects;
        }
    }
}
