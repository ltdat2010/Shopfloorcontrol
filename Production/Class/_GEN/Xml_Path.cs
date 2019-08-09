using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Production.Class._GEN
{
    class Xml_Path
    {
        public static string Create_Temp_Xml()
        {
            string XmlSourcePath = @"D:\Temp_Xml";
            // If directory does not exist, create it. 
            if (!System.IO.Directory.Exists(XmlSourcePath))
            {
                System.IO.Directory.CreateDirectory(XmlSourcePath);
            }
            return XmlSourcePath;
        }
        
    }
}
