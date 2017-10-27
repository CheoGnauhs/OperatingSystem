using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystem
{
    [Serializable]
    class Folder
    {
        public string name;//该文件夹名称
        public string path;//文件路径
        public Folder parent;//上一级文件夹
        public List<File> FileList;//其中的文件列表
        public List<Folder> FolderList;//其中的文件夹列表

        //构造函数
        public Folder(string folderName)
        {
            name = folderName;
            path = "root";
            parent = null;
            FileList = new List<File>();
            FolderList = new List<Folder>();
        }

        //通过递归按地址查找目录
        public Folder FindFolder(string folderPath, Folder index)
        {
            if (folderPath == "root")
                return index;
            Folder target = index.FolderList.Find(x => x.path == folderPath);//查找要找的目录是否在当前目录下
            //目标目录不在当前目录下则到当前目录的子目录中进行查找
            if (target == null)
                for (int i = 0; i < index.FolderList.Count; i++)
                {
                    //如果找到则返回目标目录
                    if (target != null)
                        return target;
                    target = FindFolder(folderPath, index.FolderList[i]);
                }
            return target;
        }

        //判断当前目录中，用户输入的目录命名是否存在
        public bool FolderExisted(string folderName)
        {
            for(int i = 0; i < FolderList.Count(); i++)
            {
                if (FolderList[i].name == folderName)
                    return true;
            }
            return false;
        }
        
        //添加新的子目录
        public void AddFolder(string folderName)
        {
            Folder newFolder = new Folder(folderName);
            FolderList.Add(newFolder);
            newFolder.parent = this;
            newFolder.path = this.path + "\\" + newFolder.name;
        }

        //按路径删除目录
        public void DelFolder(string folderPath, Folder index)
        {
            Folder target = FindFolder(folderPath, index);//找到目标目录
            target.parent.FolderList.Remove(target.parent.FolderList.Find(x => x.path == folderPath));//从其上一级目录中进行删除
        }

        //按名字查找文件
        public File FindFile(string fileName)
        {
            File target = FileList.Find(x => x.name == fileName);
            return target;
        }

        //判断当前目录下，用户输入的文件命名是否存在
        public bool FileExisted(string FileName)
        {
            for (int i = 0; i < FileList.Count(); i++)
            {
                if (FileList[i].name == FileName)
                    return true;
            }
            return false;
        }

        //添加新的文件
        public void AddFile(string fileName)
        {
            File newFile = new File(fileName);
            FileList.Add(newFile);
        }

    }
}
