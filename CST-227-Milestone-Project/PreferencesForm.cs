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
    public partial class PreferencesForm : Form
    {
        LiveCellsForm liveCellsForm;
        int BoardSize = 10;
        decimal Difficulty = .15M;

        public PreferencesForm(LiveCellsForm liveCellsForm)
        {
            this.liveCellsForm = liveCellsForm;
            InitializeComponent();
            XsmallRadioButton.Checked = true;
            SmallRadioButton.Checked = false;
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
            BoardSize = 10;
        }

        private void SmallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = 15;
        }

        private void MedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = 20;
        }

        private void LargeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoardSize = 25;
        }

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = .1M;
        }

        private void NormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = .15M;
        }

        private void HardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = .20M;
        }

        private void InsaneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = .3M;
        }
    }
}
