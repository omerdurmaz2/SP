namespace sp
{
    partial class Derslikler:Tasarim
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtkapasite = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Location = new System.Drawing.Point(192, 69);
            this.lblbaslik.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblbaslik.Size = new System.Drawing.Size(160, 27);
            this.lblbaslik.Text = "DERSLİKLER";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Location = new System.Drawing.Point(405, 197);
            this.btnkirmizi1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnkirmizi1.TabIndex = 4;
            this.btnkirmizi1.Click += new System.EventHandler(this.btnkirmizi1_Click);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Location = new System.Drawing.Point(405, 148);
            this.btnmavi1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnmavi1.TabIndex = 3;
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(21, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Derslik Adı: ";
            // 
            // txtad
            // 
            this.txtad.BackColor = System.Drawing.Color.White;
            this.txtad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtad.Location = new System.Drawing.Point(21, 148);
            this.txtad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(127, 36);
            this.txtad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(203, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Kapasite: ";
            // 
            // txtkapasite
            // 
            this.txtkapasite.BackColor = System.Drawing.Color.White;
            this.txtkapasite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkapasite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtkapasite.Location = new System.Drawing.Point(203, 148);
            this.txtkapasite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtkapasite.Name = "txtkapasite";
            this.txtkapasite.Size = new System.Drawing.Size(127, 36);
            this.txtkapasite.TabIndex = 2;
            this.txtkapasite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkapasite_KeyPress);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 246);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(548, 369);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Derslikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(548, 615);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtkapasite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtad);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Derslikler";
            this.Opacity = 0.99D;
            this.Load += new System.EventHandler(this.Derslikler_Load);
            this.Controls.SetChildIndex(this.btnmavi1, 0);
            this.Controls.SetChildIndex(this.btnkirmizi1, 0);
            this.Controls.SetChildIndex(this.lblbaslik, 0);
            this.Controls.SetChildIndex(this.txtad, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtkapasite, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtkapasite;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

