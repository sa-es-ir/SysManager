using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace GetBaseEventFromETW
{
    public partial class Form1 : Form
    {
        public ProcessGraph ProcGraph { get; set; }
        public string ProcessHistory = string.Empty;
        public Form1()
        {
            InitializeComponent();
            
        }

      


        private int FileAccessCount;
        private void Form1_Load(object sender, EventArgs e)
        {
            var op = PipLineManager.operation;
            if (op == 1)
                tabControl1.SelectedIndex = 3;
            else if (op == 2)
                tabControl1.SelectedIndex = 2;
            else if (op == 3)
                tabControl1.SelectedIndex = 1;
            else
                tabControl1.SelectedIndex = 0;
            SetWindowSize();
            timer1.Start();
            ProcGraph = new ProcessGraph(ProcessHistory);
            elementHost1.Child = ProcGraph;
            FileAccessCount = PathToWatchList.FileCount;
            textBox1.Text = FileAccessCount.ToString();
        }

        private void SetWindowSize()
        {
            //this.Width = Screen.PrimaryScreen.Bounds.Width-150;
        }

        public void GetData(string data)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // var eventContent = PipLineManager.ReadFile();
            FileEventsGrid.DataSource =
                PipLineManager.FileEvents.Select(
                    x => new {x.ProcessName, x.ProcessId, x.EventName, x.FileName, x.FilePath,x.ProcessHistory}).ToList();
            var fileacc = PipLineManager.FileAccessCount;
            dataGridView1.DataSource = fileacc.ToList();
            Task.Run(() =>
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    int count;
                    if (int.TryParse(item.Cells[1].Value.ToString(), out count))
                    {
                        if (count > FileAccessCount)
                        {
                            var p = dataGridView1.Rows[item.Index].Cells[0].Value.ToString();
                            dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = Color.Aqua;
                            if (ProcessToSkipList.ProcessNames.FirstOrDefault(x=>p.ToLower().Contains(x.ProcessName.ToLower()))==null)
                            {
                                var kill =
                               ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == EventName.File);
                                if (kill != null && kill.KillOrSuspend == 1)
                                {
                                    try
                                    {
                                        Process.GetProcessesByName(p)[0].Kill();
                                        
                                    }
                                    catch { }
                                }
                            }
                           
                        }
                    }
                }
            });
            
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            if (textBox1.Text != string.Empty)
            {
                FileAccessCount = int.Parse(textBox1.Text);
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            // dataGridView2.DataSource = PipLineManager.ProcessDictionary.ToList();
            dataGridViewX2.DataSource = PipLineManager.ProcessDictionary.ToList();
            var dic = PipLineManager.NetworkUsage;
            dataGridViewX1.DataSource = dic.ToList();

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridViewX1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null)
            {
                var Cells = dataGridViewX1.CurrentRow.Cells;
                string ProcessHistory = Cells[2].Value.ToString();
                ProcGraph.RebuildGraph(ProcessHistory);
                string txt = "Process Name: " + Cells[1].Value + "\r\nProcessHistory: "
                             + ProcessHistory + "\r\nSource Address: " + Cells[9].Value;
                //if (long.Parse(Cells[9].Value.ToString()) > 0)
                //{
                //    try
                //    {
                //        txt += new IPAddress(BitConverter.GetBytes(uint.Parse(Cells[9].Value.ToString())));
                //    }
                //    catch
                //    {
                //    }
                //}
                txt += "\r\nDestination Address: " + Cells[8].Value;
                //if (long.Parse(Cells[8].Value.ToString()) > 0)
                //{
                //    try
                //    {
                //        txt += new IPAddress(BitConverter.GetBytes(uint.Parse(Cells[9].Value.ToString())));
                //    }
                //    catch
                //    {
                //    }
                //}
                textBox2.Text = txt;
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(showForm);
            t.Start();
        }

        [STAThread]
        private void showForm()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form2());
        }

        private void dataGridViewX2_MouseClick(object sender, MouseEventArgs e)
        {
            string txt = "";
            if (dataGridViewX2.CurrentRow != null)
            {
                ProcessHistory = dataGridViewX2.CurrentRow.Cells[1].Value.ToString();
                ProcGraph.RebuildGraph(ProcessHistory);
                txt += "Process Name: " + dataGridViewX2.CurrentRow.Cells[0].Value + "\r\nProcess History: " +
                       ProcessHistory;
            }
            textBox2.Text = txt;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            dataGridViewX3.DataSource = PipLineManager.RegistryUsage.ToList();
        }

        private void dataGridViewX3_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridViewX3.CurrentRow != null)
            {
                var Cells = dataGridViewX3.CurrentRow.Cells;
                string ProcessHistory = Cells[2].Value.ToString();
                ProcGraph.RebuildGraph(ProcessHistory);
                string txt = "Process Name: " + Cells[1].Value + "\r\nProcessHistory: "
                             + ProcessHistory + "\r\nSource Address: ";
                textBox2.Text = txt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        

     

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
           
        }

        private void userRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRules formUserRules=new UserRules();
            formUserRules.ShowDialog(this);
        }

        private void processesGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void memoryConsumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(showForm);
            t.Start();
        }

        private void FileEventsGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void FileEventsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (FileEventsGrid.CurrentRow != null)
            {
                var Cells = FileEventsGrid.CurrentRow.Cells;
                string ProcessHistory = Cells[5].Value.ToString();
                ProcGraph.RebuildGraph(ProcessHistory);
                string txt = "Process Name: " + Cells[1].Value + "\r\nProcessHistory: "
                             + ProcessHistory + "\r\nSource Address: ";
                textBox2.Text = txt;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       
    }
}
