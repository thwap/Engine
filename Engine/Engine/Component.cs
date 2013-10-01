using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Component inherits from EngineObject
    /// It is the base class for all user created scripts attached to a GameObject
    /// </summary>
    public class Component:EngineObject
    {
        public GameObject gameObject;
        public Transform transform;

        public virtual void Update()
        { 
        }
        public virtual void Start()
        {
        }
    }
}
