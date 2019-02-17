using System;
using System.Data;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace sp
{
    public partial class SinavProgrami : Tasarim
    {
        #region Yapıcı Metod ve Form_Load

        public SinavProgrami()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0)); // border radius  
            yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
                                                //this.WindowState = FormWindowState.Maximized;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            baslikhizala();
            
        }
        private void SinavProgrami_Load(object sender, EventArgs e)
        {
            //if (Login.Session)
            //{
            //Filtrelerin Basıldığı Yer
            DonemBelirle donem = new DonemBelirle();
            DialogResult cevap;
            do
            {
                cevap = donem.ShowDialog();
                if (cevap == DialogResult.None || cevap == DialogResult.No || cevap == DialogResult.Cancel)
                {
                    MessageBox.Show("Lütfen Dönemi Seçiniz!", "UYARI!");
                }
                else
                {
                    break;
                }

            } while (cevap == DialogResult.None || cevap == DialogResult.No || cevap == DialogResult.Cancel);
            OgretimGorevlileriListele();
            FiltreTarihBas();
            FiltreSaatBas();
            FiltreOgretimGorevlisiBas();
            FiltreBolumKoduAdıBas();

            //-----

            Listele();
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

        #endregion

        #region Dışarıda Tanımlananlar
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler; // veritabanı classına giderek yapmak istediğimiz işleme göre kolaylıklar sağlıyor

        DataTable dt = new DataTable(); // veritabanından getirilen tabloların geçici olarak tutulduğu yer

        string komut = "";  //veritabanı komutlarının tutulduğu yer

        public static string donem = "";
        public static string eklebaslik = "";


        #endregion

        public void Listele()
        {
            islemler = new VeritabaniIslemler();
            komut = "select * from " + donem + " order by id desc;";

            if (islemler.Al(komut) != null)
            {

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();

                ButonEkle();
                dataGridView1.Columns.Add(duzenle);
                dataGridView1.Columns.Add(sil);
            
                dataGridView1.DataSource = islemler.Al(komut);

                dataGridView1.PerformLayout();
            }

        }

        #region Filtre İşlemleri
        #region Tarihin Basıldığı Yer
        public void FiltreTarihBas()
        {
            try
            {
                cmbfiltretarih.Items.Clear();
                DateTime tarih = DateTime.Now;
                komut = "select * from sinavtarihleri order by tarih asc;";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    tarih = Convert.ToDateTime(dr.GetString("tarih"));
                    cmbfiltretarih.Items.Add(tarih);
                }
                islemler.Kapat();
            }
            catch (Exception err)
            {
                MessageBox.Show("Filtre Tarihler Listelenirken Hata! Hata Kodu:" + err);
            }

        }
        #endregion

        #region Saatin Basıldığı Yer
        public void FiltreSaatBas()
        {
            try
            {
                cmbfiltresaat.Items.Clear();
                komut = "select saat from sinavsaatleri order by saat asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    cmbfiltresaat.Items.Add(dr.GetString("saat"));
                }
                islemler.Kapat();
            }
            catch (Exception err)
            {
                MessageBox.Show("Filtre Saatler Listelenirken Hata! Hata Kodu:" + err);
            }
        }
        #endregion

        #region Öğretim Görevlilerinin Basıldığı Yer
        public void FiltreOgretimGorevlisiBas()
        {
            try
            {
                cmbfiltreogretimgorevlisi.Items.Clear();
                komut = "select * from ogretimelemani";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    cmbfiltreogretimgorevlisi.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                }
                islemler.Kapat();
            }
            catch (Exception err)
            {
                MessageBox.Show("Filtre Öğretim Görevlisi Listelenirken Hata! Hata Kodu:" + err);
            }
        }
        #endregion

        #region Bölüm Kodunun ve Adının Basıldığı Yer
        public void FiltreBolumKoduAdıBas()
        {
            try
            {
                cmbfiltrebolumid.Items.Clear();
                cmbfiltrebolumadi.Items.Clear();
                cmbfiltrebolumkodu.Items.Clear();

                komut = "select * from bolumler";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    cmbfiltrebolumadi.Items.Add(dr.GetString("program_adi"));
                    cmbfiltrebolumkodu.Items.Add(dr.GetString("program_kodu"));
                    cmbfiltrebolumid.Items.Add(dr.GetString("id"));
                }
                islemler.Kapat();
            }
            catch (Exception err)
            {
                MessageBox.Show("Filtre Öğretim Görevlisi Listelenirken Hata! Hata Kodu:" + err);
            }
        }

        //bölüm değiştiğinde id si de değişecek
        private void cmbfiltrebolumadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbfiltrebolumid.SelectedIndex = cmbfiltrebolumadi.SelectedIndex;
        }

        #endregion

        #region Filtrelerin Temizlendiği Yer
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            cmbfiltrebolumadi.SelectedIndex = -1;
            cmbfiltrebolumadi.Text = "Bölüm Adı:";

            cmbfiltrebolumkodu.SelectedIndex = -1;
            cmbfiltrebolumkodu.Text = "Bölüm Kodu:";

            cmbfiltreogretimsekli.SelectedIndex = -1;
            cmbfiltreogretimsekli.Text = "Öğretim Şekli";

            cmbfiltreogretimgorevlisi.SelectedIndex = -1;
            cmbfiltreogretimgorevlisi.Text = "Öğretim Görevlisi:";

            cmbfiltretarih.SelectedIndex = -1;
            cmbfiltretarih.Text = "Tarih:";

            cmbfiltresaat.SelectedIndex = -1;
            cmbfiltresaat.Text = "Saat";




        }
        #endregion

        #endregion

        #region Öğretim Elemanları Listelendiği Yer
        public void OgretimGorevlileriListele()
        {
            islemler = new VeritabaniIslemler();
            komut = "select unvan as 'Ünvanı', Ad_Soyad as 'Ad Soyad',Kendi_Sinav_Sayisi as 'Kendi Sınav Sayısı',Gozetmenlik_Sayisi as 'Gözetmenlik Sayısı' from ogretimelemani";
            if (islemler.Al(komut) != null)
            {
                dataGridView2.DataSource = null;
                dataGridView2.Refresh();
                dataGridView2.DataSource = islemler.Al(komut);
            }
        }
        #endregion


        #region Ekleme Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            eklebaslik = "YENİ KAYIT";
            SinavEkleDüzenle.sinavid = -1;
            SinavEkleDüzenle ekle = new SinavEkleDüzenle();
            ekle.ShowDialog();
            if (ekle.DialogResult == DialogResult.None || ekle.DialogResult == DialogResult.No)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi", "HATA!");
            }
            else
            {
                MessageBox.Show("Kayıt Eklendi");
                Listele();
                OgretimGorevlileriListele();
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2 && e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        eklebaslik = "KAYIT DÜZENLE";
                        SinavEkleDüzenle.sinavid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        SinavEkleDüzenle goster = new SinavEkleDüzenle();
                        goster.ShowDialog();
                        if (goster.DialogResult == DialogResult.None || goster.DialogResult == DialogResult.No)
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi", "HATA!");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Güncellendi");
                            Listele();
                            OgretimGorevlileriListele();
                        }
                        break;
                    case 1:
                        break;
                }
            }
        }
    }
}
