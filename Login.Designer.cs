namespace sp
{
    partial class Login:Tasarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtkod = new System.Windows.Forms.TextBox();
            this.lblkod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.txteposta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonEllipse2 = new sp.ButtonEllipse();
            this.buttonEllipse1 = new sp.ButtonEllipse();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblbaslik.Location = new System.Drawing.Point(224, 226);
            this.lblbaslik.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblbaslik.Size = new System.Drawing.Size(96, 39);
            this.lblbaslik.Text = "GİRİŞ";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(320, 561);
            this.btnkirmizi1.Margin = new System.Windows.Forms.Padding(5);
            this.btnkirmizi1.TabIndex = 5;
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(320, 512);
            this.btnmavi1.Margin = new System.Windows.Forms.Padding(5);
            this.btnmavi1.TabIndex = 4;
            this.btnmavi1.Text = "GİRİŞ";
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // txtkod
            // 
            this.txtkod.BackColor = System.Drawing.Color.White;
            this.txtkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtkod.Location = new System.Drawing.Point(96, 432);
            this.txtkod.Margin = new System.Windows.Forms.Padding(4);
            this.txtkod.MaxLength = 6;
            this.txtkod.Name = "txtkod";
            this.txtkod.Size = new System.Drawing.Size(159, 36);
            this.txtkod.TabIndex = 3;
            this.txtkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtkod_KeyDown);
            // 
            // lblkod
            // 
            this.lblkod.AutoSize = true;
            this.lblkod.Font = new System.Drawing.Font("Arial Black", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblkod.Location = new System.Drawing.Point(309, 432);
            this.lblkod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblkod.Name = "lblkod";
            this.lblkod.Size = new System.Drawing.Size(125, 38);
            this.lblkod.TabIndex = 28;
            this.lblkod.Text = "000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(96, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Güvenlik Kodu: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(96, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Şifre: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(96, 265);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "E posta: ";
            // 
            // txtsifre
            // 
            this.txtsifre.BackColor = System.Drawing.Color.White;
            this.txtsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsifre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtsifre.Location = new System.Drawing.Point(96, 353);
            this.txtsifre.Margin = new System.Windows.Forms.Padding(4);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(340, 36);
            this.txtsifre.TabIndex = 2;
            this.txtsifre.UseSystemPasswordChar = true;
            this.txtsifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsifre_KeyDown);
            // 
            // txteposta
            // 
            this.txteposta.BackColor = System.Drawing.Color.White;
            this.txteposta.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txteposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txteposta.Location = new System.Drawing.Point(101, 286);
            this.txteposta.Margin = new System.Windows.Forms.Padding(4);
            this.txteposta.Name = "txteposta";
            this.txteposta.Size = new System.Drawing.Size(340, 36);
            this.txteposta.TabIndex = 1;
            this.txteposta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txteposta_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(96, 551);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 27);
            this.label5.TabIndex = 31;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::sp.Properties.Resources.nku_logo3;
            this.pictureBox1.Location = new System.Drawing.Point(160, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // buttonEllipse2
            // 
            this.buttonEllipse2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.buttonEllipse2.BackgroundImage = global::sp.Properties.Resources._refresh_55882;
            this.buttonEllipse2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEllipse2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.buttonEllipse2.FlatAppearance.BorderSize = 0;
            this.buttonEllipse2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEllipse2.Location = new System.Drawing.Point(448, 433);
            this.buttonEllipse2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEllipse2.Name = "buttonEllipse2";
            this.buttonEllipse2.Size = new System.Drawing.Size(43, 39);
            this.buttonEllipse2.TabIndex = 32;
            this.buttonEllipse2.UseVisualStyleBackColor = false;
            this.buttonEllipse2.Click += new System.EventHandler(this.buttonEllipse2_Click);
            // 
            // buttonEllipse1
            // 
            this.buttonEllipse1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.buttonEllipse1.BackgroundImage = global::sp.Properties.Resources.closedeye;
            this.buttonEllipse1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEllipse1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.buttonEllipse1.FlatAppearance.BorderSize = 0;
            this.buttonEllipse1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEllipse1.Location = new System.Drawing.Point(448, 354);
            this.buttonEllipse1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEllipse1.Name = "buttonEllipse1";
            this.buttonEllipse1.Size = new System.Drawing.Size(53, 39);
            this.buttonEllipse1.TabIndex = 17;
            this.buttonEllipse1.UseVisualStyleBackColor = false;
            this.buttonEllipse1.Click += new System.EventHandler(this.buttonEllipse1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(524, 625);
            this.Controls.Add(this.buttonEllipse2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtkod);
            this.Controls.Add(this.lblkod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.txteposta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonEllipse1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Login";
            this.Opacity = 0.98D;
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.buttonEllipse1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.txteposta, 0);
            this.Controls.SetChildIndex(this.txtsifre, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblkod, 0);
            this.Controls.SetChildIndex(this.txtkod, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.buttonEllipse2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtkod;
        private System.Windows.Forms.Label lblkod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.TextBox txteposta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ButtonEllipse buttonEllipse1;
        private System.Windows.Forms.Label label5;
        private ButtonEllipse buttonEllipse2;
    }
}