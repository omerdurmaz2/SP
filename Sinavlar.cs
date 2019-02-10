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

        //Öğrenci Sayısı ve Derslik Kapasitesi
        int ogrencisayisi = 0;
        int derslikkapasitesi = 0;

        //Ders - Bölüm - Öğretim Elemanı id si tutulduğu yer
        int bolumid = 0;
        int ogretimelemaniid = 0;
        int dersid = 0;

        //Gozetmen idlerinin Tutulduğu Yer
        string gozetmen1 = "0";
        string gozetmen2 = "0";
        string gozetmen3 = "0";

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
            try
            {
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
            }
            catch (Exception err)
            {
                MessageBox.Show("Tarihler Listelenirken Hata! Hata Kodu:" + err);
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
            bolumid = 0;
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

        #region Tarih İşlemleri
        //Tarih Değiştiğinde Yapılacaklar
        private void cmbtarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Saatler Güncelleniyor
            if (cmbogretimelemani.SelectedIndex > -1 && cmbtarih.SelectedIndex > -1 && cmbbolum.SelectedIndex > -1)
            {
                SaatListele();
            }

        }

        #endregion

        #region Bölüm İşlemleri
        //Bölüm Değiştiğinde Yapılacaklar
        private void cmbbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbolumid.SelectedIndex = cmbbolum.SelectedIndex;

            //Dersin Basıldığı Yer Basıldığı Yer 
            cmbders.Items.Clear();
            cmbdersid.Items.Clear();
            dersid = 0;
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
            ogretimelemaniid = 0;
            komut = "select * from ogretimelemani";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbogretimelemani.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                cmbogretimelemaniid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();
            if (cmbogretimelemani.Items.Count != 0)
            {
                cmbogretimelemani.SelectedIndex = 0;
                cmbogretimelemaniid.SelectedIndex = 0;
            }

            //Bölüm Değiştiğinde Saatin Yeniden Listelendiği yer
            if (cmbogretimelemani.SelectedIndex > -1 && cmbtarih.SelectedIndex > -1 && cmbbolum.SelectedIndex > -1)
            {
                SaatListele();
            }


        }

        //Bölüm id si değiştiğinde yapılacaklar
        private void cmbbolumid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbolum.SelectedIndex = cmbbolumid.SelectedIndex;
            bolumid = int.Parse(cmbbolumid.SelectedItem.ToString());

        }

        #endregion

        #region Ders İşlemleri
        //Ders Değiştiğinde Yapılacaklar
        private void cmbders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ders Seçimine Göre Basılmış Öğretim Elemanından En Alakalı Olanı Seçiyor
            cmbdersid.SelectedIndex = cmbders.SelectedIndex;
            OgrenciSayisiBul();
            //KapasiteKontrol();
        }

        //Ders id değiştiğinde yapılacaklar
        private void cmbdersid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbders.SelectedIndex = cmbdersid.SelectedIndex;
            dersid = int.Parse(cmbdersid.SelectedItem.ToString());
        }

        #region Derse Giren Öğrenci Sayısı Bulma
        public void OgrenciSayisiBul()
        {
            komut = "select ogr_sayisi from ders where id=" + dersid + ";";
            dr = islemler.Oku(komut);
            if (dr.Read())
            {
                ogrencisayisi = int.Parse(dr.GetString("ogr_sayisi"));
            }
            islemler.Kapat();
            lblsinavagirenogrencisayisi.Text = ogrencisayisi.ToString();
        }
        #endregion

        //Ders seçimine tıklandığında Yapılacaklar
        private void cmbders_Click(object sender, EventArgs e)
        {
            if (cmbders.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Bölümü Seçiniz!!", "UYARI!");
            }
        }


        #endregion

        #region Öğretim Elemanı İşlemleri
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

        //öğretim elemanı id si değiştiğinde yapılacaklar
        private void cmbogretimelemaniid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemani.SelectedIndex = cmbogretimelemaniid.SelectedIndex;
            ogretimelemaniid = int.Parse(cmbogretimelemaniid.SelectedItem.ToString());
        }

        //Öğretim Elemanı seçimine tıklandığında Yapılacaklar
        private void cmbogretimelemani_Click(object sender, EventArgs e)
        {
            if (cmbogretimelemani.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Bölümü Seçiniz!!", "UYARI!");
            }

        }


        #endregion

        #region Saat İşlemleri
        #region Saat Listele
        public void SaatListele()
        {
            //Bölüm Kodunun Alındığı Yer
            komut = "select * from bolumler where id=" + bolumid + ";";
            dr = islemler.Oku(komut);
            string bolumkodu = "";
            if (dr.Read())
            {
                bolumkodu = dr["bolum_kodu"].ToString();
            }
            islemler.Kapat();

            //Öğretim Elemanı Ad_Soyad Alındığı Yer
            komut = "select * from ogretimelemani where id=" + ogretimelemaniid + ";";
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



                komut = "select saat from sinavsaatleri order by saat asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    bool sonuc = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["saat"].ToString() == dr.GetString("saat"))
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
                MessageBox.Show(cmbtarih.SelectedItem.ToString() + " Tarihinde seçtiğiniz bölümün ya da öğretmenin sınavları bulunduğu için meşgul sınav saatleri kaldırılmıştır.");
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
            cmbsaat.SelectedIndex = 0;
        }
        #endregion
        //Seçilen Saat Değiştiğinde Yapılacaklar
        private void cmbsaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dersliklerin Basıldığı Yer

            //Derslik 1 Temizleniyor
            DerslikGizleGöster(false, 1);
            //derslik2 gizlenmesi
            DerslikGizleGöster(false, 2);
            //derslik3 gizlenmesi
            DerslikGizleGöster(false, 3);


            SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

            komut = "select * from sinavderslikleri;";
            SeciliDerslikleriGizle(komut, 1);

            cmbderslik1.SelectedIndex = 0;
            cmbderslik1id.SelectedIndex = 0;

            KapasiteKontrol();
        }

        //Saat seçimine tıklandığında Yapılacaklar
        private void cmbsaat_Click(object sender, EventArgs e)
        {
            if (cmbsaat.Items.Count == 0)
            {
                MessageBox.Show("Lütfen Önce Üstteki Alanları Seçiniz Seçiniz!!", "UYARI!");
            }

        }

        #endregion

        #region Derslik İşlemleri

        #region Sınav Tablosunda Kullanılan Dersliklerin Listesinin Alındığı Yer
        public void SınavTablosundakiDerslikleriListele()
        {
            if (cmbtarih.SelectedIndex != -1 && cmbsaat.SelectedIndex != -1)
            {
                DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem.ToString());
                string formattarih = tarih.ToString("yyyy-MM-dd");
                string saat = cmbsaat.SelectedItem.ToString();
                komut = "select Derslik1,Derslik2,Derslik3 from " + donem + " where Tarih='" + formattarih + "' and Saat = '" + saat + "'; ";
                dt.Clear();
                dt = islemler.Al(komut);
            }

        }
        #endregion

        #region Seçilen Derse Girecek Öğrenci Sayısına Göre Seçilen Dersliklerin Kapasitesinin Kontrolü
        public void KapasiteKontrol()
        {
            derslikkapasitesi = 0;
            int d1 = 0, d2 = 0, d3 = 0;
            ogrencisayisi = int.Parse(lblsinavagirenogrencisayisi.Text);

            int secilisayisi = 1;

            //dersliklerin idsinin alındığı yer in kapasitesinin alındığı yer,
            DerslikIdKaydet();

            //Tablodan Seçilen Derslik Bilgileriyle Seçilen Derslik Bilgileri Karşılaştırılıyor ve Seçilen Dersliklerin Toplam Kapasitesi Hesaplanıyor
            komut = "select * from sinavderslikleri";
            dt.Clear();
            dt = islemler.Al(komut);
            if (dt.Rows.Count != 0)
            {
                try
                {
                    if (cmbderslik3id.SelectedIndex != -1 && cmbderslik3id.SelectedItem != null)
                    {
                        secilisayisi = 3;
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
                    else if (cmbderslik2id.SelectedIndex != -1 && cmbderslik2id.SelectedItem != null)
                    {
                        secilisayisi = 2;
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
                    else if (cmbderslik1id.SelectedIndex != -1 && cmbderslik1id.SelectedItem != null)
                    {
                        secilisayisi = 1;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["id"].ToString() == derslik1)
                            {
                                d1 = int.Parse(dt.Rows[i]["sayi"].ToString());
                            }
                        }
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show("Derslik Kapasitesi Alınırken Hata Oluştu! Hata Kodu: " + err);
                }

                //Derslik Kapasitelerine Göre Kaç Dersliğin Yeterli Olduğunun Belirlendiği alan
                switch (secilisayisi)
                {
                    case 1:
                        derslikkapasitesi += d1;
                        if (derslikkapasitesi < ogrencisayisi)
                        {
                            DerslikGizleGöster(true, 2);
                            DerslikGizleGöster(false, 3);
                        }
                        break;
                    case 2:
                        derslikkapasitesi += d1;
                        if (derslikkapasitesi < ogrencisayisi)
                        {
                            derslikkapasitesi += d2;
                            if (derslikkapasitesi < ogrencisayisi)
                            {
                                DerslikGizleGöster(true, 3);
                            }
                        }
                        else
                        {
                            DerslikGizleGöster(false, 2);
                            DerslikGizleGöster(false, 3);
                        }
                        break;
                    case 3:
                        derslikkapasitesi += d1;
                        if (derslikkapasitesi < ogrencisayisi)
                        {
                            derslikkapasitesi += d2;
                            if (derslikkapasitesi < ogrencisayisi)
                            {
                                derslikkapasitesi += d3;
                            }
                            else
                            {
                                DerslikGizleGöster(false, 3);
                            }
                        }
                        else
                        {
                            DerslikGizleGöster(false, 2);
                            DerslikGizleGöster(false, 3);
                        }
                        break;
                }

                lblderslikkapasitesi.Text = derslikkapasitesi.ToString();

            }

        }
        #endregion

        #region Seçili Dersliklerin İd lerinin değişkenlere aktarıldığı yer
        public void DerslikIdKaydet()
        {
            derslik1 = "0";
            derslik2 = "0";
            derslik3 = "0";
            try
            {
                if (cmbderslik3.SelectedIndex != -1 && cmbderslik3id.SelectedItem != null)
                {
                    derslik1 = cmbderslik1id.SelectedItem.ToString();
                    derslik2 = cmbderslik2id.SelectedItem.ToString();
                    derslik3 = cmbderslik3id.SelectedItem.ToString();
                }
                else if (cmbderslik2.SelectedIndex != -1 && cmbderslik2id.SelectedItem != null)
                {
                    derslik1 = cmbderslik1id.SelectedItem.ToString();
                    derslik2 = cmbderslik2id.SelectedItem.ToString();
                }
                else if (cmbderslik1.SelectedIndex != -1 && cmbderslik1id.SelectedItem != null)
                {
                    derslik1 = cmbderslik1id.SelectedItem.ToString();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Derslik id Alınamadı.. Hata Kodu: " + err);
            }

        }
        #endregion

        #region Diğer Dersliklerden Seçilmiş Olan Dersliklerin Gizlendiği Yer
        public void SeciliDerslikleriGizle(string kmt, int dersliknumara)
        {

            dr = islemler.Oku(kmt);
            try
            {
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
            catch (Exception err)
            {
                MessageBox.Show("Derslikler Listesi Alınırken Hata! Hata Kodu:" + err);
                islemler.Kapat();

            }

        }
        #endregion

        #region Derslik 1 İşlemleri

        //1. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik1id.SelectedIndex = cmbderslik1.SelectedIndex;
            KapasiteKontrol();
        }

        //Derslik 1 Seçildiğinde Yapılacaklar
        private void cmbderslik1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbderslik1.SelectedIndex != -1 && cmbderslik1.Items.Count != 0)
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
                else if (cmbderslik1.Items.Count != 0)
                {
                    DerslikIdKaydet();
                    cmbderslik1.Items.Clear();
                    cmbderslik1id.Items.Clear();

                    SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık
                    komut = "select * from sinavderslikleri where id<>" + derslik2 + " and id <> " + derslik3 + ";";
                    SeciliDerslikleriGizle(komut, 1);

                }
                else
                {
                    MessageBox.Show("Lütfen Önce Sınav Saatini Seçiniz!", "UYARI!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Derslik 1 Tıklandığında Hata! Hata Kodu: " + err);
            }
        }

        #endregion

        #region Derslik 2 İşlemleri
        //2. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik2id.SelectedIndex = cmbderslik2.SelectedIndex;
            KapasiteKontrol();
        }

        //Derslik 2 Seçildiğinde Yapılacaklar
        private void cmbderslik2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbderslik2.SelectedIndex != -1)
                {
                    DerslikIdKaydet();

                    cmbderslik2.Items.Clear();
                    cmbderslik2id.Items.Clear();

                    SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

                    komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik3 + ";";
                    SeciliDerslikleriGizle(komut, 2);

                    cmbderslik2id.SelectedItem = derslik2;
                    cmbderslik2.SelectedIndex = cmbderslik2id.SelectedIndex;
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
            catch (Exception err)
            {
                MessageBox.Show("Derslik 2 Tıklandığında Hata! Hata Kodu: " + err);
            }
        }

        #endregion

        #region Derslik 3 İşlemleri
        //3. Derslik seçimi değiştiğinde yapılacaklar
        private void cmbderslik3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbderslik3id.SelectedIndex = cmbderslik3.SelectedIndex;
            KapasiteKontrol();
        }

        //Derslik 3 Seçildiğinde Yapılacaklar
        private void cmbderslik3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbderslik3.SelectedIndex != -1)
                {
                    DerslikIdKaydet();

                    cmbderslik3.Items.Clear();
                    cmbderslik3id.Items.Clear();

                    SınavTablosundakiDerslikleriListele(); // Bu methotta sınav tablosunda kullanılan derslik listesini dt datatable ina attık

                    komut = "select * from sinavderslikleri where id<>" + derslik1 + " and id <> " + derslik2 + ";";

                    SeciliDerslikleriGizle(komut, 3);

                    cmbderslik3id.SelectedItem = derslik3;
                    cmbderslik3.SelectedIndex = cmbderslik3id.SelectedIndex;
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
            catch (Exception err)
            {
                MessageBox.Show("Derslik 3 Tıklandığında Hata! Hata Kodu: " + err);
            }

        }

        #endregion

        #region Derslik 2 ve Derslik 3 Gizle / Göster / Temizle
        public void DerslikGizleGöster(bool islem, byte derslik)
        {

            if (islem)
            {
                switch (derslik)
                {
                    case 2:
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Items.Clear();
                        cmbderslik2.Text = "Seçiniz:";
                        cmbderslik2.Visible = true;
                        lblderslik2.Visible = true;
                        break;
                    case 3:
                        cmbderslik3.Items.Clear();
                        cmbderslik3.Items.Clear();
                        cmbderslik2.Text = "Seçiniz:";
                        cmbderslik3.Visible = true;
                        lblderslik3.Visible = true;
                        break;
                }
            }
            else
            {
                switch (derslik)
                {
                    case 1:
                        cmbderslik1.Items.Clear();
                        cmbderslik1.Items.Clear();
                        cmbderslik2.Text = "Seçiniz:";
                        break;
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


        #endregion

        #region Gözetmen İşlemleri
        #region Gözetmenlerin Gösterilip Gizlenmesi
        //Gözetmenlerin Gösterilip Gizlenmesi
        public void GozetmenGosterGizle(bool islem, int gozetmen)
        {
            if (islem)
            {
                switch (gozetmen)
                {
                    case 0:
                        btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 496);
                        btnmavi1.Location = new Point(btnmavi1.Location.X, 496);
                        break;
                    case 1:
                        btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 556);
                        btnmavi1.Location = new Point(btnmavi1.Location.X, 556);
                        cmbgozetmen1.Items.Clear();
                        cmbgozetmen1id.Items.Clear();
                        lblgozetmen1.Visible = true;
                        cmbgozetmen1.Visible = true;
                        cmbgozetmen1.Text = "Seçiniz...";
                        break;
                    case 2:
                        btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 616);
                        btnmavi1.Location = new Point(btnmavi1.Location.X, 616);
                        cmbgozetmen2.Items.Clear();
                        cmbgozetmen2id.Items.Clear();
                        lblgozetmen2.Visible = true;
                        cmbgozetmen2.Visible = true;
                        cmbgozetmen2.Text = "Seçiniz...";


                        break;
                    case 3:
                        btnkirmizi1.Location = new Point(btnkirmizi1.Location.X, 676);
                        btnmavi1.Location = new Point(btnmavi1.Location.X, 676);
                        cmbgozetmen3.Items.Clear();
                        cmbgozetmen3id.Items.Clear();
                        lblgozetmen3.Visible = true;
                        cmbgozetmen3.Visible = true;
                        cmbgozetmen3.Text = "Seçiniz...";
                        break;
                }
            }
            else
            {
                switch (gozetmen)
                {
                    case 0:
                        cmbgozetmen1.Items.Clear();
                        cmbgozetmen1id.Items.Clear();
                        lblgozetmen1.Visible = false;
                        cmbgozetmen1.Visible = false;
                        break;
                    case 1:
                        cmbgozetmen2.Items.Clear();
                        cmbgozetmen2id.Items.Clear();
                        lblgozetmen2.Visible = false;
                        cmbgozetmen2.Visible = false;
                        break;
                    case 2:
                        cmbgozetmen3.Items.Clear();
                        cmbgozetmen3id.Items.Clear();
                        lblgozetmen3.Visible = false;
                        cmbgozetmen3.Visible = false;
                        break;
                }
            }
        }
        #endregion

        #region Gözetmen Sayısı Değiştiğinde Yapılacaklar,

        //Gözetmen Sayısı Değiştiğinge Yapılacaklar
        private void gozetmensayisi_ValueChanged(object sender, EventArgs e)
        {
            switch (int.Parse(gozetmensayisi.Value.ToString()))
            {
                case 0:
                    GozetmenGosterGizle(true, 0);
                    GozetmenGosterGizle(false, 0);
                    break;
                case 1:
                    GozetmenGosterGizle(true, 1);
                    GozetmenGosterGizle(false, 1);
                    break;
                case 2:
                    GozetmenGosterGizle(true, 2);
                    GozetmenGosterGizle(false, 2);
                    break;
                case 3:
                    GozetmenGosterGizle(true, 3);
                    break;
            }

        }

        #endregion

        #region Seçilen Tarihte - Saatte Sınavı Olan Öğretmenlerin Alınması
        //Seçilen Tarih ve Saatte Sınavı Olan Gözetmenleri Listesi Alınıyor
        public void SinaviOlanGozetmenleriAl()
        {
            if (cmbtarih.SelectedIndex != -1 && cmbsaat.SelectedIndex != -1)
            {
                DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem.ToString());
                string formattarih = tarih.ToString("yyyy-MM-dd");
                string saat = cmbsaat.SelectedItem.ToString();
                komut = "select Gozetmen1,Gozetmen2,Gozetmen3 from " + donem + " where Tarih='" + formattarih + "' and Saat = '" + saat + "'; ";
                dt.Clear();
                dt = islemler.Al(komut);
            }

        }
        #endregion

        #region Gözetmen Sayısına Tıklandığında Yapılacaklar
        //Gözetmen Sayısına Tıklandığındaa Yapılacaklar
        private void gozetmensayisi_Click(object sender, EventArgs e)
        {
            if (cmbogretimelemani.Items.Count == 0 || cmbogretimelemani.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Önce Öğretim Elemanını Seçiniz! ", "UYARI!");
                gozetmensayisi.Value = 0;
            }

        }
        #endregion

        #region Diğer Comboboxlardan Seçilen Gözetmenlerin Idlerinin Alınması
        //Gözetmen Comboboxlarından Seçilmiş olan Gozetmenlerin İd leri Alındığı yer
        public void GozetmenIdleriAl()
        {
            gozetmen1 = "0";
            gozetmen2 = "0";
            gozetmen3 = "0";
            try
            {
                switch (int.Parse(gozetmensayisi.Value.ToString()))
                {
                    case 1:
                        if (cmbgozetmen1id.SelectedIndex != -1 && cmbgozetmen1id.Items.Count != 0)
                        {
                            gozetmen1 = cmbgozetmen1id.SelectedItem.ToString();
                        }
                        break;
                    case 2:
                        if (cmbgozetmen1id.SelectedIndex != -1 && cmbgozetmen1id.Items.Count != 0)
                        {
                            gozetmen1 = cmbgozetmen1id.SelectedItem.ToString();
                        }
                        if (cmbgozetmen2id.SelectedIndex != -1 && cmbgozetmen2id.Items.Count != 0)
                        {
                            gozetmen2 = cmbgozetmen2id.SelectedItem.ToString();
                        }
                        break;
                    case 3:
                        if (cmbgozetmen1id.SelectedIndex != -1 && cmbgozetmen1id.Items.Count != 0)
                        {
                            gozetmen1 = cmbgozetmen1id.SelectedItem.ToString();
                        }
                        if (cmbgozetmen2id.SelectedIndex != -1 && cmbgozetmen2id.Items.Count != 0)
                        {
                            gozetmen2 = cmbgozetmen2id.SelectedItem.ToString();
                        }
                        if (cmbgozetmen3id.SelectedIndex != -1 && cmbgozetmen3id.Items.Count != 0)
                        {
                            gozetmen3 = cmbgozetmen1id.SelectedItem.ToString();
                        }

                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Öğretmen İdleri Alınırken Hata! Hata Kodu: " + err);
            }
        }
        #endregion

        #region Gözetmenlerin Comboboxlara Basıldığı Yer
        //Gözetmenlerin comboboxlara Basıldığı Yer
        public void GozetmenleriBas(string kmt, int gozetmens)
        {
            dr = islemler.Oku(kmt);
            bool sonuc = false;
            try
            {
                while (dr.Read())
                {
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Gozetmen1"].ToString() == dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad") || dt.Rows[i]["Gozetmen2"].ToString() == dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad") || dt.Rows[i]["Gozetmen3"].ToString() == dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"))
                            {
                                sonuc = true;
                            }

                        }
                        if (sonuc == false)
                        {
                            switch (gozetmens)
                            {
                                case 1:
                                    cmbgozetmen1.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                    cmbgozetmen1id.Items.Add(dr.GetString("id"));
                                    break;
                                case 2:
                                    cmbgozetmen2.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                    cmbgozetmen2id.Items.Add(dr.GetString("id"));

                                    break;
                                case 3:
                                    cmbgozetmen3.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                    cmbgozetmen3id.Items.Add(dr.GetString("id"));
                                    break;
                            }

                        }
                        sonuc = false;
                    }
                    else
                    {
                        switch (gozetmens)
                        {
                            case 1:
                                cmbgozetmen1.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                cmbgozetmen1id.Items.Add(dr.GetString("id"));
                                break;
                            case 2:
                                cmbgozetmen2.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                cmbgozetmen2id.Items.Add(dr.GetString("id"));

                                break;
                            case 3:
                                cmbgozetmen3.Items.Add(dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad"));
                                cmbgozetmen3id.Items.Add(dr.GetString("id"));
                                break;
                        }
                    }
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Gözetmenler Basılırken Hata! Hata Kodu: " + err);
            }
        }
        #endregion

        #region Gozetmen 1 
        //Gözetemen 1 e tıklandığında Yapılacaklar
        private void cmbgozetmen1_Click(object sender, EventArgs e)
        {
            if (cmbgozetmen1.SelectedIndex != -1 && cmbgozetmen1.Items.Count != 0)
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen1.Items.Clear();
                cmbgozetmen1id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen2 + " and id<>" + gozetmen3 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 1);

                cmbgozetmen1.SelectedItem = gozetmen1;
                cmbgozetmen1.SelectedIndex = cmbgozetmen1id.SelectedIndex;
            }
            else
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen1.Items.Clear();
                cmbgozetmen1id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen2 + " and id<>" + gozetmen3 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 1);
                cmbgozetmen1.SelectedIndex = 0;
            }
        }
        private void cmbgozetmen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen1id.SelectedIndex = cmbgozetmen1.SelectedIndex;
        }
        private void cmbgozetmen1id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen1.SelectedIndex = cmbgozetmen1id.SelectedIndex;
        }

        #endregion

        #region Gozetmen 2

        //Gözetemen 2 e tıklandığında Yapılacaklar
        private void cmbgozetmen2_Click(object sender, EventArgs e)
        {
            if (cmbgozetmen2.SelectedIndex != -1 && cmbgozetmen2.Items.Count != 0)
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen2.Items.Clear();
                cmbgozetmen2id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen1 + " and id<>" + gozetmen3 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 2);

                cmbgozetmen2.SelectedItem = gozetmen2;
                cmbgozetmen2.SelectedIndex = cmbgozetmen1id.SelectedIndex;
            }
            else
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen2.Items.Clear();
                cmbgozetmen2id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen1 + " and id<>" + gozetmen3 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 2);
            }

        }

        //Gozetmen 2 İd indexi değiştiğinde indexleri eşitle
        private void cmbgozetmen2id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen2.SelectedIndex = cmbgozetmen2id.SelectedIndex;
        }

        //Gozetmen 2 indexi değiştiğinde id indexleri eşitle
        private void cmbgozetmen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen2id.SelectedIndex = cmbgozetmen2.SelectedIndex;
        }

        #endregion

        #region Gozetmen 3

        //Gözetemen 3 e tıklandığında Yapılacaklar
        private void cmbgozetmen3_Click(object sender, EventArgs e)
        {
            if (cmbgozetmen3.SelectedIndex != -1 && cmbgozetmen3.Items.Count != 0)
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen3.Items.Clear();
                cmbgozetmen3id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen1 + " and id<>" + gozetmen2 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 3);

                cmbgozetmen3.SelectedItem = gozetmen3;
                cmbgozetmen3.SelectedIndex = cmbgozetmen3id.SelectedIndex;
            }
            else
            {
                SinaviOlanGozetmenleriAl();
                GozetmenIdleriAl();

                cmbgozetmen3.Items.Clear();
                cmbgozetmen3id.Items.Clear();

                komut = "select * from ogretimelemani where id<>" + gozetmen1 + " and id<>" + gozetmen2 + " and id<>" + ogretimelemaniid + ";";
                GozetmenleriBas(komut, 3);
            }
        }


        //Gozetmen 3 index değiştiğinde id indexini eşitle
        private void cmbgozetmen3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen3id.SelectedIndex = cmbgozetmen3.SelectedIndex;
        }


        //gozetmen 3 id değiştiğinde indexleri eşitle
        private void cmbgozetmen3id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgozetmen3.SelectedIndex = cmbgozetmen3id.SelectedIndex;
        }
        #endregion

        #endregion


    }

}

