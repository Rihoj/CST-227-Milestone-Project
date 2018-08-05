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
using CST_227_Milestone_Project.Interfaces;
using CST_227_Milestone_Project.Difficulties;
using CST_227_Milestone_Project.BoardSizes;
using System.IO;

namespace CST_227_Milestone_Project
{
    public partial class LiveCellsForm : Form
    {
        GameBoard gameBoard;
        public int margin { get; } = 60;
        public new Size Padding { get; } = new Size(16, 49);
        private Dictionary<GameCell, PictureBox> cells = new Dictionary<GameCell, PictureBox>();
        private bool inProgress = false;
        public IBoardSize NumberOfCells { get; set; } = new SmallBoard();
        public IDifficulty Difficulty { get; set; } = new NormalDifficulty();
        PreferencesForm sizeForm;
        PlayerStat player;
        List<PlayerStat> HighScores { get; set; } = new List<PlayerStat>();
        private SaveData saveData = new SaveData();

        public LiveCellsForm()
        {
            InitializeComponent();
            sizeForm = new PreferencesForm(this);
            HighScores = saveData.LoadHighScores();
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
            player = new PlayerStat(NumberOfCells, Difficulty);
            gameBoard = new MinesweeperGame(NumberOfCells, Difficulty);
            inProgress = true;
            gameBoard.PlayGame();
            for (int x = 1; x <= gameBoard.BoardSize.Size; x++)
            {
                for (int y = 1; y <= gameBoard.BoardSize.Size; y++)
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
            int xSize = (gameBoard.BoardSize.Size * gameBoard.CellSize.Width) + Padding.Width + margin;
            int ySize = (gameBoard.BoardSize.Size * gameBoard.CellSize.Height) + margin + Padding.Height;
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
            player.EndGame();
            string message = "WOW! You Won in "+player.GetTime()+"!\n\n Enter your name to save your time!";
            if (inProgress)
            {
                gameBoard.RevealBoard(true);
                UpdatePictures();
                string input = Microsoft.VisualBasic.Interaction.InputBox(message, "Winner!", "", -1, -1);
                if(input.Length > 0)
                {
                    player.PlayerName = input;
                    saveData.SaveGameData(player);
                }
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

        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreBoard scoreBoard = new ScoreBoard(HighScores);
            scoreBoard.Show();
        }
    }
}
