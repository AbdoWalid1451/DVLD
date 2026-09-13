namespace DVLD_Presentation_Layer.TestAppointments
{
    partial class frmScheduleTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleTest));
            this.lblTestApp = new System.Windows.Forms.Label();
            this.pbTestApp = new System.Windows.Forms.PictureBox();
            this.dgvAllTestApp = new System.Windows.Forms.DataGridView();
            this.btnAddLDLApp = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLDLAppInfo1 = new DVLD_Presentation_Layer.LocalDrivingLicenseApplication.ctrlLDLAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestApp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestApp
            // 
            this.lblTestApp.AutoSize = true;
            this.lblTestApp.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestApp.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTestApp.Location = new System.Drawing.Point(214, 133);
            this.lblTestApp.Name = "lblTestApp";
            this.lblTestApp.Size = new System.Drawing.Size(337, 44);
            this.lblTestApp.TabIndex = 14;
            this.lblTestApp.Text = "Test Appointments";
            // 
            // pbTestApp
            // 
            this.pbTestApp.Location = new System.Drawing.Point(339, 12);
            this.pbTestApp.Name = "pbTestApp";
            this.pbTestApp.Size = new System.Drawing.Size(175, 118);
            this.pbTestApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestApp.TabIndex = 13;
            this.pbTestApp.TabStop = false;
            // 
            // dgvAllTestApp
            // 
            this.dgvAllTestApp.AllowUserToAddRows = false;
            this.dgvAllTestApp.AllowUserToDeleteRows = false;
            this.dgvAllTestApp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAllTestApp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllTestApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllTestApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllTestApp.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllTestApp.Location = new System.Drawing.Point(12, 631);
            this.dgvAllTestApp.Name = "dgvAllTestApp";
            this.dgvAllTestApp.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllTestApp.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllTestApp.RowHeadersWidth = 51;
            this.dgvAllTestApp.RowTemplate.Height = 24;
            this.dgvAllTestApp.Size = new System.Drawing.Size(870, 162);
            this.dgvAllTestApp.TabIndex = 16;
            // 
            // btnAddLDLApp
            // 
            this.btnAddLDLApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddLDLApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLDLApp.ForeColor = System.Drawing.Color.Gray;
            this.btnAddLDLApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLDLApp.Image")));
            this.btnAddLDLApp.Location = new System.Drawing.Point(836, 587);
            this.btnAddLDLApp.Name = "btnAddLDLApp";
            this.btnAddLDLApp.Size = new System.Drawing.Size(46, 38);
            this.btnAddLDLApp.TabIndex = 20;
            this.btnAddLDLApp.UseVisualStyleBackColor = true;
            this.btnAddLDLApp.Click += new System.EventHandler(this.btnAddLDLApp_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(124, 800);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(14, 16);
            this.lblRecords.TabIndex = 22;
            this.lblRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 796);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Appointments:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(713, 800);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 37);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctrlLDLAppInfo1
            // 
            this.ctrlLDLAppInfo1.Location = new System.Drawing.Point(-5, 180);
            this.ctrlLDLAppInfo1.Name = "ctrlLDLAppInfo1";
            this.ctrlLDLAppInfo1.Size = new System.Drawing.Size(887, 412);
            this.ctrlLDLAppInfo1.TabIndex = 25;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(897, 847);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddLDLApp);
            this.Controls.Add(this.dgvAllTestApp);
            this.Controls.Add(this.lblTestApp);
            this.Controls.Add(this.pbTestApp);
            this.Controls.Add(this.ctrlLDLAppInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTestAppointment";
            this.Load += new System.EventHandler(this.frmVisionTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTestApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestApp;
        private System.Windows.Forms.PictureBox pbTestApp;
        private System.Windows.Forms.DataGridView dgvAllTestApp;
        private System.Windows.Forms.Button btnAddLDLApp;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private LocalDrivingLicenseApplication.ctrlLDLAppInfo ctrlLDLAppInfo1;
    }
}