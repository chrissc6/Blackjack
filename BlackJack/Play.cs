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
            Hand1();
            GAME();
            
            
        }

        char answer;
        public int p1 = 0;
        public int dh = 0;
        string[] cards = new string[] {"AC","2C","3C","4C","5C","6C","7C","8C","9C","10C","JC","QC","KC",
            "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS",
            "AD","2D","3D","4D","5D","6D","7D","8D","9D","10D","JD","QD","KD",
            "AH","2H","3H","4H","5H","6H","7H","8H","9H","10H","JH","QH","KH"};
        int[] intcards = new int[] {0,2,3,4,5,6,7,8,9,10,10,10,10,
            0,2,3,4,5,6,7,8,9,10,10,10,10,
            0,2,3,4,5,6,7,8,9,10,10,10,10,
            0,2,3,4,5,6,7,8,9,10,10,10,10};
        //int indexVaule;
        Random rng = new Random();
        string x3s;
        string x4s;

        private void GAME()
        {

            WinCheck();
            
            
        }

        private void GetInput()
        {
            if (answer == 'H')
            {
                nextHand();
                GAME();
            }
            else if (answer == 'S')
            {
                dealerDraw();
                GAME();
            }
            else
                GAME();
        }

        private void button1Play_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        

        private void Hand1()
        {
            int x1 = rng.Next(0, 52);
            string x1s;
            int x2 = rng.Next(0, 52);
            string x2s;
            int x3 = rng.Next(0, 52);
            int x4 = rng.Next(0, 52);
            

            x1s = cards[x1];
            p1 = intcards[x1];
            x2s = cards[x2];
            p1 += intcards[x2];
            x3s = cards[x3];
            dh = intcards[x3];
            x4s = cards[x4];
            dh += intcards[x4];

            label3PLAYERhand.Text = $"{x1s}, {x2s}";
            label2Ptotal.Text = $"Total: {p1}";
            label2DEALERhand.Text = $"{x3s}, X";
            label2Dtotal.Text = $"Total: {intcards[x3]}";
        }

        private void WinCheck()
        {
            Button[] buttons = new Button[] { button1HIT, button2STAND };

            if (p1 == 21)
            {
                label2WIN.Text = "WINNER!";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
                
            }
            else
            {
                
            }
        }

        private void button1HIT_Click(object sender, EventArgs e)
        {
            answer = 'H';
            GetInput();
        }

        private void button2STAND_Click(object sender, EventArgs e)
        {
            answer = 'S';
            GetInput();
        }

        private void nextHand()
        {
            int x1 = rng.Next(0, 52);
            string x1s;

            x1s = cards[x1];
            p1 += intcards[x1];

            label3PLAYERhand.Text += $", {x1s}";
            label2Ptotal.Text = $"Total: {p1}";

            CheckLose();
        }

        private void CheckLose()
        {
            Button[] buttons = new Button[] { button1HIT, button2STAND };

            if (p1 > 21)
            {
                label2WIN.Text = "Lose.";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }

            }
            else
            {

            }
        }

        private void dealerDraw()
        {
            label2DEALERhand.Text = $"{x3s}, {x4s}";
            label2Dtotal.Text = $"Total: {dh}";
            
            if(dh < p1)
            {
                while (dh < 17)
                {
                    int x1 = rng.Next(0, 52);
                    string x1s;

                    x1s = cards[x1];
                    dh += intcards[x1];

                    label2DEALERhand.Text += $", {x1s}";
                    label2Dtotal.Text = $"Total: {dh}";
                }
            }

            if(dh>21)
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND };
                label2WIN.Text = "WINNER!";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }

            if (dh < p1)
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND };
                label2WIN.Text = "WINNER!";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }

            if ((dh > p1) && (dh < 22))
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND };
                label2WIN.Text = "Lose.";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Play ui = new Play();
            this.Hide();
            ui.ShowDialog();
        }
    }
}
