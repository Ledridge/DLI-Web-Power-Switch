using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StageSoft.WebPowerSwitch
{
    public partial class frmMain : Form
    {
        public WebPowerSwitch_Device _objSwitch;

        public frmMain()
        {
            InitializeComponent();

            _objSwitch = new WebPowerSwitch_Device();
            _objSwitch.StatusChanged += new EventHandler(_objSwitch_StatusChanged);
            _objSwitch.Configuration = new WebPowerSwitch_Config("192.168.0.100", "admin", "1234");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _cmdConfiguration_Click(null, null);
        }

        void _objSwitch_StatusChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(_objSwitch_StatusChanged), new object[] { sender, e });
            }
            else
            {
                UpdateStatus();
            }
        }

        private void UpdateStatus()
        {
            try
            {
                _lblControllerName.Text = _objSwitch.ControllerName;

                for (int i = 1; i <= 8; i++)
                {
                    Button ctl;
                    Label lbl;
                    switch (i)
                    {
                        case 1:
                            lbl = _lblSwitch1;
                            ctl = _cmdStatus1;
                            break;
                        case 2:
                            lbl = _lblSwitch2;
                            ctl = _cmdStatus2;
                            break;
                        case 3:
                            lbl = _lblSwitch3;
                            ctl = _cmdStatus3;
                            break;
                        case 4:
                            lbl = _lblSwitch4;
                            ctl = _cmdStatus4;
                            break;
                        case 5:
                            lbl = _lblSwitch5;
                            ctl = _cmdStatus5;
                            break;
                        case 6:
                            lbl = _lblSwitch6;
                            ctl = _cmdStatus6;
                            break;
                        case 7:
                            lbl = _lblSwitch7;
                            ctl = _cmdStatus7;
                            break;
                        case 8:
                            lbl = _lblSwitch8;
                            ctl = _cmdStatus8;
                            break;
                        default:
                            lbl = _lblSwitch1;
                            ctl = _cmdStatus1;
                            break;
                    }

                    bool bln = _objSwitch.Status(i);
                    lbl.Text = _objSwitch.RelayName(i);
                    ctl.Text = _objSwitch.BoolToText(bln);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdRefreshStatus_Click(object sender, EventArgs e)
        {
            try
            {
                _objSwitch.RefreshStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                frmProperties frm;
                frm = new frmProperties();

                //Create a disconnected copy to edit
                frm.DataSource = ObjectCopier.Clone<WebPowerSwitch_Config>(_objSwitch.Configuration);

                frm.ShowDialog(this);
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //If the user accepted the changes then apply them
                    _objSwitch.Configuration = frm.DataSource as WebPowerSwitch_Config;
                    _objSwitch.RefreshStatus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdStartScript_Click(object sender, EventArgs e)
        {
            try
            {
                _objSwitch.StartScript(int.Parse(_txtStartScript.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdRelayToggle_Click(object sender, EventArgs e)
        {
            try
            {
                Button ctl = sender as Button;
                if (ctl != null)
                {
                    int intRelay;
                    if (int.TryParse(ctl.Tag.ToString(), out intRelay))
                    {
                        _objSwitch.Relay_Toggle(intRelay);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdAllOn_Click(object sender, EventArgs e)
        {
            try
            {
                _objSwitch.Relay_SetAll(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _cmdAllOff_Click(object sender, EventArgs e)
        {
            try
            {
                _objSwitch.Relay_SetAll(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
