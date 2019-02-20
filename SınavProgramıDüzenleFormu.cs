using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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
            if (SinavProgrami.sinavid > 0)
            {

                switch (YapilanIslem)
                {
                    case 1:
                        lblbaslik.Text = "ÖĞRETİM ŞEKLİ";
                        this.Size = new Size(240, 78);
                        cmbogretimsekli.Location = new Point(10, 40);
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
                        this.Size = new Size(380, 78);
                        cmbtarih.Visible = true;
                        cmbtarih.Location = new Point(10, 40);
                        TarihBas();
                        EskiVeriyiSec();
                        cmbtarih.Focus();
                        break;
                    case 4:
                        lblbaslik.Text = "SINAV SAATİ";
                        this.Size = new Size(240, 78);
                        cmbsaat.Visible = true;
                        cmbsaat.Location = new Point(10, 40);
                        SaatBas();
                        EskiVeriyiSec();
                        cmbsaat.Focus();
                        break;
                    case 5:
                        lblbaslik.Text = "ÖĞRETİM ELEMANI";
                        this.Size = new Size(380, 78);
                        cmbogretimelemani.Visible = true;
                        cmbogretimelemani.Location = new Point(10, 40);
                        OgretimElemaniBas();
                        EskiVeriyiSec();
                        cmbogretimelemani.Focus();
                        break;
                    case 6:
                        lblbaslik.Text = "DERSLİK";
                        this.Size = new Size(240, 78);
                        cmbderslik.Visible = true;
                        cmbderslik.Location = new Point(10, 40);
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

        VeritabaniIslemler islemler = new VeritabaniIslemler();

        MySqlDataReader dr;
        DataTable dt;

        string komut = "";

        #endregion

        #region Tarih Bas
        public void TarihBas()
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
        #endregion
        #region Saat Bas
        public void SaatBas()
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
        #endregion
        #region Öğretim Elemanı Bas
        public void OgretimElemaniBas()
        {
            komut = "select * from ogretimelemani order by unvan asc";
            dr = islemler.Oku(komut);

            while (dr.Read())
            {
                string birlesik = dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad");
                cmbogretimelemani.Items.Add(birlesik);
            }
            islemler.Kapat();
        }
        #endregion
        #region Derslik Bas
        public void DerslikBas()
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

            //Dersliklerin Tabloya Aktarılması
            komut = "select * from sinavderslikleri";
            dt = new DataTable();
            dt = islemler.Al(komut);

            switch (Derslik)
            {
                case 1:
                    komut = "select Derslik2,Derslik3,Derslik4 from " + Home.donem + " where  id=" + SinavProgrami.sinavid + ";";
                    break;
                case 2:
                    komut = "select Derslik1,Derslik3,Derslik4 from " + Home.donem + " where  id=" + SinavProgrami.sinavid + ";";
                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        if (dr.IsDBNull(0))
                        {
                            islemler.Kapat();
                            MessageBox.Show("Lütfen Önce 1. Dersliği Seçiniz!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }

                    }
                    islemler.Kapat();
                    break;
                case 3:
                    komut = "select Derslik1,Derslik2,Derslik4 from " + Home.donem + " where  id=" + SinavProgrami.sinavid + ";";
                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        if (dr.IsDBNull(1))
                        {
                            islemler.Kapat();
                            MessageBox.Show("Lütfen Önce 2. Dersliği Seçiniz!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }

                    }
                    islemler.Kapat();

                    break;
                case 4:
                    komut = "select Derslik1,Derslik2,Derslik3 from " + Home.donem + " where  id=" + SinavProgrami.sinavid + ";";
                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        if (dr.IsDBNull(2))
                        {
                            islemler.Kapat();
                            MessageBox.Show("Lütfen Önce 3. Dersliği Seçiniz!");
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }

                    }
                    islemler.Kapat();

                    break;
            }
            //dr = islemler.Oku(komut);
            //if (dr.Read())
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        if (dt.Rows[i]["Derslik1"].ToString() == dr.GetString("Derslik1"))
            //        {

            //        }
            //    }
            //}
            //islemler.Kapat();
        }
        #endregion
        #region Öğretim Şekli İşlemleri

        public void EskiVeriyiSec()
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
                        if (!dr.IsDBNull(8) && !dr.IsDBNull(9))
                        {
                            cmbogretimelemani.SelectedItem = dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad");
                        }
                        else if (dr.IsDBNull(11) || dr.IsDBNull(10))
                        {
                            MessageBox.Show("Lütfen Önce Tarih ve Saati Seçiniz!");
                            islemler.Kapat();
                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }
                    }
                    break;
            }
            islemler.Kapat();
        }

        #endregion

        #region ESC ' ye / Enter 'a Basıldığında Yapılacaklar
        private void FormOgretimSekli_KeyPress(object sender, KeyPressEventArgs e)
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
            }
        }
        #endregion
        #region Kaydet Methodu

        public void Kaydet()
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

                    komut = "UPDATE " + Home.donem + " SET Ogr_Sayisi='" + txtogrencisayisi.Text + "' where id=" + SinavProgrami.sinavid + "";

                    islemler.Degistir(komut);
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
                case 5:

                    //Düzenlenen Sınav Satırındaki Tarih Saati ve Eski Öğretim Elamanı Verileri Alınıyor
                    string secilitarih = "";
                    string secilisaat = "";
                    string eskiogretmen = "";
                    string yeniogretmenunvan = "", yeniogretmenadsoyad = "";
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
                    }
                    islemler.Kapat();

                    DateTime starih = Convert.ToDateTime(secilitarih);
                    DateTime ssaat = Convert.ToDateTime(secilisaat);

                    //Seçilen Öğretim Elemanının Sınav Tablsunda aynı tarih ve saatte başka sınavı var mı kontrol ediliyor
                    komut = "Select * from " + Home.donem + " where Tarih='" + starih.ToString("yyyy-MM-dd") + "' and Saat='" + ssaat.ToShortTimeString() + "' and concat(Unvan,' ',Ad_Soyad)='" + cmbogretimelemani.SelectedItem.ToString() + "'";
                    dr = islemler.Oku(komut);

                    DialogResult cevap = DialogResult.Yes;
                    if (dr.Read())
                    {
                        cevap = MessageBox.Show("Seçilen Tarih ve Saatte Öğretim Görevlisinin Başka Bir Sınavı Bulunmakta! \nKabul Ediyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
                    }
                    islemler.Kapat();

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


                    break;

            }
        }
        #endregion

        //Öğrenci Sayısı Sadece Sayı Girişi
        private void txtogrencisayisi_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
