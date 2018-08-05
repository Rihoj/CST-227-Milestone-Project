using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST_227_Milestone_Project.Interfaces;

namespace CST_227_Milestone_Project.BoardSizes
{
    class MedBoard : IBoardSize
    {
        public int Size { get; } = 20;

        public string Name { get; } = "Medium";
    }
}
