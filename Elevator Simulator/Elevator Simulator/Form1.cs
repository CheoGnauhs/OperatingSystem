using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Elevator_Simulator.Properties;

namespace Elevator_Simulator
{
    public partial class Form1 : Form
    {
        //构建五个电梯实例
        Elevator elev1 = new Elevator();
        Elevator elev2 = new Elevator();
        Elevator elev3 = new Elevator();
        Elevator elev4 = new Elevator();
        Elevator elev5 = new Elevator();

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //初始化界面并使电梯运行
        private void Form1_Load(object sender, EventArgs e)
        {
            E1_Floor.Text = elev1.curFloor.ToString();
            E1_Status.Text = elev1.curStatus.ToString();
            E2_Floor.Text = elev1.curFloor.ToString();
            E2_Status.Text = elev1.curStatus.ToString();
            E3_Floor.Text = elev1.curFloor.ToString();
            E3_Status.Text = elev1.curStatus.ToString();
            E4_Floor.Text = elev1.curFloor.ToString();
            E4_Status.Text = elev1.curStatus.ToString();
            E5_Floor.Text = elev1.curFloor.ToString();
            E5_Status.Text = elev1.curStatus.ToString();
            ElevMove();
        }

        //开启电梯运行线程
        public void ElevMove()
        {
            //开设五个计时器来表示五个电梯
            System.Timers.Timer timer1 = new System.Timers.Timer();
            timer1.Elapsed += new ElapsedEventHandler(Elev1FloorChange);
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Enabled = true;

            System.Timers.Timer timer2 = new System.Timers.Timer();
            timer2.Elapsed += new ElapsedEventHandler(Elev2FloorChange);
            timer2.Interval = 1000;
            timer2.Start();
            timer2.Enabled = true;

            System.Timers.Timer timer3 = new System.Timers.Timer();
            timer3.Elapsed += new ElapsedEventHandler(Elev3FloorChange);
            timer3.Interval = 1000;
            timer3.Start();
            timer3.Enabled = true;

            System.Timers.Timer timer4 = new System.Timers.Timer();
            timer4.Elapsed += new ElapsedEventHandler(Elev4FloorChange);
            timer4.Interval = 1000;
            timer4.Start();
            timer4.Enabled = true;

            System.Timers.Timer timer5 = new System.Timers.Timer();
            timer5.Elapsed += new ElapsedEventHandler(Elev5FloorChange);
            timer5.Interval = 1000;
            timer5.Start();
            timer5.Enabled = true;
        }

        //电梯1运行函数
        public void Elev1FloorChange(object source, ElapsedEventArgs e)
        {
            Console.Write("No.1 works good!\n");
            //警报开启时，电梯不能运行
            if (elev1.alarmOn == true)
            {
                E1_Status.Text = "Alarm";
            }
            //警报未开启时正常运行
            else if (elev1.alarmOn == false)
            {
                //找到要去的楼层
                int tarFloor = 0;
                while (true)
                {
                    if (tarFloor == 20)
                        break;
                    if (elev1.tarUpFloor[tarFloor] == true)
                        break;
                    tarFloor++;
                }
                //实际要去的楼层为tarFloor+1
                tarFloor += 1;
                //处于停下或者上升状态时优先找上升的楼层
                if (tarFloor != 21 && (elev1.curStatus == StatusEnum.Stop || elev1.curStatus == StatusEnum.Up))
                {
                    //改变图形界面中的目标楼层显示
                    E1_Target.Text = tarFloor.ToString();
                    if (tarFloor != 21)
                        elev1.getTarFloor = false;
                    //未到达目的地时电梯楼层改变，状态相应改变
                    if (elev1.curFloor != tarFloor && elev1.getTarFloor == false)
                    {
                        E1_Floor.Text = (elev1.curFloor += 1).ToString();
                        elev1.curStatus = StatusEnum.Up;
                        E1_Status.Text = elev1.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev1.curFloor == tarFloor)
                    {
                        elev1.curStatus = StatusEnum.Stop;
                        elev1.getTarFloor = true;
                        elev1.tarUpFloor[tarFloor - 1] = false;
                        E1_Status.Text = elev1.curStatus.ToString();
                    }
                }
                //上升为空则找下降的楼层
                else if (tarFloor == 21 || elev1.curStatus == StatusEnum.Down)
                {
                    tarFloor = 19;
                    while (true)
                    {
                        if (tarFloor == -1)
                            break;
                        if (elev1.tarDownFloor[tarFloor] == true)
                            break;
                        tarFloor--;
                    }
                    tarFloor += 1;
                    //改变图形界面中的目标楼层显示
                    if (tarFloor == 0)
                        E1_Target.Text = "无";
                    else
                        E1_Target.Text = tarFloor.ToString();
                    //未到达目的地时电梯楼层改变，状态改变
                    if (tarFloor != 0)
                        elev1.getTarFloor = false;
                    if (elev1.curFloor != tarFloor && elev1.getTarFloor == false)
                    {
                        E1_Floor.Text = (elev1.curFloor -= 1).ToString();
                        elev1.curStatus = StatusEnum.Down;
                        E1_Status.Text = elev1.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev1.curFloor == tarFloor)
                    {
                        elev1.curStatus = StatusEnum.Stop;
                        elev1.getTarFloor = true;
                        elev1.tarDownFloor[tarFloor - 1] = false;
                        E1_Status.Text = elev1.curStatus.ToString();
                    }
                }
            }
        }

