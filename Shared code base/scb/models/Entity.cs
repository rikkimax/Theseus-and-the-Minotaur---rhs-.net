using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    public class Entity
    {
        public uint startX, startY;
        public Entity(uint theStartX, uint theStartY)
        {
            this.startX = theStartX;
            this.startY = theStartY;
        }
    }
}
