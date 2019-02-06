using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace sp
{
    public partial class Sinavlar : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Sinavlar()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
        }
        private void Sinavlar_Load(object sender, EventArgs e)
        {

            //if (Login.Session)
            //{
            baslikhizala();

            //}
            //else
            //{
            //    this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
            //}

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

        #region başlığı Merkeze Oturtma
        public void baslikhizala()
        {
            int x = this.Width / 2 - lblbaslik.Width / 2;
            int y = lblbaslik.Location.Y;
            lblbaslik.Location = new Point(x, y);
        }
        #endregion
        #endregion


    }
}
