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
using System.IO;
using System.Resources;
using System.Xml.Linq;

namespace BrickBreaker.Screens
{
    public partial class LevelDesignerScreen : UserControl
    {
        #region global variables for game (put them all here)
        PowerupEnum currentPowerup;
        bool[] lastPressedWASD = new bool[4];
        bool[] pressedWASD = new bool[4];
        bool[] lastPressedArrow = new bool[4];
        bool[] pressedArrow = new bool[4];
        bool replace = false;
        bool delete = true;
        int selectedBrickIndex = 0;
        int moveBy = 1;
        int spacing = 1;
        int defWidth = 42;
        int defHeight = 18;
        List<DesignerBrick> bricks = new List<DesignerBrick>();
        int currentHP = 1;
        #endregion

        public LevelDesignerScreen()
        {
            InitializeComponent();
            RileyFunc();
            currentPowerup = PowerupEnum.None;
        }


        /// <summary>
        /// Placing and replacing blocks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelDesignerScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            #region if left mouse button is clicked, add block
            if (e.Button == MouseButtons.Left)
            {
                DesignerBrick brick = new DesignerBrick(x, y, currentHP, defWidth, defHeight, currentPowerup);
                
                bricks.Add(brick);
            }
            #endregion

            #region if right mouse button is clicked, remove the block that is selected
            else if (e.Button == MouseButtons.Right)
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
            #endregion

            #region if middle mouse buttion is clicked, select it
            else if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].containsPoint(x, y))
                    {
                        selectedBrickIndex = i;
                    }
                }
            }
            #endregion

            RileyFunc();

            Refresh();
        }

        private void LevelDesignerScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (DesignerBrick brick in bricks)
            {
               
                if(brick.powerup == PowerupEnum.None)
                {
                    e.Graphics.FillRectangle(brick.solidBrush, brick.x - brick.width / 2, brick.y - brick.height / 2, brick.width, brick.height);

                }
                else
                {
                    e.Graphics.FillRectangle(brick.solidBrush, brick.x - brick.width / 2, brick.y - brick.height / 2, brick.width, brick.height);
                    e.Graphics.DrawImage(brick.powerupImage, brick.x - brick.width / 2, brick.y - brick.height / 2, brick.width, brick.height);
                }             
            }
        }
        /// <summary>
        /// Generates level with name
        /// </summary>
        private void generateLevel()
        {         
            SaveFileDialog dialogue = new SaveFileDialog();
            dialogue.Filter = "XML (*.xml)|*.xml|All files (*.*)|*.*";
            dialogue.Title = "Save as an XML";
            dialogue.FilterIndex = 2;

            #region writes all of the bricks to the specified xml file (put it in levels folder, please!)
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                            
                using (XmlTextWriter writer = new XmlTextWriter(dialogue.FileName, System.Text.Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    
                 
                    writer.WriteStartElement("Level");

                    foreach (DesignerBrick b in bricks)
                    {
                        writer.WriteStartElement("Brick");
                        writer.WriteElementString("x", $"{b.x}");
                        writer.WriteElementString("y", $"{b.y}");
                        writer.WriteElementString("width", $"{b.width}");
                        writer.WriteElementString("height", $"{b.height}");
                        writer.WriteElementString("hp", $"{b.hp}");
                        writer.WriteElementString("color", $"{b.solidBrush.Color.Name}");
                        
                        if (b.powerup != PowerupEnum.None)
                        {
                            writer.WriteElementString("powerup", $"{b.powerup}");

                        }
                        else
                        {
                            writer.WriteElementString("powerup", $"");

                        }
                        writer.WriteEndElement();
                       
                    }

                    
                    writer.Flush();
                    writer.Close();
                    
                    

                }
                

            }
            #endregion

        }
        /// <summary>
        /// Adds/subtracts HP
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private int deltaHP(int by) 
        {
            int maxHP = 5;
            int hp = currentHP += by;
              
            if(hp < 1)
            {
                hp = maxHP;
            }
            if(hp > maxHP)
            {
                hp = 1;
            }
            hpLabel.Text = $"HP is: {hp}";

            
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
                    if (currentPowerup >= PowerupEnum.Default || currentPowerup < 0)
                    {
                        currentPowerup = 0;
                    }
                    powerUpLabel.Text = currentPowerup.ToString();
                    break;
                case Keys.N:
                    currentPowerup -= 1;
                    if(currentPowerup >= PowerupEnum.Default || currentPowerup < 0)
                    {
                        currentPowerup = 0;
                    }
                    powerUpLabel.Text = currentPowerup.ToString();
                    break;
                case Keys.V:
                    RevealInstructions();
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
                    delete = !delete;

                    replaceLabel.Text = $"Replace: {replace}";
                    deleteLabel.Text = $"Delete: {delete}";

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
            Form1.LoadingFonts("burbank.otf", 18, instructionLabel);
            Form1.LoadingFonts("burbank.otf", 15, replaceLabel, deleteLabel, hpLabel, powerUpLabel);

            deleteLabel.Text = $"Delete: {delete}";         


        }
        /// <summary>
        /// Reveals the instructions with using a key
        /// </summary>
        private void RevealInstructions()
        {
            instructionLabel.Text = "Instructions:" +
                "\n Left mouse click: place first block " +
                "\n WASD: move position of block position to place " +
                "\n r: rotate " +
                "\n p: increase health " +
                "\n L: decrease health " +
                "\n m/n: change the powerups " +
                "\n Enter: save the file " +
                "\n v: make this label visible/invisible" +
                "\n Arrow keys: move selected block" +
                "\n Middle Click: select a block" +
                "\n 1: Increases speed to move blocks with arrow keys" +
                "\n 2: Decreases speed to move blocks with arrow keys" +
                "\n Space: Changes on whether using right click adds/removes a block";

            instructionLabel.Visible = !instructionLabel.Visible;
            

        }
     
       
    }

    
  
}
