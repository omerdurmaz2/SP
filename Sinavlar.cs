using System;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace sp
{
    public partial class Sinavlar : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Sinavlar()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0)); // border radius  
            yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
                                                //this.WindowState = FormWindowState.Maximized;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            baslikhizala();
            DonemBelirle();
        }
        private void Sinavlar_Load(object sender, EventArgs e)
        {

            //if (Login.Session)
            //{
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
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        DataTable dt = new DataTable();
        string komut = "";
        string mesaj = "";
        int sinavid = -1;
        string donem = "";
        // Seçili dersliklerin id leri tutulmak için 
        string derslik1 = "0";
        string derslik2 = "0";
        string derslik3 = "0";

        #endregion

        #region Dönem Belirleme
        //Bu sayede kullanıcı güz dönemi girdiğine güz dönemindeki veriler listelenecek ve kaydedilecektir. Aynı şekilde bahar dönemi de              
        public void DonemBelirle()
        {
            DateTime donemtarihi = new DateTime(DateTime.Now.Year, 1, 30);
            if (DateTime.Now < donemtarihi) donem = "guz";
            else donem = "bahar";

        }
        #endregion

        #region Listele
        public void Listele()
        {
            komut = "select D.id as 'SIRA NO',D.ders_kodu as 'DERS KODU',D.ders_adi as 'DERS ADI', D.ogr_sekli as 'ÖĞRETİM ŞEKLİ', D.ogr_sayisi as 'ÖĞRENCİ SAYISI',concat(O.unvan,' ',O.Ad_Soyad) as 'ÖĞRETİM ELEMANI', B.bolum_adi as 'BÖLÜM ADI' from ders D, ogretimelemani O,bolumler B where D.ogretim_elemani=O.id and D.bolum_id = B.id;";

            //if (islemler.Al(komut) != null)
            //{
            //    dataGridView1.DataSource = islemler.Al(komut);

            //    ButonEkle();//Tasarımda hazır buluann butonları ekliyoruz
            //    //değiştir butonu her satır için eklenir
            //    dataGridView1.Columns.Add(duzenle);

            //    //sil butonu her satır için eklenir
            //    dataGridView1.Columns.Add(sil);

            //}
            //else
            //{
            //    MessageBox.Show("İşlem Gerçekleştirlemedi, Lütfen Sonra Tekrar Deneyin!"); // eğer veritabanı işlemi gerçekleştirilemezse hata verir
            //    this.Close();
            //}

            #region Tarih Basıldığı Bölüm
            //Tarihlerin Basıldığı Yer
            cmbtarih.Items.Clear();
            DateTime tarih = DateTime.Now;
            komut = "select * from sinavtarihleri where tarih >='" + tarih.ToString("yyyy-MM-dd") + "' order by tarih asc;";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                tarih = Convert.ToDateTime(dr.GetString("tarih"));
                cmbtarih.Items.Add(tarih);
            }
            islemler.Kapat();
            if (cmbtarih.Items.Count != 0)
            {
                cmbtarih.SelectedIndex = 0;
            }
            #endregion

            #region Bölümlerin Basıldığı yer
            //Bölümlerin Basıldığı Yer 
            //öncelikle ders tablosundan bütün derslerin bölüm idlerini alıyoruz
            dt.Clear();
            komut = "select bolum_id from ders;";
            dt = islemler.Al(komut);

            //ardından bölümler tablosundan verileri çekiyoruz ve ders her bölüm idsini ders tablosundaki bölüm idleriyle karşılaştırıyoruz. ve eğer herhangi bir dersin bölüm idsi o anki basılacak bölümün idsi ile aynı ise ekrana basıyoruz.
            //Eğer bir bölümün ders tablosundan hiçbir kaydı yoksa listelemiyoruz ve bu sayede karışıklık ortadan kalkıyor.
            cmbbolum.Items.Clear();
            cmbbolumid.Items.Clear();
            komut = "select * from bolumler order by bolum_adi asc";
            dr = islemler.Oku(komut);
            bool cevap = false;

            while (dr.Read())
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bolum_id"].ToString() == dr.GetString("id"))
                        {
                            cevap = true;
                        }
                    }
                    if (cevap)
                    {
                        cmbbolum.Items.Add(dr.GetString("bolum_adi") + " (" + dr.GetString("bolum_kodu") + ")");
                        cmbbolumid.Items.Add(dr.GetString("id"));
                    }
                    cevap = false;
                }

            }
            islemler.Kapat();
            #endregion


        }
        #endregion

        #region Gözetmen Sayısı Değiştiğinde Yapılacaklar
        //Gözetmen Sayısı Değiştiğinge Yapılacaklar
        private void gozetmensayisi_ValueChanged(object sender, EventArgs e)
        {
            switch (int.Parse(gozetmensayisi.Value.ToString()))
            {
                case 0:
                    lblgozetmen1.Visible = false;
                    cmbgozetmen1.Visible = false;
                    btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 496);
                    btnmavi1.Location = new Point(btnmavi1.Location.X, 496);
                    break;
                case 1:
                    lblgozetmen1.Visible = true;
                    cmbgozetmen1.Visible = true;
                    lblgozetmen2.Visible = false;
                    cmbgozetmen2.Visible = false;
                    btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 556);
                    btnmavi1.Location = new Point(btnmavi1.Location.X, 556);


                    break;
                case 2:
                    lblgozetmen2.Visible = true;
                    cmbgozetmen2.Visible = true;
                    lblgozetmen3.Visible = false;
                    cmbgozetmen3.Visible = false;
                    btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 616);
                    btnmavi1.Location = new Point(btnmavi1.Location.X, 616);

                    break;
                case 3:
                    lblgozetmen3.Visible = true;
                    cmbgozetmen3.Visible = true;
                    btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 676);
                    btnmavi1.Location = new Point(btnmavi1.Location.X, 676);

                    break;
            }

        }
        #endregion

        #region Saat Listele
        public void SaatListele()
        {
            //Bölüm Kodunun Alındığı Yer
            komut = "select * from bolumler where id=" + int.Parse(cmbbolumid.SelectedItem.ToString()) + ";";
            dr = islemler.Oku(komut);
            string bolumkodu = "";
            if (dr.Read())
            {
                bolumkodu = dr["bolum_kodu"].ToString();
            }
            islemler.Kapat();

            //Öğretim Elemanı Ad_Soyad Alındığı Yer
            komut = "select * from ogretimelemani where id=" + int.Parse(cmbogretimelemaniid.SelectedItem.ToString()) + ";";
            dr = islemler.Oku(komut);
            string oadsoyad = "";
            string ounvan = "";
            if (dr.Read())
            {
                oadsoyad = dr["Ad_Soyad"].ToString();
                ounvan = dr["unvan"].ToString();
            }
            islemler.Kapat();

            dt.Clear();

            //Saatinin Basıldığı Yer
            cmbsaat.Items.Clear();
            DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem);
            komut = "select Saat from " + donem + " where Tarih='" + tarih.ToString("yyyy-MM-dd") + "' and (Prg_Kod = '" + bolumkodu + "' or (Unvan = '" + ounvan + "' and Ad_Soyad='" + oadsoyad + "'));";
            dt = islemler.Al(komut);
            if (dt.Rows.Count != 0)
            {

                ArrayList saatlistesi = new ArrayList();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime saat = DateTime.Parse(dt.Rows[i]["Saat"].ToString());
                    DateTime baslangic = saat.AddMinutes(-45); // koşulu sağlayan verilerdeki saatlerden bir saat öncesini de gizliyoruz (örneğin listede bölümü için 14:00 da olan bir sınav var ise kullanıcı 13:15,13:30,13:45 seçemesin ki a bölümünün sınavları çakışmasın) 
                    for (DateTime j = baslangic; j < saat.AddHours(1); j = j.AddMinutes(15))
                    {
                        if (saatlistesi.IndexOf(j) == -1)
                        {
                            saatlistesi.Add(j);
                        }
                    }


                }

                komut = "select saat from sinavsaatleri order by saat asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    bool sonuc = false;
                    foreach (var item in saatlistesi)
                    {
                        DateTime tablosaat = Convert.ToDateTime(item);
                        DateTime sinavsaat = Convert.ToDateTime(dr.GetString("saat"));
                        if (sinavsaat.ToShortTimeString() == tablosaat.ToShortTimeString())
                        {
                            sonuc = true;
                        }
                    }
                    if (sonuc == false)
                    {
                        cmbsaat.Items.Add(dr.GetString("saat"));

                    }
                }
                islemler.Kapat();
                MessageBox.Show("Seçilen Tarihte seçili bölümün ya da öğretmenin sınavları bulunduğu için seçebileceğiniz sınav saatleri güncellenmiştir.");
            }
            else
            {
                komut = "select saat from sinavsaatleri order by saat asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    cmbsaat.Items.Add(dr.GetString("saat"));
                }
                islemler.Kapat();

            }

        }
        #endregion

        #region Comboboxlarda Değer Değiştiğinde Yapılacaklar

        //Bölüm Değiştiğinde Yapılacaklar
        private void cmbbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbolumid.SelectedIndex = cmbbolum.SelectedIndex;


            //Dersin Basıldığı Yer Basıldığı Yer 
            cmbders.Items.Clear();
            cmbdersid.Items.Clear();
            int bolumid = int.Parse(cmbbolumid.SelectedItem.ToString());
            komut = "select * from ders where bolum_id=" + bolumid + ";";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbders.Items.Add(dr.GetString("ders_adi") + " (" + dr.GetString("ders_kodu") + ")");
                cmbdersid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();
            if (cmbders.Items.Count != 0)
            {
                cmbders.SelectedIndex = 0;
                cmbdersid.SelectedIndex = 0;
            }

            //Öğretim Elemanları Basıldığı Yer
            cmbogretimelemani.Items.Clear();
            cmbogretimelemaniid.Items.Clear();
            komut = "select * from ogretimelemani";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbogretimelemani.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                cmbogretimelemaniid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();

            //Saatler Güncellenyor
            if (cmbogretimelemani.SelectedIndex > -1 && cmbtarih.SelectedIndex > -1 && cmbbolum.SelectedIndex > -1)
            {
                SaatListele();
            }


        }

        //Öğretim Elemanı Değiştiğinde Yapılacaklar
        private void cmbogretimelemani_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemaniid.SelectedIndex = cmbogretimelemani.SelectedIndex;

            //Saatler Güncelleniyor
            if (cmbogretimelemani.SelectedIndex > -1 && cmbtarih.SelectedIndex > -1 && cmbbolum.SelectedIndex > -1)
            {
                SaatListele();
            }
        }

        //Tarih Değiştiğinde Yapılacaklar
        private void cmbtarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Saatler Güncelleniyor
            if (cmbogretimelemani.SelectedIndex > -1 && cmbtarih.SelectedIndex > -1 && cmbbolum.SelectedIndex > -1)
            {
                SaatListele();
            }

        }

        //Ders Değiştiğinde Yapılacaklar
        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ders Seçimine Göre Basılmış Öğretim Elemanından En Alakalı Olanı Seçiyor
            cmbdersid.SelectedIndex = cmbders.SelectedIndex;
            int dersid = int.Parse(cmbdersid.SelectedItem.ToString());
            int ogretimelemaniid = 0;
            komut = "select * from ders where id=" + dersid + ";";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                ogretimelemaniid = int.Parse(dr["ogretim_elemani"].ToString());
            }
            islemler.Kapat();
            cmbogretimelemaniid.SelectedItem = (object)ogretimelemaniid.ToString();
            KapasiteKontrol();
        }
        //öğretim elemanı id si değiştiğinde yapılacaklar
        private void cmbogretimelemaniid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemani.SelectedIndex = cmbogretimelemaniid.SelectedIndex;
        }

        //Seçilen Saat Değiştiğinde Yapılacaklar
        private void cmbsaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dersliklerin Basıldığı Yer

            //Derslik 1 Temizleniyor
            cmbderslik1.Items.Clear();
            cmbderslik1id.Items.Clear();

            //derslik3 gizlenmesi
            cmbderslik3.Items.Clear();
            cmbderslik3id.Items.Clear();
            cmbderslik3.Visible = false;
            lblderslik3.Visible = false;

            //derslik3 gizlenmesi
            cmbderslik2.Items.Clear();
            cmbderslik2id.Items.Clear();
            cmbderslik2.Visible = false;
            lblderslik2.Visible = false;

            SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

            komut = "select * from sinavderslikleri;";
            dr = islemler.Oku(komut);
            bool sonuc = false;
            while (dr.Read())
            {

                if (dt.Rows.Count != 0) //sınav tablosunda seçilen tarih ve saatte sınav var ise kullanılan dersliklerin kaldırılması
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Derslik1"].ToString() == dr.GetString("derslik") || dt.Rows[i]["Derslik2"].ToString() == dr.GetString("derslik") || dt.Rows[i]["Derslik3"].ToString() == dr.GetString("derslik"))
                        {
                            sonuc = true;
                        }
                    }
                    if (sonuc == false)
                    {
                        cmbderslik1.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                        cmbderslik1id.Items.Add(dr.GetString("id"));
                    }
                    sonuc = false;
                }
                else
                {
                    cmbderslik1.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                    cmbderslik1id.Items.Add(dr.GetString("id"));

                }
            }
            islemler.Kapat();
        }

        //1. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik1id.SelectedIndex = cmbderslik1.SelectedIndex;
            KapasiteKontrol();
        }
        //2. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik2id.SelectedIndex = cmbderslik2.SelectedIndex;
            KapasiteKontrol();
        }

        //3. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik3id.SelectedIndex = cmbderslik3.SelectedIndex;
            KapasiteKontrol();
        }


        #endregion

        #region Sınav Tablosunda Kullanılan Dersliklerin Listesinin Alındığı Yer
        public void SınavTablosundakiDerslikleriListele()
        {
            DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem.ToString());
            string formattarih = tarih.ToString("yyyy-MM-dd");
            string saat = cmbsaat.SelectedItem.ToString();
            komut = "select Derslik1,Derslik2,Derslik3 from " + donem + " where Tarih='" + formattarih + "' and Saat = '" + saat + "'; ";
            dt.Clear();
            dt = islemler.Al(komut);

        }
        #endregion

        #region Comboboxlara Tıklandığında Yapılacaklar

        //Ders seçimine tıklandığında Yapılacaklar
        private void cmbders_Click(object sender, EventArgs e)
        {
            if (cmbders.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Bölümü Seçiniz!!", "UYARI!");
            }
        }
        //Öğretim Elemanı seçimine tıklandığında Yapılacaklar
        private void cmbogretimelemani_Click(object sender, EventArgs e)
        {
            if (cmbogretimelemani.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Bölümü Seçiniz!!", "UYARI!");
            }

        }

        //Saat seçimine tıklandığında Yapılacaklar
        private void cmbsaat_Click(object sender, EventArgs e)
        {
            if (cmbsaat.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Üstteki Alanları Seçiniz Seçiniz!!", "UYARI!");
            }

        }

        //Derslik 1 Seçildiğinde Yapılacaklar
        private void cmbderslik1_Click(object sender, EventArgs e)
        {
            if (cmbderslik1.SelectedIndex != -1)
            {
                DerslikIdKaydet();
                cmbderslik1.Items.Clear();
                cmbderslik1id.Items.Clear();

                SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık
                komut = "select * from sinavderslikleri where id<>" + derslik2 + " and id <> " + derslik3 + ";";
                SeciliDerslikleriGizle(komut, 1);

                cmbderslik1id.SelectedItem = derslik1;
                cmbderslik1.SelectedIndex = cmbderslik1id.SelectedIndex;
            }
        }

        //Derslik 2 Seçildiğinde Yapılacaklar
        private void cmbderslik2_Click(object sender, EventArgs e)
        {

            if (cmbderslik2.SelectedIndex != -1)
            {
                DerslikIdKaydet();

                cmbderslik2.Items.Clear();
                cmbderslik2id.Items.Clear();

                SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

                komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik3 + ";";
                SeciliDerslikleriGizle(komut, 2);

                cmbderslik2id.SelectedItem = derslik1;
                cmbderslik2.SelectedIndex = cmbderslik1id.SelectedIndex;
            }
            else
            {
                DerslikIdKaydet();

                cmbderslik2.Items.Clear();
                cmbderslik2id.Items.Clear();

                SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

                komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik3 + ";";
                SeciliDerslikleriGizle(komut, 2);
            }
        }

        //Derslik 3 Seçildiğinde Yapılacaklar
        private void cmbderslik3_Click(object sender, EventArgs e)
        {

            if (cmbderslik3.SelectedIndex != -1)
            {
                DerslikIdKaydet();

                cmbderslik3.Items.Clear();
                cmbderslik3id.Items.Clear();

                SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

                komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik2 + ";";

                SeciliDerslikleriGizle(komut, 3);

                cmbderslik3id.SelectedItem = derslik1;
                cmbderslik3.SelectedIndex = cmbderslik1id.SelectedIndex;
            }
            else
            {
                DerslikIdKaydet();

                cmbderslik3.Items.Clear();
                cmbderslik3id.Items.Clear();

                SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık


                komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik2 + ";";

                SeciliDerslikleriGizle(komut, 3);


            }

        }

        #endregion

        #region Seçilen Derse Girecek Öğrenci Sayısına Göre Seçilen Dersliklerin Kapasitesinin Kontrolü
        public void KapasiteKontrol()
        {
            int dersid = int.Parse(cmbdersid.SelectedItem.ToString());
            int toplamkapasite = 0;
            int ogrencisayis = 0;
            int d1 = 0, d2 = 0, d3 = 0;
            //seçilen dersin sınavına girecek öğrenci sayısının alındığı yer
            komut = "select ogr_sayisi from ders where id=" + dersid + ";";
            dr = islemler.Oku(komut);
            if (dr.Read())
            {
                ogrencisayis = int.Parse(dr.GetString("ogr_sayisi"));
            }
            islemler.Kapat();
            //dersliklerin idsinin alındığı yer in kapasitesinin alındığı yer,
            DerslikIdKaydet();

            //Tablodan Seçilen Derslik Bilgileriyle Seçilen Derslik Bilgileri Karşılaştırılıyor ve Seçilen Dersliklerin Toplam Kapasitesi Hesaplanıyor
            komut = "select * from sinavderslikleri";
            dt.Clear();
            dt = islemler.Al(komut);
            if (dt.Rows.Count != 0)
            {
                if (cmbderslik3.SelectedIndex != -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["id"].ToString() == derslik3)
                        {
                            d3 += int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                        else if (dt.Rows[i]["id"].ToString() == derslik2)
                        {
                            d2 += int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                        else if (dt.Rows[i]["id"].ToString() == derslik1)
                        {
                            d1 += int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                    }
                }
                else if (cmbderslik2.SelectedIndex != -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["id"].ToString() == derslik2)
                        {
                            d2 += int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                        else if (dt.Rows[i]["id"].ToString() == derslik1)
                        {
                            d1 += int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                    }
                }
                else if (cmbderslik1.SelectedIndex != -1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["id"].ToString() == derslik1)
                        {
                            d1 = int.Parse(dt.Rows[i]["sayi"].ToString());
                        }
                    }
                }

            }

            //Toplam Kapasite Öğrenci Sayısından Küçükse Yapılacaklar
            if (cmbderslik3.SelectedIndex != -1)
            {
                toplamkapasite += d1;
                if (toplamkapasite >= ogrencisayis) // eğer derslik 1 in kapasitesi yeterli ise diğer derslik seçimlerini gizle
                {
                    //derslik3 gizlenmesi
                    DerslikGizleGöster(false, 2);

                    //derslik3 gizlenmesi
                    DerslikGizleGöster(false, 3);


                }
                else
                {
                    toplamkapasite += d2;
                    if (toplamkapasite >= ogrencisayis) // eğer derslik1 ve derslik2 nin kapasitesi yeterli ise diğer derslik seçimlerini gizle
                    {
                        //derslik3 gizlenmesi
                        DerslikGizleGöster(false, 3);
                    }
                    else
                    {
                        toplamkapasite += d3;
                    }
                }
            }
            else if (cmbderslik2.SelectedIndex != -1)
            {
                toplamkapasite += d1;
                if (toplamkapasite >= ogrencisayis) // eğer derslik 1 in kapasitesi yeterli ise diğer derslik seçimlerini gizle
                {
                    //derslik 2 gizlenmesi
                    DerslikGizleGöster(false, 2);

                }
                else
                {
                    toplamkapasite += d2;
                    if (toplamkapasite < ogrencisayis) // eğer derslik 1 in ve derslik 2 nin kapasitesi yeterli değilse derslik 3 ü göster
                    {
                        DerslikGizleGöster(true, 3);
                    }
                }
            }
            else if (cmbderslik1.SelectedIndex != -1)
            {
                toplamkapasite += d1;
                if (toplamkapasite < ogrencisayis) // eğer derslik 1 in kapasitesi yeterli değilse derslik 2 yi göster
                {
                    DerslikGizleGöster(true, 2);
                }
            }
        }
        #endregion

        #region Derslik 2 ve Derslik 3 Gizle / Göster
        public void DerslikGizleGöster(bool islem, byte derslik)
        {

            if (islem)
            {
                switch (derslik)
                {
                    case 2:
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Visible = true;
                        lblderslik2.Visible = true;
                        break;
                    case 3:
                        cmbderslik3.Items.Clear();
                        cmbderslik3.Items.Clear();
                        cmbderslik3.Visible = true;
                        lblderslik3.Visible = true;
                        break;
                }
            }
            else
            {
                switch (derslik)
                {
                    case 2:
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Visible = false;
                        lblderslik2.Visible = false;
                        break;
                    case 3:
                        cmbderslik3.Items.Clear();
                        cmbderslik3.Items.Clear();
                        cmbderslik3.Visible = false;
                        lblderslik3.Visible = false;
                        break;
                }
            }
        }
        #endregion

        #region Seçili Dersliklerin İd lerinin değişkenlere aktarıldığı yer
        public void DerslikIdKaydet()
        {
            derslik1 = "0";
            derslik2 = "0";
            derslik3 = "0";
            if (cmbderslik3.SelectedIndex != -1)
            {
                derslik1 = cmbderslik1id.SelectedItem.ToString();
                derslik2 = cmbderslik2id.SelectedItem.ToString();
                derslik3 = cmbderslik3id.SelectedItem.ToString();
            }
            else if (cmbderslik2.SelectedIndex != -1)
            {
                derslik1 = cmbderslik1id.SelectedItem.ToString();
                derslik2 = cmbderslik2id.SelectedItem.ToString();
            }
            else if (cmbderslik1.SelectedIndex != -1)
            {
                derslik1 = cmbderslik1id.SelectedItem.ToString();
            }

        }
        #endregion

        #region Diğer Dersliklerden Seçilmiş Olan Dersliklerin Gizlendiği Yer
        public void SeciliDerslikleriGizle(string kmt, int dersliknumara)
        {

            dr = islemler.Oku(kmt);
            bool sonuc = false;
            while (dr.Read())
            {

                if (dt.Rows.Count != 0) //sınav tablosunda seçilen tarih ve saatte sınav var ise kullanılan dersliklerin kaldırılması
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Derslik1"].ToString() == dr.GetString("derslik") || dt.Rows[i]["Derslik2"].ToString() == dr.GetString("derslik") || dt.Rows[i]["Derslik3"].ToString() == dr.GetString("derslik"))
                        {
                            sonuc = true;
                        }
                    }
                    if (sonuc == false)
                    {

                        switch (dersliknumara)
                        {
                            case 1:
                                cmbderslik1.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                                cmbderslik1id.Items.Add(dr.GetString("id"));
                                break;
                            case 2:
                                cmbderslik2.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                                cmbderslik2id.Items.Add(dr.GetString("id"));
                                break;
                            case 3:
                                cmbderslik3.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                                cmbderslik3id.Items.Add(dr.GetString("id"));
                                break;
                        }
                    }
                    sonuc = false;
                }
                else
                {
                    switch (dersliknumara)
                    {
                        case 1:
                            cmbderslik1.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                            cmbderslik1id.Items.Add(dr.GetString("id"));
                            break;
                        case 2:
                            cmbderslik2.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                            cmbderslik2id.Items.Add(dr.GetString("id"));
                            break;
                        case 3:
                            cmbderslik3.Items.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                            cmbderslik3id.Items.Add(dr.GetString("id"));
                            break;
                    }

                }
            }
            islemler.Kapat();

        }
        #endregion

    }

}

