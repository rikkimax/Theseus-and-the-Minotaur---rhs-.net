using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TATM.SCB.models
{
    public class Cell
    {
        [XmlAttribute]
        public uint x, y;
        public Border border;
        [XmlAttribute]
        public bool isExit;
        [XmlAttribute]
        public bool inAccessible;

        public Cell()
        {
            border = new Border();
        }

        public Cell(uint theX, uint theY, Border theBorder, bool theIsExit, bool theInAccessible)
        {
            this.x = theX;
            this.y = theY;
            this.border = theBorder;
            this.isExit = theIsExit;
            this.inAccessible = theInAccessible;
        }
    }
}
