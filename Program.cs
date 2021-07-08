using MoteurGraphiqueConsole.Moteur;
using MoteurGraphiqueConsole.Moteur.ReadFile;
using System;
using System.Threading;

namespace MoteurGraphiqueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancellationTokenSource cts = new CancellationTokenSource();
            //ThreadPool.QueueUserWorkItem(new WaitCallback(new Object), cts.Token);
            //cts.Cancel();
            //cts.Dispose();

            Component test = new();
            Tile tileExample = new Tile('a', ConsoleColor.White, ConsoleColor.Black);
            Tile[,] testTiles = Import.ImportTileMapCsv(@"Moteur/Modele_exemple/Personnage.csv");

            Engine.Instance.AddComponent(test);
            test.AddImage(testTiles);

            int gravity = 1;
            int speedFall = 0;
            int maxSpeedFall = 5;
            int jumpForce = -10;

            int xPos = 20;
            int yPos = 20;

            while (true)
            {
                yPos += speedFall;
                speedFall += gravity;
                if (speedFall > maxSpeedFall) speedFall = maxSpeedFall;
                if (yPos > 100) yPos = 100;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(false);
                    if (key.Key == ConsoleKey.Spacebar) speedFall = jumpForce;
                    if (key.Key == ConsoleKey.RightArrow) xPos+=3;
                    if (key.Key == ConsoleKey.LeftArrow) xPos-=3;

                }

                test.Hitbox = new Hitbox(new Vector2d(xPos, yPos), new Vector2d(5, 5));
                
                Engine.Instance.Run();
                Thread.Sleep(20);
            }
            
        }
    }
}
