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
        private Encoding inCode = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
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
            bWorker1.RunWorkerAsync();
            /*
            foreach(object listitem in listBox2.Items )
            {
                string filename = listitem.ToString();
                filteFile(filename);
            }
            outputResult(textBox1.Text);
            */
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
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private string convString(string instr, Encoding inCode, Encoding outCode)
        {
            byte[] inBytes = inCode.GetBytes(instr);
            byte[] outBytes = Encoding.Convert(inCode, outCode, inBytes);
            char[] outChars = new char[outCode.GetCharCount(outBytes, 0, outBytes.Length)];
            outCode.GetChars(outBytes, 0, outBytes.Length, outChars, 0);
            return new string(outChars);
        }
        /*
        private void filteFile(string fname) 
        {
        }
        */
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

        private void filteFile(string fname)
        {
            StreamReader inFile = File.OpenText(fname);
            Encoding unicode = Encoding.Unicode;
            int TotalCharCount = 0;
            int linecnt = 0;
            string outline;
            while ( !inFile.EndOfStream )
            {
                string line = inFile.ReadLine();
                byte[] inBytes = inCode.GetBytes(line);
                byte[] outBytes = Encoding.Convert(inCode, unicode, inBytes);
                char[] outChars = new char[unicode.GetCharCount(outBytes, 0, outBytes.Length)];
                unicode.GetChars(outBytes, 0, outBytes.Length, outChars, 0);

                foreach (char c in outChars)
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

        private void showTotalChar(int cnt)
        {
            infoTotalChar.Text = "總字數 : " + cnt.ToString();
        }

        private void setProgressBar(int progress)
        {
            ProgressBar1.Value = 0;
        }

        private void bWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int TotalCharCount = 0;
            foreach (object listitem in listBox2.Items)
            {
                string filename = listitem.ToString();
                StreamReader inFile = File.OpenText(filename);
                inCode = inFile.CurrentEncoding;
                long inFileLength = inFile.BaseStream.Length;
                Encoding unicode = Encoding.Unicode;
                int linecnt = 0;
                string outline;
//                setProgressBar(0);
                while (!inFile.EndOfStream)
                {
                    string line = inFile.ReadLine();
                    byte[] inBytes = inCode.GetBytes(line);
                    byte[] outBytes = Encoding.Convert(inCode, unicode, inBytes);
                    char[] outChars = new char[unicode.GetCharCount(outBytes, 0, outBytes.Length)];
                    unicode.GetChars(outBytes, 0, outBytes.Length, outChars, 0);

                    foreach (char c in outChars)
                    {
                        if (!htable.ContainsKey(c))
                        {
                            htable[c] = c;
//                            richTextBox1.AppendText( c.ToString() );
                            showTotalChar( ++TotalCharCount );
                        }
                    }
                    long pos = inFile.BaseStream.Position;
                    int progress = (int)(((float)pos / (float)inFileLength) * 100.0f);
                    worker.ReportProgress(progress);
                }
                inFile.Close();
            }
        }

        private void bWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressBar1.Value = e.ProgressPercentage;
        }

        private void bWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setProgressBar(0);
            outputResult(this.textBox1.Text);
        }
    }
}
