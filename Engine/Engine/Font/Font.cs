using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Engine.Font
{
    class Font {
        
        Font font;
        //int fontSize;


        public Font(String fontName, float fontSize){
            try{
                this.font = new Font(fontName, fontSize);
            }catch (Exception e){
                Console.Write("Font not found" + e);
                this.font = new Font("Times New Roman", 12.0f);
            }
        }
    }
}
