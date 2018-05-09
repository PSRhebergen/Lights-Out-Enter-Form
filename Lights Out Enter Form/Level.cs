using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lights_Out_Enter_Form
{
    class Level
    {
        public int id { get; set; }
        public string colors { get; set; }

        public Level()
        {
            reset();
        }

        public Level(int id, string colors)
        {
            this.id = id;
            this.colors = colors;
        }

        public void reset()
        {
            id = 0;
            colors = "bbbbbbbbbbbbbbbbbbbbbbbbb";
        }

        public int get_world()
        {
            return id / 25;
        }

        private int get_level()
        {
            return id % 25;
        }

        public string toString()
        {
            return id.ToString() + " " + colors;
        }
    }
}
