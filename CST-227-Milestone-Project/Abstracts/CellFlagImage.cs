using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    abstract class CellFlagImage : CellBaseImage, ICellImage
    {

        protected int offset = 5;
        protected int poleWidth = 2;
        protected int flagHeight = 15;
        protected int flagWidth = 10;

        protected abstract Color FlagColor { get; }

        public CellFlagImage(GameCell gameCell) : base(gameCell)
        {
        }

        protected override CellImage CreateImage()
        {
            base.CreateImage();
            int poleLeftBound = (CellWidth / 2) - poleWidth / 2 - offset;
            int poleRightBound = (CellWidth / 2) + poleWidth / 2 - offset;
            for (int x = 0; x < CellWidth; x++)
            {
                for (int y = 0; y < CellHeight; y++)
                {
                    if (y >= 5 && y <= CellHeight - 5)
                    {
                        if (x >= poleLeftBound && x <= poleRightBound)
                        {
                            image.SetPixel(x, y, Color.Black);
                        }
                        if (x > poleRightBound && x <= poleRightBound + flagWidth && y <= flagHeight)
                        {
                            image.SetPixel(x, y, FlagColor);
                        }
                    }
                }
            }
            return this;
        }
    }
}
