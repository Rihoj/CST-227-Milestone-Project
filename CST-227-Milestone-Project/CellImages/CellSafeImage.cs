using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class CellSafeImage : CellImage, ICellImage
    {

        public CellSafeImage(GameCell gameCell) : base(gameCell)
        {
        }

        protected override string IconText => (gc.Neighbors.LiveNeighbors == 0) ? " " : gc.Neighbors.LiveNeighbors.ToString();
    }
}
