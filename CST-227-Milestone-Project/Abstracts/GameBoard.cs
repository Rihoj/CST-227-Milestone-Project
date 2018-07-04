using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    abstract class GameBoard : IPlayable
    {
        public List<GameCell> GameCells { get; } = new List<GameCell>();
        public int BoardSize { get; }
        public int CellSize { get; } = 30;

        public GameBoard(int size)
        {
            BoardSize = size * 10;
        }

        protected void CreateCells()
        {
            for (int x = 1; x <= BoardSize; x++)
            {
                for (int y = 1; y <= BoardSize; y++)
                {
                    GameCells.Add(new GameCell(CellSize, CellSize, x, y));
                }
            }
        }

        public void ActivateCells()
        {
            int cellCount = BoardSize * BoardSize;
            int numberOfActiveCells = (int)(cellCount * .15);
            Random rnd = new Random();
            for (int i = 0; i < numberOfActiveCells; i++)
            {
                int x = rnd.Next(1, BoardSize + 1);
                int y = rnd.Next(1, BoardSize + 1);
                GameCell result = GameCells.Find(cell => cell.X == x && cell.Y == y && !cell.Live);
                while (result == null)
                {
                    x = rnd.Next(1, BoardSize + 1);
                    y = rnd.Next(1, BoardSize + 1);
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

        public virtual void RevealBoard()
        {
            foreach(GameCell gameCell in GameCells)
            {
                gameCell.ClickCell();
            }
        }

        public abstract void PlayGame();
    }
}
