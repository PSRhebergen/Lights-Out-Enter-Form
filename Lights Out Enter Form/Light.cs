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

        private Button button;
        public Button Button { get { return button; } set { button = value; } }
        public Light()
        {
            Button = new Button { BackColor = black };
            Button.FlatStyle = 0;
            Button.FlatAppearance.BorderSize = 0;
        }

        public Light(Button button)
        {
            this.Button = button;
        }

        public void resetColor() //resets color to our black
        {
            Button.BackColor = black;
        }

        public void ChangeColor() //Cycle color forward
        {
            if (Button.BackColor == black)
                Button.BackColor = red;
            else if (Button.BackColor == red)
                Button.BackColor = green;
            else if (Button.BackColor == green)
                Button.BackColor = black;
        }

        public void ReverseColor() //Cycle color backwards
        {
            if (Button.BackColor == black)
                Button.BackColor = green;
            else if (Button.BackColor == green)
                Button.BackColor = red;
            else if (Button.BackColor == red)
                Button.BackColor = black;
            
        }

        public string GetColorInfo() //converts color to DB ready data
        {
            if (Button.BackColor == black)
                return "b";
            else if (Button.BackColor == green)
                return "g";
            else if (Button.BackColor == red)
                return "r";
            else
                return "0";

        }

        public void ReadColor(char color) //DB to color conversion
        {
            if (color == 'b')
                Button.BackColor = black;
            else if (color == 'g')
                Button.BackColor = green;
            else if (color == 'r')
                Button.BackColor = red;
            else
                Button.BackColor = Color.White; // just in case something goes wrong

        }
    }
}
