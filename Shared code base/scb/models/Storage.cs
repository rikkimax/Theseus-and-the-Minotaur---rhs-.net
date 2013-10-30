using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TATM.SCB.models
{
    public class Storage
    {
        public static GameSettings settings { get; set; }

        public static bool isRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
        public static string getFilename()
        {
            if (isRunningOnMono())
                return "~/TATMRHS/data.xml";
            else
                return "%APPDATA%/TATMRHS/data.xml";
        }
        public static void save()
        {
            String filename;
            XmlSerializer x = new XmlSerializer(settings.GetType());
            x.Serialize(Console.Out, settings.GetType());
            filename = getFilename();
            StreamWriter file = new StreamWriter(@filename);
            x.Serialize(file, settings);
            file.Close();
        }
        public static GameSettings load()
        {
            String filename;
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
            filename = getFilename();
            // Reading the XML document requires a FileStream.
            Stream reader = new FileStream(filename, FileMode.Open);
            // Call the Deserialize method to restore the object's state.
            settings = (GameSettings)serializer.Deserialize(reader);
            return settings;
        }
    }
}