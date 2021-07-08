using MoteurGraphiqueConsole.Moteur;
using MoteurGraphiqueConsole.Moteur.Input_Manage;
using MoteurGraphiqueConsole.Moteur.ReadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.GameTest.GameComponent
{
    class Mario : Component
    {
        int gravity = 1;
        int speedFall = 0;
        int maxSpeedFall = 5;
        int jumpForce = -5;

        int xPos = 0;
        int yPos = 20;

        public override void Start()
        {
            this.AddImage(Import.ImportTileMapCsv(@"GameTest/Images/mario.csv"));
            this.Hitbox = new Hitbox(new Vector2d(xPos, yPos), new Vector2d(12, 16));
        }

        public override void Update()
        {
            yPos += speedFall;
            speedFall += gravity;
            if (speedFall > maxSpeedFall) speedFall = maxSpeedFall;
            if (yPos > 100) yPos = 100;

            /////////////////////////////////////
            if (Input.IsKeyDown(ConsoleKey.Spacebar)) speedFall = jumpForce;     
            if (Input.IsKeyDown(ConsoleKey.RightArrow)) xPos += 1;    
            if (Input.IsKeyDown(ConsoleKey.LeftArrow)) xPos -= 1;      
            ////////////////////////////////////

            this.Hitbox.Origin = new Vector2d(xPos, yPos);
        }

        public override void CollideReact(Component component)
        {
            if(component.Name == "platforme")
            {
                if (component.Hitbox.IsTouching(this.Hitbox) == SideName.TOP) 
                     this.speedFall = jumpForce;
            }
        }
    }
}
