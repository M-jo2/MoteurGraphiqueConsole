using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    class Component
    {
        private List<char[,]> Images;
        private Vector2d position;
        private Hitbox hitbox;

        /// <summary>
        /// Index de l'image en cours d'utilisation dans la liste.
        /// </summary>
        /// 

        public int imageState { get; set; }

        public Vector2d Position
        {
            get
            {
                return position;
            }
        }

        public Hitbox Hitbox
        {
            get
            {
                return hitbox;
            }
            set
            {
                hitbox = value;
            }

        }

        public Component()
        {
            imageState = 0;
        }

        public char[,] GetImage()
        {
            return Images[imageState];
        }
    }
}
