using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project.Interfaces
{
    public interface IDifficulty
    {
        decimal Difficulty
        {
            get;
        }

        string Name
        {
            get;
        }
    }
}
