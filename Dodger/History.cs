using System.IO;
using System.Windows.Forms;

namespace Dodger
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();

            if (Directory.Exists(Application.StartupPath + "/Hiscores/"))
            {
                string[] hiscoreFiles = Directory.GetFiles(Application.StartupPath + "/Hiscores/", "*.txt");

                foreach(string file in hiscoreFiles)
                {
                    using (StreamReader SR = new StreamReader(file))
                    {
                        string line;

                        while ((line = SR.ReadLine()) != null)
                        {
                            HiscoresLb.Items.Add(line);
                        }
                    }
                }
                HiscoresLb.Sorted = true;

            } else { MessageBox.Show("Hiscores not available at this time", "Error"); return; }
        }
    }
}
