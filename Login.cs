using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data;

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
            baslikhizala();
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

        private void btnmavi1_Click(object sender, EventArgs e)
        {
            string eposta = txteposta.Text.Trim();
            string sifre = txtsifre.Text.Trim();



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
                        VeritabaniIslemler sorgu = new VeritabaniIslemler();
                        label5.Text = "Bağlanıyor...";
                        DataTable dt =new DataTable();
                        string komut = "SELECT * FROM ogretimelemani WHERE eposta='" + eposta + "' AND sifre='" + sifre + "';";
                        dt = sorgu.Al(komut);
                        if (dt==null)
                        {
                            MessageBox.Show("Bağlantı Hatası!\nLütfen İnternet Bağlantınızı Kontrol Edip Tekrar Deneyin.","HATA!");
                            label5.Text="";
                        }
                        else if (dt.Rows.Count!=0)
                        {
                            Yetki = byte.Parse(dt.Rows[0]["yetki"].ToString());
                            Session = true;
                            Ad = dt.Rows[0]["Ad_Soyad"].ToString();
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

        

        #endregion

        #region Guvenlik Kodu Yenile Butonu

        private void buttonEllipse2_Click(object sender, EventArgs e)
        {
            GuvenlikKodu();
        }
        #endregion

        private void txteposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnmavi1_Click(this, new EventArgs());
            }
        }

        private void txtsifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnmavi1_Click(this, new EventArgs());
            }
        }

        private void txtkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnmavi1_Click(this, new EventArgs());
            }
        }
    }
}
