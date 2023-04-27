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
        Powerup currentPowerup;
        bool[] lastPressedWASD = new bool[4];
        bool[] pressedWASD = new bool[4];
        bool[] lastPressedArrow = new bool[4];
        bool[] pressedArrow = new bool[4];
        bool replace = false;
        int selectedBrickIndex = 0;
        int moveBy = 1;
        int spacing = 1;
        int defWidth = 42;
        int defHeight = 18;
        List<DesignerBrick> bricks = new List<DesignerBrick>();
        int currentHP = 1;
        public LevelDesignerScreen()
        {
            InitializeComponent();
            RileyFunc();
            currentPowerup = Powerup.None;
        }



        private void LevelDesignerScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if(e.Button == MouseButtons.Left)
            {
                DesignerBrick brick = new DesignerBrick(x, y, currentHP, defWidth, defHeight, currentPowerup);
                
                bricks.Add(brick);
            }
            else if(e.Button == MouseButtons.Right)
            {
                for(int i = bricks.Count - 1; i >= 0; i--)
                {
                    if (bricks[i].containsPoint(x, y))
                    {
                        if (replace)
                        {
                            DesignerBrick b = new DesignerBrick(bricks[i].x, bricks[i].y, currentHP, bricks[i].width, bricks[i].height, currentPowerup);
                            bricks.Add(b);
                        }
                        bricks.RemoveAt(i);
                        selectedBrickIndex = bricks.Count-1;

                    }
                }
            }
            else if(e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].containsPoint(x, y))
                    {
                        selectedBrickIndex = i;
                    }
                }
            }
            
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
            
            
        }

        private void generateLevel()
        {
            XmlWriter writer = XmlWriter.Create("Resources/LevelXML.xml");

            writer.WriteStartElement("Level");
            foreach (DesignerBrick b in bricks)
            {
                writer.WriteStartElement("Brick");
                writer.WriteElementString("x",$"{b.x}");
                writer.WriteElementString("y", $"{b.y}");
                writer.WriteElementString("width", $"{b.width}");
                writer.WriteElementString("height", $"{b.height}");
                writer.WriteElementString("color", $"{b.solidBrush.Color.Name}");
                if(b.powerup != Powerup.None)
                {
                    writer.WriteElementString("powerup", $"{b.powerup}");

                }
                else
                {
                    writer.WriteElementString("powerup", $"");

                }
                writer.WriteEndElement();
            }

            writer.Close();
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
                    DesignerBrick lastBrick = bricks[selectedBrickIndex];
                    int dX = (i == 3 ? lastBrick.width/2 + defWidth/2 + spacing : 0)-(i == 2 ? lastBrick.width / 2 + defWidth / 2 + spacing : 0);
                    int dY = (i == 1 ? lastBrick.height/2 + defHeight/2 + spacing : 0) - (i == 0 ? lastBrick.height / 2 + defHeight / 2 + spacing : 0);

                    DesignerBrick brick = new DesignerBrick(lastBrick.x + dX, lastBrick.y + dY, currentHP, defWidth, defHeight, currentPowerup);
                    for (int j = 0; j < bricks.Count; j++)
                    {
                        if (brick.containsBrick(bricks[j]))
                        {
                            return;
                        }
                    }
                    bricks.Add(brick);
                    selectedBrickIndex = bricks.Count - 1;
                    Refresh();
                }
                if (pressedArrow[i] != lastPressedArrow[i] && bricks.Count > 0)
                {
                    int dX = (i == 3 ? moveBy : 0) - (i == 2 ? moveBy : 0);
                    int dY = (i == 1 ? moveBy : 0) - (i == 0 ? moveBy : 0);


                    bricks[selectedBrickIndex].x += dX;
                    bricks[selectedBrickIndex].y += dY;

                    Refresh();
                }
            }
        }
        private void LevelDesignerScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            pressedWASD.CopyTo(lastPressedWASD,0);
            pressedArrow.CopyTo(lastPressedArrow,0);
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
                case Keys.Up:
                    pressedArrow[0] = true;
                    break;
                case Keys.Down:
                    pressedArrow[1] = true;
                    break;
                case Keys.Left:
                    pressedArrow[2] = true;
                    break;
                case Keys.Right:
                    pressedArrow[3] = true;
                    break;
                case Keys.P:
                    currentHP = deltaHP(1);
                    break;
                case Keys.L:
                    currentHP = deltaHP(-1);
                    break;
                case Keys.Enter:
                    generateLevel();
                    break;
                case Keys.M:
                    currentPowerup += 1;
                    if (currentPowerup >= Powerup.Default || currentPowerup < 0)
                    {
                        currentPowerup = 0;
                    }
                    powerUpLabel.Text = currentPowerup.ToString();
                    break;
                case Keys.N:
                    currentPowerup -= 1;
                    if(currentPowerup >= Powerup.Default || currentPowerup < 0)
                    {
                        currentPowerup = 0;
                    }
                    powerUpLabel.Text = currentPowerup.ToString();
                    break;
                case Keys.V:
                    RileyFunc();
                    break;


                case Keys.D1:
                    moveBy++;
                    break;
                case Keys.D2:
                    moveBy--;
                    if(moveBy < 0)
                        moveBy = 0;
                    break;
                case Keys.Space:
                    replace = !replace;
                    replaceLabel.Text = $"replace:{replace}";
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
                case Keys.Up:
                    pressedArrow[0] = false;
                    break;
                case Keys.Down:
                    pressedArrow[1] = false;
                    break;
                case Keys.Left:
                    pressedArrow[2] = false;
                    break;
                case Keys.Right:
                    pressedArrow[3] = false;
                    break;
                case Keys.R:
                    int temp = defHeight;
                    defHeight = defWidth;
                    defWidth = temp;
                    break;
                case Keys.Escape:
                    Form1.ChangeScreen(this, new MenuScreen());
                    break; 
            }
            pressedWASD.CopyTo(lastPressedWASD, 0);
        }
        private void RileyFunc()
        {
            instructionLabel.Text = "Instructions:\n Left mouse click: place first block \n WASD: move position of block position to place \n r: rotate \n p: increase health \n l: decrease health \n m/n: change the powerups \n Enter: save the file \n v: make this label visible/invisible";   
            
            instructionLabel.Visible = !instructionLabel.Visible;
        }

       
    }

    enum Powerup
    {
        None = 0,

        Ammo = 1,
        ChugJug = 2,
        Scar = 3,
        Shotgun = 4,
        RocketLauncher = 5,
        InfinityGauntlet = 6,
        
        Default = 7
    }
  
}
