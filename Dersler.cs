using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace sp
{
    public partial class Dersler : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Dersler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
            baslikhizala();
        }
        private void Dersler_Load(object sender, EventArgs e)
        {
            //if (Login.Session)
            //{
            try
            {
                //Bölümlerin Tabloya Basıldığı Yer
                komut = "select * from bolumler";
                Bolumler = islemler.Al(komut);

            }
            catch (Exception err)
            {
                MessageBox.Show("DÖnem Belirlenirken Hata! Hata Kodu:" + err, "HATA!");
            }


            Listele();
            //}
            //else
            //{
            //    this.Close();
            //}

        }
        #endregion

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

        #region Dışarda Tanımlananlar
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        DataTable Bolumler = new DataTable();
        string komut = "";
        string mesaj = "";
        int dersid = -1;
        string eskiderskodu = "";

        string ilkdonem = "", ilkbolum = "";
        #endregion

        #region Listele
        public void Listele()
        {
            komut = "select id as 'SIRA NO',ders_kodu as 'DERS KODU',ders_adi as 'DERS ADI', bolum as 'BÖLÜM', donem as 'DÖNEM' from ders ";

            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut);

                ButonEkle();//Tasarımda hazır buluann butonları ekliyoruz
                //değiştir butonu her satır için eklenir
                dataGridView1.Columns.Add(duzenle);

                //sil butonu her satır için eklenir
                dataGridView1.Columns.Add(sil);

            }
            else
            {
                MessageBox.Show("İşlem Gerçekleştirlemedi, Lütfen Sonra Tekrar Deneyin!"); // eğer veritabanı işlemi gerçekleştirilemezse hata verir
                this.Close();
            }
            cmbbolum.Items.Add("ORTAK DERS");

            komut = "select * from bolumler";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                cmbbolum.Items.Add(dr.GetString("program_kodu") + " " + dr.GetString("program_adi"));
            }
            islemler.Kapat();
            cmbbolum.SelectedIndex = -1;
            cmbbolum.Text = "Seçiniz..";
        }
        #endregion

        #region Kaydet
        public void Kaydet(string dersadi, string derskodu, string bolum, string donem)
        {
            if (dersid == -1) //eğer id -1 ise yeni ekler
            {

                komut = "INSERT INTO ders(ders_adi,ders_kodu,bolum,donem) VALUES ('" + dersadi + "','" + derskodu + "','" + bolum + "','" + donem + "')";
                mesaj = "Yeni Kayıt Eklendi";


            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {

                btnkirmizi1.Visible = false;
                btnmavi1.Text = "EKLE";

                komut = "UPDATE ders SET ders_adi = '" + dersadi + "', ders_kodu = '" + derskodu + "', bolum='" + bolum + "' , donem='" + donem + "'  WHERE id = " + dersid + ";";
                mesaj = "Kayıt Güncellendi";

            }
            islemler.Degistir(komut);


            string progad = "", progkod = "";
            ProgramaEkle program = new ProgramaEkle();
            DataTable SınavTablosu;

            //Aşağıdaki alanda dersin eklenmesi ya da güncellenmesine göre bahar ve güz tablosunda yapılacak değişiklikleri ayarlıyoruz
            if (dersid == -1) //eğer id -1 ise yeni ekler
            {
                if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                {
                    if (Bolumler.Rows.Count != 0)
                    {
                        for (int i = 0; i < Bolumler.Rows.Count; i++)
                        {
                            progkod = Bolumler.Rows[i]["program_kodu"].ToString();
                            progad = Bolumler.Rows[i]["program_adi"].ToString();


                            if (Home.donem == "ORTAK")
                            {
                                program.YeniKayit("bahar", progkod, progad, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text);

                                program.YeniKayit("güz", progkod, progad, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text);

                            }
                            else
                            {
                                program.YeniKayit(Home.donem, progkod, progad, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text);

                            }
                        }

                    }
                }
                else
                {

                    for (int i = 0; i < Bolumler.Rows.Count; i++)
                    {
                        string birlesik = Bolumler.Rows[i]["program_kodu"].ToString() + " " + Bolumler.Rows[i]["program_adi"].ToString();
                        if (birlesik == cmbbolum.SelectedItem.ToString())
                        {
                            progkod = Bolumler.Rows[i]["program_kodu"].ToString();
                            progad = Bolumler.Rows[i]["program_adi"].ToString();
                        }
                    }
                    program.YeniKayit(Home.donem, progkod, progad, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text);

                }

            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {
                if (ilkdonem == "1. Dönem" || ilkdonem == "3. Dönem")
                {
                    if (ilkdonem == cmbdonem.SelectedItem.ToString())
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum) 
                            {
                                //Güz Tablosunda Ders Kodu Düzenlenen Ders Koduna Eşit Olan Bütün Kayıtları Güncelle
                                komut = "UPDATE guz SET  donem='" + cmbdonem.SelectedItem.ToString() + "',Ders_Kodu='" + txtdkod.Text + "',Ders_Adi='" + txtdad.Text + "' where Ders_Kodu='" + eskiderskodu + "'";
                                islemler.Degistir(komut);

                            }
                            else
                            {
                                for (int i = 0; i < Bolumler.Rows.Count; i++)
                                {
                                    string birlesik = Bolumler.Rows[i]["program_kodu"].ToString() + " " + Bolumler.Rows[i]["program_adi"].ToString();
                                    if (birlesik == cmbbolum.SelectedItem.ToString())
                                    {
                                        progkod = Bolumler.Rows[i]["program_kodu"].ToString();
                                        progad = Bolumler.Rows[i]["program_adi"].ToString();
                                    }
                                }
                                //Güz Tablsonda Seçilmiş Olan BÖlüm Hariç Bütün Bölümleri Sil
                                komut = "DELETE FROM guz where Ders_Kodu='" + eskiderskodu + "' and Prg_Kod<>'" + progkod + "' and Prg_Ad<>'" + progad + "';";
                                islemler.Degistir(komut);
                                
                                //Güz Tablosunda Ders Kodu Düzenlenen Ders Koduna Eşit Olan Kaydı Güncelle
                                komut = "UPDATE guz SET Prg_Ad='" + progad + "',Prg_Kod='" + progkod + "', donem='" + cmbdonem.SelectedItem.ToString() + "',Ders_Kodu='" + txtdkod.Text + "',Ders_Adi='" + txtdad.Text + "' where Ders_Kodu='" + eskiderskodu + "'";
                                islemler.Degistir(komut);


                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else if (cmbdonem.SelectedItem.ToString() == "2. Dönem" || cmbdonem.SelectedItem.ToString() == "4. Dönem")
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }

                }
                else if (ilkdonem == "2. Dönem" || ilkdonem == "4. Dönem")
                {
                    if (ilkdonem == cmbdonem.SelectedItem.ToString())
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else if (cmbdonem.SelectedItem.ToString() == "1. Dönem" || cmbdonem.SelectedItem.ToString() == "3. Dönem")
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    if (ilkdonem == cmbdonem.SelectedItem.ToString())
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else if (cmbdonem.SelectedItem.ToString() == "1. Dönem" || cmbdonem.SelectedItem.ToString() == "3. Dönem")
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else if (cmbdonem.SelectedItem.ToString() == "2. Dönem" || cmbdonem.SelectedItem.ToString() == "4. Dönem")
                    {
                        if (ilkbolum == "ORTAK DERS")
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (cmbbolum.SelectedItem.ToString() == ilkbolum)
                            {

                            }
                            else if (cmbbolum.SelectedItem.ToString() == "ORTAK DERS")
                            {

                            }
                            else
                            {

                            }
                        }
                    }

                }


                // Güz > Güz

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Güz > Bahar

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm

                // Güz > Ortak

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Bahar > Bahar 

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Bahar > Güz

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Bahar >> Ortak

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Ortak > Ortak 

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Ortak > Güz 

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm


                // Ortak > Bahar

                //Secili Bolum > Seçili Bölüm
                //Seçili Bölüm > Ortak Bölüm
                //Ortak Bölüm > Ortak Bölüm 
                //Ortak Bölüm > Seçili Bölüm



                komut = "UPDATE ders SET ders_adi = '" + dersadi + "', ders_kodu = '" + derskodu + "', bolum='" + bolum + "' , donem='" + donem + "'  WHERE id = " + dersid + ";";

            }



            MessageBox.Show(mesaj);
            Temizle();
            Listele();
        }
        #endregion

        #region Sorgu
        public void Sorgu()
        {
            komut = "select * from ders where ders_kodu='" + txtdkod.Text + "' and id <> " + dersid + ";";
            if (islemler.Oku(komut).Read())
            {
                MessageBox.Show("Aynı ders kodunda ders kayıtlı. Lütfen Farklı bir ders kodu girin...", "HATA!");
                txtdkod.Text = "";
                txtdkod.Focus();

                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtdad.Text, txtdkod.Text, cmbbolum.SelectedItem.ToString(), cmbdonem.SelectedItem.ToString());
            }
        }
        #endregion

        #region Form Kontrol
        public void FormKontrol()
        {
            if (txtdad.Text != "" && txtdkod.Text != "" && cmbbolum.SelectedIndex != -1 && cmbdonem.SelectedIndex != -1)
            {
                if (cmbdonem.SelectedItem.ToString() == "1. Dönem" || cmbdonem.SelectedItem.ToString() == "3. Dönem")
                {
                    Home.donem = "guz";
                }
                else if (cmbdonem.SelectedItem.ToString() == "2. Dönem" || cmbdonem.SelectedItem.ToString() == "4. Dönem")
                {
                    Home.donem = "bahar";
                }
                else
                {
                    Home.donem = "ORTAK";
                }

                Sorgu();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!", "HATA!!");
            }
        }
        #endregion

        #region Ekle Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            FormKontrol();

        }
        #endregion

        #region Temizle
        public void Temizle() // textboxları ve butonları temizler
        {
            txtdad.Clear();
            txtdkod.Clear();

            btnmavi1.Text = "EKLE";
            btnkirmizi1.Visible = false;
            dersid = -1;

            dataGridView1.DataSource = null; // datagridview temizlenir
            dataGridView1.Columns.Clear();// datagridview temizlenir
            dataGridView1.Refresh(); // datagridview yenilenir

            //veritabanından basılan dropdownların temizlenmesi 
            cmbbolum.Items.Clear();


            cmbdonem.SelectedIndex = -1;
            cmbdonem.Text = "Seçiniz..";
        }

        #endregion

        #region Tabloda Değiştirme ve Silme İşlemleri
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 4) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                dersid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //seçilen verinin idsini atıyor

                switch (e.ColumnIndex)
                {
                    case 5: //değiştir
                        btnkirmizi1.Visible = true; //iptal butonu görünür
                        btnmavi1.Text = "GÜNCELLE";

                        komut = "select * from ders where id=" + dersid + ";";
                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            txtdad.Text = dr["ders_adi"].ToString();
                            txtdkod.Text = dr["ders_kodu"].ToString();
                            cmbdonem.SelectedItem = dr["donem"].ToString();
                            cmbbolum.SelectedItem = dr["bolum"].ToString();

                            ilkdonem = dr["donem"].ToString();
                            ilkbolum = dr["bolum"].ToString();

                        }
                        else
                        { // eğer kayıt buluanmazsa hata verir
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");

                        }
                        islemler.Kapat();
                        dr.Close(); //datareader i temizliyoruz
                        eskiderskodu = txtdkod.Text;
                        break;
                    case 6:

                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);// silmek istenip istenmediği sorulur
                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM ders where id=" + dersid + ";";
                            islemler.Degistir(komut);

                            MessageBox.Show("Silindi.");

                            Temizle();
                            Listele(); //tablo tekrar listelenir

                        }
                        break;

                }


            }

        }
        #endregion

        #region İptal Butonu
        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            Temizle();
            Listele();
        }


        #endregion


    }
}
