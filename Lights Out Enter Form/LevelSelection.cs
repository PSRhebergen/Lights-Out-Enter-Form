using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Lights_Out_Enter_Form
{
    public partial class LevelSelection : Form
    {
        private List<Level> levels;

        internal System.Windows.Forms.ImageList ImageList1;

        private Color green = Color.FromArgb(29, 185, 84);
        private Color red = Color.FromArgb(224, 56, 56);
        private Color black = Color.FromArgb(32, 32, 32);

        SQLiteConnection SQLConnect;

        public LevelSelection()
        {
            InitializeComponent();
        }

        private void LevelSelection_Load(object sender, EventArgs e)
        {
            levels = new List<Level>();

            ReadLevels();
        }

        private void ReadLevels()
        {
            using (SQLConnect = new SQLiteConnection("Data Source=LightsOut.db;Version=3"))
            {
                SQLConnect.Open();
                SQLiteCommand SQLCommand = new SQLiteCommand();
                SQLCommand = SQLConnect.CreateCommand();
                SQLCommand.CommandText = "SELECT * FROM LEVELS;";
                SQLiteDataReader Reader = SQLCommand.ExecuteReader();
                while (Reader.Read())
                {
                    try
                    {
                        levels.Add(new Level(Reader.GetInt32(0), Reader.GetString(1)));
                    }
                    catch
                    {
                        return;
                    }
                }
                Reader.Close();
                SQLCommand.Dispose();
            }
        }

        public void CreatePictures()
        {
            ImageList1 = new ImageList
            {
                ImageSize = new Size(100, 100)
            };
            foreach (Level level in levels)
            {
                Bitmap bmp = new Bitmap(100, 100);
                Graphics graphics = Graphics.FromImage(bmp);

                int boxSize = 20;
                int x = 0;
                int y = 0;

                Brush brush;
                foreach (char c in level.colors)
                {
                    if (c == 'b')
                        brush = Brushes.Black;
                    else if (c == 'r')
                        brush = Brushes.Red;
                    else if (c == 'g')
                        brush = Brushes.Green;
                    else
                        brush = Brushes.White;

                    graphics.FillRectangle(brush, x * boxSize, y * boxSize, boxSize, boxSize);

                    x++;

                    if (x == 5)
                    {
                        y++;
                        x = 0;
                    }
                }

                ImageList1.Images.Add(bmp);
            }

            Graphics theGraphics = Graphics.FromHwnd(this.Handle);
            int xOffset, yOffset;
            for (int count = 0; count < ImageList1.Images.Count; count++)
            {
                xOffset = count / 3;
                yOffset = count % 3;
                ImageList1.Draw(theGraphics, new Point(101*xOffset, 101*yOffset), count);
                Application.DoEvents();
            }
        }

        public void printLevels()
        {
            foreach(Level L in levels)
            {
                MessageBox.Show(L.toString());
            }
        }
    }
}
