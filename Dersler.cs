using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace sp
{
    public partial class Dersler : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Dersler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
        }
        private void Dersler_Load(object sender, EventArgs e)
        {
            if (Login.Session)
            {
                cmbogretimsekli.SelectedIndex = 0;
                Listele();
            }
            else
            {
                this.Close();
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

        #region Dışarda Tanımlananlar
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        string komut = "";
        string mesaj = "";
        int dersid = -1;
        #endregion

        #region Listele
        public void Listele()
        {
            komut = "select D.id as 'SIRA NO',D.ders_kodu as 'DERS KODU',D.ders_adi as 'DERS ADI', D.ogr_sekli as 'ÖĞRETİM ŞEKLİ', D.ogr_sayisi as 'ÖĞRENCİ SAYISI',concat(O.unvan,' ',O.Ad_Soyad) as 'ÖĞRETİM ELEMANI', B.bolum_adi as 'BÖLÜM ADI' from ders D, ogretimelemani O,bolumler B where D.ogretim_elemani=O.id and D.bolum_id = B.id;";

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

            //comboboxa veri basma 
            komut = "select * from bolumler";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbbolum.Items.Add(dr.GetString("bolum_adi"));
                cmbbolumid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();
            cmbbolum.SelectedIndex = 0;
            cmbbolumid.SelectedIndex = 0;


            komut = "select * from ogretimelemani";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbogretmen.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                cmbogretimelemaniid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();
            cmbogretmen.SelectedIndex = 0;
            cmbogretimelemaniid.SelectedIndex = 0;


        }
        #endregion

        #region Kaydet
        public void Kaydet(string dersadi, string derskodu, int ogrsayisi, string ogretimsekli, int ogretimelemani, int bolumid)
        {
            if (dersid == -1) //eğer id -1 ise yeni ekler
            {
                komut = "INSERT INTO ders(ders_adi,ogr_sekli,ogr_sayisi,ogretim_elemani,ders_kodu,bolum_id) VALUES ('" + dersadi + "','" + ogretimsekli + "'," + ogrsayisi + "," + ogretimelemani + ",'" + derskodu + "'," + bolumid + ") ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {
                button1.Visible = false;
                button2.Text = "EKLE";

                komut = "UPDATE ders SET ders_adi = '" + dersadi + "',ogr_sekli = '" + ogretimsekli + "' ,ogr_sayisi = " + ogrsayisi + ",ogretim_elemani = " + ogretimelemani + ", ders_kodu = '" + derskodu + "', bolum_id=" + bolumid + "  WHERE id = " + dersid + ";";
                mesaj = "Kayıt Güncellendi";

            }


            islemler.Degistir(komut);
            MessageBox.Show(mesaj);
            Temizle();
            Listele();
        }
        #endregion

        #region Sorgu
        public void Sorgu()
        {
            komut = "select * from ders where ders_kodu='" + txtdkod.Text + "' and id <> " + dersid + ";";
            if (islemler.Oku(komut).Read())
            {
                MessageBox.Show("Aynı ders kodunda ders kayıtlı. Lütfen Farklı bir ders kodu girin...", "HATA!");
                txtdkod.Text = "";
                txtdkod.Focus();

                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtdad.Text, txtdkod.Text, int.Parse(txtos.Text), cmbogretimsekli.SelectedItem.ToString(), int.Parse(cmbogretimelemaniid.SelectedItem.ToString()), int.Parse(cmbbolumid.SelectedItem.ToString()));
            }
        }
        #endregion

        #region Form Kontrol
        public void FormKontrol()
        {
            if (txtdad.Text != "" || txtdkod.Text != "" || txtos.Text != "")
            {
                Sorgu();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!", "HATA!!");
            }
        }
        #endregion

        #region Ekle Butonu
        private void button2_Click(object sender, EventArgs e)
        {
            FormKontrol();
        }
        #endregion

        #region Ogrenci Sayısı Sadece Sayı Girişi
        private void txtos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Temizle
        public void Temizle() // textboxları ve butonları temizler
        {
            txtdad.Clear();
            txtdkod.Clear();
            txtos.Clear();
            cmbogretimsekli.SelectedIndex = 0;
            button2.Text = "EKLE";
            button1.Visible = false;
            dersid = -1;

            dataGridView1.DataSource = null; // datagridview temizlenir
            dataGridView1.Columns.Clear();// datagridview temizlenir
            dataGridView1.Refresh(); // datagridview yenilenir

            //veritabanından basılan dropdownların temizlenmesi 
            cmbbolum.Items.Clear();
            cmbbolumid.Items.Clear();
            cmbogretmen.Items.Clear();
            cmbogretimelemaniid.Items.Clear();
        }

        #endregion

        #region Öğretim Elemanı ve BÖlüm idlerinin Comboboxa göre Tutulduğu Yer

        private void cmbogretmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemaniid.SelectedIndex = cmbogretmen.SelectedIndex;
        }

        private void cmbbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbolumid.SelectedIndex = cmbbolum.SelectedIndex;
        }

        #endregion

        #region Tabloda Değiştirme ve Silme İşlemleri
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 6) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                dersid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //seçilen verinin idsini atıyor

                switch (e.ColumnIndex)
                {
                    case 7: //değiştir
                        button1.Visible = true; //iptal butonu görünür
                        button2.Text = "GÜNCELLE";

                        komut = "select * from ders where id=" + dersid + ";";
                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            txtdad.Text = dr["ders_adi"].ToString();
                            txtdkod.Text = dr["ders_kodu"].ToString();
                            txtos.Text = dr["ogr_sayisi"].ToString();
                            cmbogretimsekli.SelectedItem= dr["ogr_sekli"].ToString();
                            cmbbolumid.SelectedItem = dr["bolum_id"].ToString();
                            cmbbolum.SelectedIndex = cmbbolumid.SelectedIndex;

                            cmbogretimelemaniid.SelectedItem = dr["ogretim_elemani"].ToString();
                            cmbogretmen.SelectedIndex = cmbogretimelemaniid.SelectedIndex;
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
                            komut = "DELETE FROM ders where id=" + dersid + ";";
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
            Temizle();
            Listele();
        }
        #endregion
    }
}
