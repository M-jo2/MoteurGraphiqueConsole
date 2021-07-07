using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    class Screen : Component
    {
        public Screen()
        {
            this.Hitbox = new Hitbox(new Vector2d(0, 0), new Vector2d(Console.WindowWidth,Console.WindowHeight));
        }
        public override void CollideReact(Component component)
        {
            if (this.Hitbox.CollideWith(component.Hitbox))
            {
                Display(component);
            }
        }

        public void Display(Component component)
        {
            Tile[,] componentDraw = component.GetImage();

            for (int i = 0; i < componentDraw.GetLength(0); i++)
            {
                for (int j = 0; j < componentDraw.GetLength(1); j++)
                {
                    Vector2d tilePos = new Vector2d() { PosX = component.Hitbox.Origin.PosX+j, 
                                                        PosY = component.Hitbox.Origin.PosY+i};

                    if (this.Hitbox.VectorInside(tilePos))
                    {
                        Console.SetCursorPosition(tilePos.PosX, tilePos.PosY);
                        Console.ForegroundColor = componentDraw[j,i].charColor;
                        Console.BackgroundColor = componentDraw[j, i].backgroundColor;
                        Console.Write(componentDraw[j, i].tileChar);
                    }
                    
                }

            }
        }
    }
}
