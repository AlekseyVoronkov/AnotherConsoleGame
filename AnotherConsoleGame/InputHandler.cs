using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal static class InputHandler
    {
        private const char NoKeyMarker = '}';
        private static readonly char[] NoKeys = [NoKeyMarker, NoKeyMarker, NoKeyMarker, NoKeyMarker];
        public static readonly Dictionary<char[], (int deltaX, int deltaY)> movementOptions = new()
        {
            [['a', 'A', 'ф', 'Ф']] = (-1, 0),   // 
            [['d', 'D', 'в', 'В']] = (1, 0),    // wasd handling
            [['w', 'W', 'ц', 'Ц']] = (0, -1),   // 
            [['s', 'S', 'ы', 'Ы']] = (0, 1)
        };

        public static void HandleControll(Player player, Map map, EffectManager effectManager)
        {
            if (Console.KeyAvailable)
            {
                var ch = Console.ReadKey(true);
                var keysPressed = GetPressedKeys(ch.KeyChar).Item1;
                if (ch.Key == ConsoleKey.Spacebar)
                {
                    player.MeleeAttack(effectManager);
                }
                else if (ch.Key == ConsoleKey.F)
                {
                    player.Dash(map, effectManager);
                }
                else
                {
                    var direction = GetPressedKeys(ch.KeyChar).Item2;
                    var validatedDirection = ValidateMovement(map, player, direction.deltaX, direction.deltaY);

                    player.Move(validatedDirection.Item1, validatedDirection.Item2);
                }
            }
        }

        private static (char[], (int deltaX, int deltaY)) GetPressedKeys(char input)
        {
            char[] keys = movementOptions.FirstOrDefault(kvp => kvp.Key.Contains(input)).Key ?? NoKeys;
            (int, int) values = movementOptions.FirstOrDefault(kvp => kvp.Key.Contains(input)).Value;

            return (keys, values);
        }

        private static (int, int) ValidateMovement(Map map, Player player, int deltaX, int deltaY)
        {
            try
            {
                int newX = deltaX + player.Position.coordinateX;
                int newY = deltaY + player.Position.coordinateY;
                if (Constants.solidObjects.Contains(map.map[newX, newY]))
                {
                    deltaX = 0;
                    deltaY = 0;
                }
            } 
            catch (IndexOutOfRangeException e)
            {
                return (0, 0);
            }

            return (deltaX, deltaY);
        }
    }
}
