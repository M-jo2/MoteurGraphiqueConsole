using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace MoteurGraphiqueConsole.Moteur
{
    class Engine
    {
        //construct
        #region
        private static Engine _instance;
        static readonly object instanceLock = new object();

        private Engine(){
            FpsMax = 60;
            Screen = new Screen();

        }

        public static Engine Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Engine();
                    }
                }
                return _instance;
            }
        }


        #endregion



        private List<Component> components = new List<Component>();
        public int FpsMax { get; set; }

        public Screen Screen { get; set; }

        private bool goLoop = true;
        public void CanLoop(object source, EventArgs e) { goLoop = true; }
        public void Run()
        {
            System.Timers.Timer loopTiming = new() { Interval = 50 };
            loopTiming.Elapsed += new ElapsedEventHandler(CanLoop);
            loopTiming.Start();
            while (true)
            {
                if (goLoop)
                {
                    UpdateStep();
                    PhysicsStep();
                    DisplayStep();
                    goLoop = false;
                }
                
            }
        }
        public void AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }

        public void UpdateStep()
        {
            foreach (Component component in components)
            {
                component.Update();
            }
        }
        public void PhysicsStep()
        {
            for (int i = 0; i < components.Count; i++)
            {
                for (int j = 0; j < components.Count; j++)
                {
                    if(!components[i].Equals(components[j]))
                        components[i].PhysicsUpdate(components[j]);
                }
            }
        }

        public void DisplayStep()
        {
            List<Component> componentsVisible = new();
            foreach (Component component in components)
            {
                if (Screen.Hitbox.CollideWith(component.Hitbox))
                {
                    componentsVisible.Add(component);
                }
            }
            Screen.Display(componentsVisible);
        }
    }
}
