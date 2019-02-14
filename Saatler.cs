using MySql.Data.MySqlClient;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace sp
{
    public partial class Saatler : Tasarim
    {

        #region Yapıcı Metot ve Form_Load

        public Saatler()
        {

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            this.yToolStripMenuItem.Visible = false;
            baslikhizala();

        }

        private void saatler_Load(object sender, EventArgs e)
        {
            if (Login.Session)
            {
                yenile();
            }
            else
            {
                this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
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
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        private int saatid = -1;
        string komut = "";
        string guncelle = "";
        string silme = "";
        string tamsaat;
        string[] kes = new string[2];
        #endregion

        #region Listedeki Elemanları Değiştirme ve Silme
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex > 1) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        btnkirmizi1.Visible = true;
                        string saat = "";
                        saatid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        DateTime zaman = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        btnmavi1.Text = "DEĞİŞTİR";
                        saat = zaman.ToShortTimeString();
                        kes = saat.Split(':');
                        comboBox1.SelectedItem = kes[0];
                        comboBox2.SelectedItem = kes[1];
                        break;
                    case 3:
                        DialogResult secenek = MessageBox.Show("Saati silmek istiyor musunuz?", "Kayıt Kontrolü", MessageBoxButtons.YesNo);
                        if (secenek == DialogResult.Yes)
                        {
                            silme = "Delete  from sinavsaatleri where id=" + saatid + "";
                            islemler.Degistir(silme);
                            temizle();
                            yenile();
                        }
                        else if (secenek == DialogResult.No)
                        {
                            temizle();
                            yenile();
                        }
                        break;
                }
            }
        }
        #endregion

        #region Ekle / Değiştir Butonu
        private void btnmavi1_Click(object sender, EventArgs e)
        {
            btnkirmizi1.Visible = false;

            kes[0] = comboBox1.SelectedItem.ToString();
            kes[1] = comboBox2.SelectedItem.ToString();
            tamsaat = kes[0] + ":" + kes[1];

            // guncelle = "UPDATE sinavsaatleri SET saat ='" + tamsaat + "' Where id=" + saatid + "";
            //islemler.Degistir(guncelle);
            if (saatid == -1)
            {
                guncelle = "INSERT INTO sinavsaatleri (saat) VALUES ('" + tamsaat + "') ";
                islemler.Degistir(guncelle);
                temizle();
                yenile();


            }
            else
            {
                guncelle = "UPDATE sinavsaatleri SET saat ='" + tamsaat + "' Where id=" + saatid + "";
                islemler.Degistir(guncelle);
                temizle();
                yenile();



            }

        }
        #endregion

        #region İptal Butonu
        private void btnkirmizi1_Click(object sender, EventArgs e)
        {
            temizle();
            yenile();
        }
        #endregion

        #region Temizle
        public void temizle()
        {
            saatid = -1;
            comboBox1.SelectedIndex = 00;
            comboBox2.SelectedIndex = 00;
            btnmavi1.Text = "EKLE";
        }
        #endregion

        #region Listele / Yenile
        public void yenile()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            komut = "select id as 'SIRA NO',saat as 'SAAT' from sinavsaatleri order by saat asc ";
            dataGridView1.DataSource = islemler.Al(komut);
            ButonEkle();
            dataGridView1.Columns.Add(duzenle);
            dataGridView1.Columns.Add(sil);
            btnkirmizi1.Visible = false;


        }
        #endregion

    }
}