using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Simulator.Properties
{
    class Elevator
    {
        public List<bool> tarUpFloor;//电梯上升时的目标楼层，为true时表示电梯要去该楼层
        public List<bool> tarDownFloor;//电梯下降时的目标楼层
        public int curFloor;//电梯当前所处当前楼层
        public StatusEnum curStatus;//电梯当前状态
        public bool getTarFloor;//电梯是否到达目标楼层,为true时到达了目标楼层
        public bool alarmOn;//电梯警报是否开启,为true时警报开启

        //构造函数
        public Elevator()
        {
            tarUpFloor = new List<bool>();
            for(int i = 0; i < 20; i++)
            {
                tarUpFloor.Add(false);
            }
            tarDownFloor = new List<bool>();
            for(int i = 0; i < 20; i++)
            {
                tarDownFloor.Add(false);
            }
            curFloor = 1;
            curStatus = StatusEnum.Stop;
            getTarFloor = true;
            alarmOn = false;
        }

        //添加目标楼层,在当前楼层下方则放入DownFloor,上方则放入UpFloor
        public void AddTarFloor(int tar)
        {
            if (tar > curFloor)
                AddTarUpFloor(tar);
            if (tar < curFloor)
                AddTarDownFloor(tar);
        }

        //添加电梯上升的目标楼层
        public void AddTarUpFloor(int tar)
        {
            getTarFloor = false;
            tarUpFloor[tar - 1] = true;
        }
        
        //添加电梯下降的目标楼层
        public void AddTarDownFloor(int tar)
        {
            getTarFloor = false;
            tarDownFloor[tar - 1] = true;
        }
    }
}
