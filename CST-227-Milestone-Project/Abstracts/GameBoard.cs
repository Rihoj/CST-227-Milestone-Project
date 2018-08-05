using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CST_227_Milestone_Project.Interfaces;
using CST_227_Milestone_Project.Difficulties;

namespace CST_227_Milestone_Project
{
    abstract class GameBoard : IPlayable
    {
        public List<GameCell> GameCells { get; } = new List<GameCell>();
        public IBoardSize BoardSize { get; }
        public Size CellSize { get; } = new Size(30, 30);
        public IDifficulty Difficulty = new NormalDifficulty();

        public GameBoard(IBoardSize size, IDifficulty difficulty)
        {
            BoardSize = size;
            Difficulty = difficulty;
        }

        protected void CreateCells()
        {
            for (int x = 1; x <= BoardSize.Size; x++)
            {
                for (int y = 1; y <= BoardSize.Size; y++)
                {
                    GameCells.Add(new GameCell(CellSize, x, y));
                }
            }
        }

        public void ActivateCells()
        {
            int cellCount = BoardSize.Size * BoardSize.Size;
            int numberOfActiveCells = (int)(cellCount * Difficulty.Difficulty);
            Random rnd = new Random();
            for (int i = 0; i < numberOfActiveCells; i++)
            {
                int x = rnd.Next(1, BoardSize.Size + 1);
                int y = rnd.Next(1, BoardSize.Size + 1);
                GameCell result = GameCells.Find(cell => cell.X == x && cell.Y == y && !cell.Live);
                while (result == null)
                {
                    x = rnd.Next(1, BoardSize.Size + 1);
                    y = rnd.Next(1, BoardSize.Size + 1);
                    result = GameCells.Find(cell => cell.X == x && cell.Y == y && !cell.Live);
                }
                result.Live = true;
            }
        }

        public void SetNeighbors()
        {
            foreach (GameCell currentCell in GameCells)
            {
                GameCell northNeighbor = GameCells.Find(cell => cell.X == currentCell.X - 1 && cell.Y == currentCell.Y);
                GameCell eastNeighbor = GameCells.Find(cell => cell.X == currentCell.X && cell.Y == currentCell.Y - 1);
                GameCell southNeighbor = GameCells.Find(cell => cell.X == currentCell.X + 1 && cell.Y == currentCell.Y);
                GameCell westNeighbor = GameCells.Find(cell => cell.X == currentCell.X && cell.Y == currentCell.Y + 1);
                currentCell.Neighbors = new Neighbors(northNeighbor, eastNeighbor, southNeighbor, westNeighbor);
            }
        }

        public GameCell ClickCell(GameCell gc)
        {
            GameCell gameCell = GameCells.Find(cell => cell.X == gc.X && cell.Y == gc.Y);
            gameCell.ClickCell();
            return gameCell;
        }

        public GameCell RightClickCell(GameCell gc)
        {
            GameCell gameCell = GameCells.Find(cell => cell.X == gc.X && cell.Y == gc.Y);
            gameCell.FlagCell();
            return gameCell;
        }

        public virtual void RevealBoard(bool markFlags = false)
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

        public abstract void PlayGame();
    }
}
