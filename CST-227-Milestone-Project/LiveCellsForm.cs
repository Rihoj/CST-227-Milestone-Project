using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_227_Milestone_Project
{
    public partial class LiveCellsForm : Form
    {
        GameBoard gameBoard;
        public int margin { get; } = 60;
        public int xPadding { get; } = 16;
        public int yPadding { get; } = 49;
        private Dictionary<GameCell, PictureBox> cells = new Dictionary<GameCell, PictureBox>();
        private bool inProgress = false;

        public LiveCellsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void FrameUpdate()
        {
            UpdatePictures();
            List<GameCell> gameCells = gameBoard.GameCells.FindAll(cell => cell.Live == false && cell.Visited == false);
            if (gameCells.Count == 0)
            {
                UserWins();
            }
        }

        private void UpdatePictures()
        {
            foreach (KeyValuePair<GameCell, PictureBox> cell in cells)
            {
                cell.Value.Image = cell.Key.Image.Image;
            }
        }
        private void StartGame()
        {
            gameBoard = new MinesweeperGame(1);
            inProgress = true;
            gameBoard.PlayGame();
            for (int x = 1; x <= gameBoard.BoardSize; x++)
            {
                for (int y = 1; y <= gameBoard.BoardSize; y++)
                {
                    GameCell currentCell = gameBoard.GameCells.Find(cell => cell.X == x && cell.Y == y);
                    PictureBox pictureBox = new PictureBox
                    {
                        Name = "pictureBox" + x.ToString() + y.ToString(),
                        Size = new Size(currentCell.CellWidth, currentCell.CellHeight),
                        Location = new Point(x * currentCell.CellWidth, y * currentCell.CellHeight),
                        Visible = true
                    };
                    pictureBox.Image = currentCell.Image.Image;
                    pictureBox.MouseClick += new MouseEventHandler((o, a) => 
                        {
                            gameBoard.ClickCell(currentCell);
                            if (currentCell.Live)
                            {
                                RevealBoard();
                            }
                            FrameUpdate();
                        }
                    );
                    this.Controls.Add(pictureBox);
                    cells.Add(currentCell, pictureBox);
                }
            }
            int xSize = (gameBoard.BoardSize * gameBoard.CellSize) + xPadding + margin;
            int ySize = (gameBoard.BoardSize * gameBoard.CellSize) + margin + yPadding;
            this.Size = new Size(xSize, ySize);
        }

        private void RevealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevealBoard(true);
        }

        private void UserWins()
        {
            string message = "WOW! You Won!";
            if (inProgress)
            {
                //gameBoard.RevealBoard();
                UpdatePictures();
                MessageBox.Show(message, "WINNER!");
            }
            inProgress = false;
        }
        
        private void RevealBoard(bool userInitiated = false)
        {
            string message = "Oh man you lost!";
            if (inProgress)
            {
                gameBoard.RevealBoard();
                UpdatePictures();
                if (userInitiated)
                {
                    message = "You revealed the board.";
                }
                MessageBox.Show(message, "Game Over");
            }
            inProgress = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GameCell currentCell in gameBoard.GameCells)
            {
                (this.Controls.Find("pictureBox" + currentCell.X.ToString() + currentCell.Y.ToString(), true)[0]).Dispose();
            }
            StartGame();
        }
    }
}
