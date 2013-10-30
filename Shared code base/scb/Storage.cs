using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using TATM.SCB.models;

namespace TATM.SCB
{
    public class Storage
    {
        public static GameSettings settings { get; set; }

        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        public static string GetFilename()
        {
            if (IsRunningOnMono())
                return "~/TATMRHS/data.xml";
            else
                return "%APPDATA%/TATMRHS/data.xml";
        }

        public static void Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(GameSettings));
                TextWriter writer = new StreamWriter("h:\\test.txt");
                ser.Serialize(writer, settings);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static GameSettings Load()
        {
            String filename;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
            filename = GetFilename();
            // Reading the XML document requires a FileStream.
            Stream reader = new FileStream(filename, FileMode.Open);
            // Call the Deserialize method to restore the object's state.
            settings = (GameSettings)serializer.Deserialize(reader);
            return settings;
        }
    }
}
