using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Dodger.Classes;

namespace Dodger.Components
{
    class Rock : PictureBox
    {
        private Timer objTimer, mainTimer;
        private Panel FooterPanel;
        private Label ScoreLabel, RoundLabel;
        private PictureBox CharacterPb, HeartPb1, HeartPb2, HeartPb3, HeartPb4;
        private static Random rnd = new Random();

        public Rock(Panel FooterPanel, Label ScoreLabel, Timer mainTimer, PictureBox CharacterPb, 
            PictureBox HeartPb1, PictureBox HeartPb2, PictureBox HeartPb3, PictureBox HeartPb4, Label RoundLabel, Main main)
        {
            this.FooterPanel = FooterPanel;
            this.ScoreLabel = ScoreLabel;
            this.mainTimer = mainTimer;
            this.CharacterPb = CharacterPb;
            this.RoundLabel = RoundLabel;
            this.HeartPb1 = HeartPb1;
            this.HeartPb2 = HeartPb2;
            this.HeartPb3 = HeartPb3;
            this.HeartPb4 = HeartPb4;

            int locationPos = RandomNumber.Get(0, 1001);
            if (locationPos < 601)
                this.Location = new Point(RandomNumber.Get(50, Client.ClientWidth - 170), 1);
            else
                this.Location = new Point(CharacterPb.Location.X, 1);

            this.SizeMode = PictureBoxSizeMode.StretchImage;

            int chance = RandomNumber.Get(0, 101);
            if (chance != 39 && chance != 31)
                this.Image = Properties.Resources.Rock;
            else if (chance == 39 || chance == 31)
            {
                this.Image = Properties.Resources.heart2;
                this.Name = "Recover";
            }

            switch (User.Round)
            {
                case 1:
                    this.Size = new Size(25, 25);
                    break;
                case 2:
                    this.Size = new Size(40, 40);
                    break;
                case 3:
                    this.Size = new Size(55, 55);
                    break;
                case 4:
                    this.Size = new Size(70, 70);
                    break;
                case 5:
                    this.Size = new Size(85, 85);
                    break;
                case 6:
                    this.Size = new Size(100, 100);
                    break;
                case 7:
                    this.Size = new Size(110, 110);
                    break;
                case 8:
                    this.Size = new Size(120, 120);
                    break;
                case 9:
                    this.Size = new Size(130, 130);
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    this.Size = new Size(150, 150);
                    break;
            }
            this.objTimer = new Timer();
            this.objTimer.Interval = Objects.TimerInt;
            this.objTimer.Tick += ObjTimer_Tick;
            this.objTimer.Start();
        }
        private void ObjTimer_Tick(object sender, EventArgs e)
        {
            if (User.Lives == 0)
            {
                objTimer.Stop();
                return;
            }

            if (this.Location.Y < Client.ClientWidth - FooterPanel.Height)
            {
                this.Location += new Size(Objects.Direction, Objects.Speed);

                if (this.Bounds.IntersectsWith(CharacterPb.Bounds))
                {
                    if (this.Name == "Recover")
                    {
                        ExecuteSound(1).Play();
                        this.Visible = false;
                        objTimer.Stop();
                        if (User.Lives < 4)
                            User.Lives++;
                        Recover();
                    }
                    else
                    {
                        ExecuteSound(2).Play();
                        this.Visible = false;

                        if (User.CharacterFacingRight)
                            CharacterPb.Image = Properties.Resources.CharacterHitRight;
                        else
                            CharacterPb.Image = Properties.Resources.CharacterHitLeft;

                        CharacterPb.Refresh();
                        objTimer.Stop();

                        System.Threading.Thread.Sleep(1200);

                        ExecuteSound(3).Play();
                        if (User.CharacterFacingRight)
                            CharacterPb.Image = Properties.Resources.CharacterRight;
                        else
                            CharacterPb.Image = Properties.Resources.CharacterLeft;

                        User.Lives--;
                        Hit();
                    }
                }
            }

            if (this.Bounds.IntersectsWith(FooterPanel.Bounds))
            {
                ExecuteSound(4).Play();
                objTimer.Stop();
                this.Visible = false;
                User.Score += 10;
                Objects.Remaining--;
                ScoreLabel.Text = "Score: " + User.Score;
                if (User.Round < 15)
                RoundLabel.Text = "Remaining: " + Objects.Remaining + " - Round: " + User.Round;

                if (Objects.Remaining == 0)
                {
                    objTimer.Stop();
                    
                    User.Round++;
                    RoundLabel.Text = "Remaining: " + Objects.Remaining + " - Round: " + User.Round;

                    switch (User.Round)
                    {
                        case 2:
                            Objects.Speed += 3;
                            mainTimer.Interval -= 75;
                            Objects.Remaining = 20;
                            break;
                        case 3:
                            Objects.Speed += 4;
                            mainTimer.Interval -= 75;
                            Objects.Remaining = 25;
                            break;
                        case 4:
                            Objects.Speed += 5;
                            mainTimer.Interval -= 75;
                            Objects.Remaining = 30;
                            break;
                        case 5:
                            Objects.Speed += 6;
                            mainTimer.Interval -= 75;
                            Objects.Remaining = 35;
                            break;
                        case 6:
                            Objects.Speed += 7;
                            mainTimer.Interval -= 75;
                            Objects.Remaining = 40;
                            break;
                        case 7:
                            Objects.Speed += 8;
                            mainTimer.Interval -= 50;
                            Objects.Remaining = 45;
                            break;
                        case 8:
                            Objects.Speed += 9;
                            mainTimer.Interval -= 40;
                            Objects.Remaining = 50;
                            break;
                        case 9:
                            Objects.Speed += 10;
                            mainTimer.Interval -= 30;
                            Objects.Remaining = 55;
                            break;
                        case 10:
                            Objects.Speed += 11;
                            mainTimer.Interval -= 20;
                            Objects.Remaining = 60;
                            break;
                        case 15:
                            RoundLabel.Text = "Game Completed!";
                            break;
                        default:
                            Objects.Remaining = 60;
                            break;
                    }
                    this.Dispose();
                    objTimer.Start();
                }
            }
        }
        private void Hit()
        {
            switch (User.Lives)
            {
                case 3:
                    HeartPb1.Image = Properties.Resources.heart;
                    break;
                case 2:
                    HeartPb2.Image = Properties.Resources.heart;
                    break;
                case 1:
                    HeartPb3.Image = Properties.Resources.heart;
                    break;
                case 0:
                    HeartPb4.Image = Properties.Resources.heart;
                    break;
            }
        }
        private void Recover()
        {
            switch (User.Lives)
            {
                case 4:
                    HeartPb1.Image = Properties.Resources.heart2;
                    break;
                case 3:
                    HeartPb2.Image = Properties.Resources.heart2;
                    break;
                case 2:
                    HeartPb3.Image = Properties.Resources.heart2;
                    break;
                case 1:
                    HeartPb4.Image = Properties.Resources.heart2;
                    break;
            }
        }
        private SoundPlayer ExecuteSound(int flag)
        {
            SoundPlayer SE = new SoundPlayer();

            switch (flag)
            {
                case 1:
                    SE = new SoundPlayer(Properties.Resources.Life);
                    break;
                case 2:
                    SE = new SoundPlayer(Properties.Resources.Ouch);
                    break;
                case 3:
                    SE = new SoundPlayer(Properties.Resources.Groan);
                    break;
                case 4:
                    SE = new SoundPlayer(Properties.Resources.Smashing);
                    break;
            }
            return SE;
        }
    }
}
