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
            int buttonSizeX = 100;
            int buttonSizeY = 125;
            int buttonPad = 5;
            int count = 0;
            foreach (Level level in levels)
            {
                level.Button.Location = new Point((buttonSizeX + buttonPad) * (count % 3), (buttonSizeY + buttonPad) * (count / 3));

                level.Button.MouseUp += new MouseEventHandler(Double_click);

                count++;

                this.Controls.Add(level.Button);
            }
        }

        private void Double_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (Level level in levels)
            {
                if (level.Button == sender as Button)
                {
                    Application.OpenForms.OfType<EnterForm>().Single().LoadLevel(level);
                    this.Close();

                }
            }
        }

        public void printLevels()
        {
            foreach (Level L in levels)
            {
                MessageBox.Show(L.toString());
            }
        }
    }
}
