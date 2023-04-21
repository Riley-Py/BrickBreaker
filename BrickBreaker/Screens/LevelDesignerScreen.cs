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

            DesignerBrick brick = new DesignerBrick(x, y, 2);
            DesignerBrick.lastX = x; DesignerBrick.lastY = y;
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
        private void LevelDesignerScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {

            }
        }
    }
}
