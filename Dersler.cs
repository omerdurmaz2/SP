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
        ProgramaEkle program;

        string komut = "";
        string mesaj = "";
        int dersid = -1;
        string eskiderskodu = "";

        string ilkdonem = "", ilkbolum = "";
        #endregion

        #region Listele
        public void Listele()
        {
            komut = "select id as 'SIRA NO',ders_kodu as 'DERS KODU',ders_adi as 'DERS ADI', bolum as 'BÖLÜM', donem as 'DÖNEM' from ders order by id desc ";

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

            for (int i = 0; i < Bolumler.Rows.Count; i++)
            {
                if (Bolumler.Rows[i]["program_adi"] != DBNull.Value && Bolumler.Rows[i]["program_kodu"] != DBNull.Value)
                {
                    cmbbolum.Items.Add(Bolumler.Rows[i]["program_adi"] + " " + Bolumler.Rows[i]["program_kodu"]);
                }
            }
            cmbbolum.SelectedIndex = -1;
            cmbbolum.Text = "Seçiniz..";
        }
        #endregion

        #region Kaydet
        public void Kaydet(string dersadi, string derskodu, string bolum, string donem)
        {

            program = new ProgramaEkle();

            //Aşağıdaki alanda dersin eklenmesi ya da güncellenmesine göre bahar ve güz tablosunda yapılacak değişiklikleri ayarlıyoruz
            if (dersid == -1) //eğer id -1 ise yeni ekler
            {
                program.YeniKayit(cmbdonem.SelectedItem.ToString(), cmbbolum.SelectedItem.ToString(), cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text);

            }
            else // eğer id -1 değilse id ye göre veri güncellenir
            {
                if ((ilkdonem == "1. Dönem" || ilkdonem == "3. Dönem")) ilkdonem = "guz";
                else ilkdonem = "bahar";

                if (cmbdonem.SelectedItem.ToString() == "1. Dönem" || cmbdonem.SelectedItem.ToString() == "3. Dönem")
                {
                    program.KayitGuncelle("guz", ilkdonem, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text, dersid.ToString(), cmbbolum.SelectedItem.ToString());
                }
                else
                {
                    program.KayitGuncelle("bahar", ilkdonem, cmbdonem.SelectedItem.ToString(), txtdkod.Text, txtdad.Text, dersid.ToString(), cmbbolum.SelectedItem.ToString());
                }

            }

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
            txtdad.Text = txtdad.Text.Trim();
            txtdkod.Text = txtdkod.Text.Trim();
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
            cmbbolum.Enabled = true;

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
                            cmbbolum.Enabled = false;


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
                            program = new ProgramaEkle();
                            program.KayitSil(dersid, 1); // Bahar Tablosundan Ders ile ilgili kayıtları sildik
                            program.KayitSil(dersid, 2); // güz tablosundan ders ile ilgili kayıtları sildik

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

        #region Form yüklendikten sonra verilerin basılması

        private void Dersler_Shown(object sender, EventArgs e)
        {
            Listele();

        }
        #endregion
    }
}
