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
            sinavid = -1;
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

        DataTable dt; // veritabanından getirilen tabloların geçici olarak tutulduğu yer

        string komut = "";  //veritabanı komutlarının tutulduğu yer

        public static string eklebaslik = "";
        public static int sinavid { get; set; }

        public static int KonumX { get; set; }
        public static int KonumY { get; set; }

        Rectangle rect;

        int rowindex = 0;
        int colindex = 0;
        #endregion

        public void Listele()
        {
            islemler = new VeritabaniIslemler();

            //Eğer Bir Sınav Güncellenmiş İse Sadece Düzenlenen Satır Güncelleniyor
            if (sinavid > 0)
            {
                //Veritabanından Çekilen Yeni Satırın Verilerinin Eskisi İle Değiştirildiği yer

                komut = "select * from " + Home.donem + " where id=" + sinavid + ";";
                dr = islemler.Oku(komut);

                if (dr.Read())
                {
                    if (!dr.IsDBNull(1)) { dataGridView1.Rows[rowindex].Cells[1].Value = dr.GetString("Prg_Kod"); }
                    if (!dr.IsDBNull(2)) { dataGridView1.Rows[rowindex].Cells[2].Value = dr.GetString("Prg_Ad"); }
                    if (!dr.IsDBNull(3)) { dataGridView1.Rows[rowindex].Cells[3].Value = dr.GetString("Ogr_Sekli"); }
                    if (!dr.IsDBNull(4)) { dataGridView1.Rows[rowindex].Cells[4].Value = dr.GetString("donem"); }
                    if (!dr.IsDBNull(5)) { dataGridView1.Rows[rowindex].Cells[5].Value = dr.GetString("Ders_Kodu"); }
                    if (!dr.IsDBNull(6)) { dataGridView1.Rows[rowindex].Cells[6].Value = dr.GetString("Ders_Adi"); }
                    if (!dr.IsDBNull(7)) { dataGridView1.Rows[rowindex].Cells[7].Value = dr.GetString("Ogr_Sayisi"); }
                    if (!dr.IsDBNull(8)) { dataGridView1.Rows[rowindex].Cells[8].Value = dr.GetString("Tarih"); }
                    if (!dr.IsDBNull(9)) { dataGridView1.Rows[rowindex].Cells[9].Value = dr.GetString("Saat"); }
                    if (!dr.IsDBNull(10)) { dataGridView1.Rows[rowindex].Cells[10].Value = dr.GetString("Unvan"); }
                    if (!dr.IsDBNull(11)) { dataGridView1.Rows[rowindex].Cells[11].Value = dr.GetString("Ad_Soyad"); }
                    if (!dr.IsDBNull(12)) { dataGridView1.Rows[rowindex].Cells[12].Value = dr.GetString("Derslik1"); }
                    if (!dr.IsDBNull(13)) { dataGridView1.Rows[rowindex].Cells[13].Value = dr.GetString("Derslik2"); }
                    if (!dr.IsDBNull(14)) { dataGridView1.Rows[rowindex].Cells[14].Value = dr.GetString("Derslik3"); }
                    if (!dr.IsDBNull(15)) { dataGridView1.Rows[rowindex].Cells[15].Value = dr.GetString("Derslik4"); }
                    if (!dr.IsDBNull(16)) { dataGridView1.Rows[rowindex].Cells[16].Value = dr.GetString("Y_Ogr_Sayisi"); }
                    if (!dr.IsDBNull(17)) { dataGridView1.Rows[rowindex].Cells[17].Value = dr.GetString("Gozetmen1"); }
                    if (!dr.IsDBNull(18)) { dataGridView1.Rows[rowindex].Cells[18].Value = dr.GetString("Gozetmen2"); }
                    if (!dr.IsDBNull(19)) { dataGridView1.Rows[rowindex].Cells[19].Value = dr.GetString("Gozetmen3"); }


                }
                islemler.Kapat();
                dataGridView1.CurrentCell = dataGridView1.Rows[rowindex].Cells[colindex];


            }
            else
            {
                komut = "select id as 'SIRA NO', Prg_Kod as 'Program Kodu', Prg_Ad as 'Program Adı', Ogr_Sekli as 'ÖĞRETİM ŞEKLİ',donem as 'DÖNEM',Ders_Kodu as 'DERS KODU',Ders_Adi as 'DERS ADI',Ogr_Sayisi as 'ÖĞRENCİ SAYISI',Tarih as 'TARİH',Saat as 'SAAT',Unvan as 'ÜNVAN' , Ad_Soyad as 'AD SOYAD',Derslik1 as 'DERSLİK 1',Derslik2 as 'DERSLİK 2',Derslik3 as 'DERSLİK 3',Derslik4 as 'DERSLİK 4',Y_Ogr_Sayisi as 'YERLEŞEN ÖĞRENCİ SAYISI', Gozetmen1 as 'GÖZETMEN 1', Gozetmen2 as 'GÖZETMEN 2', Gozetmen3 as 'GÖZETMEN 3' from " + Home.donem + " order by id desc;";

                if (islemler.Al(komut) != null)
                {

                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    dataGridView1.DataSource = islemler.Al(komut);
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowindex].Cells[colindex];
                }


            }

            sinavid = -1;
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

        public void Ac()
        {
            rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
            KonumX = rect.X + dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Width;
            KonumY = rect.Y + 455;
            DialogResult cevap;

            SınavProgramıDüzenleFormu duzenle = new SınavProgramıDüzenleFormu();

            cevap = duzenle.ShowDialog();
            if (cevap != DialogResult.Abort && cevap != DialogResult.Cancel && cevap != DialogResult.None)
            {
                Listele();
                if (SınavProgramıDüzenleFormu.YapilanIslem == 5)
                {
                    OgretimGorevlileriListele();
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                colindex = e.ColumnIndex;
                rowindex = e.RowIndex;

                sinavid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                switch (e.ColumnIndex)
                {
                    case 3:
                        SınavProgramıDüzenleFormu.YapilanIslem = 1; //Öğretim Şekli
                        Ac();
                        break;
                    case 7:
                        SınavProgramıDüzenleFormu.YapilanIslem = 2; //Öğrenci Sayısı
                        Ac();
                        break;
                    case 8:
                        SınavProgramıDüzenleFormu.YapilanIslem = 3; //Tarih
                        Ac();
                        break;
                    case 9:
                        SınavProgramıDüzenleFormu.YapilanIslem = 4; //Saat
                        Ac();
                        break;
                    case 10:
                        SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                        Ac();
                        break;
                    case 11:
                        SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                        Ac();
                        break;
                    case 12:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 1 
                        SınavProgramıDüzenleFormu.Derslik = 1; 

                        Ac();
                        break;

                    case 13:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 2
                        SınavProgramıDüzenleFormu.Derslik = 2; 
                        Ac();
                        break;

                    case 14:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 3
                        SınavProgramıDüzenleFormu.Derslik = 3; 
                        Ac();
                        break;
                    case 15:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 4
                        SınavProgramıDüzenleFormu.Derslik = 4; 
                        Ac();
                        break;

                }
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Enter a Basıldığında alt satıra inmesi sorunu için yapılmış değişiklikler
                if (rowindex >= (dataGridView1.Rows.Count - 1)) { }
                else
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex - 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                }
                colindex = dataGridView1.CurrentCell.ColumnIndex;
                rowindex = dataGridView1.CurrentCell.RowIndex;
                //----------------------

                sinavid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());


                switch (dataGridView1.CurrentCell.ColumnIndex)
                {
                    case 3:
                        SınavProgramıDüzenleFormu.YapilanIslem = 1; //Öğretim Şekli
                        Ac();
                        break;
                    case 7:
                        SınavProgramıDüzenleFormu.YapilanIslem = 2; //Öğrenci Sayısı
                        Ac();
                        break;
                    case 8:
                        SınavProgramıDüzenleFormu.YapilanIslem = 3; //Tarih
                        Ac();
                        break;
                    case 9:
                        SınavProgramıDüzenleFormu.YapilanIslem = 4; //Saat
                        Ac();
                        break;
                    case 10:
                        SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                        Ac();
                        break;
                    case 11:
                        SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                        Ac();
                        break;
                    case 12:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 1 
                        SınavProgramıDüzenleFormu.Derslik = 1; 

                        Ac();
                        break;

                    case 13:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 2
                        SınavProgramıDüzenleFormu.Derslik = 2;
                        Ac();
                        break;

                    case 14:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 3
                        SınavProgramıDüzenleFormu.Derslik = 3; 
                        Ac();
                        break;
                    case 15:
                        SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 4
                        SınavProgramıDüzenleFormu.Derslik = 4; 
                        Ac();
                        break;

                }
            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Seçili hücrenin indexini keydownda alıyoruz çünkü enter a basıldığında seçili hücre değişiyor.
            //ancak bize entera basılmadan önceki hücre indexi lazım
            rowindex = dataGridView1.CurrentCell.RowIndex;
        }
    }
}
