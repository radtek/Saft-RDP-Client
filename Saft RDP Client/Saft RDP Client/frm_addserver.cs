using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;






namespace SaftRDPClient
{
    public partial class frm_addserver : Form
    {
        IntPtr Caller;
       

        public frm_addserver()

        {
            InitializeComponent();
        }

        public frm_addserver(IntPtr caller)
        {
            InitializeComponent();
            Caller = caller;
        }

        public frm_addserver(bool some)
        {
            InitializeComponent();
            btnAddAndClose.Visible = false;
            btnAddAndConnect.Visible = false;
            Cache.MainForm.serverisediting = true;
            btnJustAdd.Text = "Закрыть";
            btnJustAdd.Click += new EventHandler(btnJustAdd_Click2);
        }

        void btnJustAdd_Click2(object sender, EventArgs e)
        {
            if (Cache.AddChangeServerForm.changes == true)
            {
                SaveServer();
                Close();
                Cache.AddChangeServerForm.changes = true;
                Cache.MainForm.serverisediting = false;
            }
        }

        private void SetDefaultValues()
        {
            comboBoxUser.Text = Common_functions.Settings.user_username;
            textBoxPassw.Text = Common_functions.MyCryptoStat.DecryptString(Common_functions.Settings.user_password, Common_functions.Settings.enterp);
            comboBoxDomain.Text = Common_functions.Settings.user_domain;
            comboBoxColor.Text = Common_functions.Settings.user_colordepth;
            comboBoxResolution.Text = Common_functions.Settings.user_screenresolution;
            comboBoxFolder.Text = Common_functions.Settings.user_folder;
            string string_audio = null;
            switch (Common_functions.Settings.user_audiomode)
            {
                case "0":
                    string_audio = "На этом компьютере";
                    break;

                case "1":
                    string_audio = "На удаленном компьютере";
                    break;                

                case "2":
                    string_audio = "Не воспроизводить";
                    break;

            }
            comboBoxSoundMode.Text = string_audio;
            checkBoxConsole.Checked = Convert.ToBoolean(Common_functions.Settings.user_console);
        }

        public void SetValues(string servername)
        {
            RegistryKey server, user;
            server = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Servers\\"+servername);
            user = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + server.GetValue("Pair").ToString());
            comboBoxUser.Text = user.GetValue("Username").ToString();
            textBoxPassw.Text = Common_functions.MyCryptoStat.DecryptString(user.GetValue("Password").ToString(), Common_functions.Settings.enterp);
            comboBoxDomain.Text = user.GetValue("Domain").ToString();
            user.Close();

            comboBoxColor.Text = server.GetValue("Colordepth").ToString();
            comboBoxResolution.Text = server.GetValue("ScreenResolution").ToString();
            comboBoxFolder.Text = server.GetValue("Folder").ToString();
            string string_audio = null;
            switch (server.GetValue("AudioMode").ToString())
            {
                case "0":
                    string_audio = "На этом компьютере";
                    break;

                case "1":
                    string_audio = "На удаленном компьютере";
                    break;                

                case "2":
                    string_audio = "Не воспроизводить";
                    break;

            }
            comboBoxSoundMode.Text = string_audio;
            checkBoxConsole.Checked = Convert.ToBoolean(server.GetValue("Console").ToString());
        
        }

