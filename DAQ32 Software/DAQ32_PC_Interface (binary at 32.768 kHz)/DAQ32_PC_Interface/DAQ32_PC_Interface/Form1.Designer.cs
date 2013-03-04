namespace DAQ32_PC_Interface
{
    partial class Form1
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
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_packets = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_open = new System.Windows.Forms.Button();
            this.textBox_errors = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_samplerate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_channels = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_COM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_samplePeriod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_scopeA0 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeA1 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeA2 = new System.Windows.Forms.ComboBox();
            this.label_scopeA = new System.Windows.Forms.Label();
            this.label_scopeB = new System.Windows.Forms.Label();
            this.comboBox_scopeB2 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeB1 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeB0 = new System.Windows.Forms.ComboBox();
            this.label_scopeC = new System.Windows.Forms.Label();
            this.comboBox_scopeC2 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeC1 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeC0 = new System.Windows.Forms.ComboBox();
            this.label_scopeD = new System.Windows.Forms.Label();
            this.comboBox_scopeD2 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeD1 = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeD0 = new System.Windows.Forms.ComboBox();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_startLog = new System.Windows.Forms.Button();
            this.comboBox_scopeDtrig = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeCtrig = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeBtrig = new System.Windows.Forms.ComboBox();
            this.comboBox_scopeAtrig = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Packet count:";
            // 
            // textBox_packets
            // 
            this.textBox_packets.Enabled = false;
            this.textBox_packets.Location = new System.Drawing.Point(95, 117);
            this.textBox_packets.Name = "textBox_packets";
            this.textBox_packets.Size = new System.Drawing.Size(81, 20);
            this.textBox_packets.TabIndex = 5;
            this.textBox_packets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Framing errors:";
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(181, 10);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(69, 23);
            this.button_open.TabIndex = 1;
            this.button_open.Text = "Open port";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_openPort_Click);
            // 
            // textBox_errors
            // 
            this.textBox_errors.Enabled = false;
            this.textBox_errors.Location = new System.Drawing.Point(95, 143);
            this.textBox_errors.Name = "textBox_errors";
            this.textBox_errors.Size = new System.Drawing.Size(81, 20);
            this.textBox_errors.TabIndex = 6;
            this.textBox_errors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "kHz";
            // 
            // textBox_samplerate
            // 
            this.textBox_samplerate.Enabled = false;
            this.textBox_samplerate.Location = new System.Drawing.Point(95, 65);
            this.textBox_samplerate.Name = "textBox_samplerate";
            this.textBox_samplerate.Size = new System.Drawing.Size(80, 20);
            this.textBox_samplerate.TabIndex = 3;
            this.textBox_samplerate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Sample rate:";
            // 
            // textBox_channels
            // 
            this.textBox_channels.Enabled = false;
            this.textBox_channels.Location = new System.Drawing.Point(95, 39);
            this.textBox_channels.Name = "textBox_channels";
            this.textBox_channels.Size = new System.Drawing.Size(80, 20);
            this.textBox_channels.TabIndex = 2;
            this.textBox_channels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Channels:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "COM port:";
            // 
            // comboBox_COM
            // 
            this.comboBox_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_COM.FormattingEnabled = true;
            this.comboBox_COM.Location = new System.Drawing.Point(95, 12);
            this.comboBox_COM.Name = "comboBox_COM";
            this.comboBox_COM.Size = new System.Drawing.Size(80, 21);
            this.comboBox_COM.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "µs";
            // 
            // textBox_samplePeriod
            // 
            this.textBox_samplePeriod.Enabled = false;
            this.textBox_samplePeriod.Location = new System.Drawing.Point(95, 91);
            this.textBox_samplePeriod.Name = "textBox_samplePeriod";
            this.textBox_samplePeriod.Size = new System.Drawing.Size(80, 20);
            this.textBox_samplePeriod.TabIndex = 4;
            this.textBox_samplePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Sample period:";
            // 
            // comboBox_scopeA0
            // 
            this.comboBox_scopeA0.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeA0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeA0.ForeColor = System.Drawing.Color.Lime;
            this.comboBox_scopeA0.FormattingEnabled = true;
            this.comboBox_scopeA0.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeA0.Location = new System.Drawing.Point(95, 169);
            this.comboBox_scopeA0.Name = "comboBox_scopeA0";
            this.comboBox_scopeA0.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeA0.TabIndex = 7;
            this.comboBox_scopeA0.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeA012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeA1
            // 
            this.comboBox_scopeA1.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeA1.ForeColor = System.Drawing.Color.Fuchsia;
            this.comboBox_scopeA1.FormattingEnabled = true;
            this.comboBox_scopeA1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeA1.Location = new System.Drawing.Point(142, 169);
            this.comboBox_scopeA1.Name = "comboBox_scopeA1";
            this.comboBox_scopeA1.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeA1.TabIndex = 8;
            this.comboBox_scopeA1.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeA012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeA2
            // 
            this.comboBox_scopeA2.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeA2.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox_scopeA2.FormattingEnabled = true;
            this.comboBox_scopeA2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeA2.Location = new System.Drawing.Point(189, 169);
            this.comboBox_scopeA2.Name = "comboBox_scopeA2";
            this.comboBox_scopeA2.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeA2.TabIndex = 9;
            this.comboBox_scopeA2.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeA012trig_SelectedIndexChanged);
            // 
            // label_scopeA
            // 
            this.label_scopeA.AutoSize = true;
            this.label_scopeA.Location = new System.Drawing.Point(12, 172);
            this.label_scopeA.Name = "label_scopeA";
            this.label_scopeA.Size = new System.Drawing.Size(51, 13);
            this.label_scopeA.TabIndex = 44;
            this.label_scopeA.Text = "Scope A:";
            // 
            // label_scopeB
            // 
            this.label_scopeB.AutoSize = true;
            this.label_scopeB.Location = new System.Drawing.Point(12, 199);
            this.label_scopeB.Name = "label_scopeB";
            this.label_scopeB.Size = new System.Drawing.Size(51, 13);
            this.label_scopeB.TabIndex = 49;
            this.label_scopeB.Text = "Scope B:";
            // 
            // comboBox_scopeB2
            // 
            this.comboBox_scopeB2.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeB2.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox_scopeB2.FormattingEnabled = true;
            this.comboBox_scopeB2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeB2.Location = new System.Drawing.Point(189, 196);
            this.comboBox_scopeB2.Name = "comboBox_scopeB2";
            this.comboBox_scopeB2.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeB2.TabIndex = 13;
            this.comboBox_scopeB2.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeB012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeB1
            // 
            this.comboBox_scopeB1.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeB1.ForeColor = System.Drawing.Color.Fuchsia;
            this.comboBox_scopeB1.FormattingEnabled = true;
            this.comboBox_scopeB1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeB1.Location = new System.Drawing.Point(142, 196);
            this.comboBox_scopeB1.Name = "comboBox_scopeB1";
            this.comboBox_scopeB1.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeB1.TabIndex = 12;
            this.comboBox_scopeB1.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeB012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeB0
            // 
            this.comboBox_scopeB0.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeB0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeB0.ForeColor = System.Drawing.Color.Lime;
            this.comboBox_scopeB0.FormattingEnabled = true;
            this.comboBox_scopeB0.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeB0.Location = new System.Drawing.Point(95, 196);
            this.comboBox_scopeB0.Name = "comboBox_scopeB0";
            this.comboBox_scopeB0.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeB0.TabIndex = 11;
            this.comboBox_scopeB0.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeB012trig_SelectedIndexChanged);
            // 
            // label_scopeC
            // 
            this.label_scopeC.AutoSize = true;
            this.label_scopeC.Location = new System.Drawing.Point(12, 226);
            this.label_scopeC.Name = "label_scopeC";
            this.label_scopeC.Size = new System.Drawing.Size(51, 13);
            this.label_scopeC.TabIndex = 54;
            this.label_scopeC.Text = "Scope C:";
            // 
            // comboBox_scopeC2
            // 
            this.comboBox_scopeC2.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeC2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeC2.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox_scopeC2.FormattingEnabled = true;
            this.comboBox_scopeC2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeC2.Location = new System.Drawing.Point(189, 223);
            this.comboBox_scopeC2.Name = "comboBox_scopeC2";
            this.comboBox_scopeC2.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeC2.TabIndex = 17;
            this.comboBox_scopeC2.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeC012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeC1
            // 
            this.comboBox_scopeC1.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeC1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeC1.ForeColor = System.Drawing.Color.Fuchsia;
            this.comboBox_scopeC1.FormattingEnabled = true;
            this.comboBox_scopeC1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeC1.Location = new System.Drawing.Point(142, 223);
            this.comboBox_scopeC1.Name = "comboBox_scopeC1";
            this.comboBox_scopeC1.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeC1.TabIndex = 16;
            this.comboBox_scopeC1.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeC012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeC0
            // 
            this.comboBox_scopeC0.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeC0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeC0.ForeColor = System.Drawing.Color.Lime;
            this.comboBox_scopeC0.FormattingEnabled = true;
            this.comboBox_scopeC0.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeC0.Location = new System.Drawing.Point(95, 223);
            this.comboBox_scopeC0.Name = "comboBox_scopeC0";
            this.comboBox_scopeC0.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeC0.TabIndex = 15;
            this.comboBox_scopeC0.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeC012trig_SelectedIndexChanged);
            // 
            // label_scopeD
            // 
            this.label_scopeD.AutoSize = true;
            this.label_scopeD.Location = new System.Drawing.Point(12, 253);
            this.label_scopeD.Name = "label_scopeD";
            this.label_scopeD.Size = new System.Drawing.Size(52, 13);
            this.label_scopeD.TabIndex = 59;
            this.label_scopeD.Text = "Scope D:";
            // 
            // comboBox_scopeD2
            // 
            this.comboBox_scopeD2.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeD2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeD2.ForeColor = System.Drawing.Color.Yellow;
            this.comboBox_scopeD2.FormattingEnabled = true;
            this.comboBox_scopeD2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeD2.Location = new System.Drawing.Point(189, 250);
            this.comboBox_scopeD2.Name = "comboBox_scopeD2";
            this.comboBox_scopeD2.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeD2.TabIndex = 21;
            this.comboBox_scopeD2.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeD012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeD1
            // 
            this.comboBox_scopeD1.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeD1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeD1.ForeColor = System.Drawing.Color.Fuchsia;
            this.comboBox_scopeD1.FormattingEnabled = true;
            this.comboBox_scopeD1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeD1.Location = new System.Drawing.Point(142, 250);
            this.comboBox_scopeD1.Name = "comboBox_scopeD1";
            this.comboBox_scopeD1.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeD1.TabIndex = 20;
            this.comboBox_scopeD1.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeD012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeD0
            // 
            this.comboBox_scopeD0.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeD0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeD0.ForeColor = System.Drawing.Color.Lime;
            this.comboBox_scopeD0.FormattingEnabled = true;
            this.comboBox_scopeD0.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeD0.Location = new System.Drawing.Point(95, 250);
            this.comboBox_scopeD0.Name = "comboBox_scopeD0";
            this.comboBox_scopeD0.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeD0.TabIndex = 19;
            this.comboBox_scopeD0.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeD012trig_SelectedIndexChanged);
            // 
            // textBox_filename
            // 
            this.textBox_filename.Location = new System.Drawing.Point(96, 279);
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(80, 20);
            this.textBox_filename.TabIndex = 60;
            this.textBox_filename.Text = "DAQ32data";
            this.textBox_filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 282);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 61;
            this.label13.Text = "File name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(182, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 62;
            this.label14.Text = ".csv";
            // 
            // button_startLog
            // 
            this.button_startLog.Location = new System.Drawing.Point(215, 277);
            this.button_startLog.Name = "button_startLog";
            this.button_startLog.Size = new System.Drawing.Size(69, 23);
            this.button_startLog.TabIndex = 64;
            this.button_startLog.Text = "Start Log";
            this.button_startLog.UseVisualStyleBackColor = true;
            this.button_startLog.Click += new System.EventHandler(this.button_startLog_Click);
            // 
            // comboBox_scopeDtrig
            // 
            this.comboBox_scopeDtrig.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeDtrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeDtrig.ForeColor = System.Drawing.Color.Red;
            this.comboBox_scopeDtrig.FormattingEnabled = true;
            this.comboBox_scopeDtrig.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeDtrig.Location = new System.Drawing.Point(236, 250);
            this.comboBox_scopeDtrig.Name = "comboBox_scopeDtrig";
            this.comboBox_scopeDtrig.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeDtrig.TabIndex = 68;
            this.comboBox_scopeDtrig.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeD012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeCtrig
            // 
            this.comboBox_scopeCtrig.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeCtrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeCtrig.ForeColor = System.Drawing.Color.Red;
            this.comboBox_scopeCtrig.FormattingEnabled = true;
            this.comboBox_scopeCtrig.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeCtrig.Location = new System.Drawing.Point(236, 223);
            this.comboBox_scopeCtrig.Name = "comboBox_scopeCtrig";
            this.comboBox_scopeCtrig.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeCtrig.TabIndex = 67;
            this.comboBox_scopeCtrig.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeC012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeBtrig
            // 
            this.comboBox_scopeBtrig.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeBtrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeBtrig.ForeColor = System.Drawing.Color.Red;
            this.comboBox_scopeBtrig.FormattingEnabled = true;
            this.comboBox_scopeBtrig.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeBtrig.Location = new System.Drawing.Point(236, 196);
            this.comboBox_scopeBtrig.Name = "comboBox_scopeBtrig";
            this.comboBox_scopeBtrig.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeBtrig.TabIndex = 66;
            this.comboBox_scopeBtrig.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeB012trig_SelectedIndexChanged);
            // 
            // comboBox_scopeAtrig
            // 
            this.comboBox_scopeAtrig.BackColor = System.Drawing.Color.Black;
            this.comboBox_scopeAtrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scopeAtrig.ForeColor = System.Drawing.Color.Red;
            this.comboBox_scopeAtrig.FormattingEnabled = true;
            this.comboBox_scopeAtrig.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_scopeAtrig.Location = new System.Drawing.Point(236, 169);
            this.comboBox_scopeAtrig.Name = "comboBox_scopeAtrig";
            this.comboBox_scopeAtrig.Size = new System.Drawing.Size(41, 21);
            this.comboBox_scopeAtrig.TabIndex = 65;
            this.comboBox_scopeAtrig.SelectedIndexChanged += new System.EventHandler(this.comboBox_scopeA012trig_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 314);
            this.Controls.Add(this.comboBox_scopeDtrig);
            this.Controls.Add(this.comboBox_scopeCtrig);
            this.Controls.Add(this.comboBox_scopeBtrig);
            this.Controls.Add(this.comboBox_scopeAtrig);
            this.Controls.Add(this.button_startLog);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox_filename);
            this.Controls.Add(this.label_scopeD);
            this.Controls.Add(this.comboBox_scopeD2);
            this.Controls.Add(this.comboBox_scopeD1);
            this.Controls.Add(this.comboBox_scopeD0);
            this.Controls.Add(this.label_scopeC);
            this.Controls.Add(this.comboBox_scopeC2);
            this.Controls.Add(this.comboBox_scopeC1);
            this.Controls.Add(this.comboBox_scopeC0);
            this.Controls.Add(this.label_scopeB);
            this.Controls.Add(this.comboBox_scopeB2);
            this.Controls.Add(this.comboBox_scopeB1);
            this.Controls.Add(this.comboBox_scopeB0);
            this.Controls.Add(this.label_scopeA);
            this.Controls.Add(this.comboBox_scopeA2);
            this.Controls.Add(this.comboBox_scopeA1);
            this.Controls.Add(this.comboBox_scopeA0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_samplePeriod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_packets);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_errors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_samplerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_channels);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_COM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DAQ32 PC Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_packets;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.TextBox textBox_errors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_samplerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_channels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_COM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_samplePeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_scopeA0;
        private System.Windows.Forms.ComboBox comboBox_scopeA1;
        private System.Windows.Forms.ComboBox comboBox_scopeA2;
        private System.Windows.Forms.Label label_scopeA;
        private System.Windows.Forms.Label label_scopeB;
        private System.Windows.Forms.ComboBox comboBox_scopeB2;
        private System.Windows.Forms.ComboBox comboBox_scopeB1;
        private System.Windows.Forms.ComboBox comboBox_scopeB0;
        private System.Windows.Forms.Label label_scopeC;
        private System.Windows.Forms.ComboBox comboBox_scopeC2;
        private System.Windows.Forms.ComboBox comboBox_scopeC1;
        private System.Windows.Forms.ComboBox comboBox_scopeC0;
        private System.Windows.Forms.Label label_scopeD;
        private System.Windows.Forms.ComboBox comboBox_scopeD2;
        private System.Windows.Forms.ComboBox comboBox_scopeD1;
        private System.Windows.Forms.ComboBox comboBox_scopeD0;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_startLog;
        private System.Windows.Forms.ComboBox comboBox_scopeDtrig;
        private System.Windows.Forms.ComboBox comboBox_scopeCtrig;
        private System.Windows.Forms.ComboBox comboBox_scopeBtrig;
        private System.Windows.Forms.ComboBox comboBox_scopeAtrig;

    }
}

