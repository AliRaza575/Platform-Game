using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platform_game_1
{
    public partial class Normal : Form
    {
        public Normal()
        {
            InitializeComponent();
            lbl_over.Hide();
            lbl_win.Hide();
        }
        bool moveleft, moveright, jumping;
        int ps = 7;
        int force;
        int js;
        int horizontalSpeed=5;
        int verticalSpeed=3;
        int score;
        int enemyOneSpeed=5;
        int enemyTwoSpeed=5;
        int enemyThreeSpeed = 5;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Normal_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            enemymovement();
            lbl_score.Text = "Score: " + score;
            player.Top += js;
            if (moveleft == true)
            {
                player.Left -=ps;
            }
            if (moveright == true)
            {
                player.Left += ps;
            }
            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                js = -8;
                force -= 1;
            }
            else
            {
                js = 10;
            };
            
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
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                            if ((string)x.Name == "horizontalPlatform" && moveleft == false || (string)x.Name == "horizontalPlatform" && moveright == false)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }
                    if ((x is PictureBox && x.Tag == "coin"))
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            timer1.Stop();

                            lbl_over.Show();
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Close();
                        }
                    }
                    //if ((string)x.Tag == "door")
                    //{
                    //    if (player.Bounds.IntersectsWith(x.Bounds) && score == 15)
                    //    {
                    //        timer1.Stop();
                    //        lbl_win.Show();
                    //    }
                    //}
                }
            }
        }
        public void movement()
        {
            HorizontolPF2.Left -= horizontalSpeed;
            if (HorizontolPF2.Left < 420 || HorizontolPF2.Left + HorizontolPF2.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            horizontolPF1.Left += horizontalSpeed;
            if (horizontolPF1.Left > 350 || horizontolPF1.Left + horizontolPF1.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            VerticalPF.Top += verticalSpeed;
            if (VerticalPF.Top < 100 || VerticalPF.Top > 250)
            {
                verticalSpeed = -verticalSpeed;
            }

            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                timer1.Stop();
                lbl_over.Show();
                Form2 form2 = new Form2();
                form2.Show();
                this.Close();
            }
            if (score == 30)
            {
                timer1.Stop();
                lbl_win.Show();
                Form2 form2=new Form2();
                form2.Show();
                this.Close();
            }
            else
            {
                lbl_score.Text = "Score: " + score;
            }
        }
        public void enemymovement()
        {
            enemy1.Left -= enemyOneSpeed;
            if (enemy1.Left < pictureBox3.Left || enemy1.Left + enemy1.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }
            enemy2.Left += enemyTwoSpeed;
            if (enemy2.Left < pictureBox6.Left || enemy2.Left + enemy2.Width > pictureBox6.Left + pictureBox6.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }
            enemy3.Left -= enemyThreeSpeed;
            if(enemy3.Left < pictureBox5.Left || enemy3.Left+enemy3.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyThreeSpeed =-enemyThreeSpeed;
            }
        }

        private void Normal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Normal_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                moveleft = false;
            }
            if(e.KeyCode==Keys.Right)
            {
                moveright = false;
            }
            if(jumping==true)
            {
                jumping = false;
            }
        }

        private void Normal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveleft =true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveright = true;
            }
            if ( e.KeyCode==Keys.Space && jumping==false)
            {
                jumping = true;
            }
        }
    }
}
