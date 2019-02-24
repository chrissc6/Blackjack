using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BlackJack
{
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
            
            
            
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
        int hitcount = 0;

        public string img1 { get; set; }

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
            int g;

            int x1 = rng.Next(0, 52);
            string x1s;
            int x2 = rng.Next(0, 52);
            string x2s;
            int x3 = rng.Next(0, 52);
            int x4 = rng.Next(0, 52);
            

            x1s = cards[x1];

            x1 = Check11(x1);
            if(x1 == 100)
            {
                p1 = 1;
            }
            else if(x1 == 1100)
            {
                p1 = 11;
            }
            else
            {
                p1 = intcards[x1];
            }
            
            x2s = cards[x2];

            x2 = Check11(x2);
            if (x2 == 100)
            {
                p1 += 1;
            }
            else if (x2 == 1100)
            {
                p1 += 11;
            }
            else
            {
                p1 += intcards[x2];
            }

            x3s = cards[x3];
            dh = intcards[x3];
            x4s = cards[x4];
            dh += intcards[x4];

            g = 1;
            PrintPic(x1s, x2s);

            
            

            label3PLAYERhand.Text = $"{x1s}, {x2s}";
            label2Ptotal.Text = $"Total: {p1}";
            label2DEALERhand.Text = $"{x3s}, X";
            label2Dtotal.Text = $"Total: {intcards[x3]}";
        }

        private int Check11(int x1)
        {
            int z;

            if((x1 == 0) || (x1 == 13) || (x1 == 26) || (x1 == 39))
            {
                const string message = "Do you want your ace to be 11?";
                const string caption = "Ace Check";
                var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    z = 1100;
                    return z;
                }
                else
                {
                    z = 100;
                    return z;
                }
            }

            z = x1;
            return z;
            
        }

        private void PrintPic(string x1s, string x2s)
        {
            img1 = @"Resources\";
            img1 += x1s;
            img1 += ".png";

            PBp1a.Image = Image.FromFile(img1);

            img1 = @"Resources\";
            img1 += x2s;
            img1 += ".png";

            PBp1b.Image = Image.FromFile(img1);
        }

        private void WinCheck()
        {
            Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };

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
            x1 = Check11(x1);
            if (x1 == 100)
            {
                p1 += 1;
            }
            else if (x1 == 1100)
            {
                p1 += 11;
            }
            else
            {
                p1 += intcards[x1];
            }
            

            label3PLAYERhand.Text += $", {x1s}";
            label2Ptotal.Text = $"Total: {p1}";

            hitcount++;
            PrintHit(hitcount, x1s);

            CheckLose();
        }

        private void PrintHit(int hitcount, string x1s)
        {

            switch (hitcount)
            {
                case 1:
                    img1 = @"Resources\";
                    img1 += x1s;
                    img1 += ".png";

                    PBp1c.Image = Image.FromFile(img1);
                    break;

                case 2:
                    img1 = @"Resources\";
                    img1 += x1s;
                    img1 += ".png";

                    PBp1d.Image = Image.FromFile(img1);
                    break;

                case 3:
                    img1 = @"Resources\";
                    img1 += x1s;
                    img1 += ".png";

                    PBp1e.Image = Image.FromFile(img1);
                    break;

                default:
                    break;
            }
        }

        private void CheckLose()
        {
            Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };

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

            while((p1 > dh) && (dh < 21))
            {
                int x1 = rng.Next(0, 52);
                string x1s;

                x1s = cards[x1];
                dh += intcards[x1];

                label2DEALERhand.Text += $", {x1s}";
                label2Dtotal.Text = $"Total: {dh}";
            }

            if(dh>21)
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };
                label2WIN.Text = "WINNER!";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }

            if (dh < p1)
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };
                label2WIN.Text = "WINNER!";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }

            if ((dh > p1) && (dh < 22))
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };
                label2WIN.Text = "Lose.";
                foreach (Button i in buttons)
                {
                    i.Enabled = false;
                }
            }

            if(dh == p1)
            {
                Button[] buttons = new Button[] { button1HIT, button2STAND, button2START };
                label2WIN.Text = "Push.";
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

        private void button2START_Click(object sender, EventArgs e)
        {
            Hand1();
            GAME();
        }
    }
}
