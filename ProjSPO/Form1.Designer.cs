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
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Проверка интернет");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Тест");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Счётчики", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28});
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
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiniReal = new System.Windows.Forms.ToolStripMenuItem();
            this.TestBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MinimizeFrm = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowFrm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseFrm = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 11);
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
            treeNode27.Name = "Проверка интернет";
            treeNode27.Text = "Проверка интернет";
            treeNode28.Name = "Тест";
            treeNode28.Text = "Тест";
            treeNode29.ImageKey = "(по умолчанию)";
            treeNode29.Name = "Счётчики";
            treeNode29.Text = "Счётчики";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode25,
            treeNode29});
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
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(207, 145);
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
            this.dataGridView1.Size = new System.Drawing.Size(623, 455);
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
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 36;
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Процессор";
            this.performanceCounter1.CounterName = "% загруженности процессора";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Black;
            this.zedGraphControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl1.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.IsShowCopyMessage = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(207, 27);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(290, 112);
            this.zedGraphControl1.TabIndex = 38;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zedGraphControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zedGraphControl2.IsEnableHZoom = false;
            this.zedGraphControl2.IsEnableVZoom = false;
            this.zedGraphControl2.IsShowContextMenu = false;
            this.zedGraphControl2.Location = new System.Drawing.Point(501, 27);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0;
            this.zedGraphControl2.ScrollMaxX = 0;
            this.zedGraphControl2.ScrollMaxY = 0;
            this.zedGraphControl2.ScrollMaxY2 = 0;
            this.zedGraphControl2.ScrollMinX = 0;
            this.zedGraphControl2.ScrollMinY = 0;
            this.zedGraphControl2.ScrollMinY2 = 0;
            this.zedGraphControl2.Size = new System.Drawing.Size(290, 112);
            this.zedGraphControl2.TabIndex = 39;
            // 
            // performanceCounter2
            // 
            this.performanceCounter2.CategoryName = "Память";
            this.performanceCounter2.CounterName = "% использования выделенной памяти";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DblClkNt);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiniReal,
            this.TestBtn,
            this.toolStripSeparator1,
            this.MinimizeFrm,
            this.ShowFrm,
            this.toolStripSeparator2,
            this.CloseFrm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 126);
            // 
            // MiniReal
            // 
            this.MiniReal.Image = global::ProjSPO.Properties.Resources.Doc_destroy;
            this.MiniReal.Name = "MiniReal";
            this.MiniReal.Size = new System.Drawing.Size(148, 22);
            this.MiniReal.Text = "Мини панель";
            this.MiniReal.Click += new System.EventHandler(this.MiniReal_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Image = global::ProjSPO.Properties.Resources.QT_destroy;
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(148, 22);
            this.TestBtn.Text = "Тест";
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // MinimizeFrm
            // 
            this.MinimizeFrm.Image = global::ProjSPO.Properties.Resources.Nero_destroy;
            this.MinimizeFrm.Name = "MinimizeFrm";
            this.MinimizeFrm.Size = new System.Drawing.Size(148, 22);
            this.MinimizeFrm.Text = "Свернуть";
            this.MinimizeFrm.Click += new System.EventHandler(this.MinimizeFrm_Click);
            // 
            // ShowFrm
            // 
            this.ShowFrm.Image = global::ProjSPO.Properties.Resources.Xnview_destroy;
            this.ShowFrm.Name = "ShowFrm";
            this.ShowFrm.Size = new System.Drawing.Size(148, 22);
            this.ShowFrm.Text = "Показать";
            this.ShowFrm.Click += new System.EventHandler(this.ShowFrm_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // CloseFrm
            // 
            this.CloseFrm.Image = global::ProjSPO.Properties.Resources.Panneau_destroy;
            this.CloseFrm.Name = "CloseFrm";
            this.CloseFrm.Size = new System.Drawing.Size(148, 22);
            this.CloseFrm.Text = "Закрыть";
            this.CloseFrm.Click += new System.EventHandler(this.CloseFrm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 607);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 40;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = global::ProjSPO.Properties.Resources.help_destroy;
            this.button1.Location = new System.Drawing.Point(797, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 33);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(127, 26);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(126, 22);
            this.Copy.Text = "Очистить";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(831, 628);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.zedGraphControl1);
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
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
            }
            catch (System.Exception ex) { };
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
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
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Diagnostics.PerformanceCounter performanceCounter2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CloseFrm;
        private System.Windows.Forms.ToolStripMenuItem MinimizeFrm;
        private System.Windows.Forms.ToolStripMenuItem ShowFrm;
        private System.Windows.Forms.ToolStripMenuItem TestBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MiniReal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Copy;
    }
}

