using Dodger.Classes;
using System;
using System.Windows.Forms;

namespace Dodger.Components
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch (b.Name)
            {
                case "ContinueBtn":
                    if (NameTb.Text != "")
                    {
                        User.Name = NameTb.Text;
                        NameTb.Visible = false;
                        KeyboardBtn.Visible = true;
                        MouseBtn.Visible = true;
                        ContinueBtn.Visible = false;
                        this.ActiveControl = null;
                        NameLabel.Text = "--------------- Select an option ---------------";
                    }
                    else { MessageBox.Show("Please enter a name and try again.", "Error"); this.ActiveControl = NameTb; }
                    break;
                case "MouseBtn":
                    User.Mouse = true;
                    User.OptionComplete = true;
                    this.Hide();
                    using (Loading performLoad = new Loading())
                    {
                        performLoad.ShowDialog();
                    }
                    break;
                case "KeyboardBtn":
                    User.Mouse = false;
                    User.OptionComplete = true;
                    this.Hide();
                    using (Loading performLoad = new Loading())
                    {
                        performLoad.ShowDialog();
                    }
                    break;
            }
        }
    }
}