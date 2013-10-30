using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TATM.SCB.models
{
    public class Border
    {
        [XmlAttribute]
        public bool right;
        [XmlAttribute]
        public bool down;

        public Border()
        {
        }

        public Border(bool theRight, bool theDown)
        {
            this.right = theRight;
            this.down = theDown;
        }
    }
}
