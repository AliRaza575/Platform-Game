using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Platform_game_1
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
           
            lbl_over.Hide();
            lbl_win.Hide();
          
            
        }

        bool left, right, jump;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;
        int horizontalSpeed = 5;
        int verticalSpeed = 3;
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            enemymovement();
            

            lbl_score.Text = "Score: " + score;
            player1.Top += jumpSpeed;
            if (left == true)
            {
                player1.Left -= playerSpeed;
            }
            if (right == true)
            {
                player1.Left += playerSpeed;
            }
            if (jump == true && force < 0)
            {
                jump = false;
            }
            if (jump == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }
            collision();
            movement();

           
        }

        public void collision()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player1.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player1.Top = x.Top - player1.Height;
                            if ((string)x.Name == "horizontalPlatform" && left == false || (string)x.Name == "horizontalPlatform" && right == false)
                            {
                                player1.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }
                    if ((x is PictureBox && x.Tag == "coin"))
                    {
                        if (player1.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if ((string)x.Tag == "enemy")
                    {
                        if (player1.Bounds.IntersectsWith(x.Bounds))
                        {
                            timer1.Stop();

                            lbl_over.Show();
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                    }
             
                }
            }
        }
        public void movement()
        {
            horizontalPF2.Left -= horizontalSpeed;
            if (horizontalPF2.Left < 350 || horizontalPF2.Left + horizontalPF2.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            horizontolPF1.Left += horizontalSpeed;
            if (horizontolPF1.Left > 350 || horizontolPF1.Left + horizontolPF1.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            verticalPF.Top += verticalSpeed;
            if (verticalPF.Top < 200 || verticalPF.Top > 480)
            {
                verticalSpeed = -verticalSpeed;
            }

            if (player1.Top + player1.Height > this.ClientSize.Height + 50)
            {
                timer1.Stop();
                lbl_over.Show();
                Form2 form2 = new Form2();
                form2.Show();
                this.Close();
            }
            if ( score == 25)
            {
                lbl_win.Show();
                timer1.Stop();
                Form2 form2= new Form2();
                this.Close();
                form2.Show();
            }
            else
            {
                lbl_score.Text = "Score: " + score;
            }
        }
        public void enemymovement()
        {
            enemy1.Left -= enemyOneSpeed;
            if (enemy1.Left < pictureBox5.Left || enemy1.Left + enemy1.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }
            enemy2.Left += enemyTwoSpeed;
            if (enemy2.Left < pictureBox2.Left || enemy2.Left + enemy2.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }
        }
        private void Player_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Space && jump == false)
            {
                jump = true;
            }
        }

        private void Player_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }

        private void Player_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left= false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (jump == true)
            {
                jump = false;
            }


        }

        private void Player_Load(object sender, EventArgs e)
        {
           
        }

        

    }
}
