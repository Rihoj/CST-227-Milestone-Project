using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    abstract class CellImage : ICellImage
    {
        protected Bitmap image;
        public Bitmap Image { get { return image; } }
        protected GameCell gc;
        protected int CellWidth;
        protected int CellHeight;
        protected Color lightGray = Color.FromArgb(255, 204, 204, 204);
        protected Color mediumGray = Color.FromArgb(255, 136, 136, 136);
        protected Color darkGray = Color.FromArgb(255, 68, 68, 68);
        Brush brush = new SolidBrush(Color.Black);
        Font font;
        protected abstract string IconText { get; }
        
        public CellImage(GameCell gameCell)
        {
            gc = gameCell;
            CellWidth = gameCell.CellWidth;
            CellHeight = gameCell.CellHeight;
            font = new Font("Courier New", CellWidth, GraphicsUnit.Pixel);
            CreateImage();
            CreateIcon();
        }

        protected virtual CellImage CreateImage()
        {
            image = new Bitmap(CellWidth, CellHeight);
            for (int x = 0; x < CellWidth; x++)
            {
                for (int y = 0; y < CellHeight; y++)
                {
                    if (x == 0 || y == 0 || x == CellWidth || y == CellHeight)
                    {
                        image.SetPixel(x, y, darkGray);
                    }
                    else
                    {
                        image.SetPixel(x, y, lightGray);
                    }
                }
            }
            return this;
        }

        protected virtual CellImage CreateIcon()
        {
            Graphics drawing = Graphics.FromImage(image);
            drawing.DrawString(IconText, font, brush, 0, 0);
            return this;
        }
    }
}
