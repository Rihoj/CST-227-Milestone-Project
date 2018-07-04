using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    class MinesweeperGame : GameBoard, IPlayable
    {
        public MinesweeperGame(int size, decimal difficulty) : base(size, difficulty)
        {
        }

        public override void PlayGame()
        {
            base.CreateCells();
            base.ActivateCells();
            base.SetNeighbors();
        }

        public override void RevealBoard()
        {
            foreach(GameCell gameCell in GameCells)
            {
                ClickCell(gameCell);
            }
        }
    }
}
