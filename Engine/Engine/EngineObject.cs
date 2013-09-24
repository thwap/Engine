using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The base class for all objects created in the framework
    /// It contains the basic information related to the object regardless its inheritance
    /// </summary>
    public class EngineObject
    {
        string name;
        int instaceID;
        bool RemoveObject = false;

        static int ID = 0;


        //Constructor
        public EngineObject()
        {
            //Give unique id to Object
            instaceID = ID;
            //Increase the ID when new Object is crated
            ID++;
        }

        /// <summary>
        /// Returns the ID of the object
        /// </summary>
        /// <returns>int</returns>
        public int GetInstanceID()
        {
            return instaceID;
        }


        /// <summary>
        /// Returns the name of Object
        /// </summary>
        /// <returns>string</returns>
        public string ToString()
        {
            return name;
        }

        internal static void RemoveObject(EngineObject Obj)
        {
            if (Obj is GameObject)
            {
                GameObject o = (GameObject)Obj;
                //o.ClearComponentList();
            }
            else if (Obj is Component)
            {
                Component comp = (Component)Obj;

            }

        }

        /// <summary>
        /// Destroys the object from scene
        /// </summary>
        /// <param name="Obj"></param>
        public static void Destroy(EngineObject Obj)
        {
            if (Obj is GameObject)
            {
                GameObject o = (GameObject)Obj;
                //o.RemoveObject = true;
            }
            else if (Obj is Component)
            {
                Component comp = (Component)Obj;
                //comp.RemoveObject = true;
            }
        }


        //Clones the object original and returns the clone.
        public static EngineObject Instantiate(EngineObject Obj)
        {
            //Todo
            return Obj;
        }
    }
}
