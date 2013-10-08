using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    public class GameBoard
    {
        public uint level;
        public Entity theseus;
        public Entity minotaur;
        public uint width, height;
        public List<Cell> cells;
    }
}
