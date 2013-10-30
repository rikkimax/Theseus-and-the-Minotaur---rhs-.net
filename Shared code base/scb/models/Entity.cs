using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TATM.SCB.models
{
    public class Entity
    {
        [XmlAttribute]
        public uint startX, startY;

        public Entity()
        {
        }

        public Entity(uint theStartX, uint theStartY)
        {
            this.startX = theStartX;
            this.startY = theStartY;
        }
    }
}
