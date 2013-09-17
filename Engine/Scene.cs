using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Scene : EngineObject
    {
        private List<GameObject> _gameobjects;
        public virtual void initScene()
        {  

        }
        private void Run()
        {
            // loops trought list and updates objects
        }
        public virtual void Render()
        {
            // loops trough objects and if object has "updated" rendedrs it
        }
    }
}
