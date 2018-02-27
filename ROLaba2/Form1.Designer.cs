namespace ROLaba2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_data = new System.Windows.Forms.ListBox();
            this.nUD_k = new System.Windows.Forms.NumericUpDown();
            this.gb_K = new System.Windows.Forms.GroupBox();
            this.cb_chus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_go = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_k)).BeginInit();
            this.gb_K.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_data
            // 
            this.lb_data.FormattingEnabled = true;
            this.lb_data.Location = new System.Drawing.Point(0, 0);
            this.lb_data.Name = "lb_data";
            this.lb_data.Size = new System.Drawing.Size(623, 511);
            this.lb_data.TabIndex = 0;
            // 
            // nUD_k
            // 
            this.nUD_k.Location = new System.Drawing.Point(6, 18);
            this.nUD_k.Name = "nUD_k";
            this.nUD_k.Size = new System.Drawing.Size(104, 20);
            this.nUD_k.TabIndex = 1;
            this.nUD_k.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // gb_K
            // 
            this.gb_K.Controls.Add(this.nUD_k);
            this.gb_K.Location = new System.Drawing.Point(635, 149);
            this.gb_K.Name = "gb_K";
            this.gb_K.Size = new System.Drawing.Size(127, 44);
            this.gb_K.TabIndex = 2;
            this.gb_K.TabStop = false;
            this.gb_K.Text = "К";
            // 
            // cb_chus
            // 
            this.cb_chus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chus.FormattingEnabled = true;
            this.cb_chus.Items.AddRange(new object[] {
            "Простой выбор",
            "Максимин",
            "К средних"});
            this.cb_chus.Location = new System.Drawing.Point(6, 19);
            this.cb_chus.Name = "cb_chus";
            this.cb_chus.Size = new System.Drawing.Size(115, 21);
            this.cb_chus.TabIndex = 3;
            this.cb_chus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_chus);
            this.groupBox1.Location = new System.Drawing.Point(635, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алгоритм";
            // 
            // bt_go
            // 
            this.bt_go.Location = new System.Drawing.Point(641, 200);
            this.bt_go.Name = "bt_go";
            this.bt_go.Size = new System.Drawing.Size(115, 33);
            this.bt_go.TabIndex = 5;
            this.bt_go.Text = "Делай штуки";
            this.bt_go.UseVisualStyleBackColor = true;
            this.bt_go.Click += new System.EventHandler(this.bt_go_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 513);
            this.Controls.Add(this.bt_go);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_K);
            this.Controls.Add(this.lb_data);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nUD_k)).EndInit();
            this.gb_K.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_data;
        private System.Windows.Forms.NumericUpDown nUD_k;
        private System.Windows.Forms.GroupBox gb_K;
        private System.Windows.Forms.ComboBox cb_chus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_go;
    }
}

