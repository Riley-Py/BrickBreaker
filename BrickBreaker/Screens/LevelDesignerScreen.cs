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
        public LevelDesignerScreen()
        {
            InitializeComponent();
        }



        private void LevelDesignerScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            DesignerBrick brick = new DesignerBrick(x, y, Color.Red);
            bricks.Add(brick);
            Refresh();
        }

        private void LevelDesignerScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (DesignerBrick brick in bricks)
            {
                e.Graphics.FillRectangle(brick.solidBrush, brick.x, brick.y, brick.width, brick.height);
            }
        }

        private void generateLevelButton_Click(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("Resources/LevelXML.xml");

            writer.WriteStartElement("Level");


        }
    }
}
