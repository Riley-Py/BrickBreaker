using BrickBreaker.Screens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BrickBreaker
{
    internal class TempLoader
    {
        string fileName;
        private int level = 0;

        public TempLoader(string fN)
        {
            fileName = fN;
        }

        public List<Block> Load() 
        {
            string path = Assembly.GetEntryAssembly().Location;
            path = path.Substring(0, path.Length - 16);
            path += $"Levels\\{fileName}";
            XmlReader reader = XmlReader.Create(path);
            reader.ReadToFollowing("Level");
            List<Block> blocks = new List<Block>();
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Text)

                {

                    reader.ReadToFollowing("x");
                    string x = reader.ReadString();
                    reader.ReadToFollowing("y");
                    string y = reader.ReadString();
                    reader.ReadToFollowing("width");
                    string w = reader.ReadString();
                    reader.ReadToFollowing("height");
                    string h = reader.ReadString();
                    reader.ReadToFollowing("hp");
                    string hp = reader.ReadString();
                    reader.ReadToFollowing("color");
                    string c = reader.ReadString();
                    reader.ReadToFollowing("powerup");
                    string pu = reader.ReadString();

                    if(x.Length > 0)
                    {
                        Block b = new Block(Convert.ToInt32(x),
                        Convert.ToInt32(y),
                        Convert.ToInt32(w), Convert.ToInt32(h),
                        Convert.ToInt32(hp),
                        Color.FromName(c));
                        blocks.Add(b);
                    }
                    
                    reader.ReadToFollowing("Brick");

                }

            }
            return blocks;
        }

        //private DesignerBrick.
        public List<DesignerBrick> LoadDesigner()
        {
            string path = Assembly.GetEntryAssembly().Location;
            path = path.Substring(0, path.Length - 16);
            path += $"Levels\\{fileName}";
            XmlReader reader = XmlReader.Create(path);
            reader.ReadToFollowing("Level");
            List<DesignerBrick> blocks = new List<DesignerBrick>();
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Text)

                {

                    reader.ReadToFollowing("x");
                    string x = reader.ReadString();
                    reader.ReadToFollowing("y");
                    string y = reader.ReadString();
                    reader.ReadToFollowing("width");
                    string w = reader.ReadString();
                    reader.ReadToFollowing("height");
                    string h = reader.ReadString();
                    reader.ReadToFollowing("hp");
                    string hp = reader.ReadString();
                    reader.ReadToFollowing("color");
                    string c = reader.ReadString();
                    reader.ReadToFollowing("powerup");
                    string pu = reader.ReadString();

                    if (x.Length > 0)
                    {
                        DesignerBrick b = new DesignerBrick(Convert.ToInt32(x),
                        Convert.ToInt32(y), Convert.ToInt32(hp),
                        Convert.ToInt32(w), Convert.ToInt32(h), PowerupEnum.None);
                        blocks.Add(b);
                    }

                    reader.ReadToFollowing("Brick");

                }

            }
            return blocks;
        }
        public bool ChangeLevel()
        {
            level++;
            fileName = level.ToString();
            return true;
        }
    }
}
