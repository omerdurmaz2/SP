using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace sp
{
    public partial class SinavEkleDüzenle : Tasarim
    {
        #region Dışarıda Tanımlananlar
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();

        DataTable DerslikTablo;
        DataTable OgretmenTablo;
        DataTable DuzenlenecekSinav;
        DataTable Sinavlar;
        DataTable Bolumler;
        public static int sinavid { get; set; }
        string komut = "";
        string mesaj = "";

        string Derslik1 = "0";
        string Derslik2 = "0";
        string Derslik3 = "0";
        string Derslik4 = "0";

        string gozetmen1 = "0";
        string gozetmen2 = "0";
        string gozetmen3 = "0";

        //Sorgu İçin Tanımlananlar
        bool kapasitekontrol = false;
        bool ogretimelemanikontrol = false;
        bool bolumkontrol = false;
        bool derslikkontrol = false;
        bool gozetmenkontrol = false;
        bool ogretmengozetmenkontrol = false;
        bool programadkodkontrol = false;
        #endregion

        #region Yapıcı metot ve Form_Load

        public SinavEkleDüzenle()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius  
            yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
                                                //this.WindowState = FormWindowState.Maximized;
            lblbaslik.Text = SinavProgrami.eklebaslik;
            baslikhizala();

        }
        private void SinavEkleDüzenle_Load(object sender, EventArgs e)
        {
            try
            {
                if (sinavid > 0)
                {
                    //Düzenlenecek sınav tabloya atılıyor
                    DuzenlenecekSinav = new DataTable();
                    komut = "select * from " + SinavProgrami.donem + " where id= " + sinavid + ";";
                    DuzenlenecekSinav = islemler.Al(komut);

                }
                Sinavlar = new DataTable();
                komut = "select * from " + SinavProgrami.donem + ";";
                Sinavlar = islemler.Al(komut);

                //Derslikler tabloya atılıyor
                DerslikTablo = new DataTable();
                komut = "select * from sinavderslikleri";
                DerslikTablo = islemler.Al(komut);

                //Öğretim Görevlileri Tabloya Atılıyor
                OgretmenTablo = new DataTable();
                komut = "select * from ogretimelemani";
                OgretmenTablo = islemler.Al(komut);

                //Bölümlerin Tabloya Tutulduğu Yer
                komut = "select * from bolumler";
                Bolumler = new DataTable();
                Bolumler = islemler.Al(komut);



                BolumBas();
                OgretimGorevlisiBas();
                TarihBas();
                SaatBas();
                İslemKontrol();
            }
            catch (Exception err)
            {
                MessageBox.Show("Form Yüklenirken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
            }
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


        #region Bolum / Bolum Kodu Bas
        public void BolumBas()
        {
            try
            {
                komut = "select program_kodu,program_adi from bolumler;";
                dr = islemler.Oku(komut);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        cmbbolumkod.Items.Add(dr.GetString("program_kodu"));
                        cmbbolumad.Items.Add(dr.GetString("program_adi"));
                    }
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Bölümler Basılırken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
            }

        }
        #endregion



        //Eğer kayıt değiştirme yapılmıyorsa prg_kod değiştiğinde otomatik olarak prg_adın seçildiği kısım
        private void cmbbolumkod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolumkontrol = false;
            try
            {
                if (sinavid > 0)
                {
                    komut = "select * from bolumler where program_kodu='" + cmbbolumkod.SelectedItem.ToString() + "';";
                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        cmbbolumad.SelectedItem = dr.GetString("program_adi");
                    }
                    islemler.Kapat();
                    DersBas();
                }
                else
                {
                    DersBas();
                }
            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Otomatik Program Kodu Seçimi Yapılırken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
            }

        }



        //Bölüm adı değiştiğinde yapılacaklar
        private void cmbbolumad_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolumkontrol = false; // bu sayede tekrardan sınavlar tablosunda seçilen bölümün sınavı var mı kontrol ediyoruz
            DersBas();//bu sayede sadece bölümün derslerini ve ortak dersleri listelemiş olacağız
        }

        //Derse Tıklandığında Yapılacaklar
        private void cmbders_Click(object sender, EventArgs e)
        {
            if (cmbbolumad.SelectedIndex == -1 || cmbbolumkod.SelectedIndex == -1)//bu sayede bölüme göre dersleri listeleyeceğiz
            {
                MessageBox.Show("Lütfen Önce Program Adını ve Program Kodunu Seçiniz");
            }
        }

        #region Ders Bas
        public void DersBas()
        {
            cmbders.Items.Clear();
            try
            {

                if (sinavid > 0) // eğer düzenleme yapılmıyorsa bölüm seçili olmasına göre komut değişiyor
                {
                    string birlesik = DuzenlenecekSinav.Rows[0]["Prg_Kod"].ToString() + " " + DuzenlenecekSinav.Rows[0]["Prg_Ad"].ToString();
                    komut = "select ders_adi from ders where bolum='" + birlesik + "' or bolum='ORTAK DERS'";


                }
                else // eğer düzenleme yapılıyorsa düzenleneceksınav tablosundan prg_kod ve prg_ad alınıyor ve ona göre derslikler listeleniyor
                {
                    if (cmbbolumad.SelectedItem != null && cmbbolumkod.SelectedItem != null)
                    {
                        string birlesik = cmbbolumkod.SelectedItem.ToString() + " " + cmbbolumad.SelectedItem.ToString();
                        komut = "select ders_adi from ders where bolum='" + birlesik + "' or bolum='ORTAK DERS'";
                    }
                    else
                    {
                        komut = "select ders_adi from ders where bolum='ORTAK DERS'";
                    }

                }
                dr = islemler.Oku(komut);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        cmbders.Items.Add(dr.GetString("ders_adi"));
                    }
                }
                islemler.Kapat();
                if (cmbders.Items.Count > 0)
                {
                    cmbders.SelectedIndex = -1;
                    cmbders.Text = "Seçiniz..";
                }

            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Ders Basılırken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
            }

        }
        #endregion

        #region Öğrenci Sayısı Sadece Sayı Girişi

        private void txtogrencisayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Öğretim Görevlisi Basıldığı Yer
        public void OgretimGorevlisiBas()
        {
            try
            {
                komut = "select id,unvan,Ad_Soyad from ogretimelemani;";
                dr = islemler.Oku(komut);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        cmbogretimelemani.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                    }
                }
                islemler.Kapat();
            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Öğretim Görevlisi Basılırken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
            }


        }

        #endregion

        #region Tarihin Basıldığı Yer
        public void TarihBas()
        {
            komut = "select tarih from sinavtarihleri order by tarih asc;";
            dr = islemler.Oku(komut);
            if (dr != null)
            {
                while (dr.Read())
                {
                    DateTime tarih = Convert.ToDateTime(dr.GetString("tarih"));
                    cmbtarih.Items.Add(tarih.ToShortDateString());
                }
            }
            islemler.Kapat();

        }
        #endregion

        #region Saatin Basıldığı Yer
        public void SaatBas()
        {
            komut = "select saat from sinavsaatleri order by saat asc;";
            dr = islemler.Oku(komut);
            if (dr != null)
            {
                while (dr.Read())
                {
                    DateTime saat = Convert.ToDateTime(dr.GetString("saat"));
                    cmbsaat.Items.Add(saat.ToShortTimeString());
                }
            }
            islemler.Kapat();

        }
        #endregion

        #region Dersliklerin Basıldığı Yer
        //Derslik Sayısı Değiştiğinde Yapılacaklars
        private void dersliksayisi_ValueChanged(object sender, EventArgs e)
        {
            switch (int.Parse(dersliksayisi.Value.ToString()))
            {
                case 1:
                    cmbderslik2.Items.Clear();
                    cmbderslik2.SelectedIndex = -1;
                    Derslik2 = "0";
                    cmbderslik2.Visible = false;
                    lblderslik2.Visible = false;
                    cmbderslik2.Text = "Seçiniz..";
                    break;
                case 2:
                    cmbderslik2.Visible = true;
                    lblderslik2.Visible = true;

                    cmbderslik3.Items.Clear();
                    cmbderslik3.SelectedIndex = -1;
                    Derslik3 = "0";
                    cmbderslik3.Visible = false;
                    lblderslik3.Visible = false;
                    cmbderslik3.Text = "Seçiniz..";

                    break;
                case 3:
                    cmbderslik3.Visible = true;
                    lblderslik3.Visible = true;

                    cmbderslik4.Items.Clear();
                    cmbderslik4.SelectedIndex = -1;
                    Derslik4 = "0";
                    cmbderslik4.Visible = false;
                    lblderslik4.Visible = false;
                    cmbderslik4.Text = "Seçiniz..";
                    break;
                case 4:
                    cmbderslik4.Visible = true;
                    lblderslik4.Visible = true;
                    break;

            }

        }

        public void DerslikBas(int derslik)
        {
            string komut = "select * from sinavderslikleri;";
            dr = islemler.Oku(komut);
            try
            {
                ArrayList derslikler = new ArrayList();
                while (dr.Read())
                {
                    derslikler.Add(dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik");
                }
                islemler.Kapat();
                foreach (var item in derslikler)
                {
                    string[] ayrilmis = new string[1];
                    ayrilmis = item.ToString().Split('-');
                    string deger = ayrilmis[0].Trim();
                    switch (derslik)
                    {
                        case 1:
                            if (deger != Derslik2 && deger != Derslik3 && deger != Derslik4)
                            {
                                cmbderslik1.Items.Add(item.ToString());
                            }
                            break;
                        case 2:
                            if (deger != Derslik1 && deger != Derslik3 && deger != Derslik4)
                            {

                                cmbderslik2.Items.Add(item.ToString());
                            }
                            break;
                        case 3:
                            if (deger != Derslik1 && deger != Derslik2 && deger != Derslik4)
                            {

                                cmbderslik3.Items.Add(item.ToString());
                            }
                            break;
                        case 4:
                            if (deger != Derslik1 && deger != Derslik2 && deger != Derslik3)
                            {

                                cmbderslik4.Items.Add(item.ToString());
                            }
                            break;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Derslikler Listesi Alınırken Hata! \nHata Kodu:" + err);
                islemler.Kapat();
                this.Close();

            }


        }
        public void DerslikTut()
        {
            Derslik1 = "0";
            Derslik2 = "0";
            Derslik3 = "0";
            Derslik4 = "0";
            string[] ayrilmis = new string[1];
            int tk = 0;
            try
            {
                if (cmbderslik4.SelectedIndex != -1 && cmbderslik4.SelectedItem != null)
                {

                    ayrilmis = cmbderslik1.SelectedItem.ToString().Split('-');
                    Derslik1 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik2.SelectedItem.ToString().Split('-');
                    Derslik2 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik3.SelectedItem.ToString().Split('-');
                    Derslik3 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik4.SelectedItem.ToString().Split('-');
                    Derslik4 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                }
                else if (cmbderslik3.SelectedIndex != -1 && cmbderslik3.SelectedItem != null)
                {
                    ayrilmis = cmbderslik1.SelectedItem.ToString().Split('-');
                    Derslik1 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik2.SelectedItem.ToString().Split('-');
                    Derslik2 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik3.SelectedItem.ToString().Split('-');
                    Derslik3 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);


                }
                else if (cmbderslik2.SelectedIndex != -1 && cmbderslik2.SelectedItem != null)
                {
                    ayrilmis = cmbderslik1.SelectedItem.ToString().Split('-');
                    Derslik1 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);
                    ayrilmis = cmbderslik2.SelectedItem.ToString().Split('-');
                    Derslik2 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);

                }
                else if (cmbderslik1.SelectedIndex != -1 && cmbderslik1.SelectedItem != null)
                {
                    ayrilmis = cmbderslik1.SelectedItem.ToString().Split('-');
                    Derslik1 = ayrilmis[0].Trim();
                    ayrilmis = ayrilmis[1].Trim().Split(' ');
                    tk += int.Parse(ayrilmis[0]);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Derslik id Alınamadı.. \nHata Kodu: " + err);

                this.Close();
            }
            //Eğer Yukarıdaki "a54 - 60 kişilik" gibi değer split işleminde hata oluşursa ve kapasitede sadece sayı yerine string değer tutarsa lblkapasiteyi err yap
            lblderslikkapasitesi.Text = tk.ToString();
        }

        #region Derslik 1 İşlemleri
        private void cmbderslik1_SelectedIndexChanged(object sender, EventArgs e)
        {
            derslikkontrol = false;
            DerslikTut();
        }
        private void cmbderslik1_Click(object sender, EventArgs e)
        {
            cmbderslik1.Items.Clear();
            DerslikBas(1);

            if (cmbderslik1.SelectedIndex != -1 && cmbderslik1.SelectedItem != null)
            {
                cmbderslik1.SelectedItem = Derslik1;
            }
        }

        #endregion
        #region Derslik 2 İşlemleri
        private void cmbderslik2_SelectedIndexChanged(object sender, EventArgs e)
        {
            derslikkontrol = false;

            DerslikTut();
        }

        private void cmbderslik2_Click(object sender, EventArgs e)
        {
            if (cmbderslik1.SelectedIndex != -1)
            {
                cmbderslik2.Items.Clear();
                DerslikBas(2);

                if (cmbderslik2.SelectedIndex != -1 && cmbderslik2.SelectedItem != null)
                {
                    cmbderslik2.SelectedItem = Derslik2;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Önce 1. Dersliği Seçiniz!", "UYARI!");
            }

        }

        #endregion
        #region Derslik 3 İşlemleri
        private void cmbderslik3_SelectedIndexChanged(object sender, EventArgs e)
        {
            derslikkontrol = false;

            DerslikTut();
        }

        private void cmbderslik3_Click(object sender, EventArgs e)
        {
            if (cmbderslik2.SelectedIndex != -1)
            {
                cmbderslik3.Items.Clear();
                DerslikBas(3);

                if (cmbderslik3.SelectedIndex != -1 && cmbderslik3.SelectedItem != null)
                {
                    cmbderslik3.SelectedItem = Derslik3;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Önce 2. Dersliği Seçiniz!", "UYARI!");
            }


        }

        #endregion
        #region Derslik 4 İşlemleri
        private void cmbderslik4_SelectedIndexChanged(object sender, EventArgs e)
        {
            derslikkontrol = false;

            DerslikTut();
        }

        private void cmbderslik4_Click(object sender, EventArgs e)
        {
            if (cmbderslik3.SelectedIndex != -1)
            {
                cmbderslik4.Items.Clear();
                DerslikBas(4);

                if (cmbderslik4.SelectedIndex != -1 && cmbderslik4.SelectedItem != null)
                {
                    cmbderslik4.SelectedItem = Derslik4;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Önce 3. Dersliği Seçiniz!", "UYARI!");
            }


        }

        #endregion

        #endregion

        #region İşlem Kontrol Yeni Kayıt / Düzenleme
        public void İslemKontrol()
        {
            if (sinavid > 0)
            {




                if (DuzenlenecekSinav.Rows.Count != 0)
                {
                    int[] listelenecekler = { 0, 0, 0, 0 }; //dizinin 0. elemanı 1. derslik olarak düşünerek eğer herhangi bir eleman 1 ise listeleme yapılacak

                    try
                    {
                        cmbders.SelectedItem = DuzenlenecekSinav.Rows[0]["Ders_Adi"].ToString(); // dersin seçildiği yer
                        cmbdonem.SelectedItem = DuzenlenecekSinav.Rows[0]["donem"].ToString(); // donemin seçildiği yer
                        cmbbolumad.SelectedItem = DuzenlenecekSinav.Rows[0]["Prg_Ad"].ToString(); //program adının seçildiği yer
                        cmbbolumkod.SelectedItem = DuzenlenecekSinav.Rows[0]["Prg_Kod"].ToString(); //program kodunun seçildiği yer
                        txtogrencisayisi.Text = DuzenlenecekSinav.Rows[0]["Ogr_Sayisi"].ToString();  //öğrenci sayısının yazıldığı yer

                        string ogretimgorevlisiua = "";
                        ogretimgorevlisiua = DuzenlenecekSinav.Rows[0]["Unvan"].ToString() + " " + DuzenlenecekSinav.Rows[0]["Ad_Soyad"].ToString();
                        cmbogretimelemani.SelectedItem = ogretimgorevlisiua; //öğretim elemanının seçildiği yer

                        DateTime tarih = Convert.ToDateTime(DuzenlenecekSinav.Rows[0]["Tarih"].ToString());
                        cmbtarih.SelectedItem = tarih.ToShortDateString();//tarihin seçildiği yer

                        DateTime saat = Convert.ToDateTime(DuzenlenecekSinav.Rows[0]["Saat"].ToString());
                        cmbsaat.SelectedItem = saat.ToShortTimeString();//saatin seçildiği yer

                        cmbogretimsekli.SelectedItem = DuzenlenecekSinav.Rows[0]["Ogr_Sekli"].ToString(); // öğretim şeklinin seçildiği yer
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Düzenlenecek sınavın verileri seçilirken Hata! \nHata Kodu: " + err, "HATA!");
                    }

                    try
                    {
                        //Derslik İşlemleri
                        //Dersliklerin Basılıp Seçildiği Alan
                        if (DerslikTablo.Rows.Count != 0)
                        {
                            for (int i = 0; i < DerslikTablo.Rows.Count; i++)
                            {
                                if (DuzenlenecekSinav.Rows[0]["Derslik1"] != null)
                                {
                                    if (DerslikTablo.Rows[i]["derslik"].ToString() == DuzenlenecekSinav.Rows[0]["Derslik1"].ToString())
                                    {
                                        DerslikBas(1);
                                        cmbderslik1.SelectedItem = DerslikKapasiteAl(DuzenlenecekSinav.Rows[0]["Derslik1"].ToString());
                                    }
                                }
                                if (DuzenlenecekSinav.Rows[0]["Derslik2"] != null)
                                {
                                    if (DerslikTablo.Rows[i]["derslik"].ToString() == DuzenlenecekSinav.Rows[0]["Derslik2"].ToString())
                                    {
                                        dersliksayisi.Value++;
                                        DerslikBas(2);
                                        cmbderslik2.SelectedItem = DerslikKapasiteAl(DuzenlenecekSinav.Rows[0]["Derslik2"].ToString());
                                    }
                                }
                                if (DuzenlenecekSinav.Rows[0]["Derslik3"] != null)
                                {
                                    if (DerslikTablo.Rows[i]["derslik"].ToString() == DuzenlenecekSinav.Rows[0]["Derslik3"].ToString())
                                    {
                                        dersliksayisi.Value++;
                                        DerslikBas(3);
                                        cmbderslik3.SelectedItem = DerslikKapasiteAl(DuzenlenecekSinav.Rows[0]["Derslik3"].ToString());
                                    }
                                }
                                if (DuzenlenecekSinav.Rows[0]["Derslik4"] != null)
                                {
                                    if (DerslikTablo.Rows[i]["derslik"].ToString() == DuzenlenecekSinav.Rows[0]["Derslik4"].ToString())
                                    {
                                        dersliksayisi.Value++;
                                        DerslikBas(4);
                                        cmbderslik4.SelectedItem = DerslikKapasiteAl(DuzenlenecekSinav.Rows[0]["Derslik4"].ToString());
                                    }
                                }
                            }
                        }
                        //----------------------
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Düzenlenecek sınavın derslikleri seçilirken Hata! \nHata Kodu: " + err, "HATA!");
                    }

                    try
                    {
                        //Gözetmen İşlemleri
                        int gozetmens = int.Parse(DuzenlenecekSinav.Rows[0]["Y_Ogr_Sayisi"].ToString()); // gözetmen sayısı alınıyor

                        //Gözetmenlerin Basıldığı Alan
                        for (int i = 0; i < gozetmens; i++)
                        {
                            gozetmensayisi.Value++;
                            GozetmenBas(i + 1);
                        }
                        //Basılmış Gözetmenlerin Seçildiği Yer
                        if (OgretmenTablo.Rows.Count != 0)
                        {
                            for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                            {
                                string unvanvead = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                if (DuzenlenecekSinav.Rows[0]["Gozetmen1"].ToString() != null)
                                {
                                    if (unvanvead == DuzenlenecekSinav.Rows[0]["Gozetmen1"].ToString())
                                    {
                                        cmbgozetmen1.SelectedItem = unvanvead;
                                    }
                                }
                                if (DuzenlenecekSinav.Rows[0]["Gozetmen2"].ToString() != null)
                                {
                                    if (unvanvead == DuzenlenecekSinav.Rows[0]["Gozetmen2"].ToString())
                                    {
                                        cmbgozetmen2.SelectedItem = unvanvead;
                                    }
                                }
                                if (DuzenlenecekSinav.Rows[0]["Gozetmen3"].ToString() != null)
                                {
                                    if (unvanvead == DuzenlenecekSinav.Rows[0]["Gozetmen3"].ToString())
                                    {
                                        cmbgozetmen3.SelectedItem = unvanvead;
                                    }
                                }
                            }
                        }
                        //-------------------
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Düzenlenecek Sınavın Gözetmenleri Seçilirken Hata! \nHata Kodu: " + err, "HATA!");
                        this.Close();
                    }
                }
            }
        }
        #endregion


        public string DerslikKapasiteAl(string derslik)
        {
            try
            {
                string kapasite = "";
                string komut = "select * from sinavderslikleri";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    if (dr.GetString("derslik") == derslik)
                    {
                        kapasite = dr.GetString("derslik") + " - " + dr.GetString("sayi") + " Kişilik";
                    }
                }
                islemler.Kapat();
                return kapasite;

            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Derslik Kapasite Alınırken Hata! \nHata Kodu: " + err, "HATA!");
                this.Close();
                return "";
            }
        }


        #region Kayıt Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            bool cevap = Form_Kontrol();
            if (cevap)
            {
                cevap = Sorgu();
                if (cevap)
                {
                    try
                    {

                        string unvan = "", adsoyad = "";
                        DateTime tarih, saat;
                        tarih = Convert.ToDateTime(cmbtarih.SelectedItem);
                        saat = Convert.ToDateTime(cmbsaat.SelectedItem);


                        for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                        {
                            string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                            if (birlesik == cmbogretimelemani.SelectedItem.ToString())
                            {
                                unvan = OgretmenTablo.Rows[i]["unvan"].ToString();
                                adsoyad = OgretmenTablo.Rows[i]["Ad_Soyad"].ToString();
                            }
                        }

                        #region Sınav Kaydetme / Güncelleme

                        if (sinavid > 0)
                        {
                            komut = "UPDATE " + SinavProgrami.donem + " SET Prg_Ad='" + cmbbolumad.SelectedItem.ToString() + "', Prg_Kod='" + cmbbolumkod.SelectedItem.ToString() + "', Ogr_Sekli='" + cmbogretimsekli.SelectedItem.ToString() + "', donem='" + cmbdonem.SelectedItem.ToString() + "', Ders_Adi='" + cmbders.SelectedItem.ToString() + "',Ogr_Sayisi=" + txtogrencisayisi.Text + " ,Unvan='" + unvan + "' , Ad_Soyad='" + adsoyad + "', Tarih='" + tarih.ToString("yyyy-MM-dd") + "' , Saat='" + saat.ToShortTimeString() + "' , ";

                            if (Derslik1 != "0") komut += "Derslik1= '" + Derslik1 + "' ,";
                            else komut += "Derslik1= null ,";
                            if (Derslik2 != "0") komut += "Derslik2= '" + Derslik2 + "' ,";
                            else komut += "Derslik2= null ,";
                            if (Derslik3 != "0") komut += "Derslik3= '" + Derslik3 + "' ,";
                            else komut += "Derslik3= null ,";
                            if (Derslik4 != "0") komut += "Derslik4= '" + Derslik4 + "' ,";
                            else komut += "Derslik4= null ,";

                            komut += "Y_Ogr_Sayisi=" + gozetmensayisi.Value + " ,";
                            if (gozetmensayisi.Value == 0) komut += "Gozetmen1=null, Gozetmen2=null, Gozetmen3=null ";
                            else if (gozetmensayisi.Value == 1) komut += "Gozetmen1= '" + gozetmen1 + "' ,Gozetmen2=null, Gozetmen3=null ";
                            else if (gozetmensayisi.Value == 2) komut += "Gozetmen1= '" + gozetmen1 + "' ,Gozetmen2='" + gozetmen2 + "', Gozetmen3=null ";
                            else if (gozetmensayisi.Value == 3) komut += "Gozetmen1= '" + gozetmen1 + "' ,Gozetmen2='" + gozetmen2 + "', Gozetmen3='" + gozetmen3 + "' ";

                            komut += "where id=" + sinavid + ";";
                        }
                        else
                        {
                            komut = "INSERT INTO " + SinavProgrami.donem + " (Prg_Ad,Prg_Kod,Ogr_Sekli,donem,Ders_Adi,Ogr_Sayisi,Unvan,Ad_Soyad,Tarih,Saat,Derslik1,Derslik2,Derslik3,Derslik4,Y_Ogr_Sayisi,Gozetmen1,Gozetmen2,Gozetmen3) VALUES ('" + cmbbolumad.SelectedItem.ToString() + "','" + cmbbolumkod.SelectedItem.ToString() + "','" + cmbogretimsekli.SelectedItem.ToString() + "','" + cmbdonem.SelectedItem.ToString() + "','" + cmbders.SelectedItem.ToString() + "'," + txtogrencisayisi.Text + ",'" + unvan + "' ,'" + adsoyad + "','" + tarih.ToString("yyyy-MM-dd") + "' ,'" + saat.ToShortTimeString() + "' ,";

                            if (Derslik1 != "0") komut += "'" + Derslik1 + "' ,";
                            else komut += "null ,";
                            if (Derslik2 != "0") komut += "'" + Derslik2 + "' ,";
                            else komut += "null ,";
                            if (Derslik3 != "0") komut += "'" + Derslik3 + "' ,";
                            else komut += "null ,";
                            if (Derslik4 != "0") komut += "'" + Derslik4 + "' ,";
                            else komut += "null ,";

                            komut += "" + gozetmensayisi.Value + ", ";

                            if (gozetmensayisi.Value == 0) komut += "null, null,null ";
                            else if (gozetmensayisi.Value == 1) komut += "'" + gozetmen1 + "' , null, null );";
                            else if (gozetmensayisi.Value == 2) komut += "'" + gozetmen1 + "' , '" + gozetmen2 + "', null );";
                            else if (gozetmensayisi.Value == 3) komut += "'" + gozetmen1 + "' , '" + gozetmen2 + "', '" + gozetmen3 + "' );";
                        }
                        islemler.Degistir(komut);
                        #endregion

                        #region Gözetmenlik Sayısı ve Kendi Sınav Sayısı Arttıma

                        //Kendi Sınav Sayısı Arttırma
                        if (sinavid < 0)
                        {
                            komut = "UPDATE ogretimelemani SET Kendi_Sinav_Sayisi=Kendi_Sinav_Sayisi+1 where unvan='" + unvan + "' and Ad_Soyad='" + adsoyad + "'";
                            islemler.Degistir(komut);
                        }
                        //Gözetmenlik Sayısını Arttırma
                        int gozetmenid = 0;
                        if (sinavid > 0)
                        {

                            //Gözetmen 1 
                            if (DuzenlenecekSinav.Rows[0]["Gozetmen1"].ToString() != gozetmen1 && DuzenlenecekSinav.Rows[0]["Gozetmen2"].ToString() != gozetmen1 && DuzenlenecekSinav.Rows[0]["Gozetmen3"].ToString() != gozetmen1 && gozetmen1 != "0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen1)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }
                            //Gözetmen 2

                            if (DuzenlenecekSinav.Rows[0]["Gozetmen1"].ToString() != gozetmen2 && DuzenlenecekSinav.Rows[0]["Gozetmen2"].ToString() != gozetmen2 && DuzenlenecekSinav.Rows[0]["Gozetmen3"].ToString() != gozetmen2 && gozetmen2 != "0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen2)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }

                            //Gözetmen 3

                            if (DuzenlenecekSinav.Rows[0]["Gozetmen1"].ToString() != gozetmen3 && DuzenlenecekSinav.Rows[0]["Gozetmen2"].ToString() != gozetmen3 && DuzenlenecekSinav.Rows[0]["Gozetmen3"].ToString() != gozetmen3 && gozetmen3 != "0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen3)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }
                        }
                        else // Eğer Yeni Kayıt Yapılıyorsa
                        {
                            if (gozetmen1!="0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen1)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }
                            if (gozetmen2 != "0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen2)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }
                            if (gozetmen3 != "0")
                            {
                                for (int i = 0; i < OgretmenTablo.Rows.Count; i++)
                                {
                                    string birlesik = OgretmenTablo.Rows[i]["unvan"] + " " + OgretmenTablo.Rows[i]["Ad_Soyad"];
                                    if (birlesik == gozetmen3)
                                    {
                                        gozetmenid = int.Parse(OgretmenTablo.Rows[i]["id"].ToString());
                                    }
                                }
                                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 WHERE id=" + gozetmenid + "";
                                islemler.Degistir(komut);
                            }

                        }

                        #endregion

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception err)
                    {
                        this.DialogResult = DialogResult.None;
                        MessageBox.Show("Veriler Kaydedilirken Hata! \nHata Kodu:" + err, "HATA!");
                        this.Close();
                    }
                }
            }
        }

        #endregion

        #region Form Kontrol
        public bool Form_Kontrol()
        {
            try
            {
                if (cmbbolumkod.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Bölüm Kodunu Seçiniz!", "UYARI!");
                    return false;
                }
                if (cmbbolumad.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Bölüm Adını Seçiniz!", "UYARI!");
                    return false;
                }
                if (cmbders.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Dersi Seçiniz!", "UYARI!");
                    return false;
                }
                if (txtogrencisayisi.Text == "")
                {
                    MessageBox.Show("Lütfen Öğrenci Sayısını Yazınız!", "UYARI!");
                    return false;
                }
                if (cmbdonem.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Dönemi Seçiniz!", "UYARI!");
                    return false;
                }
                if (cmbogretimelemani.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Öğretim Görevlisini Seçiniz!", "UYARI!");
                    return false;
                }
                if (cmbtarih.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Tarihi Seçiniz!", "UYARI!");
                    return false;
                }

                if (cmbsaat.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Saati Seçiniz!", "UYARI!");
                    return false;
                }

                if (cmbogretimsekli.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Öğretim Şeklini Seçiniz!", "UYARI!");
                    return false;
                }

                if (cmbderslik1.Visible == true && cmbderslik1.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 1. Dersliği Seçiniz!", "UYARI!");
                    return false;
                }
                if (cmbderslik2.Visible == true && cmbderslik2.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 2. Dersliği Seçiniz ya da Derslik Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }
                if (cmbderslik3.Visible == true && cmbderslik3.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 3. Dersliği Seçiniz ya da Derslik Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }
                if (cmbderslik4.Visible == true && cmbderslik4.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 4. Dersliği Seçiniz ya da Derslik Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }
                if (cmbgozetmen1.Visible == true && cmbgozetmen1.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 1. Gözetmeni Seçiniz ya da Gözetmen Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }
                if (cmbgozetmen2.Visible == true && cmbgozetmen2.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 2. Gözetmeni Seçiniz ya da Gözetmen Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }
                if (cmbgozetmen3.Visible == true && cmbgozetmen3.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen 3. Gözetmeni Seçiniz ya da Gözetmen Sayısını Düşürünüz!", "UYARI!");
                    return false;
                }

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Form Kontrol Edilirken Hata! \nHata Kodu:" + err, "HATA!");
                this.Close();
                return false;
            }
        }
        #endregion

        #region Sorgu
        public bool Sorgu()
        {
            //Sorgu İçin Dışarıda Tanımlananlar
            DialogResult cevap;
            DateTime secilitarih = Convert.ToDateTime(cmbtarih.SelectedItem);
            DateTime tablotarih;
            DateTime secilisaat = Convert.ToDateTime(cmbsaat.SelectedItem);
            DateTime tablosaat;

            string ogretmen = "";
            int id = -1;

            //öğrenci sayısı derslik kapasitesinden büyük mü kontrol..
            if (kapasitekontrol == false)
            {
                if (int.Parse(lblsinavagirenogrencisayisi.Text) > int.Parse(lblderslikkapasitesi.Text))
                {
                    cevap = MessageBox.Show("Seçilen Dersin Öğrenci Sayısı Dersliklerin Toplam Kapasitesinden Fazla! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        kapasitekontrol = true;
                    }
                    else
                    {
                        kapasitekontrol = false;
                    }
                }
                else
                {
                    kapasitekontrol = true;
                }

            }
            //Seçilen Öğretim Elamnının Seçilen Tarih ve Saatte Sınavı Olması Sorgusu
            if (ogretimelemanikontrol == false)
            {

                for (int i = 0; i < Sinavlar.Rows.Count; i++)
                {
                    tablosaat = Convert.ToDateTime(Sinavlar.Rows[i]["Saat"].ToString());
                    tablotarih = Convert.ToDateTime(Sinavlar.Rows[i]["Tarih"].ToString());
                    ogretmen = Sinavlar.Rows[i]["Unvan"].ToString() + " " + Sinavlar.Rows[i]["Ad_Soyad"].ToString();
                    id = int.Parse(Sinavlar.Rows[i]["id"].ToString());
                    if (tablotarih.ToShortDateString() == secilitarih.ToShortDateString() && secilisaat.ToShortTimeString() == tablosaat.ToShortTimeString() && ogretmen == cmbogretimelemani.SelectedItem.ToString() && sinavid != id)
                    {
                        cevap = MessageBox.Show("Seçilen Tarih ve Saatte Öğretim Görevlisinin Başka Bir Sınavı Bulunmakta! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                        if (cevap == DialogResult.Yes)
                        {
                            ogretimelemanikontrol = true;
                            break;

                        }
                        else
                        {
                            ogretimelemanikontrol = false;
                            break;
                        }
                    }
                    else
                    {
                        ogretimelemanikontrol = true;
                    }

                }
            }
            //Seçilen Bölümün Seçilen Tarih ve Saatte Sınavı Olması Sorgusu
            if (bolumkontrol == false)
            {
                string secilmisbolumbirlesik = cmbbolumkod.SelectedItem.ToString() + " " + cmbbolumad.SelectedItem.ToString();

                for (int i = 0; i < Sinavlar.Rows.Count; i++)
                {
                    tablosaat = Convert.ToDateTime(Sinavlar.Rows[i]["Saat"].ToString());
                    tablotarih = Convert.ToDateTime(Sinavlar.Rows[i]["Tarih"].ToString());
                    id = int.Parse(Sinavlar.Rows[i]["id"].ToString());

                    if (cmbbolumkod.SelectedItem.ToString() == Sinavlar.Rows[i]["Prg_Kod"].ToString() && cmbbolumad.SelectedItem.ToString() == Sinavlar.Rows[i]["Prg_Ad"].ToString() &&
                        cmbogretimsekli.SelectedItem.ToString() == Sinavlar.Rows[i]["Ogr_Sekli"].ToString() && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        cevap = MessageBox.Show("Seçilen Tarih ve Saatte Bölümün Başka Bir Sınavı Bulunmakta! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                        if (cevap == DialogResult.Yes)
                        {
                            bolumkontrol = true;
                            break;

                        }
                        else
                        {
                            bolumkontrol = false;
                            break;
                        }

                    }
                    else
                    {
                        bolumkontrol = true;
                    }
                }
            }
            //Seçilen Dersliklerin Seçilen Tarih ve Saatte Kullanılması Sorgusu
            if (derslikkontrol == false)
            {
                mesaj = "";
                int[] olanlar = { 0, 0, 0, 0 };
                for (int i = 0; i < Sinavlar.Rows.Count; i++)
                {
                    tablosaat = Convert.ToDateTime(Sinavlar.Rows[i]["Saat"].ToString());
                    tablotarih = Convert.ToDateTime(Sinavlar.Rows[i]["Tarih"].ToString());
                    id = int.Parse(Sinavlar.Rows[i]["id"].ToString());
                    if (Sinavlar.Rows[i]["Derslik1"].ToString() == Derslik1 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[0] = 1;
                    }
                    if (Sinavlar.Rows[i]["Derslik2"].ToString() == Derslik2 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[1] = 1;
                    }
                    if (Sinavlar.Rows[i]["Derslik3"].ToString() == Derslik3 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[2] = 1;
                    }
                    if (Sinavlar.Rows[i]["Derslik4"].ToString() == Derslik4 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[3] = 1;
                    }
                    int toplam = 0;
                    for (int j = 0; j < olanlar.Length; j++)
                    {
                        toplam += olanlar[j];
                    }
                    if (toplam == 4) break;

                }

                for (int i = 0; i < olanlar.Length; i++)
                {
                    if (olanlar[i] == 1)
                    {
                        mesaj += +(i + 1) + ". Derslik, ";
                    }
                }
                if (mesaj != "")
                {
                    mesaj += " <== Bu Derslikler Seçilen Tarih ve Saatte Kullanılmakta!";
                    cevap = MessageBox.Show(mesaj + "\nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        derslikkontrol = true;

                    }
                    else
                    {
                        derslikkontrol = false;
                    }

                }
                else
                {
                    derslikkontrol = true;
                }

            }
            //Seçilen Gözetmenlerin Seçilen Tarihte ve Saatte Sınavı Olup Olmadığı Sorgusu
            if (gozetmenkontrol == false)
            {
                int[] olanlar = { 0, 0, 0 };
                mesaj = "";
                for (int i = 0; i < Sinavlar.Rows.Count; i++)
                {
                    tablosaat = Convert.ToDateTime(Sinavlar.Rows[i]["Saat"].ToString());
                    tablotarih = Convert.ToDateTime(Sinavlar.Rows[i]["Tarih"].ToString());
                    id = int.Parse(Sinavlar.Rows[i]["id"].ToString());
                    if (Sinavlar.Rows[i]["Gozetmen1"].ToString() == gozetmen1 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[0] = 1;
                    }
                    if (Sinavlar.Rows[i]["Gozetmen2"].ToString() == gozetmen2 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[1] = 1;
                    }
                    if (Sinavlar.Rows[i]["Gozetmen3"].ToString() == gozetmen3 && tablotarih == secilitarih && tablosaat == secilisaat && sinavid != id)
                    {
                        olanlar[2] = 1;
                    }
                    int toplam = 0;
                    for (int j = 0; j < olanlar.Length; j++)
                    {
                        toplam += olanlar[j];
                    }
                    if (toplam == 3) break;

                }
                for (int i = 0; i < olanlar.Length; i++)
                {
                    if (olanlar[i] == 1)
                    {
                        mesaj += (i + 1) + ". Gözetmen, ";
                    }
                }
                if (mesaj != "")
                {
                    mesaj += " <== Gözetmenlerin Seçilen Tarih ve Saatte Sınavı Bulunmakta!";
                    cevap = MessageBox.Show(mesaj + "\nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        gozetmenkontrol = true;

                    }
                    else
                    {
                        gozetmenkontrol = false;
                    }

                }
                else
                {
                    gozetmenkontrol = true;
                }
            }
            if (ogretmengozetmenkontrol == false)
            {
                if (cmbogretimelemani.SelectedItem.ToString() == gozetmen1 || cmbogretimelemani.SelectedItem.ToString() == gozetmen2 || cmbogretimelemani.SelectedItem.ToString() == gozetmen3)
                {
                    cevap = MessageBox.Show("Öğretim Elemanını Gözetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        ogretmengozetmenkontrol = true;

                    }
                    else
                    {
                        ogretmengozetmenkontrol = false;
                    }
                }
                else
                {
                    ogretmengozetmenkontrol = true;
                }
            }
            if (programadkodkontrol == false)
            {
                bool kontrol = false;
                string seciliprogkod = cmbbolumkod.SelectedItem.ToString();
                string seciliprogad = cmbbolumad.SelectedItem.ToString();
                for (int i = 0; i < Bolumler.Rows.Count; i++)
                {

                    string tabloprogkod = Bolumler.Rows[i]["program_kodu"].ToString();
                    string tabloprogad = Bolumler.Rows[i]["program_adi"].ToString();
                    if (seciliprogkod == tabloprogkod)
                    {
                        if (seciliprogad != tabloprogad)
                        {
                            kontrol = true;
                            break;
                        }
                    }
                    else if (seciliprogad == tabloprogad)
                    {
                        if (seciliprogkod != tabloprogkod)
                        {
                            kontrol = true;
                            break;
                        }
                    }
                }
                if (kontrol)
                {
                    cevap = MessageBox.Show("Program Adı ve Kodu Eşleşmemekte! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    if (cevap == DialogResult.Yes)
                    {
                        programadkodkontrol = true;
                    }
                    else
                    {
                        programadkodkontrol = false;
                    }
                }
                else
                {
                    programadkodkontrol = true;
                }

            }

            //Eğer Bütün Sorgular True İse Ekle Butonuna True Gönder, Değilse False Gönder
            if (kapasitekontrol && ogretimelemanikontrol && bolumkontrol && derslikkontrol && gozetmenkontrol && ogretmengozetmenkontrol && programadkodkontrol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        //Öğrenci Sayısının Yazdırıldığı Yer
        private void txtogrencisayisi_TextChanged(object sender, EventArgs e)
        {
            lblsinavagirenogrencisayisi.Text = txtogrencisayisi.Text;
        }

        #region Gözetmen İşlemleri

        #region Gözetmenlerin Gösterilip Gizlenmesi

        private void gozetmensayisi_ValueChanged(object sender, EventArgs e)
        {
            switch (int.Parse(gozetmensayisi.Value.ToString()))
            {
                case 0:
                    cmbgozetmen1.Items.Clear();
                    cmbgozetmen1.SelectedIndex = -1;
                    gozetmen1 = "0";
                    cmbgozetmen1.Visible = false;
                    lblgozetmen1.Visible = false;
                    cmbgozetmen1.Text = "Seçiniz..";
                    break;
                case 1:
                    cmbgozetmen1.Visible = true;
                    lblgozetmen1.Visible = true;
                    gozetmen2 = "0";
                    cmbgozetmen2.Items.Clear();
                    cmbgozetmen2.SelectedIndex = -1;
                    cmbgozetmen2.Visible = false;
                    lblgozetmen2.Visible = false;
                    cmbgozetmen2.Text = "Seçiniz..";
                    break;
                case 2:
                    cmbgozetmen2.Visible = true;
                    lblgozetmen2.Visible = true;
                    gozetmen3 = "0";
                    cmbgozetmen3.Items.Clear();
                    cmbgozetmen3.SelectedIndex = -1;
                    cmbgozetmen3.Visible = false;
                    lblgozetmen3.Visible = false;
                    cmbgozetmen3.Text = "Seçiniz..";
                    break;
                case 3:
                    cmbgozetmen3.Visible = true;
                    lblgozetmen3.Visible = true;
                    break;
            }

        }

        #endregion

        public void GozetmenBas(int gozetmens)
        {
            komut = "select * from ogretimelemani";
            dr = islemler.Oku(komut);
            try
            {
                ArrayList gozetmenler = new ArrayList();
                while (dr.Read())
                {
                    gozetmenler.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                }
                islemler.Kapat();
                foreach (var item in gozetmenler)
                {
                    switch (gozetmens)
                    {
                        case 1:
                            if (item.ToString() != gozetmen2 && item.ToString() != gozetmen3)
                            {
                                cmbgozetmen1.Items.Add(item.ToString());
                            }
                            break;
                        case 2:
                            if (item.ToString() != gozetmen1 && item.ToString() != gozetmen3)
                            {
                                cmbgozetmen2.Items.Add(item.ToString());
                            }

                            break;
                        case 3:
                            if (item.ToString() != gozetmen1 && item.ToString() != gozetmen2)
                            {
                                cmbgozetmen3.Items.Add(item.ToString());
                            }
                            break;
                    }

                }

            }
            catch (Exception err)
            {
                islemler.Kapat();
                MessageBox.Show("Gözetmenler Basılırken Hata! Hata Kodu: " + err, "HATA");
                this.Close();
            }
        }

        public void GozetmenTut()
        {
            try
            {
                gozetmen1 = "0";
                gozetmen2 = "0";
                gozetmen3 = "0";
                if (cmbgozetmen3.SelectedIndex != -1 && cmbgozetmen3.SelectedItem != null)
                {
                    gozetmen1 = cmbgozetmen1.SelectedItem.ToString();
                    gozetmen2 = cmbgozetmen2.SelectedItem.ToString();
                    gozetmen3 = cmbgozetmen3.SelectedItem.ToString();
                }
                else if (cmbgozetmen2.SelectedIndex != -1 && cmbgozetmen2.SelectedItem != null)
                {
                    gozetmen1 = cmbgozetmen1.SelectedItem.ToString();
                    gozetmen2 = cmbgozetmen2.SelectedItem.ToString();
                }
                else if (cmbgozetmen1.SelectedIndex != -1 && cmbgozetmen1.SelectedItem != null)
                {
                    gozetmen1 = cmbgozetmen1.SelectedItem.ToString();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Seçilmiş Gözetmenler Tutulurken Hata! \nHata Kodu:" + err, "HATA!");
                this.Close();
            }
        }

        #region Gozetmen 1
        private void cmbgozetmen1_Click(object sender, EventArgs e)
        {
            cmbgozetmen1.Items.Clear();
            GozetmenBas(1);
            if (cmbgozetmen1.SelectedIndex != -1 && cmbgozetmen1.SelectedItem != null)
            {
                cmbgozetmen1.SelectedItem = gozetmen1;
            }
        }

        private void cmbgozetmen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretmengozetmenkontrol = false;
            gozetmenkontrol = false;
            GozetmenTut();
        }
        #endregion
        #region Gozetmen 2

        private void cmbgozetmen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretmengozetmenkontrol = false;
            gozetmenkontrol = false;
            GozetmenTut();
        }

        private void cmbgozetmen2_Click(object sender, EventArgs e)
        {
            if (cmbgozetmen1.SelectedIndex != -1)
            {
                cmbgozetmen2.Items.Clear();
                GozetmenBas(2);

                if (cmbgozetmen2.SelectedIndex != -1 && cmbgozetmen2.SelectedItem != null)
                {
                    cmbgozetmen2.SelectedItem = gozetmen2;
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce 1. Gözetmeni Seçiniz", "UYARI!");
            }

        }
        #endregion
        #region Gozetmen 3

        private void cmbgozetmen3_Click(object sender, EventArgs e)
        {
            if (cmbgozetmen2.SelectedIndex != -1)
            {
                cmbgozetmen3.Items.Clear();
                GozetmenBas(3);

                if (cmbgozetmen3.SelectedIndex != -1 && cmbgozetmen3.SelectedItem != null)
                {
                    cmbgozetmen3.SelectedItem = gozetmen3;
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce 2. Gözetmeni Seçiniz", "UYARI!");
            }
        }

        private void cmbgozetmen3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretmengozetmenkontrol = false;
            gozetmenkontrol = false;
            GozetmenTut();
        }
        #endregion

        #endregion

        #region İptal Butonu

        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Sorgu İçin Yapılmış Ayarlamalar
        //Eğer Öğrenci Sayısı Ya da Derslik Kapasitesi Değişirse kapasite kontrolü sıfırla ki değerler uyuşmadığına kullanıcıya tekrar sorulabilsin
        private void lblsinavagirenogrencisayisi_TextChanged(object sender, EventArgs e)
        {
            kapasitekontrol = false;
        }
        private void cmbogretimelemani_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretmengozetmenkontrol = false;
            ogretimelemanikontrol = false;
            gozetmenkontrol = false;
        }

        private void cmbtarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretimelemanikontrol = false;
            bolumkontrol = false;
        }

        private void cmbsaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretimelemanikontrol = false;
            bolumkontrol = false;
        }

        private void cmbogretimsekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolumkontrol = false;
        }
    }

    #endregion

}
