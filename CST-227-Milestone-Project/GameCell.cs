﻿using System;
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
        public Size Size { get; set; } = new Size(30, 30);
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public bool Visited { get; set; } = false;
        public bool Live { get; set; } = false;
        public Neighbors Neighbors { get; set; } = new Neighbors();
        public ICellImage Image { get; set; }

        public GameCell(int x, int y)
        {
            X = x;
            Y = y;
            Image = new CellBaseImage(this);
        }

        public GameCell(Size cellSize, int x, int y) : this(x, y)
        {
            Size = cellSize;
        }

        public GameCell(int x, int y, bool visited, bool live) : this(x, y)
        {
            Visited = visited;
            Live = live;
        }

        public void ClickCell()
        {
            Visited = true;
            Image = null;
            if (Live)
            {
                Image = new CellHitImage(this);
            }
            else
            {
                Image = new CellSafeImage(this);
            }
            Neighbors.CheckNeighbors();
        }

        public void FlagCell(bool success = false)
        {
            if (Image is CellBaseImage && success)
            {
                Image = new CellSuccessFlagImage(this);
            }
            else
            {
                if (Image is CellWarningFlagImage)
                {
                    Image = new CellBaseImage(this);
                }
                else if (Image is CellCautionFlagImage)
                {
                    Image = new CellWarningFlagImage(this);
                }
                else
                {
                    Image = new CellCautionFlagImage(this);
                }
            }
        }

    }
}
