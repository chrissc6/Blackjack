using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
        }

        private void button1Play_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
