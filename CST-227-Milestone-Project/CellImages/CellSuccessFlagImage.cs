﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class CellSuccessFlagImage : CellFlagImage, ICellImage
    {

        protected override string IconText => "";
        protected override Color FlagColor => Color.Green;

        public CellSuccessFlagImage(GameCell gameCell) : base(gameCell)
        {
        }
    }
}
