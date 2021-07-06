using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void AddComponent(Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }
    }
}
