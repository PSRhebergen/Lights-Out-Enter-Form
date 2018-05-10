using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lights_Out_Enter_Form
{
    class Level
    {
        private Color green = Color.FromArgb(29, 185, 84);
        private Color red = Color.FromArgb(224, 56, 56);
        private Color black = Color.FromArgb(32, 32, 32);

        public Bitmap Bitmap { get; set; }

        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string colors;
        public string Colors { get { return colors; } set { colors = value; } }

        public Level()
        {
            Reset();
        }

        public Level(int id, string colors)
        {
            this.Id = id;
            this.Colors = colors;
            MakeBitmap();
        }

        public void Reset()
        {
            Id = 0;
            Colors = "bbbbbbbbbbbbbbbbbbbbbbbbb";
            MakeBitmap();
        }

        public int Get_world()
        {
            return Id / 25;
        }

        public int Get_level()
        {
            return Id % 25;
        }

        public string toString()
        {
            return Id.ToString() + " " + Colors;
        }

        private void MakeBitmap()
        {
            {
                Bitmap = new Bitmap(100, 100);
                Graphics graphics = Graphics.FromImage(Bitmap);

                int boxSize = 20;
                int x = 0;
                int y = 0;

                SolidBrush brush;
                foreach (char c in Colors)
                {
                    if (c == 'b')
                        brush = new SolidBrush(black);
                    else if (c == 'r')
                        brush = new SolidBrush(red);
                    else if (c == 'g')
                        brush = new SolidBrush(green);
                    else
                        brush = new SolidBrush(Color.White);

                    graphics.FillRectangle(brush, x * boxSize, y * boxSize, boxSize, boxSize);

                    x++;

                    if (x == 5)
                    {
                        y++;
                        x = 0;
                    }
                }
            }
        }
    }
}

