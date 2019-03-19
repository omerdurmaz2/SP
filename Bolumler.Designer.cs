namespace sp
{
    partial class Bolumler:Tasarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bolumler));
            this.txtad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbkod = new System.Windows.Forms.TextBox();
            this.txtprogramadi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(181, 69);
            this.lblbaslik.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblbaslik.Size = new System.Drawing.Size(149, 27);
            this.lblbaslik.Text = "BÖLÜMLER";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(1109, 158);
            this.btnkirmizi1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnkirmizi1.TabIndex = 5;
            this.btnkirmizi1.Click += new System.EventHandler(this.btnkirmizi1_Click);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(981, 158);
            this.btnmavi1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnmavi1.TabIndex = 4;
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // txtad
            // 
            this.txtad.BackColor = System.Drawing.Color.White;
            this.txtad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtad.Location = new System.Drawing.Point(11, 158);
            this.txtad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(393, 36);
            this.txtad.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(11, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Bölüm Adı:";
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 210);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1236, 303);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(416, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Program Kodu:";
            // 
            // txtbkod
            // 
            this.txtbkod.BackColor = System.Drawing.Color.White;
            this.txtbkod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbkod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtbkod.Location = new System.Drawing.Point(416, 158);
            this.txtbkod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbkod.Name = "txtbkod";
            this.txtbkod.Size = new System.Drawing.Size(137, 36);
            this.txtbkod.TabIndex = 2;
            // 
            // txtprogramadi
            // 
            this.txtprogramadi.BackColor = System.Drawing.Color.White;
            this.txtprogramadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprogramadi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtprogramadi.Location = new System.Drawing.Point(565, 158);
            this.txtprogramadi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtprogramadi.Name = "txtprogramadi";
            this.txtprogramadi.Size = new System.Drawing.Size(393, 36);
            this.txtprogramadi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Location = new System.Drawing.Point(565, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Program Adı:";
            // 
            // Bolumler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1236, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbkod);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtprogramadi);
            this.Controls.Add(this.txtad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Bolumler";
            this.Opacity = 0.99D;
            this.Load += new System.EventHandler(this.Bolumler_Load);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.txtad, 0);
            this.Controls.SetChildIndex(this.txtprogramadi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.txtbkod, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbkod;
        private System.Windows.Forms.TextBox txtprogramadi;
        private System.Windows.Forms.Label label3;
    }
}

