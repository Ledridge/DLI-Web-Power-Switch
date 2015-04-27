namespace StageSoft.WebPowerSwitch
{
    partial class frmProperties
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
            this._cmdCancel = new System.Windows.Forms.Button();
            this._cmdOk = new System.Windows.Forms.Button();
            this._grdMain = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // _cmdCancel
            // 
            this._cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cmdCancel.Location = new System.Drawing.Point(230, 292);
            this._cmdCancel.Name = "_cmdCancel";
            this._cmdCancel.Size = new System.Drawing.Size(75, 23);
            this._cmdCancel.TabIndex = 0;
            this._cmdCancel.Text = "&Cancel";
            this._cmdCancel.UseVisualStyleBackColor = true;
            // 
            // _cmdOk
            // 
            this._cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._cmdOk.Location = new System.Drawing.Point(149, 292);
            this._cmdOk.Name = "_cmdOk";
            this._cmdOk.Size = new System.Drawing.Size(75, 23);
            this._cmdOk.TabIndex = 0;
            this._cmdOk.Text = "&OK";
            this._cmdOk.UseVisualStyleBackColor = true;
            // 
            // _grdMain
            // 
            this._grdMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._grdMain.Location = new System.Drawing.Point(4, 5);
            this._grdMain.Name = "_grdMain";
            this._grdMain.Size = new System.Drawing.Size(301, 281);
            this._grdMain.TabIndex = 1;
            // 
            // frmProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cmdCancel;
            this.ClientSize = new System.Drawing.Size(311, 321);
            this.Controls.Add(this._grdMain);
            this.Controls.Add(this._cmdOk);
            this.Controls.Add(this._cmdCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(275, 300);
            this.Name = "frmProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _cmdCancel;
        private System.Windows.Forms.Button _cmdOk;
        private System.Windows.Forms.PropertyGrid _grdMain;
    }
}