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

namespace TotalChar
{
    public partial class Form1 : Form
    {
        private System.Collections.Hashtable htable = new System.Collections.Hashtable();
        

        private void fiFileChar(string fname)
        {
            StreamReader inFile = File.OpenText(fname);
            int linecnt = 0;
            string outline;
            while( !inFile.EndOfStream )
            {
                string line = inFile.ReadLine();
                char[] chars = line.ToCharArray();
                foreach (char c in chars)
                {
                    if (!htable.ContainsKey(c))
                    {
                        htable[c] = c;
                        richTextBox1.AppendText(c.ToString());
                    }
                }
            }
            inFile.Close();
        }

        private void outputResult(string fname)
        {
            StreamWriter outFile = new StreamWriter( fname, false, Encoding.Unicode );

            System.Collections.IDictionaryEnumerator denum = htable.GetEnumerator();
            int linecnt = 0;
            while (denum.MoveNext())
            {
                char ch = (char)denum.Value;
                outFile.Write(ch);
                if (++linecnt == 64)
                {
                    outFile.WriteLine();
                    linecnt = 0;
                }
            }
            outFile.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

               foreach (string file in files)
                {
                    listBox2.Items.Add(file);
                }
 
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            // 確定使用者抓進來的是檔案
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            // 確定使用者抓進來的是檔案
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                textBox1.Text = file;
                break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fsInfile;
            foreach(object listitem in listBox2.Items )
            {
                string filename = listitem.ToString();
                fiFileChar(filename);
            }
            outputResult(textBox1.Text);
        }

    }
}
