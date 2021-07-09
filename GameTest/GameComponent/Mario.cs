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

        Vector2d Position = new Vector2d(100, 20);
        Vector2d LastPosition;

        public override void Start()
        {
            this.AddImage(Import.ImportTileMapCsv(@"GameTest/Images/mario.csv"));
            Tile[,] miroirMario = new Tile[this.Images[0].GetLength(0), this.Images[0].GetLength(1)];

            for(int i= 0;i<miroirMario.GetLongLength(0); i++)
            {
                for (int j = 0; j < miroirMario.GetLongLength(1)/2; j++)
                {
                    Tile tileTemp1 = this.Images[0][i, j];
                    Tile tileTemp2 = this.Images[0][i, miroirMario.GetLongLength(1)-1 - j];

                    miroirMario[i,j] = tileTemp2;
                    miroirMario[i, miroirMario.GetLongLength(1) - j-1] = tileTemp1;
                }
            }
            this.AddImage(miroirMario);
            this.ImageState = 0;
            //this.AddImage(Import.ImportTileMapCsv(@"GameTest/Images/bloc.csv"));
            //this.AddImage(Import.ImportTileMapCsv(@"Moteur/Modele_exemple/Personnage.csv"));
            this.Hitbox = new Hitbox(Position, new Vector2d(12, 16));
        }

        public override void Update()
        {
            LastPosition.PosX = Position.PosX;
            LastPosition.PosY = Position.PosY;

            Position.PosY += speedFall;
            speedFall += gravity;
            if (speedFall > maxSpeedFall) speedFall = maxSpeedFall;
            if (Position.PosY > 100) Position.PosY = 100;
            if (Position.PosX - Engine.Instance.Screen.Hitbox.Origin.PosX > 250)
                Engine.Instance.Screen.Hitbox.Origin = new Vector2d(Engine.Instance.Screen.Hitbox.Origin.PosX + 1, Engine.Instance.Screen.Hitbox.Origin.PosY);

            if (Position.PosX - Engine.Instance.Screen.Hitbox.Origin.PosX < 50)
                Engine.Instance.Screen.Hitbox.Origin = new Vector2d(Engine.Instance.Screen.Hitbox.Origin.PosX - 1, Engine.Instance.Screen.Hitbox.Origin.PosY);

            if (Position.PosY - Engine.Instance.Screen.Hitbox.Origin.PosY > 100)
                Engine.Instance.Screen.Hitbox.Origin = new Vector2d(Engine.Instance.Screen.Hitbox.Origin.PosX, Engine.Instance.Screen.Hitbox.Origin.PosY+1);

            if (Position.PosY - Engine.Instance.Screen.Hitbox.Origin.PosY < 50)
                Engine.Instance.Screen.Hitbox.Origin = new Vector2d(Engine.Instance.Screen.Hitbox.Origin.PosX, Engine.Instance.Screen.Hitbox.Origin.PosY-1);

            //////////////////////////////////////////////////////
            if (Input.IsKeyDown(ConsoleKey.Spacebar)) speedFall = jumpForce;
            if (Input.IsKeyDown(ConsoleKey.RightArrow))
            {
                Position.PosX += 4;
                this.ImageState = 0;
            }
            if (Input.IsKeyDown(ConsoleKey.LeftArrow))
            {
                Position.PosX -= 4;
                this.ImageState = 1;
            }
            //////////////////////////////////////////////////////

            
            this.Hitbox.Origin = Position;

        }

        public override void PhysicsUpdate(Component component)
        {
            
            if (component.Name == "platforme")
            {
                if (component.Hitbox.CollideWith(this.Hitbox)){
                    //this.speedFall = jumpForce;
                    Vector2d PositionTemp = new Vector2d(Position.PosX, Position.PosY);
                    int distX = Math.Abs(LastPosition.PosX - Position.PosX);
                    int distY = Math.Abs(LastPosition.PosY - Position.PosY);
                    int greaterDistance = distX >= distY ? distX : distY;
                    if(greaterDistance != 0)
                    {
                        decimal stepX = distX / greaterDistance;
                        decimal stepY = distY / greaterDistance;

                        for (int i = 0; component.Hitbox.CollideWith(this.Hitbox); i++)
                        {
                            if (PositionTemp.PosX > LastPosition.PosX) 
                                Position.PosX = PositionTemp.PosX - ((int)stepX * i);

                            else if (PositionTemp.PosX < LastPosition.PosX) 
                                Position.PosX = PositionTemp.PosX + ((int)stepX * i);


                            if (PositionTemp.PosY > LastPosition.PosY) 
                                Position.PosY = PositionTemp.PosY - ((int)stepY * i);

                            else if (PositionTemp.PosY < LastPosition.PosY) 
                                Position.PosY = PositionTemp.PosY + ((int)stepY * i);


                            this.Hitbox.Origin = Position;
                        }
                    }
                }
                     
            }
        }
    }
}
