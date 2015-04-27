namespace StageSoft.WebPowerSwitch
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cmdRefreshStatus = new System.Windows.Forms.Button();
            this._cmdConfiguration = new System.Windows.Forms.Button();
            this._cmdStartScript = new System.Windows.Forms.Button();
            this._txtStartScript = new System.Windows.Forms.TextBox();
            this._cmdStatus1 = new System.Windows.Forms.Button();
            this._lblSwitch1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblSwitch2 = new System.Windows.Forms.Label();
            this._cmdStatus2 = new System.Windows.Forms.Button();
            this._lblSwitch3 = new System.Windows.Forms.Label();
            this._cmdStatus3 = new System.Windows.Forms.Button();
            this._lblSwitch4 = new System.Windows.Forms.Label();
            this._cmdStatus4 = new System.Windows.Forms.Button();
            this._lblSwitch5 = new System.Windows.Forms.Label();
            this._cmdStatus5 = new System.Windows.Forms.Button();
            this._lblSwitch6 = new System.Windows.Forms.Label();
            this._cmdStatus6 = new System.Windows.Forms.Button();
            this._lblSwitch7 = new System.Windows.Forms.Label();
            this._cmdStatus7 = new System.Windows.Forms.Button();
            this._lblSwitch8 = new System.Windows.Forms.Label();
            this._cmdStatus8 = new System.Windows.Forms.Button();
            this._cmdAllOn = new System.Windows.Forms.Button();
            this._cmdAllOff = new System.Windows.Forms.Button();
            this._lblControllerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cmdRefreshStatus
            // 
            this._cmdRefreshStatus.Location = new System.Drawing.Point(5, 126);
            this._cmdRefreshStatus.Name = "_cmdRefreshStatus";
            this._cmdRefreshStatus.Size = new System.Drawing.Size(101, 23);
            this._cmdRefreshStatus.TabIndex = 0;
            this._cmdRefreshStatus.Text = "Refresh Status";
            this._cmdRefreshStatus.UseVisualStyleBackColor = true;
            this._cmdRefreshStatus.Click += new System.EventHandler(this._cmdRefreshStatus_Click);
            // 
            // _cmdConfiguration
            // 
            this._cmdConfiguration.Location = new System.Drawing.Point(5, 5);
            this._cmdConfiguration.Name = "_cmdConfiguration";
            this._cmdConfiguration.Size = new System.Drawing.Size(101, 23);
            this._cmdConfiguration.TabIndex = 0;
            this._cmdConfiguration.Text = "Configuration";
            this._cmdConfiguration.UseVisualStyleBackColor = true;
            this._cmdConfiguration.Click += new System.EventHandler(this._cmdConfiguration_Click);
            // 
            // _cmdStartScript
            // 
            this._cmdStartScript.Location = new System.Drawing.Point(5, 212);
            this._cmdStartScript.Name = "_cmdStartScript";
            this._cmdStartScript.Size = new System.Drawing.Size(70, 23);
            this._cmdStartScript.TabIndex = 1;
            this._cmdStartScript.Text = "Start Script";
            this._cmdStartScript.UseVisualStyleBackColor = true;
            this._cmdStartScript.Click += new System.EventHandler(this._cmdStartScript_Click);
            // 
            // _txtStartScript
            // 
            this._txtStartScript.Location = new System.Drawing.Point(81, 214);
            this._txtStartScript.Name = "_txtStartScript";
            this._txtStartScript.Size = new System.Drawing.Size(25, 20);
            this._txtStartScript.TabIndex = 2;
            this._txtStartScript.Text = "1";
            this._txtStartScript.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _cmdStatus1
            // 
            this._cmdStatus1.Location = new System.Drawing.Point(266, 39);
            this._cmdStatus1.Name = "_cmdStatus1";
            this._cmdStatus1.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus1.TabIndex = 3;
            this._cmdStatus1.Tag = "1";
            this._cmdStatus1.Text = "?";
            this._cmdStatus1.UseVisualStyleBackColor = true;
            this._cmdStatus1.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch1
            // 
            this._lblSwitch1.AutoSize = true;
            this._lblSwitch1.Location = new System.Drawing.Point(123, 44);
            this._lblSwitch1.Name = "_lblSwitch1";
            this._lblSwitch1.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch1.TabIndex = 4;
            this._lblSwitch1.Text = "Switch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SWITCH                     STATUS";
            // 
            // _lblSwitch2
            // 
            this._lblSwitch2.AutoSize = true;
            this._lblSwitch2.Location = new System.Drawing.Point(123, 69);
            this._lblSwitch2.Name = "_lblSwitch2";
            this._lblSwitch2.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch2.TabIndex = 6;
            this._lblSwitch2.Text = "Switch";
            // 
            // _cmdStatus2
            // 
            this._cmdStatus2.Location = new System.Drawing.Point(266, 64);
            this._cmdStatus2.Name = "_cmdStatus2";
            this._cmdStatus2.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus2.TabIndex = 5;
            this._cmdStatus2.Tag = "2";
            this._cmdStatus2.Text = "?";
            this._cmdStatus2.UseVisualStyleBackColor = true;
            this._cmdStatus2.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch3
            // 
            this._lblSwitch3.AutoSize = true;
            this._lblSwitch3.Location = new System.Drawing.Point(123, 94);
            this._lblSwitch3.Name = "_lblSwitch3";
            this._lblSwitch3.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch3.TabIndex = 8;
            this._lblSwitch3.Text = "Switch";
            // 
            // _cmdStatus3
            // 
            this._cmdStatus3.Location = new System.Drawing.Point(266, 89);
            this._cmdStatus3.Name = "_cmdStatus3";
            this._cmdStatus3.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus3.TabIndex = 7;
            this._cmdStatus3.Tag = "3";
            this._cmdStatus3.Text = "?";
            this._cmdStatus3.UseVisualStyleBackColor = true;
            this._cmdStatus3.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch4
            // 
            this._lblSwitch4.AutoSize = true;
            this._lblSwitch4.Location = new System.Drawing.Point(123, 119);
            this._lblSwitch4.Name = "_lblSwitch4";
            this._lblSwitch4.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch4.TabIndex = 10;
            this._lblSwitch4.Text = "Switch";
            // 
            // _cmdStatus4
            // 
            this._cmdStatus4.Location = new System.Drawing.Point(266, 114);
            this._cmdStatus4.Name = "_cmdStatus4";
            this._cmdStatus4.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus4.TabIndex = 9;
            this._cmdStatus4.Tag = "4";
            this._cmdStatus4.Text = "?";
            this._cmdStatus4.UseVisualStyleBackColor = true;
            this._cmdStatus4.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch5
            // 
            this._lblSwitch5.AutoSize = true;
            this._lblSwitch5.Location = new System.Drawing.Point(123, 144);
            this._lblSwitch5.Name = "_lblSwitch5";
            this._lblSwitch5.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch5.TabIndex = 12;
            this._lblSwitch5.Text = "Switch";
            // 
            // _cmdStatus5
            // 
            this._cmdStatus5.Location = new System.Drawing.Point(266, 139);
            this._cmdStatus5.Name = "_cmdStatus5";
            this._cmdStatus5.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus5.TabIndex = 11;
            this._cmdStatus5.Tag = "5";
            this._cmdStatus5.Text = "?";
            this._cmdStatus5.UseVisualStyleBackColor = true;
            this._cmdStatus5.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch6
            // 
            this._lblSwitch6.AutoSize = true;
            this._lblSwitch6.Location = new System.Drawing.Point(123, 169);
            this._lblSwitch6.Name = "_lblSwitch6";
            this._lblSwitch6.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch6.TabIndex = 14;
            this._lblSwitch6.Text = "Switch";
            // 
            // _cmdStatus6
            // 
            this._cmdStatus6.Location = new System.Drawing.Point(266, 164);
            this._cmdStatus6.Name = "_cmdStatus6";
            this._cmdStatus6.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus6.TabIndex = 13;
            this._cmdStatus6.Tag = "6";
            this._cmdStatus6.Text = "?";
            this._cmdStatus6.UseVisualStyleBackColor = true;
            this._cmdStatus6.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch7
            // 
            this._lblSwitch7.AutoSize = true;
            this._lblSwitch7.Location = new System.Drawing.Point(123, 194);
            this._lblSwitch7.Name = "_lblSwitch7";
            this._lblSwitch7.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch7.TabIndex = 16;
            this._lblSwitch7.Text = "Switch";
            // 
            // _cmdStatus7
            // 
            this._cmdStatus7.Location = new System.Drawing.Point(266, 189);
            this._cmdStatus7.Name = "_cmdStatus7";
            this._cmdStatus7.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus7.TabIndex = 15;
            this._cmdStatus7.Tag = "7";
            this._cmdStatus7.Text = "?";
            this._cmdStatus7.UseVisualStyleBackColor = true;
            this._cmdStatus7.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _lblSwitch8
            // 
            this._lblSwitch8.AutoSize = true;
            this._lblSwitch8.Location = new System.Drawing.Point(123, 219);
            this._lblSwitch8.Name = "_lblSwitch8";
            this._lblSwitch8.Size = new System.Drawing.Size(39, 13);
            this._lblSwitch8.TabIndex = 18;
            this._lblSwitch8.Text = "Switch";
            // 
            // _cmdStatus8
            // 
            this._cmdStatus8.Location = new System.Drawing.Point(266, 214);
            this._cmdStatus8.Name = "_cmdStatus8";
            this._cmdStatus8.Size = new System.Drawing.Size(29, 23);
            this._cmdStatus8.TabIndex = 17;
            this._cmdStatus8.Tag = "8";
            this._cmdStatus8.Text = "?";
            this._cmdStatus8.UseVisualStyleBackColor = true;
            this._cmdStatus8.Click += new System.EventHandler(this._cmdRelayToggle_Click);
            // 
            // _cmdAllOn
            // 
            this._cmdAllOn.Location = new System.Drawing.Point(5, 154);
            this._cmdAllOn.Name = "_cmdAllOn";
            this._cmdAllOn.Size = new System.Drawing.Size(101, 23);
            this._cmdAllOn.TabIndex = 17;
            this._cmdAllOn.Text = "Switch All On";
            this._cmdAllOn.UseVisualStyleBackColor = true;
            this._cmdAllOn.Click += new System.EventHandler(this._cmdAllOn_Click);
            // 
            // _cmdAllOff
            // 
            this._cmdAllOff.Location = new System.Drawing.Point(5, 183);
            this._cmdAllOff.Name = "_cmdAllOff";
            this._cmdAllOff.Size = new System.Drawing.Size(101, 23);
            this._cmdAllOff.TabIndex = 17;
            this._cmdAllOff.Text = "Switch All Off";
            this._cmdAllOff.UseVisualStyleBackColor = true;
            this._cmdAllOff.Click += new System.EventHandler(this._cmdAllOff_Click);
            // 
            // _lblControllerName
            // 
            this._lblControllerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblControllerName.Location = new System.Drawing.Point(123, 4);
            this._lblControllerName.Name = "_lblControllerName";
            this._lblControllerName.Size = new System.Drawing.Size(187, 13);
            this._lblControllerName.TabIndex = 19;
            this._lblControllerName.Text = "Controller Name";
            this._lblControllerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 243);
            this.Controls.Add(this._lblControllerName);
            this.Controls.Add(this._lblSwitch8);
            this.Controls.Add(this._cmdAllOff);
            this.Controls.Add(this._cmdAllOn);
            this.Controls.Add(this._cmdStatus8);
            this.Controls.Add(this._lblSwitch7);
            this.Controls.Add(this._cmdStatus7);
            this.Controls.Add(this._lblSwitch6);
            this.Controls.Add(this._cmdStatus6);
            this.Controls.Add(this._lblSwitch5);
            this.Controls.Add(this._cmdStatus5);
            this.Controls.Add(this._lblSwitch4);
            this.Controls.Add(this._cmdStatus4);
            this.Controls.Add(this._lblSwitch3);
            this.Controls.Add(this._cmdStatus3);
            this.Controls.Add(this._lblSwitch2);
            this.Controls.Add(this._cmdStatus2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblSwitch1);
            this.Controls.Add(this._cmdStatus1);
            this.Controls.Add(this._txtStartScript);
            this.Controls.Add(this._cmdStartScript);
            this.Controls.Add(this._cmdConfiguration);
            this.Controls.Add(this._cmdRefreshStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Web Power Switch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cmdRefreshStatus;
        private System.Windows.Forms.Button _cmdConfiguration;
        private System.Windows.Forms.Button _cmdStartScript;
        private System.Windows.Forms.TextBox _txtStartScript;
        private System.Windows.Forms.Button _cmdStatus1;
        private System.Windows.Forms.Label _lblSwitch1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblSwitch2;
        private System.Windows.Forms.Button _cmdStatus2;
        private System.Windows.Forms.Label _lblSwitch3;
        private System.Windows.Forms.Button _cmdStatus3;
        private System.Windows.Forms.Label _lblSwitch4;
        private System.Windows.Forms.Button _cmdStatus4;
        private System.Windows.Forms.Label _lblSwitch5;
        private System.Windows.Forms.Button _cmdStatus5;
        private System.Windows.Forms.Label _lblSwitch6;
        private System.Windows.Forms.Button _cmdStatus6;
        private System.Windows.Forms.Label _lblSwitch7;
        private System.Windows.Forms.Button _cmdStatus7;
        private System.Windows.Forms.Label _lblSwitch8;
        private System.Windows.Forms.Button _cmdStatus8;
        private System.Windows.Forms.Button _cmdAllOn;
        private System.Windows.Forms.Button _cmdAllOff;
        private System.Windows.Forms.Label _lblControllerName;
    }
}

