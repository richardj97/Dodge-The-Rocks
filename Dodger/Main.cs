using System;
using System.Drawing;
using System.Windows.Forms;
using Dodger.Components;
using Dodger.Classes;
using System.IO;

namespace Dodger
{
    public partial class Main : Form
    {
        private Timer MainTimer;
        private Rock[] Rocks;
        private int objs = 0, characterX, characterY;

        public Main()
        {
            InitializeComponent();
            User.Lives = 4;
            User.Round = 1;
            User.CharacterFacingRight = true;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Rocks = new Rock[5000];
            MainTimer = new Timer();
            MainTimer.Interval = 1000;
            MainTimer.Tick += MainTimer_Tick;
            MainTimer.Start();
            this.WindowState = FormWindowState.Maximized;
            Client.ClientWidth = Screen.GetWorkingArea(this).Width;
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (User.Lives > 0)
            {
                try
                {
                    Rocks[objs] = new Rock(FooterPanel, IntervalLabel, MainTimer, CharacterPb, HeartPb1, HeartPb2, HeartPb3, HeartPb4, RoundLabel, this);
                    this.Controls.Add(Rocks[objs]);
                    objs++;
                }
                catch { User.Lives = 0; MessageBox.Show("Wow! You have dodged 5,000 rocks!", "Mastered the game"); return; }
            }
            else if (User.Lives == 0)
            {
                MainTimer.Stop();

                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox)
                        c.Visible = false;
                }
                GameOverPanel.Visible = true;
                EndScoreLabel.Text = "Score : " + User.Score;
                EndRoundLabel.Text = "Round : " + User.Round;
                TotalScoreLabel.Text = "Total Score : " + User.Score * User.Round;

                try
                {
                    if (Directory.Exists(Application.StartupPath + "/Hiscores/"))
                    {
                        using (StreamWriter SW = new StreamWriter(Application.StartupPath + "/Hiscores/" + User.Name + ".txt", true))
                        {
                            SW.WriteLine(User.Name + " scored: " + User.Score * User.Round + " on " + DateTime.Now);
                            SW.Close();
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(Application.StartupPath + "/Hiscores/");

                        using (StreamWriter SW = new StreamWriter(Application.StartupPath + "/Hiscores/" + User.Name + ".txt", true))
                        {
                            SW.WriteLine(User.Name + " scored: " + User.Score * User.Round + " on " + DateTime.Now);
                            SW.Close();
                        }
                    }
                }
                catch { MessageBox.Show("Hiscores unavailable at this time", "Error"); return; }
            }
        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            CharacterPb.Location = new Point(this.Size.Width / 2, CharacterPb.Location.Y);
            Client.ClientWidth = this.Width;
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.FlatAppearance.BorderSize = 1;
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.FlatAppearance.BorderSize = 0;
        }
        private void PlayNowBtn_Click(object sender, EventArgs e)
        {
            Objects.NewGame = true;
            this.Dispose();
            User.Lives = 4;
            User.Score = 0;
            User.Round = 1;
            Objects.Remaining = 10;
            Objects.Speed = 7;
            Objects.Direction = 0;
            MainTimer.Interval = 1000;
            Loading PerformLoad = new Loading();
            PerformLoad.ShowDialog();
            this.Size = new Size(Client.ClientWidth, this.Size.Height);
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (User.Mouse != true)
            {
                int y = CharacterPb.Location.Y;
                int x = CharacterPb.Location.X;

                if (e.KeyCode == Keys.Right && x < this.Size.Width - 150)
                {
                    User.CharacterFacingRight = true;
                    x = x + 50;
                    CharacterPb.Location = new Point(x, y);
                    CharacterPb.Image = Properties.Resources.CharacterRight;
                }
                else if (e.KeyCode == Keys.Left && x > 50)
                {
                    User.CharacterFacingRight = false;
                    x = x - 50;
                    CharacterPb.Location = new Point(x, y);
                    CharacterPb.Image = Properties.Resources.CharacterLeft;
                }
            }
        }
        private void CharacterPb_MouseUp(object sender, MouseEventArgs e)
        {
            if (User.Mouse)
            {
                var c = sender as PictureBox;
                if (null == c)
                    return;
                else
                    Client.IsDragging = false;
            }
        }
        private void CharacterPb_MouseDown(object sender, MouseEventArgs e)
        {
            if (User.Mouse)
            {
                Client.IsDragging = true;
                characterX = e.X;
                characterY = e.Y;
            }
        }

        private void HiscoresBtn_Click(object sender, EventArgs e)
        {
            using (History OpenHistory = new History())
            {
                OpenHistory.ShowDialog();
            }
        }
        private void CharacterPb_MouseMove(object sender, MouseEventArgs e)
        {
            if (User.Mouse)
            {
                var c = sender as PictureBox;
                if (!Client.IsDragging || null == c)
                    return;
                else
                {
                    if (CharacterPb.Location.X > this.Size.Width - 130)
                    {
                        Client.IsDragging = false;
                        CharacterPb.Location = new Point(CharacterPb.Location.X - 5, CharacterPb.Location.Y);
                    }
                    if (CharacterPb.Location.X > 0 + 10)
                    {
                        c.Left = e.X + c.Left - characterX;
                    }
                    else
                    {
                        Client.IsDragging = false;
                        CharacterPb.Location = new Point(CharacterPb.Location.X + 5, CharacterPb.Location.Y);
                    }
                }
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Objects.NewGame)
                return;
            else
                Application.Exit();
        }
    }
}
