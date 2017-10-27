using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemeryAllocation.Properties;
using System.Threading;

namespace MemeryAllocation
{
    public partial class MemeryAllocation : Form
    {
        Memery MemManage = new Memery();
        int Total = 0, Fail = 0;//执行总次数和缺页次数
        double rate;//缺页率
        int rdNum;//用于表示生成的随机数
        int rdFlag = 0;//标志下一步随机数如何取值
        Random rd = new Random();//生成随机数
        TimerRunner timer = new TimerRunner();//定义计时器实例

        //向listView输出日志
        public static void ShowInfo(System.Windows.Forms.TextBox txtInfo, string Info)
        {
            txtInfo.AppendText(Info);
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.ScrollToCaret();
        }

        //更改窗体显示的每个内存块储存页号,labelNum表示应该存入的内存块的编号,pageNum表示存入内存块的页的编号
        public void ChangePageLabel(int labelNum, int pageNum)
        {
            if (labelNum == 1)
            {
                pageLabel1.Text = pageNum.ToString();
            }
            else if (labelNum == 2)
            {
                pageLabel2.Text = pageNum.ToString();
            }
            else if (labelNum == 3)
            {
                pageLabel3.Text = pageNum.ToString();
            }
            else if (labelNum == 4)
            {
                pageLabel4.Text = pageNum.ToString();
            }
        }

        //主要的处理函数
        public void Process(int num)
        {
            Total += 1;
            label7.Text = Total.ToString();
            int pageNum = MemManage.GetPageNum(num);
            //检查当前读入的指令是否在内存中
            //不在内存中则缺页，分配页面至内存块，同时更新窗体内的显示
            if (MemManage.IsPageInMem(pageNum) == false)
            {
                Fail += 1;
                int labelNum = MemManage.AllocateMem(pageNum);
                listView1.Items.Add(num + "号发生缺页");
                listView1.EnsureVisible(Total - 1);
                ChangePageLabel(labelNum, pageNum);
            }
            //在内存中则读取下一条
            else
            {
                listView1.Items.Add(num + "号读取成功");
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            //通过求rdFlag%4的值来决定下一条指令的位置，0和2为下一条指令，1为前面的指令，3为后面的指令
            if (rdFlag % 4 == 0 || rdFlag % 4 == 2)
            {
                rdNum += 1;
                Process(rdNum);
            }
            if (rdFlag % 4 == 1)
            {
                rdNum = rd.Next(0, rdFlag);
                Process(rdNum);
            }
            if (rdFlag % 4 == 3)
            {
                rdNum = rd.Next(rdFlag, 319);
                Process(rdNum);
            }
            rdFlag += 1;
            if (Total == 320)
            {
                timer.TimerStop();
                rate = (double)Fail / Total;
                button2.Enabled = true;
                MessageBox.Show("缺页率为" + rate * 100 + "%");
            }
        }

        public MemeryAllocation()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            timer.time.Tick += Time_Tick;
        }

        //按下开始按钮，计时器开始运行
        private void button1_Click(object sender, EventArgs e)
        {
            rdNum = rd.Next(0, 319);
            Process(rdNum);
            timer.time.Start();
            timer.time.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        //按下重置按钮，计时器停止，Memery实例重置，窗体内的文字初始化
        private void button2_Click(object sender, EventArgs e)
        {
            Total = 0;
            Fail = 0;
            rdFlag = 0;
            MemManage.reset();
            button1.Enabled = true;
            label7.Text = "N/A";
            pageLabel1.Text = "无";
            pageLabel2.Text = "无";
            pageLabel3.Text = "无";
            pageLabel4.Text = "无";
            listView1.Clear();
        }
    }
}
