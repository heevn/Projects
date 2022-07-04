using System;
using System.Windows.Forms;

namespace LoadingScreen
{
    public partial class LoadScreen : Form
    {
        Timer tmr = new Timer() { Interval = 3000 };

        public LoadScreen()
        {
            InitializeComponent();
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
 
        void tmr_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
