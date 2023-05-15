using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker.Screens;
using System.Windows.Media;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {

        MediaPlayer menuMusic = new MediaPlayer();
        public MenuScreen()
        {
            string loc = Application.StartupPath + "/Resources/menumusic.wav";
           menuMusic.Open(new Uri(loc));
            menuMusic.Play();
            InitializeComponent();
            RileyFunc();
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            menuMusic.Stop();
            //Reads the selected mode and see if it's a certain selection.  Otherwise, nothing happens
            if (modeSelector.SelectedItem == "Level Editor")
            {
                Form1.ChangeScreen(this, new LevelDesignerScreen());
            }
            else if (modeSelector.SelectedItem == "Single Player")
            {
                Form1.ChangeScreen(this, new UserInfo());
            }


        }

        
        //Comment out for color testing
        private void RileyFunc()
        {
            playButton.BackColor = System.Drawing.Color.FromArgb(255, 247, 255, 25);
            modeSelector.BackColor = System.Drawing.Color.FromArgb(255, 0, 86, 255);
            exitButton.BackColor = System.Drawing.Color.FromArgb(255, 247, 255, 25);

            Form1.LoadingFonts("burbank.otf", 36, titleLabel);
            Form1.LoadingFonts("burbank.otf", 27, playButton, exitButton);
            Form1.LoadingFonts("burbank.otf", 20, modeSelector);
            

            modeSelector.Items.Add("Level Editor");
            modeSelector.Items.Add("Single Player");

            
        }
        //NOTE: if you want to remove these next lines, go to designer and remove the reference.  DO NOT delete these lines in code or the program breaks!!
        private void playButton_MouseHover(object sender, EventArgs e)
        {
            playButton.BackColor = System.Drawing.Color.FromArgb(150, 247, 255, 25);
        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            playButton.BackColor = System.Drawing.Color.FromArgb(255, 247, 255, 25);
        }

        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            exitButton.BackColor = System.Drawing.Color.FromArgb(150, 247, 255, 25);
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackColor = System.Drawing.Color.FromArgb(255, 247, 255, 25);
        }
        //private void levelDesignerButton_Click(object sender, EventArgs e)
        //{
        //    LevelDesignerScreen lds = new LevelDesignerScreen();
        //    Form form = this.FindForm();

        //    form.Controls.Add(lds);
        //    form.Controls.Remove(this);

        //    lds.Location = new Point((form.Width - lds.Width) / 2, (form.Height - lds.Height) / 2);
        //}
    }
}
