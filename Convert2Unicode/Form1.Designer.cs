﻿namespace Convert2Unicode
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.srcOpenBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selOutFmt = new System.Windows.Forms.ComboBox();
            this.subDir = new System.Windows.Forms.CheckBox();
            this.useDir = new System.Windows.Forms.CheckBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "檔案路徑：";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(83, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // srcOpenBtn
            // 
            this.srcOpenBtn.Location = new System.Drawing.Point(453, 10);
            this.srcOpenBtn.Name = "srcOpenBtn";
            this.srcOpenBtn.Size = new System.Drawing.Size(25, 23);
            this.srcOpenBtn.TabIndex = 2;
            this.srcOpenBtn.Text = "...";
            this.srcOpenBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selOutFmt);
            this.groupBox1.Controls.Add(this.subDir);
            this.groupBox1.Controls.Add(this.useDir);
            this.groupBox1.Location = new System.Drawing.Point(14, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "輸出格式";
            // 
            // selOutFmt
            // 
            this.selOutFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selOutFmt.FormattingEnabled = true;
            this.selOutFmt.Items.AddRange(new object[] {
            "UNICODE",
            "UTF32",
            "UTF16",
            "UTF8"});
            this.selOutFmt.Location = new System.Drawing.Point(353, 17);
            this.selOutFmt.Name = "selOutFmt";
            this.selOutFmt.Size = new System.Drawing.Size(105, 20);
            this.selOutFmt.TabIndex = 2;
            // 
            // subDir
            // 
            this.subDir.AutoSize = true;
            this.subDir.Location = new System.Drawing.Point(120, 21);
            this.subDir.Name = "subDir";
            this.subDir.Size = new System.Drawing.Size(60, 16);
            this.subDir.TabIndex = 1;
            this.subDir.Text = "子目錄";
            this.subDir.UseVisualStyleBackColor = true;
            // 
            // useDir
            // 
            this.useDir.AutoSize = true;
            this.useDir.Location = new System.Drawing.Point(18, 21);
            this.useDir.Name = "useDir";
            this.useDir.Size = new System.Drawing.Size(96, 16);
            this.useDir.TabIndex = 0;
            this.useDir.Text = "檔案所在目錄";
            this.useDir.UseVisualStyleBackColor = true;
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(403, 279);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 4;
            this.RunBtn.Text = "轉換";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(464, 156);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // bWorker
            // 
            this.bWorker.WorkerReportsProgress = true;
            this.bWorker.WorkerSupportsCancellation = true;
            this.bWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_DoWork);
            this.bWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorker_ProgressChanged);
            this.bWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWorker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 314);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.srcOpenBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button srcOpenBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox selOutFmt;
        private System.Windows.Forms.CheckBox subDir;
        private System.Windows.Forms.CheckBox useDir;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker bWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

