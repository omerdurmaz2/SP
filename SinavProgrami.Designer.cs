namespace sp
{
    partial class SinavProgrami : Tasarim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbfiltrebolumadi = new System.Windows.Forms.ComboBox();
            this.cmbfiltretarih = new System.Windows.Forms.ComboBox();
            this.cmbfiltreogretimsekli = new System.Windows.Forms.ComboBox();
            this.cmbfiltrebolumkodu = new System.Windows.Forms.ComboBox();
            this.cmbfiltresaat = new System.Windows.Forms.ComboBox();
            this.cmbfiltreogretimgorevlisi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtDisplayPageNo = new System.Windows.Forms.TextBox();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(776, 48);
            this.lblbaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(1105, 32);
            this.btnkirmizi1.Margin = new System.Windows.Forms.Padding(4);
            this.btnkirmizi1.TabIndex = 8;
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(8, 40);
            this.btnmavi1.Margin = new System.Windows.Forms.Padding(4);
            this.btnmavi1.TabIndex = 9;
            this.btnmavi1.Text = "YAZDIR";
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 52;
            this.label1.Text = "FİLTRELE: ";
            // 
            // cmbfiltrebolumadi
            // 
            this.cmbfiltrebolumadi.DropDownHeight = 100;
            this.cmbfiltrebolumadi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltrebolumadi.FormattingEnabled = true;
            this.cmbfiltrebolumadi.IntegralHeight = false;
            this.cmbfiltrebolumadi.Location = new System.Drawing.Point(96, 24);
            this.cmbfiltrebolumadi.Name = "cmbfiltrebolumadi";
            this.cmbfiltrebolumadi.Size = new System.Drawing.Size(152, 21);
            this.cmbfiltrebolumadi.TabIndex = 1;
            this.cmbfiltrebolumadi.SelectedIndexChanged += new System.EventHandler(this.cmbfiltrebolumadi_SelectedIndexChanged);
            // 
            // cmbfiltretarih
            // 
            this.cmbfiltretarih.DropDownHeight = 100;
            this.cmbfiltretarih.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltretarih.FormattingEnabled = true;
            this.cmbfiltretarih.IntegralHeight = false;
            this.cmbfiltretarih.Items.AddRange(new object[] {
            "Hepsi"});
            this.cmbfiltretarih.Location = new System.Drawing.Point(640, 24);
            this.cmbfiltretarih.Name = "cmbfiltretarih";
            this.cmbfiltretarih.Size = new System.Drawing.Size(136, 21);
            this.cmbfiltretarih.TabIndex = 5;
            this.cmbfiltretarih.SelectedIndexChanged += new System.EventHandler(this.cmbfiltretarih_SelectedIndexChanged);
            // 
            // cmbfiltreogretimsekli
            // 
            this.cmbfiltreogretimsekli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltreogretimsekli.FormattingEnabled = true;
            this.cmbfiltreogretimsekli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbfiltreogretimsekli.Items.AddRange(new object[] {
            "Hepsi",
            "G",
            "IO"});
            this.cmbfiltreogretimsekli.Location = new System.Drawing.Point(352, 24);
            this.cmbfiltreogretimsekli.Name = "cmbfiltreogretimsekli";
            this.cmbfiltreogretimsekli.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltreogretimsekli.TabIndex = 3;
            this.cmbfiltreogretimsekli.SelectedIndexChanged += new System.EventHandler(this.cmbfiltreogretimsekli_SelectedIndexChanged);
            // 
            // cmbfiltrebolumkodu
            // 
            this.cmbfiltrebolumkodu.DropDownHeight = 100;
            this.cmbfiltrebolumkodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltrebolumkodu.FormattingEnabled = true;
            this.cmbfiltrebolumkodu.IntegralHeight = false;
            this.cmbfiltrebolumkodu.Items.AddRange(new object[] {
            "Hepsi"});
            this.cmbfiltrebolumkodu.Location = new System.Drawing.Point(256, 24);
            this.cmbfiltrebolumkodu.Name = "cmbfiltrebolumkodu";
            this.cmbfiltrebolumkodu.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltrebolumkodu.TabIndex = 2;
            this.cmbfiltrebolumkodu.Tag = "";
            this.cmbfiltrebolumkodu.SelectedIndexChanged += new System.EventHandler(this.cmbfiltrebolumkodu_SelectedIndexChanged);
            // 
            // cmbfiltresaat
            // 
            this.cmbfiltresaat.DropDownHeight = 100;
            this.cmbfiltresaat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltresaat.FormattingEnabled = true;
            this.cmbfiltresaat.IntegralHeight = false;
            this.cmbfiltresaat.Items.AddRange(new object[] {
            "Hepsi"});
            this.cmbfiltresaat.Location = new System.Drawing.Point(784, 24);
            this.cmbfiltresaat.Name = "cmbfiltresaat";
            this.cmbfiltresaat.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltresaat.TabIndex = 6;
            this.cmbfiltresaat.SelectedIndexChanged += new System.EventHandler(this.cmbfiltresaat_SelectedIndexChanged);
            // 
            // cmbfiltreogretimgorevlisi
            // 
            this.cmbfiltreogretimgorevlisi.DropDownHeight = 100;
            this.cmbfiltreogretimgorevlisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltreogretimgorevlisi.FormattingEnabled = true;
            this.cmbfiltreogretimgorevlisi.IntegralHeight = false;
            this.cmbfiltreogretimgorevlisi.Items.AddRange(new object[] {
            "Hepsi"});
            this.cmbfiltreogretimgorevlisi.Location = new System.Drawing.Point(448, 24);
            this.cmbfiltreogretimgorevlisi.Name = "cmbfiltreogretimgorevlisi";
            this.cmbfiltreogretimgorevlisi.Size = new System.Drawing.Size(184, 21);
            this.cmbfiltreogretimgorevlisi.TabIndex = 4;
            this.cmbfiltreogretimgorevlisi.SelectedIndexChanged += new System.EventHandler(this.cmbfiltreogretimgorevlisi_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(64, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 22);
            this.label2.TabIndex = 52;
            this.label2.Text = "ÖĞRETİM GÖREVLİLERİ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(875, 24);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 18);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Filtreleri Temizle";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Location = new System.Drawing.Point(0, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1297, 491);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(304, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 491);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(301, 491);
            this.dataGridView2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbfiltresaat);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbfiltrebolumadi);
            this.panel2.Controls.Add(this.cmbfiltrebolumkodu);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.cmbfiltretarih);
            this.panel2.Controls.Add(this.cmbfiltreogretimgorevlisi);
            this.panel2.Controls.Add(this.cmbfiltreogretimsekli);
            this.panel2.Location = new System.Drawing.Point(304, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 56);
            this.panel2.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, -2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Bölüm adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Bölüm kodu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Öğretim Şekli:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, -2);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Öğretim Görevlisi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Sınav Tarihi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(784, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Sınav Saati";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPreviousPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPreviousPage.Location = new System.Drawing.Point(96, 8);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(66, 21);
            this.btnPreviousPage.TabIndex = 61;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNextPage.Location = new System.Drawing.Point(832, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(66, 21);
            this.btnNextPage.TabIndex = 60;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayPageNo.Enabled = false;
            this.txtDisplayPageNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtDisplayPageNo.Location = new System.Drawing.Point(456, 8);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.Size = new System.Drawing.Size(152, 21);
            this.txtDisplayPageNo.TabIndex = 59;
            this.txtDisplayPageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLastPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.btnLastPage.FlatAppearance.BorderSize = 0;
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLastPage.Location = new System.Drawing.Point(920, 8);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(62, 21);
            this.btnLastPage.TabIndex = 58;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFirstPage.Location = new System.Drawing.Point(8, 8);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(66, 21);
            this.btnFirstPage.TabIndex = 57;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnFirstPage);
            this.panel3.Controls.Add(this.btnLastPage);
            this.panel3.Controls.Add(this.txtDisplayPageNo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPreviousPage);
            this.panel3.Location = new System.Drawing.Point(304, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(992, 32);
            this.panel3.TabIndex = 62;
            // 
            // SinavProgrami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 669);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SinavProgrami";
            this.Text = "SinavProgrami";
            this.Load += new System.EventHandler(this.SinavProgrami_Load);
            this.Shown += new System.EventHandler(this.SinavProgrami_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SinavProgrami_MouseDown);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbfiltrebolumadi;
        private System.Windows.Forms.ComboBox cmbfiltretarih;
        private System.Windows.Forms.ComboBox cmbfiltreogretimsekli;
        private System.Windows.Forms.ComboBox cmbfiltrebolumkodu;
        private System.Windows.Forms.ComboBox cmbfiltresaat;
        private System.Windows.Forms.ComboBox cmbfiltreogretimgorevlisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TextBox txtDisplayPageNo;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Panel panel3;
    }
}