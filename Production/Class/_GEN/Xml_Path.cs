namespace Production.Class._GEN
{
    internal class Xml_Path
    {
        //PC Name
        public static string PCname = System.Environment.MachineName;

        public static string Create_Temp_Xml()
        {

            
            string XmlSourcePath = string.Empty;

            if (PCname == "vpv-lab-sample")
                XmlSourcePath = @"D:\Temp_Xml";
            else
                XmlSourcePath = @"X:\Temp_Xml";
            
            // If directory does not exist, create it.
            if (!System.IO.Directory.Exists(XmlSourcePath))
            {
                System.IO.Directory.CreateDirectory(XmlSourcePath);
            }
            return XmlSourcePath;
        }
    }
}