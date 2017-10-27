using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeryAllocation
{
    class Memery
    {
        private List<int> MemBlocks;//用于表示四个内存块
        private int MemNumFlag;

        //构造函数
        public Memery()
        {
            MemBlocks = new List<int>();
            //添加四个空的内存块（第五个用来占坑..）
            for(int i = 0; i < 5; i++)
            {
                MemBlocks.Add(0);
            }
            MemNumFlag = 0;
        }

        //初始化实例
        public void reset()
        {
            MemBlocks.Clear();
            MemBlocks = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                MemBlocks.Add(0);
            }
            MemNumFlag = 0;
        }

        //内存块是否可用，可用返回内存块编号，不可用返回4
        public int IsMemBlockAvaliable()
        {
            int i = 0;
            while (MemBlocks[i] != 0)
            {
                if (i == 4) break;
                i++;
            }
            return i;
        }

        //获取当前指令的页面号
        public int GetPageNum(int opNum)
        {
            int pageNum = opNum / 10 + 1;
            return pageNum;
        }

        //查询当前页面是否在内存里
        public bool IsPageInMem(int pageNum)
        {
            int i = 0;
            while (MemBlocks[i] != pageNum)
            {
                if (i == 4) return false;
                i++;
            }
            return true;
        }

        //分配页面至内存块,返回内存块的编号
        public int AllocateMem(int pageNum)
        {
            //如果有可用的内存块，则直接导入
            if (IsMemBlockAvaliable() != 4)
            {
                MemBlocks[IsMemBlockAvaliable()] = pageNum;
                return IsMemBlockAvaliable();
            }
            //如果没有可用的内存块，则采用FIFO算法置换后导入
            else
            {
                MemBlocks[MemNumFlag] = pageNum;
                int temp = MemNumFlag;
                if (MemNumFlag == 3)
                    MemNumFlag = 0;
                else MemNumFlag += 1;
                return temp + 1;
            }
        }
    }
}
