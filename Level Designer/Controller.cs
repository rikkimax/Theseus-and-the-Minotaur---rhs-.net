using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TATM.SCB.models;

namespace TATM.LevelDesigner
{
    class Controller
    {
        IView view;
        GameBoard map;

        public Controller(IView newView)
        {
            this.view = newView;
            this.map = new GameBoard();
        }

        public void draw()
        {
            if (this.map.cells != null)
            {
                this.calculateCells();
                this.view.drawMap();
                this.calculateWalls();
                this.view.drawHighlightedCell();
                this.view.drawHighlightedWall();
                this.calculateEntities();
            }
        }

        private void calculateCells()
        {
            foreach (Cell cell in this.map.cells)
            {
                this.view.drawCell((int)cell.x, (int)cell.y,             
                    new bool[]{(cell.y == 0 || (!this.cellExists((int)cell.x, (int)cell.y - 1))), 
                        (!this.cellExists((int)cell.x + 1, (int)cell.y)),
                        (!this.cellExists((int)cell.x, (int)cell.y + 1)), 
                        (cell.x == 0 || !this.cellExists((int)cell.x - 1, (int)cell.y))});
            }
        }

        private void calculateWalls()
        {
            foreach (Cell cell in this.map.cells)
            {
                if (cell.border.right) this.view.drawCellBorder(cell.x, cell.y, 1);
                if (cell.border.down) this.view.drawCellBorder(cell.x, cell.y, 2);
            }
        }

        public bool isAllowedWall(int x, int y, int wall)
        {
            //TODO check if the wall is allowed for the cell
            bool result = true;

            result = x + 1 < this.map.width;
            result = y + 1 < this.map.height;

            return result;
        }

        private void calculateEntities()
        {
            if (this.map.theseus != null) this.view.drawEntity(1, (int)this.map.theseus.startX, (int)this.map.theseus.startY);
            if (this.map.minotaur != null) this.view.drawEntity(2, (int)this.map.minotaur.startX, (int)this.map.minotaur.startY);

            int[] exit = this.getExit();
            if (exit != null) this.view.drawEntity(3, exit[0], exit[1]);
        }

        public void createMap(int cols, int rows)
        {
            this.map.cells = new List<Cell>();
            this.map.height = (uint)rows;
            this.map.width = (uint)cols;

            for (uint i = 0; i < cols; i++)
            {
                for (uint j = 0; j < rows; j++)
                {
                    Cell cell = new Cell(i, j, new Border(false, false), false, true);
                    this.map.cells.Add(cell);
                }
            }
        }

        public void setWall(int x, int y, int wall)
        {
            if (this.cellExists(x, y))
            {
                if (wall == 2) this.getCell(x, y).border.right = !this.getCell(x, y).border.right;
                if (wall == 3) this.getCell(x, y).border.down = !this.getCell(x, y).border.down;
            }
        }

        public void removeCell(int x, int y)
        {
            foreach (Cell cell in this.map.cells)
            {
                if (cell.x == x && cell.y == y)
                {
                    this.map.cells.Remove(cell);
                    break;
                }
            }
        }

        public void addCell(int x, int y)
        {
            if (!this.cellExists(x, y))
            {
                Cell cell = new Cell((uint)x, (uint)y, new Border(false, false), false, false);
                this.map.cells.Add(cell);
            }
        }

        private Cell getCell(int x, int y)
        {
            Cell result = null;

            foreach (Cell cell in this.map.cells)
            {
                if (cell.x == (uint)x && cell.y == (uint)y)
                {
                    result = cell;
                    break;
                }
            }

            return result;
        }

        private bool cellExists(int x, int y)
        {
            bool result = false;

            foreach (Cell cell in this.map.cells)
            {
                if (cell.x == (uint)x && cell.y == (uint)y)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void setEntity(string name, int x, int y)
        {
            switch (name)
            {
                case "theseus":
                    this.map.theseus = new Entity((uint)x, (uint)y);
                    break;

                case "minotaur":
                    this.map.minotaur = new Entity((uint)x, (uint)y);
                    break;

                case "exit":
                    this.setExit(x, y);
                    break;
            }
        }

        private void setExit(int x, int y)
        {
            foreach (Cell cell in this.map.cells)
            {
                if (cell.isExit)cell.isExit = false;
                if (cell.x == (uint)x && cell.y == (uint)y) cell.isExit = true;
            }
        }

        private int[] getExit()
        {
            int[] result = null;

            foreach (Cell cell in this.map.cells)
            {
                if (cell.isExit)
                {
                    result = new int[]{(int)cell.x, (int)cell.y};
                    break;
                }
            }

            return result;
        }
    }
}
