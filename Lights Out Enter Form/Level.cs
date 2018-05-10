using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lights_Out_Enter_Form
{
    public class Level
    {
        private Color green = Color.FromArgb(29, 185, 84);
        private Color red = Color.FromArgb(224, 56, 56);
        private Color black = Color.FromArgb(32, 32, 32);

        public Bitmap Bitmap { get; set; }
        private Button button;
        public Button Button { get { return button; } set { button = value; } }

        private int id;
        public int Id { get { return id; } set { id = value; } }

        public int LevelID { get { return id % 25; } }
        public int WorldID { get { return id / 25; } }

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
            MakeButton();
        }

        public void Reset()
        {
            Id = 0;
            Colors = "bbbbbbbbbbbbbbbbbbbbbbbbb";
            MakeBitmap();
            MakeButton();
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

        private void MakeButton()
        {
            int buttonSizeX = 100;
            int buttonSizeY = 125;
            button = new Button
            {
                Size = new Size(buttonSizeX, buttonSizeY)
            };
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(64, 64, 64);
            button.ImageAlign = ContentAlignment.TopCenter;
            button.BackgroundImageLayout = ImageLayout.None;

            button.Text = WorldID + " - " + LevelID;
            button.ForeColor = Color.FromArgb(224, 224, 224);
            button.TextAlign = ContentAlignment.BottomCenter;
            button.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);

            button.BackgroundImage = Bitmap;
        }
    }
}

