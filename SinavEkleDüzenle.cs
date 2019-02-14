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
            BolumBas();
            DersBas();
            OgretimGorevlisiBas();
            TarihBas();
            SaatBas();
            İslemKontrol();
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

        DataTable dt;

        public static int sinavid = -1;
        string komut = "";
        string mesaj = "";

        string Derslik1 = "0";
        string Derslik2 = "0";
        string Derslik3 = "0";
        string Derslik4 = "0";
        #endregion

        #region Bolum / Bolum Kodu Bas
        public void BolumBas()
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
        #endregion

        #region Gözetmenlerin Gösterilip Gizlenmesi
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

        //Gözetmenlerin Gösterilip Gizlenmesi
        public void GozetmenGosterGizle(bool islem, int gozetmen)
        {
            if (islem)
            {
                switch (gozetmen)
                {
                    case 1:
                        cmbgozetmen1.Items.Clear();
                        cmbgozetmen1id.Items.Clear();
                        lblgozetmen1.Visible = true;
                        cmbgozetmen1.Visible = true;
                        cmbgozetmen1.Text = "Seçiniz...";
                        break;
                    case 2:
                        cmbgozetmen2.Items.Clear();
                        cmbgozetmen2id.Items.Clear();
                        lblgozetmen2.Visible = true;
                        cmbgozetmen2.Visible = true;
                        cmbgozetmen2.Text = "Seçiniz...";


                        break;
                    case 3:
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

        #region Eğer Kayıt Değiştirme Yapılmıyorsa Program_Kodu Değiştirildiğinde Bölümün de otomatik seçildiği alan

        private void cmbbolumkod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sinavid == -1)
            {
                komut = "select * from bolumler where program_kodu='" + cmbbolumkod.SelectedItem.ToString() + "';";
                dr = islemler.Oku(komut);
                if (dr.Read())
                {
                    cmbbolumad.SelectedItem = dr.GetString("program_adi");
                }
                islemler.Kapat();
            }
        }


        #endregion

        #region Ders Bas
        public void DersBas()
        {
            komut = "select ders_adi from ders;";
            dr = islemler.Oku(komut);
            if (dr != null)
            {
                while (dr.Read())
                {
                    cmbders.Items.Add(dr.GetString("ders_adi"));
                }
            }
            islemler.Kapat();
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
            komut = "select id,unvan,Ad_Soyad from ogretimelemani;";
            dr = islemler.Oku(komut);
            if (dr != null)
            {
                while (dr.Read())
                {
                    cmbogretimelemani.Items.Add(dr.GetString("unvan") + " " + dr.GetString("Ad_Soyad"));
                    cmbogretimelemaniid.Items.Add(dr.GetString("id"));
                }
            }
            islemler.Kapat();

        }
        private void cmbogretimelemani_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbogretimelemaniid.SelectedIndex = cmbogretimelemani.SelectedIndex;
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
                MessageBox.Show("Derslikler Listesi Alınırken Hata! Hata Kodu:" + err);
                islemler.Kapat();

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
                    try
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
                    catch (Exception)
                    {

                        lblderslikkapasitesi.Text = "err";
                    }
                }
                else if (cmbderslik3.SelectedIndex != -1 && cmbderslik3.SelectedItem != null)
                {
                    try
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
                    catch (Exception)
                    {

                        lblderslikkapasitesi.Text = "err";
                    }

                }
                else if (cmbderslik2.SelectedIndex != -1 && cmbderslik2.SelectedItem != null)
                {
                    try
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
                    catch (Exception)
                    {

                        lblderslikkapasitesi.Text = "err";
                    }

                }
                else if (cmbderslik1.SelectedIndex != -1 && cmbderslik1.SelectedItem != null)
                {
                    try
                    {
                        ayrilmis = cmbderslik1.SelectedItem.ToString().Split('-');
                        Derslik1 = ayrilmis[0].Trim();
                        ayrilmis = ayrilmis[1].Trim().Split(' ');
                        tk += int.Parse(ayrilmis[0]);
                    }
                    catch (Exception)
                    {

                        lblderslikkapasitesi.Text = "err";
                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Derslik id Alınamadı.. Hata Kodu: " + err);
            }

            lblderslikkapasitesi.Text = tk.ToString();

        }

        #region Derslik 1 İşlemleri
        private void cmbderslik1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (sinavid != -1)
            {
                //Dersli yazdırma Komutları
                dt = new DataTable();
                komut = "select * from sinavderslikleri";
                dt = islemler.Al(komut);
                int[] listelenecekler = { 0, 0, 0, 0 }; //dizinin 0. elemanı 1. derslik olarak düşünerek eğer herhangi bir eleman 1 ise listeleme yapılacak
                //---------------

                komut = "select * from " + SinavProgrami.donem + " where id= " + sinavid + ";";
                dr = islemler.Oku(komut);
                if (dr.Read())
                {
                    cmbders.SelectedItem = dr.GetString("Ders_Adi");
                    cmbdonem.SelectedItem = dr.GetString("donem");
                    cmbders.SelectedItem = dr.GetString("Ders_Adi");
                    cmbbolumad.SelectedItem = dr.GetString("Prg_Ad");
                    cmbbolumkod.SelectedItem = dr.GetString("Prg_Kod");
                    txtogrencisayisi.Text = dr.GetString("Ogr_Sayisi");
                    cmbogretimelemani.SelectedItem = dr.GetString("Unvan") + " " + dr.GetString("Ad_Soyad");

                    DateTime tarih = Convert.ToDateTime(dr.GetString("Tarih"));
                    cmbtarih.SelectedItem = tarih.ToShortDateString();

                    DateTime saat = Convert.ToDateTime(dr.GetString("Saat"));
                    cmbsaat.SelectedItem = saat.ToShortTimeString();

                    cmbogretimsekli.SelectedItem = dr.GetString("Ogr_Sekli");


                    //Derslik Yazdırma Komutları
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!dr.IsDBNull(11))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik1"))
                                {
                                    listelenecekler[0] = 1;
                                }
                            }
                            if (!dr.IsDBNull(12))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik2"))
                                {
                                    dersliksayisi.Value++;
                                    listelenecekler[1] = 1;
                                }
                            }
                            if (!dr.IsDBNull(13))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString
                                ("Derslik3"))
                                {
                                    dersliksayisi.Value++;
                                    listelenecekler[2] = 1;
                                }
                            }
                            if (!dr.IsDBNull(14))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik4"))
                                {
                                    dersliksayisi.Value++;
                                    listelenecekler[3] = 1;
                                }
                            }
                        }
                    }
                    //----------------------




                }
                islemler.Kapat();
                //Derslikler Yazıma Komutları

                for (int i = 0; i < listelenecekler.Length; i++)
                {
                    if (listelenecekler[i] == 1)
                    {
                        DerslikBas(i + 1);
                    }
                }
                //üstteki datareaderden ayrı yapmamızın sebebi başka bir methodda tekrardan veritabanına bağlandığı için öncelikle bağlantıyı kapatmamız gerekiyor
                komut = "select * from " + SinavProgrami.donem + " where id= " + sinavid + ";";
                dr = islemler.Oku(komut);

                if (dr.Read())
                {

                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!dr.IsDBNull(11))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik1"))
                                {
                                    cmbderslik1.SelectedItem = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                }
                            }
                            if (!dr.IsDBNull(12))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik2"))
                                {
                                    cmbderslik2.SelectedItem = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                }
                            }
                            if (!dr.IsDBNull(13))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString
                                ("Derslik3"))
                                {
                                    cmbderslik3.SelectedItem = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                }
                            }
                            if (!dr.IsDBNull(14))
                            {
                                if (dt.Rows[i]["derslik"].ToString() == dr.GetString("Derslik4"))
                                {
                                    cmbderslik4.SelectedItem = dt.Rows[i]["derslik"].ToString() + " - " + dt.Rows[i]["sayi"].ToString() + " Kişilik";
                                }
                            }

                        }
                    }

                }
                islemler.Kapat();
                //--------------------------
            }

        }
        #endregion

        #region Kayıt Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            Form_Kontrol();


            DialogResult cevap = DialogResult.Yes;
            komut = "select * from bolumler where program_adi='" + cmbbolumad.SelectedItem.ToString() + "' and program_kodu='" + cmbbolumkod.SelectedItem.ToString() + "';";
            dr = islemler.Oku(komut);
            if (dr.Read() == false) cevap = MessageBox.Show("Program Kodu ve Program Adı birbiriyle uyuşmuyor!\nDevam Etmek İstiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {

            }

        }

        #endregion

        #region Form Kontrol
        public void Form_Kontrol()
        {

        }

        #endregion

        //Öğrenci Sayısının Yazdırıldığı Yer
        private void txtogrencisayisi_TextChanged(object sender, EventArgs e)
        {
            lblsinavagirenogrencisayisi.Text = txtogrencisayisi.Text;
        }
    }
}
