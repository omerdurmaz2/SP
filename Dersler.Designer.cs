namespace sp
{
    partial class Dersler:Tasarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dersler));
            this.lblderskodu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbogretmen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdad = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtdkod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbogretimsekli = new System.Windows.Forms.ComboBox();
            this.cmbogretimelemaniid = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbbolumid = new System.Windows.Forms.ComboBox();
            this.cmbbolum = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(528, 48);
            this.lblbaslik.Size = new System.Drawing.Size(96, 22);
            this.lblbaslik.Text = "DERSLER";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(992, 208);
            this.btnkirmizi1.Click += new System.EventHandler(this.btnkirmizi1_Click);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(992, 168);
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // lblderskodu
            // 
            this.lblderskodu.AutoSize = true;
            this.lblderskodu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblderskodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblderskodu.Location = new System.Drawing.Point(344, 88);
            this.lblderskodu.Name = "lblderskodu";
            this.lblderskodu.Size = new System.Drawing.Size(60, 13);
            this.lblderskodu.TabIndex = 71;
            this.lblderskodu.Text = "Ders Kodu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label6.Location = new System.Drawing.Point(672, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Dersi Alacak Bölüm:";
            // 
            // cmbogretmen
            // 
            this.cmbogretmen.FormattingEnabled = true;
            this.cmbogretmen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretmen.Location = new System.Drawing.Point(344, 176);
            this.cmbogretmen.Name = "cmbogretmen";
            this.cmbogretmen.Size = new System.Drawing.Size(256, 21);
            this.cmbogretmen.TabIndex = 5;
            this.cmbogretmen.Text = "Seçiniz...";
            this.cmbogretmen.SelectedIndexChanged += new System.EventHandler(this.cmbogretmen_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(344, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Öğretim Elemanı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(672, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Öğrenci Sayısı:";
            // 
            // txtos
            // 
            this.txtos.BackColor = System.Drawing.Color.White;
            this.txtos.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtos.Location = new System.Drawing.Point(672, 112);
            this.txtos.Name = "txtos";
            this.txtos.Size = new System.Drawing.Size(96, 30);
            this.txtos.TabIndex = 3;
            this.txtos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtos_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Ders Adı: ";
            // 
            // txtdad
            // 
            this.txtdad.BackColor = System.Drawing.Color.White;
            this.txtdad.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtdad.Location = new System.Drawing.Point(16, 112);
            this.txtdad.Name = "txtdad";
            this.txtdad.Size = new System.Drawing.Size(256, 30);
            this.txtdad.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1098, 400);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtdkod
            // 
            this.txtdkod.BackColor = System.Drawing.Color.White;
            this.txtdkod.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdkod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtdkod.Location = new System.Drawing.Point(344, 112);
            this.txtdkod.Name = "txtdkod";
            this.txtdkod.Size = new System.Drawing.Size(256, 30);
            this.txtdkod.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(16, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Öğretim Şekli:";
            // 
            // cmbogretimsekli
            // 
            this.cmbogretimsekli.FormattingEnabled = true;
            this.cmbogretimsekli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimsekli.Items.AddRange(new object[] {
            "G",
            "IO"});
            this.cmbogretimsekli.Location = new System.Drawing.Point(16, 176);
            this.cmbogretimsekli.Name = "cmbogretimsekli";
            this.cmbogretimsekli.Size = new System.Drawing.Size(256, 21);
            this.cmbogretimsekli.TabIndex = 4;
            this.cmbogretimsekli.Text = "Seçiniz...";
            // 
            // cmbogretimelemaniid
            // 
            this.cmbogretimelemaniid.FormattingEnabled = true;
            this.cmbogretimelemaniid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimelemaniid.Location = new System.Drawing.Point(16, 224);
            this.cmbogretimelemaniid.Name = "cmbogretimelemaniid";
            this.cmbogretimelemaniid.Size = new System.Drawing.Size(256, 21);
            this.cmbogretimelemaniid.TabIndex = 4;
            this.cmbogretimelemaniid.Text = "Seçiniz...";
            this.cmbogretimelemaniid.Visible = false;
            this.cmbogretimelemaniid.SelectedIndexChanged += new System.EventHandler(this.cmbogretimelemaniid_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(16, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "ogretimelemaniid";
            this.label3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label7.Location = new System.Drawing.Point(344, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "bolumid";
            this.label7.Visible = false;
            // 
            // cmbbolumid
            // 
            this.cmbbolumid.FormattingEnabled = true;
            this.cmbbolumid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolumid.Location = new System.Drawing.Point(344, 232);
            this.cmbbolumid.Name = "cmbbolumid";
            this.cmbbolumid.Size = new System.Drawing.Size(256, 21);
            this.cmbbolumid.TabIndex = 4;
            this.cmbbolumid.Text = "Seçiniz...";
            this.cmbbolumid.Visible = false;
            this.cmbbolumid.SelectedIndexChanged += new System.EventHandler(this.cmbbolumid_SelectedIndexChanged);
            // 
            // cmbbolum
            // 
            this.cmbbolum.FormattingEnabled = true;
            this.cmbbolum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolum.Location = new System.Drawing.Point(672, 176);
            this.cmbbolum.Name = "cmbbolum";
            this.cmbbolum.Size = new System.Drawing.Size(256, 21);
            this.cmbbolum.TabIndex = 4;
            this.cmbbolum.Text = "Seçiniz...";
            this.cmbbolum.SelectedIndexChanged += new System.EventHandler(this.cmbbolum_SelectedIndexChanged);
            // 
            // Dersler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1098, 660);
            this.Controls.Add(this.lblderskodu);
            this.Controls.Add(this.cmbbolum);
            this.Controls.Add(this.cmbbolumid);
            this.Controls.Add(this.cmbogretimelemaniid);
            this.Controls.Add(this.cmbogretimsekli);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbogretmen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdkod);
            this.Controls.Add(this.txtdad);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dersler";
            this.Opacity = 0.99D;
            this.Load += new System.EventHandler(this.Dersler_Load);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.txtdad, 0);
            this.Controls.SetChildIndex(this.txtdkod, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtos, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbogretmen, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbogretimsekli, 0);
            this.Controls.SetChildIndex(this.cmbogretimelemaniid, 0);
            this.Controls.SetChildIndex(this.cmbbolumid, 0);
            this.Controls.SetChildIndex(this.cmbbolum, 0);
            this.Controls.SetChildIndex(this.lblderskodu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblderskodu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbogretmen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdkod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbogretimsekli;
        private System.Windows.Forms.ComboBox cmbogretimelemaniid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbbolumid;
        private System.Windows.Forms.ComboBox cmbbolum;
    }
}

