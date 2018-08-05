using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CST_227_Milestone_Project.Interfaces;
using CST_227_Milestone_Project.Difficulties;
using CST_227_Milestone_Project.BoardSizes;

namespace CST_227_Milestone_Project
{
    public partial class PreferencesForm : Form
    {
        LiveCellsForm liveCellsForm;
        public IBoardSize BoardSize = new SmallBoard();
        public IDifficulty Difficulty = new NormalDifficulty();

        public PreferencesForm(LiveCellsForm liveCellsForm)
        {
            this.liveCellsForm = liveCellsForm;
            InitializeComponent();
            XsmallRadioButton.Checked = false;
            SmallRadioButton.Checked = true;
            MedRadioButton.Checked = false;
            LargeRadioButton.Checked = false;

            easyRadioButton.Checked = false;
            NormalRadioButton.Checked = true;
            HardRadioButton.Checked = false;
            InsaneRadioButton.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liveCellsForm.NumberOfCells = BoardSize;
            liveCellsForm.Difficulty = Difficulty;
            liveCellsForm.NewGame();
            this.Close();
        }

        private void XsmallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = new XsmallBoard();
        }

        private void SmallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = new SmallBoard();
        }

        private void MedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = new MedBoard();
        }

        private void LargeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = new LargeBoard();
        }

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = new EasyDifficulty();
        }

        private void NormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = new NormalDifficulty();
        }

        private void HardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = new HardDifficulty();
        }

        private void InsaneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = new InsaneDifficulty();
        }
    }
}
