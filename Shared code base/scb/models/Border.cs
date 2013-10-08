using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    class Border
    {
	    bool right;
	    bool down;
        public Border(bool theRight, bool theDown)
        {
            this.right = theRight;
            this.down = theDown;
        }
    }
}
