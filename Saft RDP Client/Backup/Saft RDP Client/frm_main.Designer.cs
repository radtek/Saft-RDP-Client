namespace SafTRDPClient
{
    public partial class frm_main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public class treeviewsaft : System.Windows.Forms.TreeView
        {
            /// <summary>
            /// Метод, выполняющий поиск ветки дерева по тексту. Выполняется для отдельно взятой ноды, с заходов во все дочерние ноды.
            /// Поэтому необходимо выполнить для каждой корневой ветки
            /// </summary>
            /// <param name="node">Ветка, в которой надо выполнить поиск</param>
            /// <param name="text">Текст, содержащийся в ветке и который мы ищем</param>
            /// <returns>Возвращает либо пустую ветку, либо нужную ветку. Тип рез-та TreeNode</returns>
            public System.Windows.Forms.TreeNode Find(System.Windows.Forms.TreeNode node,string text)
            {
                System.Windows.Forms.TreeNode nothing = null,something =  null;
                
                if (node.Text == text)
                {
                    return node;
                }
                else
                    if (node.Nodes.Count > 0)
                    {
                        for (int i = 0; i < node.Nodes.Count; i++)
                        {
                            something = Find(node.Nodes[i], text);
                        }
                        return something;
                    }
                    else return nothing;
            }





        }

        

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
     
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСведенияИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСерверовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разорватьСоединениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьССобственнымиПараметрамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстваВыбранногоСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстаПоУмолчаниюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.задатьПарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.местоХраненияПараметровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реестрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.реестрИФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.парыЛогинпарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бесконечныйПингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПроцессовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрСобытийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.службыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиИГруппыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеКомпьютеровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.редактироватьСписокФункцийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rDPБезДобавленияВСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.сменитьПарольДляШифрованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeView1 = new SafTRDPClient.frm_main.treeviewsaft();
            this.FoldersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.соединитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разъединитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.свойстваToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьСерверВГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перенестиВГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.RDPClient = new AxMSTSCLib.AxMsRdpClientNotSafeForScripting();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ServersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.соединитьсяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.свойстваToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.перенестиВГруппуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.FoldersContextMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDPClient)).BeginInit();
            this.ServersContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.toolStripContainer1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 53);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator12,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(155, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(124, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Соединиться";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Разъединить";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Переподключиться";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Удалить сервер";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(795, 4);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(795, 29);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton10,
            this.toolStripSeparator14,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton11});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(147, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Добавить группу";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Удалить группу";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton10.Text = "Переименовать папку";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Добавить сервер";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Удалить сервер";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "Переименовать сервер";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.списокСерверовToolStripMenuItem,
            this.параметрыToolStripMenuItem,
            this.функцииToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.свойстваToolStripMenuItem,
            this.добавитьСведенияИзФайлаToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // свойстваToolStripMenuItem
            // 
            this.свойстваToolStripMenuItem.Name = "свойстваToolStripMenuItem";
            this.свойстваToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.свойстваToolStripMenuItem.Text = "Свойства";
            // 
            // добавитьСведенияИзФайлаToolStripMenuItem
            // 
            this.добавитьСведенияИзФайлаToolStripMenuItem.Name = "добавитьСведенияИзФайлаToolStripMenuItem";
            this.добавитьСведенияИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.добавитьСведенияИзФайлаToolStripMenuItem.Text = "Добавить сведения из файла";
            // 
            // списокСерверовToolStripMenuItem
            // 
            this.списокСерверовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяToolStripMenuItem,
            this.разорватьСоединениеToolStripMenuItem,
            this.toolStripSeparator5,
            this.добавитьToolStripMenuItem,
            this.добавитьССобственнымиПараметрамиToolStripMenuItem,
            this.удалитьИзСпискаToolStripMenuItem,
            this.toolStripSeparator15,
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem});
            this.списокСерверовToolStripMenuItem.Name = "списокСерверовToolStripMenuItem";
            this.списокСерверовToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.списокСерверовToolStripMenuItem.Text = "Список серверов";
            // 
            // подключитьсяToolStripMenuItem
            // 
            this.подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            this.подключитьсяToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.подключитьсяToolStripMenuItem.Text = "Подключиться";
            // 
            // разорватьСоединениеToolStripMenuItem
            // 
            this.разорватьСоединениеToolStripMenuItem.Name = "разорватьСоединениеToolStripMenuItem";
            this.разорватьСоединениеToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.разорватьСоединениеToolStripMenuItem.Text = "Разорвать соединение";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(345, 6);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить с параметрами по умолчанию";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // добавитьССобственнымиПараметрамиToolStripMenuItem
            // 
            this.добавитьССобственнымиПараметрамиToolStripMenuItem.Name = "добавитьССобственнымиПараметрамиToolStripMenuItem";
            this.добавитьССобственнымиПараметрамиToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.добавитьССобственнымиПараметрамиToolStripMenuItem.Text = "Добавить с собственными параметрами";
            this.добавитьССобственнымиПараметрамиToolStripMenuItem.Click += new System.EventHandler(this.добавитьССобственнымиПараметрамиToolStripMenuItem_Click);
            // 
            // удалитьИзСпискаToolStripMenuItem
            // 
            this.удалитьИзСпискаToolStripMenuItem.Name = "удалитьИзСпискаToolStripMenuItem";
            this.удалитьИзСпискаToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.удалитьИзСпискаToolStripMenuItem.Text = "Удалить из списка";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(345, 6);
            // 
            // показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem
            // 
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem.Name = "показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem";
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem.Size = new System.Drawing.Size(348, 22);
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem.Text = "Показать все подключенные сервера в одном окне";
            this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem.Click += new System.EventHandler(this.показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem_Click);
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.свойстваВыбранногоСервераToolStripMenuItem,
            this.свойстаПоУмолчаниюToolStripMenuItem,
            this.toolStripSeparator1,
            this.задатьПарольToolStripMenuItem,
            this.сменитьПарольToolStripMenuItem,
            this.toolStripSeparator2,
            this.местоХраненияПараметровToolStripMenuItem,
            this.toolStripSeparator4,
            this.парыЛогинпарольToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // свойстваВыбранногоСервераToolStripMenuItem
            // 
            this.свойстваВыбранногоСервераToolStripMenuItem.Name = "свойстваВыбранногоСервераToolStripMenuItem";
            this.свойстваВыбранногоСервераToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.свойстваВыбранногоСервераToolStripMenuItem.Text = "Свойства выбранного сервера";
            // 
            // свойстаПоУмолчаниюToolStripMenuItem
            // 
            this.свойстаПоУмолчаниюToolStripMenuItem.Name = "свойстаПоУмолчаниюToolStripMenuItem";
            this.свойстаПоУмолчаниюToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.свойстаПоУмолчаниюToolStripMenuItem.Text = "Свойста по умолчанию";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // задатьПарольToolStripMenuItem
            // 
            this.задатьПарольToolStripMenuItem.Name = "задатьПарольToolStripMenuItem";
            this.задатьПарольToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.задатьПарольToolStripMenuItem.Text = "Задать пароль";
            // 
            // сменитьПарольToolStripMenuItem
            // 
            this.сменитьПарольToolStripMenuItem.Name = "сменитьПарольToolStripMenuItem";
            this.сменитьПарольToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.сменитьПарольToolStripMenuItem.Text = "Сменить пароль";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // местоХраненияПараметровToolStripMenuItem
            // 
            this.местоХраненияПараметровToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.местоХраненияПараметровToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.местоХраненияПараметровToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.реестрToolStripMenuItem,
            this.файлToolStripMenuItem1,
            this.реестрИФайлToolStripMenuItem});
            this.местоХраненияПараметровToolStripMenuItem.Name = "местоХраненияПараметровToolStripMenuItem";
            this.местоХраненияПараметровToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.местоХраненияПараметровToolStripMenuItem.Text = "Место хранения параметров";
            // 
            // реестрToolStripMenuItem
            // 
            this.реестрToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.реестрToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.реестрToolStripMenuItem.Name = "реестрToolStripMenuItem";
            this.реестрToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.реестрToolStripMenuItem.Text = "Реестр";
            // 
            // файлToolStripMenuItem1
            // 
            this.файлToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.файлToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            this.файлToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.файлToolStripMenuItem1.Text = "Файл";
            // 
            // реестрИФайлToolStripMenuItem
            // 
            this.реестрИФайлToolStripMenuItem.Name = "реестрИФайлToolStripMenuItem";
            this.реестрИФайлToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.реестрИФайлToolStripMenuItem.Text = "Реестр и файл";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(238, 6);
            // 
            // парыЛогинпарольToolStripMenuItem
            // 
            this.парыЛогинпарольToolStripMenuItem.Name = "парыЛогинпарольToolStripMenuItem";
            this.парыЛогинпарольToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.парыЛогинпарольToolStripMenuItem.Text = "Пары логин/пароль";
            this.парыЛогинпарольToolStripMenuItem.Click += new System.EventHandler(this.парыЛогинпарольToolStripMenuItem_Click);
            // 
            // функцииToolStripMenuItem
            // 
            this.функцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пингToolStripMenuItem,
            this.бесконечныйПингToolStripMenuItem,
            this.списокПроцессовToolStripMenuItem,
            this.просмотрСобытийToolStripMenuItem,
            this.службыToolStripMenuItem,
            this.пользователиИГруппыToolStripMenuItem,
            this.управлениеКомпьютеровToolStripMenuItem,
            this.toolStripSeparator3,
            this.редактироватьСписокФункцийToolStripMenuItem,
            this.rDPБезДобавленияВСписокToolStripMenuItem,
            this.toolStripSeparator11,
            this.сменитьПарольДляШифрованияToolStripMenuItem});
            this.функцииToolStripMenuItem.Name = "функцииToolStripMenuItem";
            this.функцииToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.функцииToolStripMenuItem.Text = "Функции";
            // 
            // пингToolStripMenuItem
            // 
            this.пингToolStripMenuItem.Name = "пингToolStripMenuItem";
            this.пингToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.пингToolStripMenuItem.Text = "Пинг";
            this.пингToolStripMenuItem.Click += new System.EventHandler(this.пингToolStripMenuItem_Click);
            // 
            // бесконечныйПингToolStripMenuItem
            // 
            this.бесконечныйПингToolStripMenuItem.Name = "бесконечныйПингToolStripMenuItem";
            this.бесконечныйПингToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.бесконечныйПингToolStripMenuItem.Text = "Бесконечный пинг";
            this.бесконечныйПингToolStripMenuItem.Click += new System.EventHandler(this.бесконечныйПингToolStripMenuItem_Click);
            // 
            // списокПроцессовToolStripMenuItem
            // 
            this.списокПроцессовToolStripMenuItem.Name = "списокПроцессовToolStripMenuItem";
            this.списокПроцессовToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.списокПроцессовToolStripMenuItem.Text = "Список процессов";
            // 
            // просмотрСобытийToolStripMenuItem
            // 
            this.просмотрСобытийToolStripMenuItem.Name = "просмотрСобытийToolStripMenuItem";
            this.просмотрСобытийToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.просмотрСобытийToolStripMenuItem.Text = "Просмотр событий";
            this.просмотрСобытийToolStripMenuItem.Click += new System.EventHandler(this.просмотрСобытийToolStripMenuItem_Click);
            // 
            // службыToolStripMenuItem
            // 
            this.службыToolStripMenuItem.Name = "службыToolStripMenuItem";
            this.службыToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.службыToolStripMenuItem.Text = "Службы";
            this.службыToolStripMenuItem.Click += new System.EventHandler(this.службыToolStripMenuItem_Click);
            // 
            // пользователиИГруппыToolStripMenuItem
            // 
            this.пользователиИГруппыToolStripMenuItem.Name = "пользователиИГруппыToolStripMenuItem";
            this.пользователиИГруппыToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.пользователиИГруппыToolStripMenuItem.Text = "Пользователи и группы";
            // 
            // управлениеКомпьютеровToolStripMenuItem
            // 
            this.управлениеКомпьютеровToolStripMenuItem.Name = "управлениеКомпьютеровToolStripMenuItem";
            this.управлениеКомпьютеровToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.управлениеКомпьютеровToolStripMenuItem.Text = "Управление удаленным компьютером";
            this.управлениеКомпьютеровToolStripMenuItem.Click += new System.EventHandler(this.управлениеКомпьютеровToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(275, 6);
            // 
            // редактироватьСписокФункцийToolStripMenuItem
            // 
            this.редактироватьСписокФункцийToolStripMenuItem.Name = "редактироватьСписокФункцийToolStripMenuItem";
            this.редактироватьСписокФункцийToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.редактироватьСписокФункцийToolStripMenuItem.Text = "Редактировать список функций";
            // 
            // rDPБезДобавленияВСписокToolStripMenuItem
            // 
            this.rDPБезДобавленияВСписокToolStripMenuItem.Name = "rDPБезДобавленияВСписокToolStripMenuItem";
            this.rDPБезДобавленияВСписокToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.rDPБезДобавленияВСписокToolStripMenuItem.Text = "RDP без добавления в список";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(275, 6);
            // 
            // сменитьПарольДляШифрованияToolStripMenuItem
            // 
            this.сменитьПарольДляШифрованияToolStripMenuItem.Name = "сменитьПарольДляШифрованияToolStripMenuItem";
            this.сменитьПарольДляШифрованияToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.сменитьПарольДляШифрованияToolStripMenuItem.Text = "Сменить пароль для шифрования";
            this.сменитьПарольДляШифрованияToolStripMenuItem.Click += new System.EventHandler(this.сменитьПарольДляШифрованияToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 533);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 100);
            this.panel2.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Локальный вход"});
            this.comboBox3.Location = new System.Drawing.Point(228, 37);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 17;
            this.comboBox3.Text = "holding";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Домен";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Хэш-код";
            this.label7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label7_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Количество символов";
            this.label6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label6_MouseClick);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(624, 56);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(68, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Консоль";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(624, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(97, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "На весь экран";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label5.Location = new System.Drawing.Point(398, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Разрешение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Цветовая палитра";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(624, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Масштабировать";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "640*480",
            "800*600",
            "1024*768",
            "1280*1024",
            "По размеру окна"});
            this.comboBox2.Location = new System.Drawing.Point(472, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Text = "640*480";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "8",
            "15",
            "16",
            "24",
            "32"});
            this.comboBox1.Location = new System.Drawing.Point(472, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пасс";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '+';
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "safargaliev";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Хост";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "analytic";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(717, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 480);
            this.panel3.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.FoldersContextMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageListTree;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(155, 480);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // FoldersContextMenu
            // 
            this.FoldersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.соединитьсяToolStripMenuItem,
            this.разъединитьToolStripMenuItem,
            this.toolStripSeparator7,
            this.свойстваToolStripMenuItem1,
            this.применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem,
            this.toolStripSeparator6,
            this.добавитьСерверВГруппуToolStripMenuItem,
            this.перенестиВГруппуToolStripMenuItem,
            this.toolStripSeparator8,
            this.переименоватьToolStripMenuItem,
            this.toolStripSeparator13,
            this.удалитьToolStripMenuItem});
            this.FoldersContextMenu.Name = "FoldersContextMenu";
            this.FoldersContextMenu.Size = new System.Drawing.Size(331, 226);
            // 
            // соединитьсяToolStripMenuItem
            // 
            this.соединитьсяToolStripMenuItem.Name = "соединитьсяToolStripMenuItem";
            this.соединитьсяToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.соединитьсяToolStripMenuItem.Text = "Соединиться";
            this.соединитьсяToolStripMenuItem.Click += new System.EventHandler(this.соединитьсяToolStripMenuItem_Click);
            // 
            // разъединитьToolStripMenuItem
            // 
            this.разъединитьToolStripMenuItem.Name = "разъединитьToolStripMenuItem";
            this.разъединитьToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.разъединитьToolStripMenuItem.Text = "Разъединить";
            this.разъединитьToolStripMenuItem.Click += new System.EventHandler(this.разъединитьToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(327, 6);
            // 
            // свойстваToolStripMenuItem1
            // 
            this.свойстваToolStripMenuItem1.Name = "свойстваToolStripMenuItem1";
            this.свойстваToolStripMenuItem1.Size = new System.Drawing.Size(330, 22);
            this.свойстваToolStripMenuItem1.Text = "Свойства";
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(327, 6);
            // 
            // добавитьСерверВГруппуToolStripMenuItem
            // 
            this.добавитьСерверВГруппуToolStripMenuItem.Name = "добавитьСерверВГруппуToolStripMenuItem";
            this.добавитьСерверВГруппуToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.добавитьСерверВГруппуToolStripMenuItem.Text = "Добавить сервер в группу";
            // 
            // перенестиВГруппуToolStripMenuItem
            // 
            this.перенестиВГруппуToolStripMenuItem.Name = "перенестиВГруппуToolStripMenuItem";
            this.перенестиВГруппуToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.перенестиВГруппуToolStripMenuItem.Text = "Перенести в группу";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(327, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.White;
            this.imageListTree.Images.SetKeyName(0, "Dummy.bmp");
            this.imageListTree.Images.SetKeyName(1, "Folder_Closed.bmp");
            this.imageListTree.Images.SetKeyName(2, "Folder_Closed_Selected.bmp");
            this.imageListTree.Images.SetKeyName(3, "Folder_Opened.bmp");
            this.imageListTree.Images.SetKeyName(4, "Folder_Opened_Selected.bmp");
            this.imageListTree.Images.SetKeyName(5, "Server_Disconnected.bmp");
            this.imageListTree.Images.SetKeyName(6, "Server_Disconnected_Selected.bmp");
            this.imageListTree.Images.SetKeyName(7, "Server_Connected.bmp");
            this.imageListTree.Images.SetKeyName(8, "Server_Connected_Selected.bmp");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.RDPClient);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(155, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(640, 480);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGreen;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(640, 480);
            this.panel5.TabIndex = 1;
            this.panel5.Visible = false;
            // 
            // RDPClient
            // 
            this.RDPClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RDPClient.Enabled = true;
            this.RDPClient.Location = new System.Drawing.Point(0, 0);
            this.RDPClient.Name = "RDPClient";
            this.RDPClient.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("RDPClient.OcxState")));
            this.RDPClient.Size = new System.Drawing.Size(640, 480);
            this.RDPClient.TabIndex = 0;
            this.RDPClient.OnConnected += new System.EventHandler(this.RDPClient_OnConnected);
            this.RDPClient.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.RDPClient_OnDisconnected);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "srdp";
            this.openFileDialog1.FileName = "My SaftRDP file";
            this.openFileDialog1.Filter = "Saft RDP(*.srdp)|* .srdp|MS RDP(*.rdp)| *.rdp";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "srdp";
            this.saveFileDialog1.Filter = "SafT RDP(*.srdp) | *.srdp | MS RDP(*.rdp) | *.rdp";
            // 
            // ServersContextMenu
            // 
            this.ServersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.соединитьсяToolStripMenuItem1,
            this.toolStripSeparator9,
            this.свойстваToolStripMenuItem2,
            this.переименоватьToolStripMenuItem1,
            this.toolStripSeparator10,
            this.перенестиВГруппуToolStripMenuItem1,
            this.toolStripSeparator17,
            this.удалитьToolStripMenuItem1});
            this.ServersContextMenu.Name = "SeversContextMenu";
            this.ServersContextMenu.Size = new System.Drawing.Size(187, 132);
            this.ServersContextMenu.Opened += new System.EventHandler(this.ServersContextMenu_Opened);
            // 
            // соединитьсяToolStripMenuItem1
            // 
            this.соединитьсяToolStripMenuItem1.Name = "соединитьсяToolStripMenuItem1";
            this.соединитьсяToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.соединитьсяToolStripMenuItem1.Text = "Соединиться";
            this.соединитьсяToolStripMenuItem1.Click += new System.EventHandler(this.соединитьсяToolStripMenuItem1_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(183, 6);
            // 
            // свойстваToolStripMenuItem2
            // 
            this.свойстваToolStripMenuItem2.Name = "свойстваToolStripMenuItem2";
            this.свойстваToolStripMenuItem2.Size = new System.Drawing.Size(186, 22);
            this.свойстваToolStripMenuItem2.Text = "Свойства";
            this.свойстваToolStripMenuItem2.Click += new System.EventHandler(this.свойстваToolStripMenuItem2_Click);
            // 
            // переименоватьToolStripMenuItem1
            // 
            this.переименоватьToolStripMenuItem1.Name = "переименоватьToolStripMenuItem1";
            this.переименоватьToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.переименоватьToolStripMenuItem1.Text = "Переименовать";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(183, 6);
            // 
            // перенестиВГруппуToolStripMenuItem1
            // 
            this.перенестиВГруппуToolStripMenuItem1.Name = "перенестиВГруппуToolStripMenuItem1";
            this.перенестиВГруппуToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.перенестиВГруппуToolStripMenuItem1.Text = "Перенести в группу";
            this.перенестиВГруппуToolStripMenuItem1.MouseHover += new System.EventHandler(this.перенестиВГруппуToolStripMenuItem1_MouseHover);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(183, 6);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(327, 6);
            // 
            // применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem
            // 
            this.применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem.Name = "применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem";
            this.применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem.Size = new System.Drawing.Size(330, 22);
            this.применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem.Text = "Применить параметры группы ко всем серверам";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(795, 633);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saft RDP Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.CausesValidationChanged += new System.EventHandler(this.frm_main_CausesValidationChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.FoldersContextMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RDPClient)).EndInit();
            this.ServersContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        //public System.Windows.Forms.TreeView treeView1;
        public treeviewsaft treeView1;
        private System.Windows.Forms.Panel panel4;
        private AxMSTSCLib.AxMsRdpClientNotSafeForScripting RDPClient;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойстваВыбранногоСервераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойстаПоУмолчаниюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem задатьПарольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьПарольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСерверовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьССобственнымиПараметрамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзСпискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem функцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пингToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бесконечныйПингToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПроцессовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem службыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеКомпьютеровToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem редактироватьСписокФункцийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местоХраненияПараметровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реестрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem пользователиИГруппыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rDPБезДобавленияВСписокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСведенияИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разорватьСоединениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem парыЛогинпарольToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem реестрИФайлToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem просмотрСобытийToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip FoldersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem соединитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСерверВГруппуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перенестиВГруппуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        public System.Windows.Forms.ContextMenuStrip ServersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem соединитьсяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem перенестиВГруппуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem сменитьПарольДляШифрованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разъединитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem показатьВсеПодключенныеСервераВОдномОкнеToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripMenuItem применитьПараметрыГруппыКоВсемСерверамToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    }
}

