﻿using System;
using System.Data;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using TyroDeveloperDLL;
using CustomControl;
using System.Collections.Generic;

namespace sp
{

    public partial class SinavProgrami : Tasarim
    {
        #region Yapıcı Metod ve Form_Load

        public SinavProgrami()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
                                                                                                      //yToolStripMenuItem.Visible = false; // normal boyuta getir butonu kapalı
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
                List<CheckComboBox.ComboboxData> dat1 = chkgizli.CheckItems;

                //if (Login.Session)
                //{


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

        System.Drawing.Rectangle rect;

        int rowindex = 0;
        int colindex = 0;

        DataTable tablo;
        public string siralama = "";


        #endregion
        #region Orijinal Listeleme
        //public void Listele()
        //{
        //    try
        //    {

        //        islemler = new VeritabaniIslemler();
        //        komut = "select SiraNo as 'SIRA NO', Prg_Kod as 'Program Kodu', Prg_Ad as 'Program Adı', Ogr_Sekli as 'ÖĞRETİM ŞEKLİ',donem as 'DÖNEM',Ders_Kodu as 'DERS KODU',Ders_Adi as 'DERS ADI',Ogr_Sayisi as 'ÖĞRENCİ SAYISI',Tarih as 'TARİH',Saat as 'SAAT',Unvan as 'ÜNVAN' , Ad_Soyad as 'AD SOYAD',Derslik1 as 'DERSLİK 1',Derslik2 as 'DERSLİK 2',Derslik3 as 'DERSLİK 3',Derslik4 as 'DERSLİK 4',Y_Ogr_Sayisi as 'YERLEŞEN ÖĞRENCİ SAYISI', Gozetmen1 as 'GÖZETMEN 1', Gozetmen2 as 'GÖZETMEN 2', Gozetmen3 as 'GÖZETMEN 3' from " + Home.donem + " order by SiraNo desc;";

        //        if (islemler.Al(komut).Rows.Count > 0)
        //        {

        //            dataGridView1.Columns.Clear();
        //            dataGridView1.DataSource = null;
        //            dataGridView1.Refresh();

        //            dataGridView1.DataSource = islemler.Al(komut);
        //        }

        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show("Tablo Listelenirken Hata! \nHata Kodu:" + err, "HATA!");
        //    }


        //}
        #endregion

        public void Guncelle()
        {

            try
            {
                DataTable guncelleme = new DataTable();

                komut = "select * from " + Home.donem + " where SiraNo=" + sinavid + ";";
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
                cmbfiltretarih.Items.Add("Hepsi");
                DateTime tarih;
                tablo = new DataTable();
                komut = "select * from sinavtarihleri order by tarih asc;";
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count > 0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["tarih"] != DBNull.Value)
                        {
                            tarih = Convert.ToDateTime(tablo.Rows[i]["tarih"]);
                            cmbfiltretarih.Items.Add(tarih.ToShortDateString());
                        }
                    }
                }
                cmbfiltretarih.SelectedIndex = 0;

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
                cmbfiltresaat.Items.Add("Hepsi");

                tablo = new DataTable();
                komut = "select saat from sinavsaatleri order by saat asc";
                tablo = islemler.Al(komut);
                if (tablo.Rows.Count > 0)
                {
                    for (int i = 0; i < tablo.Rows.Count; i++)
                    {
                        if (tablo.Rows[i]["saat"] != DBNull.Value)
                        {
                            cmbfiltresaat.Items.Add(tablo.Rows[i]["saat"].ToString());
                        }
                    }
                }
                cmbfiltresaat.SelectedIndex = 0;

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
                cmbfiltreogretimgorevlisi.Items.Add("Hepsi");

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
                cmbfiltreogretimgorevlisi.SelectedIndex = 0;

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
                cmbfiltrebolumadi.Items.Add("Hepsi");
                cmbfiltrebolumkodu.Items.Add("Hepsi");


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
                cmbfiltrebolumadi.SelectedIndex = 0;
                cmbfiltrebolumkodu.SelectedIndex = 0;

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
                cmbfiltrebolumadi.SelectedIndex = 0;

                cmbfiltrebolumkodu.SelectedIndex = 0;

                cmbfiltreogretimsekli.SelectedIndex = 0;

                cmbfiltreogretimgorevlisi.SelectedIndex = 0;

                cmbfiltretarih.SelectedIndex = 0;

                cmbfiltresaat.SelectedIndex = 0;

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


