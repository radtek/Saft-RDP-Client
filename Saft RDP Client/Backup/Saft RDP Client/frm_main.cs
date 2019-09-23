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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;






namespace SafTRDPClient
{
    





    public partial class frm_main : Form
    {
        
        
        

        string hashcode;
        IntPtr Caller;
        int connected_screens=0;
        string[] folderslist = null;

        
        public frm_main()
        {
            InitializeComponent();
        }


        

   

        /// <summary>
        /// Создает превьюшку из указанного контрола
        /// </summary>
        /// <param name="c">объект, превью которого надо сделать</param>
        /// <param name="w">ширина превьюшки</param>
        /// <param name="h">высота превью</param>
        /// <returns></returns>
        private Bitmap GetThumbnail(Control c, int w, int h)
        {
            Bitmap bm = new Bitmap(10,10);
            

            return bm;
        }

        private bool RegValueExists(string text,string root,string registry_path)
        {
            RegistryKey Key = null;
            switch (root)
            {
                case "CU":
                    Key = Registry.CurrentUser.OpenSubKey(registry_path);
                    break;

                case "LM":
                    Key = Registry.LocalMachine.OpenSubKey(registry_path);
                    break;

                case "CC":
                    Key = Registry.CurrentConfig.OpenSubKey(registry_path);
                    break;
            }

            string[] list = null;
            if (Key != null)
            {
                list = Key.GetValueNames();
            }
            bool exists = false;
            for (int i = 0; i < list.Length; i++)
                if (list[i] == text)
                {
                    exists = true;
                    break;
                }
            return exists;
        }

