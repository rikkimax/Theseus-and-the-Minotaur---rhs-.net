using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATM.LevelDesigner
{
    interface IView
    {
        void drawMap();
        void drawCell(int x, int y, bool[] walls);
        void draw();
        void drawCellBorder(uint x, uint y, int border);
        void drawHighlightedCell();
        void drawHighlightedWall();
        void drawEntity(int entity, int x, int y);
        void show();
    }
}
