using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARA
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("google.com");

        }
    }
}
