namespace SaftRDPClient
{
    partial class Pairs
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.pair_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.apply_btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.is_default = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pair_id,
            this.login,
            this.password,
            this.domain,
            this.apply_btn,
            this.is_default});
            this.Grid.Location = new System.Drawing.Point(1, -2);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(577, 223);
            this.Grid.TabIndex = 0;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grid_EditingControlShowing);
            this.Grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Grid_DataError);
            this.Grid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellEnter);
            // 
            // pair_id
            // 
            this.pair_id.Frozen = true;
            this.pair_id.HeaderText = "Идентификатор пары";
            this.pair_id.Name = "pair_id";
            this.pair_id.ReadOnly = true;
            // 
            // login
            // 
            this.login.Frozen = true;
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            // 
            // password
            // 
            this.password.Frozen = true;
            this.password.HeaderText = "Пароль";
            this.password.Name = "password";
            // 
            // domain
            // 
            this.domain.Frozen = true;
            this.domain.HeaderText = "Домен";
            this.domain.Name = "domain";
            this.domain.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.domain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // apply_btn
            // 
            this.apply_btn.Frozen = true;
            this.apply_btn.HeaderText = "Изменить";
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.ReadOnly = true;
            this.apply_btn.Text = "Изменить";
            // 
            // is_default
            // 
            this.is_default.FalseValue = "false";
            this.is_default.Frozen = true;
            this.is_default.HeaderText = "1";
            this.is_default.IndeterminateValue = "false";
            this.is_default.Name = "is_default";
            this.is_default.ReadOnly = true;
            this.is_default.TrueValue = "true";
            this.is_default.Width = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "По умолчанию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Pairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 251);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Grid);
            this.Name = "Pairs";
            this.Text = "Pairs";
            this.Load += new System.EventHandler(this.Pairs_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pairs_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pair_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewComboBoxColumn domain;
        private System.Windows.Forms.DataGridViewButtonColumn apply_btn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_default;
    }
}