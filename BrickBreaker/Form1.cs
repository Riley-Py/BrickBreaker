using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        List<HighScore> highScore = new List<HighScore>();

        public static int score, highScoreD;

        public Form1()
        {
            InitializeComponent();
            LoganCode();
            LoganLoadHS();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoganSaveHS();
        }

        public void LoganCode()
        {
            if (highScoreD < score)
            {
                highScoreD = score;
                //highScoreLabel.Text = "NEW HIGH SCORE";
                //highScoreLabel.Text = "";
                //highScoreLabel.Text = "NEW HIGH SCORE";
                //highScoreLabel.Text = "";
                //highScoreLabel.Text = "NEW HIGH SCORE";
                //highScoreLabel.Text = "";
                //highScoreLabel.Text = "NEW HIGH SCORE";
                //highScoreLabel.Text = $"High Score: {highScore}";
            }
        }
        public void LoganSaveHS()
        {
            XmlWriter writer = XmlWriter.Create("Resources/HighScoreXML.xml", null);
        }

        public void LoganLoadHS()
        {
            //highScoreLabel.Text = $"High Score: {highScore}";
        }

    }
}