        //电梯2运行函数
        public void Elev2FloorChange(object source, ElapsedEventArgs e)
        {
            Console.Write("No.2 works good!\n");
            /*
            Console.Write("      " + elev2.alarmOn + " ");
            */
            //警报开启时，电梯不能运行
            if (elev2.alarmOn == true)
            {
                E2_Status.Text = "Alarm";
            }
            //警报未开启时正常运行
            else if (elev2.alarmOn == false)
            {
                int tarFloor = 0;//找到要去的楼层
                while (true)
                {
                    if (tarFloor == 20)
                        break;
                    if (elev2.tarUpFloor[tarFloor] == true)
                        break;
                    tarFloor++;
                }
                //实际要去的楼层为tarFloor+1
                tarFloor += 1;
                //处于停下或者上升状态时优先找上升的楼层
                if (tarFloor != 21 && (elev2.curStatus == StatusEnum.Stop || elev2.curStatus == StatusEnum.Up))
                {
                    /*
                    Console.Write(elev2.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev2.getTarFloor);
                    */
                    E2_Target.Text = tarFloor.ToString();
                    if (tarFloor != 21)
                        elev2.getTarFloor = false;
                    //未到达目的地时电梯楼层改变，状态改变
                    if (elev2.curFloor != tarFloor && elev2.getTarFloor == false)
                    {
                        E2_Floor.Text = (elev2.curFloor += 1).ToString();
                        elev2.curStatus = StatusEnum.Up;
                        E2_Status.Text = elev2.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev2.curFloor == tarFloor)
                    {
                        elev2.curStatus = StatusEnum.Stop;
                        elev2.getTarFloor = true;
                        elev2.tarUpFloor[tarFloor - 1] = false;
                        E2_Status.Text = elev2.curStatus.ToString();
                    }
                }
                //上升为空则找下降的楼层
                else if (tarFloor == 21 || elev2.curStatus == StatusEnum.Down)
                {
                    tarFloor = 19;
                    while (true)
                    {
                        if (tarFloor == -1)
                            break;
                        if (elev2.tarDownFloor[tarFloor] == true)
                            break;
                        tarFloor--;
                    }
                    tarFloor += 1;
                    if (tarFloor == 0)
                        E2_Target.Text = "无";
                    else
                        E2_Target.Text = tarFloor.ToString();
                    /*
                    Console.Write(elev2.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev2.getTarFloor);
                    */
                    //未到达目的地时电梯楼层改变，状态改变
                    if (tarFloor != 0)
                        elev2.getTarFloor = false;
                    if (elev2.curFloor != tarFloor && elev2.getTarFloor == false)
                    {
                        E2_Floor.Text = (elev2.curFloor -= 1).ToString();
                        elev2.curStatus = StatusEnum.Down;
                        E2_Status.Text = elev2.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev2.curFloor == tarFloor)
                    {
                        elev2.curStatus = StatusEnum.Stop;
                        elev2.getTarFloor = true;
                        elev2.tarDownFloor[tarFloor - 1] = false;
                        E2_Status.Text = elev2.curStatus.ToString();
                    }
                }
            }
        }

