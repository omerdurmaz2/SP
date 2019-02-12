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
            this.label1 = new System.Windows.Forms.Label();
            this.txtdad = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtdkod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbolum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbdonem = new System.Windows.Forms.ComboBox();
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
            this.btnkirmizi1.Location = new System.Drawing.Point(1000, 104);
            this.btnkirmizi1.Click += new System.EventHandler(this.btnkirmizi1_Click);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(904, 104);
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // lblderskodu
            // 
            this.lblderskodu.AutoSize = true;
            this.lblderskodu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblderskodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblderskodu.Location = new System.Drawing.Point(8, 80);
            this.lblderskodu.Name = "lblderskodu";
            this.lblderskodu.Size = new System.Drawing.Size(60, 13);
            this.lblderskodu.TabIndex = 71;
            this.lblderskodu.Text = "Ders Kodu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(112, 80);
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
            this.txtdad.Location = new System.Drawing.Point(112, 104);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1098, 300);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtdkod
            // 
            this.txtdkod.BackColor = System.Drawing.Color.White;
            this.txtdkod.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdkod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtdkod.Location = new System.Drawing.Point(8, 104);
            this.txtdkod.Name = "txtdkod";
            this.txtdkod.Size = new System.Drawing.Size(96, 30);
            this.txtdkod.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label5.Location = new System.Drawing.Point(376, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Bölüm:";
            // 
            // cmbbolum
            // 
            this.cmbbolum.DropDownHeight = 100;
            this.cmbbolum.FormattingEnabled = true;
            this.cmbbolum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolum.IntegralHeight = false;
            this.cmbbolum.Location = new System.Drawing.Point(376, 104);
            this.cmbbolum.Name = "cmbbolum";
            this.cmbbolum.Size = new System.Drawing.Size(256, 21);
            this.cmbbolum.TabIndex = 5;
            this.cmbbolum.Text = "Seçiniz...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(640, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Dönem:";
            // 
            // cmbdonem
            // 
            this.cmbdonem.FormattingEnabled = true;
            this.cmbdonem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbdonem.Items.AddRange(new object[] {
            "ORTAK",
            "1. Dönem",
            "2. Dönem",
            "3. Dönem",
            "4. Dönem"});
            this.cmbdonem.Location = new System.Drawing.Point(640, 104);
            this.cmbdonem.Name = "cmbdonem";
            this.cmbdonem.Size = new System.Drawing.Size(256, 21);
            this.cmbdonem.TabIndex = 5;
            this.cmbdonem.Text = "Seçiniz...";
            // 
            // Dersler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1098, 448);
            this.Controls.Add(this.lblderskodu);
            this.Controls.Add(this.cmbdonem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbbolum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdkod);
            this.Controls.Add(this.txtdad);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dersler";
            this.Load += new System.EventHandler(this.Dersler_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.txtdad, 0);
            this.Controls.SetChildIndex(this.txtdkod, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbbolum, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbdonem, 0);
            this.Controls.SetChildIndex(this.lblderskodu, 0);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblderskodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdkod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbbolum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbdonem;
    }
}

