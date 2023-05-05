using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
            Loading();
        }
        private void Loading()
        {
            backButton.BackColor = Color.FromArgb(255, 247, 255, 25);
            playButton.BackColor = Color.FromArgb(255, 247, 255, 25);

            Form1.LoadingFonts("burbank.otf", 27, playButton, backButton);
            Form1.LoadingFonts("burbank.otf", 20, entryLabel);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            Form1.LoadingFonts("burbank.otf", 27, playButton, backButton);
        }
    }
}
