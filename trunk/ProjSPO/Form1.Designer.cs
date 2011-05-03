namespace ProjSPO
{
    partial class Form1
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Рабочий стол");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Идентификация ПК");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Загрузка ОС");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Окружение");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Шрифты");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Службы");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Принтеры");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Программы");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Групповая политика");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Компьютерная система");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Запущенные процессы");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ОС", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("USB");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("CDRom");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Материнская плата");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("IDE контроллер");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("SCSI контроллер");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Видео конфигурация");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Память");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Процессор");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Видеокарта");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("BIOS");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Сетевой адаптер");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Сетевое соеденение");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Устройства", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Температура HDD");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Загрузка ЦП");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Загрузка ОП");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Проверка интернет");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Тест");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Счётчики", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Свойство = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Значение = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 33;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Location = new System.Drawing.Point(1, 1);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "desk";
            treeNode1.Text = "Рабочий стол";
            treeNode2.Name = "Ident";
            treeNode2.Text = "Идентификация ПК";
            treeNode3.Name = "BootOS";
            treeNode3.Text = "Загрузка ОС";
            treeNode4.Name = "env";
            treeNode4.Text = "Окружение";
            treeNode5.Name = "Fonts";
            treeNode5.Text = "Шрифты";
            treeNode6.Name = "Службы";
            treeNode6.Text = "Службы";
            treeNode7.Name = "printers";
            treeNode7.Text = "Принтеры";
            treeNode8.Name = "soft";
            treeNode8.Text = "Программы";
            treeNode9.Name = "Group";
            treeNode9.Text = "Групповая политика";
            treeNode10.Name = "Компьютерная система";
            treeNode10.Text = "Компьютерная система";
            treeNode11.Name = "Запущенные процессы";
            treeNode11.Text = "Запущенные процессы";
            treeNode12.ImageKey = "(по умолчанию)";
            treeNode12.Name = "os";
            treeNode12.Text = "ОС";
            treeNode13.Name = "Usb";
            treeNode13.Text = "USB";
            treeNode14.Name = "cdrom";
            treeNode14.Text = "CDRom";
            treeNode15.Name = "Материнская плата";
            treeNode15.Text = "Материнская плата";
            treeNode16.Name = "IDE контроллер";
            treeNode16.Text = "IDE контроллер";
            treeNode17.Name = "SCSI контроллер";
            treeNode17.Text = "SCSI контроллер";
            treeNode18.Name = "Видео конфигурация";
            treeNode18.Text = "Видео конфигурация";
            treeNode19.Name = "Память";
            treeNode19.Text = "Память";
            treeNode20.Name = "Процессор";
            treeNode20.Text = "Процессор";
            treeNode21.Name = "Видеокарта";
            treeNode21.Text = "Видеокарта";
            treeNode22.Name = "BIOS";
            treeNode22.Text = "BIOS";
            treeNode23.Name = "Сетевой адаптер";
            treeNode23.Text = "Сетевой адаптер";
            treeNode24.Name = "Сетевое соеденение";
            treeNode24.Text = "Сетевое соеденение";
            treeNode25.Name = "devices";
            treeNode25.Text = "Устройства";
            treeNode26.Name = "Температура HDD";
            treeNode26.Text = "Температура HDD";
            treeNode27.Name = "Загрузка ЦП";
            treeNode27.Text = "Загрузка ЦП";
            treeNode28.Name = "Загрузка ОП";
            treeNode28.Text = "Загрузка ОП";
            treeNode29.Name = "Проверка интернет";
            treeNode29.Text = "Проверка интернет";
            treeNode30.Name = "Тест";
            treeNode30.Text = "Тест";
            treeNode31.ImageKey = "(по умолчанию)";
            treeNode31.Name = "Счётчики";
            treeNode31.Text = "Счётчики";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode25,
            treeNode31});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(200, 625);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 32;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "windows.png");
            this.imageList1.Images.SetKeyName(1, "binary.png");
            this.imageList1.Images.SetKeyName(2, "hardwarechip.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Свойство,
            this.Значение});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(207, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(623, 565);
            this.dataGridView1.TabIndex = 34;
            // 
            // Свойство
            // 
            this.Свойство.DividerWidth = 1;
            this.Свойство.Frozen = true;
            this.Свойство.HeaderText = "Свойство";
            this.Свойство.MinimumWidth = 200;
            this.Свойство.Name = "Свойство";
            this.Свойство.ReadOnly = true;
            this.Свойство.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Свойство.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Свойство.Width = 200;
            // 
            // Значение
            // 
            this.Значение.HeaderText = "Значение";
            this.Значение.Name = "Значение";
            this.Значение.ReadOnly = true;
            this.Значение.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Значение.Width = 420;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(797, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 54);
            this.button1.TabIndex = 37;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(831, 628);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мониторинг программно-аппаратной части PC под управлением Windows 7";
            this.Resize += new System.EventHandler(this.ResizeForm);
            this.ResizeEnd += new System.EventHandler(this.ResizeForm);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        //   private System.Windows.Forms.Button button21;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Свойство;
        private System.Windows.Forms.DataGridViewTextBoxColumn Значение;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

