namespace sp
{
    partial class SınavProgramıDüzenleFormu:Tasarim
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
            this.cmbogretimsekli = new System.Windows.Forms.ComboBox();
            this.txtogrencisayisi = new System.Windows.Forms.TextBox();
            this.cmbogretimelemani = new System.Windows.Forms.ComboBox();
            this.lblogretimgorevlisi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbtarih = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsaat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbderslik = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.lblbaslik.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblbaslik.Location = new System.Drawing.Point(8, 9);
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(288, 80);
            this.btnkirmizi1.Size = new System.Drawing.Size(80, 32);
            // 
            // btnmavi1
            // 
            this.btnmavi1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(288, 40);
            this.btnmavi1.Size = new System.Drawing.Size(80, 33);
            this.btnmavi1.Text = "KAYDET";
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            this.btnmavi1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            this.btnmavi1.MouseLeave += new System.EventHandler(this.btnmavi1_MouseLeave);
            this.btnmavi1.MouseHover += new System.EventHandler(this.btnmavi1_MouseHover);
            // 
            // cmbogretimsekli
            // 
            this.cmbogretimsekli.FormattingEnabled = true;
            this.cmbogretimsekli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimsekli.Items.AddRange(new object[] {
            "G",
            "IO"});
            this.cmbogretimsekli.Location = new System.Drawing.Point(8, 80);
            this.cmbogretimsekli.Name = "cmbogretimsekli";
            this.cmbogretimsekli.Size = new System.Drawing.Size(112, 21);
            this.cmbogretimsekli.TabIndex = 112;
            this.cmbogretimsekli.Text = "Seçiniz..";
            this.cmbogretimsekli.Visible = false;
            this.cmbogretimsekli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            // 
            // txtogrencisayisi
            // 
            this.txtogrencisayisi.BackColor = System.Drawing.Color.White;
            this.txtogrencisayisi.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtogrencisayisi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtogrencisayisi.Location = new System.Drawing.Point(8, 112);
            this.txtogrencisayisi.MaxLength = 4;
            this.txtogrencisayisi.Name = "txtogrencisayisi";
            this.txtogrencisayisi.Size = new System.Drawing.Size(88, 30);
            this.txtogrencisayisi.TabIndex = 122;
            this.txtogrencisayisi.Visible = false;
            this.txtogrencisayisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtogrencisayisi_KeyPress);
            // 
            // cmbogretimelemani
            // 
            this.cmbogretimelemani.DropDownHeight = 100;
            this.cmbogretimelemani.FormattingEnabled = true;
            this.cmbogretimelemani.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimelemani.IntegralHeight = false;
            this.cmbogretimelemani.Location = new System.Drawing.Point(8, 216);
            this.cmbogretimelemani.Name = "cmbogretimelemani";
            this.cmbogretimelemani.Size = new System.Drawing.Size(256, 21);
            this.cmbogretimelemani.TabIndex = 123;
            this.cmbogretimelemani.Text = "Seçiniz...";
            this.cmbogretimelemani.Visible = false;
            this.cmbogretimelemani.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            // 
            // lblogretimgorevlisi
            // 
            this.lblogretimgorevlisi.AutoSize = true;
            this.lblogretimgorevlisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblogretimgorevlisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblogretimgorevlisi.Location = new System.Drawing.Point(128, 88);
            this.lblogretimgorevlisi.Name = "lblogretimgorevlisi";
            this.lblogretimgorevlisi.Size = new System.Drawing.Size(84, 13);
            this.lblogretimgorevlisi.TabIndex = 124;
            this.lblogretimgorevlisi.Text = "<< Öğretim Şekli";
            this.lblogretimgorevlisi.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(128, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "<< Öğrenci Sayısı";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(272, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 124;
            this.label2.Text = "<< Öğretim Elemanı";
            this.label2.Visible = false;
            // 
            // cmbtarih
            // 
            this.cmbtarih.DropDownHeight = 100;
            this.cmbtarih.FormattingEnabled = true;
            this.cmbtarih.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbtarih.IntegralHeight = false;
            this.cmbtarih.Location = new System.Drawing.Point(8, 152);
            this.cmbtarih.Name = "cmbtarih";
            this.cmbtarih.Size = new System.Drawing.Size(256, 21);
            this.cmbtarih.TabIndex = 126;
            this.cmbtarih.Text = "Seçiniz...";
            this.cmbtarih.Visible = false;
            this.cmbtarih.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(272, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "<< Sınav Tarihi";
            this.label3.Visible = false;
            // 
            // cmbsaat
            // 
            this.cmbsaat.DropDownHeight = 100;
            this.cmbsaat.FormattingEnabled = true;
            this.cmbsaat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbsaat.IntegralHeight = false;
            this.cmbsaat.Location = new System.Drawing.Point(8, 184);
            this.cmbsaat.Name = "cmbsaat";
            this.cmbsaat.Size = new System.Drawing.Size(112, 21);
            this.cmbsaat.TabIndex = 127;
            this.cmbsaat.Text = "Seçiniz...";
            this.cmbsaat.Visible = false;
            this.cmbsaat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(136, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "<< Sınav Saati";
            this.label4.Visible = false;
            // 
            // cmbderslik
            // 
            this.cmbderslik.FormattingEnabled = true;
            this.cmbderslik.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbderslik.Location = new System.Drawing.Point(8, 248);
            this.cmbderslik.Name = "cmbderslik";
            this.cmbderslik.Size = new System.Drawing.Size(112, 21);
            this.cmbderslik.TabIndex = 128;
            this.cmbderslik.Text = "Seçiniz...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(136, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "<< derslik";
            this.label5.Visible = false;
            // 
            // SınavProgramıDüzenleFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(380, 285);
            this.Controls.Add(this.cmbderslik);
            this.Controls.Add(this.cmbsaat);
            this.Controls.Add(this.cmbtarih);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblogretimgorevlisi);
            this.Controls.Add(this.cmbogretimelemani);
            this.Controls.Add(this.txtogrencisayisi);
            this.Controls.Add(this.cmbogretimsekli);
            this.Name = "SınavProgramıDüzenleFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormOgretimSekli";
            this.Load += new System.EventHandler(this.FormOgretimSekli_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormOgretimSekli_KeyPress);
            this.Controls.SetChildIndex(this.cmbogretimsekli, 0);
            this.Controls.SetChildIndex(this.txtogrencisayisi, 0);
            this.Controls.SetChildIndex(this.cmbogretimelemani, 0);
            this.Controls.SetChildIndex(this.lblogretimgorevlisi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbtarih, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.cmbsaat, 0);
            this.Controls.SetChildIndex(this.cmbderslik, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbogretimsekli;
        private System.Windows.Forms.TextBox txtogrencisayisi;
        private System.Windows.Forms.ComboBox cmbogretimelemani;
        private System.Windows.Forms.Label lblogretimgorevlisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbtarih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsaat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbderslik;
        private System.Windows.Forms.Label label5;
    }
}