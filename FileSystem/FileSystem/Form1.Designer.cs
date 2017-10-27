namespace FileSystem
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.filePath = new System.Windows.Forms.TreeView();
            this.indexName = new System.Windows.Forms.TextBox();
            this.addChildNode = new System.Windows.Forms.Button();
            this.delNode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newFile = new System.Windows.Forms.Button();
            this.delFile = new System.Windows.Forms.Button();
            this.saveFileContent = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath.Location = new System.Drawing.Point(32, 191);
            this.filePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(261, 340);
            this.filePath.TabIndex = 1;
            this.filePath.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.filePath_NodeMouseDoubleClick_1);
            // 
            // indexName
            // 
            this.indexName.Location = new System.Drawing.Point(102, 52);
            this.indexName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.indexName.Name = "indexName";
            this.indexName.Size = new System.Drawing.Size(191, 25);
            this.indexName.TabIndex = 3;
            this.indexName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.indexName_KeyUp);
            // 
            // addChildNode
            // 
            this.addChildNode.Font = new System.Drawing.Font("思源黑体 CN Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addChildNode.Location = new System.Drawing.Point(206, 96);
            this.addChildNode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addChildNode.Name = "addChildNode";
            this.addChildNode.Size = new System.Drawing.Size(87, 33);
            this.addChildNode.TabIndex = 5;
            this.addChildNode.Text = "添加子目录";
            this.addChildNode.UseVisualStyleBackColor = true;
            this.addChildNode.Click += new System.EventHandler(this.button2_Click);
            // 
            // delNode
            // 
            this.delNode.Location = new System.Drawing.Point(206, 137);
            this.delNode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delNode.Name = "delNode";
            this.delNode.Size = new System.Drawing.Size(87, 33);
            this.delNode.TabIndex = 6;
            this.delNode.Text = "删除目录";
            this.delNode.UseVisualStyleBackColor = true;
            this.delNode.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "添加的目录名:";
            // 
            // textEditer
            // 
            this.textEditer.AcceptsReturn = true;
            this.textEditer.AcceptsTab = true;
            this.textEditer.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEditer.Location = new System.Drawing.Point(713, 191);
            this.textEditer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditer.Multiline = true;
            this.textEditer.Name = "textEditer";
            this.textEditer.Size = new System.Drawing.Size(328, 340);
            this.textEditer.TabIndex = 8;
            this.textEditer.Text = "点击此处进行文件编辑..";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "目录";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "目录下文件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "文件编辑";
            // 
            // newFile
            // 
            this.newFile.Location = new System.Drawing.Point(538, 96);
            this.newFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newFile.Name = "newFile";
            this.newFile.Size = new System.Drawing.Size(87, 33);
            this.newFile.TabIndex = 13;
            this.newFile.Text = "新建文件";
            this.newFile.UseVisualStyleBackColor = true;
            this.newFile.Click += new System.EventHandler(this.newFile_Click);
            // 
            // delFile
            // 
            this.delFile.Location = new System.Drawing.Point(538, 137);
            this.delFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delFile.Name = "delFile";
            this.delFile.Size = new System.Drawing.Size(87, 33);
            this.delFile.TabIndex = 14;
            this.delFile.Text = "删除文件";
            this.delFile.UseVisualStyleBackColor = true;
            this.delFile.Click += new System.EventHandler(this.delFile_Click);
            // 
            // saveFileContent
            // 
            this.saveFileContent.Location = new System.Drawing.Point(954, 137);
            this.saveFileContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveFileContent.Name = "saveFileContent";
            this.saveFileContent.Size = new System.Drawing.Size(87, 33);
            this.saveFileContent.TabIndex = 15;
            this.saveFileContent.Text = "保存文件";
            this.saveFileContent.UseVisualStyleBackColor = true;
            this.saveFileContent.Click += new System.EventHandler(this.saveFileContent_Click);
            // 
            // fileList
            // 
            this.fileList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 12;
            this.fileList.Items.AddRange(new object[] {
            "待选择目录.."});
            this.fileList.Location = new System.Drawing.Point(374, 191);
            this.fileList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(251, 340);
            this.fileList.TabIndex = 16;
            this.fileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "添加的文件名:";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(434, 52);
            this.fileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(191, 25);
            this.fileName.TabIndex = 17;
            this.fileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fileName_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1055, 583);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.saveFileContent);
            this.Controls.Add(this.delFile);
            this.Controls.Add(this.newFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEditer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delNode);
            this.Controls.Add(this.addChildNode);
            this.Controls.Add(this.indexName);
            this.Controls.Add(this.filePath);
            this.Font = new System.Drawing.Font("思源黑体 CN Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "文件管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView filePath;
        private System.Windows.Forms.TextBox indexName;
        private System.Windows.Forms.Button addChildNode;
        private System.Windows.Forms.Button delNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEditer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newFile;
        private System.Windows.Forms.Button delFile;
        private System.Windows.Forms.Button saveFileContent;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fileName;
    }
}

