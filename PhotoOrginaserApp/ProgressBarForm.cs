using System;
using System.Windows.Forms;

namespace PhotoOrginaserApp
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        public void SetMaximum(int max)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progressBar.Maximum = max));
            }
            else
            {
                progressBar.Maximum = max;
            }
        }

        public void UpdateProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progressBar.Value = value));
            }
            else
            {
                progressBar.Value = value;
            }
        }
    }
}
