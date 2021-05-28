using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleMapApp
{
    public partial class FrmWorldMap : Form
    {
        public FrmWorldMap()
        {
            InitializeComponent();
        }

       
      

        private void FrmGeoReference_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //
        }
      
        private void FrmGeoReference_FormClosing(object sender, FormClosingEventArgs e)
        {
            registerMapCtl1.ControlClosing();
        }

        private void registerMapCtl1_Click(object sender, EventArgs e)
        {
           
        }

        private void registerMapCtl1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void registerMapCtl1_Load(object sender, EventArgs e)
        {

        }
    }
}
