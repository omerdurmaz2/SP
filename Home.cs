using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace sp
{

    public partial class Home : Tasarim
    {

        #region Yapıcı Metot ve Form_Load
        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {

            Login giris = new Login();
            giris.ShowDialog(); //anasayfa açıldığında giris ekranını açma
            if (Login.Session == false)
            {
                this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
            }
            else
            {
                if (Login.Yetki != 0)
                {
                    button1.Visible = false;
                    button12.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;

                }
                label1.Text = Login.Ad;
            }
        }
        #endregion

        public static string donem { get; set; }
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


        #region Anasayfaya Geri Dönüldüğünde Bağlanıyor Yazısı Gitmesi İçin

        private void Home_Activated(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
        #endregion

        #region Öğretim Elemanları Sayfası

        private void button12_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            OgretimElemanlari ogr = new OgretimElemanlari();
            ogr.ShowDialog();

        }
        #endregion

        #region Derslikler Sayfası
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Derslikler ders = new Derslikler();
            ders.ShowDialog();
        }
        #endregion

        #region Tarihler Sayfası
        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Tarihler tarih = new Tarihler();
            tarih.ShowDialog();
        }
        #endregion

        #region Bölümler Sayfası
        private void button5_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Bolumler bolum = new Bolumler();
            bolum.ShowDialog();
        }
        #endregion

        #region Dersler Sayfası
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Dersler ders = new Dersler();
            ders.ShowDialog();
        }
        #endregion

        #region Sınav Programı Sayfası
        private void button6_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            SinavProgrami sinav = new SinavProgrami();
            sinav.ShowDialog();
        }
        #endregion

        #region Sınav Saatleri
        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Saatler saat = new Saatler();
            saat.Show();
        }
        #endregion

    }
}
