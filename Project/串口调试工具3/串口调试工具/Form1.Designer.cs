namespace 串口调试工具
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.btnCheckCom = new System.Windows.Forms.Button();
            this.rbnHex = new System.Windows.Forms.RadioButton();
            this.rbnChar = new System.Windows.Forms.RadioButton();
            this.n = new System.Windows.Forms.Label();
            this.cbxStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCOMPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.CheckedChanged = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxRecvData = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbxSendData = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckedChanged)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxParity);
            this.groupBox1.Controls.Add(this.btnOpenCom);
            this.groupBox1.Controls.Add(this.btnCheckCom);
            this.groupBox1.Controls.Add(this.rbnHex);
            this.groupBox1.Controls.Add(this.rbnChar);
            this.groupBox1.Controls.Add(this.n);
            this.groupBox1.Controls.Add(this.cbxStopBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxDataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxCOMPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbxParity
            // 
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Location = new System.Drawing.Point(80, 210);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(151, 28);
            this.cbxParity.TabIndex = 14;
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(149, 318);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(94, 29);
            this.btnOpenCom.TabIndex = 13;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // btnCheckCom
            // 
            this.btnCheckCom.Location = new System.Drawing.Point(20, 318);
            this.btnCheckCom.Name = "btnCheckCom";
            this.btnCheckCom.Size = new System.Drawing.Size(94, 29);
            this.btnCheckCom.TabIndex = 12;
            this.btnCheckCom.Text = "检测串口";
            this.btnCheckCom.UseVisualStyleBackColor = true;
            this.btnCheckCom.Click += new System.EventHandler(this.btnCheckCom_Click);
            // 
            // rbnHex
            // 
            this.rbnHex.AutoSize = true;
            this.rbnHex.Location = new System.Drawing.Point(141, 273);
            this.rbnHex.Name = "rbnHex";
            this.rbnHex.Size = new System.Drawing.Size(90, 24);
            this.rbnHex.TabIndex = 11;
            this.rbnHex.Text = "HEX显示";
            this.rbnHex.UseVisualStyleBackColor = true;
            this.rbnHex.CheckedChanged += new System.EventHandler(this.rbnHex_CheckedChanged);
            // 
            // rbnChar
            // 
            this.rbnChar.AutoSize = true;
            this.rbnChar.Checked = true;
            this.rbnChar.Location = new System.Drawing.Point(20, 273);
            this.rbnChar.Name = "rbnChar";
            this.rbnChar.Size = new System.Drawing.Size(90, 24);
            this.rbnChar.TabIndex = 10;
            this.rbnChar.TabStop = true;
            this.rbnChar.Text = "字符显示";
            this.rbnChar.UseVisualStyleBackColor = true;
            // 
            // n
            // 
            this.n.AutoSize = true;
            this.n.Location = new System.Drawing.Point(6, 210);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(69, 20);
            this.n.TabIndex = 8;
            this.n.Text = "奇偶校验";
            // 
            // cbxStopBits
            // 
            this.cbxStopBits.FormattingEnabled = true;
            this.cbxStopBits.Location = new System.Drawing.Point(80, 165);
            this.cbxStopBits.Name = "cbxStopBits";
            this.cbxStopBits.Size = new System.Drawing.Size(151, 28);
            this.cbxStopBits.TabIndex = 7;
            this.cbxStopBits.SelectedIndexChanged += new System.EventHandler(this.cbxStopBits_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "停止位";
            // 
            // cbxDataBits
            // 
            this.cbxDataBits.FormattingEnabled = true;
            this.cbxDataBits.Location = new System.Drawing.Point(80, 120);
            this.cbxDataBits.Name = "cbxDataBits";
            this.cbxDataBits.Size = new System.Drawing.Size(151, 28);
            this.cbxDataBits.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Location = new System.Drawing.Point(80, 78);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(151, 28);
            this.cbxBaudRate.TabIndex = 3;
            this.cbxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // cbxCOMPort
            // 
            this.cbxCOMPort.FormattingEnabled = true;
            this.cbxCOMPort.Location = new System.Drawing.Point(80, 32);
            this.cbxCOMPort.Name = "cbxCOMPort";
            this.cbxCOMPort.Size = new System.Drawing.Size(151, 28);
            this.cbxCOMPort.TabIndex = 1;
            this.cbxCOMPort.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(24, 559);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(94, 29);
            this.btnClearData.TabIndex = 1;
            this.btnClearData.Text = "清空数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(161, 559);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(94, 29);
            this.btnSendData.TabIndex = 2;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(152, 29);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 24);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "回车换行";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "HEX发送";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.CheckedChanged);
            this.groupBox3.Location = new System.Drawing.Point(12, 464);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 70);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(152, 26);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 24);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "自动发送";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // CheckedChanged
            // 
            this.CheckedChanged.Location = new System.Drawing.Point(15, 26);
            this.CheckedChanged.Name = "CheckedChanged";
            this.CheckedChanged.Size = new System.Drawing.Size(94, 27);
            this.CheckedChanged.TabIndex = 7;
            this.CheckedChanged.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxRecvData);
            this.groupBox4.Location = new System.Drawing.Point(342, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 409);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收数据";
            // 
            // tbxRecvData
            // 
            this.tbxRecvData.Location = new System.Drawing.Point(16, 26);
            this.tbxRecvData.Multiline = true;
            this.tbxRecvData.Name = "tbxRecvData";
            this.tbxRecvData.ReadOnly = true;
            this.tbxRecvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxRecvData.Size = new System.Drawing.Size(424, 362);
            this.tbxRecvData.TabIndex = 0;
            this.tbxRecvData.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbxSendData);
            this.groupBox5.Location = new System.Drawing.Point(342, 450);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 138);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送数据";
            // 
            // tbxSendData
            // 
            this.tbxSendData.Location = new System.Drawing.Point(21, 36);
            this.tbxSendData.Multiline = true;
            this.tbxSendData.Name = "tbxSendData";
            this.tbxSendData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSendData.Size = new System.Drawing.Size(419, 81);
            this.tbxSendData.TabIndex = 0;
            this.tbxSendData.TextChanged += new System.EventHandler(this.tbxSendData_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 603);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(830, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked_2);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSendData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 625);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "串口调试工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckedChanged)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cbxCOMPort;
        private ComboBox cbxBaudRate;
        private Label label2;
        private Label label3;
        private RadioButton rbnHex;
        private RadioButton rbnChar;
        private Label n;
        private ComboBox cbxStopBits;
        private Label label4;
        private ComboBox cbxDataBits;
        private Button btnOpenCom;
        private Button btnCheckCom;
        private Button btnClearData;
        private Button btnSendData;
        private GroupBox groupBox2;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox3;
        private NumericUpDown CheckedChanged;
        private CheckBox checkBox3;
        private GroupBox groupBox4;
        private TextBox tbxRecvData;
        private GroupBox groupBox5;
        private TextBox tbxSendData;
        private StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private ComboBox cbxParity;
    }
}