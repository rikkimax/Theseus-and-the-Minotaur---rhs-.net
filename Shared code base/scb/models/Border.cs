using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    public class Border
    {
        public bool right;
        public bool down;
        public Border(bool theRight, bool theDown)
        {
            this.right = theRight;
            this.down = theDown;
        }
    }
}