        public frm_addserver(IntPtr caller,bool editflag)
        {
            InitializeComponent();
            SetDefaultValues();
            
            comboBoxUser.Enabled = false;
            textBoxPassw.Enabled = false;
            comboBoxDomain.Enabled = false;
            comboBoxColor.Enabled = false;
            comboBoxResolution.Enabled = false;
            comboBoxFolder.Enabled = false;
            comboBoxSoundMode.Enabled = false;
            checkBoxConsole.Enabled = false;
            Caller = caller;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label8.Text = textBoxPassw.Text.Length.ToString();
            label7.Text = textBoxPassw.Text.GetHashCode().ToString();
          
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label8.Text = textBoxPassw.Text.Length.ToString();

            }
            if (e.Button == MouseButtons.Right)
            {
                label8.Text = "Количество символов";
            }

        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label7.Text = textBoxPassw.Text.GetHashCode().ToString();

            }
            if (e.Button == MouseButtons.Right)
            {
                label7.Text = "Хэш-код";
            }

        }

        private void AddServer_Load(object sender, EventArgs e)
        {
            #region LoadingDefaults
            /*           
            comboBoxUser.Text = Common_functions.Settings.user_username;
            comboBoxDomain.Text = Common_functions.Settings.user_domain;
            comboBoxColor.Text = Common_functions.Settings.user_colordepth;
            comboBoxResolution.Text = Common_functions.Settings.user_screenresolution;
            comboBoxFolder.Text = Common_functions.Settings.user_folder;
            comboBoxDomain.Text = Common_functions.Settings.user_domain;
            defaults.Close();
            
            */
            #endregion
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string domainsstring =  "Software\\SafT\\RDPClient\\Users\\"+Environment.UserName+"\\Domains";
            RegistryKey domains = Registry.LocalMachine.OpenSubKey(domainsstring);
            
            comboBoxDomain.Items.Clear();
            comboBoxDomain.Items.Add("Локальный вход");
            if (domains != null)
            {
                string[] domainslist = domains.GetValueNames();
                for (int i = 0; i < domainslist.Length; i++)
                {
                    comboBoxDomain.Items.Add(domainslist[i]);
                }
             domains.Close();
            }

            
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            string foldersstring = "Software\\SafT\\RDPClient\\Users\\" + Environment.UserName + "\\Folders";
            RegistryKey folders = Registry.LocalMachine.OpenSubKey(foldersstring);
            
            comboBoxFolder.Items.Clear();
           
            if (folders != null)
            {
                string[] folderslist = folders.GetValueNames();
                for (int i = 0; i < folderslist.Length; i++)
                {
                    comboBoxFolder.Items.Add(folderslist[i]);
                }
                folders.Close();
               
            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);           
            Close();
            
        }

        private void SaveServer()
        {
            #region Добавляем новый сервер в реестр
            RegistryKey newserver;
            int pairnum = Common_functions.Other.CheckUnique(comboBoxUser.Text, textBoxPassw.Text, comboBoxDomain.Text);
            string newserverstring = Common_functions.Settings.common_reg_string + "\\Servers\\" + textBoxAlias.Text;
            newserver = Registry.CurrentUser.CreateSubKey(newserverstring);
            newserver.SetValue("Folder", comboBoxFolder.Text);
            newserver.SetValue("ServerName", textBoxHostname.Text);
            newserver.SetValue("ScreenResolution", comboBoxResolution.Text);
            if (pairnum == -1)
            {
                int newpair = Common_functions.Other.GeneratePairID();
                pairnum = newpair;
                RegistryKey add_pair = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\Pairs\\" + newpair.ToString());
                add_pair.SetValue("Password", Common_functions.MyCryptoStat.EncryptString(textBoxPassw.Text, Common_functions.Settings.enterp));
                add_pair.SetValue("Username", comboBoxUser.Text);
                add_pair.SetValue("Domain", comboBoxDomain.Text);
                add_pair.Flush();
                add_pair.Close();

            }
            newserver.SetValue("Pair", pairnum.ToString());
            newserver.SetValue("ColorDepth", "32");

            newserver.SetValue("FullScreen", "False");
            newserver.SetValue("Console", "True");
            newserver.SetValue("AudioMode", comboBoxSoundMode.SelectedIndex.ToString());
            newserver.SetValue("Port", "3389");

            newserver.Flush();
            newserver.Close();
            #endregion

            #region Добавляем группу в реестр, если ее еще нет
            RegistryKey group;
            string groupstring = Common_functions.Settings.common_reg_string + "\\Groups\\" + comboBoxFolder.Text;
            group = Registry.LocalMachine.OpenSubKey(groupstring);
            if (group == null)
                group = Registry.LocalMachine.CreateSubKey(groupstring);
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveServer();
            #region Добавляем сервер в дерево на главной форме
            SafTRDPClient.frm_main main_form;
            main_form = Form.FromHandle(Caller) as SafTRDPClient.frm_main;
            main_form.BuildTree();
            //Добавляем сервер в выбранную папку.
            //Если папка не выбрана, то добавляем в папку по умолчанию.
            //Кстати, надо сделать, чтоб папка по умолчанию бралась из реестра или файла(зависит от опций)
            /*TreeNode Parent=null;
            if (comboBox4.Text == "")
            {
                Parent = main_form.treeView1.Find(main_form.treeView1.Nodes[0], "Default");
                Parent.Nodes.Add(textBox4.Text);       
                Parent.Nodes[Parent.Nodes.Count-1].ContextMenuStrip = main_form.ServersContextMenu;
                           
            }
            else
            {
                for (int i = 0; i < Parent.Nodes.Count;i++ )
                    Parent = main_form.treeView1.Find(main_form.treeView1.Nodes[0], comboBox4.Text);
                if (Parent != null)
                {
                    Parent.Nodes.Add(textBox4.Text);
                    Parent.Nodes[Parent.Nodes.Count - 1].ContextMenuStrip = main_form.ServersContextMenu;
                }
                              
            }
             */
            #endregion
         
            
            
            

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBoxHostname.Text = textBoxAlias.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAndConnect_Click(object sender, EventArgs e)
        {
            //создать рдп-компонент, прописать настройки и запустить соединение
            button2_Click(sender, e);
            Close();

        }

        private void frm_addserver_Click(object sender, EventArgs e)
        {
            Cache.AddChangeServerForm.MakeCache(Handle);
        }
    }
}