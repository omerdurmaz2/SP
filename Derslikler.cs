using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
namespace sp
{
    public partial class Derslikler : Tasarim
    {
        #region Yapıcı Metot ve Form_Load

        public Derslikler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius  
            this.yToolStripMenuItem.Visible = false;
            baslikhizala();
        }
        private void Derslikler_Load(object sender, EventArgs e)
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

        #region Dışarıda Tanımlananlar

        MySqlDataReader rd;// tekrar tekrar tanımlamamak için dışarı tanımladık
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        private int derslikid = -1; // -1 ise yeni kayıt değilse id ye göre değiştirme
        string komut = "";
        string mesaj = "";
        #endregion

        #region Listele

        public void Listele()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            komut = "select id as Sıra_No, derslik as DERSLİK,sayi as KAPASİTE from sinavderslikleri";

            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut); ;

                ButonEkle(); //tasarımda hazır bulunan butonları ekliyoruz
                dataGridView1.Columns.Add(duzenle);

                dataGridView1.Columns.Add(sil);
            }
        }

        #endregion

        #region Form Kontrol

        public void FormKontrol()
        {
            if (txtad.Text == "" || txtkapasite.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
            }
            else
            {
                if (derslikid == -1)
                {
                    Sorgu();
                }
                else
                {
                    Kaydet(txtad.Text, int.Parse(txtkapasite.Text));
                }

            }

        }
        #endregion

        #region Ekle Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            txtkapasite.Text = txtkapasite.Text.Trim();
            txtad.Text = txtad.Text.Trim();
            FormKontrol();

        }
        #endregion

        #region Sorgu Methodu

        public void Sorgu()
        {
            komut = "select * from sinavderslikleri where derslik='" + txtad.Text + "';";
            rd = islemler.Oku(komut);
            if (rd.Read())
            {
                MessageBox.Show("Aynı İsimde Sınıf Bulunmakta Lütfen Başka İsim Girin..", "HATA!!");
                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtad.Text, int.Parse(txtkapasite.Text));
            }


        }
        #endregion

        #region Kaydet Methodu
        public void Kaydet(string ad, int kapasite)
        {

            if (derslikid == -1)
            {
                komut = "INSERT INTO sinavderslikleri (derslik,sayi) VALUES ('" + ad + "'," + kapasite + ") ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else
            {

                komut = "UPDATE sinavderslikleri SET derslik = '" + ad + "' ,sayi = " + kapasite + "  WHERE id = " + derslikid + ";";
                mesaj = "Kayıt Güncellendi";

            }
            islemler.Degistir(komut);
            MessageBox.Show(mesaj);
            Temizle();
            Listele();

        }
        #endregion

        #region Kapasite Sadece Sayı Girişi

        private void txtkapasite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Değiştir Sil Butonu

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 2) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                derslikid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                switch (e.ColumnIndex)
                {
                    case 3:
                        btnkirmizi1.Visible = true;

                        komut = "select * from sinavderslikleri where id=" + derslikid + ";";
                        rd = islemler.Oku(komut);
                        if (rd.Read())
                        {
                            txtad.Text = rd["derslik"].ToString();
                            txtkapasite.Text = rd["sayi"].ToString();
                            btnmavi1.Text = "DEĞİŞTİR";
                        }
                        else
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");
                        }
                        islemler.Kapat();
                        rd.Close(); //mysqldatareaderi temizliyoruz
                        break;
                    case 4:
                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);
                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM sinavderslikleri where id=" + derslikid + ";";
                            islemler.Degistir(komut);
                            MessageBox.Show("Silindi.");
                            Listele();
                            Temizle();
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
        }
        #endregion

        #region Temizle
        public void Temizle()
        {
            derslikid = -1;
            btnmavi1.Text = "EKLE";
            txtad.Text = "";
            txtkapasite.Text = "";
            btnkirmizi1.Visible = false;
        }
        #endregion

    }
}
