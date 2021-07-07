using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    public enum SideName
    {
        NOTHING = 0,
        TOP = 1,
        TOP_RIGHT = 3,
        RIGHT = 2,
        BOTTOM_RIGHT = 6,
        BOTTOM = 4,
        BOTTOM_LEFT = 12,
        LEFT = 8,
        TOP_LEFT = 9
    }

    public struct Hitbox
    {
        public Vector2d Origin { get; set; }
        public Vector2d Size { get; set; }
        
        public SideName IsTouching(Hitbox hitbox)
        {
            int touch = 0;

            if (this.Origin.PosX == (hitbox.Origin.PosX + hitbox.Size.PosX)) touch += (int)SideName.LEFT;
            if (this.Origin.PosY == (hitbox.Origin.PosY + hitbox.Size.PosY)) touch += (int)SideName.BOTTOM;
            if (hitbox.Origin.PosX == (this.Origin.PosX + hitbox.Size.PosX)) touch += (int)SideName.RIGHT;
            if (hitbox.Origin.PosY == (this.Origin.PosY + hitbox.Size.PosY)) touch += (int)SideName.TOP;

            return (SideName)touch;
        }

        public bool CollideWith(Hitbox hitbox)
        {
            bool collide = false;

            if (this.Origin.PosX < (hitbox.Origin.PosX + hitbox.Size.PosX)
                && this.Origin.PosX + this.Size.PosX > hitbox.Origin.PosX 
                && this.Origin.PosY < (hitbox.Origin.PosY + hitbox.Size.PosY) 
                && this.Origin.PosY + this.Size.PosY > hitbox.Origin.PosY)
            {
                collide = true;
            }

            return collide;
        }
    }
}
