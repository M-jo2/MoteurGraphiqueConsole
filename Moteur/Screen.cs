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
            Console.SetBufferSize(300, 180);
            
            this.Hitbox = new Hitbox(new Vector2d(0, 0), new Vector2d(Console.WindowWidth,Console.WindowHeight));
        }

        public void Display(List<Component> components)
        {
            Console.CursorVisible = false;
            Console.Clear();
            foreach (Component component in components)
            {
                Tile[,] componentDraw = component.GetImage();
                
                for (int i = 0; i < componentDraw.GetLength(0); i++)
                {
                    for (int j = 0; j < componentDraw.GetLength(1); j++)
                    {
                        Vector2d tilePos = new Vector2d()
                        {
                            PosX = component.Hitbox.Origin.PosX + j,
                            PosY = component.Hitbox.Origin.PosY + i
                        };

                        if (this.Hitbox.VectorInside(tilePos))
                        {
                            Console.SetCursorPosition(tilePos.PosX, tilePos.PosY);
                            Console.ForegroundColor = componentDraw[i, j].charColor;
                            Console.BackgroundColor = componentDraw[i, j].backgroundColor;
                            Console.Write(componentDraw[i, j].tileChar);
                            Console.ResetColor();
                            

                        }

                    }

                }
            }
            
        }
    }
}
