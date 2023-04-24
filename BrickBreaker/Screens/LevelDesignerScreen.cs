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

namespace BrickBreaker.Screens
{
    public partial class LevelDesignerScreen : UserControl
    {
        bool[] lastPressedWASD = new bool[4];
        bool[] pressedWASD = new bool[4];
        int spacing = 1;
        List<DesignerBrick> bricks = new List<DesignerBrick>();
        int currentHP = 1;
        public LevelDesignerScreen()
        {
            InitializeComponent();
        }



        private void LevelDesignerScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            DesignerBrick brick = new DesignerBrick(x, y, currentHP);
           //w DesignerBrick.lastX = x; DesignerBrick.lastY = y;
            bricks.Add(brick);
            Refresh();
        }

        private void LevelDesignerScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (DesignerBrick brick in bricks)
            {
                e.Graphics.FillRectangle(brick.solidBrush, brick.x - brick.width/2, brick.y - brick.height/2, brick.width, brick.height);
            }
        }

        private void generateLevelButton_Click(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("Resources/LevelXML.xml");

            writer.WriteStartElement("Level");


        }

        private int deltaHP(int by) 
        {
            int hp = currentHP += by;
            int maxHP = 5;
            if(hp < 1)
            {
                hp = maxHP;
            }
            if(hp > maxHP)
            {
                hp = 1;
            }
            return hp;
        }

        private void compareKeys()
        {
            for(int i = 0; i < 4; i++)
            {
                if (pressedWASD[i] != lastPressedWASD[i] && bricks.Count > 0) 
                {
                    DesignerBrick lastBrick = bricks.Last();
                    int dX = (i == 3 ? lastBrick.width + spacing : 0)-(i == 2 ? lastBrick.width + spacing : 0);
                    int dY = (i == 1 ? lastBrick.height + spacing : 0) - (i == 0 ? lastBrick.height + spacing : 0);

                    DesignerBrick b = new DesignerBrick(lastBrick.x + dX, lastBrick.y + dY, currentHP);
                    bricks.Add(b);
                    Refresh();
                }
            }
        }
        private void LevelDesignerScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            pressedWASD.CopyTo(lastPressedWASD,0);
            switch (e.KeyCode)
            {
                case Keys.W:
                    pressedWASD[0] = true;
                    break;
                case Keys.S:
                    pressedWASD[1] = true;
                    break;
                case Keys.A:
                    pressedWASD[2] = true;
                    break;
                case Keys.D:
                    pressedWASD[3] = true;
                    break;
                case Keys.P:
                    currentHP = deltaHP(1);
                    break;
                case Keys.L:
                    currentHP = deltaHP(-1);
                    break;
            }
            compareKeys();
        }

        private void LevelDesignerScreen_KeyUp(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.W:
                    pressedWASD[0] = false;
                    break;
                case Keys.S:
                    pressedWASD[1] = false;
                    break;
                case Keys.A:
                    pressedWASD[2] = false;
                    break;
                case Keys.D:
                    pressedWASD[3] = false;
                    break;

            }
            pressedWASD.CopyTo(lastPressedWASD, 0);
        }
    }
}
