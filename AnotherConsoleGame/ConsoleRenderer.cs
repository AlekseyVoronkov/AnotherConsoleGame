using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherConsoleGame
{
    internal struct ScreenCell
    {
        public char Symbol;
        public ConsoleColor Color;

        public ScreenCell(char symbol, ConsoleColor color = ConsoleColor.White)
        {
            Symbol = symbol;
            Color = color;
        }
    }

    internal class ConsoleRenderer
    {
        private readonly int _width;
        private readonly int _height;
        private ScreenCell[,] _currentBuffer;
        private ScreenCell[,] _previousBuffer;

        public ConsoleRenderer(int width, int height)
        {
            _width = width;
            _height = height;

            _currentBuffer = new ScreenCell[width, height];
            _previousBuffer = new ScreenCell[width, height];
            Console.CursorVisible = false;
        }

        public void BeginFrame()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _currentBuffer[x, y] = new ScreenCell(' ');
                }
            }
        }

        public void Draw(int x, int y, char symbol, ConsoleColor color)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
            {
                _currentBuffer[x, y] = new ScreenCell(symbol, color);
            }
        }

        public void PresentFrame()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_currentBuffer[x, y].Symbol != _previousBuffer[x, y].Symbol ||
                        _currentBuffer[x, y].Color != _previousBuffer[x, y].Color)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = _currentBuffer[x, y].Color;
                        Console.Write(_currentBuffer[x, y].Symbol);

                        _previousBuffer[x, y] = _currentBuffer[x, y];
                    }
                }
            }
        }
    }

}
