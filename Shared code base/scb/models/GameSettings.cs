using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.SCB.models
{
    public class GameSettings
    {
        public List<Player> players;
        public List<GameBoard> maps;

        public GameSettings()
        {
            players = new List<Player>();
            maps = new List<GameBoard>();
        }
    }
}
