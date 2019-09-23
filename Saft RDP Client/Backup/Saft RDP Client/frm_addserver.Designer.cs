namespace SaftRDPClient
{
    public partial class frm_addserver
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddAndClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHostname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPassw = new System.Windows.Forms.TextBox();
            this.comboBoxDomain = new System.Windows.Forms.ComboBox();
            this.comboBoxFolder = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnJustAdd = new System.Windows.Forms.Button();
            this.btnAddAndConnect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAlias = new System.Windows.Forms.TextBox();
            this.checkBoxConsole = new System.Windows.Forms.CheckBox();
            this.comboBoxSoundMode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddAndClose
            // 
            this.btnAddAndClose.Location = new System.Drawing.Point(252, 144);
            this.btnAddAndClose.Name = "btnAddAndClose";
            this.btnAddAndClose.Size = new System.Drawing.Size(117, 23);
            this.btnAddAndClose.TabIndex = 10;
            this.btnAddAndClose.Text = "Добавить и закрыть";
            this.btnAddAndClose.UseCompatibleTextRendering = true;
            this.btnAddAndClose.UseVisualStyleBackColor = true;
            this.btnAddAndClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Хост";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пароль";
            // 
            // textBoxHostname
            // 
            this.textBoxHostname.Location = new System.Drawing.Point(110, 38);
            this.textBoxHostname.Name = "textBoxHostname";
            this.textBoxHostname.Size = new System.Drawing.Size(121, 20);
            this.textBoxHostname.TabIndex = 1;
            this.textBoxHostname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Домен";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Разрешение";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Цветовая палитра";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "640*480",
            "800*600",
            "1024*768",
            "1280*1024",
            "По размеру окна"});
            this.comboBoxResolution.Location = new System.Drawing.Point(110, 168);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(121, 21);
            this.comboBoxResolution.TabIndex = 6;
            this.comboBoxResolution.Text = "640*480";
            this.comboBoxResolution.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Items.AddRange(new object[] {
            "8",
            "15",
            "16",
            "24",
            "32"});
            this.comboBoxColor.Location = new System.Drawing.Point(110, 142);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColor.TabIndex = 5;
            this.comboBoxColor.Text = "15";
            this.comboBoxColor.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Хэш-код";
            this.label7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label7_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Количество символов";
            this.label8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label8_MouseClick);
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Location = new System.Drawing.Point(110, 90);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.PasswordChar = '+';
            this.textBoxPassw.Size = new System.Drawing.Size(121, 20);
            this.textBoxPassw.TabIndex = 3;
            this.textBoxPassw.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // comboBoxDomain
            // 
            this.comboBoxDomain.FormattingEnabled = true;
            this.comboBoxDomain.Items.AddRange(new object[] {
            "Локальный вход"});
            this.comboBoxDomain.Location = new System.Drawing.Point(110, 116);
            this.comboBoxDomain.Name = "comboBoxDomain";
            this.comboBoxDomain.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDomain.TabIndex = 4;
            this.comboBoxDomain.Text = "holding";
            this.comboBoxDomain.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // comboBoxFolder
            // 
            this.comboBoxFolder.FormattingEnabled = true;
            this.comboBoxFolder.Location = new System.Drawing.Point(110, 195);
            this.comboBoxFolder.Name = "comboBoxFolder";
            this.comboBoxFolder.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFolder.TabIndex = 7;
            this.comboBoxFolder.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            this.comboBoxFolder.DropDown += new System.EventHandler(this.comboBox4_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Папка";
            // 
            // btnJustAdd
            // 
            this.btnJustAdd.Location = new System.Drawing.Point(252, 223);
            this.btnJustAdd.Name = "btnJustAdd";
            this.btnJustAdd.Size = new System.Drawing.Size(117, 23);
            this.btnJustAdd.TabIndex = 12;
            this.btnJustAdd.Text = "Добавить";
            this.btnJustAdd.UseVisualStyleBackColor = true;
            this.btnJustAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddAndConnect
            // 
            this.btnAddAndConnect.Location = new System.Drawing.Point(253, 173);
            this.btnAddAndConnect.Name = "btnAddAndConnect";
            this.btnAddAndConnect.Size = new System.Drawing.Size(116, 47);
            this.btnAddAndConnect.TabIndex = 11;
            this.btnAddAndConnect.Text = "Добавить и соединить";
            this.btnAddAndConnect.UseVisualStyleBackColor = true;
            this.btnAddAndConnect.Click += new System.EventHandler(this.btnAddAndConnect_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(42, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Псевдоним";
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(110, 12);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(121, 20);
            this.textBoxAlias.TabIndex = 0;
            this.textBoxAlias.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // checkBoxConsole
            // 
            this.checkBoxConsole.AutoSize = true;
            this.checkBoxConsole.Location = new System.Drawing.Point(252, 11);
            this.checkBoxConsole.Name = "checkBoxConsole";
            this.checkBoxConsole.Size = new System.Drawing.Size(64, 17);
            this.checkBoxConsole.TabIndex = 9;
            this.checkBoxConsole.Text = "Console";
            this.checkBoxConsole.UseVisualStyleBackColor = true;
            // 
            // comboBoxSoundMode
            // 
            this.comboBoxSoundMode.FormattingEnabled = true;
            this.comboBoxSoundMode.Items.AddRange(new object[] {
            "На этом компьютере",
            "На удаленном компьютере",
            "Не воспроизводить"});
            this.comboBoxSoundMode.Location = new System.Drawing.Point(110, 222);
            this.comboBoxSoundMode.Name = "comboBoxSoundMode";
            this.comboBoxSoundMode.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSoundMode.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Звук";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(110, 63);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUser.TabIndex = 29;
            // 
            // frm_addserver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 254);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxSoundMode);
            this.Controls.Add(this.checkBoxConsole);
            this.Controls.Add(this.textBoxAlias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddAndConnect);
            this.Controls.Add(this.btnJustAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxFolder);
            this.Controls.Add(this.comboBoxDomain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPassw);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxResolution);
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHostname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAndClose);
            this.Name = "frm_addserver";
            this.Text = "Добавление сервера";
            this.Load += new System.EventHandler(this.AddServer_Load);
            this.Click += new System.EventHandler(this.frm_addserver_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAndClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHostname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.ComboBox comboBoxColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPassw;
        private System.Windows.Forms.ComboBox comboBoxDomain;
        private System.Windows.Forms.ComboBox comboBoxFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnJustAdd;
        private System.Windows.Forms.Button btnAddAndConnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.CheckBox checkBoxConsole;
        private System.Windows.Forms.ComboBox comboBoxSoundMode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxUser;
    }
}