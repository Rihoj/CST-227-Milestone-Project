using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    class GameCell
    {
        public int CellHeight { get; set; } = 30;
        public int CellWidth { get; set; } = 30;
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;
        public int LiveNeighbors { get; set; } = 0;
        public ICellImage Image { get; set; }

        public GameCell(int x, int y)
        {
            X = x;
            Y = y;
            Image = new CellBaseImage(this);
        }

        public GameCell(int cellHeight, int cellWidth, int x, int y) : this(x, y)
        {
            X = x;
            Y = y;
        }

        public GameCell(int x, int y, bool visited, bool live, int liveNeighbors) : this(x, y)
        {
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }

        public void ClickCell()
        {
            if (Live)
            {
                Image = new CellHitImage(this);
            }
            else
            {
                Image = new CellSafeImage(this);
            }
        }

    }
}
