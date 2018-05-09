using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lights_Out_Enter_Form
{
    class Light
    {
        private Color green = Color.FromArgb(29, 185, 84);
        private Color red = Color.FromArgb(224, 56, 56);
        private Color black = Color.FromArgb(32, 32, 32);

        public Button button { get; set; }
        public Light()
        {
            button = new Button { BackColor = black };
            button.FlatStyle = 0;
            button.FlatAppearance.BorderSize = 0;
        }

        public Light(Button button)
        {
            this.button = button;
        }

        public void resetColor() //resets color to our black
        {
            button.BackColor = black;
        }

        public void ChangeColor() //Cycle color forward
        {
            if (button.BackColor == black)
                button.BackColor = red;
            else if (button.BackColor == red)
                button.BackColor = green;
            else if (button.BackColor == green)
                button.BackColor = black;
        }

        public void ReverseColor() //Cycle color backwards
        {
            if (button.BackColor == black)
                button.BackColor = green;
            else if (button.BackColor == green)
                button.BackColor = red;
            else if (button.BackColor == red)
                button.BackColor = black;
            
        }

        public string GetColorInfo() //converts color to DB ready data
        {
            if (button.BackColor == black)
                return "b";
            else if (button.BackColor == green)
                return "g";
            else if (button.BackColor == red)
                return "r";
            else
                return "0";

        }

        public void ReadColor(char color) //DB to color conversion
        {
            if (color == 'b')
                button.BackColor = black;
            else if (color == 'g')
                button.BackColor = green;
            else if (color == 'r')
                button.BackColor = red;
            else
                button.BackColor = Color.White; // just in case something goes wrong

        }
    }
}
