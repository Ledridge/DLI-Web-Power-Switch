using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StageSoft.WebPowerSwitch
{
    public partial class frmProperties : Form
    {
        public frmProperties()
        {
            InitializeComponent();
        }

        public object DataSource 
        {
            get { return _grdMain.SelectedObject; }
            set { _grdMain.SelectedObject = value; }
        }
    }
}
