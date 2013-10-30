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

        public static string GetFilePath()
        {
            string path;
            if (IsRunningOnMono())
            {
                return "~/TATMRHS/";
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return System.IO.Path.Combine(path, "TATMRHS");
            }
        }

        public static void Save()
        {
            CheckDirectory();

            try
            {
                String filePath = GetFilePath();
                string filename = System.IO.Path.Combine(filePath, "data.xml");
                XmlSerializer ser = new XmlSerializer(typeof(GameSettings));
                TextWriter writer = new StreamWriter(filename);
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
            String filePath = GetFilePath();
            string filename = System.IO.Path.Combine(filePath, "data.xml");
            CheckDirectory();
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer = new XmlSerializer(typeof(GameSettings));
            // Reading the XML document requires a FileStream.
            Stream reader = new FileStream(filename, FileMode.Open);
            // Call the Deserialize method to restore the object's state.
            settings = (GameSettings)serializer.Deserialize(reader);
            return settings;
        }

        public static void CheckDirectory()
        {
            // does directory exist?
            // if not create
            String filePath = GetFilePath();
            //if the file doesnt exist
            if (!File.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
        }
    }
}
