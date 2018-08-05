using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST_227_Milestone_Project.Interfaces;

namespace CST_227_Milestone_Project.BoardSizes
{
    class LargeBoard : IBoardSize
    {
        public int Size { get; } = 25;

        public string Name { get; } = "Large";
    }
}