        private void RemoveFolder(bool deleteservers)
        {
            if (treeView1.SelectedNode != null)
                if (treeView1.SelectedNode.Tag.ToString() == "Folder")
                    {
                    RegistryKey group = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Groups",true);
                    try
                    {
                        group.DeleteValue(treeView1.SelectedNode.Text);
                        group.Close();
                        group.Flush();
                    }
                    catch
                    {

                    }
                    
                    string servertochange;

                    if (deleteservers != true)
                    for (int i = 0; i < treeView1.SelectedNode.Nodes.Count;i++ )
                    {
                        servertochange = treeView1.SelectedNode.Nodes[i].Text;
                        RegistryKey server = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Servers\\" + servertochange, true);
                        server.SetValue("Group", "");
                        server.Close();
                        server.Flush();
                    }
                    else                        
                        {                            
                            RegistryKey server = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Servers\\" , true);
                            for (int i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
                            {
                                servertochange = treeView1.SelectedNode.Nodes[i].Text;
                                server.DeleteSubKey(servertochange, false);
                            }
                            
                            server.Close();
                            server.Flush();
                        }
                         


                    BuildTree();
                   
                    }

        }

        private void RemoveServer()
        {
            RegistryKey servers = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Servers",true);
            servers.DeleteSubKey(treeView1.SelectedNode.Text,false);
            servers.Close();
            servers.Flush();
            BuildTree();
        }

        private void RemoveServer(string servername)
        {
            RegistryKey servers = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Servers", true);
            servers.DeleteValue(servername);
            servers.Close();
            servers.Flush();
            BuildTree();
        }



        private void AddRDP(TreeNode server)
        {
            AxMSTSCLib.AxMsRdpClientNotSafeForScripting RDPCl = new myRDP();//AxMSTSCLib.AxMsRdpClientNotSafeForScripting();
            RDPCl.Name = server.Text;
            panel4.Controls.Add(RDPCl);
            RDPCl.Dock = DockStyle.Fill;
            RDPCl.Tag = server;
            server.Tag = RDPCl;
            RDPCl.OnConnected += new System.EventHandler(RDPCl_OnConnected);
            RDPCl.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(RDPCl_OnDisconnected);
            //return RDPCl;
        }

        private void SetRDPconfig(AxMSTSCLib.AxMsRdpClientNotSafeForScripting rdp, TreeNode linknode, bool showerrors)
        {
           
            string serverstring = "Software\\SafT\\RDPClient\\Servers\\" + linknode.Text;
            RegistryKey server = Registry.CurrentUser.OpenSubKey(serverstring);
            
            rdp.Server = server.GetValue("ServerName").ToString();
            string pair = server.GetValue("Pair").ToString();
            rdp.AdvancedSettings2.SmartSizing = true;

            RegistryKey login = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + pair);
            if (login != null)
            {

                rdp.UserName = login.GetValue("Username").ToString();
                rdp.AdvancedSettings2.ClearTextPassword = Common_functions.MyCryptoStat.DecryptString(login.GetValue("Password").ToString(), Common_functions.Settings.enterp);
                rdp.Domain = login.GetValue("Domain").ToString();
                login.Close();
            }
            else
            {
                rdp.UserName = Environment.UserName;
                rdp.AdvancedSettings2.ClearTextPassword = "";
                rdp.Domain = Environment.UserDomainName;
                if ( showerrors == true) 
                    MessageBox.Show("У сервера "+rdp.Server+" не указаны логин, пароль и домен","Проблемы с логином и паролем");
            }
            
            rdp.ColorDepth = Convert.ToInt32(server.GetValue("ColorDepth").ToString());
            if (showerrors == true)
            {
                string[] resolution = (server.GetValue("ScreenResolution").ToString()).Split('*');
                rdp.DesktopWidth = Convert.ToInt32(resolution[0]);
                rdp.DesktopHeight = Convert.ToInt32(resolution[1]);

            }
            else
            {
                rdp.DesktopWidth = rdp.Width;
                rdp.DesktopHeight = rdp.Height;
            }

            
            
            //rdp.AdvancedSettings2.SmartSizing = Convert.ToBoolean(server.GetValue("Username").ToString());
            rdp.AdvancedSettings2.DisplayConnectionBar = true;
            rdp.FullScreen = Convert.ToBoolean(server.GetValue("FullScreen").ToString());
            rdp.FullScreenTitle = rdp.UserName + " on " + rdp.Server;
            rdp.AdvancedSettings2.ConnectToServerConsole = Convert.ToBoolean(server.GetValue("Console").ToString());
            rdp.SecuredSettings2.AudioRedirectionMode = Convert.ToInt32(server.GetValue("AudioMode").ToString());
            rdp.AdvancedSettings2.RDPPort = Convert.ToInt32(server.GetValue("Port").ToString());
            rdp.Tag = linknode;
            server.Close();
        }

