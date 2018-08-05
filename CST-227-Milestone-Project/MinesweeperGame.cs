using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CST_227_Milestone_Project.Interfaces;

namespace CST_227_Milestone_Project
{
    class MinesweeperGame : GameBoard, IPlayable
    {
        public MinesweeperGame(IBoardSize size, IDifficulty difficulty) : base(size, difficulty)
        {
        }

        public override void PlayGame()
        {
            base.CreateCells();
            base.ActivateCells();
            base.SetNeighbors();
        }

        public override void RevealBoard(bool markFlags = false)
        {
            foreach(GameCell gameCell in GameCells)
            {
                if (markFlags && gameCell.Live)
                {
                    gameCell.FlagCell(true);
                }
                else
                {
                    gameCell.ClickCell();
                }
            }
        }
    }
}
