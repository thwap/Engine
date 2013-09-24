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
        enum FileType
        {
            Texture,
            Audio,
            NotSupported
        }

        static string[] textureTypes = { ".jpg", ".png" };
        static string[] audioTypes = { ".mp3", ".wav" };
        static string directory = null;
        static Dictionary<string, object> assetList = new Dictionary<string,object>();
        
        public static void init(string dir = "Data")
        {
            directory = dir;
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    switch (CheckExtension(file))
                    {
                        case FileType.Texture:
                            LoadTexture();
                            break;
                        case FileType.NotSupported:
                            break;
                    }
                }
            }
            else
            {
                string error = "The Data directory  " + directory + " does not exist";
                System.Diagnostics.Debug.Assert(false, error);
            }
        }
        public static T Load<T>(string asset) {
            if (assetList.ContainsKey(asset))
                return (T)assetList[asset];
            else
                return default(T);
        }

        static Texture LoadTexture() {
            throw new NotImplementedException();
        }

        static FileType CheckExtension(string file)
        {
            string extension = Path.GetExtension(file);
            foreach (string ext in textureTypes)
            {
                if (extension == ext)
                    return FileType.Texture;
            }

            foreach (string ext in audioTypes)
            {
                if (extension == ext)
                    return FileType.Audio;
            }

            return FileType.NotSupported;
        }
    }
}
