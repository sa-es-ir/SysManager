using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace GetBaseEventFromETW
{
    public partial class Form3 : Form
    {
        public ProcessGraph ProcGraph { get; set; }
        public List<string> AllProcess = new List<string>();
        public List<ProcessTreeMine> PsTree = new List<ProcessTreeMine>();
        public Form3()
        {
            InitializeComponent();
           
        }

        private void GenerateProcessTreeList()
        {
            var cmd = new Process() { StartInfo = { FileName = "cmd.exe" } };
            var runPsListPath =Directory.GetCurrentDirectory()+ @"\PsList.exe";
            var resultDest = string.Empty;
            if (!Directory.Exists(@"C:\ProgramData\ProcessTree\"))
            {
                Directory.CreateDirectory(@"C:\ProgramData\ProcessTree\");
                
            }
            resultDest = @"C:\ProgramData\ProcessTree\pstree.txt";
            var command = string.Format("/C \"{0}\" -t > {1}", runPsListPath, resultDest);
            cmd.StartInfo.Arguments = command;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
            cmd.WaitForExit();
            var sr = new StreamReader(resultDest);
            var fulltxt = sr.ReadToEnd();
            fulltxt = fulltxt.Replace("\r\n", "*");
            AllProcess = fulltxt.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var lineNumber = 0;
            List<string> fatherProcess = new List<string>();
            String childs = string.Empty;
            for (int j = 0; j < AllProcess.Count; j++)
            {
                var itemToEdit = AllProcess[j];
                var outF = false;
                var spaces = string.Empty;
                var editchar = string.Empty;
                var newItem = string.Empty;
                foreach (var ch in itemToEdit.ToCharArray())
                {

                    if (ch == ' ')
                    {
                        if (outF)
                            break;
                        spaces += ch;
                    }
                    else
                    {
                        outF = true;
                        editchar += ch;
                    }
                }
                newItem = spaces + editchar;
                outF = false;
                editchar = string.Empty;

                itemToEdit = itemToEdit.Replace(newItem, "");
                foreach (var ch in itemToEdit.ToCharArray())
                {

                    if (ch == ' ')
                    {
                        if (outF)
                            break;
                    }
                    else
                    {
                        outF = true;
                        editchar += ch;
                    }
                }
                newItem += "(ID:" + editchar + ")";
                AllProcess[j] = newItem;
            }
            lineNumber = 0;
            foreach (var line in AllProcess)
            {
                childs = string.Empty;
                lineNumber++;
                if (lineNumber > 2)
                {
                    var fll = !line.StartsWith("  ");
                    if (fll)
                    {

                        fatherProcess.Add(line);
                    }

                }
            }

            //            List<ProcessTreeMine> PsTree = new List<ProcessTreeMine>();
            int from = 0, until = 0;
            foreach (var item in fatherProcess)
            {
                for (int i = 0; i < AllProcess.Count; i++)
                {
                    if (AllProcess[i].StartsWith(item))
                    {
                        from = i;
                        break;
                    }
                }
                for (int i = from + 1; i < AllProcess.Count; i++)
                {
                    if (AllProcess[i].StartsWith("  "))
                    {
                        until = i;
                    }
                    else
                        break;
                }
                until = until == 0 ? from : until;
                if (from > 0)
                    PsTree.Add(new ProcessTreeMine(item, from, until, AllProcess));

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width - 100;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            elementHost2.Width = this.Width-50;
            elementHost2.Height = this.Height-50;
            GenerateProcessTreeList();
            ProcGraph = new ProcessGraph(AllProcess, PsTree);
            //elementHost2.Size=new Size(ClientRectangle.X,ClientRectangle.Y);
            //elementHost2.Width = ClientRectangle.X;
            //elementHost2.Height = ClientRectangle.Y;
            elementHost2.Child = ProcGraph;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
