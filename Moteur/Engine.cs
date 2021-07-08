using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void Run()
        {
            while (true)
            {
                foreach(Component component in components)
                {
                    component.Update();
                }
                PhysicsStep();
                DisplayEveryComponent();
                Thread.Sleep(16);
            }
            
        }
        public void AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }

        public void PhysicsStep()
        {
            for (int i = 0; i < components.Count; i++)
            {
                for (int j = 0; j < components.Count; j++)
                {
                    if(!components[i].Equals(components[j]))
                        components[i].CollideReact(components[j]);
                }
            }
        }

        public void DisplayEveryComponent()
        {
            List< Component> componentsVisible = new();
            foreach(Component component in components)
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
