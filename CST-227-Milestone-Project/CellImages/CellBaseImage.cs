using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class CellBaseImage : CellImage, ICellImage
    {

        protected override string IconText => "";

        public CellBaseImage(GameCell gameCell) : base(gameCell)
        {
        }

        protected override CellImage CreateImage()
        {
            image = new Bitmap(CellWidth, CellHeight);
            for (int x = 0; x < CellWidth; x++)
            {
                for (int y = 0; y < CellHeight; y++)
                {
                    if (x == 0 || y == 0 || x == CellWidth-1 || y >= CellHeight-1)
                    {
                        image.SetPixel(x, y, darkGray);
                    }else if(x <= 2 || y <= 2 || x >= CellWidth - 2 || y >= CellHeight - 2)
                    {
                        image.SetPixel(x, y, mediumGray);
                    }
                    else
                    {
                        image.SetPixel(x, y, lightGray);
                    }
                }
            }
            return this;
        }
    }
}
