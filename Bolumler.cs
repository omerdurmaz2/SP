using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data;
namespace sp
{
    public partial class Bolumler : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Bolumler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
            baslikhizala();
        }
        private void Bolumler_Load(object sender, EventArgs e)
        {
            if (Login.Session)
            {
                Listele();
            }
            else
            {
                this.Close();
            }
        }
        #endregion
        #region Tasarım için yapılmış değişiklikler
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
        public int bolumid = -1;
        string komut = "";
        string mesaj = "";
        MySqlDataReader rd;
        DataTable dt;
        VeritabaniIslemler islemler = new VeritabaniIslemler();

        string progkod = "", progad = "";

        #endregion

        #region Listele
        public void Listele()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            komut = "select id as 'SIRA NO',program_kodu as 'BÖLÜM KODU', bolum_adi as 'BÖLÜM ADI', program_adi as 'PROGRAM ADI' from bolumler";

            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut);
                ButonEkle();
                //tablodaki veriler için düzenle ve sil butonları
                dataGridView1.Columns.Add(duzenle);
                dataGridView1.Columns.Add(sil);

            }
        }

        #endregion

        #region Kaydet Methodu
        public void Kaydet(string ad, string bolumkod, string programadi)
        {

            if (bolumid == -1)
            {
                komut = "INSERT INTO bolumler (bolum_adi,program_kodu,program_adi) VALUES ('" + ad + "', '" + bolumkod + "' , '" + programadi + "') ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else
            {
                //Bölümün Bahar ve Güz Tablosundaki Kayıtlarının Güncellenmesi

                komut = "select * from bolumler where id=" + bolumid + "";
                dt = new DataTable();
                dt = islemler.Al(komut);

                if (dt.Rows.Count != 0)
                {
                    progkod = dt.Rows[0]["program_kodu"].ToString();
                    progad = dt.Rows[0]["program_adi"].ToString();
                }
                komut = "UPDATE bahar SET Prg_Ad='" + programadi + "', Prg_Kod='" + bolumkod + "' where Prg_Ad='" + progad + "' and Prg_Kod='" + progkod + "'";
                islemler.Degistir(komut);

                komut = "UPDATE guz SET Prg_Ad='" + programadi + "', Prg_Kod='" + bolumkod + "' where Prg_Ad='" + progad + "' and Prg_Kod='" + progkod + "'";
                islemler.Degistir(komut);
                //-------------------

                komut = "UPDATE bolumler SET bolum_adi = '" + ad + "', program_kodu='" + bolumkod + "' , program_adi='" + programadi + "' WHERE id = " + bolumid + ";";
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
            komut = "select * from bolumler where program_kodu='" + txtbkod.Text + "' and id <>" + bolumid + " ;";
            rd = islemler.Oku(komut);
            if (rd.Read())
            {
                MessageBox.Show("Aynı İsimde Sınıf Bulunmakta Lütfen Başka İsim Girin..", "HATA!!");
                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtad.Text, txtbkod.Text, txtprogramadi.Text);
            }

        }
        #endregion

        #region Ekle Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "" || txtbkod.Text != "" || txtprogramadi.Text != "")
            {
                txtad.Text=txtad.Text.Trim();
                txtbkod.Text = txtbkod.Text.Trim();
                txtprogramadi.Text = txtprogramadi.Text.Trim();

                Sorgu();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!", "HATA!!");
            }

        }

        #endregion

        #region İptal Butonu
        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            Temizle();

        }
        #endregion

        #region Temizle
        public void Temizle()
        {
            btnkirmizi1.Visible = false;
            btnmavi1.Text = "EKLE";
            bolumid = -1;
            txtad.Text = "";
            txtbkod.Text = "";
            txtprogramadi.Text = "";
        }
        #endregion

        #region Değiştir Sil Butonları

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 3) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                bolumid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                switch (e.ColumnIndex)
                {
                    case 4:
                        btnkirmizi1.Visible = true;

                        komut = "select * from bolumler where id=" + bolumid + ";";
                        rd = islemler.Oku(komut);
                        if (rd.Read())
                        {
                            txtad.Text = rd["bolum_adi"].ToString();
                            txtbkod.Text = rd["program_kodu"].ToString();
                            txtprogramadi.Text = rd["program_adi"].ToString();
                            btnmavi1.Text = "DEĞİŞTİR";
                        }
                        else
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");
                        }
                        islemler.Kapat();
                        break;
                    case 5:
                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);
                        if (uyari == DialogResult.Yes)
                        {

                            //Bölümün Sınav ve Güz Tablosundaki Kayıtlarının Silinmesi
                            komut = "select * from bolumler where id=" + bolumid + "";
                            dt = new DataTable();
                            dt = islemler.Al(komut);

                            if (dt.Rows.Count != 0)
                            {
                                progkod = dt.Rows[0]["program_kodu"].ToString();
                                progad = dt.Rows[0]["program_adi"].ToString();
                            }
                            komut = "DELETE FROM guz WHERE Prg_Ad='" + progad + "' and Prg_Kod='" + progkod + "'";
                            islemler.Degistir(komut);

                            komut = "DELETE FROM bahar WHERE Prg_Ad='" + progad + "' and Prg_Kod='" + progkod + "'";
                            islemler.Degistir(komut);
                            //-------------------

                            //BÖlümün Bölümler Tablosundan silinmesi
                            komut = "DELETE FROM bolumler where id=" + bolumid + ";";
                            islemler.Degistir(komut);
                            //------------

                            MessageBox.Show("Silindi.");
                            Listele();
                            Temizle();
                        }
                        break;

                }

            }

        }

        #endregion

    }
}
