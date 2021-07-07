using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    struct Hitbox
    {
        public Vector2d Origin { get; set; }
        public Vector2d Size { get; set; }
        
        public bool IsTouching(Hitbox hitbox)
        {
            bool touch = false;

            if(this.Origin.PosX == (hitbox.Origin.PosX + hitbox.Size.PosX)
               || this.Origin.PosY == (hitbox.Origin.PosY + hitbox.Size.PosY)
               || hitbox.Origin.PosX == (this.Origin.PosX + hitbox.Size.PosX)
               || hitbox.Origin.PosY == (this.Origin.PosY + hitbox.Size.PosY))
            {
                touch = true;
            }

            return touch;
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
