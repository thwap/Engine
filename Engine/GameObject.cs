using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class GameObject : EngineObject
    {
        private bool _updated;
        private List<Component> _components;
        public virtual void initGameObject()
        {
        }
        public virtual void Render()
        {

        }
        public virtual void Update()
        {

        }
        public bool isUpdated()
        {
            return _updated;
        }
    }
}
