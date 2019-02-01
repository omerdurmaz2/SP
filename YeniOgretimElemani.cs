using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace sp
{
    public partial class YeniOgretimElemani : Form
    {
        public static bool iptal = false;


        //Connection String
        public string ConnectionString()
        {   //orijinal
            //"server=remotemysql.com; database= tDNQ1XRXlu; uid=tDNQ1XRXlu; pwd=F44eHROJZ1;";

            //test
            //"server=localhost; database= sp_test; uid=root; pwd=root;";
            return "server=remotemysql.com; database= tDNQ1XRXlu; uid=tDNQ1XRXlu; pwd=F44eHROJZ1;";
        }

        #region Kaydet Methodu
        MySqlConnection bag; // Form_Load 'da kullanabilmek için dışarıda tanımladık
        MySqlCommand cmd;// Form_Load 'da kullanabilmek için dışarıda tanımladık
        public void Kaydet(string unvan, string eposta, string adsoyad, string sifre, int yetki, bool islem)
        {

            string komut = "";
            string mesaj = "";
            bag = new MySqlConnection(ConnectionString());
            if (islem)
            {
                komut = "INSERT INTO OgretimElemani (unvan,Ad_Soyad,eposta,Kendi_Sinav_Sayisi,Gozetmenlik_Sayisi,sifre,yetki) VALUES ('" + unvan + "','" + adsoyad + "','" + eposta + "',0,0,'" + sifre + "'," + yetki + ") ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else
            {
                int id = OgretimElemanlari.sessionid;
                komut = "UPDATE OgretimElemani SET unvan = '" + unvan + "' ,Ad_Soyad = '" + adsoyad + "' ,eposta = '" + eposta + "',sifre = '" + sifre + "', yetki = " + yetki + "  WHERE id = " + id + ";";
                mesaj = "Kayıt Güncellendi";

            }

            try
            {
                bag.Open();
                cmd = new MySqlCommand(komut, bag);
                cmd.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show(mesaj);
            }
            catch (Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin" + err.Message, "HATA!!");
            }
        }
        #endregion
        #region Form Kontrol Methodu
        public void FormKontrol(bool islem)
        {
            if (txtunvan.Text == "" || txtsifre.Text == "" || txtadsoyad.Text == "" || txteposta.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
            }
            else
            {
                if (txteposta.Text.Trim() != string.Empty)
                {
                    Regex duzenliifade = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                    if (!duzenliifade.IsMatch(txteposta.Text.Trim()))
                    {
                        MessageBox.Show("Hatalı E posta Girişi Yaptınız!");
                        txteposta.Focus();
                        txteposta.SelectAll();
                    }
                    else
                    {
                        Kaydet(txtunvan.Text, txteposta.Text, txtadsoyad.Text, txtsifre.Text, comboBox1.SelectedIndex, islem);
                        this.Close();
                    }
                }

            }

        }
        #endregion

        #region Yapıcı Metot ve Form_Load

        public YeniOgretimElemani()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi

        }
        private void YeniOgretimElemani_Load(object sender, EventArgs e)
        {
            //session kontrolü
            if (Login.Session)
            {
                if (OgretimElemanlari.sessionid == -1)
                {
                    label3.Text = " YENİ KAYIT";
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    label3.Text = " DÜZENLE";
                    button5.Text = "DEĞİŞTİR";
                    int id = OgretimElemanlari.sessionid;
                    bag = new MySqlConnection(ConnectionString());
                    try
                    {
                        bag.Open();
                        cmd = new MySqlCommand("SELECT * FROM OgretimElemani WHERE id=" + id + ";", bag);
                        MySqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            txtunvan.Text = rd["unvan"].ToString();
                            txtadsoyad.Text = rd["Ad_Soyad"].ToString();
                            txteposta.Text = rd["eposta"].ToString();
                            txtsifre.Text = rd["sifre"].ToString();
                            comboBox1.SelectedIndex = int.Parse(rd["yetki"].ToString());
                            bag.Close();

                        }
                        else
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");
                            this.Close();
                        }

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin" + err, "HATA!!");
                        this.Close();
                    }

                }
            }
            else
            {
                this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
            }


        }
        #endregion

        #region Tasarım için Yapılmış Değişiklikler
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
        #region Menü Butonlarının Hoverı

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Brush arkaplan = new SolidBrush(Color.FromArgb(35, 157, 211));
                    e.Graphics.FillRectangle(arkaplan, rc);
                }
            }
        }
        #endregion

        #endregion
        #region Formun Sürüklenmesi
        #region Formun Üzerinde Tıklanınca

        private bool mouseDown;
        private Point _start_point = new Point(0, 0);

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void Home_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        #endregion
        #region Menü Üzerinde Tıklanınca

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #endregion
        #region Form Küçültme ve Kapatma
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtunvan.Text != "" || txtsifre.Text != "" || txtadsoyad.Text != "" || txteposta.Text != "")
            {
                DialogResult cevap = MessageBox.Show("Formu kapatırsanız yaptığınız değişiklikler kaybedilecek. Çıkmak İstiyor musunuz?", "Uyarı!!!", MessageBoxButtons.YesNo);
                if (cevap==DialogResult.Yes)
                {
                    iptal = true;
                    MessageBox.Show("İşlem İptal Edildi");
                    this.Close();

                }
            }
            else
            {
                this.Close();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Kaydet Butonu

        private void button5_Click(object sender, EventArgs e)
        {
            if (OgretimElemanlari.sessionid == -1)
            {
                FormKontrol(true); //true ise yeni kayıt
            }
            else
            {
                FormKontrol(false); //false ise kayıt düzenleme
            }
        }
        #endregion

    }
}
