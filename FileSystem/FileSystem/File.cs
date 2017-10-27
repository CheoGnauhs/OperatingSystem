using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    [Serializable]
    public class File
    {
        public string name;//文件名
        public string content;//文件内容

        //构造函数
        public File(string fileName)
        {
            name = fileName;
        }
    }
}
