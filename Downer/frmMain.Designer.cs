namespace Downer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblWhen = new System.Windows.Forms.Label();
            this.radShutdown = new System.Windows.Forms.RadioButton();
            this.radReboot = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.spinDay = new System.Windows.Forms.NumericUpDown();
            this.spinHour = new System.Windows.Forms.NumericUpDown();
            this.spinMinute = new System.Windows.Forms.NumericUpDown();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.spinYear = new System.Windows.Forms.NumericUpDown();
            this.btnAbort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spinDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWhen
            // 
            this.lblWhen.AutoSize = true;
            this.lblWhen.Location = new System.Drawing.Point(10, 16);
            this.lblWhen.Name = "lblWhen";
            this.lblWhen.Size = new System.Drawing.Size(39, 13);
            this.lblWhen.TabIndex = 0;
            this.lblWhen.Text = "When:";
            // 
            // radShutdown
            // 
            this.radShutdown.AutoSize = true;
            this.radShutdown.Location = new System.Drawing.Point(160, 44);
            this.radShutdown.Name = "radShutdown";
            this.radShutdown.Size = new System.Drawing.Size(76, 17);
            this.radShutdown.TabIndex = 2;
            this.radShutdown.Text = "Shut down";
            this.radShutdown.UseVisualStyleBackColor = true;
            // 
            // radReboot
            // 
            this.radReboot.AutoSize = true;
            this.radReboot.Checked = true;
            this.radReboot.Location = new System.Drawing.Point(275, 44);
            this.radReboot.Name = "radReboot";
            this.radReboot.Size = new System.Drawing.Size(60, 17);
            this.radReboot.TabIndex = 3;
            this.radReboot.TabStop = true;
            this.radReboot.Text = "Reboot";
            this.radReboot.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(257, 78);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // spinDay
            // 
            this.spinDay.Location = new System.Drawing.Point(80, 13);
            this.spinDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinDay.Name = "spinDay";
            this.spinDay.Size = new System.Drawing.Size(40, 20);
            this.spinDay.TabIndex = 6;
            this.spinDay.ValueChanged += new System.EventHandler(this.spinDay_ValueChanged);
            // 
            // spinHour
            // 
            this.spinHour.Location = new System.Drawing.Point(247, 13);
            this.spinHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinHour.Name = "spinHour";
            this.spinHour.Size = new System.Drawing.Size(40, 20);
            this.spinHour.TabIndex = 7;
            this.spinHour.ValueChanged += new System.EventHandler(this.spinHour_ValueChanged);
            // 
            // spinMinute
            // 
            this.spinMinute.Location = new System.Drawing.Point(292, 13);
            this.spinMinute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinMinute.Name = "spinMinute";
            this.spinMinute.Size = new System.Drawing.Size(40, 20);
            this.spinMinute.TabIndex = 8;
            this.spinMinute.ValueChanged += new System.EventHandler(this.spinMinute_ValueChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(126, 13);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(59, 21);
            this.cmbMonth.TabIndex = 9;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // spinYear
            // 
            this.spinYear.Location = new System.Drawing.Point(191, 14);
            this.spinYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinYear.Name = "spinYear";
            this.spinYear.Size = new System.Drawing.Size(50, 20);
            this.spinYear.TabIndex = 10;
            this.spinYear.ValueChanged += new System.EventHandler(this.spinYear_ValueChanged);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(13, 78);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(132, 23);
            this.btnAbort.TabIndex = 11;
            this.btnAbort.Text = "&Abort pending shutdown";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 112);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.spinYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.spinMinute);
            this.Controls.Add(this.spinHour);
            this.Controls.Add(this.spinDay);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radReboot);
            this.Controls.Add(this.radShutdown);
            this.Controls.Add(this.lblWhen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Schedule Downer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.spinDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWhen;
        private System.Windows.Forms.RadioButton radShutdown;
        private System.Windows.Forms.RadioButton radReboot;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown spinDay;
        private System.Windows.Forms.NumericUpDown spinHour;
        private System.Windows.Forms.NumericUpDown spinMinute;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.NumericUpDown spinYear;
        private System.Windows.Forms.Button btnAbort;
    }
}

