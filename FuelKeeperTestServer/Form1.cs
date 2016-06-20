using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace be.subport.app.FuelKeeper.Test.Server
{
    public partial class Form1 : Form
    {
        DataProviderRunner dpr;

        public Form1()
        {
            InitializeComponent();
            dpr = new DataProviderRunner();
            dpr.Run();
            textBox1.Text = dpr.Test();
        }
    }
}
