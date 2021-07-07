using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    public struct Tile
    {
        public char tileChar;
        public ConsoleColor charColor;
        public ConsoleColor backgroundColor;

        public Tile(char tileChar, ConsoleColor charColor, ConsoleColor backgroundColor)
        {
            this.tileChar = tileChar;
            this.charColor = charColor;
            this.backgroundColor = backgroundColor;

        }
    }
}
