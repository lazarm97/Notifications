using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notification
{
    public partial class Alert : Form
    {
        public Alert(string message)
        {
            InitializeComponent();
            this.labelTime.Text = this.dateTimePicker1.Value.ToShortTimeString();
            this.timer1.Start();
            this.BringToFront();
            this.timer1.Interval = 10000;
            this.timer1.Enabled = true;
            this.label1.BringToFront();
            this.label1.Text = message;
        }

        public void Alert_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 60;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 30;

        }

        public void Show(string message)
        {
            new Notification.Alert(message);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            this.Close();
        }


    }
}
