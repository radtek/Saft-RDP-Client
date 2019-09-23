using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace SafTRDPClient
{
     static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
         [STAThread]


         
         private static void run()
         {
             DialogResult dlgrslt = MessageBox.Show("Запустить программу?", "Приложение установлено в реестр", MessageBoxButtons.OKCancel);
             if (dlgrslt == DialogResult.OK)
             {
                 if (File.Exists("C:\\Program Files\\SafT\\RDPClient\\SafT RDP Client.exe"))
                 {
                     Process.Start("C:\\Program Files\\SafT\\RDPClient\\SafT RDP Client.exe", "");
                     Application.Exit();
                 }
                 else
                     MessageBox.Show("C:\\Program Files\\SafT\\RDPClient\\SafT RDP Client.exe", "Файл не найден");

             }
         }
         

         /// <summary>
         /// В реестр добавляются настройки приложения по умолчанию
         /// </summary>
         private static void Write_App_defaults()
         {
             RegistryKey SRDPDefaults;
             SRDPDefaults = Registry.LocalMachine.CreateSubKey("Software\\SafT\\RDPClient\\Defaults");
             SRDPDefaults.SetValue("UserName", "");
             SRDPDefaults.SetValue("AudioMode", "2");
             SRDPDefaults.SetValue("FullScreen", "false");
             SRDPDefaults.SetValue("Domain", "holding.ru");
             SRDPDefaults.SetValue("ColorDepth", 8);
             SRDPDefaults.SetValue("ScreenResolution", "640*480");
             SRDPDefaults.SetValue("SmartSizing", "true");
             SRDPDefaults.SetValue("Console", "true");
             SRDPDefaults.SetValue("AllowAutoConnect", "true");
             SRDPDefaults.SetValue("Reconnect", "true");
             SRDPDefaults.SetValue("ServerName", "");
             SRDPDefaults.SetValue("Folder", "Default");
             SRDPDefaults.SetValue("StoreSettingsInRegistryOrFile", "Registry");
             SRDPDefaults.SetValue("Password", "");
             SRDPDefaults.SetValue("Port", "3389");
             SRDPDefaults.Close();             
         }

         /// <summary>
         /// Запись сведений об установке - кем установлено и когда
         /// </summary>
         private static void Write_Install_Time()
         {
             RegistryKey SRDP;
             SRDP = Registry.LocalMachine.CreateSubKey("Software\\SafT\\RDPClient\\");
             SRDP.SetValue("Installed by", Environment.UserName);
             SRDP.SetValue("Installation date", System.DateTime.Now);
             SRDP.Close();
         }

         /// <summary>
         /// Создаются разделы реестра, котрыми будет пользоваться конкретный пользователь
         /// </summary>
         private static void Write_User_Defaults()
         {
             RegistryKey SRDPUsers;
             SRDPUsers = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\");
             SRDPUsers.SetValue("Username", "");
             SRDPUsers.SetValue("Password", Common_functions.MyCryptoStat.EncryptString("default", "default"));
             SRDPUsers.SetValue("Domain", "");
             SRDPUsers.SetValue("ScreenResolution", "");
             SRDPUsers.SetValue("ColorDepth", "");
             SRDPUsers.SetValue("FullScreen", "false");
             SRDPUsers.SetValue("Console", "");
             SRDPUsers.SetValue("AudioMode", "2");
             SRDPUsers.SetValue("Port", "3389");
             SRDPUsers.SetValue("Folder", "");
             SRDPUsers.SetValue("PasswordChanged", "false");

             SRDPUsers = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\Servers");
             SRDPUsers = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\Groups");
             SRDPUsers = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\Domains");
             SRDPUsers = Registry.CurrentUser.CreateSubKey("Software\\SafT\\RDPClient\\Pairs");
             SRDPUsers.Close();             
         }



        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            
                 
            if (args.Length == 0)
            {
                
                RegistryKey SRDP,SRDPD;
                SRDP = Registry.LocalMachine.OpenSubKey("Software\\SafT\\RDPClient\\Defaults");
                SRDPD = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient");
                
                
                if ((SRDP != null) && (SRDPD !=null))
                {
                    Common_functions.Settings.Initialize();
                    Application.Run( new frm_main());
                }
             
                if (SRDP == null)
                {
                    Process.Start("Saft RDP Client.exe","install application");
                    Environment.Exit(1);
                }

                if (SRDPD == null)
                {
                    Process.Start("Saft RDP Client.exe", "install user");
                    Environment.Exit(1);
                }

                if ((SRDP == null) && (SRDPD == null))
                {
                    Process.Start("Saft RDP Client.exe", "install all");
                    Environment.Exit(1);
                }

            }


  

            if ((args.Length!=0) && (args!=null))
            {
                //MessageBox.Show(args[0].ToString()+" "+args[1].ToString());
                
                if (args[0] == "install")
                {
                    
                    if (args[1] == "application")
                    {
                        DialogResult installrslt = MessageBox.Show("Хотите установить в реестр?", "Приложение не установлено", MessageBoxButtons.YesNo);
                        if (installrslt == DialogResult.OK)
                        {
                            Write_Install_Time();
                            Write_App_defaults();
                            
                        }
                    }

                    if (args[1] == "user")
                    {
                        DialogResult installuserrslt = MessageBox.Show("В реестре нет настроек пользователя. Создать?", "Приложение не установлено", MessageBoxButtons.YesNo);
                        if (installuserrslt == DialogResult.OK)
                        {
                            Write_User_Defaults();
                        }
                        
                       
                    }

                    if (args[1] == "all")
                    {
                        Write_Install_Time();
                        Write_App_defaults();
                        Write_User_Defaults();
                    }


                    
                }

                
                Application.Run(new frm_main());

            }
        }
    }
}
