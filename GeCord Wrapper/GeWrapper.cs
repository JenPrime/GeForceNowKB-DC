using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeCord_Wrapper
{
    public partial class GeWrapper : Form
    {
        string game = "GG!";
        public GeWrapper(string rgame)
        {
            game = rgame;
            InitializeComponent();
        }

        private void GeWrapper_Load(object sender, EventArgs e)
        {
            this.Text = "GeWrapper for: " + game;   
            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
        }
    }
}
