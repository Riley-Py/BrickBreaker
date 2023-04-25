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

        public static int score;

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

        }
        public void LoganSaveHS()
        {
            XmlWriter writer = XmlWriter.Create("Resources/HighScoreXML.xml");
            writer.WriteStartElement("HighScore");

            foreach (HighScore hs in highScore)
            {
                writer.WriteStartElement("HighScore");

                writer.WriteElementString("score", hs.score);
                writer.WriteElementString("playerName", hs.playerName);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
        }

        public void LoganLoadHS()
        {

            string score, playerName;

            XmlReader reader = XmlReader.Create("Resources/HighScoreXML.xml", null);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    score = reader.ReadString();

                    reader.ReadToNextSibling("playerName");
                    playerName = reader.ReadString();

                    HighScore newHighScore = new HighScore(score, playerName);
                    highScore.Add(newHighScore);
                }
            }

            reader.Close();
        }

    }
}
