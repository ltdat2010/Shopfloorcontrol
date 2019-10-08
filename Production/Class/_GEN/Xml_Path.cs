namespace Production.Class._GEN
{
    internal class Xml_Path
    {
        public static string Create_Temp_Xml()
        {
            string XmlSourcePath = @"X:\Temp_Xml";
            // If directory does not exist, create it.
            if (!System.IO.Directory.Exists(XmlSourcePath))
            {
                System.IO.Directory.CreateDirectory(XmlSourcePath);
            }
            return XmlSourcePath;
        }
    }
}