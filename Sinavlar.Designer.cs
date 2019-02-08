namespace sp
{
    partial class Sinavlar:Tasarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sinavlar));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbbolum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbders = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbogretimelemani = new System.Windows.Forms.ComboBox();
            this.lblogretimgorevlisi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbsaat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbderslik1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbderslik2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbderslik3 = new System.Windows.Forms.ComboBox();
            this.lblgozetmen1 = new System.Windows.Forms.Label();
            this.cmbgozetmen1 = new System.Windows.Forms.ComboBox();
            this.gozetmensayisi = new System.Windows.Forms.NumericUpDown();
            this.lblgozetmen2 = new System.Windows.Forms.Label();
            this.cmbgozetmen2 = new System.Windows.Forms.ComboBox();
            this.lblgozetmen3 = new System.Windows.Forms.Label();
            this.cmbgozetmen3 = new System.Windows.Forms.ComboBox();
            this.cmbbolumid = new System.Windows.Forms.ComboBox();
            this.cmbdersid = new System.Windows.Forms.ComboBox();
            this.cmbogretimelemaniid = new System.Windows.Forms.ComboBox();
            this.cmbtarih = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gozetmensayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(432, 48);
            this.lblbaslik.Size = new System.Drawing.Size(104, 22);
            this.lblbaslik.Text = "SINAVLAR";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(96, 496);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(192, 496);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(24, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Gözetmen Sayısı:";
            // 
            // cmbbolum
            // 
            this.cmbbolum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbbolum.FormattingEnabled = true;
            this.cmbbolum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolum.Location = new System.Drawing.Point(24, 168);
            this.cmbbolum.Name = "cmbbolum";
            this.cmbbolum.Size = new System.Drawing.Size(256, 21);
            this.cmbbolum.TabIndex = 70;
            this.cmbbolum.Text = "Seçiniz:";
            this.cmbbolum.SelectedIndexChanged += new System.EventHandler(this.cmbbolum_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label6.Location = new System.Drawing.Point(24, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Bölüm";
            // 
            // cmbders
            // 
            this.cmbders.FormattingEnabled = true;
            this.cmbders.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbders.Location = new System.Drawing.Point(24, 224);
            this.cmbders.Name = "cmbders";
            this.cmbders.Size = new System.Drawing.Size(256, 21);
            this.cmbders.TabIndex = 72;
            this.cmbders.Text = "Seçiniz...";
            this.cmbders.SelectedIndexChanged += new System.EventHandler(this.cmbders_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(24, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Ders:";
            // 
            // cmbogretimelemani
            // 
            this.cmbogretimelemani.FormattingEnabled = true;
            this.cmbogretimelemani.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimelemani.Location = new System.Drawing.Point(24, 280);
            this.cmbogretimelemani.Name = "cmbogretimelemani";
            this.cmbogretimelemani.Size = new System.Drawing.Size(256, 21);
            this.cmbogretimelemani.TabIndex = 74;
            this.cmbogretimelemani.Text = "Seçiniz...";
            this.cmbogretimelemani.SelectedIndexChanged += new System.EventHandler(this.cmbogretimelemani_SelectedIndexChanged);
            // 
            // lblogretimgorevlisi
            // 
            this.lblogretimgorevlisi.AutoSize = true;
            this.lblogretimgorevlisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblogretimgorevlisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblogretimgorevlisi.Location = new System.Drawing.Point(24, 256);
            this.lblogretimgorevlisi.Name = "lblogretimgorevlisi";
            this.lblogretimgorevlisi.Size = new System.Drawing.Size(89, 13);
            this.lblogretimgorevlisi.TabIndex = 75;
            this.lblogretimgorevlisi.Text = "Öğretim Görevlisi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(24, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Sınav Saati:";
            // 
            // cmbsaat
            // 
            this.cmbsaat.FormattingEnabled = true;
            this.cmbsaat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbsaat.Location = new System.Drawing.Point(24, 336);
            this.cmbsaat.Name = "cmbsaat";
            this.cmbsaat.Size = new System.Drawing.Size(88, 21);
            this.cmbsaat.TabIndex = 76;
            this.cmbsaat.Text = "Seçiniz...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label7.Location = new System.Drawing.Point(24, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Derslik 1:";
            // 
            // cmbderslik1
            // 
            this.cmbderslik1.FormattingEnabled = true;
            this.cmbderslik1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbderslik1.Location = new System.Drawing.Point(24, 400);
            this.cmbderslik1.Name = "cmbderslik1";
            this.cmbderslik1.Size = new System.Drawing.Size(80, 21);
            this.cmbderslik1.TabIndex = 76;
            this.cmbderslik1.Text = "Seçiniz...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label8.Location = new System.Drawing.Point(112, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "Derslik 2:";
            // 
            // cmbderslik2
            // 
            this.cmbderslik2.FormattingEnabled = true;
            this.cmbderslik2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbderslik2.Location = new System.Drawing.Point(112, 400);
            this.cmbderslik2.Name = "cmbderslik2";
            this.cmbderslik2.Size = new System.Drawing.Size(80, 21);
            this.cmbderslik2.TabIndex = 76;
            this.cmbderslik2.Text = "Seçiniz...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label9.Location = new System.Drawing.Point(200, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Derslik 3:";
            // 
            // cmbderslik3
            // 
            this.cmbderslik3.FormattingEnabled = true;
            this.cmbderslik3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbderslik3.Location = new System.Drawing.Point(200, 400);
            this.cmbderslik3.Name = "cmbderslik3";
            this.cmbderslik3.Size = new System.Drawing.Size(80, 21);
            this.cmbderslik3.TabIndex = 76;
            this.cmbderslik3.Text = "Seçiniz...";
            // 
            // lblgozetmen1
            // 
            this.lblgozetmen1.AutoSize = true;
            this.lblgozetmen1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblgozetmen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblgozetmen1.Location = new System.Drawing.Point(24, 488);
            this.lblgozetmen1.Name = "lblgozetmen1";
            this.lblgozetmen1.Size = new System.Drawing.Size(64, 13);
            this.lblgozetmen1.TabIndex = 77;
            this.lblgozetmen1.Text = "Gözetmen 1";
            this.lblgozetmen1.Visible = false;
            // 
            // cmbgozetmen1
            // 
            this.cmbgozetmen1.FormattingEnabled = true;
            this.cmbgozetmen1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbgozetmen1.Location = new System.Drawing.Point(24, 512);
            this.cmbgozetmen1.Name = "cmbgozetmen1";
            this.cmbgozetmen1.Size = new System.Drawing.Size(256, 21);
            this.cmbgozetmen1.TabIndex = 76;
            this.cmbgozetmen1.Text = "Seçiniz...";
            this.cmbgozetmen1.Visible = false;
            // 
            // gozetmensayisi
            // 
            this.gozetmensayisi.Location = new System.Drawing.Point(24, 456);
            this.gozetmensayisi.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.gozetmensayisi.Name = "gozetmensayisi";
            this.gozetmensayisi.Size = new System.Drawing.Size(96, 20);
            this.gozetmensayisi.TabIndex = 78;
            this.gozetmensayisi.ValueChanged += new System.EventHandler(this.gozetmensayisi_ValueChanged);
            // 
            // lblgozetmen2
            // 
            this.lblgozetmen2.AutoSize = true;
            this.lblgozetmen2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblgozetmen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblgozetmen2.Location = new System.Drawing.Point(24, 544);
            this.lblgozetmen2.Name = "lblgozetmen2";
            this.lblgozetmen2.Size = new System.Drawing.Size(64, 13);
            this.lblgozetmen2.TabIndex = 77;
            this.lblgozetmen2.Text = "Gözetmen 2";
            this.lblgozetmen2.Visible = false;
            // 
            // cmbgozetmen2
            // 
            this.cmbgozetmen2.FormattingEnabled = true;
            this.cmbgozetmen2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbgozetmen2.Location = new System.Drawing.Point(24, 568);
            this.cmbgozetmen2.Name = "cmbgozetmen2";
            this.cmbgozetmen2.Size = new System.Drawing.Size(256, 21);
            this.cmbgozetmen2.TabIndex = 76;
            this.cmbgozetmen2.Text = "Seçiniz...";
            this.cmbgozetmen2.Visible = false;
            // 
            // lblgozetmen3
            // 
            this.lblgozetmen3.AutoSize = true;
            this.lblgozetmen3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblgozetmen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblgozetmen3.Location = new System.Drawing.Point(24, 600);
            this.lblgozetmen3.Name = "lblgozetmen3";
            this.lblgozetmen3.Size = new System.Drawing.Size(64, 13);
            this.lblgozetmen3.TabIndex = 77;
            this.lblgozetmen3.Text = "Gözetmen 3";
            this.lblgozetmen3.Visible = false;
            // 
            // cmbgozetmen3
            // 
            this.cmbgozetmen3.FormattingEnabled = true;
            this.cmbgozetmen3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbgozetmen3.Location = new System.Drawing.Point(24, 624);
            this.cmbgozetmen3.Name = "cmbgozetmen3";
            this.cmbgozetmen3.Size = new System.Drawing.Size(256, 21);
            this.cmbgozetmen3.TabIndex = 76;
            this.cmbgozetmen3.Text = "Seçiniz...";
            this.cmbgozetmen3.Visible = false;
            // 
            // cmbbolumid
            // 
            this.cmbbolumid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbbolumid.FormattingEnabled = true;
            this.cmbbolumid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolumid.Location = new System.Drawing.Point(56, 144);
            this.cmbbolumid.Name = "cmbbolumid";
            this.cmbbolumid.Size = new System.Drawing.Size(224, 21);
            this.cmbbolumid.TabIndex = 70;
            this.cmbbolumid.Text = "bölüm idsi tutulduğu yer";
            this.cmbbolumid.Visible = false;
            // 
            // cmbdersid
            // 
            this.cmbdersid.FormattingEnabled = true;
            this.cmbdersid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbdersid.Location = new System.Drawing.Point(56, 200);
            this.cmbdersid.Name = "cmbdersid";
            this.cmbdersid.Size = new System.Drawing.Size(224, 21);
            this.cmbdersid.TabIndex = 72;
            this.cmbdersid.Text = "dersidsinin tutulduğu yer";
            this.cmbdersid.Visible = false;
            // 
            // cmbogretimelemaniid
            // 
            this.cmbogretimelemaniid.FormattingEnabled = true;
            this.cmbogretimelemaniid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimelemaniid.Location = new System.Drawing.Point(112, 256);
            this.cmbogretimelemaniid.Name = "cmbogretimelemaniid";
            this.cmbogretimelemaniid.Size = new System.Drawing.Size(168, 21);
            this.cmbogretimelemaniid.TabIndex = 74;
            this.cmbogretimelemaniid.Text = "öğretimelemanlarınınidsitutulduğuyer";
            this.cmbogretimelemaniid.Visible = false;
            this.cmbogretimelemaniid.SelectedIndexChanged += new System.EventHandler(this.cmbogretimelemaniid_SelectedIndexChanged);
            // 
            // cmbtarih
            // 
            this.cmbtarih.FormattingEnabled = true;
            this.cmbtarih.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbtarih.Location = new System.Drawing.Point(24, 112);
            this.cmbtarih.Name = "cmbtarih";
            this.cmbtarih.Size = new System.Drawing.Size(256, 21);
            this.cmbtarih.TabIndex = 80;
            this.cmbtarih.Text = "Seçiniz...";
            this.cmbtarih.SelectedIndexChanged += new System.EventHandler(this.cmbtarih_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Sınav Tarihi:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 688);
            this.dataGridView1.TabIndex = 79;
            // 
            // Sinavlar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.cmbtarih);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gozetmensayisi);
            this.Controls.Add(this.cmbsaat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbderslik3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbderslik2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbderslik1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbgozetmen3);
            this.Controls.Add(this.lblgozetmen3);
            this.Controls.Add(this.cmbgozetmen2);
            this.Controls.Add(this.lblgozetmen2);
            this.Controls.Add(this.cmbgozetmen1);
            this.Controls.Add(this.lblgozetmen1);
            this.Controls.Add(this.cmbogretimelemaniid);
            this.Controls.Add(this.cmbogretimelemani);
            this.Controls.Add(this.lblogretimgorevlisi);
            this.Controls.Add(this.cmbdersid);
            this.Controls.Add(this.cmbders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbbolumid);
            this.Controls.Add(this.cmbbolum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sinavlar";
            this.Opacity = 0.99D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "";
            this.Load += new System.EventHandler(this.Sinavlar_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbbolum, 0);
            this.Controls.SetChildIndex(this.cmbbolumid, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbders, 0);
            this.Controls.SetChildIndex(this.cmbdersid, 0);
            this.Controls.SetChildIndex(this.lblogretimgorevlisi, 0);
            this.Controls.SetChildIndex(this.cmbogretimelemani, 0);
            this.Controls.SetChildIndex(this.cmbogretimelemaniid, 0);
            this.Controls.SetChildIndex(this.lblgozetmen1, 0);
            this.Controls.SetChildIndex(this.cmbgozetmen1, 0);
            this.Controls.SetChildIndex(this.lblgozetmen2, 0);
            this.Controls.SetChildIndex(this.cmbgozetmen2, 0);
            this.Controls.SetChildIndex(this.lblgozetmen3, 0);
            this.Controls.SetChildIndex(this.cmbgozetmen3, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.cmbderslik1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cmbderslik2, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cmbderslik3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbsaat, 0);
            this.Controls.SetChildIndex(this.gozetmensayisi, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbtarih, 0);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gozetmensayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbbolum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbogretimelemani;
        private System.Windows.Forms.Label lblogretimgorevlisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbsaat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbderslik1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbderslik2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbderslik3;
        private System.Windows.Forms.Label lblgozetmen1;
        private System.Windows.Forms.ComboBox cmbgozetmen1;
        private System.Windows.Forms.NumericUpDown gozetmensayisi;
        private System.Windows.Forms.Label lblgozetmen2;
        private System.Windows.Forms.ComboBox cmbgozetmen2;
        private System.Windows.Forms.Label lblgozetmen3;
        private System.Windows.Forms.ComboBox cmbgozetmen3;
        private System.Windows.Forms.ComboBox cmbbolumid;
        private System.Windows.Forms.ComboBox cmbdersid;
        private System.Windows.Forms.ComboBox cmbogretimelemaniid;
        private System.Windows.Forms.ComboBox cmbtarih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