        public void BuildTree()
        {
            treeView1.Nodes.Clear();
            
            string groupstring = "Software\\SafT\\RDPClient\\Groups";
            RegistryKey group = Registry.CurrentUser.OpenSubKey(groupstring);
            string[] groups = group.GetValueNames();//Список групп
            group.Close();

            //Сначала добавляем группы
            for (int i = 0; i < groups.Length; i++)
            {
                treeView1.Nodes.Add(groups[i].ToString());
                treeView1.Nodes[treeView1.Nodes.Count - 1].ContextMenuStrip = FoldersContextMenu;
                treeView1.Nodes[treeView1.Nodes.Count - 1].ImageIndex = 1;
                treeView1.Nodes[treeView1.Nodes.Count - 1].SelectedImageIndex = 2;
                treeView1.Nodes[treeView1.Nodes.Count - 1].Tag = "Folder";
                
            }

            //Потом добавляем сервера
            string serverliststring = "Software\\SafT\\RDPClient\\Servers";
            RegistryKey servlist = Registry.CurrentUser.OpenSubKey(serverliststring);
            string[] servers = servlist.GetSubKeyNames();//Список серверов
            servlist.Close();

            for (int j = 0; j < servers.Length; j++)//Для каждого сервера из списка
            {
                string current_serverstring = serverliststring + "\\" + servers[j];
                RegistryKey current_server = Registry.CurrentUser.OpenSubKey(current_serverstring);
                TreeNode Parent = null;
                string folder_name = current_server.GetValue("Folder").ToString();

                for (int k = 0; k < treeView1.Nodes.Count; k++)//перебираем все ветки
                {
                    Parent = treeView1.Find(treeView1.Nodes[k], folder_name);
                    if (Parent != null)
                        break;
                }
                
                if (Parent != null)//Проверка нужна, тк функция может вернуть пустую ветку=родитель не найден
                    {
                        Parent.Nodes.Add(servers[j]);
                        Parent.Nodes[Parent.Nodes.Count - 1].ContextMenuStrip = ServersContextMenu;
                        Parent.Nodes[Parent.Nodes.Count - 1].ImageIndex = 5;
                        Parent.Nodes[Parent.Nodes.Count - 1].SelectedImageIndex = 6;
                        AddRDP(Parent.Nodes[Parent.Nodes.Count - 1]);                        
                        //Parent.Nodes[Parent.Nodes.Count - 1].Tag = "Server";
                   
                    }

                    else
                        {
                        treeView1.Nodes.Add(servers[j]);
                        treeView1.Nodes[treeView1.Nodes.Count - 1].ContextMenuStrip = ServersContextMenu;
                        treeView1.Nodes[treeView1.Nodes.Count - 1].ImageIndex = 5;
                        treeView1.Nodes[treeView1.Nodes.Count - 1].SelectedImageIndex = 6;
                        AddRDP(treeView1.Nodes[treeView1.Nodes.Count - 1]);
                        //treeView1.Nodes[treeView1.Nodes.Count - 1].Tag = "Server";
                        }
                    

                current_server.Close();


            }
            servlist.Close();
            
            
        }

        public void ConnectServer(AxMSTSCLib.AxMsRdpClientNotSafeForScripting RDPClientComponentComponent)
        {


        }

        public void ConnectNode(TreeNode servername) 
            //процедура для соединения при клике по ветке с серверами
        {
            
            switch (servername.Tag.ToString())
            {
               case "Folder"://если есть дети, то создаем массив рдп-компонентов и проходимся по веткам с целью коннекта
                    {
                        MessageBox.Show("");
                       /* AxMSTSCLib.AxMsRdpClientNotSafeForScripting[] RDPClientDyn = null;
                        for (int i = 0; i < servername.Nodes.Count; i++)
                        {
                            RDPClientDyn[i] = new AxMSTSCLib.AxMsRdpClientNotSafeForScripting();
                            RDPClientDyn[i].Parent = frm_main.ActiveForm;
                            RDPClientDyn[i].Dock = System.Windows.Forms.DockStyle.Fill;
                            RDPClientDyn[i].Enabled = true;
                            RDPClientDyn[i].Location = new System.Drawing.Point(0, 0);
                            RDPClientDyn[i].Name = "RDPClient"+i.ToString();
                            RDPClientDyn[i].Size = new System.Drawing.Size(640, 480);
                            
                        }*/
                        }
                    break;

               default://если это сервер, о чем свидетельствует тэг, не равный Folder...
                    {
                        AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = servername.Tag as AxMSTSCLib.AxMsRdpClientNotSafeForScripting;
                        SetRDPconfig(rc, servername,true);
                        rc.BringToFront();
                        rc.Connect();
                    }
                    break;
            }

            
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
                    
                    RDPClient.AdvancedSettings2.SmartSizing = true;
                    RDPClient.AdvancedSettings2.DisplayConnectionBar = true;
                    
                }

                if (checkBox2.Checked)
                {
                    RDPClient.FullScreen = true;
                    RDPClient.FullScreenTitle = RDPClient.UserName + " on " + RDPClient.Server;
                }


