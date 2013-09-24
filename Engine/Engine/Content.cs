using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Engine
{
    public static class Content
    {
        static Dictionary<string, object> assetList = new Dictionary<string,object>();
        
        public static void init(string directory = "Content")
        {
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    //TODO
                }
            }
            else
            {
                string error = "The contend directory  " + directory + " does not exist";
                System.Diagnostics.Debug.Assert(false, error);
            }
        }
        public static T Load<T>(string asset) {
            throw new NotImplementedException();
        }

        static Texture LoadTexture() {
            throw new NotImplementedException();
        }
    }
}
