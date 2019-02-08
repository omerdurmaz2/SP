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


            //Bölümlerin Basıldığı Yer 
            cmbbolum.Items.Clear();
            cmbbolumid.Items.Clear();
            komut = "select * from bolumler order by bolum_adi asc";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbbolum.Items.Add(dr.GetString("bolum_adi") + " (" + dr.GetString("bolum_kodu") + ")");
                cmbbolumid.Items.Add(dr.GetString("id"));
            }
            islemler.Kapat();


        }
        #endregion

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
                    DateTime baslangic = saat.AddMinutes(-45); // koşulu sağlayan verilerdeki saatlerden bir saat öncesini de gizliyoruz (örneğin listede a program kodu için 14:00 da olan bir sınav var ise kullanıcı 13:15,13:3013:45 seçemesin ki ) 
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

        #region Combobox Değer Değiştiğinde Yapılacaklar

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
            if (cmbders.Items.Count!=0)
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
        }
        //öğretim elemanı id si değiştiğinde yapılacaklar
        private void cmbogretimelemaniid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemani.SelectedIndex = cmbogretimelemaniid.SelectedIndex;
        }

        #endregion

    }

}

