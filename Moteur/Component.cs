using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    class Component
    {
        protected List<Tile[,]> Images;
        private Hitbox hitbox;

        public bool Visible { get; set; }
        public string Name { get; set; }
        

        /// <summary>
        /// Index de l'image en cours d'utilisation dans la liste.
        /// </summary>
        public int ImageState { get; set; }

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
            Images = new List<Tile[,]>();
            ImageState = 0;
            Start();
        }

        public Tile[,] GetImage()
        {
            return Images[ImageState];
        }

        public virtual void PhysicsUpdate(Component component) { }
        public virtual void Update() { }
        public virtual void Start() { }

        public void AddImage(Tile[,] tiles)
        {
            Images.Add(tiles);
        }
    }
}
