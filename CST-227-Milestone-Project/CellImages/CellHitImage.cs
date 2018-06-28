using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class CellHitImage : CellImage, ICellImage
    {

        protected override string IconText => "*";

        public CellHitImage(GameCell gameCell) : base(gameCell)
        {
        }
    }
}
