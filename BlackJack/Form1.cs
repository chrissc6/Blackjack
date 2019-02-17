﻿using System;
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
    public partial class Blackjack : Form
    {
        public Blackjack()
        {
            InitializeComponent();
        }

        private void button1Play_Click(object sender, EventArgs e)
        {
            Play ui = new Play();
            this.Hide();
            ui.ShowDialog();
            this.Show();
        }

        private void button1Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
