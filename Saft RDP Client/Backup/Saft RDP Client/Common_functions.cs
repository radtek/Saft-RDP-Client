using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;





  namespace Common_functions
    {


        /// <summary>
        /// Статический 
        /// Этот класс содержит 3 функции: 2 публичные(зашифровать и расшифровать), одну собственную (генерация ключа)
        /// </summary>
      public static class MyCryptoStat
        {


            /// <Генерация ключа>
            /// Функция генерирует ключ на основе пароля. При этом используется добавка в виде имени текущего пользователя
            /// </Генерация ключа>
            /// <param name="password">Пароль, используемый для шифрования</param>
            /// <returns>[0] - ключ шифрования;[1] - вектор инициализации</returns>
            private static byte[][] GenerateKey(string password)
            {
                SymmetricAlgorithm algo = new RijndaelManaged();
                byte[] salt = Encoding.ASCII.GetBytes(Environment.UserName);
                PasswordDeriveBytes passwordkey = new PasswordDeriveBytes(password, salt, "SHA256", 3);
                algo.Key = passwordkey.GetBytes(algo.KeySize / 8);
                algo.IV = passwordkey.GetBytes(algo.BlockSize / 8);
                byte[][] returnvalue = new byte[2][];
                returnvalue[0] = algo.Key;
                returnvalue[1] = algo.IV;
                return returnvalue;

            }

            /// <Шифрование>
            /// Шифрует данные по алгоритму AES
            /// </Шифрование>
            /// <param name="data_to_crypt">Строка, которую необходимо зашифровать</param>
            /// <param name="password">Пароль, используемый для шифрования</param>
            /// <returns>Зашифрованная строка</returns>
            public  static string EncryptString(string data_to_crypt, string password)
            {
                SymmetricAlgorithm algo = new RijndaelManaged();
                algo.Key = GenerateKey(password)[0];
                algo.IV = GenerateKey(password)[1];
                ICryptoTransform encryptor = algo.CreateEncryptor(algo.Key, algo.IV);
                MemoryStream unencryptedpass = new MemoryStream();
                CryptoStream encryptstream = new CryptoStream(unencryptedpass, encryptor, CryptoStreamMode.Write);
                encryptstream.Write(Encoding.UTF8.GetBytes(data_to_crypt), 0, Encoding.UTF8.GetByteCount(data_to_crypt));// <- По сути, эта строка отвечает за запись шифровки. Если вместо input поставить password, при дешифрации получим расшифрованный password
                encryptstream.FlushFinalBlock();
                string cryptodone = Convert.ToBase64String(unencryptedpass.ToArray());
                return cryptodone;

            }

            /// <Расшифровка>
            /// Расшифровывает данные, исп. алгоритм AES. Если задан не тот пароль для рашифровки, то возвращает строку = "Trouble!!!"
            /// </Расшифровка>
            /// <param name="data_to_decrypt">Строка, которую надо расшифровать</param>
            /// <param name="password">Пароль, на основании которого делается рашифровка</param>
            /// <returns>Расшифрованная строка или "Trouble!!!"</returns>
            public static string DecryptString(string data_to_decrypt, string password)
            {
                SymmetricAlgorithm algo = new RijndaelManaged();
                algo.Key = GenerateKey(password)[0];
                algo.IV = GenerateKey(password)[1];
                ICryptoTransform decryptor = algo.CreateDecryptor(algo.Key, algo.IV);//ключ не меняется
                MemoryStream encryptedpass = new MemoryStream(Convert.FromBase64String(data_to_decrypt));//криптодон - зашифрованный пароль
                CryptoStream decryptstream = new CryptoStream(encryptedpass, decryptor, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(decryptstream);
                try
                {
                    string decryptedpass = sr.ReadToEnd();
                    return decryptedpass;
                }
                catch                
                {
                    return "Trouble!!!";

                }
                
            }

            /// <summary>
            /// Функция для смены пароля по заданному пути, шифруется текущим паролем
            /// </summary>
            /// <param name="path">Путь к паролю в реестре, указывает на пару "логин-пароль"</param>
            public static void ChangePassword(string path)
            {
                RegistryKey pass = null;
                pass = Registry.CurrentUser.OpenSubKey(path);
                pass.DeleteValue("Password");
                SaftRDPClient.Askdialog new_pass = new SaftRDPClient.Askdialog();
                string newpass = new_pass.ShowDialogString();

                if (newpass == Common_functions.Settings.enterp)
                {
                    new_pass.Text = "Введите новый пароль";
                    string pass1 = new_pass.ShowDialogString();
                    new_pass.Text = "Подтвердите пароль";
                    string pass2 = new_pass.ShowDialogString();
                    if (pass1 == pass2)
                    {
                        pass.SetValue("Password", EncryptString(pass1, Common_functions.Settings.enterp));
                    }
                }
                
                pass.Close();

            }

            /// <summary>
            /// Заменяет пароль по указанному пути новым паролем
            /// </summary>
            /// <param name="path">путь к паре "логин-пароль"</param>
            /// <param name="new_password">новый пароль в зашифрованном виде</param>
            public static void ChangeSingleCryptPassword(string path, string new_password)
            {
                RegistryKey Change = Registry.CurrentUser.OpenSubKey(path,true);
                string cryptedpass = Change.GetValue("Password").ToString();
                string serverpass = DecryptString(cryptedpass, Common_functions.Settings.enterp);
                
                Change.DeleteValue("Password");
                Change.SetValue("Password", EncryptString(serverpass,new_password));

                if (path == "Software\\SafT\\RDPClient")
                    Change.SetValue("PasswordChanged", "true");

                Change.Flush();
                Change.Close();

            }
          
            /// <summary>
            /// Заменяет пароль новым во всех ветках
            /// </summary>
            public static void ChangeCryptPassword()
            {
                SaftRDPClient.Askdialog new_pass = new SaftRDPClient.Askdialog();
                

                new_pass.Text = "Введите текущий пароль";
                string pass = new_pass.ShowDialogString();

                if (pass == Common_functions.Settings.enterp)
                {
                    new_pass.Text = "Введите новый пароль";
                    string pass1 = new_pass.ShowDialogString();
                    new_pass.Text = "Подтвердите пароль";
                    string pass2 = new_pass.ShowDialogString();

                    if (pass1 == pass2)
                    {
                        ///Замена пароля по дефолту
                        ///Работает неправильно!!! Шифруя старым паролем новый!!!
                        string encryptedpass = EncryptString(pass1, Common_functions.Settings.enterp);

                        string passvalue = "Software\\SafT\\RDPClient";
                        ChangeSingleCryptPassword(passvalue, pass1);
                        Settings.enterp = pass1;


                        passvalue = "Software\\SafT\\RDPClient\\Pairs";
                        RegistryKey listkey = Registry.CurrentUser.OpenSubKey(passvalue);
                        if (listkey != null)
                        {
                            string[] pairlist = listkey.GetValueNames();
                            for (int i = 0; i < pairlist.Length; i++)
                            {
                                ChangeSingleCryptPassword(passvalue + "\\" + pairlist[i], pass1);
                            }
                        }


                    }

                    else
                        MessageBox.Show("Введенные пароли не совпадают!");

                }
                else
                    MessageBox.Show("Введен некорректный пароль");
            }


        }

      /// <summary>
      /// Статический класс настроек
      /// Класс сделан статическим в связи с тем что:
      ///     1. Нужен доступ из любого модуля к одинаковым данным
      ///     2. Если класс нестатический, то приходится в каждом модуле создавать экземпляр класса,
      ///         что накладно и в принципе неверно
      ///     3. Надо же и опыта набираться :)
      /// </summary>
      public static class Settings
      {
          public static string user_password { get ; set; }
          public static string user_username { get; set; }
          public static string user_domain { get; set; }
          public static string user_console { get; set; }
          public static string user_colordepth { get; set; }
          public static string user_audiomode { get; set; }
          public static string user_screenresolution { get; set; }
          public static string user_fullscreen { get; set; }
          public static string user_port { get; set; }
          public static string user_folder { get; set; }
          public static string user_default_pair { get; set; }


          public static string app_console { get; set; }
          public static string app_colordepth { get; set; }
          public static string app_audiomode { get; set; }
          public static string app_screenresolution { get; set; }
          public static string app_fullscreen { get; set; }
          public static string app_port { get; set; }
          public static string app_folder { get; set; }
          

          public static string enterp { get; set; }
          
          public static string common_reg_string { get; set; }
          public static string defaults_reg_string { get; set; }



          /// <summary>
          /// Загрузка дефолтных настроек пользователя
          /// </summary>
          private static void LoadUserSettings_reg()
          {

              RegistryKey userdefaults = Registry.CurrentUser.OpenSubKey(common_reg_string);
              if (userdefaults != null)
              {
                  //user_domain = userdefaults.GetValue("Domain").ToString();
                  //user_username = userdefaults.GetValue("Username").ToString();
                  //user_password = userdefaults.GetValue("Password").ToString();

                  user_console = userdefaults.GetValue("Console").ToString();
                  user_colordepth = userdefaults.GetValue("ColorDepth").ToString();
                  user_audiomode = userdefaults.GetValue("AudioMode").ToString();
                  user_folder = userdefaults.GetValue("Folder").ToString();
                  
                  user_screenresolution = userdefaults.GetValue("ScreenResolution").ToString();
                  user_fullscreen = userdefaults.GetValue("FullScreen").ToString();
                  user_port = userdefaults.GetValue("Port").ToString();
                  user_default_pair = userdefaults.GetValue("Pair").ToString();
                  userdefaults.Close();                  
              }

              RegistryKey userdefaults2 = Registry.CurrentUser.OpenSubKey(common_reg_string + "\\Pairs\\"+user_default_pair);
              if (userdefaults2 != null)
              {
                  user_domain = userdefaults2.GetValue("Domain").ToString();
                  user_username = userdefaults2.GetValue("Username").ToString();
                  user_password = userdefaults2.GetValue("Password").ToString();
                  userdefaults2.Close();
              }
            


          }

          /// <summary>
          /// Загрузка настроек приложения
          /// </summary>
          private static void LoadAppSettings_reg()
          {
              
              RegistryKey appdefaults = Registry.LocalMachine.OpenSubKey(defaults_reg_string);

              if (appdefaults != null)
              {
                  app_console = appdefaults.GetValue("Console").ToString();
                  app_colordepth = appdefaults.GetValue("ColorDepth").ToString();
                  app_audiomode = appdefaults.GetValue("AudioMode").ToString();
                  app_folder = appdefaults.GetValue("Folder").ToString();
                  
                  app_screenresolution = appdefaults.GetValue("ScreenResolution").ToString();
                  app_fullscreen = appdefaults.GetValue("FullScreen").ToString();
                  app_port = appdefaults.GetValue("Port").ToString();
                  
                  appdefaults.Close();                  
              }
           
              
              

          }


          /// <summary>
          /// Загрузка настроек программы и пользовательских настроек из реестра
          /// </summary>
          public static void LoadSettings_reg()
          {
              LoadAppSettings_reg();
              LoadUserSettings_reg();
              
          }


          





          public static void LoadSettings_xml()
          {
          }

          /// <summary>
          /// Проверка места хранения настроек
          /// </summary>
          /// <returns>Если настройки хранятся в файле xml - истина, в реестре - ложь</returns>
          public static bool Check_storage()
          {
              
              if (!File.Exists(Application.StartupPath + "Settings.xml"))
              {
                  File.Create("Settings.xml");                 
                  
              }

              return false;
          }

          public static void WriteSettings_xml()
          {
          }

          public static void ExportSettings()
          {
          }

          /// <summary>
          /// Функция запрашивает у пользователя пароль для расшифровки. Данный пароль используется для расшифровки
          /// паролей к серверам RDP. Поскольку этот пароль используется для шифрования всех паролей RDP, проверяется
          /// корректность введенного пароля. Тестируется расшифровка пароля пользователя по умолчанию
          /// </summary>
          public static void AskPassword()
          {

              SaftRDPClient.Askdialog passdialog = new SaftRDPClient.Askdialog();
              enterp = passdialog.ShowDialogString();
              string def_pass = MyCryptoStat.DecryptString(user_password, enterp);
              DialogResult dr = DialogResult.No;
              if (def_pass == "Trouble!!!")
                  while (def_pass == "Trouble!!!")
                  {
                      dr = MessageBox.Show("Введен неправильный пароль. \n Хотите ввести пароль снова?", "Введен неправильный пароль.", MessageBoxButtons.YesNo);
                        if (dr != DialogResult.Yes)
                        {
                            Environment.Exit(-1);
                        }
                        else
                        {                            
                            enterp = passdialog.ShowDialogString();
                            def_pass = MyCryptoStat.DecryptString(user_password, enterp);
                        }
                  }
                        
          }


          /// <summary>
          /// Загружаются настройки и запрашивается пароль. Для того, чтобы можно было спокойно использовать данные
          /// из этого модуля.
          /// </summary>
          public static void Initialize()
          {
              common_reg_string = "Software\\SafT\\RDPClient";
              defaults_reg_string = common_reg_string+"\\Defaults";
              RegistryKey secur = Registry.CurrentUser.OpenSubKey(common_reg_string);
              if (secur != null)
                  if (secur.GetValue("PasswordChanged").ToString() == "false")
                      {
                      MessageBox.Show("Пароль по умолчанию необходимо заменить!");
                      MyCryptoStat.ChangeCryptPassword();
                      }

              LoadSettings_reg();
              Check_storage();
              AskPassword();
          }
          

      }

      public static class Other
      {
          public static int[] pos_size { get; set; }

          public static int GeneratePairID()
          {
              string[] existing_pairs_s = null;
              int max = 0;
              RegistryKey check = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs");
              existing_pairs_s =  check.GetSubKeyNames();
              if (existing_pairs_s != null)
              {
                  int[] existing_pairs_i = new Int32[existing_pairs_s.Length];
                  for (int i = 0; i < existing_pairs_s.Length; i++)
                      existing_pairs_i[i] = Convert.ToInt32(existing_pairs_s[i]);

                  
                  for (int j = 0; j < existing_pairs_s.Length; j++)
                      if (existing_pairs_i[j] >= max)
                          max = existing_pairs_i[j] + 1;
              }
              return max;
          }

          /// <summary>
          /// Проверка пары на уникальность
          /// </summary>
          /// <param name="uname">Имя пользователя</param>
          /// <param name="upass">Пароль</param>
          /// <param name="udomain">Домен</param>
          /// <returns>-1, если пара уникальна, в противном случае - номер пары</returns>
          public static int CheckUnique(string uname, string upass, string udomain)
          {
              int unique = -1;
                          
              RegistryKey pair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs");
              RegistryKey cur_pair = null;
              string[] pair_names = pair.GetSubKeyNames();
              for (int i = 0; i < pair.SubKeyCount; i++)
              {
                  cur_pair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + pair_names[i]);
                  if (cur_pair.GetValue("Username").ToString() == uname)
                  {
                      if (cur_pair.GetValue("Domain").ToString() == udomain)
                      {
                          if (Common_functions.MyCryptoStat.DecryptString(cur_pair.GetValue("Password").ToString(), Common_functions.Settings.enterp) == upass)
                          {
                              unique = Convert.ToInt32(pair_names[i]);
                              break;
                          }
                      }
                  }
              }
              
              return unique;
          }

          /// <summary>
          /// Функция рассчета размеров окон рдп-клиентов, чтобы уместить их в одном контейнере
          /// </summary>
          /// <param name="count">Количество экранов</param>
          /// <param name="x">Ширина контейнера</param>
          /// <param name="y">Высота контейнера</param>
          /// <returns>Возвращает массив, в котором содержатся координаты количество строк и столбцов, ширина и высота каждого рдп-клиента</returns>
          public static void MultiScreen(int count, int x, int y,int delimiter)
          {
              pos_size = new int[4];
              pos_size[0]=1;
              pos_size[1]=1;
              pos_size[2]=10;
              pos_size[3]=10;
              
              if (count > 0)
              {
                  

                  int delimiter_x_count, delimiter_y_count;
                  int columns = 1, rows = 1;
                  double root, root2;
                  root = System.Math.Sqrt(count);
                  root2 = System.Math.Round(root, 1);
                 
                  string rounder = root2.ToString();
                  if (rounder.Length == 3)
                      rounder = rounder.Remove(2, 1);
                  rounder = rounder.Insert(2, "9");
                 
                  root2 = Convert.ToDouble(rounder);
                  
                  columns = (int)System.Math.Round(root2, 0);
                  
                  rows = (int)System.Math.Round(root, 0, MidpointRounding.AwayFromZero);
                  delimiter_x_count = columns - 1;
                  delimiter_y_count = rows - 1;

                  pos_size[0] = columns;//количество столбцов
                  pos_size[1] = rows;//количество строк
                  pos_size[2] = (int)((x - (delimiter * delimiter_x_count)) / columns);//ширина компонента
                  pos_size[3] = (int)((y - (delimiter * delimiter_y_count)) / rows);//высота компонента              
              }

              //return pos_size;
          }

      }

    }

