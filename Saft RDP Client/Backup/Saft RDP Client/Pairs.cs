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
    public partial class Pairs : Form
    {
        int[] added_rows = new Int32[0];//список добавленных строк
        

        /// <summary>
        /// Проверка уникальности пары, чтобы избежать дублирования
        /// </summary>
        /// <param name="index">Номер добавляемой строки</param>
        /// <returns>Если пара уникальна - возвращает занчение true</returns>
        private bool CheckUnique(int index)
        {
            bool unique = true;
            bool found_flag = false;
            string username, password, domain;
            username = Grid["login",index].Value.ToString();
            password = Grid["password",index].Value.ToString();
            domain = Grid["domain",index].Value.ToString();

            RegistryKey pair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs");
            RegistryKey cur_pair = null;
            string[] pair_names = pair.GetSubKeyNames();
            for (int i = 0; i < pair.SubKeyCount; i++)
            {
                cur_pair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + pair_names[i]);
                if (cur_pair.GetValue("Username").ToString() == username)
                {
                    if (cur_pair.GetValue("Domain").ToString() == domain)
                    {
                        if (Common_functions.MyCryptoStat.DecryptString(cur_pair.GetValue("Password").ToString(), Common_functions.Settings.enterp) == password)
                        {
                            found_flag = true;
                            break;
                        }
                    }
                }
            }
            if (found_flag == true)
                unique = false;
            return unique;
        }

        /// <summary>
        /// Генерация уникального кода пары "логин-пароль"
        /// </summary>
        /// <param name="add">Код строки, для которой генерируется код</param>
        /// <returns>Код пары</returns>
        private int GeneratePairID(int add)
        {
            int id = 0;
            Random addition = new Random();           
            string date = DateTime.MaxValue.ToString();
            for (int i = 0; i < date.Length; i++)
                id = id + Convert.ToInt32(date[i]);
            id = id + Convert.ToInt32( addition.NextDouble()*100)+add;
            return id;
        }

        /// <summary>
        /// Проверка добавляемой строки на пустые поля
        /// </summary>
        /// <param name="index">Номер строки в списке</param>
        /// <returns>Код ошибки: 
        /// 0 = ошибок нет;
        /// 1 = пустое поле логина;
        /// 2 = пустое поле пароля;
        /// 3 = нет логина и пароля;
        /// 4 = нет домена;
        /// 5 = нет логина и домена;
        /// 6 = нет пароля и домена;
        /// 7 = все поля пусты
        /// </returns>
        private int CheckErrors(int index)
        {
          int errorcode = 0;
          if (index < Grid.RowCount - 1)
          {
              if (Grid["login", index].Value == null)
                  errorcode = 1;
              if (Grid["password", index].Value == null)
                  errorcode = errorcode + 2;
              if (Grid["domain", index].Value == null)
                  errorcode = errorcode + 4;
          }
          else errorcode = -1;
            
          return errorcode;
        }

        /// <summary>
        /// Проверка, сохранены ли добавления в реестр, чтобы избежать проблем с дублированием веток в реестре.
        /// Проверяется только наличие раздела в реестре с соответствующим идентификатором пары.
        /// </summary>
        /// <param name="index">Номер строки списка</param>
        /// <returns>Записана ли строка в реестр</returns>
        private bool Flushed(int index)
        {
            bool result = false;
            RegistryKey flush = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs");
            string[] pairs = flush.GetSubKeyNames();
            flush.Close();
            for (int i = 0; i < pairs.Length; i++)
                if (Grid["pair_id", index].Value.ToString() == pairs[i])
                    result = true;
           /*
            if (result == true)
                MessageBox.Show("Строка " + index.ToString() + " уже есть в реестре");
            else
                MessageBox.Show("Строка " + index.ToString() + " в реестре отсутствует");
            * */
            return result;
        }


        public Pairs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение списка доступных доменов, чтобы пользователь мог выбрать нужный
        /// </summary>
        /// <returns></returns>
        private string[] GetDomainsList()
        {
            string[] domainlist;
            RegistryKey domains = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Domains");
            domainlist = domains.GetValueNames();
            domains.Close();
            return domainlist;

        }

        /// <summary>
        /// Загрузка формы, при этом выполняется заполнение таблицы пар
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pairs_Load(object sender, EventArgs e)
        {
            RegistryKey listkey, pairs,def_pair_reg;
            string pair;
            string[] list;
            listkey = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs");
            list = listkey.GetSubKeyNames();
            listkey.Close();
            


            

            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    pair = "Software\\SafT\\RDPClient\\Pairs\\" + list[i];                
                    pairs = Registry.CurrentUser.OpenSubKey(pair);
                    Grid.RowCount = Grid.RowCount + 1;
                    Grid["pair_id", i].Value = list[i];
                    Grid["login", i].Value = pairs.GetValue("Username").ToString();
                    Grid["password", i].Value = Common_functions.MyCryptoStat.DecryptString(pairs.GetValue("Password").ToString(), Common_functions.Settings.enterp);
                    Grid["domain", i].Value = pairs.GetValue("Domain").ToString();
                    Grid["apply_btn", i].Value = "Заменить";
                    if (Common_functions.Settings.user_default_pair == list[i])
                        Grid["is_default", i].Value = true;
                    
                    /*string cr_pass = Common_functions.MyCryptoStat.EncryptString(Grid["password", i].Value.ToString(),Common_functions.Settings.enterp);
                    if ((Grid["login", i].Value.ToString() == Common_functions.Settings.user_username) && ( cr_pass == Common_functions.Settings.user_password) && (Grid["domain", i].Value.ToString() == Common_functions.Settings.user_domain))
                        Grid["is_default",i].Value = true;
                     */
                    pairs.Close();
                }
            }

            string[] domainlist;
            RegistryKey domains = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Domains");
            domainlist = domains.GetValueNames();
            domains.Close();

            for (int i = 0; i < domainlist.Length; i++)
                try
                {

                    domain.Items.Add(domainlist[i]);
                }

                catch
                {
                    MessageBox.Show(domainlist[i],"Не удается добавить");
                }



        }

        /// <summary>
        /// Обработка ввода текста в комбобокс для самостоятельного указания домена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }


        /// <summary>
        /// Обработка нажатия в ячейке. Используется для добавления сервера в реестр, если нажата кнопка "Добавить" или "Заменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (CheckErrors(e.RowIndex) == 0)
                {
                    if (CheckUnique(e.RowIndex) == true)
                    {
                        RegistryKey pairs = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs", true);
                        pairs.CreateSubKey(Grid["pair_id", e.RowIndex].Value.ToString());
                        pairs.Flush();
                        pairs.Close();
                        pairs = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + Grid["pair_id", e.RowIndex].Value.ToString(), true);
                        pairs.SetValue("Username", Grid["login", e.RowIndex].Value);
                        pairs.SetValue("Password", Common_functions.MyCryptoStat.EncryptString(Grid["password", e.RowIndex].Value.ToString(), Common_functions.Settings.enterp));
                        pairs.SetValue("Domain", Grid["domain", e.RowIndex].Value);
                        pairs.Flush();
                        pairs.Close();
                    }
                    else
                        MessageBox.Show("Пара в строке "+e.RowIndex.ToString()+" уже есть в реестре","Дублирование");
                }
                else
                    switch (CheckErrors(e.RowIndex))
                    {
                        case 1:
                            MessageBox.Show("Не указан логин", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 2:
                            MessageBox.Show("Не указан пароль", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 3:
                            MessageBox.Show("Не указаны логин и пароль", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 4:
                            MessageBox.Show("Не указан домен", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 5:
                            MessageBox.Show("Не указаны логин и домен", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 6:
                            MessageBox.Show("Не указаны пароль и домен", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;

                        case 7:
                            MessageBox.Show("Нет заполнения строки", "Ошибка в строке: " + e.RowIndex.ToString());
                            break;
                    }
            }
        }

    

        /// <summary>
        /// Процедура обработки добавления строки. Если это действительно новая строка, создается индекс и в список добавленных строк вносится номер строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex == Grid.RowCount - 1) && (Grid["pair_id", e.RowIndex].Value == null))
            {
                int[] buf = new Int32[added_rows.Length];
                Grid["pair_id", e.RowIndex].Value = GeneratePairID(e.RowIndex);
                Grid["apply_btn", e.RowIndex].Value = "Добавить";
                buf = added_rows;
                added_rows = new Int32[buf.Length + 1];
                for (int i=0;i<buf.Length;i++)
                    added_rows[i] = buf[i];
                added_rows[added_rows.Length - 1] = e.RowIndex;
                
            }
            
        }

        /// <summary>
        /// Закрытие формы. Все недобавленные строки добавляются в реестр без запроса. Если есть незаполненные строки - закрытие отменяется
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pairs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (added_rows.Length != 0)
            {
                RegistryKey newpairs = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs",true);
                RegistryKey singlepair = null;
                for (int i = 0; i < added_rows.Length; i++)
                {
                    if ((CheckErrors(added_rows[i]) == 0) && (Flushed(added_rows[i]) == false)&&(added_rows[i] != Grid.Rows.Count -1))
                    {
                        singlepair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs", true);
                        singlepair.CreateSubKey(Grid["pair_id", added_rows[i]].Value.ToString());
                        singlepair.Flush();
                        singlepair.Close();
                        singlepair = Registry.CurrentUser.OpenSubKey("Software\\SafT\\RDPClient\\Pairs\\" + Grid["pair_id", added_rows[i]].Value.ToString(), true);
                        singlepair.SetValue("Username", Grid["login", added_rows[i]].Value.ToString());
                        singlepair.SetValue("Password", Common_functions.MyCryptoStat.EncryptString(Grid["password", added_rows[i]].Value.ToString(), Common_functions.Settings.enterp));
                        singlepair.SetValue("Domain", Grid["Domain", added_rows[i]].Value.ToString());
                        singlepair.Flush();
                        singlepair.Close();
                        //MessageBox.Show("Строка " + added_rows[i].ToString() + " добавлена");
                    }
                    else
                        switch (CheckErrors(added_rows[i]))
                        {
                            case 1:
                                MessageBox.Show("Не указан логин", "Ошибка в строке: " + added_rows[i].ToString());
                                e.Cancel = true;
                                break;

                            case 2:
                                MessageBox.Show("Не указан пароль", "Ошибка в строке: " + added_rows[i].ToString());
                                e.Cancel = true;
                                break;

                            case 3:
                                MessageBox.Show("Не указаны логин и пароль", "Ошибка в строке: " + i.ToString());
                                e.Cancel = true;
                                break;

                            case 4:
                                MessageBox.Show("Не указан домен", "Ошибка в строке: " + i.ToString());
                                e.Cancel = true;
                                break;

                            case 5:
                                MessageBox.Show("Не указаны логин и домен", "Ошибка в строке: " + i.ToString());
                                e.Cancel = true;
                                break;

                            case 6:
                                MessageBox.Show("Не указаны пароль и домен", "Ошибка в строке: " + i.ToString());
                                e.Cancel = true;
                                break;

                            case 7:
                                MessageBox.Show("Нет заполнения строки", "Ошибка в строке: " + i.ToString());
                                e.Cancel = true;
                                break;

                            case 0:
                                MessageBox.Show("Строка "+added_rows[i].ToString()+ " уже есть в реестре");
                                break;
                        }
                    
                }
            }
        }

        /// <summary>
        /// Тупо закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Удаление выбранной строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey del_pair = Registry.CurrentUser.OpenSubKey("Software\\Saft\\RDPClient\\Pairs",true);
            RegistryKey check_pair = null;
            int row = Grid.SelectedRows[0].Index;
            int pair_num = Convert.ToInt32(Grid["pair_id", row].Value.ToString());
            
            string[] pairlist = del_pair.GetSubKeyNames();
            for (int i=0;i<pairlist.Length;i++)
                if (pair_num.ToString() == pairlist[i])
                {
                    del_pair.DeleteSubKeyTree(pair_num.ToString());
                    del_pair.Close();
                    Grid.Rows.Clear();
                    Pairs_Load(sender, e);
                    
                }
                else
                {
                    if (row<Grid.RowCount-1)
                        Grid.Rows.RemoveAt(row);
                         
                }
        }

        /// <summary>
        /// Установка выбранной пары по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey default_pair = Registry.CurrentUser.OpenSubKey("Software\\Saft\\RDPClient",true);
            int row = Grid.SelectedRows[0].Index;
            default_pair.SetValue("Username", Grid["login", row].Value.ToString());
            default_pair.Flush();
            default_pair.Close();
            Common_functions.Settings.LoadSettings_reg();
            //Grid.Rows.Clear();
            //Pairs_Load(sender, e);
            for (int i = 0; i < Grid.RowCount - 1; i++)
                Grid["is_default", i].Value = false;
            Grid["is_default", row].Value = true;
            
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString() + " ;"+e.ColumnIndex.ToString() +"\n"+e.Context, "Ошибка DataGrid");
        }


    }
}
