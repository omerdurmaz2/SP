namespace sp
{
    
    public partial class Tasarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tasarim));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblbaslik = new System.Windows.Forms.Label();
            this.btnkirmizi1 = new System.Windows.Forms.Button();
            this.btnmavi1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1366, 34);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseUp);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.xToolStripMenuItem.AutoSize = false;
            this.xToolStripMenuItem.AutoToolTip = true;
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xToolStripMenuItem.Image = global::sp.Properties.Resources.close;
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.xToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.xToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.xToolStripMenuItem.Size = new System.Drawing.Size(30, 30);
            this.xToolStripMenuItem.Tag = "Kapat";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Image = global::sp.Properties.Resources.maximize;
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(28, 30);
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripMenuItem1.Image = global::sp.Properties.Resources.minimize2;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 30);
            this.toolStripMenuItem1.Tag = "Küçült";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblbaslik
            // 
            this.lblbaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblbaslik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblbaslik.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblbaslik.Location = new System.Drawing.Point(8, 48);
            this.lblbaslik.Name = "lblbaslik";
            this.lblbaslik.Size = new System.Drawing.Size(161, 22);
            this.lblbaslik.TabIndex = 31;
            this.lblbaslik.Text = "SINAV PROGRAMI";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkirmizi1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkirmizi1.Location = new System.Drawing.Point(8, 120);
            this.btnkirmizi1.Name = "btnkirmizi1";
            this.btnkirmizi1.Size = new System.Drawing.Size(88, 32);
            this.btnkirmizi1.TabIndex = 50;
            this.btnkirmizi1.Text = "İPTAL";
            this.btnkirmizi1.UseVisualStyleBackColor = false;
            this.btnkirmizi1.Visible = false;
            // 
            // btnmavi1
            // 
            this.btnmavi1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmavi1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnmavi1.Location = new System.Drawing.Point(8, 80);
            this.btnmavi1.Name = "btnmavi1";
            this.btnmavi1.Size = new System.Drawing.Size(88, 32);
            this.btnmavi1.TabIndex = 49;
            this.btnmavi1.Text = "EKLE";
            this.btnmavi1.UseVisualStyleBackColor = false;
            // 
            // Tasarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.btnkirmizi1);
            this.Controls.Add(this.btnmavi1);
            this.Controls.Add(this.lblbaslik);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Tasarim";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Tasarim_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tasarim_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tasarim_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tasarim_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        public System.Windows.Forms.Label lblbaslik;
        public System.Windows.Forms.Button btnkirmizi1;
        public System.Windows.Forms.Button btnmavi1;
    }
}

