using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST_227_Milestone_Project.Interfaces;
using System.Diagnostics;

namespace CST_227_Milestone_Project
{
    public class PlayerStat : IComparable<PlayerStat>
    {
        public string PlayerName { get; set; }
        public string BoardSize { get; set; }
        public string Difficulty { get; set; }
        Stopwatch Time { get; set; } = new Stopwatch();
        public string UID { get; set; }
        public string FinalTime { get; set; }
        public long FinalTicks { get; set; }

        public PlayerStat()
        {
            UID = generateID();
            Time.Start();
        }

        public PlayerStat(IBoardSize boardSize, IDifficulty difficulty)
        {
            BoardSize = boardSize.Name;
            Difficulty = difficulty.Name;
            UID = generateID();
            Time.Start();
        }

        public void EndGame()
        {
            Time.Stop();

        }

        public int CompareTo(PlayerStat other)
        {
            return FinalTicks.CompareTo(other.FinalTicks);
        }

        public string GetTime()
        {
            FinalTicks = Time.Elapsed.Ticks;
            TimeSpan ts = Time.Elapsed;
            FinalTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            return FinalTime;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
