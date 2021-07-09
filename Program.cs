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
            //////////Threads
            //CancellationTokenSource cts = new CancellationTokenSource();
            //ThreadPool.QueueUserWorkItem(new WaitCallback(new Object), cts.Token);
            //cts.Cancel();
            //cts.Dispose();


            Mario mario = new();
            Engine.Instance.Screen.SizeWindow = new Vector2d(300, 120);


            for (int i = 0; i < 20; i++)
            {
                Plateform plateform = new();
                plateform.Position = new Vector2d(50 + 6 * i, 80);
                Engine.Instance.AddComponent(plateform);
            }
            for (int i = 1; i < 20; i++)
            {
                Plateform plateform = new();
                plateform.Position = new Vector2d(50, 80-6*i);
                Engine.Instance.AddComponent(plateform);
            }
            Engine.Instance.AddComponent(mario);
            Engine.Instance.Run();
            
        }
    }
}
