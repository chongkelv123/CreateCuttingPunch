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
            this.chkRetriveProjInfoFromDwg = new System.Windows.Forms.CheckBox();
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
            this.btnPathRetrieve = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblSketchStatus = new System.Windows.Forms.Label();
            this.btnSelectSketch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radFlange = new System.Windows.Forms.RadioButton();
            this.radScrew = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radShoulder = new System.Windows.Forms.RadioButton();
            this.radStraight = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipLength = new System.Windows.Forms.TextBox();
            this.txtPunchLength = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblDatumStatus = new System.Windows.Forms.Label();
            this.btnSelectDatum = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radOffsetDownPHT = new System.Windows.Forms.RadioButton();
            this.radPunHldTop = new System.Windows.Forms.RadioButton();
            this.txtOffSetDownPHT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.BtnApply.Enabled = false;
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
            this.groupBox9.Controls.Add(this.chkRetriveProjInfoFromDwg);
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
            this.groupBox9.Size = new System.Drawing.Size(836, 117);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Project Information";
            // 
            // chkRetriveProjInfoFromDwg
            // 
            this.chkRetriveProjInfoFromDwg.AutoSize = true;
            this.chkRetriveProjInfoFromDwg.Location = new System.Drawing.Point(628, 81);
            this.chkRetriveProjInfoFromDwg.Name = "chkRetriveProjInfoFromDwg";
            this.chkRetriveProjInfoFromDwg.Size = new System.Drawing.Size(159, 20);
            this.chkRetriveProjInfoFromDwg.TabIndex = 8;
            this.chkRetriveProjInfoFromDwg.Text = "Retrieve from drawing";
            this.chkRetriveProjInfoFromDwg.UseVisualStyleBackColor = true;
            this.chkRetriveProjInfoFromDwg.CheckedChanged += new System.EventHandler(this.chkRetriveProjInfoFromDwg_CheckedChanged);
            // 
            // btnSaveProjInfo
            // 
            this.btnSaveProjInfo.Location = new System.Drawing.Point(636, 17);
            this.btnSaveProjInfo.Name = "btnSaveProjInfo";
            this.btnSaveProjInfo.Size = new System.Drawing.Size(140, 30);
            this.btnSaveProjInfo.TabIndex = 7;
            this.btnSaveProjInfo.Text = "Save to file";
            this.btnSaveProjInfo.UseVisualStyleBackColor = true;
            this.btnSaveProjInfo.Click += new System.EventHandler(this.btnSaveProjInfo_Click);
            // 
            // chkRetriveProjInfo
            // 
            this.chkRetriveProjInfo.AutoSize = true;
            this.chkRetriveProjInfo.Location = new System.Drawing.Point(628, 55);
            this.chkRetriveProjInfo.Name = "chkRetriveProjInfo";
            this.chkRetriveProjInfo.Size = new System.Drawing.Size(184, 20);
            this.chkRetriveProjInfo.TabIndex = 6;
            this.chkRetriveProjInfo.Text = "Retrieve From external file";
            this.chkRetriveProjInfo.UseVisualStyleBackColor = true;
            this.chkRetriveProjInfo.CheckedChanged += new System.EventHandler(this.chkRetriveProjInfo_CheckedChanged);
            // 
            // cboDesign
            // 
            this.cboDesign.FormattingEnabled = true;
            this.cboDesign.Location = new System.Drawing.Point(408, 55);
            this.cboDesign.Name = "cboDesign";
            this.cboDesign.Size = new System.Drawing.Size(200, 24);
            this.cboDesign.TabIndex = 4;
            this.cboDesign.SelectedIndexChanged += new System.EventHandler(this.cboDesign_SelectedIndexChanged);
            // 
            // txtCodePrefix
            // 
            this.txtCodePrefix.Location = new System.Drawing.Point(408, 26);
            this.txtCodePrefix.Name = "txtCodePrefix";
            this.txtCodePrefix.Size = new System.Drawing.Size(200, 22);
            this.txtCodePrefix.TabIndex = 3;
            this.txtCodePrefix.TextChanged += new System.EventHandler(this.txtCodePrefix_TextChanged);
            // 
            // txtPart
            // 
            this.txtPart.Location = new System.Drawing.Point(73, 59);
            this.txtPart.Name = "txtPart";
            this.txtPart.Size = new System.Drawing.Size(200, 22);
            this.txtPart.TabIndex = 2;
            this.txtPart.TextChanged += new System.EventHandler(this.txtPart_TextChanged);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(73, 26);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(200, 22);
            this.txtModel.TabIndex = 1;
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
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
            this.groupBox1.Controls.Add(this.btnPathRetrieve);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Where would you like the Tooling Assembly to be saved to? Copy and paste the addr" +
    "ess here:";
            // 
            // btnPathRetrieve
            // 
            this.btnPathRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathRetrieve.Location = new System.Drawing.Point(719, 16);
            this.btnPathRetrieve.Name = "btnPathRetrieve";
            this.btnPathRetrieve.Size = new System.Drawing.Size(108, 30);
            this.btnPathRetrieve.TabIndex = 8;
            this.btnPathRetrieve.Text = "Retrive Path...";
            this.btnPathRetrieve.UseVisualStyleBackColor = true;
            this.btnPathRetrieve.Click += new System.EventHandler(this.btnPathRetrieve_Click);
            // 
            // txtPath
            // 
            this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Location = new System.Drawing.Point(6, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(707, 22);
            this.txtPath.TabIndex = 0;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.lblSketchStatus);
            this.groupBox6.Controls.Add(this.btnSelectSketch);
            this.groupBox6.Location = new System.Drawing.Point(218, 213);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(316, 73);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select Sketch or Punch Surface";
            // 
            // lblSketchStatus
            // 
            this.lblSketchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSketchStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSketchStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSketchStatus.Location = new System.Drawing.Point(120, 28);
            this.lblSketchStatus.Name = "lblSketchStatus";
            this.lblSketchStatus.Size = new System.Drawing.Size(139, 28);
            this.lblSketchStatus.TabIndex = 3;
            this.lblSketchStatus.Text = "No sketch selected";
            // 
            // btnSelectSketch
            // 
            this.btnSelectSketch.Location = new System.Drawing.Point(4, 28);
            this.btnSelectSketch.Name = "btnSelectSketch";
            this.btnSelectSketch.Size = new System.Drawing.Size(110, 28);
            this.btnSelectSketch.TabIndex = 0;
            this.btnSelectSketch.Text = "Selection...";
            this.btnSelectSketch.UseVisualStyleBackColor = true;
            this.btnSelectSketch.Click += new System.EventHandler(this.btnSelectSketch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 523);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radFlange);
            this.groupBox2.Controls.Add(this.radScrew);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 85);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mounting Type";
            // 
            // radFlange
            // 
            this.radFlange.AutoSize = true;
            this.radFlange.Location = new System.Drawing.Point(6, 53);
            this.radFlange.Name = "radFlange";
            this.radFlange.Size = new System.Drawing.Size(70, 20);
            this.radFlange.TabIndex = 1;
            this.radFlange.Text = "Flange";
            this.radFlange.UseVisualStyleBackColor = true;
            // 
            // radScrew
            // 
            this.radScrew.AutoSize = true;
            this.radScrew.Checked = true;
            this.radScrew.Location = new System.Drawing.Point(6, 27);
            this.radScrew.Name = "radScrew";
            this.radScrew.Size = new System.Drawing.Size(65, 20);
            this.radScrew.TabIndex = 0;
            this.radScrew.TabStop = true;
            this.radScrew.Text = "Screw";
            this.radScrew.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radShoulder);
            this.groupBox3.Controls.Add(this.radStraight);
            this.groupBox3.Location = new System.Drawing.Point(12, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 85);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Body Type";
            // 
            // radShoulder
            // 
            this.radShoulder.AutoSize = true;
            this.radShoulder.Location = new System.Drawing.Point(6, 53);
            this.radShoulder.Name = "radShoulder";
            this.radShoulder.Size = new System.Drawing.Size(82, 20);
            this.radShoulder.TabIndex = 1;
            this.radShoulder.Text = "Shoulder";
            this.radShoulder.UseVisualStyleBackColor = true;
            // 
            // radStraight
            // 
            this.radStraight.AutoSize = true;
            this.radStraight.Checked = true;
            this.radStraight.Location = new System.Drawing.Point(6, 27);
            this.radStraight.Name = "radStraight";
            this.radStraight.Size = new System.Drawing.Size(73, 20);
            this.radStraight.TabIndex = 0;
            this.radStraight.TabStop = true;
            this.radStraight.Text = "Straight";
            this.radStraight.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtOffSetDownPHT);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtTipLength);
            this.groupBox4.Controls.Add(this.txtPunchLength);
            this.groupBox4.Location = new System.Drawing.Point(12, 395);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 122);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Numerical Dimension";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tip Length (B:)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pun Length (L:)";
            // 
            // txtTipLength
            // 
            this.txtTipLength.Location = new System.Drawing.Point(6, 57);
            this.txtTipLength.Name = "txtTipLength";
            this.txtTipLength.Size = new System.Drawing.Size(80, 22);
            this.txtTipLength.TabIndex = 1;
            // 
            // txtPunchLength
            // 
            this.txtPunchLength.Location = new System.Drawing.Point(6, 29);
            this.txtPunchLength.Name = "txtPunchLength";
            this.txtPunchLength.Size = new System.Drawing.Size(80, 22);
            this.txtPunchLength.TabIndex = 0;
            this.txtPunchLength.TextChanged += new System.EventHandler(this.txtPunchLength_TextChanged);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(353, 156);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Location = new System.Drawing.Point(540, 212);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(365, 191);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pick the assembly for the punch:";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.lblDatumStatus);
            this.groupBox7.Controls.Add(this.btnSelectDatum);
            this.groupBox7.Location = new System.Drawing.Point(218, 292);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(316, 73);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select Datum";
            // 
            // lblDatumStatus
            // 
            this.lblDatumStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatumStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumStatus.ForeColor = System.Drawing.Color.Red;
            this.lblDatumStatus.Location = new System.Drawing.Point(120, 28);
            this.lblDatumStatus.Name = "lblDatumStatus";
            this.lblDatumStatus.Size = new System.Drawing.Size(139, 28);
            this.lblDatumStatus.TabIndex = 3;
            this.lblDatumStatus.Text = "No datum selected";
            // 
            // btnSelectDatum
            // 
            this.btnSelectDatum.Location = new System.Drawing.Point(4, 28);
            this.btnSelectDatum.Name = "btnSelectDatum";
            this.btnSelectDatum.Size = new System.Drawing.Size(110, 28);
            this.btnSelectDatum.TabIndex = 0;
            this.btnSelectDatum.Text = "Selection...";
            this.btnSelectDatum.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radOffsetDownPHT);
            this.groupBox8.Controls.Add(this.radPunHldTop);
            this.groupBox8.Location = new System.Drawing.Point(218, 371);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(316, 85);
            this.groupBox8.TabIndex = 17;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Place Punch Datum:";
            // 
            // radOffsetDownPHT
            // 
            this.radOffsetDownPHT.AutoSize = true;
            this.radOffsetDownPHT.Location = new System.Drawing.Point(6, 53);
            this.radOffsetDownPHT.Name = "radOffsetDownPHT";
            this.radOffsetDownPHT.Size = new System.Drawing.Size(269, 20);
            this.radOffsetDownPHT.TabIndex = 1;
            this.radOffsetDownPHT.Text = "Offset Downward from Punch Holder Top";
            this.radOffsetDownPHT.UseVisualStyleBackColor = true;
            // 
            // radPunHldTop
            // 
            this.radPunHldTop.AutoSize = true;
            this.radPunHldTop.Checked = true;
            this.radPunHldTop.Location = new System.Drawing.Point(6, 27);
            this.radPunHldTop.Name = "radPunHldTop";
            this.radPunHldTop.Size = new System.Drawing.Size(137, 20);
            this.radPunHldTop.TabIndex = 0;
            this.radPunHldTop.TabStop = true;
            this.radPunHldTop.Text = "Punch Holder Top";
            this.radPunHldTop.UseVisualStyleBackColor = true;
            // 
            // txtOffSetDownPHT
            // 
            this.txtOffSetDownPHT.Location = new System.Drawing.Point(6, 85);
            this.txtOffSetDownPHT.Name = "txtOffSetDownPHT";
            this.txtOffSetDownPHT.Size = new System.Drawing.Size(80, 22);
            this.txtOffSetDownPHT.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset PHT (O:)";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 703);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
        private System.Windows.Forms.Label lblSketchStatus;
        private System.Windows.Forms.Button btnSelectSketch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radFlange;
        private System.Windows.Forms.RadioButton radScrew;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radShoulder;
        private System.Windows.Forms.RadioButton radStraight;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTipLength;
        private System.Windows.Forms.TextBox txtPunchLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPathRetrieve;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkRetriveProjInfoFromDwg;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblDatumStatus;
        private System.Windows.Forms.Button btnSelectDatum;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radOffsetDownPHT;
        private System.Windows.Forms.RadioButton radPunHldTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOffSetDownPHT;
    }
}