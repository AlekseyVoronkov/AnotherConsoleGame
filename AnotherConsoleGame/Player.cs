using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal class Player
    {
        (int, int) startCoordinates = (1, 1);
        public (int coordinateX, int coordinateY) Position;
        public (int x, int y) prevDelta = (0, 0);
        public Player() 
        {
            Position = startCoordinates;
        }

        public void Move(int deltaX, int deltaY)
        {
            prevDelta = (deltaX, deltaY);
            Position = (Position.coordinateX + deltaX, Position.coordinateY + deltaY);
        }

        public void Dash(Map map, EffectManager effectManager)
        {
            int directionX = prevDelta.x;
            int directionY = prevDelta.y;
            int distance = Constants.DashMult;

            for (int i = 1; i <= distance; i++)
            {
                int checkX = Position.coordinateX + directionX * i;
                int checkY = Position.coordinateY + directionY * i;

                if (checkX <= 0 || checkX >= Constants.mapSize.sizeX - 1 ||
                    checkY <= 0 || checkY >= Constants.mapSize.sizeY - 1 ||
                    Constants.solidObjects.Contains(map.map[checkX, checkY]))
                {
                    return;
                }
            }

            var dashTrailCoords = new List<(int, int)>();
            for (int i = 1; i <= distance; i++)
            {
                dashTrailCoords.Add((Position.coordinateX + directionX * i, Position.coordinateY + directionY * i));
            }

            effectManager.AddEffect(new VisualEffect('.', dashTrailCoords.ToArray(), 600));
            effectManager.AddEffect(new VisualEffect(',', dashTrailCoords.ToArray(), 400));
            effectManager.AddEffect(new VisualEffect('@', dashTrailCoords.ToArray(), 200));

            Position = (Position.coordinateX + directionX * distance, Position.coordinateY + directionY * distance);
        }

        public void MeleeAttack(EffectManager effectManager)
        {
            (int x, int y)[] attackCoords;
            char attackSymbol = '|';

            switch (prevDelta)
            {
                case (1, 0):
                    attackSymbol = ')';
                    attackCoords = new (int, int)[] {
                (Position.coordinateX + 1, Position.coordinateY - 1),
                (Position.coordinateX + 1, Position.coordinateY),
                (Position.coordinateX + 1, Position.coordinateY + 1)
            };
                    break;
                case (-1, 0):
                    attackSymbol = '(';
                    attackCoords = new (int, int)[] {
                (Position.coordinateX - 1, Position.coordinateY - 1),
                (Position.coordinateX - 1, Position.coordinateY),
                (Position.coordinateX - 1, Position.coordinateY + 1)
            };
                    break;
                case (0, 1):
                    attackSymbol = '|';
                    attackCoords = new (int, int)[] {
                (Position.coordinateX - 1, Position.coordinateY + 1),
                (Position.coordinateX, Position.coordinateY + 1),
                (Position.coordinateX + 1, Position.coordinateY + 1)
            };
                    break;
                case (0, -1):
                    attackSymbol = '|';
                    attackCoords = new (int, int)[] {
                (Position.coordinateX - 1, Position.coordinateY - 1),
                (Position.coordinateX, Position.coordinateY - 1),
                (Position.coordinateX + 1, Position.coordinateY - 1)
            };
                    break;
                default:
                    return;
            }

            var attackEffect = new VisualEffect(attackSymbol, attackCoords, 100);
            effectManager.AddEffect(attackEffect);
        }
    }
}
