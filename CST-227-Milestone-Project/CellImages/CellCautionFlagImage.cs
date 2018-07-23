using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class CellCautionFlagImage : CellFlagImage, ICellImage
    {

        protected override string IconText => "";
        protected override Color FlagColor => Color.Yellow;

        public CellCautionFlagImage(GameCell gameCell) : base(gameCell)
        {
        }
    }
}
