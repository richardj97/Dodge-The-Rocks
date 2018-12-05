using System.Windows.Forms;
using Dodger.Classes;

namespace Dodger.Components
{
    public partial class Loading : Form
    {
        private Timer loadingTimer;

        public Loading()
        {
            InitializeComponent();
            loadingTimer = new Timer();
            loadingTimer.Interval = 50;
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
        }
        private void LoadingTimer_Tick(object sender, System.EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                loadingTimer.Stop();

                if (User.OptionComplete)
                {
                    using (Main openGame = new Main())
                    {
                        this.Hide();
                        openGame.ShowDialog();
                    }
                }
                else
                {
                    using (Options openOptions = new Options())
                    {
                        this.Hide();
                        openOptions.ShowDialog();
                    }
                }
            }
            else
            {
                progressBar1.Value += 5;
            }
        }
    }
}
