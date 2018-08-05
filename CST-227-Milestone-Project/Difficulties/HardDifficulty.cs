using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST_227_Milestone_Project.Interfaces;

namespace CST_227_Milestone_Project.Difficulties
{
    class HardDifficulty : IDifficulty
    {
        public decimal Difficulty
        {
            get;
        } = .20M;

        public string Name
        {
            get;
        } = "Hard";
    }
}
