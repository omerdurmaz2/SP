using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

namespace sp
{
    public partial class SınavProgramıDüzenleFormu : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public SınavProgramıDüzenleFormu()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0)); // border radius  

            yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
                                                //this.WindowState = FormWindowState.Maximized;
            toolStripMenuItem1.Visible = false;

        }
        private void FormOgretimSekli_Load(object sender, EventArgs e)
        {
            try
            {
                if (SinavProgrami.sinavid > 0)
                {

                    switch (YapilanIslem)
                    {
                        case 1:
                            lblbaslik.Text = "ÖĞRETİM ŞEKLİ";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(240, 88);
                            cmbogretimsekli.Location = new Point(10, 60);
                            cmbogretimsekli.Visible = true;
                            EskiVeriyiSec();
                            cmbogretimsekli.Focus();
                            break;
                        case 2:
                            lblbaslik.Text = "ÖĞRENCİ SAYISI";
                            this.Size = new Size(240, 78);
                            txtogrencisayisi.Visible = true;
                            txtogrencisayisi.Location = new Point(10, 40);
                            EskiVeriyiSec();
                            txtogrencisayisi.Focus();
                            break;
                        case 3:
                            lblbaslik.Text = "SINAV TARİHİ";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(380, 88);
                            cmbtarih.Visible = true;
                            cmbtarih.Location = new Point(10, 60);
                            TarihBas();
                            EskiVeriyiSec();
                            cmbtarih.Focus();
                            break;
                        case 4:
                            lblbaslik.Text = "SINAV SAATİ";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(240, 88);
                            cmbsaat.Visible = true;
                            cmbsaat.Location = new Point(10, 60);
                            SaatBas();
                            EskiVeriyiSec();
                            cmbsaat.Focus();
                            break;
                        case 5:
                            if (Gözetmen == 0) { lblbaslik.Text = "ÖĞRETİM ELEMANI"; }
                            else { lblbaslik.Text = "GÖZETMEN"; }
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(380, 88);
                            cmbogretimelemani.Visible = true;
                            cmbogretimelemani.Location = new Point(10, 60);
                            OgretimElemaniBas();
                            EskiVeriyiSec();
                            cmbogretimelemani.Focus();
                            break;
                        case 6:
                            lblbaslik.Text = "DERSLİK";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(240, 88);
                            cmbderslik.Visible = true;
                            cmbderslik.Location = new Point(10, 60);
                            DerslikBas();
                            EskiVeriyiSec();
                            cmbderslik.Focus();
                            break;

                    }
                    if (SinavProgrami.KonumX < Screen.PrimaryScreen.Bounds.Width / 2)
                    {
                        while (SinavProgrami.KonumY + 130 >= Screen.PrimaryScreen.Bounds.Height)
                        {
                            SinavProgrami.KonumY -= 10;
                        }
                        this.Location = new Point(SinavProgrami.KonumX, SinavProgrami.KonumY);

                    }
                    else //Çalışmıyor olabilir kontrol et
                    {
                        while (SinavProgrami.KonumY + 130 >= Screen.PrimaryScreen.Bounds.Height)
                        {
                            SinavProgrami.KonumY -= 10;
                        }
                        this.Location = new Point(SinavProgrami.KonumX - 300, SinavProgrami.KonumY);
                    }

                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Düzenleme Sayfası Açılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
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

        #region Buton Hoverı
        private void btnmavi1_MouseHover(object sender, EventArgs e)
        {
            btnmavi1.BackColor = Color.FromArgb(49, 158, 152);
        }

        private void btnmavi1_MouseLeave(object sender, EventArgs e)
        {
            btnmavi1.BackColor = Color.FromArgb(44, 171, 227);
        }

        #endregion


        #endregion

        #region Dışarıda Tanımlananlar
        public static byte YapilanIslem { get; set; }
        public static byte Derslik { get; set; }
        public static byte Gözetmen { get; set; }

        VeritabaniIslemler islemler = new VeritabaniIslemler();


        MySqlDataReader dr;
        DataTable dt;

        string komut = "";
        DateTime starih;
        DateTime ssaat;
        DialogResult cevap;

        string Gozetmen1 = "0";
        string Gozetmen2 = "0";
        string Gozetmen3 = "0";

        #endregion

        #region Tarih Bas
        public void TarihBas()
        {
            try
            {
                komut = "select * from sinavtarihleri order by tarih asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    DateTime tarih = Convert.ToDateTime(dr.GetString("tarih"));
                    cmbtarih.Items.Add(tarih.ToShortDateString());
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                MessageBox.Show("Tarihler Basılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }

        }
        #endregion
        #region Saat Bas
        public void SaatBas()
        {
            try
            {
                komut = "select * from sinavsaatleri order by saat asc";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    DateTime saat = Convert.ToDateTime(dr.GetString("saat"));
                    cmbsaat.Items.Add(saat.ToShortTimeString());
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                MessageBox.Show("Saat Basılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }

        }
        #endregion
        #region Öğretim Elemanı Bas
        public void OgretimElemaniBas()
        {
            islemler = new VeritabaniIslemler();
            try
            {
                if (Gözetmen != 0)
                {
                    komut = "select Gozetmen1,Gozetmen2,Gozetmen3 from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0)) { Gozetmen1 = dr.GetString("Gozetmen1"); }
                        if (!dr.IsDBNull(1)) { Gozetmen2 = dr.GetString("Gozetmen2"); }
                        if (!dr.IsDBNull(2)) { Gozetmen3 = dr.GetString("Gozetmen3"); }
                    }
                    islemler.Kapat();
                }

                switch (Gözetmen)
                {
                    case 0:
                        komut = "select * from ogretimelemani order by unvan asc";
                        break;
                    case 1:
                        komut = "select  unvan,Ad_Soyad from ogretimelemani where concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen2 + "' and concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen3 + "';";
                        break;
                    case 2:
                        komut = "select  unvan,Ad_Soyad from ogretimelemani where concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen1 + "' and concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen3 + "';";
                        break;
                    case 3:
                        komut = "select  unvan,Ad_Soyad from ogretimelemani where concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen1 + "' and concat(unvan,' ',Ad_Soyad)<>'" + Gozetmen2 + "';";
                        break;
                }

                dr = islemler.Oku(komut);
                if (Gözetmen != 0)
                {
                    cmbogretimelemani.Items.Add("Hiçbiri..");
                }
                while (dr.Read())
                {
                    string birlesik = dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad");
                    cmbogretimelemani.Items.Add(birlesik);
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                MessageBox.Show("Öğretim Elemanı Basılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }

        }
        #endregion
        #region Derslik Bas
        public void DerslikBas()
        {
            try
            {
                //Sınav Tablosundaki Seçili Dersliklerin Alındığı Yer
                string Derslik1 = "0", Derslik2 = "0", Derslik3 = "0", Derslik4 = "0";
                komut = "select Derslik1,Derslik2,Derslik3,Derslik4 from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                dr = islemler.Oku(komut);
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0)) { Derslik1 = dr.GetString("Derslik1"); }
                    if (!dr.IsDBNull(1)) { Derslik2 = dr.GetString("Derslik2"); }
                    if (!dr.IsDBNull(2)) { Derslik3 = dr.GetString("Derslik3"); }
                    if (!dr.IsDBNull(3)) { Derslik4 = dr.GetString("Derslik4"); }
                }
                islemler.Kapat();

                //Derslik Tablosundaki verilerin geçici Tabloya Kopyalanması
                komut = "select * from sinavderslikleri";
                dt = new DataTable();
                dt = islemler.Al(komut);


                cmbderslik.Items.Add("Hiçbiri.."); //Kullanıcı Boş Seçerse Diye 0. indexe boş veri ekleniyor

                //SınavProgramı sayfasından gelen -düzenlenen derslik numarası - veriye göre kullanıcının yönlendirilmesi ya da verilerin basılması
                switch (Derslik)
                {
                    case 1:
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["derslik"].ToString() != Derslik2 && dt.Rows[i]["derslik"].ToString() != Derslik3 && dt.Rows[i]["derslik"].ToString() != Derslik4)
                            {
                                string birlesik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                cmbderslik.Items.Add(birlesik);
                            }
                        }
                        break;
                    case 2:
                        if (Derslik1 == "0")
                        {
                            MessageBox.Show("Lütfen Önce 1. Dersliği Seçiniz!", "UYARI!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["derslik"].ToString() != Derslik1 && dt.Rows[i]["derslik"].ToString() != Derslik3 && dt.Rows[i]["derslik"].ToString() != Derslik4)
                                {
                                    string birlesik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                    cmbderslik.Items.Add(birlesik);
                                }
                            }
                        }
                        break;
                    case 3:
                        if (Derslik2 == "0")
                        {
                            MessageBox.Show("Lütfen Önce 2. Dersliği Seçiniz!", "UYARI!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();

                        }
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["derslik"].ToString() != Derslik1 && dt.Rows[i]["derslik"].ToString() != Derslik2 && dt.Rows[i]["derslik"].ToString() != Derslik4)
                                {
                                    string birlesik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                    cmbderslik.Items.Add(birlesik);
                                }
                            }
                        }
                        break;
                    case 4:
                        if (Derslik3 == "0")
                        {
                            MessageBox.Show("Lütfen Önce 3. Dersliği Seçiniz!", "UYARI!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();

                        }
                        else
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["derslik"].ToString() != Derslik1 && dt.Rows[i]["derslik"].ToString() != Derslik2 && dt.Rows[i]["derslik"].ToString() != Derslik3)
                                {
                                    string birlesik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                    cmbderslik.Items.Add(birlesik);
                                }
                            }
                        }

                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Derslik Basılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }


        }
        public void YerlesenOgrenciBelirle()
        {
            try
            {
                //Derslik Tablosu Geçici Bir Tabloya Kopyalanıyor
                komut = "select * from sinavderslikleri";
                dt = new DataTable();
                dt = islemler.Al(komut);

                int ogrencisayisi = 0;
                string Derslik1 = "0";
                string Derslik2 = "0";
                string Derslik3 = "0";
                string Derslik4 = "0";

                //Sınav Tablosundan Düzenlenen Satırın Derslikleri Çekiliyor
                komut = "select Ogr_Sayisi,Derslik1,Derslik2,Derslik3,Derslik4 from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                dr = islemler.Oku(komut);
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0)) { ogrencisayisi = int.Parse(dr.GetString("Ogr_Sayisi")); }
                    if (!dr.IsDBNull(1)) { Derslik1 = dr.GetString("Derslik1"); }
                    if (!dr.IsDBNull(2)) { Derslik2 = dr.GetString("Derslik2"); }
                    if (!dr.IsDBNull(3)) { Derslik3 = dr.GetString("Derslik3"); }
                    if (!dr.IsDBNull(4)) { Derslik4 = dr.GetString("Derslik4"); }
                }
                islemler.Kapat();

                //Sınav Tablosundan Çekilen Dersliklerin Kapasitesi Alınıyor
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["derslik"].ToString() == Derslik1) { Derslik1 = dt.Rows[i]["sayi"].ToString(); }
                    else if (dt.Rows[i]["derslik"].ToString() == Derslik2) { Derslik2 = dt.Rows[i]["sayi"].ToString(); }
                    else if (dt.Rows[i]["derslik"].ToString() == Derslik3) { Derslik3 = dt.Rows[i]["sayi"].ToString(); }
                    else if (dt.Rows[i]["derslik"].ToString() == Derslik4) { Derslik4 = dt.Rows[i]["sayi"].ToString(); }
                }
                int toplamkapasite = 0;

                //Kapasitelerin Düzgün Alınıp Alınmadığına Bakılıyor
                if (Derslik1.All(char.IsDigit)) { toplamkapasite += int.Parse(Derslik1); }
                if (Derslik2.All(char.IsDigit)) { toplamkapasite += int.Parse(Derslik2); }
                if (Derslik3.All(char.IsDigit)) { toplamkapasite += int.Parse(Derslik3); }
                if (Derslik4.All(char.IsDigit)) { toplamkapasite += int.Parse(Derslik4); }

                //Eğer kapasite öğrenci sayısından küçükse ekrana yerleşen öğrenci sayısına kapasite basılıyor,değilse öğrenci sayısı basılıyor
                if (ogrencisayisi > toplamkapasite) { komut = "update " + Home.donem + " set Y_Ogr_Sayisi=" + toplamkapasite + " where id=" + SinavProgrami.sinavid + ";"; }
                else { komut = "update " + Home.donem + " set Y_Ogr_Sayisi=" + ogrencisayisi + " where id=" + SinavProgrami.sinavid + ";"; }
                islemler.Degistir(komut);

            }
            catch (Exception err)
            {
                MessageBox.Show("Yerleşen Öğrenci Sayısı Belirlenirken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }




        }

        #endregion

        #region Eski Veriyi Bas

        public void EskiVeriyiSec()
        {
            try
            {
                komut = "select * from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                dr = islemler.Oku(komut);
                switch (YapilanIslem)
                {
                    case 1:
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(3))
                            {
                                cmbogretimsekli.SelectedItem = dr.GetString("Ogr_Sekli");
                            }
                        }
                        break;
                    case 2:
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(7))
                            {
                                txtogrencisayisi.Text = dr.GetString("Ogr_Sayisi");
                            }
                        }
                        break;
                    case 3:
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(10))
                            {
                                DateTime tarih = Convert.ToDateTime(dr.GetString("Tarih"));
                                cmbtarih.SelectedItem = tarih.ToShortDateString();
                            }
                        }
                        break;
                    case 4:
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(11))
                            {
                                DateTime saat = Convert.ToDateTime(dr.GetString("Saat"));
                                cmbsaat.SelectedItem = saat.ToShortTimeString();
                            }
                        }
                        break;
                    case 5:
                        if (dr.Read())
                        {
                            switch (Gözetmen)
                            {
                                case 0:
                                    if (!dr.IsDBNull(8) && !dr.IsDBNull(9))
                                    {
                                        cmbogretimelemani.SelectedItem = dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad");
                                    }
                                    if (dr.IsDBNull(11) || dr.IsDBNull(10))
                                    {
                                        MessageBox.Show("Lütfen Önce Tarih ve Saati Seçiniz!");
                                        islemler.Kapat();
                                        this.DialogResult = DialogResult.Abort;
                                        this.Close();
                                    }
                                    break;
                                case 1:
                                    if (!dr.IsDBNull(17))
                                    {
                                        cmbogretimelemani.SelectedItem = dr.GetString("Gozetmen1");
                                    }
                                    break;
                                case 2:
                                    if (!dr.IsDBNull(18))
                                    {
                                        cmbogretimelemani.SelectedItem = dr.GetString("Gozetmen2");
                                    }
                                    if (dr.IsDBNull(17))
                                    {
                                        MessageBox.Show("Lütfen Önce 1. Gözetmeni Seçiniz!");
                                        islemler.Kapat();
                                        this.DialogResult = DialogResult.Abort;
                                        this.Close();
                                    }
                                    break;
                                case 3:
                                    if (!dr.IsDBNull(19))
                                    {
                                        cmbogretimelemani.SelectedItem = dr.GetString("Gozetmen3");
                                    }
                                    if (dr.IsDBNull(18))
                                    {
                                        MessageBox.Show("Lütfen Önce 2. Gözetmeni Seçiniz!");
                                        islemler.Kapat();
                                        this.DialogResult = DialogResult.Abort;
                                        this.Close();
                                    }

                                    break;
                            }


                        }
                        break;
                    case 6:
                        string derslik = "0";

                        if (dr.Read())
                        {
                            switch (Derslik)
                            {
                                case 1:
                                    if (!dr.IsDBNull(12))
                                    {
                                        derslik = dr.GetString("Derslik1");
                                    }
                                    break;
                                case 2:
                                    if (!dr.IsDBNull(13))
                                    {
                                        derslik = dr.GetString("Derslik2");
                                    }
                                    break;
                                case 3:
                                    if (!dr.IsDBNull(14))
                                    {
                                        derslik = dr.GetString("Derslik3");
                                    }
                                    break;
                                case 4:
                                    if (!dr.IsDBNull(15))
                                    {
                                        derslik = dr.GetString("Derslik4");
                                    }
                                    break;

                            }
                            if (dr.IsDBNull(11) || dr.IsDBNull(10) || dr.IsDBNull(7))
                            {
                                MessageBox.Show("Lütfen Önce Tarihi, Saatini Seçiniz ve Öğrenci Sayısınıı Giriniz!");
                                islemler.Kapat();
                                this.DialogResult = DialogResult.Abort;
                                this.Close();
                            }
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["derslik"].ToString() == derslik)
                            {
                                derslik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                break;
                            }
                        }
                        cmbderslik.SelectedItem = derslik;

                        break;
                }
                islemler.Kapat();

            }
            catch (Exception err)
            {
                MessageBox.Show("Eski veri Seçilirken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                islemler.Kapat();
                this.Close();
            }

        }

        #endregion

        #region ESC ' ye / Enter 'a Basıldığında Yapılacaklar
        private void FormOgretimSekli_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //ESC'ye Basıldığında Formu Kapat

                if (e.KeyChar == (char)Keys.Escape)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else if (e.KeyChar == (char)Keys.Enter)             //ENTER'a Basıldığında Formu Kapat
                {
                    btnmavi1.PerformClick();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Öğrenci Sayısı Keypress Alınırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

        }
        #endregion

        #region Kaydet Butonu

        private void btnmavi1_Click(object sender, EventArgs e)
        {
            Sorgu();
        }
        #endregion
        #region Sorgu Methodu

        public void Sorgu()
        {
            try
            {
                switch (YapilanIslem)
                {
                    case 1:
                        if (cmbogretimsekli.SelectedIndex != -1) { Kaydet(); }
                        else { MessageBox.Show("Lütfen Öğretim Şeklini Seçiniz!", "UYARI"); }
                        break;
                    case 2:
                        if (txtogrencisayisi.Text != "") { Kaydet(); }
                        else { MessageBox.Show("Lütfen Öğrenci Sayısını Yazınız!", "UYARI"); }
                        break;
                    case 3:
                        if (cmbtarih.SelectedIndex != -1) { Kaydet(); }
                        else { MessageBox.Show("Lütfen Sınav Tarihini Seçiniz!", "UYARI"); }
                        break;
                    case 4:
                        if (cmbsaat.SelectedIndex != -1) { Kaydet(); }
                        else { MessageBox.Show("Lütfen Sınav Saatini Seçiniz!", "UYARI"); }
                        break;
                    case 5:
                        if (cmbogretimelemani.SelectedIndex != -1) { Kaydet(); }
                        else { MessageBox.Show("Lütfen Öğretim Elamanını Seçiniz!", "UYARI"); }
                        break;
                    case 6:
                        if (cmbderslik.SelectedIndex != -1) { Kaydet(); }
                        else { MessageBox.Show("Lütfen Dersliği Seçiniz!", "UYARI"); }
                        break;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Sorgu Alanında Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

        }
        #endregion
        #region Öğretim Elemanı Sayfasında GÖzetmenlik Sayısının Azaltılıp Arttırılması

        public void GozetmenlikSayisiDuzenle(bool islem, string Gozetmen)
        {
            islemler = new VeritabaniIslemler();
            if (islem) // Eğer işlem true ise öğretimelemanı tablosundaki seçili gözetmenin gözetmenlik sayısı arttırılıyor
            {
                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi+1 where concat(unvan,' ', Ad_Soyad)='" + Gozetmen + "';";
            }
            else //false ise azaltılıyor
            {
                komut = "UPDATE ogretimelemani SET Gozetmenlik_Sayisi=Gozetmenlik_Sayisi-1 where concat(unvan,' ', Ad_Soyad)='" + Gozetmen + "';";
            }
            islemler.Degistir(komut);
        }
        #endregion

        #region Gözetmen Kodları Kısaltması
        public void SeciliGozetmeniKaydet(string seciliogretmen, string eskigozetmen, byte gozetmenno)
        {

            //Kod Tekrarı Olduğu İçin Bu kod Alanları Method İçinde Yazıldı
            switch (gozetmenno) //Gözetmen numarasına göre tablodaki gözetmen değeri güncelleniyor
            {
                case 1:
                    komut = "UPDATE " + Home.donem + " SET Gozetmen1='" + seciliogretmen + "' where id=" + SinavProgrami.sinavid + ";";
                    islemler.Degistir(komut);
                    break;
                case 2:
                    komut = "UPDATE " + Home.donem + " SET Gozetmen2='" + seciliogretmen + "' where id=" + SinavProgrami.sinavid + ";";
                    islemler.Degistir(komut);
                    break;
                case 3:
                    komut = "UPDATE " + Home.donem + " SET Gozetmen3='" + seciliogretmen + "' where id=" + SinavProgrami.sinavid + ";";
                    islemler.Degistir(komut);
                    break;
            }


            if (eskigozetmen != seciliogretmen) // Yeni Gözetmen Eski Gözetmen ile aynı aynı değil ise
            {
                if (eskigozetmen != "0") // ve eski gözetmen boş değil ise yapılacaklar
                {
                    GozetmenlikSayisiDuzenle(true, seciliogretmen); //yeni gözetmenin gözetmenlik sayısı arttırılıyor
                    GozetmenlikSayisiDuzenle(false, eskigozetmen); // eski gözetmenin gözetmenlik sayısı azaltırlıyor
                }
                else // boş ise yapılacakalr
                {
                    GozetmenlikSayisiDuzenle(true, seciliogretmen); //yeni gözetmenin gözetmenlik sayısı arttırılıyor
                }

            }

        }
        #endregion

        #region Kaydet Methodu

        public void Kaydet()
        {
            try
            {
                switch (YapilanIslem)
                {
                    case 1:

                        komut = "UPDATE " + Home.donem + " SET Ogr_Sekli='" + cmbogretimsekli.SelectedItem.ToString() + "' where id=" + SinavProgrami.sinavid + "";

                        islemler.Degistir(komut);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 2:

                        if (txtogrencisayisi.Text == "0")
                        {
                            komut = "UPDATE " + Home.donem + " SET Ogr_Sayisi=null, Derslik1=null, Derslik2=null, Derslik3=null, Derslik4=null,Y_Ogr_Sayisi=null  where id=" + SinavProgrami.sinavid + "";
                            islemler.Degistir(komut);

                        }
                        else
                        {
                            komut = "UPDATE " + Home.donem + " SET Ogr_Sayisi='" + txtogrencisayisi.Text + "' where id=" + SinavProgrami.sinavid + "";
                            islemler.Degistir(komut);
                            YerlesenOgrenciBelirle();

                        }

                        //Yerleşen Öğrenci Renk Ataması

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 3:

                        DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem);
                        komut = "UPDATE " + Home.donem + " SET Tarih='" + tarih.ToString("yyyy-MM-dd") + "' where id=" + SinavProgrami.sinavid + "";

                        islemler.Degistir(komut);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 4:

                        DateTime saat = Convert.ToDateTime(cmbsaat.SelectedItem);
                        komut = "UPDATE " + Home.donem + " SET Saat='" + saat.ToShortTimeString() + "' where id=" + SinavProgrami.sinavid + "";

                        islemler.Degistir(komut);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 5: // Öğretim Elemanı ve Gözetmenin Kaydedildiği Alan

                        //Değişkenler Tannımlanıyor
                        string secilitarih = "";
                        string secilisaat = "";
                        string eskiogretmen = "";
                        string yeniogretmenunvan = "", yeniogretmenadsoyad = "";

                        Gozetmen1 = "0";
                        Gozetmen2 = "0";
                        Gozetmen3 = "0";

                        //Sınav Tablosundan Gözetmen Değerleri,Tarih,Saat ve Eski Öğretim Elamanı Bilgileri Alınıyor
                        komut = "select * from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            secilitarih = dr.GetString("Tarih");
                            secilisaat = dr.GetString("Saat");
                            if (!dr.IsDBNull(8) && !dr.IsDBNull(9))
                            {
                                eskiogretmen = dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad");
                            }
                            if (!dr.IsDBNull(17)) { Gozetmen1 = dr.GetString("Gozetmen1"); }
                            if (!dr.IsDBNull(18)) { Gozetmen2 = dr.GetString("Gozetmen2"); }
                            if (!dr.IsDBNull(19)) { Gozetmen3 = dr.GetString("Gozetmen3"); }
                        }
                        islemler.Kapat();

                        //Sınav Tablosundan Alınan String Türündeki Tarih ve Saat Kendi Türlerine Dönüştürülüyor
                        starih = Convert.ToDateTime(secilitarih);
                        ssaat = Convert.ToDateTime(secilisaat);

                        switch (Gözetmen)
                        {
                            case 0: //Eğer 0 ise öğretim elemanı bilgileri kaydediliyor

                                //Seçilen Öğretim Elemanının Sınav Tablsunda aynı tarih ve saatte başka sınavı var mı kontrol ediliyor
                                komut = "Select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' and id<>" + SinavProgrami.sinavid + "";
                                dr = islemler.Oku(komut);

                                cevap = DialogResult.Yes;
                                if (dr.Read())//Eğer Tabloda Seçilen tarihte ve saatte aynı öğretim elemanının sınavı var ise bu işlemleri yapacak
                                {
                                    islemler.Kapat();
                                    cevap = MessageBox.Show("Seçilen Tarih ve Saatte Öğretim Görevlisinin Başka Bir Sınavı Bulunmakta! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                    if (cevap == DialogResult.Yes)
                                    {
                                        //yeni öğretim elemanının ünvanını ve adsoyadını ayrı ayrı almak
                                        komut = "select * from ogretimelemani where concat(unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "'";
                                        dr = islemler.Oku(komut);
                                        if (dr.Read())
                                        {
                                            yeniogretmenunvan = dr.GetString("unvan");
                                            yeniogretmenadsoyad = dr.GetString("Ad_Soyad");
                                        }
                                        islemler.Kapat();
                                        //-----------------


                                        if (eskiogretmen != cmbogretimelemani.SelectedItem.ToString())
                                        {
                                            //eski öğretim elemanının kendi sınav sayısının düşürülmesi
                                            komut = "UPDATE ogretimelemani SET Kendi_Sinav_Sayisi=Kendi_Sinav_Sayisi-1 where concat(unvan,' ',Ad_Soyad)='" + eskiogretmen + "';";
                                            islemler.Degistir(komut);

                                            //yeni öğretim elemanının kendi sınav sayısının arttırılması
                                            komut = "UPDATE ogretimelemani SET Kendi_Sinav_Sayisi=Kendi_Sinav_Sayisi+1 where concat(unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "';";
                                            islemler.Degistir(komut);

                                        }

                                        //Sınav Tablosunda Kaydın Güncellenmesi
                                        komut = "UPDATE " + Home.donem + " SET Unvan='" + yeniogretmenunvan + "', Ad_Soyad='" + yeniogretmenadsoyad + "' where id=" + SinavProgrami.sinavid + "";
                                        islemler.Degistir(komut);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();

                                    }

                                }
                                else
                                {
                                    //Eğer Tabloda Seçilen tarihte ve saatte aynı öğretim elemanının sınavı yok ise bu işlemleri yapacak

                                    islemler.Kapat();
                                    //yeni öğretim elemanının ünvanını ve adsoyadını ayrı ayrı almak
                                    komut = "select * from ogretimelemani where concat(unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "'";
                                    dr = islemler.Oku(komut);
                                    if (dr.Read())
                                    {
                                        yeniogretmenunvan = dr.GetString("unvan");
                                        yeniogretmenadsoyad = dr.GetString("Ad_Soyad");
                                    }
                                    islemler.Kapat();
                                    //-----------------


                                    if (eskiogretmen != cmbogretimelemani.SelectedItem.ToString())
                                    {
                                        //eski öğretim elemanının kendi sınav sayısının düşürülmesi
                                        komut = "UPDATE ogretimelemani SET Kendi_Sinav_Sayisi=Kendi_Sinav_Sayisi-1 where concat(unvan,' ',Ad_Soyad)='" + eskiogretmen + "';";
                                        islemler.Degistir(komut);

                                        //yeni öğretim elemanının kendi sınav sayısının arttırılması
                                        komut = "UPDATE ogretimelemani SET Kendi_Sinav_Sayisi=Kendi_Sinav_Sayisi+1 where concat(unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "';";
                                        islemler.Degistir(komut);

                                    }

                                    //Sınav Tablosunda Kaydın Güncellenmesi
                                    komut = "UPDATE " + Home.donem + " SET Unvan='" + yeniogretmenunvan + "', Ad_Soyad='" + yeniogretmenadsoyad + "' where id=" + SinavProgrami.sinavid + "";
                                    islemler.Degistir(komut);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();

                                }


                                break;
                            case 1: // 1. Gözetmen için Yapılan işlemler
                                if (cmbogretimelemani.SelectedIndex == 0) // Eğer Gözetmen Hiçbiri Olarak Seçildiyse Yapılacaklar
                                {

                                    GozetmenlikSayisiDuzenle(false, Gozetmen1); //GÖzetmen 1 de kayıtlı olan öğretmenin gözetmenlik sayısı düşürülüyor
                                    GozetmenlikSayisiDuzenle(false, Gozetmen2);//GÖzetmen 2 de kayıtlı olan öğretmenin gözetmenlik sayısı düşürülüyor
                                    GozetmenlikSayisiDuzenle(false, Gozetmen3);//GÖzetmen 3 de kayıtlı olan öğretmenin gözetmenlik sayısı düşürülüyor

                                    //Tablodaki Bütün Gözetmenlerin değerleri null yapılıyor
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen1=null,Gozetmen2=null,Gozetmen3=null where id=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and id<>" + SinavProgrami.sinavid + ";";
                                    dr = islemler.Oku(komut);
                                    if (dr.Read()) // Eğer var ise Bu alandakiler Yapılacak
                                    {
                                        islemler.Kapat();
                                        cevap = MessageBox.Show("Öğretim Görevlisinin Seçilen Tarih ve Saatte Başka Bir Sınavı ya da Gözetmenlik Görevi Bulunuyor! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                        if (cevap == DialogResult.Yes)
                                        {
                                            //Düzenlenen sınavın öğretim elemanı ile gözetmeni aynı mı diye bakılıyor
                                            if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                            {   //aynı ise yapılacaklar
                                                cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                                if (cevap == DialogResult.Yes)
                                                {
                                                    //1. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                    SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen1, 1);

                                                    this.DialogResult = DialogResult.OK;
                                                    this.Close();
                                                }
                                            }
                                            else
                                            { //degil ise yapılacaklar

                                              //1. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen1, 1);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                    }
                                    else
                                    {   //Eğer GÖzetmenin sınavı ya da gözetmenliği yok ise bu alandakiler yapılacak
                                        islemler.Kapat();
                                        if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                        {
                                            cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                            if (cevap == DialogResult.Yes)
                                            {
                                                //1. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen1, 1);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            //1. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                            SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen1, 1);

                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }

                                    }
                                }
                                break;
                            case 2: // 2. Gözetmen için Yapılan işlemler
                                if (cmbogretimelemani.SelectedIndex == 0)// Eğer Gözetmen Hiçbiri Olarak Seçildiyse Yapılacaklar
                                {
                                    GozetmenlikSayisiDuzenle(false, Gozetmen2);//GÖzetmen 2 de kayıtlı olan öğretmenin gözetmenlik sayısı düşürülüyor
                                    GozetmenlikSayisiDuzenle(false, Gozetmen3);//GÖzetmen 3 de kayıtlı olan öğretmenin gözetmenlik sayısı düşürülüyor
                                    //Tablodaki gözetmen 2 ve 3 değerleri null yapılıyor
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen2=null,Gozetmen3=null where id=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and id<>" + SinavProgrami.sinavid + ";";
                                    dr = islemler.Oku(komut);
                                    if (dr.Read())// Eğer var ise Bu alandakiler Yapılacak
                                    {
                                        islemler.Kapat();
                                        cevap = MessageBox.Show("Öğretim Görevlisinin Seçilen Tarih ve Saatte Başka Bir Sınavı ya da Gözetmenlik Görevi Bulunuyor! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                        if (cevap == DialogResult.Yes)
                                        {//Düzenlenen sınavın öğretim elemanı ile gözetmeni aynı mı diye bakılıyor
                                            if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                            {//aynı ise yapılacaklar
                                                cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                                if (cevap == DialogResult.Yes)
                                                {
                                                    //2. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                    SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen2, 2);

                                                    this.DialogResult = DialogResult.OK;
                                                    this.Close();
                                                }
                                            }
                                            else
                                            {//degil ise yapılacaklar

                                                //2. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen2, 2);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Eğer GÖzetmenin sınavı ya da gözetmenliği yok ise bu alandakiler yapılacak
                                        islemler.Kapat();
                                        if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                        {
                                            cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                            if (cevap == DialogResult.Yes)
                                            {
                                                //2. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen2, 2);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            //2. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                            SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen2, 2);

                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }

                                    }
                                }

                                break;
                            case 3: // 3. Gözetmen için Yapılan işlemler
                                if (cmbogretimelemani.SelectedIndex == 0)// Eğer Gözetmen Hiçbiri Olarak Seçildiyse Yapılacaklar
                                {
                                    GozetmenlikSayisiDuzenle(false, Gozetmen3); //GÖzetmen 3 de kayıtlı olan öğretmenin gözetmenlik

                                    //Tablodaki gözetmen  3 değeri null yapılıyor
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen3=null where id=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and id<>" + SinavProgrami.sinavid + ";";
                                    dr = islemler.Oku(komut);
                                    if (dr.Read()) // Eğer var ise Bu alandakiler Yapılacak
                                    {
                                        islemler.Kapat();
                                        cevap = MessageBox.Show("Öğretim Görevlisinin Seçilen Tarih ve Saatte Başka Bir Sınavı ya da Gözetmenlik Görevi Bulunuyor! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                        if (cevap == DialogResult.Yes)
                                        {  //Düzenlenen sınavın öğretim elemanı ile gözetmeni aynı mı diye bakılıyor
                                            if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                            { //aynı ise yapılacaklar
                                                cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                                if (cevap == DialogResult.Yes)
                                                { //3. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                    SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen3, 3);

                                                    this.DialogResult = DialogResult.OK;
                                                    this.Close();
                                                }
                                            }
                                            else
                                            {//degil ise yapılacaklar 

                                                //3. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen3, 3);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Eğer GÖzetmenin sınavı ya da gözetmenliği yok ise bu alandakiler yapılacak
                                        islemler.Kapat();
                                        if (eskiogretmen == cmbogretimelemani.SelectedItem.ToString())
                                        {
                                            cevap = MessageBox.Show("Öğretim GÖrevlisini Kendi Sınavına GÖzetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                                            if (cevap == DialogResult.Yes)
                                            {
                                                //3. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                                SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen3, 3);

                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            //3. Gözetmen kaydediliyor ve gözetmenlik sayısı arttırılıyor
                                            SeciliGozetmeniKaydet(cmbogretimelemani.SelectedItem.ToString(), Gozetmen3, 3);

                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }

                                    }
                                }
                                break;
                        }



                        break;
                    case 6:


                        //Eğer Derslik Boş Seçilmişse Tablodan TEmizlendiği Alan
                        if (cmbderslik.SelectedIndex == 0)
                        {
                            //Kaçıncı Derslik null Seçildiyse o ve ondan sonrakiler null yapılıyor
                            komut = "UPDATE " + Home.donem + " set ";
                            switch (Derslik)
                            {
                                case 1:
                                    komut += "Derslik1=null, Derslik2=null, Derslik3=null, Derslik4=null, Y_Ogr_Sayisi=null ";
                                    break;
                                case 2:
                                    komut += "Derslik2=null, Derslik3=null, Derslik4=null";
                                    break;
                                case 3:
                                    komut += "Derslik3=null , Derslik4=null";
                                    break;
                                case 4:
                                    komut += "Derslik4=null";
                                    break;

                            }
                            komut += " where id=" + SinavProgrami.sinavid + ";";
                            islemler.Degistir(komut);

                            //Kalan Dersliklere ve Öğrenci Sayısına Göre Yerleşen Öğrenci Sayısı Belirleniyor
                            YerlesenOgrenciBelirle();

                            // Yerleşen Öğrenci Renk Ataması

                            this.DialogResult = DialogResult.OK;
                            this.Close();


                        }
                        else //Eğer Derslik Dolu İse Tablodan Temizlenilen Alan
                        {
                            secilitarih = "";
                            secilisaat = "";

                            //Sınav Tablosundan Tarih ve Saat Alınıyor
                            komut = "select * from " + Home.donem + " where id=" + SinavProgrami.sinavid + ";";
                            dr = islemler.Oku(komut);
                            if (dr.Read())
                            {
                                secilitarih = dr.GetString("Tarih");
                                secilisaat = dr.GetString("Saat");
                            }
                            islemler.Kapat();

                            starih = Convert.ToDateTime(secilitarih);
                            ssaat = Convert.ToDateTime(secilisaat);

                            //Seçilen Derslik Alınıyor
                            string[] seciliderslik = cmbderslik.SelectedItem.ToString().Split('-');
                            seciliderslik[0] = seciliderslik[0].Trim(); // dizinin 0. elemaanı derslik adı oldu



                            //Tabloda Seçilen Tarih ve Saatte Seçilen Derslik Kullanılıyor mu Diye Bakılıyor
                            komut = "Select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (Derslik1='" + seciliderslik[0] + "' or Derslik2='" + seciliderslik[0] + "' or Derslik3='" + seciliderslik[0] + "' or Derslik4='" + seciliderslik[0] + "'); ";
                            dr = islemler.Oku(komut);

                            //Eğer Kullanılıyorsa Kullanıcıya Kabul Ediyor musunuz diye soruluyor
                            cevap = DialogResult.Yes;
                            if (dr.Read())
                            {
                                cevap = MessageBox.Show("Seçilen Tarih ve Saatte Derslik Başka Bir Sınav İçin Kullanılmakta! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                            }
                            islemler.Kapat();

                            //Eğer Kullanıcı Kabul Ederse Kaydediliyor
                            komut = "UPDATE " + Home.donem + " set ";
                            if (cevap == DialogResult.Yes)
                            {
                                switch (Derslik)
                                {
                                    case 1:
                                        komut += "Derslik1='" + seciliderslik[0] + "'";
                                        break;
                                    case 2:
                                        komut += "Derslik2='" + seciliderslik[0] + "' ";
                                        break;
                                    case 3:
                                        komut += "Derslik3='" + seciliderslik[0] + "' ";
                                        break;
                                    case 4:
                                        komut += "Derslik4='" + seciliderslik[0] + "' ";
                                        break;
                                }
                                komut += "where id=" + SinavProgrami.sinavid + ";";
                                islemler.Degistir(komut);

                                //Derslik Kaydedildikten Sonra Yerleşen Öğrenci Sayısı Belirleniyor
                                YerlesenOgrenciBelirle();

                                //Yerleşen Öğrenci Renk Ataması

                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                        }

                        break;

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Kaydetme Alanında Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

        }
        #endregion


        //Öğrenci Sayısı Sadece Sayı Girişi
        private void txtogrencisayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)Keys.Escape)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else if (e.KeyChar == (char)Keys.Enter)             //ENTER'a Basıldığında Formu Kapat
                {
                    btnmavi1.PerformClick();
                }
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }


            }
            catch (Exception err)
            {
                MessageBox.Show("Öğrenci Sayısı KeyPress Alanında Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
