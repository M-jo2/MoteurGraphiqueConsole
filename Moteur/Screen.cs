using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    class Screen : Component
    {
        private List<Vector2d> lastPixelChanged = new List<Vector2d>();
        private List<Vector2d> pixelChanged = new List<Vector2d>();


        public Screen()
        {
            bool screenOk = false;
            do
            {
                try
                {
                    Console.SetWindowSize(80, 10);
                    Console.SetBufferSize(301, 121);
                    Console.SetWindowSize(300, 120);
                    screenOk = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Attention : Taille de police probablement trop élevée.");
                    Console.WriteLine("N'importe quelle touche pour continuer.");
                    Console.ReadKey();
                }
            } while (!screenOk);
            
            
            
            
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

                            //if (!pixelChanged.Contains(tilePos)) pixelChanged.Add(tilePos);
                            
                        }
                    }
                }
            }
            //EraseLastScreen();

        }


        private void EraseLastScreen()
        {
            foreach(Vector2d vector2D in pixelChanged)
            {
                if (lastPixelChanged.Contains(vector2D)) lastPixelChanged.Remove(vector2D);
            }
            foreach(Vector2d vector2D in lastPixelChanged)
            {
                ResetPixel(vector2D);
            }
            lastPixelChanged.Clear();
            foreach(Vector2d vector2D in pixelChanged)
            {
                lastPixelChanged.Add(vector2D);
            }
        }

        private void ResetPixel(Vector2d pos)
        {
            Console.SetCursorPosition(pos.PosX, pos.PosY);
            Console.Write(" ");
        }
    }
}