        //电梯3运行函数
        public void Elev3FloorChange(object source, ElapsedEventArgs e)
        {
            Console.Write("No.3 works good!\n");
            /*
            Console.Write("      "+elev3.alarmOn+" ");
            */
            //警报开启时，电梯不能运行
            if (elev3.alarmOn == true)
            {
                E3_Status.Text = "Alarm";
            }
            //警报未开启时正常运行
            else if (elev3.alarmOn == false)
            {
                int tarFloor = 0;//找到要去的楼层
                while (true)
                {
                    if (tarFloor == 20)
                        break;
                    if (elev3.tarUpFloor[tarFloor] == true)
                        break;
                    tarFloor++;
                }
                //实际要去的楼层为tarFloor+1
                tarFloor += 1;
                //处于停下或者上升状态时优先找上升的楼层
                if (tarFloor != 21 && (elev3.curStatus == StatusEnum.Stop || elev3.curStatus == StatusEnum.Up))
                {
                    /*
                    Console.Write(elev3.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev3.getTarFloor);
                    */
                    E3_Target.Text = tarFloor.ToString();
                    if (tarFloor != 21)
                        elev3.getTarFloor = false;
                    //未到达目的地时电梯楼层改变，状态改变
                    if (elev3.curFloor != tarFloor && elev3.getTarFloor == false)
                    {
                        E3_Floor.Text = (elev3.curFloor += 1).ToString();
                        elev3.curStatus = StatusEnum.Up;
                        E3_Status.Text = elev3.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev3.curFloor == tarFloor)
                    {
                        elev3.curStatus = StatusEnum.Stop;
                        elev3.getTarFloor = true;
                        elev3.tarUpFloor[tarFloor - 1] = false;
                        E3_Status.Text = elev3.curStatus.ToString();
                    }
                }
                //上升为空则找下降的楼层
                else if (tarFloor == 21 || elev3.curStatus == StatusEnum.Down)
                {
                    tarFloor = 19;
                    while (true)
                    {
                        if (tarFloor == -1)
                            break;
                        if (elev3.tarDownFloor[tarFloor] == true)
                            break;
                        tarFloor--;
                    }
                    tarFloor += 1;
                    /*
                    Console.Write(elev3.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev3.getTarFloor);
                    */
                    if (tarFloor == 0)
                        E3_Target.Text = "无";
                    else
                        E3_Target.Text = tarFloor.ToString();
                    //未到达目的地时电梯楼层改变，状态改变
                    if (tarFloor != 0)
                        elev3.getTarFloor = false;
                    if (elev3.curFloor != tarFloor && elev3.getTarFloor == false)
                    {
                        E3_Floor.Text = (elev3.curFloor -= 1).ToString();
                        elev3.curStatus = StatusEnum.Down;
                        E3_Status.Text = elev3.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev3.curFloor == tarFloor)
                    {
                        elev3.curStatus = StatusEnum.Stop;
                        elev3.getTarFloor = true;
                        elev3.tarDownFloor[tarFloor - 1] = false;
                        E3_Status.Text = elev3.curStatus.ToString();
                    }
                }
            }
        }

