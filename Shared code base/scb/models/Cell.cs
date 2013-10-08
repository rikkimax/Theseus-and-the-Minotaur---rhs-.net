using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    class Cell
    {
        uint x, y;
        Border border;
        bool isExit;
        bool inAccessible;
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
