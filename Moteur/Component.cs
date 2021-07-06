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
        private Position position;

        /// <summary>
        /// Index de l'image en cours d'utilisation dans la liste.
        /// </summary>
        public int imageState { get; set; }

        public Position Position { 
            get 
            {
                return position;
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
