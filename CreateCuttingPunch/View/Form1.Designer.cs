namespace CreateCuttingPunch.View
{
    partial class UserForm
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSaveProjInfo = new System.Windows.Forms.Button();
            this.chkRetriveProjInfo = new System.Windows.Forms.CheckBox();
            this.cboDesign = new System.Windows.Forms.ComboBox();
            this.txtCodePrefix = new System.Windows.Forms.TextBox();
            this.txtPart = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblPlateSketchStatus = new System.Windows.Forms.Label();
            this.lblPlateSketchInstructions = new System.Windows.Forms.Label();
            this.btnSelectSketch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.radPartialCoverage = new System.Windows.Forms.RadioButton();
            this.radFullCoverage = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(643, 656);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(117, 35);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.Location = new System.Drawing.Point(766, 656);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(117, 35);
            this.BtnApply.TabIndex = 0;
            this.BtnApply.Text = "&Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox9.Controls.Add(this.btnSaveProjInfo);
            this.groupBox9.Controls.Add(this.chkRetriveProjInfo);
            this.groupBox9.Controls.Add(this.cboDesign);
            this.groupBox9.Controls.Add(this.txtCodePrefix);
            this.groupBox9.Controls.Add(this.txtPart);
            this.groupBox9.Controls.Add(this.txtModel);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Location = new System.Drawing.Point(12, 89);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(836, 90);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Project Information";
            // 
            // btnSaveProjInfo
            // 
            this.btnSaveProjInfo.Location = new System.Drawing.Point(676, 17);
            this.btnSaveProjInfo.Name = "btnSaveProjInfo";
            this.btnSaveProjInfo.Size = new System.Drawing.Size(140, 30);
            this.btnSaveProjInfo.TabIndex = 7;
            this.btnSaveProjInfo.Text = "Save to file";
            this.btnSaveProjInfo.UseVisualStyleBackColor = true;
            // 
            // chkRetriveProjInfo
            // 
            this.chkRetriveProjInfo.AutoSize = true;
            this.chkRetriveProjInfo.Location = new System.Drawing.Point(676, 61);
            this.chkRetriveProjInfo.Name = "chkRetriveProjInfo";
            this.chkRetriveProjInfo.Size = new System.Drawing.Size(151, 20);
            this.chkRetriveProjInfo.TabIndex = 6;
            this.chkRetriveProjInfo.Text = "Retrieve project info:";
            this.chkRetriveProjInfo.UseVisualStyleBackColor = true;
            // 
            // cboDesign
            // 
            this.cboDesign.FormattingEnabled = true;
            this.cboDesign.Location = new System.Drawing.Point(408, 55);
            this.cboDesign.Name = "cboDesign";
            this.cboDesign.Size = new System.Drawing.Size(200, 24);
            this.cboDesign.TabIndex = 4;
            // 
            // txtCodePrefix
            // 
            this.txtCodePrefix.Location = new System.Drawing.Point(408, 26);
            this.txtCodePrefix.Name = "txtCodePrefix";
            this.txtCodePrefix.Size = new System.Drawing.Size(200, 22);
            this.txtCodePrefix.TabIndex = 3;
            // 
            // txtPart
            // 
            this.txtPart.Location = new System.Drawing.Point(73, 59);
            this.txtPart.Name = "txtPart";
            this.txtPart.Size = new System.Drawing.Size(200, 22);
            this.txtPart.TabIndex = 2;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(73, 26);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(200, 22);
            this.txtModel.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(290, 54);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label18.Size = new System.Drawing.Size(71, 26);
            this.label18.TabIndex = 0;
            this.label18.Text = "Design by:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(290, 21);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label19.Size = new System.Drawing.Size(106, 26);
            this.label19.TabIndex = 0;
            this.label19.Text = "Dwg code prefix:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 54);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label20.Size = new System.Drawing.Size(47, 26);
            this.label20.TabIndex = 0;
            this.label20.Text = "PART:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 21);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label21.Size = new System.Drawing.Size(57, 26);
            this.label21.TabIndex = 0;
            this.label21.Text = "MODEL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Where would you like the Tooling Assembly to be saved to? Copy and paste the addr" +
    "ess here:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(6, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(824, 22);
            this.txtPath.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox6.Controls.Add(this.lblPlateSketchStatus);
            this.groupBox6.Controls.Add(this.lblPlateSketchInstructions);
            this.groupBox6.Controls.Add(this.btnSelectSketch);
            this.groupBox6.Location = new System.Drawing.Point(12, 532);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(292, 90);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select Sketch or Punch Surface";
            // 
            // lblPlateSketchStatus
            // 
            this.lblPlateSketchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlateSketchStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateSketchStatus.ForeColor = System.Drawing.Color.Red;
            this.lblPlateSketchStatus.Location = new System.Drawing.Point(147, 47);
            this.lblPlateSketchStatus.Name = "lblPlateSketchStatus";
            this.lblPlateSketchStatus.Size = new System.Drawing.Size(139, 28);
            this.lblPlateSketchStatus.TabIndex = 3;
            this.lblPlateSketchStatus.Text = "No sketch selected";
            // 
            // lblPlateSketchInstructions
            // 
            this.lblPlateSketchInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlateSketchInstructions.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlateSketchInstructions.Location = new System.Drawing.Point(6, 26);
            this.lblPlateSketchInstructions.Name = "lblPlateSketchInstructions";
            this.lblPlateSketchInstructions.Size = new System.Drawing.Size(280, 21);
            this.lblPlateSketchInstructions.TabIndex = 4;
            this.lblPlateSketchInstructions.Text = "Select a plate sketch from the NX model.";
            // 
            // btnSelectSketch
            // 
            this.btnSelectSketch.Location = new System.Drawing.Point(6, 47);
            this.btnSelectSketch.Name = "btnSelectSketch";
            this.btnSelectSketch.Size = new System.Drawing.Size(133, 28);
            this.btnSelectSketch.TabIndex = 0;
            this.btnSelectSketch.Text = "Select Sketch...";
            this.btnSelectSketch.UseVisualStyleBackColor = true;
            this.btnSelectSketch.Click += new System.EventHandler(this.btnSelectSketch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(560, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 267);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.radPartialCoverage);
            this.groupBox12.Controls.Add(this.radFullCoverage);
            this.groupBox12.Location = new System.Drawing.Point(18, 194);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(335, 85);
            this.groupBox12.TabIndex = 15;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Punch Type";
            // 
            // radPartialCoverage
            // 
            this.radPartialCoverage.AutoSize = true;
            this.radPartialCoverage.Location = new System.Drawing.Point(6, 53);
            this.radPartialCoverage.Name = "radPartialCoverage";
            this.radPartialCoverage.Size = new System.Drawing.Size(108, 20);
            this.radPartialCoverage.TabIndex = 1;
            this.radPartialCoverage.Text = "Round Punch";
            this.radPartialCoverage.UseVisualStyleBackColor = true;
            // 
            // radFullCoverage
            // 
            this.radFullCoverage.AutoSize = true;
            this.radFullCoverage.Checked = true;
            this.radFullCoverage.Location = new System.Drawing.Point(6, 27);
            this.radFullCoverage.Name = "radFullCoverage";
            this.radFullCoverage.Size = new System.Drawing.Size(102, 20);
            this.radFullCoverage.TabIndex = 0;
            this.radFullCoverage.TabStop = true;
            this.radFullCoverage.Text = "Block Punch";
            this.radFullCoverage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Location = new System.Drawing.Point(18, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 85);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mounting Type";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 53);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 20);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Text = "Flange";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 27);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(65, 20);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Screw";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Location = new System.Drawing.Point(18, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 85);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Body Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 53);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 20);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Shoulder";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 20);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Straight";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 703);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.BtnCancel);
            this.Name = "UserForm";
            this.Text = "Create Cutting Punch Form";
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnSaveProjInfo;
        private System.Windows.Forms.CheckBox chkRetriveProjInfo;
        private System.Windows.Forms.ComboBox cboDesign;
        private System.Windows.Forms.TextBox txtCodePrefix;
        private System.Windows.Forms.TextBox txtPart;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblPlateSketchStatus;
        private System.Windows.Forms.Label lblPlateSketchInstructions;
        private System.Windows.Forms.Button btnSelectSketch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton radPartialCoverage;
        private System.Windows.Forms.RadioButton radFullCoverage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}