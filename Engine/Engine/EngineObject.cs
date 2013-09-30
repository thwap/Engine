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
        public string name;
        int instaceID;

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
                o.compList.Clear();

                o = null;
            }
            else if (Obj is Component)
            {
                Component comp = (Component)Obj;

                comp = null;
            }

        }

        /// <summary>
        /// Destroys the object from scene
        /// </summary>
        /// <param name="Obj"></param>
        public static void Destroy(EngineObject Obj)
        {
            if (Obj != null && Obj is EngineObject)
            {
                App.listToDestroy.Add(Obj);
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
