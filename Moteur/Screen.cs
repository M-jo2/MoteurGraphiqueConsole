using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurGraphiqueConsole.Moteur
{
    class Screen : Component
    {
        private Dictionary<Vector2d,Tile> lastPixelChanged = new Dictionary<Vector2d, Tile>();
        private Dictionary<Vector2d, Tile> pixelChanged = new Dictionary<Vector2d, Tile>();

        private Vector2d sizeWindow = new Vector2d(300, 160);

        public Vector2d SizeWindow { 
            get { return sizeWindow; }
            set 
            {
                bool screenOk = false;
                sizeWindow = value;
                do
                {
                    try
                    {
                        Console.SetWindowSize(80, 10);
                        Console.SetBufferSize(sizeWindow.PosX + 1, sizeWindow.PosY + 1);
                        Console.SetWindowSize(sizeWindow.PosX, sizeWindow.PosY);
                        screenOk = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Attention : Taille de police probablement trop élevée.");
                        Console.WriteLine("N'importe quelle touche pour continuer.");
                        Console.ReadKey();
                    }
                } while (!screenOk);

                this.Hitbox = new Hitbox(new Vector2d(0, 0), new Vector2d(Console.WindowWidth, Console.WindowHeight));
            } 
        }

        public void Display(List<Component> components)
        {
            Console.CursorVisible = false;
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
                            tilePos = new Vector2d(tilePos.PosX - this.Hitbox.Origin.PosX, tilePos.PosY - this.Hitbox.Origin.PosY);
                            if (!pixelChanged.ContainsKey(tilePos))
                                pixelChanged.Add(tilePos,new Tile(componentDraw[i, j].tileChar, 
                                    componentDraw[i, j].charColor, 
                                    componentDraw[i, j].backgroundColor));

                            //Console.SetCursorPosition(tilePos.PosX, tilePos.PosY);
                            //Console.ForegroundColor = componentDraw[i, j].charColor;
                            //Console.BackgroundColor = componentDraw[i, j].backgroundColor;
                            //Console.Write(componentDraw[i, j].tileChar);
                            //Console.ResetColor();

                            //if (!pixelChanged.Contains(tilePos)) pixelChanged.Add(tilePos);
                            
                        }
                    }
                }
            }
            UpdateScreen();
        }


        private void UpdateScreen()
        {
            List<Vector2d> pixelUpdated = new List<Vector2d>();

            foreach (Vector2d vector2D in pixelChanged.Keys)
            {
                if (!lastPixelChanged.ContainsKey(vector2D))
                    lastPixelChanged.Add(vector2D, new Tile(' ',(ConsoleColor)100, (ConsoleColor)100));
            }

            foreach (Vector2d vector2D in lastPixelChanged.Keys)
            {
                if (!pixelChanged.ContainsKey(vector2D))
                    ResetPixel(vector2D);
                else
                {
                    Tile newTile = pixelChanged[vector2D];
                    Tile oldTile = lastPixelChanged[vector2D];
                    bool isEqual = newTile.Equals(oldTile);
                    if (!isEqual)
                        SetPixel(pixelChanged[vector2D], vector2D);
                    pixelUpdated.Add(vector2D);
                }
            }

            

            lastPixelChanged.Clear();
            foreach (KeyValuePair<Vector2d,Tile> keyValuePair in pixelChanged)
            {
                lastPixelChanged.Add(keyValuePair.Key, keyValuePair.Value);
            }
            pixelChanged.Clear();
        }

        private void ResetPixel(Vector2d pos)
        {
            Console.SetCursorPosition(pos.PosX,  pos.PosY);
            Console.Write(" ");
        }

        private void SetPixel(Tile tile,Vector2d tilePos)
        {
            Console.SetCursorPosition(tilePos.PosX, tilePos.PosY);
            Console.ForegroundColor = tile.charColor;
            Console.BackgroundColor = tile.backgroundColor;
            Console.Write(tile.tileChar);
            Console.ResetColor();
        }
    }
}
