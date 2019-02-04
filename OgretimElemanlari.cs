using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace sp
{
    public partial class OgretimElemanlari : Form
    {
        public static int userid = -1; // session olarak duzenlenecek uyenin id sini tutuyor


        #region Yapıcı Metot ve Form_Load

        public OgretimElemanlari()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi


        }
        private void OgretimElemanlari_Load(object sender, EventArgs e)
        {
            //session kontrolü
            if (Login.Session)
            {
                comboBox1.SelectedIndex = 0;
                Listele();
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

        #region Form Küçültme  ve Kapatma
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (txtunvan.Text != "" || txtsifre.Text != "" || txtadsoyad.Text != "" || txteposta.Text != "")
            {
                DialogResult cevap = MessageBox.Show("Kaydedilmemiş ve var! Çıkmak istiyor musunuz ? ", "DİKKAT!", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
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

        #endregion

        #region Tablo Elemanları
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        string komut = "";
        string mesaj = "";
        #endregion

        #region  Ekranı Temizle
        public void Temizle() // textboxları ve butonları temizler
        {
            txtadsoyad.Clear();
            txtsifre.Clear();
            txteposta.Clear();
            txtunvan.Clear();
            comboBox1.SelectedIndex = 0;
            button5.Text = "EKLE";
            userid = -1;
        }
        #endregion

        #region Veritabanından verilerin Çekilip Listelenmesi

        public void Listele()
        {
            dataGridView1.DataSource = null; // datagridview temizlenir
            dataGridView1.Columns.Clear();// datagridview temizlenir
            dataGridView1.Refresh(); // datagridview yenilenir

            komut = "select id as Sıra_No,unvan as Unvan,Ad_Soyad,eposta as E_posta,Kendi_Sinav_Sayisi ,Gozetmenlik_Sayisi from OgretimElemani";
            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut);
                //değiştir butonu her satır için eklenir
                duzenle = new DataGridViewButtonColumn();
                duzenle.HeaderText = "DÜZENLE";
                duzenle.Text = "DÜZENLE";
                duzenle.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(duzenle);

                //sil butonu her satır için eklenir
                sil = new DataGridViewButtonColumn();
                sil.HeaderText = "SİL";
                sil.Text = "SİL";
                sil.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(sil);

            }
            else
            {
                MessageBox.Show("İşlem Gerçekleştirlemedi, Lütfen Sonra Tekrar Deneyin!"); // eğer veritabanı işlemi gerçekleştirilemezse hata verir
                this.Close();
            }


        }
        #endregion

        #region Form Kontrol Methodu
        public void FormKontrol()
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
                        Sorgu();
                    }
                }

            }

        }
        #endregion

        #region Veritabanı E posta Kontrolü
        public void Sorgu()
        {
            komut = "select * from OgretimElemani where eposta='" + txteposta.Text + "' and id <> " + userid + ";";
            if (islemler.Oku(komut).Read())
            {
                MessageBox.Show("Aynı E posta da başka üye bulunmakta. Lütfen başka bir e posta girin...", "HATA!");
                txteposta.Text = "";
                txteposta.Focus();

                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtunvan.Text, txteposta.Text, txtadsoyad.Text, txtsifre.Text, comboBox1.SelectedIndex);
            }
        }
        #endregion

        #region Kaydetme Methodu
        public void Kaydet(string unvan, string eposta, string adsoyad, string sifre, int yetki)
        {

            if (userid == -1) //eğer id -1 ise yeni ekler
            {
                komut = "INSERT INTO OgretimElemani (unvan,Ad_Soyad,eposta,Kendi_Sinav_Sayisi,Gozetmenlik_Sayisi,sifre,yetki) VALUES ('" + unvan + "','" + adsoyad + "','" + eposta + "',0,0,'" + sifre + "'," + yetki + ") ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {
                button1.Visible = false;
                button5.Text = "EKLE";

                komut = "UPDATE OgretimElemani SET unvan = '" + unvan + "' ,Ad_Soyad = '" + adsoyad + "' ,eposta = '" + eposta + "',sifre = '" + sifre + "', yetki = " + yetki + "  WHERE id = " + userid + ";";
                mesaj = "Kayıt Güncellendi";

            }


            islemler.Degistir(komut);
            MessageBox.Show(mesaj);
            Temizle();
            Listele();

        }

        #endregion

        #region Yeni Kayıt Ekleme Butonu

        private void button5_Click(object sender, EventArgs e)
        {
            FormKontrol(); // form kontrol metodundan textboxları kontrol eder sonra da sorgu metodunda girilen kayıt önceden girilmiş mi bakar ve en son kaydet metodundan kaydedilip ekran listelenir
        }
        #endregion

        #region Tablodaki verileri Düzenleme ve Silme Butonları

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 5) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                userid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //seçilen verinin idsini atıyor

                switch (e.ColumnIndex)
                {
                    case 6: //değiştir
                        button1.Visible = true; //iptal butonu görünür
                        button5.Text = "GÜNCELLE";

                        komut = "select * from OgretimElemani where id=" + userid + ";";
                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            txtunvan.Text = dr["unvan"].ToString();
                            txtadsoyad.Text = dr["Ad_Soyad"].ToString();
                            txteposta.Text = dr["eposta"].ToString();
                            txtsifre.Text = dr["sifre"].ToString();
                            comboBox1.SelectedIndex = int.Parse(dr["yetki"].ToString());
                        }
                        else
                        { // eğer kayıt buluanmazsa hata verir
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");

                        }
                        islemler.Kapat();
                        dr.Close(); //datareader i temizliyoruz

                        break;
                    case 7:

                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);// silmek istenip istenmediği sorulur
                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM OgretimElemani where id=" + userid + ";";
                            islemler.Degistir(komut);

                            MessageBox.Show("Silindi.");

                            Temizle();
                            Listele(); //tablo tekrar listelenir

                        }
                        break;

                }


            }
        }

        #endregion

        #region İptal Butonu

        private void button1_Click(object sender, EventArgs e)
        {
            Temizle(); //textboxlar ve dropdown temizleme
            button1.Visible = false; //iptal butonu kapat
        }
        #endregion

    }
}