        //电梯4运行函数
        public void Elev4FloorChange(object source, ElapsedEventArgs e)
        {
            Console.Write("No.4 works good!\n");
            /*
            Console.Write("      "+elev4.alarmOn+" ");
            */
            //警报开启时，电梯不能运行
            if (elev4.alarmOn == true)
            {
                E4_Status.Text = "Alarm";
            }
            //警报未开启时正常运行
            else if (elev4.alarmOn == false)
            {
                int tarFloor = 0;//找到要去的楼层
                while (true)
                {
                    if (tarFloor == 20)
                        break;
                    if (elev4.tarUpFloor[tarFloor] == true)
                        break;
                    tarFloor++;
                }
                //实际要去的楼层为tarFloor+1
                tarFloor += 1;
                //处于停下或者上升状态时优先找上升的楼层
                if (tarFloor != 21 && (elev4.curStatus == StatusEnum.Stop || elev4.curStatus == StatusEnum.Up))
                {
                    /*
                    Console.Write(elev4.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev4.getTarFloor);
                    */
                    E4_Target.Text = tarFloor.ToString();
                    if (tarFloor != 21)
                        elev4.getTarFloor = false;
                    //未到达目的地时电梯楼层改变，状态改变
                    if (elev4.curFloor != tarFloor && elev4.getTarFloor == false)
                    {
                        E4_Floor.Text = (elev4.curFloor += 1).ToString();
                        elev4.curStatus = StatusEnum.Up;
                        E4_Status.Text = elev4.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev4.curFloor == tarFloor)
                    {
                        elev4.curStatus = StatusEnum.Stop;
                        elev4.getTarFloor = true;
                        elev4.tarUpFloor[tarFloor - 1] = false;
                        E4_Status.Text = elev4.curStatus.ToString();
                    }
                }
                //上升为空则找下降的楼层
                else if (tarFloor == 21 || elev4.curStatus == StatusEnum.Down)
                {
                    tarFloor = 19;
                    while (true)
                    {
                        if (tarFloor == -1)
                            break;
                        if (elev4.tarDownFloor[tarFloor] == true)
                            break;
                        tarFloor--;
                    }
                    tarFloor += 1;
                    /*
                    Console.Write(elev4.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev4.getTarFloor);
                    */
                    if (tarFloor == 0)
                        E4_Target.Text = "无";
                    else
                        E4_Target.Text = tarFloor.ToString();
                    //未到达目的地时电梯楼层改变，状态改变
                    if (tarFloor != 0)
                        elev4.getTarFloor = false;
                    if (elev4.curFloor != tarFloor && elev4.getTarFloor == false)
                    {
                        E4_Floor.Text = (elev4.curFloor -= 1).ToString();
                        elev4.curStatus = StatusEnum.Down;
                        E4_Status.Text = elev4.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev4.curFloor == tarFloor)
                    {
                        elev4.curStatus = StatusEnum.Stop;
                        elev4.getTarFloor = true;
                        elev4.tarDownFloor[tarFloor - 1] = false;
                        E4_Status.Text = elev4.curStatus.ToString();
                    }
                }
            }
        }

        //电梯5运行函数
        public void Elev5FloorChange(object source, ElapsedEventArgs e)
        {
            Console.Write("No.4 works good!\n");
            /*
            Console.Write("      "+elev5.alarmOn+" ");
            */
            //警报开启时，电梯不能运行
            if (elev5.alarmOn == true)
            {
                E5_Status.Text = "Alarm";
            }
            //警报未开启时正常运行
            else if (elev5.alarmOn == false)
            {
                int tarFloor = 0;//找到要去的楼层
                while (true)
                {
                    if (tarFloor == 20)
                        break;
                    if (elev5.tarUpFloor[tarFloor] == true)
                        break;
                    tarFloor++;
                }
                //实际要去的楼层为tarFloor+1
                tarFloor += 1;
                //处于停下或者上升状态时优先找上升的楼层
                if (tarFloor != 21 && (elev5.curStatus == StatusEnum.Stop || elev5.curStatus == StatusEnum.Up))
                {
                    /*
                    Console.Write(elev5.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev5.getTarFloor);
                    */
                    E5_Target.Text = tarFloor.ToString();
                    if (tarFloor != 21)
                        elev5.getTarFloor = false;
                    //未到达目的地时电梯楼层改变，状态改变
                    if (elev5.curFloor != tarFloor && elev5.getTarFloor == false)
                    {
                        E5_Floor.Text = (elev5.curFloor += 1).ToString();
                        elev5.curStatus = StatusEnum.Up;
                        E5_Status.Text = elev5.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev5.curFloor == tarFloor)
                    {
                        elev5.curStatus = StatusEnum.Stop;
                        elev5.getTarFloor = true;
                        elev5.tarUpFloor[tarFloor - 1] = false;
                        E5_Status.Text = elev5.curStatus.ToString();
                    }
                }
                //上升为空则找下降的楼层
                else if (tarFloor == 21 || elev5.curStatus == StatusEnum.Down)
                {
                    tarFloor = 19;
                    while (true)
                    {
                        if (tarFloor == -1)
                            break;
                        if (elev5.tarDownFloor[tarFloor] == true)
                            break;
                        tarFloor--;
                    }
                    tarFloor += 1;
                    /*
                    Console.Write(elev5.curFloor + " ");
                    Console.Write(tarFloor + " ");
                    Console.Write(elev5.getTarFloor);
                    */
                    if (tarFloor == 0)
                        E5_Target.Text = "无";
                    else
                        E5_Target.Text = tarFloor.ToString();
                    //未到达目的地时电梯楼层改变，状态改变
                    if (tarFloor != 0)
                        elev5.getTarFloor = false;
                    if (elev5.curFloor != tarFloor && elev5.getTarFloor == false)
                    {
                        E5_Floor.Text = (elev5.curFloor -= 1).ToString();
                        elev5.curStatus = StatusEnum.Down;
                        E5_Status.Text = elev5.curStatus.ToString();
                    }
                    //到达目的地后电梯楼层不变，状态为stop
                    if (elev5.curFloor == tarFloor)
                    {
                        elev5.curStatus = StatusEnum.Stop;
                        elev5.getTarFloor = true;
                        elev5.tarDownFloor[tarFloor - 1] = false;
                        E5_Status.Text = elev5.curStatus.ToString();
                    }
                }
            }
        }

