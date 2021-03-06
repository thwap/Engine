﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tao.DevIl;
using System.Windows.Forms;


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
        static Dictionary<string, object> assetList = new Dictionary<string,object>();
        
        public static void init(string directory = "Data")
        {
            if (Directory.Exists(directory))
            {
                foreach (string dir in Directory.GetDirectories(directory))
                    init(dir);
                foreach (string file in Directory.GetFiles(directory))
                {
                    switch (CheckExtension(file))
                    {
                        case FileType.Texture:
                            Console.WriteLine(Path.GetFileName(file));
                            assetList.Add(Path.GetFileNameWithoutExtension(file), LoadTexture(file));
                            break;
                        case FileType.NotSupported:
                            break;
                    }
                }
            }
            else
            {
                string error = "The directory  " + Application.StartupPath + "\\" + directory + " does not exist";
                System.Diagnostics.Debug.Assert(false, error);
            }
        }
        public static T Load<T>(string asset) {
            if (assetList.ContainsKey(asset))
                return (T)assetList[asset];
            else
                return default(T);
        }

        static Texture LoadTexture(string file) {
            int devilId = 0;
            Il.ilGenImages(0, out devilId);
            Il.ilBindImage(devilId);

            if (!Il.ilLoadImage(file))
            {
                string error = "Could not open file: " + file;
                System.Diagnostics.Debug.Assert(false, error);
            }

            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int openglId = Ilut.ilutGLBindTexImage();

            if (openglId == 0)
            {
                string error = "Something went wrong";
                System.Diagnostics.Debug.Assert(false, error);
            }

            Il.ilDeleteImages(1, ref devilId);
            return new Texture(openglId, devilId, width, height);
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
