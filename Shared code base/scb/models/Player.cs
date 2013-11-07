using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TATM.SCB.models
{
    public class Player
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public double highscore; // time
        [XmlAttribute]
        public uint unlockMapLevel;

        public Player()
        {
        }
    }
}
