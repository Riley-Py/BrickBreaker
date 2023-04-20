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

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void levelDesignerButton_Click(object sender, EventArgs e)
        {
            LevelDesignerScreen lds = new LevelDesignerScreen();
            Form form = this.FindForm();

            form.Controls.Add(lds);
            form.Controls.Remove(this);

            lds.Location = new Point((form.Width - lds.Width) / 2, (form.Height - lds.Height) / 2);
        }
    }
}
