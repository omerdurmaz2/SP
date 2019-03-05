using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace sp
{
    public partial class OgretimElemanlari : Tasarim
    {


        #region Yapıcı Metot ve Form_Load

        public OgretimElemanlari()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
            baslikhizala();
        }
        private void OgretimElemanlari_Load(object sender, EventArgs e)
        {
            //session kontrolü
            if (Login.Session)
            {
                Listele();
            }
            else
            {
                this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
            }
        }
        #endregion
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

        #region Dışarıda Tanımlananlar
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        string komut = "";
        string mesaj = "";
        public static int userid = -1; // session olarak duzenlenecek uyenin id sini tutuyor
        #endregion

        #region  Ekranı Temizle
        public void Temizle() // textboxları ve butonları temizler
        {
            txtadsoyad.Clear();
            txtsifre.Clear();
            txteposta.Clear();
            txtunvan.Clear();
            comboBox1.SelectedIndex = 0;
            btnmavi1.Text = "EKLE";
            userid = -1;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            dataGridView1.DataSource = null; // datagridview temizlenir
            dataGridView1.Columns.Clear();// datagridview temizlenir
            dataGridView1.Refresh(); // datagridview yenilenir
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

        }
        #endregion

        #region Listele

        public void Listele()
        {


            komut = "select O.id as 'SIRA NO',O.unvan as 'ÜNVAN',O.Ad_Soyad as 'AD SOYAD',O.eposta as 'E POSTA',O.Kendi_Sinav_Sayisi as 'KENDİ SINAV SAYISI' ,O.Gozetmenlik_Sayisi as 'GÖZETMENLİK SAYISI' , B.bolum_adi as 'BÖLÜMÜ' from ogretimelemani O, bolumler B where O.bolumu = B.id";
            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut);

                ButonEkle();//Tasarımda hazır bulunan tablo butonlarını ekliyoruz
                //değiştir butonu her satır için eklenir
                dataGridView1.Columns.Add(duzenle);

                //sil butonu her satır için eklenir
                dataGridView1.Columns.Add(sil);


            }
            else
            {
                MessageBox.Show("İşlem Gerçekleştirlemedi, Lütfen Sonra Tekrar Deneyin!"); // eğer veritabanı işlemi gerçekleştirilemezse hata verir
                this.Close();
            }

            //comboboxa veri basma 
            komut = "select * from bolumler";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                comboBox2.Items.Add(dr.GetString("bolum_adi"));
                comboBox3.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();


        }
        #endregion

        #region Form Kontrol Methodu
        public void FormKontrol()
        {
            if (txtunvan.Text == "" || txtsifre.Text == "" || txtadsoyad.Text == "" || txteposta.Text == "" || comboBox1.SelectedIndex==-1 || comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!");
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
            komut = "select * from ogretimelemani where eposta='" + txteposta.Text + "' and id <> " + userid + ";";
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
                Kaydet(txtunvan.Text, txteposta.Text, txtadsoyad.Text, txtsifre.Text, comboBox1.SelectedIndex, int.Parse(comboBox3.SelectedItem.ToString()));
            }
        }
        #endregion

        #region Kaydetme Methodu
        public void Kaydet(string unvan, string eposta, string adsoyad, string sifre, int yetki, int bolumid)
        {

            if (userid == -1) //eğer id -1 ise yeni ekler
            {
                komut = "INSERT INTO ogretimelemani (unvan,Ad_Soyad,eposta,Kendi_Sinav_Sayisi,Gozetmenlik_Sayisi,sifre,yetki,bolumu) VALUES ('" + unvan + "','" + adsoyad + "','" + eposta + "',0,0,'" + sifre + "'," + yetki + ", " + bolumid + ") ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {
                btnkirmizi1.Visible = false;
                btnmavi1.Text = "EKLE";

                komut = "UPDATE ogretimelemani SET unvan = '" + unvan + "' ,Ad_Soyad = '" + adsoyad + "' ,eposta = '" + eposta + "',sifre = '" + sifre + "', yetki = " + yetki + ", bolumu=" + bolumid + "  WHERE id = " + userid + ";";
                mesaj = "Kayıt Güncellendi";

            }


            islemler.Degistir(komut);
            MessageBox.Show(mesaj);
            Temizle();
            Listele();

        }

        #endregion

        #region Yeni Kayıt Ekleme Butonu

        private void btnmavi1_Click(object sender, EventArgs e)
        {
            FormKontrol(); // form kontrol metodundan textboxları kontrol eder sonra da sorgu metodunda girilen kayıt önceden girilmiş mi bakar ve en son kaydet metodundan kaydedilip ekran listelenir
        }
        #endregion

        #region Tablodaki verileri Düzenleme ve Silme Butonları

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 6) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                userid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //seçilen verinin idsini atıyor

                switch (e.ColumnIndex)
                {
                    case 7: //değiştir
                        btnkirmizi1.Visible = true; //iptal butonu görünür
                        btnmavi1.Text = "GÜNCELLE";

                        komut = "select * from ogretimelemani where id=" + userid + ";";
                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            txtunvan.Text = dr["unvan"].ToString();
                            txtadsoyad.Text = dr["Ad_Soyad"].ToString();
                            txteposta.Text = dr["eposta"].ToString();
                            txtsifre.Text = dr["sifre"].ToString();
                            comboBox1.SelectedIndex = int.Parse(dr["yetki"].ToString());
                            comboBox3.SelectedItem= dr["bolumu"].ToString();
                            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
                        }
                        else
                        { // eğer kayıt buluanmazsa hata verir
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");

                        }
                        islemler.Kapat();
                        dr.Close(); //datareader i temizliyoruz

                        break;
                    case 8:

                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);// silmek istenip istenmediği sorulur
                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM ogretimelemani where id=" + userid + ";";
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

        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            Temizle(); //textboxlar ve dropdown temizleme
            btnkirmizi1.Visible = false; //iptal butonu kapat
            Listele();
        }
        #endregion

        //id yi alabilmek için id nin tutulduğu comboboxu değiştirme
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox2.SelectedIndex;
        }

    }
}
