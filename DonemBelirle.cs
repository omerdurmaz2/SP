using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sp
{
    public partial class DonemBelirle : Tasarim
    {
        #region Yapıcı Metod ve Form_Load


        public DonemBelirle()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius  
            yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
                                                //this.WindowState = FormWindowState.Maximized;
            baslikhizala();

        }
        private void DonemBelirle_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region Tasarım İçin Yapılmış Değişiklikler
        #region Köşelerin Yuvarlanması

        //Köşelerin Yuvarlanması 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,     // x-coordinate of upper-left corner
                int nTopRect,      // y-coordinate of upper-left corner
                int nRightRect,    // x-coordinate of lower-right corner
                int nBottomRect,   // y-coordinate of lower-right corner
                int nWidthEllipse, // height of ellipse
                int nHeightEllipse // width of ellipse
            );



        #endregion

        #endregion

        private void btnmavi1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Home.donem = "guz";
            
            this.Close();
        }

        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Home.donem = "bahar";
            this.Close();

        }
    }
}
