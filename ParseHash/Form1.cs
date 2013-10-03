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

namespace ParseHash
{
    public partial class Form1 : Form
    {

        private Dictionary<string, List<string>> hList = new Dictionary<string, List<string>>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                listBox1.Items.Add(file);
            }
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            foreach (string fname in listBox1.Items)
            {
                parseFile(fname);
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            bgWorker1.RunWorkerAsync();
        }

        private void parseFile(string fname)
        {
            StreamReader sr = new StreamReader(fname);
            string line;
            List<string> slist;

            while( !sr.EndOfStream )
            {
                line = sr.ReadLine();
                string[] cl = line.Split(' ');
                if (hList.ContainsKey(cl[0]) == false)
                    hList[cl[0]] = new List<string>();
                slist = hList[cl[0]];
                slist.Add(cl[7]);
            }
            sr.Close();
            int totalNodes = treeView1.Nodes.Count;
            TreeNode root;
            if (totalNodes == 0)
                root = new TreeNode("scene");
            else
                root = treeView1.Nodes[0];

        }
    }
}
