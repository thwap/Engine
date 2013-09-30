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
        /// <summary>
        /// Name of the object
        /// </summary>
        public string name;
        /// <summary>
        /// Unique instance number of the object
        /// </summary>
        public int instanceID;

        private static int ID = 0;


        //Constructor
        /// <summary>
        /// Default constructor for the EngineObject, creates a new EngineObject
        /// </summary>
        public EngineObject()
        {
            //Give unique id to Object
            instanceID = ID;
            //Increase the ID when new Object is crated
            ID++;
        }
        /// <summary>
        /// Constructor for the EngineObject, creates a new EngineObject with given name
        /// </summary>
        /// <param name="name"></param>
        public EngineObject(string name)
        {
            this.name = name;
            instanceID = ID;
            ID++;
        }

        /// <summary>
        /// Returns the ID of the object
        /// </summary>
        /// <returns>int</returns>
        public int GetInstanceID()
        {
            return instanceID;
        }


        /// <summary>
        /// Returns the name of Object
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
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
        /// Destroys the object from the scene
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
