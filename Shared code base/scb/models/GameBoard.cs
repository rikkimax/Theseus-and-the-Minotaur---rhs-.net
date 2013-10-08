using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    class GameBoard
    {
        uint level;
        Entity theseus;
        Entity minotaur;
        uint width, height;
        List<Cell> cells;
    }
}
