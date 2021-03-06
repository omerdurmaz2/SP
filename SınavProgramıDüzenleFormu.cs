﻿using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;
using TyroDeveloperDLL;

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
            SinavProgrami sprogrm = new SinavProgrami();
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
                            this.Text = "ÖĞRETİM ŞEKLİ";
                            break;
                        case 2:
                            this.Text = "ÖĞRENCİ SAYISI";
                            lblbaslik.Text = "ÖĞRENCİ SAYISI";
                            this.Size = new Size(240, 78);
                            txtogrencisayisi.Visible = true;
                            txtogrencisayisi.Location = new Point(10, 40);
                            break;
                        case 3:
                            this.Text = "SINAV TARİHİ";
                            lblbaslik.Text = "SINAV TARİHİ";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(380, 88);
                            cmbtarih.Visible = true;
                            cmbtarih.Location = new Point(10, 60);
                            break;
                        case 4:
                            this.Text = "SINAV SAATİ";
                            lblbaslik.Text = "SINAV SAATİ";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(240, 88);
                            cmbsaat.Visible = true;
                            cmbsaat.Location = new Point(10, 60);
                            break;
                        case 5:

                            if (Gözetmen == 0) { lblbaslik.Text = "ÖĞRETİM ELEMANI"; this.Text = "ÖĞRETİM ELEMANI"; }
                            else { lblbaslik.Text = "GÖZETMEN"; this.Text = "GÖZETMEN"; }
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(380, 88);
                            cmbogretimelemani.Visible = true;
                            cmbogretimelemani.Location = new Point(10, 60);
                            break;
                        case 6:
                            this.Text = "DERSLİK";
                            lblbaslik.Text = "DERSLİK";
                            lblseciniz.Visible = true;
                            btnmavi1.Location = new Point(btnmavi1.Location.X, 48);
                            this.Size = new Size(240, 88);
                            cmbderslik.Visible = true;
                            cmbderslik.Location = new Point(10, 60);
                            break;

                    }

                    //Formun ekrandaki konumunun belirlendiği yer
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
                        this.Location = new Point(SinavProgrami.KonumX - this.Width / 4, SinavProgrami.KonumY);
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

        DateTime eskitarih;
        DateTime eskisaat;

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
                dt = new DataTable();
                komut = "select * from sinavtarihleri order by tarih asc";
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["tarih"] != DBNull.Value)
                        {
                            DateTime tarih = Convert.ToDateTime(dt.Rows[i]["tarih"]);
                            cmbtarih.Items.Add(tarih.ToShortDateString());
                        }
                    }
                }
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
                dt = new DataTable();
                komut = "select * from sinavsaatleri order by saat asc";
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["saat"] != DBNull.Value)
                        {
                            DateTime saat = Convert.ToDateTime(dt.Rows[i]["saat"].ToString());
                            cmbsaat.Items.Add(saat.ToShortTimeString());
                        }
                    }
                }
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
                dt = new DataTable();
                komut = "select Tarih,Saat from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] != DBNull.Value) tarih = Convert.ToDateTime(dt.Rows[0][0].ToString());
                    if (dt.Rows[0][1] != DBNull.Value) saat = Convert.ToDateTime(dt.Rows[0][1].ToString());
                }


                if (Gözetmen != 0)
                {
                    dt = new DataTable();
                    komut = "select Gozetmen1,Gozetmen2,Gozetmen3,Tarih,Saat from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
                    dt = islemler.Al(komut);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Gozetmen1"] != DBNull.Value) { Gozetmen1 = dt.Rows[0]["Gozetmen1"].ToString(); }
                        if (dt.Rows[0]["Gozetmen2"] != DBNull.Value) { Gozetmen2 = dt.Rows[0]["Gozetmen2"].ToString(); }
                        if (dt.Rows[0]["Gozetmen3"] != DBNull.Value) { Gozetmen3 = dt.Rows[0]["Gozetmen3"].ToString(); }
                    }
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

                if (Gözetmen != 0)
                {
                    cmbogretimelemani.Items.Add(new ComboBoxItem("Hiçbiri", "0", Color.Black));
                }
                dt = new DataTable();
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Gözetmen == 0)
                        {
                            if (dt.Rows[i]["unvan"] != DBNull.Value && dt.Rows[i]["Ad_Soyad"] != DBNull.Value)
                            {
                                string birlesik = dt.Rows[i]["unvan"] + " " + dt.Rows[i]["Ad_Soyad"];
                                if (Bak(birlesik) == DialogResult.OK) cmbogretimelemani.Items.Add(new ComboBoxItem(birlesik, i, Color.DarkRed));
                                else cmbogretimelemani.Items.Add(new ComboBoxItem(birlesik, i, Color.DarkGreen));
                            }
                        }
                        else
                        {
                            if (dt.Rows[i]["unvan"] != DBNull.Value && dt.Rows[i]["Ad_Soyad"] != DBNull.Value)
                            {
                                string birlesik = dt.Rows[i]["unvan"] + " " + dt.Rows[i]["Ad_Soyad"];
                                if (Bak(birlesik) == DialogResult.OK) cmbogretimelemani.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkRed));
                                else cmbogretimelemani.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkGreen));
                            }
                        }

                    }
                }
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
                dt = new DataTable();
                komut = "select Derslik1,Derslik2,Derslik3,Derslik4,Tarih,Saat from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Derslik1"] != DBNull.Value) { Derslik1 = dt.Rows[0]["Derslik1"].ToString(); }
                    if (dt.Rows[0]["Derslik2"] != DBNull.Value) { Derslik2 = dt.Rows[0]["Derslik2"].ToString(); }
                    if (dt.Rows[0]["Derslik3"] != DBNull.Value) { Derslik3 = dt.Rows[0]["Derslik3"].ToString(); }
                    if (dt.Rows[0]["Derslik4"] != DBNull.Value) { Derslik4 = dt.Rows[0]["Derslik4"].ToString(); }
                    if (dt.Rows[0]["Tarih"] != DBNull.Value) { tarih = Convert.ToDateTime(dt.Rows[0]["Tarih"].ToString()); }
                    if (dt.Rows[0]["Saat"] != DBNull.Value) { saat = Convert.ToDateTime(dt.Rows[0]["Saat"].ToString()); }
                }

                //Derslik Tablosundaki verilerin geçici Tabloya Kopyalanması
                komut = "select * from sinavderslikleri";
                dt = new DataTable();
                dt = islemler.Al(komut);

                cmbderslik.Items.Add(new ComboBoxItem("Hiçbiri...", "0", Color.Black));  //Kullanıcı Boş Seçerse Diye 0. indexe boş veri ekleniyor

                //SınavProgramı sayfasından gelen -düzenlenen derslik numarası - veriye göre kullanıcının yönlendirilmesi ya da verilerin basılması
                switch (Derslik)
                {
                    case 1:
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["derslik"].ToString() != Derslik2 && dt.Rows[i]["derslik"].ToString() != Derslik3 && dt.Rows[i]["derslik"].ToString() != Derslik4)
                            {
                                string birlesik = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                if (Bak(dt.Rows[i]["derslik"].ToString()) == DialogResult.OK)
                                {
                                    cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkRed));
                                }
                                else cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkGreen));
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
                                    if (Bak(dt.Rows[i]["derslik"].ToString()) == DialogResult.OK)
                                    {
                                        cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkRed));
                                    }
                                    else cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkGreen));
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
                                    if (Bak(dt.Rows[i]["derslik"].ToString()) == DialogResult.OK)
                                    {
                                        cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkRed));
                                    }
                                    else cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkGreen));
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
                                    if (Bak(dt.Rows[i]["derslik"].ToString()) == DialogResult.OK)
                                    {
                                        cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkRed));
                                    }
                                    else cmbderslik.Items.Add(new ComboBoxItem(birlesik, i + 1, Color.DarkGreen));
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


                int ogrencisayisi = 0;
                string Derslik1 = "0";
                string Derslik2 = "0";
                string Derslik3 = "0";
                string Derslik4 = "0";

                //Sınav Tablosundan Düzenlenen Satırın Derslikleri Çekiliyor
                dt = new DataTable();
                komut = "select Ogr_Sayisi,Derslik1,Derslik2,Derslik3,Derslik4 from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
                dt = islemler.Al(komut);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Ogr_Sayisi"] != DBNull.Value) { ogrencisayisi = int.Parse(dt.Rows[0]["Ogr_Sayisi"].ToString()); }
                    if (dt.Rows[0]["Derslik1"] != DBNull.Value) { Derslik1 = dt.Rows[0]["Derslik1"].ToString(); }
                    if (dt.Rows[0]["Derslik2"] != DBNull.Value) { Derslik2 = dt.Rows[0]["Derslik2"].ToString(); }
                    if (dt.Rows[0]["Derslik3"] != DBNull.Value) { Derslik3 = dt.Rows[0]["Derslik3"].ToString(); }
                    if (dt.Rows[0]["Derslik4"] != DBNull.Value) { Derslik4 = dt.Rows[0]["Derslik4"].ToString(); }
                }

                //Sınav Tablosundan Çekilen Dersliklerin Kapasitesi Alınıyor
                //Derslik Tablosu Geçici Bir Tabloya Kopyalanıyor
                komut = "select * from sinavderslikleri";
                dt = new DataTable();
                dt = islemler.Al(komut);
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
                if (ogrencisayisi > toplamkapasite) { komut = "update " + Home.donem + " set Y_Ogr_Sayisi=" + toplamkapasite + " where SiraNo=" + SinavProgrami.sinavid + ";"; }
                else { komut = "update " + Home.donem + " set Y_Ogr_Sayisi=" + ogrencisayisi + " where SiraNo=" + SinavProgrami.sinavid + ";"; }
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
                komut = "select * from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
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
                                eskitarih = tarih;
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
                                eskisaat = saat;
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
                                    if (dr.IsDBNull(11) || dr.IsDBNull(10))
                                    {
                                        MessageBox.Show("Lütfen Önce Tarih ve Saati Seçiniz!");
                                        islemler.Kapat();
                                        this.DialogResult = DialogResult.Abort;
                                        this.Close();
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
                    komut = "UPDATE " + Home.donem + " SET Gozetmen1='" + seciliogretmen + "' where SiraNo=" + SinavProgrami.sinavid + ";";
                    islemler.Degistir(komut);
                    break;
                case 2:
                    komut = "UPDATE " + Home.donem + " SET Gozetmen2='" + seciliogretmen + "' where SiraNo=" + SinavProgrami.sinavid + ";";
                    islemler.Degistir(komut);
                    break;
                case 3:
                    komut = "UPDATE " + Home.donem + " SET Gozetmen3='" + seciliogretmen + "' where SiraNo=" + SinavProgrami.sinavid + ";";
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

                        komut = "UPDATE " + Home.donem + " SET Ogr_Sekli='" + cmbogretimsekli.SelectedItem.ToString() + "' where SiraNo=" + SinavProgrami.sinavid + "";

                        islemler.Degistir(komut);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 2:

                        if (txtogrencisayisi.Text == "0")
                        {
                            komut = "UPDATE " + Home.donem + " SET Ogr_Sayisi=null, Derslik1=null, Derslik2=null, Derslik3=null, Derslik4=null,Y_Ogr_Sayisi=null  where SiraNo=" + SinavProgrami.sinavid + "";
                            islemler.Degistir(komut);

                        }
                        else
                        {
                            komut = "UPDATE " + Home.donem + " SET Ogr_Sayisi='" + txtogrencisayisi.Text + "' where SiraNo=" + SinavProgrami.sinavid + "";
                            islemler.Degistir(komut);
                            YerlesenOgrenciBelirle();

                        }

                        //Yerleşen Öğrenci Renk Ataması

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case 3:
                        if (DegisiklikKontrol(0) == DialogResult.Yes)
                        {
                            DateTime tarih = Convert.ToDateTime(cmbtarih.SelectedItem);
                            komut = "UPDATE " + Home.donem + " SET Tarih='" + tarih.ToString("yyyy-MM-dd") + "' where SiraNo=" + SinavProgrami.sinavid + "";

                            islemler.Degistir(komut);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        break;
                    case 4:
                        if (DegisiklikKontrol(1) == DialogResult.Yes)
                        {

                            DateTime saat = Convert.ToDateTime(cmbsaat.SelectedItem);
                            komut = "UPDATE " + Home.donem + " SET Saat='" + saat.ToShortTimeString() + "' where SiraNo=" + SinavProgrami.sinavid + "";

                            islemler.Degistir(komut);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
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
                        komut = "select * from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
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
                                komut = "Select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' and SiraNo<>" + SinavProgrami.sinavid + "";
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
                                        komut = "UPDATE " + Home.donem + " SET Unvan='" + yeniogretmenunvan + "', Ad_Soyad='" + yeniogretmenadsoyad + "' where SiraNo=" + SinavProgrami.sinavid + "";
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
                                    komut = "UPDATE " + Home.donem + " SET Unvan='" + yeniogretmenunvan + "', Ad_Soyad='" + yeniogretmenadsoyad + "' where SiraNo=" + SinavProgrami.sinavid + "";
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
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen1=null,Gozetmen2=null,Gozetmen3=null where SiraNo=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and SiraNo<>" + SinavProgrami.sinavid + ";";
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
                                                cevap = MessageBox.Show("Öğretim Görevlisini Kendi Sınavına Gözetmen Olarak Seçtiniz! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
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
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen2=null,Gozetmen3=null where SiraNo=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and SiraNo<>" + SinavProgrami.sinavid + ";";
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
                                    komut = "UPDATE " + Home.donem + " SET Gozetmen3=null where SiraNo=" + SinavProgrami.sinavid + ";";
                                    islemler.Degistir(komut);

                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    //Sınav Tablosunda seçilen tarih ve saatte gözetmenin sınavı ya da gözetmenliği var mmı diye kontrol ediliyor
                                    komut = "select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen1='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen2='" + cmbogretimelemani.SelectedItem.ToString() + "' or Gozetmen3='" + cmbogretimelemani.SelectedItem.ToString() + "') and SiraNo<>" + SinavProgrami.sinavid + ";";
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
                                    komut += "Derslik1=null, Derslik2=null, Derslik3=null, Derslik4=null, Y_Ogr_Sayisi=0 ";
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
                            komut += " where SiraNo=" + SinavProgrami.sinavid + ";";
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
                            komut = "select * from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + ";";
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
                            komut = "Select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and (Derslik1='" + seciliderslik[0] + "' or Derslik2='" + seciliderslik[0] + "' or Derslik3='" + seciliderslik[0] + "' or Derslik4='" + seciliderslik[0] + "') and SiraNo<>" + SinavProgrami.sinavid + "; ";
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
                                komut += "where SiraNo=" + SinavProgrami.sinavid + ";";
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

        private void SınavProgramıDüzenleFormu_Shown(object sender, EventArgs e)
        {
            SinavProgrami sprogrm = new SinavProgrami();
            try
            {

                switch (YapilanIslem)
                {
                    case 1:
                        EskiVeriyiSec();
                        cmbogretimsekli.Focus();
                        break;
                    case 2:
                        EskiVeriyiSec();
                        txtogrencisayisi.Focus();
                        txtogrencisayisi.SelectAll();
                        break;
                    case 3:
                        TarihBas();
                        EskiVeriyiSec();
                        cmbtarih.Focus();
                        break;
                    case 4:
                        SaatBas();
                        EskiVeriyiSec();
                        cmbsaat.Focus();
                        break;
                    case 5:
                        OgretimElemaniBas();
                        EskiVeriyiSec();
                        cmbogretimelemani.Focus();
                        break;
                    case 6:
                        DerslikBas();
                        EskiVeriyiSec();
                        cmbderslik.Focus();
                        break;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Düzenleme Sayfası Açılırken Hata! \nHata Kodu:" + err, "HATA!");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

        }

        #region Tarih ve Saat Değişikliğinde Derslik/Öğrement/Gözetmen Kontrolü

        //iki methodta da kullanılacak global değişkenler
        DateTime tarih = DateTime.Now;
        DateTime saat = DateTime.Now;
        public DialogResult DegisiklikKontrol(byte ts)
        {
            try
			{
				//id si çekilen satırdaki verilerin tutulacağı değişkenler
				string progkod = "";
				string progad = "";
				string adsoyad = "";
				string Derslik1 = "";
				string Derslik2 = "";
				string Derslik3 = "";
				string Derslik4 = "";
				string gozetmen1 = "";
				string gozetmen2 = "";
				string gozetmen3 = "";
				komut = "select Unvan,Ad_Soyad,Prg_Kod,Prg_Ad,Derslik1,Derslik2,Derslik3,Derslik4,Gozetmen1,Gozetmen2,Gozetmen3,Tarih,Saat from " + Home.donem + " where SiraNo=" + SinavProgrami.sinavid + "";
				DataTable tablo = new DataTable();
				tablo = islemler.Al(komut);

				//tabloya aktarılan satırın verileri değişkenlere aktarılıyor
				if (tablo.Rows.Count != 0)
				{
					adsoyad = tablo.Rows[0][0].ToString() + " " + tablo.Rows[0][1].ToString();
					progkod = tablo.Rows[0][2].ToString();
					progad = tablo.Rows[0][3].ToString();
					Derslik1 = tablo.Rows[0][4].ToString();
					Derslik2 = tablo.Rows[0][5].ToString();
					Derslik3 = tablo.Rows[0][6].ToString();
					Derslik4 = tablo.Rows[0][7].ToString();
					gozetmen1 = tablo.Rows[0][8].ToString();
					gozetmen2 = tablo.Rows[0][9].ToString();
					gozetmen3 = tablo.Rows[0][10].ToString();
					tarih = Convert.ToDateTime(tablo.Rows[0][11].ToString());
					saat = Convert.ToDateTime(tablo.Rows[0][12].ToString());
				}

				//eğer güncellenecek tarih eski tarih ise işlem yapılmıyor
				if (ts == 0)
				{
					tarih = Convert.ToDateTime(cmbtarih.SelectedItem);
					if (tarih == eskitarih)
					{
						return DialogResult.Yes;
					}
				} //eğer güncellenecek saat eski saat ise işlem yapılmıyor
				else
				{

					saat = Convert.ToDateTime(cmbsaat.SelectedItem);
					if (saat == eskisaat)
					{
						return DialogResult.Yes;
					}

				}

				// değişkenlerdeki veriler sırasıyla kontrol edilmek üzere bak methoduna gönderiliyor ve methodtan gelen cavaba göre uyarı mesajı düzenleniyor
				string uyari = "Güncellenecek (Tarih / Saatte);\n";
				if (Bak(progkod) == DialogResult.OK && Bak(progad) == DialogResult.OK) uyari +="\n+ Bölümün Başka Bir Sınavı Bulunmakta!!!";
				if (Bak(adsoyad) == DialogResult.OK) uyari += "\n+ Öğretim Elemanının Görevli Olduğu Başka Bir Sınav Bulunmakta!";
				if (Derslik1 != "" && Bak(Derslik1) == DialogResult.OK) uyari += "\n+ 1. Derslik Kullanılmakta!";
				if (Derslik2 != "" && Bak(Derslik2) == DialogResult.OK) uyari += "\n+ 2. Derslik Kullanılmakta!";
				if (Derslik3 != "" && Bak(Derslik3) == DialogResult.OK) uyari += "\n+ 3. Derslik Kullanılmakta!";
				if (Derslik4 != "" && Bak(Derslik4) == DialogResult.OK) uyari += "\n+ 4. Derslik Kullanılmakta!";
				if (gozetmen1 != "" && Bak(gozetmen1) == DialogResult.OK) uyari += "\n+ 1. Gözetmenin Görevli Olduğu Başka Bir Sınav Bulunmakta!";
				if (gozetmen2 != "" && Bak(gozetmen2) == DialogResult.OK) uyari += "\n+ 2. Gözetmenin Görevli Olduğu Başka Bir Sınav Bulunmakta!";
				if (gozetmen3 != "" && Bak(gozetmen3) == DialogResult.OK) uyari += "\n+ 3. Gözetmenin Görevli Olduğu Başka Bir Sınav Bulunmakta!";

				//eğer uyarı mesajına ekleme yapılmışsa kullanıcıya yansıtılıyor ve cevaba göre işlem yapılıyor
				if (uyari.Substring(uyari.Length - 1, 1) != "\n")
				{
					uyari += "\n\nKabul ediyor musunuz?";
					return MessageBox.Show(uyari, "UYARI!!", MessageBoxButtons.YesNo);
				}//eğer uyarı mesajı değişmemiş ise işlem yapılmıyor
				else return DialogResult.Yes;

			}
			catch (Exception err)
			{
				MessageBox.Show("Tarih Saat Değişikliğinde Veri Kontrolü Yaparken Hata!\nHata Kodu: " + err.ToString());
				return DialogResult.No;
			}
        }

        public DialogResult Bak(string bakilacak)
        {
            try
            {
                komut = "select Unvan,Ad_Soyad,Derslik1,Derslik2,Derslik3,Derslik4,Gozetmen1,Gozetmen2,Gozetmen3 from " + Home.donem + " where Tarih='" + tarih.ToString("yyyy-MM-dd") + "' and Saat='" + saat.ToShortTimeString() + "'";
                DataTable tablo = new DataTable();
                tablo = islemler.Al(komut); //seçili olan tarih ve saatteki bütün veriler tabloya aktarılıyor

                for (int i = 0; i < tablo.Rows.Count; i++)
                {//tablodaki bütün satırlar sırayla methoda gelen bakılacak değer ile karşılaştırılıyor.
                    //Eğer eşleşme olursa geriye ok mesajı gönderiliyor ve çağırılan yerde cevaba göre uyarı mesajı düzenleniyor
                    if (
                        (tablo.Rows[i][0].ToString() + " " + tablo.Rows[i][1].ToString()) == bakilacak ||
                        tablo.Rows[i][2].ToString() == bakilacak ||
                        tablo.Rows[i][3].ToString() == bakilacak ||
                        tablo.Rows[i][4].ToString() == bakilacak ||
                        tablo.Rows[i][5].ToString() == bakilacak ||
                        tablo.Rows[i][6].ToString() == bakilacak ||
                        tablo.Rows[i][7].ToString() == bakilacak ||
                        tablo.Rows[i][8].ToString() == bakilacak
                        )
                    {
                        return DialogResult.OK;
                    }
                }
                return DialogResult.No;

            }
            catch (Exception err)
            {
                MessageBox.Show("Tarih Saat Değişikliğinde Veri Kontrolü Yaparken Hata!\nHata Kodu: " + err.ToString());
                return DialogResult.No;
            }
        }
        #endregion
    }
}
