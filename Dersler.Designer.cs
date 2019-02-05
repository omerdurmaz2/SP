namespace sp
{
    partial class Dersler
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbbolum = new System.Windows.Forms.ComboBox();
            this.lblderskodu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbogretmen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtdkod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbogretimsekli = new System.Windows.Forms.ComboBox();
            this.cmbogretimelemaniid = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbbolumid = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1098, 36);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseUp);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.xToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.xToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.xToolStripMenuItem.Size = new System.Drawing.Size(31, 32);
            this.xToolStripMenuItem.Tag = "Kapat";
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 32);
            this.toolStripMenuItem1.Tag = "Küçült";
            this.toolStripMenuItem1.Text = "_";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cmbbolum
            // 
            this.cmbbolum.FormattingEnabled = true;
            this.cmbbolum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbbolum.Location = new System.Drawing.Point(672, 176);
            this.cmbbolum.Name = "cmbbolum";
            this.cmbbolum.Size = new System.Drawing.Size(256, 21);
            this.cmbbolum.TabIndex = 6;
            this.cmbbolum.SelectedIndexChanged += new System.EventHandler(this.cmbbolum_SelectedIndexChanged);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(992, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "İPTAL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(992, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "EKLE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(528, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 22);
            this.label9.TabIndex = 63;
            this.label9.Text = "DERSLER";
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
            // 
            // cmbogretimelemaniid
            // 
            this.cmbogretimelemaniid.FormattingEnabled = true;
            this.cmbogretimelemaniid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbogretimelemaniid.Location = new System.Drawing.Point(176, 224);
            this.cmbogretimelemaniid.Name = "cmbogretimelemaniid";
            this.cmbogretimelemaniid.Size = new System.Drawing.Size(256, 21);
            this.cmbogretimelemaniid.TabIndex = 4;
            this.cmbogretimelemaniid.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(176, 208);
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
            this.label7.Location = new System.Drawing.Point(464, 208);
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
            this.cmbbolumid.Location = new System.Drawing.Point(464, 224);
            this.cmbbolumid.Name = "cmbbolumid";
            this.cmbbolumid.Size = new System.Drawing.Size(256, 21);
            this.cmbbolumid.TabIndex = 4;
            this.cmbbolumid.Visible = false;
            // 
            // Dersler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1098, 660);
            this.Controls.Add(this.cmbbolum);
            this.Controls.Add(this.lblderskodu);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dersler";
            this.Opacity = 0.99D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Dersler_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Home_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Home_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbbolum;
        private System.Windows.Forms.Label lblderskodu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbogretmen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdkod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbogretimsekli;
        private System.Windows.Forms.ComboBox cmbogretimelemaniid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbbolumid;
    }
}

