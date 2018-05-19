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

        private bool boardValid = true;

        SQLiteConnection SQLConnect;

        public EnterForm()
        {
            InitializeComponent();
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {
            grid = new Light[rowCount, columnCount];

            this.LightBoard.ColumnCount = columnCount;
            this.LightBoard.RowCount = rowCount;

            this.LightBoard.ColumnStyles.Clear();
            this.LightBoard.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
                this.LightBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));

            for (int i = 0; i < rowCount; i++)
                this.LightBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));


            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j] = new Light();
                    grid[i, j].Button.Dock = DockStyle.Fill;
                    this.LightBoard.Controls.Add(grid[i, j].Button, j, i);
                    grid[i, j].Button.MouseUp += new MouseEventHandler(button_click);
                }
            }

            this.LevelTB.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
            this.WorldTB.Validating += new System.ComponentModel.CancelEventHandler(this.TB_Validating);
        }

        protected void TB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox TB = sender as TextBox;
            int x;
            try
            {
                x = Int32.Parse(TB.Text);
                if (x < 1 && x > 25)
                    errorProvider1.SetError(TB, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(TB, "Non-numerical value.");
                boardValid = false;
                return;
            }

            if (x < 0 || x > 25)
            {
                errorProvider1.SetError(TB, "Invalid value.");
                boardValid = false;
            }
        }

        private int get_level(int ID)
        {
            return ID % 25 + 1;
        }

        private int get_world(int ID)
        {
            return ID / 25;
        }

        private int get_levelID(int world, int level)
        {
            return (world * 25) + level - 1;
        }

        private void DisplayColors(string colors)
        {
            int let = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j].ReadColor(colors[let]);
                    let++;
                }
            }
        }

        public void LoadLevel(Level level)
        {
            DisplayColors(level.Colors);
            LoadButton.Text = "Clear";
            EnterButton.Text = "Update";
            WorldTB.Text = level.WorldID.ToString();
            LevelTB.Text = level.LevelID.ToString();
            WorldTB.ReadOnly = true;
            LevelTB.ReadOnly = true;
            DeleteButton.Enabled = true;
        }

        private void clear_board()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    grid[i, j].resetColor();
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

        private void button_click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Light light = new Light(sender as Button);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                light.ChangeColor();
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                light.ReverseColor();
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

            if (str != blank && boardValid)
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
                        SetConfirmMessage("Level " + WorldTB.Text + "-" + LevelTB.Text + message);
                        //reset every button to black
                        clear_board();
                    }

                    catch (System.Data.SQLite.SQLiteException)
                    {
                        SetConfirmMessage("Level " + WorldTB.Text + "-" + LevelTB.Text + " already exists.");
                    }

                    SQLCommand.Dispose();
                    boardValid = true;

                }

            }
            else
                SetConfirmMessage("Level not added.");

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (LoadButton.Text == "Load")
            {
                if (WorldTB.Text == "" && LevelTB.Text == "")
                {
                    LevelSelection levelSelection = new LevelSelection();
                    levelSelection.Show();
                    levelSelection.CreatePictures();
                }
                else
                {
                    String colors = "";
                    int id = get_levelID(Convert.ToInt32(WorldTB.Text), Convert.ToInt32(LevelTB.Text));
                    using (SQLConnect = new SQLiteConnection("Data Source=LightsOut.db;Version=3"))
                    {
                        SQLConnect.Open();
                        SQLiteCommand SQLCommand = new SQLiteCommand();
                        SQLCommand = SQLConnect.CreateCommand();
                        SQLCommand.CommandText = "SELECT COLORS FROM LEVELS WHERE LevelID = @levelid;";
                        SQLCommand.Parameters.AddWithValue("@levelid", id);
                        SQLiteDataReader Reader = SQLCommand.ExecuteReader();
                        Reader.Read();
                        try
                        {
                            colors = Reader.GetString(0);
                        }
                        catch
                        {
                            SetConfirmMessage("Level does not exist.");
                            return;
                        }
                        Reader.Close();
                        SQLCommand.Dispose();
                    }

                    LoadLevel(new Level(id, colors));
                }
                //TODO Add handler for bad input
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
                SetConfirmMessage("World or Level not entered.");
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
                SetConfirmMessage("Level " + WorldTB.Text + "-" + LevelTB.Text + " deleted.");
                clear_board();
            }
        }

        private async void SetConfirmMessage(String message)
        {
            int i = 224;
            ConfirmLabel.Text = message;
            ConfirmLabel.ForeColor = Color.FromArgb(i, i, i);
            await Task.Delay(5000);
            while (i >= 105)
            {
                ConfirmLabel.ForeColor = Color.FromArgb(i, i, i);
                i -= 17;
                await Task.Delay(50);

            }

            ConfirmLabel.Text = "";
        }
    }
}



/*TODO
 * Add data control to make sure its good data - solvable level  ErrorProvider Class
 * Remanage SQLConnections? Open once?
 *   
 * HELP menu?
 * 
 * Load in database?
 * 
 * Done
 * Fix the look of the app
 * Add Delete button - CLOSE! - I don't know, this works?
 * Add a control for repeated levels? not a bad thing
 * */
