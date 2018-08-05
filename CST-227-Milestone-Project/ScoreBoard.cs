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
    public partial class ScoreBoard : Form
    {
        public ScoreBoard(List<PlayerStat> HighScores)
        {
            InitializeComponent();

            labelName1.Text = "";
            labelName2.Text = "";
            labelName3.Text = "";
            labelName4.Text = "";
            labelName5.Text = "";
            labelTime1.Text = "";
            labelTime2.Text = "";
            labelTime3.Text = "";
            labelTime4.Text = "";
            labelTime5.Text = "";
            if (HighScores.ElementAtOrDefault(0) != null)
            {
                labelName1.Text = HighScores[0].PlayerName;
                labelTime1.Text = HighScores[0].FinalTime;
            }
            if (HighScores.ElementAtOrDefault(1) != null)
            {
                labelName2.Text = HighScores[1].PlayerName;
                labelTime2.Text = HighScores[1].FinalTime;
            }
            if (HighScores.ElementAtOrDefault(2) != null)
            {
                labelName3.Text = HighScores[2].PlayerName;
                labelTime3.Text = HighScores[2].FinalTime;
            }
            if (HighScores.ElementAtOrDefault(3) != null)
            {
                labelName4.Text = HighScores[3].PlayerName;
                labelTime4.Text = HighScores[3].FinalTime;
            }
            if (HighScores.ElementAtOrDefault(4) != null)
            {
                labelName5.Text = HighScores[4].PlayerName;
                labelTime5.Text = HighScores[4].FinalTime;
            }
        }
    }
}
