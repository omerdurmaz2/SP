using System;
using System.Data;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

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
            baslikhizala();


            //this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            ////Rectangle rect = Screen.GetWorkingArea(this);
            ////this.MaximizedBounds = Screen.GetWorkingArea(this);
            //label3.Text = this.Width.ToString();
            //label4.Text = this.Height.ToString();

            ////this.WindowState = FormWindowState.Maximized;
        }
        private void SinavProgrami_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {
                MessageBox.Show("Form Yüklenirken Hata! \nHata Kotu: " + err, "HATA!");
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

        #region Dışarıda Tanımlananlar
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler; // veritabanı classına giderek yapmak istediğimiz işleme göre kolaylıklar sağlıyor


        string komut = "";  //veritabanı komutlarının tutulduğu yer

        public static string eklebaslik = "";
        public static int sinavid { get; set; }

        public static int KonumX { get; set; }
        public static int KonumY { get; set; }

        public static int DuzenlenenAlan { get; set; }

        Rectangle rect;

        int rowindex = 0;
        int colindex = 0;

        DataTable tablo;

        #endregion

        public void Listele()
        {
            try
            {

                islemler = new VeritabaniIslemler();
                komut = "select id as 'SIRA NO', Prg_Kod as 'Program Kodu', Prg_Ad as 'Program Adı', Ogr_Sekli as 'ÖĞRETİM ŞEKLİ',donem as 'DÖNEM',Ders_Kodu as 'DERS KODU',Ders_Adi as 'DERS ADI',Ogr_Sayisi as 'ÖĞRENCİ SAYISI',Tarih as 'TARİH',Saat as 'SAAT',Unvan as 'ÜNVAN' , Ad_Soyad as 'AD SOYAD',Derslik1 as 'DERSLİK 1',Derslik2 as 'DERSLİK 2',Derslik3 as 'DERSLİK 3',Derslik4 as 'DERSLİK 4',Y_Ogr_Sayisi as 'YERLEŞEN ÖĞRENCİ SAYISI', Gozetmen1 as 'GÖZETMEN 1', Gozetmen2 as 'GÖZETMEN 2', Gozetmen3 as 'GÖZETMEN 3' from " + Home.donem + " order by id desc;";

                if (islemler.Al(komut).Rows.Count>0)
                {

                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    dataGridView1.DataSource = islemler.Al(komut);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Tablo Listelenirken Hata! \nHata Kodu:" + err, "HATA!");
            }


        }

        public void Guncelle()
        {

            try
            {
                DataTable guncelleme = new DataTable();

                komut = "select * from " + Home.donem + " where id=" + sinavid + ";";
                guncelleme = islemler.Al(komut);
                if (guncelleme.Rows.Count == 1)
                {
                    switch (DuzenlenenAlan)
                    {
                        case 1:
                            dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Ogr_Sekli"];
                            break;
                        case 2:
                            if (guncelleme.Rows[0]["Ogr_Sayisi"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Ogr_Sayisi"];

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[12].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[13].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[14].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[15].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[16].Value = DBNull.Value;
                            }

                            break;
                        case 3:
                            dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Tarih"];
                            break;
                        case 4:

                            dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Saat"];
                            break;
                        case 5:
                            dataGridView1.Rows[rowindex].Cells[10].Value = guncelleme.Rows[0]["Unvan"];
                            dataGridView1.Rows[rowindex].Cells[11].Value = guncelleme.Rows[0]["Ad_Soyad"];
                            break;
                        case 6:
                            if (guncelleme.Rows[0]["Derslik1"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Derslik1"];

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[13].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[14].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[15].Value = DBNull.Value;

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }

                            break;
                        case 7:
                            if (guncelleme.Rows[0]["Derslik2"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Derslik2"];

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[14].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[15].Value = DBNull.Value;

                            }
                            break;
                        case 8:
                            if (guncelleme.Rows[0]["Derslik3"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Derslik3"];

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[15].Value = DBNull.Value;

                            }
                            break;
                        case 9:
                            if (guncelleme.Rows[0]["Derslik4"] != DBNull.Value)
                            {
                                //string derslik4 = dr.GetString("Derslik4");
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Derslik4"];
                                //int yogrs = int.Parse(dr.GetString("Y_Ogr_Sayisi"));

                                dataGridView1.Rows[rowindex].Cells[16].Value = guncelleme.Rows[0]["Y_Ogr_Sayisi"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;

                            }
                            break;
                        case 10:
                            if (guncelleme.Rows[0]["Gozetmen1"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Gozetmen1"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[18].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[19].Value = DBNull.Value;
                            }
                            break;
                        case 11:
                            if (guncelleme.Rows[0]["Gozetmen2"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Gozetmen2"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                                dataGridView1.Rows[rowindex].Cells[19].Value = DBNull.Value;
                            }
                            break;
                        case 12:
                            if (guncelleme.Rows[0]["Gozetmen3"] != DBNull.Value)
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = guncelleme.Rows[0]["Gozetmen3"];
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[colindex].Value = DBNull.Value;
                            }
                            break;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Tabloda Güncellenirken Hata! \nHata Kodu:" + err, "HATA!");
            }


        }


        #region Filtre İşlemleri
        #region Tarihin Basıldığı Yer
        public void FiltreTarihBas()
        {
            try
            {
                cmbfiltretarih.Items.Clear();
                DateTime tarih;
                tablo=new DataTable();
                komut = "select * from sinavtarihleri order by tarih asc;";
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count>0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["tarih"]!=DBNull.Value)
                        {
                            tarih=Convert.ToDateTime(tablo.Rows[i]["tarih"]);
                            cmbfiltretarih.Items.Add(tarih);
                        }
                    }
                }
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
                tablo=new DataTable();
                komut = "select saat from sinavsaatleri order by saat asc";
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count > 0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["saat"] != DBNull.Value)
                        {
                            cmbfiltresaat.Items.Add(tablo.Rows[i]["saat"]);
                        }
                    }
                }

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
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count > 0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["unvan"] != DBNull.Value && tablo.Rows[i]["Ad_Soyad"] != DBNull.Value)
                        {
                            cmbfiltreogretimgorevlisi.Items.Add(tablo.Rows[i]["unvan"] + " " + tablo.Rows[i]["Ad_Soyad"]);
                        }
                    }
                } 
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
                cmbfiltrebolumadi.Items.Clear();
                cmbfiltrebolumkodu.Items.Clear();

                komut = "select * from bolumler";
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count > 0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["program_adi"] != DBNull.Value && tablo.Rows[i]["program_kodu"] != DBNull.Value)
                        {
                            cmbfiltrebolumadi.Items.Add(tablo.Rows[i]["program_adi"]);
                            cmbfiltrebolumkodu.Items.Add(tablo.Rows[i]["program_kodu"]);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Filtre Bölüm Listelenirken Hata! Hata Kodu:" + err);
            }
        }

        #endregion

        #region Filtrelerin Temizlendiği Yer
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
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
            catch (Exception err)
            {
                MessageBox.Show("Filtre Temizlenirken Hata! \nHata Kodu:" + err, "HATA!");
            }






        }
        #endregion

        #endregion

        #region Öğretim Elemanları Listelendiği Yer
        public void OgretimGorevlileriListele()
        {
            try
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
            catch (Exception err)
            {
                MessageBox.Show("Öğretim Elemanları Listelenirken Hata! \nHata Kodu:" + err, "HATA!");
            }

        }
        #endregion



        public void Ac()
        {
            try
            {
                rect = dataGridView1.GetCellDisplayRectangle(colindex, rowindex, true);
                KonumX = rect.X + panel1.Location.X;
                KonumY = rect.Y + panel1.Location.Y;
                DialogResult cevap;

                SınavProgramıDüzenleFormu duzenle = new SınavProgramıDüzenleFormu();

                cevap = duzenle.ShowDialog();
                if (cevap != DialogResult.Abort && cevap != DialogResult.Cancel && cevap != DialogResult.None)
                {
                    Guncelle();
                    YerlesenOGrenciRenkAta();
                    if (SınavProgramıDüzenleFormu.YapilanIslem == 5)
                    {
                        OgretimGorevlileriListele();
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Düzenleme Formu Açılırken Hata! \nHata Kodu:" + err, "HATA!");
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    colindex = e.ColumnIndex;
                    rowindex = e.RowIndex;

                    sinavid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    switch (dataGridView1.CurrentCell.ColumnIndex)
                    {
                        case 3:
                            SınavProgramıDüzenleFormu.YapilanIslem = 1; //Öğretim Şekli
                            DuzenlenenAlan = 1;
                            Ac();
                            break;
                        case 7:
                            SınavProgramıDüzenleFormu.YapilanIslem = 2; //Öğrenci Sayısı
                            DuzenlenenAlan = 2;
                            Ac();
                            break;
                        case 8:
                            SınavProgramıDüzenleFormu.YapilanIslem = 3; //Tarih
                            DuzenlenenAlan = 3;
                            Ac();
                            break;
                        case 9:
                            SınavProgramıDüzenleFormu.YapilanIslem = 4; //Saat
                            DuzenlenenAlan = 4;
                            Ac();
                            break;
                        case 10:
                            SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                            DuzenlenenAlan = 5;
                            Ac();
                            break;
                        case 11:
                            SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                            DuzenlenenAlan = 5;
                            Ac();
                            break;
                        case 12:
                            SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 1 
                            DuzenlenenAlan = 6;
                            SınavProgramıDüzenleFormu.Derslik = 1;
                            Ac();
                            break;

                        case 13:
                            SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 2
                            SınavProgramıDüzenleFormu.Derslik = 2;
                            DuzenlenenAlan = 7;
                            Ac();
                            break;

                        case 14:
                            SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 3
                            SınavProgramıDüzenleFormu.Derslik = 3;
                            DuzenlenenAlan = 8;
                            Ac();
                            break;
                        case 15:
                            SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 4
                            SınavProgramıDüzenleFormu.Derslik = 4;
                            DuzenlenenAlan = 9;
                            Ac();
                            break;
                        case 17:
                            SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 1
                            SınavProgramıDüzenleFormu.Gözetmen = 1;
                            DuzenlenenAlan = 10;
                            Ac();
                            break;
                        case 18:
                            SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 2
                            SınavProgramıDüzenleFormu.Gözetmen = 2;
                            DuzenlenenAlan = 11;
                            Ac();
                            break;
                        case 19:
                            SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 3
                            SınavProgramıDüzenleFormu.Gözetmen = 3;
                            DuzenlenenAlan = 12;
                            Ac();
                            break;

                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Tablo Tıklanmasında Yapılan İşlemlerde Hata! \nHata Kodu:" + err, "HATA!");
            }

        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dataGridView1.Rows.Count>0)
            {
                try
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
                                DuzenlenenAlan = 1;
                                Ac();
                                break;
                            case 7:
                                SınavProgramıDüzenleFormu.YapilanIslem = 2; //Öğrenci Sayısı
                                DuzenlenenAlan = 2;
                                Ac();
                                break;
                            case 8:
                                SınavProgramıDüzenleFormu.YapilanIslem = 3; //Tarih
                                DuzenlenenAlan = 3;
                                Ac();
                                break;
                            case 9:
                                SınavProgramıDüzenleFormu.YapilanIslem = 4; //Saat
                                DuzenlenenAlan = 4;
                                Ac();
                                break;
                            case 10:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                                DuzenlenenAlan = 5;
                                Ac();
                                break;
                            case 11:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                                DuzenlenenAlan = 5;
                                Ac();
                                break;
                            case 12:
                                SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 1 
                                DuzenlenenAlan = 6;
                                SınavProgramıDüzenleFormu.Derslik = 1;

                                Ac();
                                break;

                            case 13:
                                SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 2
                                SınavProgramıDüzenleFormu.Derslik = 2;
                                DuzenlenenAlan = 7;
                                Ac();
                                break;

                            case 14:
                                SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 3
                                SınavProgramıDüzenleFormu.Derslik = 3;
                                DuzenlenenAlan = 8;
                                Ac();
                                break;
                            case 15:
                                SınavProgramıDüzenleFormu.YapilanIslem = 6; //Derslik 4
                                SınavProgramıDüzenleFormu.Derslik = 4;
                                DuzenlenenAlan = 9;
                                Ac();
                                break;
                            case 17:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 1
                                SınavProgramıDüzenleFormu.Gözetmen = 1;
                                DuzenlenenAlan = 10;
                                Ac();
                                break;
                            case 18:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 2
                                SınavProgramıDüzenleFormu.Gözetmen = 2;
                                DuzenlenenAlan = 11;
                                Ac();
                                break;
                            case 19:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Gozetmen 3
                                SınavProgramıDüzenleFormu.Gözetmen = 3;
                                DuzenlenenAlan = 12;
                                Ac();
                                break;

                        }
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show("Tablo Keypress Alınırken Hata! \nHata Kodu:" + err, "HATA!");
                }


            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Seçili hücrenin indexini keydownda alıyoruz çünkü enter a basıldığında seçili hücre değişiyor.
            //ancak bize entera basılmadan önceki hücre indexi lazım
            if (dataGridView1.Rows.Count>0)
            {
                rowindex = dataGridView1.CurrentCell.RowIndex;
            }
        }

        //Veri Basıldıktan Sonra Hücre Rengi Değiştiriliyor
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            YerlesenOGrenciRenkAta();
        }

        public void YerlesenOGrenciRenkAta()
        {
            try
            {
                islemler = new VeritabaniIslemler();
                if (sinavid > 0)
                {
                    komut = "select id,Ogr_Sayisi,Y_Ogr_Sayisi from " + Home.donem + " where id=" + sinavid + "";
                }
                else
                {
                    komut = "select id,Ogr_Sayisi,Y_Ogr_Sayisi from " + Home.donem + " order by id desc";
                }



                dr = islemler.Oku(komut);
                if (sinavid > 0)
                {
                    if (dr.Read())
                    {
                        int ogrencisayisi = 0;
                        int yerlesenogrencisayisi = 0;
                        if (!dr.IsDBNull(1)) { ogrencisayisi = int.Parse(dr.GetString("Ogr_Sayisi")); }
                        if (!dr.IsDBNull(2)) { yerlesenogrencisayisi = int.Parse(dr.GetString("Y_Ogr_Sayisi")); }

                        if (ogrencisayisi == 0 && yerlesenogrencisayisi == 0) { dataGridView1.Rows[rowindex].Cells[16].Style.BackColor = Color.White; }
                        else if (ogrencisayisi > yerlesenogrencisayisi) { dataGridView1.Rows[rowindex].Cells[16].Style.BackColor = Color.FromArgb(244, 67, 54); }
                        else { dataGridView1.Rows[rowindex].Cells[16].Style.BackColor = Color.FromArgb(165, 214, 167); }
                    }

                }
                else
                {
                    while (dr.Read())
                    {
                        int ogrencisayisi = 0;
                        int yerlesenogrencisayisi = 0;
                        if (!dr.IsDBNull(1)) { ogrencisayisi = int.Parse(dr.GetString("Ogr_Sayisi")); }
                        if (!dr.IsDBNull(2)) { yerlesenogrencisayisi = int.Parse(dr.GetString("Y_Ogr_Sayisi")); }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == dr.GetString("id"))
                            {

                                if (ogrencisayisi == 0 && yerlesenogrencisayisi == 0) { dataGridView1.Rows[i].Cells[16].Style.BackColor = Color.White; break; }
                                else if (ogrencisayisi > yerlesenogrencisayisi) { dataGridView1.Rows[i].Cells[16].Style.BackColor = Color.FromArgb(244, 67, 54); break; }
                                else { dataGridView1.Rows[i].Cells[16].Style.BackColor = Color.FromArgb(165, 214, 167); break; }

                            }
                        }


                    }

                }
                islemler.Kapat();
                sinavid = -1;
            }
            catch (Exception err)
            {
                MessageBox.Show("Hücre Rengi Değiştirilirken Hata! \nHata Kodu:" + err, "HATA!");
            }

        }

    }
}
