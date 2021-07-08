using MoteurGraphiqueConsole.Moteur;
using MoteurGraphiqueConsole.Moteur.ReadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.GameTest.GameComponent
{
    class Plateform : Component
    {
        private Vector2d position = new Vector2d(0,0);

        public Vector2d Position
        {
            get
            {
                return position;
            }
            set { 
                this.position = value;
                this.Hitbox.Origin = value;
            }
        }

        public override void Start()
        {
            this.AddImage(Import.ImportTileMapCsv(@"GameTest/Images/bloc.csv"));
            this.Hitbox = new Hitbox(position, new Vector2d(6, 6));
            this.Name = "platforme";
        }

        public override void Update()
        {
        }
    }
}
