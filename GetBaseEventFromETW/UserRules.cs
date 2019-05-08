using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Common;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace GetBaseEventFromETW
{
    public partial class UserRules : Form
    {
        public UserRules()
        {
            InitializeComponent();

        }

        private void AddPath_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Pathtxt.Text))
            {
                PathList.Items.Add(Pathtxt.Text);
            }
            ClearText();
        }

        private void PathList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BrowsePath_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Pathtxt.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void RemoveSelectedPath_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = PathList.SelectedItem;
            PathList.Items.Remove(itemToRemove);
            PathList.Refresh();
            PathToWatchList.PathToWatches.Remove(PathToWatchList.PathToWatches.FirstOrDefault(x => x.Path == itemToRemove.ToString()));
        }

        private void RemoveAllPath_btn_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= PathList.Items.Count; i++)
            {
                i = 0;
                PathList.Items.RemoveAt(i);

            }
            PathList.Refresh();
        }

        private void SavePathFile_btn_Click(object sender, EventArgs e)
        {
            try
            {

                //var pathToWatchList= (from object item in PathList.Items select new PathToWatch() {Path = item.ToString()}).ToList();
                foreach (var item in PathList.Items)
                {
                    var itemt = item.ToString().Trim();
                    if (PathToWatchList.PathToWatches.FirstOrDefault(x => x.Path == (string)item) == null)
                        PathToWatchList.PathToWatches.Add(new PathToWatch() { Path = itemt });
                }
                // get file count
                int filecount;
                int.TryParse(FileCount_txt.Text, out filecount);
                //convert paths to Json and save in file

                var stringJson = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new PathToWatchSave() { PathList = PathToWatchList.PathToWatches, FileCount = filecount });
                File.WriteAllText(Environment.CurrentDirectory + @"\FileEventConfig.txt", stringJson, Encoding.UTF8);
                PathToWatchList.PathToWatches.ForEach(x => x.Path = x.Path.ToLower());

                var killsuspend = 0;
                if (PTSFileKill_rbtn.Checked)
                    killsuspend = 1;
                if (PTSFileSuspend_rbtn.Checked)
                    killsuspend = 2;
                ProcessToSkipList.KillOrSuspendList.Remove(ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x=>x.EventName==EventName.File));
                ProcessToSkipList.KillOrSuspendList.Add(new KillOrSuspendList() { KillOrSuspend = killsuspend, EventName = EventName.File });
                var stringJson_p = Newtonsoft.Json.JsonConvert.SerializeObject(new ProcessSkipToSave() { ProcessSkipList = ProcessToSkipList.ProcessNames, KillOrSuspend = ProcessToSkipList.KillOrSuspendList });
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProcessToSkip.txt", stringJson_p,
                   Encoding.UTF8);
                MessageBox.Show("تنظیمات دخیره شد");
                ClearText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ClearText()
        {
            Pathtxt.Clear();
            KeyPath_txt.Clear();
            IPAdd_txt.Clear();
            Port_txt.Clear();
            ProcessNameSkip_txt.Clear();
             PTSFileProcessName_txt.Clear();
            PTKRegProcessName_txt.Clear();
            PTSNetProcessName_txt.Clear();
        }

        private void UserRules_Load(object sender, EventArgs e)
        {
            GetConfigs();
        }

        private void GetConfigs()
        {
            //File events config
            foreach (var item in PathToWatchList.PathToWatches)
            {
                PathList.Items.Add(item.Path);
            }
            FileCount_txt.Text = PathToWatchList.FileCount.ToString();

            //Regisrty event config
            foreach (var item in KeyToWatchList.KeyToWatches)
            {
                KeyPath_ListBox.Items.Add(item.Key);
            }

            //Network event config
            foreach (var item in NetConfigList.IpToWatches)
            {
                IPAddr_ListBox.Items.Add(item.IpAddress);
            }
            foreach (var item in NetConfigList.PortToWatches)
            {
                Port_ListBox.Items.Add(item.Port);
            }
            // Fill file grid
            dataGridViewX1.DataSource = HashFileListClass.HashList.ToList();
            // Process
            foreach (var item in ProcessToSkipList.ProcessNames.Where(x=>x.EventName==EventName.Process).ToList())
            {
                ProcessSkip_listbox.Items.Add(item.ProcessName);
            }
            foreach (var item in ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.File).ToList())
            {
                PTSFile_Listbox.Items.Add(item.ProcessName);
            }
            foreach (var item in ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.Registry).ToList())
            {
                PTKReg_ListBox.Items.Add(item.ProcessName);
            }
            foreach (var item in ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.Network).ToList())
            {
                PTSNet_ListBox.Items.Add(item.ProcessName);
            }
            //Action radio buttons
            foreach (var item in ProcessToSkipList.KillOrSuspendList.Where(x => x.EventName == EventName.Process).ToList())
            {
                ProcessSkipNoActionRadio_btn.Checked = true;
                if (item.KillOrSuspend == 1)
                    ProcessSkipKillRadio_btn.Checked = true;
                if (item.KillOrSuspend == 2)
                    ProcessSkipSuspendRadio_btn.Checked = true;
            }
            foreach (var item in ProcessToSkipList.KillOrSuspendList.Where(x => x.EventName == EventName.File).ToList())
            {
                PTSFileNoaction_rbtn.Checked = true;
                if (item.KillOrSuspend == 1)
                    PTSFileKill_rbtn.Checked = true;
                if (item.KillOrSuspend == 2)
                    PTSFileSuspend_rbtn.Checked = true;
            }
            foreach (var item in ProcessToSkipList.KillOrSuspendList.Where(x => x.EventName == EventName.Registry).ToList())
            {
                PTKRegNoAction_rbtn.Checked = true;
                if (item.KillOrSuspend == 1)
                    PTKRegKill_rbtn.Checked = true;
                if (item.KillOrSuspend == 2)
                    PTKRegSuspend_rbtn.Checked = true;
            }
            foreach (var item in ProcessToSkipList.KillOrSuspendList.Where(x => x.EventName == EventName.Network).ToList())
            {
                PTSNetNoAction_rbtn.Checked = true;
                if (item.KillOrSuspend == 1)
                    PTSNetKill_rbtn.Checked = true;
                if (item.KillOrSuspend == 2)
                    PTSNetSuspend_rbtn.Checked = true;
            }
            //
        }

        private void AddKeyPath_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(KeyPath_txt.Text))
            {
                KeyPath_ListBox.Items.Add(KeyPath_txt.Text);
            }
            ClearText();
        }

        private void RemoveKePath_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = KeyPath_ListBox.SelectedItem;
            KeyPath_ListBox.Items.Remove(itemToRemove);
            KeyPath_ListBox.Refresh();
            KeyToWatchList.KeyToWatches.Remove(KeyToWatchList.KeyToWatches.FirstOrDefault(x => x.Key == itemToRemove.ToString()));
        }

        private void SaveRegSetting_btn_Click(object sender, EventArgs e)
        {
            try
            {

                //var pathToWatchList= (from object item in PathList.Items select new PathToWatch() {Path = item.ToString()}).ToList();
                foreach (var item in KeyPath_ListBox.Items)
                {
                    var itemt = item.ToString().Trim();
                    if (KeyToWatchList.KeyToWatches.FirstOrDefault(x => x.Key == (string)item) == null)
                        KeyToWatchList.KeyToWatches.Add(new KeyToWatch() { Key = itemt });
                }

                //convert paths to Json and save in file

                var stringJson = Newtonsoft.Json.JsonConvert.SerializeObject(KeyToWatchList.KeyToWatches);
                File.WriteAllText(Environment.CurrentDirectory + @"\RegistryEventConfig.txt", stringJson, Encoding.UTF8);
                KeyToWatchList.KeyToWatches.ForEach(x => x.Key = x.Key.ToLower());


                var killsuspend = 0;
                if (PTKRegKill_rbtn.Checked)
                    killsuspend = 1;
                if (PTKRegSuspend_rbtn.Checked)
                    killsuspend = 2;
                ProcessToSkipList.KillOrSuspendList.Remove(ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == EventName.Registry));
                ProcessToSkipList.KillOrSuspendList.Add(new KillOrSuspendList() { KillOrSuspend = killsuspend, EventName = EventName.Registry });
                var stringJson_p = Newtonsoft.Json.JsonConvert.SerializeObject(new ProcessSkipToSave() { ProcessSkipList = ProcessToSkipList.ProcessNames, KillOrSuspend = ProcessToSkipList.KillOrSuspendList });
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProcessToSkip.txt", stringJson_p,
                   Encoding.UTF8);

                MessageBox.Show("تنظیمات ذخیره شد");
                ClearText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddIPAddr_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IPAdd_txt.Text))
            {
                IPAddr_ListBox.Items.Add(IPAdd_txt.Text);
            }
            ClearText();
        }

        private void SaveNetSetting_btn_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (var item in IPAddr_ListBox.Items)
                {
                    var itemt = item.ToString().Trim();
                    if (NetConfigList.IpToWatches.FirstOrDefault(x => x.IpAddress == (string)item) == null)
                        NetConfigList.IpToWatches.Add(new IpConfig() { IpAddress = itemt });
                }
                foreach (var item in Port_ListBox.Items)
                {
                    var itemt = item.ToString().Trim();
                    if (NetConfigList.PortToWatches.FirstOrDefault(x => x.Port == (string)item) == null)
                        NetConfigList.PortToWatches.Add(new PortConfig() { Port = itemt });
                }
                //convert configs to Json and save in file

                var stringJson = Newtonsoft.Json.JsonConvert.SerializeObject(new NetConfigSave() { PortConfigs = NetConfigList.PortToWatches, IpConfigs = NetConfigList.IpToWatches });
                File.WriteAllText(Environment.CurrentDirectory + @"\NetworkEventConfig.txt", stringJson, Encoding.UTF8);

                var killsuspend = 0;
                if (PTSNetKill_rbtn.Checked)
                    killsuspend = 1;
                if (PTSNetSuspend_rbtn.Checked)
                    killsuspend = 2;
                ProcessToSkipList.KillOrSuspendList.Remove(ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == EventName.Network));
                ProcessToSkipList.KillOrSuspendList.Add(new KillOrSuspendList() { KillOrSuspend = killsuspend, EventName = EventName.Network });
                var stringJson_p = Newtonsoft.Json.JsonConvert.SerializeObject(new ProcessSkipToSave() { ProcessSkipList = ProcessToSkipList.ProcessNames, KillOrSuspend = ProcessToSkipList.KillOrSuspendList });
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProcessToSkip.txt", stringJson_p,
                   Encoding.UTF8);
                MessageBox.Show("تنطیمات ذخیره شد");
                ClearText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveIPAddr_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = IPAddr_ListBox.SelectedItem;
            IPAddr_ListBox.Items.Remove(itemToRemove);
            IPAddr_ListBox.Refresh();
            NetConfigList.IpToWatches.Remove(NetConfigList.IpToWatches.FirstOrDefault(x => x.IpAddress == itemToRemove.ToString()));
        }

        private void AddPort_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Port_txt.Text))
            {
                Port_ListBox.Items.Add(Port_txt.Text);
            }
            ClearText();
        }

        private void RemovePort_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = Port_ListBox.SelectedItem;
            Port_ListBox.Items.Remove(itemToRemove);
            Port_ListBox.Refresh();
            NetConfigList.PortToWatches.Remove(NetConfigList.PortToWatches.FirstOrDefault(x => x.Port == itemToRemove.ToString()));
        }

        private void FilePathbtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " AllFiles (*.*) | *.*";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePathtxt.Text = openFileDialog1.FileName;
            }
            openFileDialog1.Dispose();
        }

        private void HashFilebtn_Click(object sender, EventArgs e)
        {
            dataGridViewX1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HashFiletxt.Text = HashClass.GetHashFile(FilePathtxt.Text, new SHA512CryptoServiceProvider());
            SetDataGridSource();
            dataGridViewX1.Visible = true;
        }

        private void SaveHashbtn_Click(object sender, EventArgs e)
        {
            SaveHashFileToList();
        }
        private void SaveHashFileToList(HashFileClass hash = null)
        {
            try
            {
                //if (HashFileListClass.HashList.FirstOrDefault(x => string.Compare(x.Hash, hash.Hash) == 0) == null)
                //{
                // HashFileListClass.HashList.Add(hash); //Sync Hash List
                var stringJson = Newtonsoft.Json.JsonConvert.SerializeObject(HashFileListClass.HashList);
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\PermissibleFile.txt", stringJson,
                    Encoding.UTF8);

                var killsuspend = 0;
                if (ProcessSkipKillRadio_btn.Checked)
                    killsuspend = 1;
                if (ProcessSkipSuspendRadio_btn.Checked)
                    killsuspend = 2;
                ProcessToSkipList.KillOrSuspendList.Remove(ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == EventName.Process));
                ProcessToSkipList.KillOrSuspendList.Add(new KillOrSuspendList(){KillOrSuspend = killsuspend,EventName = EventName.Process});
                var stringJson_p = Newtonsoft.Json.JsonConvert.SerializeObject(new ProcessSkipToSave(){ProcessSkipList = ProcessToSkipList.ProcessNames,KillOrSuspend =ProcessToSkipList.KillOrSuspendList});
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProcessToSkip.txt", stringJson_p,
                   Encoding.UTF8);
                MessageBox.Show("تنطیمات با موفقیت ذخیره شد");
                //}
                //else
                //    MessageBox.Show("این هش فایل قبلا ثبت شده است.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var hash = senderGrid.CurrentRow.Cells[2].Value.ToString();
                var dialog = MessageBox.Show("آیااز حذف هش فرایندمطمن هستید؟", "هشدار", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    HashFileListClass.HashList.Remove(HashFileListClass.HashList.FirstOrDefault(
                        x => string.Compare(x.Hash, hash) == 0));
                    SetDataGridSource();
                }
            }
        }

        private void AddHash_btn_Click(object sender, EventArgs e)
        {

            var name = Path.GetFileName(FilePathtxt.Text);
            var hash = HashFiletxt.Text;
            var hashObj = new HashFileClass() { Name = name, Hash = hash };
            HashFileListClass.HashList.Add(hashObj);
            SetDataGridSource();
        }

        private void SetDataGridSource()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = HashFileListClass.HashList;
            dataGridViewX1.Refresh();
        }

        private void ProcessSkip_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProcessSkip_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProcessNameSkip_txt.Text))
            {
                ProcessSkip_listbox.Items.Add(ProcessNameSkip_txt.Text);
                ProcessToSkipList.ProcessNames.Add(new ProcessToSkip() { ProcessName = ProcessNameSkip_txt.Text,EventName = EventName.Process});
            }
            ClearText();
        }

       

        private void ProcessSkipRemove_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = ProcessSkip_listbox.SelectedItem;
            ProcessSkip_listbox.Items.Remove(itemToRemove);
            ProcessSkip_listbox.Refresh();
            if (ProcessToSkipList.ProcessNames.Where(x=>x.EventName == EventName.Process).ToList().Count > 0)
                ProcessToSkipList.ProcessNames.Remove(ProcessToSkipList.ProcessNames.FirstOrDefault(x => x.ProcessName == itemToRemove.ToString() && x.EventName == EventName.Process));
        }

        private void PTSFileAdd_btn_Click(object sender, EventArgs e)
        {
            var txt = PTSFileProcessName_txt.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                PTSFile_Listbox.Items.Add(txt);
                ProcessToSkipList.ProcessNames.Add(new ProcessToSkip() { ProcessName = txt, EventName = EventName.File });
            }
            ClearText();
        }

        private void PTSFileRemove_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = PTSFile_Listbox.SelectedItem;
            PTSFile_Listbox.Items.Remove(itemToRemove);
            PTSFile_Listbox.Refresh();
            if (ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.File).ToList().Count > 0)
                ProcessToSkipList.ProcessNames.Remove(ProcessToSkipList.ProcessNames.FirstOrDefault(x => x.ProcessName == itemToRemove.ToString() && x.EventName==EventName.File));
        }

        private void PTKRegAdd_btn_Click(object sender, EventArgs e)
        {
            var txt = PTKRegProcessName_txt.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                PTKReg_ListBox.Items.Add(txt);
                ProcessToSkipList.ProcessNames.Add(new ProcessToSkip() { ProcessName = txt, EventName = EventName.Registry });
            }
            ClearText();
        }

        private void PTKRegRemove_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = PTKReg_ListBox.SelectedItem;
            PTKReg_ListBox.Items.Remove(itemToRemove);
            PTKReg_ListBox.Refresh();
            if (ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.Registry).ToList().Count > 0)
                ProcessToSkipList.ProcessNames.Remove(ProcessToSkipList.ProcessNames.FirstOrDefault(x => x.ProcessName == itemToRemove.ToString() && x.EventName == EventName.Registry));
        }

        private void PTSNetAdd_btn_Click(object sender, EventArgs e)
        {
            var txt = PTSNetProcessName_txt.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                PTSNet_ListBox.Items.Add(txt);
                ProcessToSkipList.ProcessNames.Add(new ProcessToSkip() { ProcessName = txt, EventName = EventName.Network });
            }
            ClearText();
        }

        private void PTSNetRemove_btn_Click(object sender, EventArgs e)
        {
            var itemToRemove = PTSNet_ListBox.SelectedItem;
            PTSNet_ListBox.Items.Remove(itemToRemove);
            PTSNet_ListBox.Refresh();
            if (ProcessToSkipList.ProcessNames.Where(x => x.EventName == EventName.Network).ToList().Count > 0)
                ProcessToSkipList.ProcessNames.Remove(ProcessToSkipList.ProcessNames.FirstOrDefault(x => x.ProcessName == itemToRemove.ToString() && x.EventName == EventName.Network));
        }

    }
}
