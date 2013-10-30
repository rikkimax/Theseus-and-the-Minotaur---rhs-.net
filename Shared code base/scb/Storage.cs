using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TATM.SCB.models;

namespace TATM.SCB.scb
{
    class Storage
    {
        public static GameSettings settings { get; set; }

        public static bool Save(/*GameSettings gs*/)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(gs.GetType());
            x.Serialize(Console.Out, gs.GetType());
            System.IO.StreamWriter file = new System.IO.StreamWriter(
    @"%APPDATA%/TATMRHS/data.xml");
            x.Serialize(file, gs);
            file.Close();
            return true;
        }

        public static GameSettings Load()
        {
            return null;
        }
    }
}
