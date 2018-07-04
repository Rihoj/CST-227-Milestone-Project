using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_227_Milestone_Project
{
    class Neighbors
    {
        public Dictionary<string, GameCell> neighbors { get; set;  } = new Dictionary<string, GameCell>();
        public int LiveNeighbors { get; private set; } = 0;

        public Neighbors()
        {
        }

        public Neighbors(GameCell North, GameCell East, GameCell South, GameCell West)
        {
            SetNorth(North);
            SetEast(East);
            SetSouth(South);
            SetWest(West);
        }

        public void SetNorth(GameCell North)
        {
            neighbors.Add("North", North);
            UpdateLiveNeighbors();
        }

        public void SetEast(GameCell East)
        {
            neighbors.Add("East", East);
            UpdateLiveNeighbors();
        }

        public void SetSouth(GameCell South)
        {
            neighbors.Add("South", South);
            UpdateLiveNeighbors();
        }

        public void SetWest(GameCell West)
        {
            neighbors.Add("West", West);
            UpdateLiveNeighbors();
        }

        public GameCell GetNorth()
        {
            return neighbors["North"];
        }

        public GameCell GetEast()
        {
            return neighbors["East"];
        }

        public GameCell GetSouth()
        {
            return neighbors["South"];
        }

        public GameCell GetWest()
        {
            return neighbors["West"];
        }

        private void UpdateLiveNeighbors()
        {
            LiveNeighbors = 0;
            if (neighbors.Count > 0)
            {
                foreach (KeyValuePair<string, GameCell> neighbor in neighbors)
                {
                    if (neighbor.Value != null)
                    {
                        int neighborStatus = CheckStatus(neighbor.Value);
                        if (neighborStatus == 1)
                        {
                            LiveNeighbors++;
                        }
                    }
                }
            }
        }

        public void CheckNeighbors()
        {
            if (LiveNeighbors == 0)
            {
                foreach (KeyValuePair<string, GameCell> neighbor in neighbors)
                {
                    if (neighbor.Value != null && !neighbor.Value.Visited)
                    {
                        int neighborStatus = CheckStatus(neighbor.Value);
                        if (neighborStatus != 1)
                        {
                            neighbor.Value.ClickCell();
                        }
                    }
                }
            }
        }

        // returns 1 for live, 0 for has live neighbor, -1 for no live neighbor
        private int CheckStatus(GameCell neighbor)
        {
            if (neighbor.Live)
            {
                return 1;
            } else if (neighbor.Neighbors.LiveNeighbors == 0)
            {
                return -1;
            }else
            {
                return 0;
            }
        }
    }
}
