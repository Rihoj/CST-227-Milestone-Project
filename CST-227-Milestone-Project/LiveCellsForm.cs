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
        public LiveCellsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            gameBoard = new MinesweeperGame(1);
            for (int x = 1; x <= gameBoard.BoardSize; x++)
            {
                for (int y = 1; y <= gameBoard.BoardSize; y++)
                {
                    GameCell currentCell = gameBoard.gameCells.Find(cell => cell.X == x && cell.Y == y);
                    PictureBox pictureBox = new PictureBox
                    {
                        Name = "pictureBox" + x.ToString() + y.ToString(),
                        Size = new Size(currentCell.CellWidth, currentCell.CellHeight),
                        Location = new Point(x * currentCell.CellWidth, y * currentCell.CellHeight),
                        Visible = true
                    };
                    pictureBox.Image = currentCell.Image.Image;
                    pictureBox.MouseClick += new MouseEventHandler((o, a) => pictureBox.Image = gameBoard.ClickCell(currentCell).Image);
                    this.Controls.Add(pictureBox);
                }
            }
            int xSize = (gameBoard.BoardSize * gameBoard.CellSize) + xPadding + margin;
            int ySize = (gameBoard.BoardSize * gameBoard.CellSize) + margin + yPadding;
            this.Size = new Size(xSize, ySize);
        }

        private void revealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(GameCell currentCell in gameBoard.gameCells)
            {
                ((PictureBox) this.Controls.Find("pictureBox"+currentCell.X.ToString()+currentCell.Y.ToString(), true)[0]).Image = gameBoard.ClickCell(currentCell).Image;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (GameCell currentCell in gameBoard.gameCells)
            {
                (this.Controls.Find("pictureBox" + currentCell.X.ToString() + currentCell.Y.ToString(), true)[0]).Dispose();
            }
            StartGame();
        }
    }
}
