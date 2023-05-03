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
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        List<HighScore> highScore = new List<HighScore>();

        public static int score;

       


        public Form1()
        {
            InitializeComponent();
            HighScore high = new HighScore("23", "Logan");
            highScore.Add(high);
            LoganCode();
            
            //LoganSaveHS();
            //LoganLoadHS();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            ChangeScreen(this, new MenuScreen());
        }

        //Added the ChangeScreen Method 
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //LoganSaveHS();
        }

        public void LoganCode()
        {

        }
        //public void LoganSaveHS()
        //{
        //    XmlWriter writer = XmlWriter.Create("Resources/HighScoreXML.xml");
        //    writer.WriteStartElement("HighScore");

        //    foreach (HighScore hs in highScore)
        //    {
        //        writer.WriteStartElement("HighScore");

        //        writer.WriteElementString("score", hs.score);
        //        writer.WriteElementString("playerName", hs.playerName);

        //        writer.WriteEndElement();
        //    }

        //    writer.WriteEndElement();

        //    writer.Close();
        //}

        //public void LoganLoadHS()
        //{

        //    string score, playerName;

        //    XmlReader reader = XmlReader.Create("Resources/HighScoreXML.xml", null);

        //    while (reader.Read())
        //    {
        //        if (reader.NodeType == XmlNodeType.Text)
        //        {
        //            score = reader.ReadString();

        //            reader.ReadToNextSibling("playerName");
        //            playerName = reader.ReadString();

        //            HighScore newHighScore = new HighScore(score, playerName);
        //            highScore.Add(newHighScore);
        //        }
        //    }

        //    reader.Close();
        //}
        /// <summary>
        /// Loading fonts for labels
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="label"></param>
        public static void loadingFonts(string name, int size, params Label[] labels)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();

            fontCollection.AddFontFile(name);

            Font font = new Font(fontCollection.Families[0], size);

            foreach (Label label in labels)
            {
              
               label.Font = font;
                
               
            }
            
        }
        /// <summary>
        /// Loading fonts for buttons
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="buttons"></param>
        public static void loadingFonts(string name, int size, params Button[] buttons)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();


            fontCollection.AddFontFile(name);

            Font font = new Font(fontCollection.Families[0], size);

            foreach (Button button in buttons)
            {
                button.Font = font;
            }
        }
        /// <summary>
        /// Loading fonts for comboboxes
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="combo"></param>
        public static void loadingFonts(string name, int size, ComboBox combo)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();

            fontCollection.AddFontFile(name);

            Font font = new Font(fontCollection.Families[0], size);

            combo.Font = font;
        }

    }
}
