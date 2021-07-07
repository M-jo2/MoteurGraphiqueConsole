using MoteurGraphiqueConsole.Moteur;
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
            Tile[,] testTiles =new Tile[,] 
            { 
                { tileExample, tileExample, tileExample },
                { tileExample, tileExample, tileExample },
                { tileExample, tileExample, tileExample }
            };


            test.AddImage(testTiles);
            test.Hitbox = new Hitbox(new Vector2d(10, 10), new Vector2d(5, 5));
            Engine.Instance.AddComponent(test);
            Engine.Instance.Run();


            
        }
    }
}
