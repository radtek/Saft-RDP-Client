namespace SaftRDPClient
{
    partial class PasswordDialog_frm
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
            this.Passw_TxtBx = new System.Windows.Forms.TextBox();
            this.Hash_lbl = new System.Windows.Forms.Label();
            this.SymbCount_lbl = new System.Windows.Forms.Label();
            this.Accept_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.Passw_TxtBx.Location = new System.Drawing.Point(2, 3);
            this.Passw_TxtBx.Name = "Passw_TxtBx";
            this.Passw_TxtBx.PasswordChar = '+';
            this.Passw_TxtBx.Size = new System.Drawing.Size(219, 20);
            this.Passw_TxtBx.TabIndex = 0;
            this.Passw_TxtBx.TextChanged += new System.EventHandler(this.Passw_TxtBx_TextChanged);
            this.Passw_TxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Passw_TxtBx_KeyPress);
            // 
            // label1
            // 
            this.Hash_lbl.AutoSize = true;
            this.Hash_lbl.Location = new System.Drawing.Point(12, 26);
            this.Hash_lbl.Name = "Hash_lbl";
            this.Hash_lbl.Size = new System.Drawing.Size(26, 13);
            this.Hash_lbl.TabIndex = 1;
            this.Hash_lbl.Text = "Хэш";
            // 
            // label2
            // 
            this.SymbCount_lbl.AutoSize = true;
            this.SymbCount_lbl.Location = new System.Drawing.Point(12, 41);
            this.SymbCount_lbl.Name = "SymbCount_lbl";
            this.SymbCount_lbl.Size = new System.Drawing.Size(117, 13);
            this.SymbCount_lbl.TabIndex = 2;
            this.SymbCount_lbl.Text = "Количество символов";
            // 
            // button1
            // 
            this.Accept_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Accept_btn.Location = new System.Drawing.Point(214, 36);
            this.Accept_btn.Name = "Accept_btn";
            this.Accept_btn.Size = new System.Drawing.Size(75, 23);
            this.Accept_btn.TabIndex = 3;
            this.Accept_btn.Text = "Принять";
            this.Accept_btn.UseVisualStyleBackColor = true;
            this.Accept_btn.Click += new System.EventHandler(this.Accept_btn_Click);
            // 
            // Askdialog
            // 
            this.AcceptButton = this.Accept_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 63);
            this.Controls.Add(this.Accept_btn);
            this.Controls.Add(this.SymbCount_lbl);
            this.Controls.Add(this.Hash_lbl);
            this.Controls.Add(this.Passw_TxtBx);
            this.Name = "PasswordDialog_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Введите пароль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Passw_TxtBx;
        private System.Windows.Forms.Label Hash_lbl;
        private System.Windows.Forms.Label SymbCount_lbl;
        private System.Windows.Forms.Button Accept_btn;
    }
}