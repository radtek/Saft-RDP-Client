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
    public partial class AddServer : Form
    {
        public AddServer()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label8.Text = textBox3.Text.Length.ToString();
            label7.Text = textBox3.Text.GetHashCode().ToString();
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label8.Text = textBox3.Text.Length.ToString();

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
                label7.Text = textBox3.Text.GetHashCode().ToString();

            }
            if (e.Button == MouseButtons.Right)
            {
                label7.Text = "Хэш-код";
            }

        }

        private void AddServer_Load(object sender, EventArgs e)
        {
            #region LoadingDefaults
            RegistryKey defaults;
            string defaultsstring = "Software\\SafT\\RDPClient\\Defaults";
            defaults = Registry.LocalMachine.OpenSubKey(defaultsstring);               
            textBox2.Text = defaults.GetValue("UserName").ToString();
            comboBox1.Text = defaults.GetValue("Domain").ToString();
            comboBox2.Text = defaults.GetValue("ColorDepth").ToString();
            comboBox3.Text = defaults.GetValue("ScreenResolution").ToString();
            comboBox4.Text = defaults.GetValue("Folder").ToString();
            defaults.Close();
            comboBox1.Text = "holding";

            #endregion
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string domainsstring =  "Software\\SafT\\RDPClient\\Users\\"+Environment.UserName+"\\Domains";
            RegistryKey domains = Registry.LocalMachine.OpenSubKey(domainsstring);
            
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Локальный вход");
            if (domains != null)
            {
                string[] domainslist = domains.GetValueNames();
                for (int i = 0; i < domainslist.Length; i++)
                {
                    comboBox1.Items.Add(domainslist[i]);
                }
             domains.Close();
            }

            
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            string foldersstring = "Software\\SafT\\RDPClient\\Users\\" + Environment.UserName + "\\Folders";
            RegistryKey folders = Registry.LocalMachine.OpenSubKey(foldersstring);
            
            comboBox4.Items.Clear();
            comboBox4.Items.Add("noname");
            if (folders != null)
            {
                string[] folderslist = folders.GetValueNames();
                for (int i = 0; i < folderslist.Length; i++)
                {
                    comboBox4.Items.Add(folderslist[i]);
                }
                folders.Close();
            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
                       
            Close();
            
        }
    }
}
