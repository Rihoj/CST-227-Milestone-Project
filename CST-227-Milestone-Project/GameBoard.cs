using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    class GameBoard
    {
        public List<GameCell> gameCells { get; } = new List<GameCell>();
        public int BoardSize { get; }
        public int CellSize { get; } = 30;

        public GameBoard(int size)
        {
            BoardSize = size * 10;
            CreateCells();
            ActivateCells();
            SetNeighbors();
        }

        private void CreateCells()
        {
            for (int x = 1; x <= BoardSize; x++)
            {
                for (int y = 1; y <= BoardSize; y++)
                {
                    gameCells.Add(new GameCell(CellSize, CellSize, x, y));
                }
            }
        }

        private void ActivateCells()
        {
            int cellCount = BoardSize * BoardSize;
            int numberOfActiveCells = (int)(cellCount * .15);
            Random rnd = new Random();
            for (int i = 0; i < numberOfActiveCells; i++)
            {
                int x = rnd.Next(1, BoardSize + 1);
                int y = rnd.Next(1, BoardSize + 1);
                GameCell result = gameCells.Find(cell => cell.X == x && cell.Y == y && !cell.Live);
                while (result == null)
                {
                    x = rnd.Next(1, BoardSize + 1);
                    y = rnd.Next(1, BoardSize + 1);
                    result = gameCells.Find(cell => cell.X == x && cell.Y == y && !cell.Live);
                }
                result.Live = true;
            }
        }

        private void SetNeighbors()
        {
            foreach (GameCell currentCell in gameCells)
            {
                if (currentCell.Live)
                {
                    currentCell.LiveNeighbors = 9;
                    continue;
                }
                CheckNorthNeighbor(currentCell);
                CheckSouthNeighbor(currentCell);
                CheckEastNeighbor(currentCell);
                CheckWestNeighbor(currentCell);
            }
        }

        private void CheckNorthNeighbor(GameCell currentCell)
        {
            GameCell northNeighbor = gameCells.Find(cell => cell.X == currentCell.X - 1 && cell.Y == currentCell.Y);
            if (northNeighbor != null && northNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }

        private void CheckSouthNeighbor(GameCell currentCell)
        {
            GameCell southNeighbor = gameCells.Find(cell => cell.X == currentCell.X + 1 && cell.Y == currentCell.Y);
            if (southNeighbor != null && southNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }
        private void CheckEastNeighbor(GameCell currentCell)
        {
            GameCell eastNeighbor = gameCells.Find(cell => cell.X == currentCell.X && cell.Y == currentCell.Y - 1);
            if (eastNeighbor != null && eastNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }
        private void CheckWestNeighbor(GameCell currentCell)
        {
            GameCell westNeighbor = gameCells.Find(cell => cell.X == currentCell.X && cell.Y == currentCell.Y + 1);
            if (westNeighbor != null && westNeighbor.Live)
            {
                currentCell.LiveNeighbors++;
            }
        }

        public ICellImage ClickCell(GameCell gc)
        {
            GameCell gameCell = gameCells.Find(cell => cell.X == gc.X && cell.Y == gc.Y);
            if (gameCell.Live)
            {
                gameCell.Image = new CellHitImage(gameCell);
            }
            else
            {
                gameCell.Image = new CellSafeImage(gameCell);
            }
            return gameCell.Image;
        }
    }
}
