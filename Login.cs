using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace sp
{
    public partial class Login : Tasarim
    {
        #region Yapıcı metot ve Form_Load

        public Login()
        {
            InitializeComponent();


            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
        }
        private void Login_Load_1(object sender, EventArgs e)
        {
            //Güvenlik Kodu
            GuvenlikKodu();
        }
        #endregion

        //Güvenlik Kodu
        public void GuvenlikKodu()
        {
            int rsayi; //guvenlik kodunun tutulduğu yer
            Random r = new Random();
            rsayi = r.Next(100000, 999999);
            lblkod.Text = rsayi.ToString();

        }

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

        #region Formun Sürüklenmesi
        #region Formun Üzerinde Tıklanınca

        private bool mouseDown;
        private Point _start_point = new Point(0, 0);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        #endregion
        #region Menü Üzerinde Tıklanınca

        private void menuStrip2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void menuStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void menuStrip2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
        #endregion

        #region Formu Kapatma ve Küçültme
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void xToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login.Session = false;
            this.Close();
        }

        #endregion

        #region Diğer Formlara Gönderilen Bilgiler

        public static bool Session; // giris kontrolü
        public static byte Yetki;  // Kullanıcı yetkisi
        public static string Ad;// Ad Soyad
        #endregion



        #region Şifreyi Göster Gizle Butonu

        private void buttonEllipse1_Click(object sender, EventArgs e)
        {
            {
                if (txtsifre.UseSystemPasswordChar == true)
                {
                    buttonEllipse1.BackColor = Color.FromArgb(44, 171, 227);
                    txtsifre.UseSystemPasswordChar = false;
                    buttonEllipse1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.openeye));
                }
                else
                {
                    buttonEllipse1.BackColor = Color.FromArgb(255, 82, 82);

                    txtsifre.UseSystemPasswordChar = true;
                    buttonEllipse1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closedeye));
                }

            }
        }
        #endregion

        #region Giriş Butonu

        private void button5_Click(object sender, EventArgs e)
        {

            string eposta = txteposta.Text;
            string sifre = txtsifre.Text;



            //Eposta kontrolü ve girilen eposta uygunsa ana forma giriş yapıldı gönderiyor
            Regex duzenliifade;
            if (txtkod.Text == "" || txteposta.Text == "" || txtsifre.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!");
            }
            else if (txteposta.Text.Trim() != string.Empty)
            {
                duzenliifade = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!duzenliifade.IsMatch(txteposta.Text.Trim()))
                {
                    MessageBox.Show("Hatalı E posta Girişi Yaptınız!");
                    txteposta.Focus();
                    txteposta.SelectAll();
                }
                else
                {
                    if (txtkod.Text == lblkod.Text)
                    {
                        #region Veritabanı Bağlantısı
                        MySqlDataReader rd;
                        VeritabaniIslemler sorgu = new VeritabaniIslemler();
                        label5.Text = "Bağlanıyor...";
                        string komut = "SELECT * FROM OgretimElemani WHERE eposta='" + eposta + "' AND sifre='" + sifre + "';";
                        rd = sorgu.Oku(komut);
                        if (rd.Read())
                        {
                            Yetki = byte.Parse(rd["yetki"].ToString());
                            Session = true;
                            Ad = rd["Ad_Soyad"].ToString();
                            this.Close();


                        }
                        else
                        {
                            label5.Text = "";
                            GuvenlikKodu();
                            MessageBox.Show("E posta ya da şifre yanlış!");
                        }

                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Güvenlik Kodu Girişi");
                        GuvenlikKodu();
                    }

                }

            }
        }


        #endregion

        #region Şifremi Unuttum

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        #endregion

        #region Güvenlik Kodu(Sadece Sayı Girişi)

        private void txtkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Guvenlik Kodu Yenile Butonu

        private void buttonEllipse2_Click(object sender, EventArgs e)
        {
            GuvenlikKodu();
        }
        #endregion

    }
}
