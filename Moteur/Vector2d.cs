﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    public struct Vector2d
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Vector2d(int PosX,int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
        }
    }
}
