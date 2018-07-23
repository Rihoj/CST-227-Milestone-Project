using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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
        public int NumberOfCells { get; set; } = 10;
        public decimal Difficulty { get; set; } = .15M;
        PreferencesForm sizeForm;
        Stopwatch stopWatch;

        public LiveCellsForm()
        {
            InitializeComponent();
            sizeForm = new PreferencesForm(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
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
            stopWatch.Reset();
            stopWatch.Start();
            gameBoard = new MinesweeperGame(NumberOfCells, Difficulty);
            inProgress = true;
            gameBoard.PlayGame();
            for (int x = 1; x <= gameBoard.BoardSize; x++)
            {
                for (int y = 1; y <= gameBoard.BoardSize; y++)
                {
                    CreateFormCell(x, y);
                }
            }
            SetFormSize();
        }

        private void CreateFormCell(int x, int y)
        {
            GameCell currentCell = gameBoard.GameCells.Find(cell => cell.X == x && cell.Y == y);
            PictureBox pictureBox = new PictureBox
            {
                Name = "pictureBox" + x.ToString() + y.ToString(),
                Size = currentCell.Size,
                Location = new Point(x * currentCell.Size.Width, y * currentCell.Size.Height),
                Visible = true
            };
            pictureBox.Image = currentCell.Image.Image;
            pictureBox.MouseClick += new MouseEventHandler((o, a) =>
            {
                if (a.Button == MouseButtons.Left)
                {
                    gameBoard.ClickCell(currentCell);
                    if (currentCell.Live)
                    {
                        RevealBoard();
                    }
                }
                else if(a.Button == MouseButtons.Right && !currentCell.Visited)
                {
                    gameBoard.RightClickCell(currentCell);
                }
                FrameUpdate();
            }
            );
            this.Controls.Add(pictureBox);
            cells.Add(currentCell, pictureBox);
        }

        private void SetFormSize()
        {
            int xSize = (gameBoard.BoardSize * gameBoard.CellSize.Width) + xPadding + margin;
            int ySize = (gameBoard.BoardSize * gameBoard.CellSize.Height) + margin + yPadding;
            Size size = new Size(xSize, ySize);
            this.MinimumSize = size;
            this.MaximumSize = size;
            this.Size = size;
        }

        private void RevealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevealBoard(true);
        }

        private void UserWins()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            string message = "WOW! You Won in "+elapsedTime+"!";
            if (inProgress)
            {
                gameBoard.RevealBoard(true);
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
            NewGame();
        }

        public void NewGame()
        {
            foreach (GameCell currentCell in gameBoard.GameCells)
            {
                (this.Controls.Find("pictureBox" + currentCell.X.ToString() + currentCell.Y.ToString(), true)[0]).Dispose();
            }
            StartGame();
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeForm.ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeForm.ShowDialog();
        }
    }
}