                if (checkBox3.Checked) 
                    RDPClient.AdvancedSettings2.ConnectToServerConsole = true;

                
                RDPClient.SecuredSettings2.AudioRedirectionMode = 2;
                RDPClient.BringToFront();
                RDPClient.Connect();
                
            }
            else
            {
                RDPClient.Disconnect();
                
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

 

       
        
        private void frm_main_Load(object sender, EventArgs e)
        {
            Caller = Handle;
            BuildTree();
            


            #region Заполняем список доменов для быстрого соединения

            string domainsstring = "Software\\SafT\\RDPClient\\Domains";

            RegistryKey domains = Registry.CurrentUser.OpenSubKey(domainsstring);

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

        #region Обработка текста пароля

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

        #endregion

        #region Дополнительные функции

        private void пингToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in  serverlist
            //Process.Start("cmd.exe /k ping.exe "+serverlist[i]);
        }

        private void управлениеКомпьютеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach in serverlist
            //Process.Start("mmc.exe compmgmt.msc /computer=" + serverlist[i]);            
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

        #endregion

        #region Добавляем новый сервер в список

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool defaults = true;
            SaftRDPClient.frm_addserver form_add_server = new SaftRDPClient.frm_addserver(Handle,defaults);
            form_add_server.Show();
           
             
        }

//Данная функция используется, чтобы построить дерево заново с новыми параметрами после
// добавления сервера на соответствующей форме
        private void frm_main_CausesValidationChanged(object sender, EventArgs e)
        {
            
            if (CausesValidation == false)
            {
                treeView1.Nodes.Add(Tag.ToString());
                CausesValidation = true;
                
            }

        }
        #endregion