        #region Düzenleme Formunun Açılması

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
        #endregion


        #region Datagrid İşlemleri
        //Hücre Tıklanması
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
							SınavProgramıDüzenleFormu.Gözetmen = 0;
							DuzenlenenAlan = 5;
							Ac();
							break;
						case 11:
							SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
							DuzenlenenAlan = 5;
							SınavProgramıDüzenleFormu.Gözetmen = 0;
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
        //Hücre tuşla seçilmesi
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
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

                        //son column tam görüntülenmediği için aşağıdaki işlem yapıldı
                        if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns.Count - 1)
                        {
                            dataGridView1.FirstDisplayedScrollingColumnIndex = dataGridView1.Columns.Count - 1;
                        }
                        //-------------------------

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
                                SınavProgramıDüzenleFormu.Gözetmen = 0;
                                DuzenlenenAlan = 5;
                                Ac();
							    break;
                            case 11:
                                SınavProgramıDüzenleFormu.YapilanIslem = 5; //Öğretim Elemanı
                                DuzenlenenAlan = 5;
                                SınavProgramıDüzenleFormu.Gözetmen = 0;
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
        //Hücre içinde tuş aşağı basıldığı anda yapılacaklar
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Seçili hücrenin indexini keydownda alıyoruz çünkü enter a basıldığında seçili hücre değişiyor.
            //ancak bize entera basılmadan önceki hücre indexi lazım
            if (dataGridView1.Rows.Count > 0)
            {
                rowindex = dataGridView1.CurrentCell.RowIndex;
            }
        }
        //Veri Basıldıktan Sonra Hücre Rengi Değiştiriliyor
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            YerlesenOGrenciRenkAta();
        }

        #endregion

        #region Yerleşen Öğrenci Durumuna Göre Renk Atanması

        public void YerlesenOGrenciRenkAta()
        {
            try
            {
                islemler = new VeritabaniIslemler();
                if (sinavid > 0)
                {
                    komut = "select SiraNo,Ogr_Sayisi,Y_Ogr_Sayisi from " + Home.donem + " where SiraNo=" + sinavid + "";
                }
                else
                {
                    komut = "select SiraNo,Ogr_Sayisi,Y_Ogr_Sayisi from " + Home.donem + " order by SiraNo desc";
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
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == dr.GetString("SiraNo"))
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
        #endregion


        //Bu sayfada Form Üzerisinden Sürükleme Yapılmaması Yapılan İşlem
        private void SinavProgrami_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = false; //tasarım classı kopyalandığı için tasarım formunaki mousedown false yapıldığında sürükleme iptal olur 
        }

        #region Filtreleme İşlemleri
        public void filtreleme()
        {

            komut = "select SiraNo as 'SIRA NO', Prg_Kod as 'Program Kodu', Prg_Ad as 'Program Adı', Ogr_Sekli as 'ÖĞRETİM ŞEKLİ',donem as 'DÖNEM',Ders_Kodu as 'DERS KODU',Ders_Adi as 'DERS ADI',Ogr_Sayisi as 'ÖĞRENCİ SAYISI',Tarih as 'TARİH',Saat as 'SAAT',Unvan as 'ÜNVAN' , Ad_Soyad as 'AD SOYAD',Derslik1 as 'DERSLİK 1',Derslik2 as 'DERSLİK 2',Derslik3 as 'DERSLİK 3',Derslik4 as 'DERSLİK 4',Y_Ogr_Sayisi as 'YERLEŞEN ÖĞRENCİ SAYISI', Gozetmen1 as 'GÖZETMEN 1', Gozetmen2 as 'GÖZETMEN 2', Gozetmen3 as 'GÖZETMEN 3' from " + Home.donem + " where ";

            if (cmbfiltrebolumkodu.SelectedIndex != 0 && cmbfiltrebolumkodu.SelectedIndex != -1)
            {
                komut += "Prg_Kod LIKE '" + cmbfiltrebolumkodu.SelectedItem + "' AND ";
            }
            if (cmbfiltrebolumadi.SelectedIndex != 0 && cmbfiltrebolumadi.SelectedIndex != -1)
            {
                komut += "Prg_Ad LIKE '" + cmbfiltrebolumadi.SelectedItem + "' AND ";
            }
            if (cmbfiltreogretimsekli.SelectedIndex != 0 && cmbfiltreogretimsekli.SelectedIndex != -1)
            {
                komut += "Ogr_Sekli LIKE '" + cmbfiltreogretimsekli.SelectedItem + "' AND ";
            }
            if (cmbfiltreogretimgorevlisi.SelectedIndex != 0 && cmbfiltreogretimgorevlisi.SelectedIndex != -1)
            {
                komut += "concat(Unvan,' ',Ad_Soyad) LIKE '" + cmbfiltreogretimgorevlisi.SelectedItem + "' AND ";
            }
            if (cmbfiltretarih.SelectedIndex != 0 && cmbfiltretarih.SelectedIndex != -1)
            {
                DateTime tarih = Convert.ToDateTime(cmbfiltretarih.SelectedItem);
                komut += "Tarih LIKE '" + tarih.ToString("yyyy-MM-dd") + "' AND ";
            }
            if (cmbfiltresaat.SelectedIndex != 0 && cmbfiltresaat.SelectedIndex != -1)
            {
                komut += "Saat LIKE '" + cmbfiltresaat.SelectedItem.ToString() + "' AND ";
            }
            komut = komut.Substring(0, komut.Length - 4);
            komut += siralama;

            Listele(komut);

        }
        private void cmbfiltrebolumadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();
        }
        private void cmbfiltrebolumkodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();
        }

        private void cmbfiltreogretimsekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();

        }

        private void cmbfiltretarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();
        }

        private void cmbfiltreogretimgorevlisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();
        }

        private void cmbfiltresaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtreleme();
        }
        #endregion


        #region Yazdırma İşlemi
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {

                // Creating a Excel object. 
                Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                try
                {

                    worksheet = workbook.ActiveSheet;

                    worksheet.Name = "Sheet 1";



                    //Loop through each row and read value from each column. 
                    for (int i = 0; i < dtSource.Rows.Count + 1; i++)
                    {
                        for (int j = 0; j < dtSource.Columns.Count; j++)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            if (i + 1 == 1)
                            {
                                worksheet.Cells[i + 1, j + 1] = dataGridView1.Columns[j].HeaderText;
                            }
                            else
                            {
                                if (dtSource.Rows[i - 1][j] != DBNull.Value)
                                {
                                    worksheet.Cells[i + 1, j + 1] = dtSource.Rows[i - 1][j].ToString();
                                }
                            }
                        }

                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;
                    string yol = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    excel.Quit();
                    workbook = null;
                    excel = null;
                }
            }
            else
            {
                MessageBox.Show("Kaydedilecek Veri Yok! ", "HATA");
            }
        }

        #endregion



        #region Sayfalama İşlemi

        //SAYFALAMA İŞLEMİ
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dtSource;
        int PageCount;
        int maxRec;
        int pageSize;
        int currentPage;
        int recNo;

        public void Listele(string komut)
        {
            try
            {

                islemler = new VeritabaniIslemler();
                if (islemler.Al(komut).Rows.Count > 0)
                {

                    MySqlConnection conn = new MySqlConnection(VeritabaniIslemler.ConnectionString());

                    da = new MySqlDataAdapter(komut, conn);
                    ds = new DataSet();

                    //Fill the DataSet.
                    da.Fill(ds, Home.donem);
                    dtSource = ds.Tables[Home.donem];
                    Fill();
                    dataGridView1.Focus();

                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Tablo Listelenirken Hata! \nHata Kodu:" + err, "HATA!");
            }
        }
        private void LoadPage()
        {
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            dtTemp = dtSource.Clone();

            if (currentPage == PageCount)
            {
                endRec = maxRec;
            }
            else
            {
                endRec = pageSize * currentPage;
            }
            startRec = recNo;

            for (i = startRec; i < endRec; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
                recNo += 1;
            }



            dataGridView1.DataSource = dtTemp;


            DisplayPageInfo();
        }
        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Sayfa " + currentPage.ToString() + "/ " + PageCount.ToString();
        }


        public void Fill()
        {
            try
            {
                pageSize = 20;
                maxRec = dtSource.Rows.Count;
                PageCount = maxRec / pageSize;

                if ((maxRec % pageSize) > 0)
                {
                    PageCount += 1;
                }

                currentPage = 1;
                recNo = 0;

                LoadPage();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {


            //Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("Son Sayfadasınız!");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            LoadPage();
            dataGridView1.Focus();

        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                if (recNo == maxRec)
                {
                    MessageBox.Show("Son Sayfadasınız!");
                    return;
                }
            }
            LoadPage();
            dataGridView1.Focus();

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {


            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }

            currentPage -= 1;
            if (currentPage < 1)
            {
                MessageBox.Show("1. Sayfadasınız!");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            LoadPage();
            dataGridView1.Focus();

        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {


            if (currentPage == 1)
            {
                MessageBox.Show("1. Sayfadasınız!");
                return;
            }

            currentPage = 1;
            recNo = 0;
            LoadPage();
            dataGridView1.Focus();

        }






        //--------------------------------------
        #endregion

        #region Form Yüklendikten Sonra Verilerin Basılması
        private void SinavProgrami_Shown(object sender, EventArgs e)
        {
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
            cmbfiltreogretimsekli.SelectedIndex = 0;

            //-----
            sinavid = -1;
            cmbsirala.SelectedIndex = 0;

            //Gizlenecek Alanların Basıldığı Yer
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Sıra No", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Program Kodu", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Program Adı", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Dönem", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Ders Kodu", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Ders Adı", false));
            chkgizli.Items.Add(new CheckComboBox.ComboboxData("Yerleşen Öğrenci Sayısı", false));

        }
        #endregion


        #region Seçilen Sıralamaya Göre Listenin Sıralandığı Yer

        private void cmbsirala_SelectedIndexChanged(object sender, EventArgs e)
        {
            komut = "select SiraNo as 'SIRA NO', Prg_Kod as 'Program Kodu', Prg_Ad as 'Program Adı', Ogr_Sekli as 'ÖĞRETİM ŞEKLİ',donem as 'DÖNEM',Ders_Kodu as 'DERS KODU',Ders_Adi as 'DERS ADI',Ogr_Sayisi as 'ÖĞRENCİ SAYISI',Tarih as 'TARİH',Saat as 'SAAT',Unvan as 'ÜNVAN' , Ad_Soyad as 'AD SOYAD',Derslik1 as 'DERSLİK 1',Derslik2 as 'DERSLİK 2',Derslik3 as 'DERSLİK 3',Derslik4 as 'DERSLİK 4',Y_Ogr_Sayisi as 'YERLEŞEN ÖĞRENCİ SAYISI', Gozetmen1 as 'GÖZETMEN 1', Gozetmen2 as 'GÖZETMEN 2', Gozetmen3 as 'GÖZETMEN 3' from " + Home.donem + " ";
            switch (cmbsirala.SelectedIndex)
            {

                case 0:
                    siralama = " order by SiraNo desc;";
                    break;
                case 1:
                    siralama = " order by Tarih asc;";
                    break;
                case 2:
                    siralama = " order by Tarih desc;";
                    break;
                case 3:
                    siralama = " order by Ders_Adi asc;";
                    break;
                case 4:
                    siralama = " order by Ders_Adi desc;";
                    break;
                case 5:
                    siralama = " order by Prg_Ad asc;";
                    break;
                case 6:
                    siralama = " order by Prg_Ad desc;";
                    break;
            }
            filtreleme();
            //Seçilen Sıralama string bir değişkene kaydediliyor ve filtrelemeye gidilip datagrid basılıyor
        }
        #endregion


        //Seçilen Alanların Gizlendiği Yer
        private void chkgizli_Checkchanged(object sender, EventArgs e)
        {
            try
            {
                List<CheckComboBox.ComboboxData> liste = chkgizli.CheckItems;
                if (liste[0].Checked == true) dataGridView1.Columns[0].Visible = false;
                else dataGridView1.Columns[0].Visible = true;
                if (liste[1].Checked == true) dataGridView1.Columns[1].Visible = false;
                else dataGridView1.Columns[1].Visible = true;
                if (liste[2].Checked == true) dataGridView1.Columns[2].Visible = false;
                else dataGridView1.Columns[2].Visible = true;
                if (liste[3].Checked == true) dataGridView1.Columns[4].Visible = false;
                else dataGridView1.Columns[4].Visible = true;
                if (liste[4].Checked == true) dataGridView1.Columns[5].Visible = false;
                else dataGridView1.Columns[5].Visible = true;
                if (liste[5].Checked == true) dataGridView1.Columns[6].Visible = false;
                else dataGridView1.Columns[6].Visible = true;
                if (liste[6].Checked == true) dataGridView1.Columns[16].Visible = false;
                else dataGridView1.Columns[16].Visible = true;

            }
            catch (Exception err)
            {
                MessageBox.Show("Datagrid Sütun Gizlerken Hata! \nHata Kodu: " + err.ToString());
            }
        }
    }
}










