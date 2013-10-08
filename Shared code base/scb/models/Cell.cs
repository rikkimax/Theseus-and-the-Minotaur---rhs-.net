using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    public class Cell
    {
        public uint x, y;
        public Border border;
        public bool isExit;
        public bool inAccessible;
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
