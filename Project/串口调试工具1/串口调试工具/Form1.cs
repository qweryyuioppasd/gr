using System.IO.Ports;
using System.Text.RegularExpressions;//正则表达式，加入命名空间。
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口调试工具
{
    public partial class Form1 : Form
    {
        SerialPort sp = null;
        bool isOpen = false;
        bool isSetProperty = false;
        private bool numericUpDown1_Value;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            for (int i = 0; i < 20; i++)
            {
                cbxCOMPort.Items.Add("COM" + (i + 1).ToString());
            }
            cbxCOMPort.SelectedIndex = 0;

            cbxBaudRate.Items.Add("1200");
            cbxBaudRate.Items.Add("2400");
            cbxBaudRate.Items.Add("4800");
            cbxBaudRate.Items.Add("9600");
            cbxBaudRate.Items.Add("19200");
            cbxBaudRate.Items.Add("38400");
            cbxBaudRate.Items.Add("115200");
            cbxBaudRate.SelectedIndex = 6;

            cbxStopBits.Items.Add("0");
            cbxStopBits.Items.Add("1");
            cbxStopBits.Items.Add("1.5");
            cbxStopBits.Items.Add("2");
            cbxStopBits.SelectedIndex = 1;

            cbxParity.Items.Add("无");
            cbxParity.Items.Add("奇");
            cbxParity.Items.Add("偶");
            cbxParity.SelectedIndex = 0;

            cbxDataBits.Items.Add("8");
            cbxDataBits.Items.Add("7");
            cbxDataBits.Items.Add("6");
            cbxDataBits.Items.Add("5");
            cbxDataBits.SelectedIndex = 0;

            rbnChar.Checked = true;
            /*添加时间显示*/
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_0(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!numericUpDown1_Value)
            {
                tbxRecvData.Text = "";
                tbxSendData.Text = "";
            }
            else
            {
                MessageBox.Show("请先关闭自动发送", "错误提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] textchar = new byte[1];
            int num2 = 0;
            if (isOpen)
            {
                try
                {
                    if (!checkBox1.Checked)//如果没有选中十六进制发送
                    {
                        if (!checkBox2.Checked)//未选中回车换行
                        {
                            sp.Write(tbxSendData.Text);//串口发送 （发送框里的东西）
                        }
                        else
                        {
                            sp.WriteLine(tbxSendData.Text);
                        }
                    }
                    else//选择十六进制发送的时候
                    {

                        string buf = tbxSendData.Text;
                        string bartenm = @"\s";//正则表达式
                        string replace = "";

                        Regex rgx = new Regex(bartenm);
                        string senddata = rgx.Replace(buf, replace);
                        num2 = (senddata.Length - senddata.Length % 2) / 2;

                        for (int a = 0; a < num2; a++)
                        {
                            textchar[0] = Convert.ToByte(senddata.Substring(a * 2, 2), 16);
                            sp.Write(textchar, 0, 1);
                        }


                        if (senddata.Length % 2 != 0)
                        {
                            textchar[0] = Convert.ToByte(senddata.Substring(tbxSendData.Text.Length - 1, 2), 16);
                            sp.Write(textchar, 0, 1);
                            num2++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示");
                    return;
                }
            }
            else
            {
                MessageBox.Show("串口未打开错误提示！", "错误提示");
            }
            if (!CheckSendData())
            {
                MessageBox.Show("请输入要发送的数据", "错误提示");
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                if (!CheckPortSetting())
                {
                    MessageBox.Show("串口未设置", "错误提示");
                    return;
                }
                if (!isSetProperty)
                {
                    SetProperty();
                    isSetProperty = true;
                }
                try
                {
                    sp.Open();
                    isOpen = true;
                    btnOpenCom.Text = "关闭串口";
                    cbxCOMPort.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    cbxDataBits.Enabled = false;
                    cbxParity.Enabled = false;
                    cbxStopBits.Enabled = false;
                    rbnChar.Enabled = false;
                    rbnHex.Enabled = false;
                }
                catch (Exception)
                {
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用", "错误提示");
                }
            }
            else if (isOpen == true)
            {

                try
                {
                    if (!numericUpDown1_Value)
                    {
                        sp.Close();//关闭端口
                        isOpen = false;
                        btnOpenCom.Text = "打开串口";
                        cbxCOMPort.Enabled = true;
                        cbxBaudRate.Enabled = true;
                        cbxDataBits.Enabled = true;
                        cbxParity.Enabled = true;
                        cbxStopBits.Enabled = true;
                        rbnChar.Enabled = true;
                        rbnHex.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请先关闭自动发送", "错误提示");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("关闭串口时发生错误", "错误提示");
                }
            }
        }

        private void btnCheckCom_Click(object sender, EventArgs e)
        {
            bool comExistence = false;
            cbxCOMPort.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    sp.Close();
                    cbxCOMPort.Items.Add("COM" + (i + 1).ToString());
                    comExistence = true;
                }

                catch (Exception)
                {
                    continue;
                }
            }
            if (comExistence)
            {
                cbxCOMPort.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("没有找到可用串口！", "错误提示！");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer txTimer = new System.Windows.Forms.Timer();

            if (numericUpDown1_Value)
            {
                if (CheckedChanged.Value != 0)
                {
                    if (CheckSendData())
                    {
                        txTimer.Enabled = false;
                        timer2.Interval = (int)CheckedChanged.Value; //定时器赋初值  
                        timer2.Start();
                    }
                    else if (!CheckSendData())
                    {
                        timer2.Stop();
                    }
                }
                else if (CheckedChanged.Value == 0)
                {
                    timer2.Stop();
                }
            }
            else
            {
                txTimer.Enabled = true;
                timer2.Stop();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool CheckPortSetting()
        {
            if (cbxCOMPort.Text.Trim() == "") return false;
            if (cbxBaudRate.Text.Trim() == "") return false;
            if (cbxStopBits.Text.Trim() == "") return false;
            if (cbxParity.Text.Trim() == "") return false;
            if (cbxDataBits.Text.Trim() == "") return false;
            return true;
        }

        private bool CheckSendData()
        {
            if (tbxSendData.Text.Trim() == "") return false;
            return true;
        }




        private void SetProperty()
        {
            sp = new SerialPort();
            sp.PortName = cbxCOMPort.Text.Trim();
            sp.BaudRate = Convert.ToInt32(cbxBaudRate.Text.Trim());
            if (cbxStopBits.Text.Trim() == "0")
            {
                sp.StopBits = StopBits.None;
            }
            else if (cbxStopBits.Text.Trim() == "1.5")
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (cbxStopBits.Text.Trim() == "2")
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }

            sp.DataBits = Convert.ToInt16(cbxDataBits.Text.Trim());

            if (cbxParity.Text.Trim() == "奇校验")
            {
                sp.Parity = Parity.Odd;

            }
            else if (cbxParity.Text.Trim() == "偶校验")
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }
            sp.ReadTimeout = -1;
            sp.RtsEnable = true;

            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs eg)
        {

            System.Threading.Thread.Sleep(100);

            this.Invoke((EventHandler)delegate//异步执行 一个线程
            {
                if (!rbnHex.Checked)//如果未选中name为rbnHex的控件
                {
                    //tbxRecvData.Text += sp.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    long rec_count = 0;
                    int num = sp.BytesToRead;
                    byte[] recbuf = new byte[num];
                    rec_count += num;

                    sp.Read(recbuf, 0, num);
                    sb.Clear();

                    try
                    {
                        Invoke((EventHandler)(delegate
                        {
                            sb.Append(Encoding.ASCII.GetString(recbuf));  //将整个数组解码为ASCII数组
                            tbxRecvData.AppendText(sb.ToString());
                        }
                        )
                        );
                    }

                    catch
                    {
                        MessageBox.Show("请勾选换行", "错误提示");
                    }
                }
                else if (rbnHex.Checked)//如果选中
                {
                    Byte[] ReceivedData = new Byte[sp.BytesToRead];
                    sp.Read(ReceivedData, 0, ReceivedData.Length);
                    String RecvDataText = null;
                    /*
                     for (int i = 0; i < ReceivedData.Length; i++)
                    {
                        RecvDataText += (ReceivedData[i].ToString("X2") + " ");//数组里接收到的数据转化为16进制
                    }
                    tbxRecvData.Text += RecvDataText;
                    sp.DiscardInBuffer();
                    */
                    if (ReceivedData.Length > 0)
                        if (ReceivedData[6] ==0x01)
                    {
                        byte[] textchar = new byte[1];
                        int num2 = 0;
                        if (isOpen)
                        {
                            try
                            {
                                if (!checkBox1.Checked)//如果没有选中十六进制发送
                                {
                                    if (!checkBox2.Checked)//未选中回车换行
                                    {
                                        sp.Write(tbxSendData.Text);//串口发送 （发送框里的东西）
                                    }
                                    else
                                    {

                                    }
                                    {
                                        sp.WriteLine(tbxSendData.Text);
                                    }
                                }
                                else//选择十六进制发送的时候
                                {

                                    string buf = tbxSendData.Text;
                                    string bartenm = @"\s";//正则表达式
                                    string replace = "";

                                    Regex rgx = new Regex(bartenm);
                                    string senddata = rgx.Replace(buf, replace);
                                    num2 = (senddata.Length - senddata.Length % 2) / 2;

                                    for (int a = 0; a < num2; a++)
                                    {
                                        textchar[0] = Convert.ToByte(senddata.Substring(a * 2, 2), 16);
                                        sp.Write(textchar, 0, 1);
                                    }


                                    if (senddata.Length % 2 != 0)
                                    {
                                        textchar[0] = Convert.ToByte(senddata.Substring(tbxSendData.Text.Length - 1, 2), 16);
                                        sp.Write(textchar, 0, 1);
                                        num2++;
                                    }
                                }
                            }
                            catch
                            {
                                //MessageBox.Show("发送数据时发生错误！", "错误提示");
                                return;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("串口未打开错误提示！", "错误提示");
                        }
                        if (!CheckSendData())
                        {
                            //MessageBox.Show("请输入要发送的数据", "错误提示");
                        }
                    }
                }
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbxStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.toolStripStatusLabel1.Text = "当前时间" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //btnSendData_Click(btnSendData, new EventArgs());
        }

        private void statusStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tbxSendData_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbnHex_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}