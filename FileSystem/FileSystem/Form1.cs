using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileSystem
{
    public partial class Form1 : Form
    {
        Folder FileSystem;// = new Folder("root");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filePath.Nodes.Add("root");
            //如果存在备份文件，则进行反序列化；不存在则初始化运行程序
            try
            {
                FileStream fs = new FileStream("Folders.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                FileSystem = (Folder)bf.Deserialize(fs);
                fs.Close();
                InitFilePath(FileSystem, filePath.TopNode);
                filePath.ExpandAll();
            }
            catch
            {
                FileSystem = new Folder("root");
            }
        }

        //遍历内存中的目录，并生成图形界面中的树状目录图
        private void InitFilePath(Folder index,TreeNode node)
        {
            //子文件夹目录不为空时，将其中的目录写到界面最左侧的树状图中去
            if (index.FolderList.Count != 0)
            {
                for(int i = 0; i < index.FolderList.Count; i++)
                {
                    node.Nodes.Add(index.FolderList[i].name);
                    InitFilePath(index.FolderList[i], node.FirstNode);//递归在子目录中进行遍历
                }
            }
        }

        //添加子节点按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (indexName.Text.ToString() == "")
                MessageBox.Show("目录名称不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (filePath.SelectedNode == null)
                MessageBox.Show("请单击要添加子目录的目录后，再点击\"添加子目录\"键", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到要添加节点的目录
                //若当前目录下没有该名字的目录，则创建；否则弹出提示框，不进行目录创建
                if (!temp.FolderExisted(indexName.Text.ToString()))
                {
                    temp.AddFolder(indexName.Text.ToString());//内存中添加目录
                    filePath.SelectedNode.Nodes.Add(indexName.Text.ToString());//图形界面中添加目录
                    filePath.ExpandAll();
                    indexName.Clear();
                }
                else MessageBox.Show("当前目录下，该目录名称已经被占用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //删除子节点按钮
        private void button3_Click(object sender, EventArgs e) 
        {
            //要先单击要删除的目录后才能进行删除操作
            if (filePath.SelectedNode == null)
                MessageBox.Show("请单击要删除的节点，再点击\"删除目录\"键","警告", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                DialogResult result = MessageBox.Show("确认要删除该目录及目录里的文件吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //由于本系统的创建的类的操作基于根节点root，因此不允许删除根节点
                    //判断用户要删除的是否为根节点，是则提示无法删除；不是则进行删除操作
                    if (filePath.SelectedNode.FullPath.ToString() == "root")
                        MessageBox.Show("本系统不允许删除根目录！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else
                    {
                        FileSystem.DelFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//在内存中删除
                        filePath.SelectedNode.Remove();//在图形界面中删除
                    }
                }
            }
        }

        //双击目录中的某一项会显示该目录下的文件
        private void filePath_NodeMouseDoubleClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileListRefresh();
        }

        //根据图形界面目录中选择的项，刷新图形界面文件目录中的内容
        public void FileListRefresh()
        {
            fileList.Items.Clear();//首先清空文件目录中的内容，之后重新进行填充
            Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到选择的目录
            //如果该目录下没有文件，则显示“该目录下无文件”
            if (temp.FileList.Count == 0)
            {
                fileList.Items.Clear();
                fileList.Items.Add("该目录下无文件");
            }
            //该目录下有文件则显示文件
            else
            {
                for (int i = 0; i < temp.FileList.Count; i++)
                {
                    fileList.Items.Add(temp.FileList[i].name);
                }
            }
        }

        //在当前目录下创建新文件
        private void newFile_Click(object sender, EventArgs e)
        {
            //判断输入框是否为空，不为空时才能进行文件创建操作
            if (fileName.Text == "")
            {
                MessageBox.Show("请先输入文件名称", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string newFileName = fileName.Text.ToString();
                Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到选择的目录
                //判断文件名在该目录下是否存在，不存在才能进行添加文件的操作
                if (temp.FileExisted(newFileName))
                    MessageBox.Show("当前目录下，该文件名称已经被占用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    temp.AddFile(newFileName);//在内存中添加新文件
                    FileListRefresh();//重新刷新图形界面中的文件列表
                }
                fileName.Text = null;//清空输入框的内容
            }
        }

        //删除文件
        private void delFile_Click(object sender, EventArgs e)
        {
            if (fileList.SelectedItem == null)
                MessageBox.Show("请先点击要删除的文件，再点击\"删除文件\"键", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult result = MessageBox.Show("确认要删除所选的文件吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到选择的目录
                    File tempFile = temp.FileList.Find(x => x.name == fileList.SelectedItem.ToString());//找到选择的要删除的文件
                    temp.FileList.Remove(tempFile);//在内存中删除文件
                }
            }
            FileListRefresh();//重新刷新图形界面中的文件列表
        }

        //双击文件列表中的内容，在编辑框中显示文件内容，并可进行编辑
        private void fileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //判断用户双击的是列出的数据不是空白区域
            if (fileList.SelectedItems.Count != 0)
            {
                //当文件区域显示"该目录下无文件"和"待选择目录.."时不予响应
                if (fileList.SelectedItem.ToString() != "该目录下无文件" && fileList.SelectedItem.ToString() != "待选择目录..")
                {
                    Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到选择文件所在的目录
                    File tempFile = temp.FileList.Find(x => x.name == fileList.SelectedItem.ToString());//找到该文件
                    //若文件内容为空，在textEditor中显示“该文件内容为空..”；不为空则显示文件内容
                    if (tempFile.content == null)
                        textEditer.Text = "该文件内容为空..";
                    else textEditer.Text = tempFile.content;
                }
            }
        }

        //储存文件
        private void saveFileContent_Click(object sender, EventArgs e)
        {
            Folder temp = FileSystem.FindFolder(filePath.SelectedNode.FullPath.ToString(), FileSystem);//找到文件所在的目录
            DialogResult result = MessageBox.Show("确认要保存更改的内容吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                File tempFile = temp.FileList.Find(x => x.name == fileList.SelectedItem.ToString());//在内存中找到要存储数据的文件
                tempFile.content = textEditer.Text;//写入文件
            }
        }

        //绑定目录名输入框的回车事件至"添加子目录"按钮
        private void indexName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2_Click(sender, e);
        }

        //绑定文件名输入框的回车事件至"新建文件"按钮
        private void fileName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                newFile_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭时提示用户是否对现有数据进行保存，若保存则进行Folder类FileSystem实例的序列化
            DialogResult result = MessageBox.Show("是否保存当前的文件系统状态", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FileStream fs = new FileStream("Folders.dat", FileMode.Create, FileAccess.ReadWrite);//将数据写入到当前路径下的Folders.dat文件中
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, FileSystem);//序列化
                fs.Close();
            }
        }
    }
}