        //电梯调度函数
        public void ElevChoose(int tar, StatusEnum dir)
        {
            //比较各电梯与目标楼层间的距离
            int dis1 = System.Math.Abs(tar - elev1.curFloor);
            int dis2 = System.Math.Abs(tar - elev2.curFloor);
            int dis3 = System.Math.Abs(tar - elev3.curFloor);
            int dis4 = System.Math.Abs(tar - elev4.curFloor);
            int dis5 = System.Math.Abs(tar - elev5.curFloor);
            List<int> distance = new List<int>();
            distance.Add(dis1);
            distance.Add(dis2);
            distance.Add(dis3);
            distance.Add(dis4);
            distance.Add(dis5);
            //如果最近的电梯处于停止状态或运行方向与按键方向一致，则优先调用最近的电梯
            if (dis1 == distance.Min() && (elev1.curStatus == StatusEnum.Stop || (dir == elev1.curStatus)))
                elev1.AddTarFloor(tar);
            else if (dis2 == distance.Min() && (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus)))
                elev2.AddTarFloor(tar);
            else if (dis3 == distance.Min() && (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus)))
                elev3.AddTarFloor(tar);
            else if (dis4 == distance.Min() && (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus)))
                elev4.AddTarFloor(tar);
            else if (dis5 == distance.Min() && (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus)))
                elev5.AddTarFloor(tar);
            //如果最近的电梯不可用，则优先调用可用的电梯中序号最小的
            else if (elev1.curStatus == StatusEnum.Stop || (dir == elev1.curStatus))
                elev1.AddTarFloor(tar);
            else if (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus))
                elev2.AddTarFloor(tar);
            else if (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus))
                elev3.AddTarFloor(tar);
            else if (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus))
                elev4.AddTarFloor(tar);
            else if (elev2.curStatus == StatusEnum.Stop || (dir == elev2.curStatus))
                elev5.AddTarFloor(tar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        #region elevator1Buttons
        private void E1_1_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(1);
        }

        private void E1_2_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(2);
        }

        private void E1_3_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(3);
        }

        private void E1_4_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(4);
        }

        private void E1_5_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(5);
        }

        private void E1_6_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(6);
        }

        private void E1_7_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(7);
        }

        private void E1_8_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(8);
        }

        private void E1_9_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(9);
        }

        private void E1_10_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(10);
        }

        private void E1_11_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(11);
        }

        private void E1_12_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(12);
        }

        private void E1_13_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(13);
        }

        private void E1_14_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(14);
        }

        private void E1_15_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(15);
        }

        private void E1_16_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(16);
        }

        private void E1_17_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(17);
        }

        private void E1_18_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(18);
        }

        private void E1_19_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(19);
        }

        private void E1_20_Click(object sender, EventArgs e)
        {
            elev1.AddTarFloor(20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (elev1.alarmOn == false)
                elev1.alarmOn = true;
            else if (elev1.alarmOn == true)
                elev1.alarmOn = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region elevator2Buttons
        private void E2_1_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(1);
        }

        private void E2_2_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(2);
        }

        private void E2_3_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(3);
        }

        private void E2_4_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(4);
        }

        private void E2_5_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(5);
        }

        private void E2_6_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(6);
        }

        private void E2_7_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(7);
        }

        private void E2_8_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(8);
        }

        private void E2_9_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(9);
        }

        private void E2_10_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(10);
        }

        private void E2_11_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(11);
        }

        private void E2_12_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(12);
        }

        private void E2_13_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(13);
        }

        private void E2_14_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(14);
        }

        private void E2_15_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(15);
        }

        private void E2_16_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(16);
        }

        private void E2_17_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(17);
        }

        private void E2_18_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(18);
        }

        private void E2_19_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(19);
        }

        private void E2_20_Click(object sender, EventArgs e)
        {
            elev2.AddTarFloor(20);
        }

        private void E2_Alarm_Click(object sender, EventArgs e)
        {
            if (elev2.alarmOn == false)
                elev2.alarmOn = true;
            else if (elev2.alarmOn == true)
                elev2.alarmOn = false;
        }

        #endregion

        #region elevator3Buttons
        private void E3_1_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(1);
        }

        private void E3_2_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(2);
        }

        private void E3_3_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(3);
        }

        private void E3_4_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(4);
        }

        private void E3_5_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(5);
        }

        private void E3_6_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(6);
        }

        private void E3_7_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(7);
        }

        private void E3_8_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(8);
        }

        private void E3_9_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(9);
        }

        private void E3_10_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(10);
        }

        private void E3_11_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(11);
        }

        private void E3_12_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(12);
        }

        private void E3_13_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(13);
        }

        private void E3_14_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(14);
        }

        private void E3_15_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(15);
        }

        private void E3_16_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(16);
        }

        private void E3_17_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(17);
        }

        private void E3_18_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(18);
        }

        private void E3_19_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(19);
        }

        private void E3_20_Click(object sender, EventArgs e)
        {
            elev3.AddTarFloor(20);
        }

        private void E3_Alarm_Click(object sender, EventArgs e)
        {
            if (elev3.alarmOn == true)
                elev3.alarmOn = false;
            else if (elev3.alarmOn == false)
                elev3.alarmOn = true;
        }

        #endregion

        #region elevator4Buttons
        private void E4_1_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(1);
        }

        private void E4_2_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(2);
        }

        private void E4_3_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(3);
        }

        private void E4_4_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(4);
        }

        private void E4_5_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(5);
        }

        private void E4_6_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(6);
        }

        private void E4_7_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(7);
        }

        private void E4_8_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(8);
        }

        private void E4_9_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(9);
        }

        private void E4_10_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(10);
        }

        private void E4_11_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(11);
        }

        private void E4_12_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(12);
        }

        private void E4_13_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(13);
        }

        private void E4_14_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(14);
        }

        private void E4_15_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(15);
        }

        private void E4_16_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(16);
        }

        private void E4_17_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(17);
        }

        private void E4_18_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(18);
        }

        private void E4_19_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(19);
        }

        private void E4_20_Click(object sender, EventArgs e)
        {
            elev4.AddTarFloor(20);
        }

        private void E4_Alarm_Click(object sender, EventArgs e)
        {
            if (elev4.alarmOn == true)
                elev4.alarmOn = false;
            else if (elev4.alarmOn == false)
                elev4.alarmOn = true;
        }

        #endregion

        #region elevator5Buttons
        private void button123_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(1);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(2);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(3);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(4);
        }

        private void button119_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(5);
        }

        private void button118_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(6);
        }

        private void button117_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(7);
        }

        private void button116_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(8);
        }

        private void button115_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(9);
        }

        private void button114_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(10);
        }

        private void button113_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(11);
        }

        private void button112_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(12);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(13);
        }

        private void button110_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(14);
        }

        private void button109_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(15);
        }

        private void button108_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(16);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(17);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(18);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(19);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            elev5.AddTarFloor(20);
        }

        private void button124_Click(object sender, EventArgs e)
        {
            if (elev5.alarmOn == true)
                elev5.alarmOn = false;
            if (elev5.alarmOn == false)
                elev5.alarmOn = true;
        }

        #endregion

        #region buttonsEveryFloor

        public void Up_1_Click(object sender, EventArgs e)
        {
            ElevChoose(1,StatusEnum.Up);
        }

        private void Up_2_Click(object sender, EventArgs e)
        {
            ElevChoose(2, StatusEnum.Up);
        }

        private void Up_3_Click(object sender, EventArgs e)
        {
            ElevChoose(3, StatusEnum.Up);
        }

        private void Up_4_Click(object sender, EventArgs e)
        {
            ElevChoose(4, StatusEnum.Up);
        }

        private void Up_5_Click(object sender, EventArgs e)
        {
            ElevChoose(5, StatusEnum.Up);
        }

        private void Up_6_Click(object sender, EventArgs e)
        {
            ElevChoose(6, StatusEnum.Up);
        }

        private void Up_7_Click(object sender, EventArgs e)
        {
            ElevChoose(7, StatusEnum.Up);
        }

        private void Up_8_Click(object sender, EventArgs e)
        {
            ElevChoose(8, StatusEnum.Up);
        }

        private void Up_9_Click(object sender, EventArgs e)
        {
            ElevChoose(9, StatusEnum.Up);
        }

        private void Up_10_Click(object sender, EventArgs e)
        {
            ElevChoose(10, StatusEnum.Up);
        }

        private void Up_11_Click(object sender, EventArgs e)
        {
            ElevChoose(11, StatusEnum.Up);
        }

        private void Up12_Click(object sender, EventArgs e)
        {
            ElevChoose(12, StatusEnum.Up);
        }

        private void Up_13_Click(object sender, EventArgs e)
        {
            ElevChoose(13, StatusEnum.Up);
        }

        private void Up_14_Click(object sender, EventArgs e)
        {
            ElevChoose(14, StatusEnum.Up);
        }

        private void Up_15_Click(object sender, EventArgs e)
        {
            ElevChoose(15, StatusEnum.Up);
        }

        private void Up_16_Click(object sender, EventArgs e)
        {
            ElevChoose(16, StatusEnum.Up);
        }

        private void Up_17_Click(object sender, EventArgs e)
        {
            ElevChoose(17, StatusEnum.Up);
        }

        private void Up_18_Click(object sender, EventArgs e)
        {
            ElevChoose(18, StatusEnum.Up);
        }

        private void Up_19_Click(object sender, EventArgs e)
        {
            ElevChoose(19, StatusEnum.Up);
        }

        private void Down_2_Click(object sender, EventArgs e)
        {
            ElevChoose(2, StatusEnum.Down);
        }

        private void Down_3_Click(object sender, EventArgs e)
        {
            ElevChoose(3, StatusEnum.Down);
        }

        private void Down_4_Click(object sender, EventArgs e)
        {
            ElevChoose(4, StatusEnum.Down);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ElevChoose(5, StatusEnum.Down);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ElevChoose(6, StatusEnum.Down);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ElevChoose(7, StatusEnum.Down);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ElevChoose(8, StatusEnum.Down);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ElevChoose(9, StatusEnum.Down);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ElevChoose(10, StatusEnum.Down);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ElevChoose(11, StatusEnum.Down);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ElevChoose(12, StatusEnum.Down);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ElevChoose(13, StatusEnum.Down);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ElevChoose(14, StatusEnum.Down);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ElevChoose(15, StatusEnum.Down);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ElevChoose(16, StatusEnum.Down);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ElevChoose(17, StatusEnum.Down);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ElevChoose(18, StatusEnum.Down);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ElevChoose(19, StatusEnum.Down);
        }

        #endregion
    }
}
