using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convert2Unicode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selOutFmt.SelectedIndex = 0;
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            bWorker.RunWorkerAsync();
        }

        private void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InputStreamReader isr = new InputStreamReader(new FileInputStream(infile), "SJIS");
            OutputStreamWriter osw = new OutputStreamWriter(new FileOutputStream(outfile), "UTF16");
            char[] ca = new char[4096];
            int n;
            while ((n = isr.read(ca)) > 0)
            {
                osw.write(ca, 0, n);
            }
            osw.close();
            isr.close();
        }

        private void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
