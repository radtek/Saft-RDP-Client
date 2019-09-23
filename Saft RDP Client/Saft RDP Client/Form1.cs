using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;





namespace SafTRDPClient
{
    
    public partial class frm_main : Form
    {
        

        string hashcode;
        public frm_main()
        {
            InitializeComponent();
        }

        private void реестрToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void реестрToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            
              
        }

        private void местоХраненияПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RDPClient.Connected != 1)
            {
                RDPClient.Server = textBox1.Text;
                RDPClient.UserName = textBox2.Text;
                RDPClient.AdvancedSettings2.ClearTextPassword = textBox3.Text;
                if (comboBox3.Text != "Локальный вход")
                {
                    RDPClient.Domain = comboBox3.Text;
                }
                else
                {
                    RDPClient.Domain = textBox1.Text;
                }


                
                switch (comboBox1.SelectedIndex)
                {
                    case 0 :
                    RDPClient.ColorDepth = 8;                      
                    break;

                    case 1:
                    RDPClient.ColorDepth = 15;
                    break;

                    case 2:
                    RDPClient.ColorDepth = 16;
                    break;

                    case 3:
                    RDPClient.ColorDepth = 24;
                    break;

                    case 4:
                    RDPClient.ColorDepth = 32;
                    break;

                }

                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                    RDPClient.DesktopWidth = 640;
                    RDPClient.DesktopHeight = 480;
                    break;

                    case 1:
                    RDPClient.DesktopWidth = 800;
                    RDPClient.DesktopHeight = 600;
                    break;

                    case 2:
                    RDPClient.DesktopWidth = 1024;
                    RDPClient.DesktopHeight = 768;
                    break;

                    case 3:
                    RDPClient.DesktopWidth = 1280;
                    RDPClient.DesktopHeight = 1024;
                    break;

                    case 4:
                    RDPClient.DesktopWidth = RDPClient.Width;
                    RDPClient.DesktopHeight = RDPClient.Height;
                    break;
                }

                if (checkBox1.Checked)
                {
                    
                    //RDPClient.AdvancedSettings2.SmartSizing = true;
                    RDPClient.AdvancedSettings2.DisplayConnectionBar = true;
                    
                }

                if (checkBox2.Checked)
                {
                    RDPClient.FullScreen = true;
                    RDPClient.FullScreenTitle = RDPClient.UserName + " on " + RDPClient.Server;
                }


                if (checkBox3.Checked) 
                    RDPClient.AdvancedSettings2.ConnectToServerConsole = true;

                RDPClient.AdvancedSettings2.SmartSizing = true;
                RDPClient.SecuredSettings2.AudioRedirectionMode = 2;
                RDPClient.Connect();
                button1.Text = "Disconnect";
            }
            else
            {
                RDPClient.Disconnect();
                button1.Text = "Connect";
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void пингToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in  serverlist
            //Process.Start("cmd.exe /k ping.exe "+serverlist[i]);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            RDPClient.Visible = false;
            Mstsc.Dock = DockStyle.Fill;
            
            Mstsc.DesktopHeight = 1024;
            Mstsc.DesktopWidth = 1280;
            
            Mstsc.Server = "analytic";
            Mstsc.UserName = "safargaliev";
            
            Mstsc.FullScreen = false;
            Mstsc.ColorDepth = 32;
            Mstsc.SecuredSettings2.AudioRedirectionMode = 2;
            Mstsc.AdvancedSettings3.SmartSizing = true;
            Mstsc.Connect();
            Mstsc.Visible = true;
             */
        }

        private void axSAFRemoteDesktopClientHost1_Enter(object sender, EventArgs e)
        {
            
        }

        private void управлениеКомпьютеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //foreach in serverlist
            //Process.Start("mmc.exe compmgmt.msc /computer=" + serverlist[i]);            
        }

        private void списокСерверовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frm_main_Load(object sender, EventArgs e)
        {
           
            string servliststring = @"Software\SafT\RDPClient\Users\"+Environment.UserName+"\\Servers";
            RegistryKey servlist = Registry.LocalMachine.OpenSubKey(servliststring);
            if (servlist == null) MessageBox.Show("Список серверов пуст");
            else
            #region BuildingServersTree
            {
                //узнаем список подразделов
                string[] serverlist = servlist.GetSubKeyNames();
                //пройдемся по списку с целью построения дерева
                for (int i = 0; i < serverlist.Length; i++)
                {
                    //пооткрывем-ка папки, чтобы узнать, что в них есть
                    RegistryKey folders = Registry.LocalMachine.OpenSubKey(servliststring + "\\"+serverlist[i]);
                    for (int j=0; j<treeView1.Nodes.Count-1;j++)
                    {
                        //если нету такой папки в дереве, то надо добавить и ее, и сервер
                        if (folders.GetValue("Folder").ToString() != treeView1.Nodes[j].Text)
                        {
                            treeView1.Nodes.Add(folders.GetValue("Folder").ToString());
                            treeView1.Nodes.Add(folders.GetValue("Folder").ToString(), folders.GetValue("ServerName").ToString());
                        }
                        //а вот если есть, то надо добавить сервер к уже существующей папке
                        else
                            treeView1.Nodes.Add(folders.GetValue("Folder").ToString(), folders.GetValue("ServerName").ToString());
               
                    }
                    folders.Close();

                }
                servlist.Close();
            }
            #endregion
            #region FillingInDomains

            
            string domainsstring = @"Software\SafT\RDPClient\Users\" + Environment.UserName + "\\Domains";
            
            RegistryKey domains = Registry.LocalMachine.OpenSubKey(domainsstring);
            
            if (domains != null)
            {

                string[] domainslist = domains.GetValueNames();
                
                for (int i = 0; i < domainslist.Length; i++)
                {
                    comboBox3.Items.Add(domainslist[i]);
                }
               

            }
            domains.Close();

            #endregion



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Text = (textBox3.Text.Length.ToString());
            label7.Text = (textBox3.Text.GetHashCode().ToString());
            hashcode = label7.Text;
        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                hashcode = label7.Text;
                label7.Text = "Хэш-код";
            }

            if (e.Button == MouseButtons.Left)
            {
                label7.Text = (textBox3.Text.GetHashCode().ToString());
            }

        }

        private void label6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                hashcode = label6.Text;
                label6.Text = "Количество символов";
            }

            if (e.Button == MouseButtons.Left)
            {
                label6.Text = (textBox3.Text.Length.ToString());
            }
        }

        private void бесконечныйПингToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in serverlist
            //Process.Start("ping -t"+sereverlist[i]);
        }

        private void просмотрСобытийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in serverlist
            //Process.Start("mmc.exe eventvwr.msc /computer=" + serverlist[i]);
        }

        private void службыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in serverlist
            //Process.Start("mmc.exe  services.msc /computer=" + serverlist[i]);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Список серверов надо переместить в HKCU; Надо бы еще, чтоб приложение запрашивало админские права при установке");
            SaftRDPClient.AddServer form_add_server = new SaftRDPClient.AddServer();
            form_add_server.Show();
           
             
        }

        private void frm_main_Paint(object sender, PaintEventArgs e)
        {
            
            

        }

    }
}
