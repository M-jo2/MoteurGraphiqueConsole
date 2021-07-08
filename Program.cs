using MoteurGraphiqueConsole.Moteur;
using MoteurGraphiqueConsole.Moteur.ReadFile;
using System;
using System.Threading;
using MoteurGraphiqueConsole.Moteur.Input_Manage;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using MoteurGraphiqueConsole.GameTest.GameComponent;

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


            Mario mario = new();
            Plateform plateform = new();
            plateform.Position = new Vector2d(50, 80);


            Engine.Instance.AddComponent(plateform);
            Engine.Instance.AddComponent(mario);

            Engine.Instance.Run();
            
        }
    }
}
