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
        private void InitializeComponent()
        {
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
            this.label1 = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.HDDList = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(737, 6);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 23);
            this.button21.TabIndex = 21;
            this.button21.Text = "HDD 2";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // HDDList
            // 
            this.HDDList.FormattingEnabled = true;
            this.HDDList.Location = new System.Drawing.Point(689, 413);
            this.HDDList.Name = "HDDList";
            this.HDDList.Size = new System.Drawing.Size(123, 134);
            this.HDDList.TabIndex = 22;
            this.HDDList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(470, 413);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(213, 134);
            this.listBox1.TabIndex = 28;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // treeView1
            // 
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
            treeNode6.Name = "Sevices";
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
            treeNode31.Name = "Счётчики";
            treeNode31.Text = "Счётчики";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode25,
            treeNode31});
            this.treeView1.Size = new System.Drawing.Size(213, 556);
            this.treeView1.TabIndex = 32;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(824, 559);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.HDDList);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "V";
         //   ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.ListBox HDDList;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
    }
}

