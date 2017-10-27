using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeryAllocation
{
    class TimerRunner
    {
        public System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();

        //初始化计时器
        public TimerRunner()
        {
            time.Interval = 15;
        }

        //计时器暂停
        public void TimerStop()
        {
            time.Enabled = false;
        }
    }
}
