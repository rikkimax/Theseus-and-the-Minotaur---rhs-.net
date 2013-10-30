using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TATM.SCB.models
{
    public class GameBoard
    {
        [XmlAttribute]
        public uint level;
        public Entity theseus;
        public Entity minotaur;
        [XmlAttribute]
        public uint width, height;
        public List<Cell> cells;

        public GameBoard()
        {
            cells = new List<Cell>();
            theseus = new Entity();
            minotaur = new Entity();
        }
    }
}
