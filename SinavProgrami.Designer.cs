﻿namespace sp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbfiltrebolumadi = new System.Windows.Forms.ComboBox();
            this.cmbfiltretarih = new System.Windows.Forms.ComboBox();
            this.cmbfiltreogretimsekli = new System.Windows.Forms.ComboBox();
            this.cmbfiltrebolumkodu = new System.Windows.Forms.ComboBox();
            this.cmbfiltresaat = new System.Windows.Forms.ComboBox();
            this.cmbfiltreogretimgorevlisi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbfiltrebolumid = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(8, 352);
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(1176, 392);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(1272, 392);
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 455);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1366, 313);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 80);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(488, 258);
            this.dataGridView2.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 52;
            this.label1.Text = "FİLTRELE: ";
            // 
            // cmbfiltrebolumadi
            // 
            this.cmbfiltrebolumadi.DropDownHeight = 100;
            this.cmbfiltrebolumadi.FormattingEnabled = true;
            this.cmbfiltrebolumadi.IntegralHeight = false;
            this.cmbfiltrebolumadi.Location = new System.Drawing.Point(96, 408);
            this.cmbfiltrebolumadi.Name = "cmbfiltrebolumadi";
            this.cmbfiltrebolumadi.Size = new System.Drawing.Size(168, 21);
            this.cmbfiltrebolumadi.TabIndex = 53;
            this.cmbfiltrebolumadi.Text = "Bölüm Adı:";
            this.cmbfiltrebolumadi.SelectedIndexChanged += new System.EventHandler(this.cmbfiltrebolumadi_SelectedIndexChanged);
            // 
            // cmbfiltretarih
            // 
            this.cmbfiltretarih.DropDownHeight = 100;
            this.cmbfiltretarih.FormattingEnabled = true;
            this.cmbfiltretarih.IntegralHeight = false;
            this.cmbfiltretarih.Location = new System.Drawing.Point(680, 408);
            this.cmbfiltretarih.Name = "cmbfiltretarih";
            this.cmbfiltretarih.Size = new System.Drawing.Size(136, 21);
            this.cmbfiltretarih.TabIndex = 53;
            this.cmbfiltretarih.Text = "Sınav Tarihi:";
            // 
            // cmbfiltreogretimsekli
            // 
            this.cmbfiltreogretimsekli.FormattingEnabled = true;
            this.cmbfiltreogretimsekli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbfiltreogretimsekli.Items.AddRange(new object[] {
            "G",
            "IO"});
            this.cmbfiltreogretimsekli.Location = new System.Drawing.Point(368, 408);
            this.cmbfiltreogretimsekli.Name = "cmbfiltreogretimsekli";
            this.cmbfiltreogretimsekli.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltreogretimsekli.TabIndex = 54;
            this.cmbfiltreogretimsekli.Text = "Öğretim Şekli";
            // 
            // cmbfiltrebolumkodu
            // 
            this.cmbfiltrebolumkodu.DropDownHeight = 100;
            this.cmbfiltrebolumkodu.FormattingEnabled = true;
            this.cmbfiltrebolumkodu.IntegralHeight = false;
            this.cmbfiltrebolumkodu.Location = new System.Drawing.Point(272, 408);
            this.cmbfiltrebolumkodu.Name = "cmbfiltrebolumkodu";
            this.cmbfiltrebolumkodu.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltrebolumkodu.TabIndex = 53;
            this.cmbfiltrebolumkodu.Text = "Bölüm Kodu";
            // 
            // cmbfiltresaat
            // 
            this.cmbfiltresaat.DropDownHeight = 100;
            this.cmbfiltresaat.FormattingEnabled = true;
            this.cmbfiltresaat.IntegralHeight = false;
            this.cmbfiltresaat.Location = new System.Drawing.Point(824, 408);
            this.cmbfiltresaat.Name = "cmbfiltresaat";
            this.cmbfiltresaat.Size = new System.Drawing.Size(88, 21);
            this.cmbfiltresaat.TabIndex = 53;
            this.cmbfiltresaat.Text = "Sınav Saati:";
            // 
            // cmbfiltreogretimgorevlisi
            // 
            this.cmbfiltreogretimgorevlisi.DropDownHeight = 100;
            this.cmbfiltreogretimgorevlisi.FormattingEnabled = true;
            this.cmbfiltreogretimgorevlisi.IntegralHeight = false;
            this.cmbfiltreogretimgorevlisi.Location = new System.Drawing.Point(464, 408);
            this.cmbfiltreogretimgorevlisi.Name = "cmbfiltreogretimgorevlisi";
            this.cmbfiltreogretimgorevlisi.Size = new System.Drawing.Size(208, 21);
            this.cmbfiltreogretimgorevlisi.TabIndex = 53;
            this.cmbfiltreogretimgorevlisi.Text = "Öğretim Görevlisi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(136, 48);
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
            this.linkLabel1.Location = new System.Drawing.Point(928, 408);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 18);
            this.linkLabel1.TabIndex = 55;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Filtreleri Temizle";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmbfiltrebolumid
            // 
            this.cmbfiltrebolumid.DropDownHeight = 100;
            this.cmbfiltrebolumid.FormattingEnabled = true;
            this.cmbfiltrebolumid.IntegralHeight = false;
            this.cmbfiltrebolumid.Location = new System.Drawing.Point(96, 392);
            this.cmbfiltrebolumid.Name = "cmbfiltrebolumid";
            this.cmbfiltrebolumid.Size = new System.Drawing.Size(168, 21);
            this.cmbfiltrebolumid.TabIndex = 53;
            this.cmbfiltrebolumid.Text = "Bölüm idsi Tutulduğu Yer";
            this.cmbfiltrebolumid.Visible = false;
            // 
            // SinavProgrami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmbfiltreogretimsekli);
            this.Controls.Add(this.cmbfiltresaat);
            this.Controls.Add(this.cmbfiltreogretimgorevlisi);
            this.Controls.Add(this.cmbfiltretarih);
            this.Controls.Add(this.cmbfiltrebolumkodu);
            this.Controls.Add(this.cmbfiltrebolumid);
            this.Controls.Add(this.cmbfiltrebolumadi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SinavProgrami";
            this.Text = "SinavProgrami";
            this.Load += new System.EventHandler(this.SinavProgrami_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.dataGridView2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbfiltrebolumadi, 0);
            this.Controls.SetChildIndex(this.cmbfiltrebolumid, 0);
            this.Controls.SetChildIndex(this.cmbfiltrebolumkodu, 0);
            this.Controls.SetChildIndex(this.cmbfiltretarih, 0);
            this.Controls.SetChildIndex(this.cmbfiltreogretimgorevlisi, 0);
            this.Controls.SetChildIndex(this.cmbfiltresaat, 0);
            this.Controls.SetChildIndex(this.cmbfiltreogretimsekli, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbfiltrebolumadi;
        private System.Windows.Forms.ComboBox cmbfiltretarih;
        private System.Windows.Forms.ComboBox cmbfiltreogretimsekli;
        private System.Windows.Forms.ComboBox cmbfiltrebolumkodu;
        private System.Windows.Forms.ComboBox cmbfiltresaat;
        private System.Windows.Forms.ComboBox cmbfiltreogretimgorevlisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cmbfiltrebolumid;
    }
}