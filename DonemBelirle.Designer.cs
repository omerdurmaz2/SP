namespace sp
{
    partial class DonemBelirle:Tasarim
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
            this.SuspendLayout();
            // 
            // lblbaslik
            // 
            this.lblbaslik.Text = "DÖNEMİ SEÇİNİZ";
            // 
            // btnkirmizi1
            // 
            this.btnkirmizi1.FlatAppearance.BorderSize = 0;
            this.btnkirmizi1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnkirmizi1.ForeColor = System.Drawing.Color.White;
            this.btnkirmizi1.Location = new System.Drawing.Point(8, 192);
            this.btnkirmizi1.Size = new System.Drawing.Size(280, 104);
            this.btnkirmizi1.Text = "BAHAR";
            this.btnkirmizi1.Visible = true;
            this.btnkirmizi1.Click += new System.EventHandler(this.btnkirmizi1_Click);
            // 
            // btnmavi1
            // 
            this.btnmavi1.FlatAppearance.BorderSize = 0;
            this.btnmavi1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnmavi1.ForeColor = System.Drawing.Color.White;
            this.btnmavi1.Size = new System.Drawing.Size(280, 104);
            this.btnmavi1.Text = "GÜZ";
            this.btnmavi1.Click += new System.EventHandler(this.btnmavi1_Click);
            // 
            // DonemBelirle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "DonemBelirle";
            this.Text = "DonemBelirle";
            this.Load += new System.EventHandler(this.DonemBelirle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}