        private void соединитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.SelectedNode.Nodes.Count ; i++)
            {
                AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting)treeView1.SelectedNode.Nodes[i].Tag;
                if (rc.Connected != 1)
                    ConnectNode(treeView1.SelectedNode.Nodes[i]);
                
            }
        }

        private void соединитьсяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = treeView1.SelectedNode.Tag as AxMSTSCLib.AxMsRdpClientNotSafeForScripting;
            if (rc.Connected != 1)
                ConnectNode(treeView1.SelectedNode);
            else
                rc.Disconnect();
        }

        #region Изменение иконок серверов

        
        private void RDPClient_OnConnected(object sender, EventArgs e)
        {
            connected_screens++;
            button1.Text = "Disconnect";
            TreeNode helper = (TreeNode) RDPClient.Tag;
            helper.ImageIndex = 7;
            helper.SelectedImageIndex = 8;
        }

        
        private void RDPClient_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            connected_screens--;
            button1.Text = "Connect";
            TreeNode helper = (TreeNode)RDPClient.Tag;
            helper.ImageIndex = 5;
            helper.SelectedImageIndex = 6;
        }

       

        private void RDPCl_OnConnected(object sender, EventArgs e)
        {
            connected_screens++;
            AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting) sender;
            TreeNode helper = (TreeNode) rc.Tag;
            helper.ImageIndex = 7;
            helper.SelectedImageIndex = 8;

        }


        private void RDPCl_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            connected_screens--;            
            AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting)sender;
            TreeNode helper = (TreeNode)rc.Tag;            
            helper.ImageIndex = 5;
            helper.SelectedImageIndex = 6;
        }

        #endregion




        #region Изменение картинок папок

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = e.Node.ImageIndex + 2;
            e.Node.SelectedImageIndex = e.Node.SelectedImageIndex + 2;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = e.Node.ImageIndex - 2;
            e.Node.SelectedImageIndex = e.Node.SelectedImageIndex - 2;
        }

        #endregion

        private void сменитьПарольДляШифрованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common_functions.MyCryptoStat.ChangeCryptPassword();
        }

        private void добавитьССобственнымиПараметрамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaftRDPClient.frm_addserver new_custom_server = new SaftRDPClient.frm_addserver(Caller);
            new_custom_server.Show();
        }

        private void парыЛогинпарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string testpass = null;
            SaftRDPClient.Askdialog test = new SaftRDPClient.Askdialog();
            testpass = test.ShowDialogString();
            if (testpass == Common_functions.Settings.enterp)
            {
                SaftRDPClient.Pairs pass_pairs = new SaftRDPClient.Pairs();
                pass_pairs.Show();
            }
            else
                MessageBox.Show("Пароль не подходит!");
            
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Действительно хотите удалить сервер из списка?","Вы уверены?") == DialogResult.Yes)
            {
                RegistryKey servertoremove = Registry.CurrentUser.OpenSubKey(Common_functions.Settings.common_reg_string + "\\Servers", true);
                servertoremove.DeleteSubKey(treeView1.SelectedNode.Text);
                servertoremove.Close();
                servertoremove.Flush();
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < panel5.Controls.Count; i++)
            {
                Bitmap pict = new Bitmap(panel5.Controls[i].Width, panel5.Controls[i].Height);

                panel5.Controls[i].DrawToBitmap(pict, panel5.Controls[i].Bounds);
                pict.Save("c:\\rdp\\" + panel5.Controls[i].Name + ".bmp");
            }*/

            for (int i = 0; i < panel5.Controls.Count; i++)
            {
                /*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/
                myRDP thumb = (/*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/myRDP)panel5.Controls[i];
                Bitmap bmp = new Bitmap(thumb.Width, thumb.Height);
                thumb.DrawToBitmap(bmp, new Rectangle(0,0,thumb.Width,thumb.Height));
                bmp.Save("c:\\temp\\"+thumb.Name+".bmp");
                MessageBox.Show(thumb.Name);
            }
             
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (e.Node.Tag.ToString() != "Folder")
                        {
                            AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting)e.Node.Tag;
                            if (rc.Connected == 1)
                                rc.BringToFront();
                        }
                    }
                    break;

                case MouseButtons.Right:
                    {
                        if (e.Node.Tag.ToString() != "Folder")
                        {
                            AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting)e.Node.Tag;
                            if (rc.Connected == 1)
                            {
                                ServersContextMenu.Items[0].Text = "Разъединить";
                            }
                            else
                            {
                                ServersContextMenu.Items[0].Text = "Соединиться";
                            }
                        }   
                    }
                    break;
            }


        }

        private void разъединитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.SelectedNode.Nodes.Count; i++)
            {
                AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (AxMSTSCLib.AxMsRdpClientNotSafeForScripting)treeView1.SelectedNode.Nodes[i].Tag;
                if (rc.Connected == 1)
                    rc.Disconnect();
            }

        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Index.ToString());
        }

        private void показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();                     
            panel5.Size = panel4.Size;
            panel5.Visible = true;
            panel5.BringToFront();
            Common_functions.Other.MultiScreen(connected_screens, panel4.Width, panel4.Height, 5);
            int screencount = 0;
            for (int i = 0; i < panel4.Controls.Count; i++)
            {
                if (panel4.Controls[i] is /*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/ myRDP)
                {
                    AxMSTSCLib.AxMsRdpClientNotSafeForScripting rc = (/*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/ myRDP)panel4.Controls[i];
                    if (rc.Connected != 0)
                    {
                        screencount++;
                        TreeNode thumb_node = (TreeNode)rc.Tag;

                        /*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/
                        myRDP thumbnail = new /*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/myRDP();
                        thumbnail.Name = "thumbnail_" + rc.Name;                        
                        panel5.Controls.Add(thumbnail);
                        thumbnail.EndInit();
                        thumbnail.Width = Common_functions.Other.pos_size[2];
                        thumbnail.Height = Common_functions.Other.pos_size[3];
                        SetRDPconfig(thumbnail, thumb_node,false);
                        
                        thumbnail.Connect();
                                               
                        /*Label thumbnail_name = new Label();
                        thumbnail_name.Text = rc.Name;
                        thumbnail_name.Left = (int)(thumbnail.Width / 2) + thumbnail.Left;
                        thumbnail_name.Top = thumbnail.Top + thumbnail.Height;
                        panel5.Controls.Add(thumbnail_name);*/
                       
                    }
                }
            }
            
            int screen_number = 0;
            
            
            
            
            
            for (int i = 0; i < Common_functions.Other.pos_size[1]; i++)//строки
                for (int j = 0; j < Common_functions.Other.pos_size[0]; j++)//столбцы
                    if (screen_number < panel5.Controls.Count)
                    {
                        panel5.Controls[screen_number].Left = j * (Common_functions.Other.pos_size[2] + 5);
                        panel5.Controls[screen_number].Top = i * (Common_functions.Other.pos_size[3] + 5);
                        

                        
                        screen_number++;
                    }
                    else
                        break;


            for (int i = 0; i < panel5.Controls.Count; i++)
            {
                panel5.Controls[i].BringToFront();

                /*
                Bitmap pict = new Bitmap(panel5.Controls[i].Width, panel5.Controls[i].Height);
                panel5.Controls[i].DrawToBitmap(pict, panel5.Controls[i].Bounds);
                pict.Save("c:\\rdp\\" + panel5.Controls[i].Name + ".bmp");
                 */
            }   
            
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {

                if (treeView1.SelectedNode.Tag.ToString() == "Folder")
                    соединитьсяToolStripMenuItem_Click(sender, e);
                else
                    соединитьсяToolStripMenuItem1_Click(sender, e);
            }
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag.ToString() == "Folder")
                    разъединитьToolStripMenuItem_Click(sender, e);
                else
                    соединитьсяToolStripMenuItem1_Click(sender, e);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {

                if (treeView1.SelectedNode.Tag.ToString() == "Folder")
                {
                    разъединитьToolStripMenuItem_Click(sender, e);
                    соединитьсяToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    /*соединитьсяToolStripMenuItem1_Click(sender, e);
                    MessageBox.Show("Disconnected");
                    соединитьсяToolStripMenuItem1_Click(sender, e);*/
                    /*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/
                    myRDP rc = (/*AxMSTSCLib.AxMsRdpClientNotSafeForScripting*/myRDP)treeView1.SelectedNode.Tag;
                    if (rc.Connected !=0)
                        rc.Disconnect();
                    if (rc.Connected == 0)
                        rc.Connect();
                    
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

           Bitmap bmp = new Bitmap(RDPClient.ClientSize.Width,RDPClient.ClientSize.Height);
           Graphics gr = Graphics.FromImage(bmp);
           
           gr.CopyFromScreen(panel4.Left+ RDPClient.ClientRectangle.Left,panel4.Top+ RDPClient.ClientRectangle.Top, 0,0 ,RDPClient.ClientSize);
           bmp.Save(@"c:\temp\test.bmp");
           

            /*Bitmap screen = new Bitmap(RDPClient.Width, RDPClient.Height);
            screen = GetBitmap2(RDPClient);
            screen.Save("c:\\rdp.bmp");
             */


             
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TreeNode Added = new TreeNode("New Folder", 1, 2);
            Added.Tag = "Folder";
            treeView1.Nodes.Add(Added);
            treeView1.LabelEdit = true;
            
            Added.BeginEdit();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.ToString() == "Folder")
            {
                if (treeView1.SelectedNode.Nodes.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Выбранная папка содержит дочерние объекты. \n Хотите удалить дочерние объекты?", "Подтверждение", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        RemoveFolder(true);
                    }
                    else

                        if (dr == DialogResult.No)
                            RemoveFolder(false);
                }
                else
                    RemoveFolder(false);
            }
            
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
                if (treeView1.SelectedNode.Tag.ToString() != "Folder")
                    if ((DialogResult.Yes == MessageBox.Show("Вы действительно хотите удалить этот сервер из списка?", "Подтверждение", MessageBoxButtons.YesNo)))
                    {
                        RemoveServer();
                        BuildTree();
                    }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            if (e.Node.Tag.ToString() == "Folder")
            {
                if (e.Label != null)
                {
                    if (RegValueExists(e.Label, "CU", Common_functions.Settings.common_reg_string + "\\Groups") == true)
                    {
                        MessageBox.Show("Такая группа уже есть", "Измените название группы");
                        e.CancelEdit = true;
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        RegistryKey foldersnode = Registry.CurrentUser.OpenSubKey(Common_functions.Settings.common_reg_string + "\\Groups",true);
                        foldersnode.SetValue(e.Label,"");
                        foldersnode.Close();
                        foldersnode.Flush();
                    }                   
                }
                else
                    if (RegValueExists(e.Node.Text, "CU", Common_functions.Settings.common_reg_string + "\\Groups") == true)
                    {
                        MessageBox.Show("Такая группа уже есть", "Измените название группы");
                        e.CancelEdit = true;
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        RegistryKey foldersnode = Registry.CurrentUser.OpenSubKey(Common_functions.Settings.common_reg_string + "\\Groups", true);
                        foldersnode.SetValue(e.Node.Text, "");
                        foldersnode.Close();
                        foldersnode.Flush();
                    }


                
            }
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
        }

        private void перенестиВГруппуToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            if (folderslist != null)
            {
                перенестиВГруппуToolStripMenuItem1.DropDownItems.Clear();

                for (int i = 0; i < folderslist.Length; i++)
                {
                    ToolStripMenuItem some = new ToolStripMenuItem(folderslist[i]);
                    some.Click +=new EventHandler(some_Click);
                    перенестиВГруппуToolStripMenuItem1.DropDownItems.Add(some);                   
                }
            }
            
        }

        void some_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem c = (ToolStripMenuItem)sender;
            RegistryKey servertomove = Registry.CurrentUser.OpenSubKey(Common_functions.Settings.common_reg_string + "\\Servers\\" + treeView1.SelectedNode.Text, true);
            servertomove.SetValue("Folder", c.Text);
            servertomove.Close();
            servertomove.Flush();
            BuildTree();

        }

     

                

        private void ServersContextMenu_Opened(object sender, EventArgs e)
        {
            RegistryKey folders = Registry.CurrentUser.OpenSubKey(Common_functions.Settings.common_reg_string + "\\Groups");
            if (folders != null)
            {
                folderslist = folders.GetValueNames();
                folders.Close();
            }

        }

        private void свойстваToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool c = true;
            SaftRDPClient.frm_addserver p_of_s = new SaftRDPClient.frm_addserver(c);
            p_of_s.SetValues(treeView1.SelectedNode.Text);
            p_of_s.Show();
            
        }

       

       







    }





    public class myRDP : AxMSTSCLib.AxMsRdpClientNotSafeForScripting
    {


        [Flags]
        private enum DrawingOptions
        {
            PRF_CHECKVISIBLE = 0x00000001,
            PRF_NONCLIENT = 0x00000002,
            PRF_CLIENT = 0x00000004,
            PRF_ERASEBKGND = 0x00000008,
            PRF_CHILDREN = 0x00000010,
            PRF_OWNED = 0x00000020
        }

        private const uint WM_PRINT = 0x317;
        private const uint WM_PAINT = 0xF;
        private const uint WM_PRINTCLIENT = 0x318;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr dc, DrawingOptions opts);


        /// <summary>
        /// Получает изображение указанного контрола
        /// </summary>
        /// <param name="c">контрол, чье изображение надо получить</param>
        /// <returns></returns>
        public Bitmap GetBitmap(Control c)
        {
            Bitmap bm = new Bitmap(c.Width, c.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                IntPtr dc = g.GetHdc();
                try
                {
                    SendMessage(c.Handle, WM_PRINTCLIENT, dc, DrawingOptions.PRF_CLIENT);
                }
                finally
                {
                    g.ReleaseHdc();
                }

            }

            return bm;
        }

        public void DrawToBitmap(Bitmap bitmap, Rectangle targetBounds)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr dc = g.GetHdc();
                try
                {
                    SendMessage(Handle, WM_PRINTCLIENT, dc, DrawingOptions.PRF_CLIENT);
                }
                finally
                {
                    g.ReleaseHdc();
                }

            }
        }
    }

}
