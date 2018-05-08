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
    public partial class EnterForm : Form
    {
        private Light[,] grid;
        private int rowCount = 5;
        private int columnCount = 5;

        private string blank = "bbbbbbbbbbbbbbbbbbbbbbbbb";

        SQLiteConnection SQLConnect;

        public EnterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid = new Light[rowCount, columnCount];

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));

            for (int i = 0; i < rowCount; i++)
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));


            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j] = new Light();
                    grid[i, j].button.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(grid[i, j].button, j, i);
                    grid[i, j].button.Click += new EventHandler(button_click);
                }
            }
        }

        private void clear_board()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j].button.BackColor = Color.Black;
                }
            }
            WorldTB.Text = "";
            LevelTB.Text = "";
            LoadButton.Text = "Load";
            EnterButton.Text = "Save";
            WorldTB.ReadOnly = false;
            LevelTB.ReadOnly = false;
            DeleteButton.Enabled = false;
        }

        private int get_level(int ID)
        {
            return ID % 25;
        }

        private int get_world(int ID)
        {
            return ID / 25;
        }

        private int get_levelID(int world, int level)
        {
            return (world * 25) + level;
        }

        private void button_click(object sender, System.EventArgs e)
        {
            Light light = new Light(sender as Button);
            light.ChangeColor();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            //Concatenate all color to string str
            string str = "";
            string message;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    str += grid[i, j].GetColorInfo();
                }
            }
            if (str != blank && WorldTB.Text != "" && LevelTB.Text != "")
            {
                using (SQLConnect = new SQLiteConnection("Data Source=LightsOut.db;Version=3"))
                {
                    SQLConnect.Open();
                    SQLiteCommand SQLCommand = new SQLiteCommand();
                    SQLCommand = SQLConnect.CreateCommand();
                    if (EnterButton.Text == "Save")
                    {
                        SQLCommand.CommandText = "INSERT INTO LEVELS VALUES (@ID,@lights);";
                        message = " created.";
                    }
                    else
                    {
                        SQLCommand.CommandText = "UPDATE LEVELS SET COLORS = @lights WHERE LEVELID = @ID;";
                        message = " updated";
                    }
                        SQLCommand.Parameters.AddWithValue("@id", get_levelID(Convert.ToInt32(WorldTB.Text), Convert.ToInt32(LevelTB.Text)));
                    SQLCommand.Parameters.AddWithValue("@lights", str);
                    try
                    {
                        SQLCommand.ExecuteNonQuery();
                        MessageBox.Show("Level " + WorldTB.Text + "-" + LevelTB.Text + message);
                        //reset every button to black
                        clear_board();
                    }

                    catch (System.Data.SQLite.SQLiteException)
                    {
                        MessageBox.Show("Level " + WorldTB.Text + "-" + LevelTB.Text + " already exists.");
                    }

                    SQLCommand.Dispose();


                }

            }
            else
                MessageBox.Show("Level not added. Please try again.");

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (LoadButton.Text == "Load")
            {
                String colors = "";
                using (SQLConnect = new SQLiteConnection("Data Source=LightsOut.db;Version=3"))
                {
                    SQLConnect.Open();
                    SQLiteCommand SQLCommand = new SQLiteCommand();
                    SQLCommand = SQLConnect.CreateCommand();
                    SQLCommand.CommandText = "SELECT COLORS FROM LEVELS WHERE LevelID = @levelid;";
                    SQLCommand.Parameters.AddWithValue("@levelid", get_levelID(Convert.ToInt32(WorldTB.Text), Convert.ToInt32(LevelTB.Text)));
                    SQLiteDataReader Reader = SQLCommand.ExecuteReader();
                    Reader.Read();
                    try
                    {
                        colors = Reader.GetString(0);
                    }
                    catch
                    {
                        MessageBox.Show("Level does not exist.");
                        return;
                    }
                    Reader.Close();
                    SQLCommand.Dispose();
                }
                int let = 0;
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        grid[i, j].ReadColor(colors[let]);
                        let++;
                    }
                }
                LoadButton.Text = "Clear";
                EnterButton.Text = "Update";
                WorldTB.ReadOnly = true;
                LevelTB.ReadOnly = true;
                DeleteButton.Enabled = true;
            }
            else
            {
                clear_board();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (WorldTB.Text == "" || LevelTB.Text == "")
            {
                MessageBox.Show("World or Level not entered.");
                return;
            }
            using (SQLConnect = new SQLiteConnection("Data Source=LightsOut.db;Version=3"))
            {
                SQLConnect.Open();
                SQLiteCommand SQLCommand = new SQLiteCommand();
                SQLCommand = SQLConnect.CreateCommand();
                SQLCommand.CommandText = "DELETE FROM LEVELS WHERE LevelID = @levelid;";
                SQLCommand.Parameters.AddWithValue("@levelid", get_levelID(Convert.ToInt32(WorldTB.Text), Convert.ToInt32(LevelTB.Text)));
                SQLCommand.ExecuteNonQuery();
                SQLCommand.Dispose();
                MessageBox.Show("Level " + WorldTB.Text + "-" + LevelTB.Text + " deleted.");
                clear_board();
            }
        }
    }
}



/*TODO
 * Add data control to make sure its good data - solvable level
 * Remanage SQLConnections? Open once?
 * 
 * Done
 * Fix the look of the app
 * Add Delete button - CLOSE! - I don't know, this works?
 * Add a control for repeated levels? not a bad thing
 * */
