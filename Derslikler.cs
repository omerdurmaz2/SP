using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data;
namespace sp
{
    public partial class Derslikler : Form
    {
        #region Yapıcı Metot ve Form_Load

        public Derslikler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi

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

        #region Tasarım için Yapılmış Değişiklikler
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
        #region Menü Butonlarının Hoverı

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    Brush arkaplan = new SolidBrush(Color.FromArgb(35, 157, 211));
                    e.Graphics.FillRectangle(arkaplan, rc);
                }
            }
        }
        #endregion

        #endregion

        #region Formun Sürüklenmesi
        #region Formun Üzerinde Tıklanınca

        private bool mouseDown;
        private Point _start_point = new Point(0, 0);

        private void Derslikler_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void Derslikler_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void Derslikler_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        #endregion
        #region Menü Üzerinde Tıklanınca

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #endregion

        #region Form Küçültme ve Kapatma
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Dışarıda Tanımlananlar

        MySqlConnection bag = new MySqlConnection(ConnectionString.Al());// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlCommand kmt;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataAdapter adp;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataTable dt = new DataTable(); // tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataReader rd;// tekrar tekrar tanımlamamak için dışarı tanımladık
        private int derslikid=-1; // -1 ise yeni kayıt değilse id ye göre değiştirme
        string komut = "";
        string mesaj = "";
        #endregion

        #region Veritabanından verilerin Çekilip Listelenmesi

        public void Listele()
        {
            try
            {
                dt.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                bag = new MySqlConnection(ConnectionString.Al());
                bag.Open();
                kmt = new MySqlCommand("select id as Sıra_No, derslik as DERSLİK,sayi as KAPASİTE from sinavderslikleri", bag);
                adp = new MySqlDataAdapter(kmt);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                bag.Close();

                duzenle = new DataGridViewButtonColumn();
                duzenle.HeaderText = "DÜZENLE";
                duzenle.Text = "DÜZENLE";
                duzenle.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(duzenle);

                sil = new DataGridViewButtonColumn();
                sil.HeaderText = "SİL";
                sil.Text = "SİL";
                sil.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(sil);


            }
            catch (Exception err)
            {

                MessageBox.Show("İşlem Gerçekleştirlemedi, Lütfen Sonra Tekrar Deneyin!" + err.ToString());
                this.Close();
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
        private void button5_Click(object sender, EventArgs e)
        {
            FormKontrol();
            Listele();

        }
        #endregion

        #region Sorgu Methodu

        public void Sorgu()
        {
            try
            {
                bag.Open();
                komut = "select * from sinavderslikleri where derslik='" + txtad.Text + "';";
                kmt = new MySqlCommand(komut, bag);
                rd = kmt.ExecuteReader();
                if (rd.Read())
                {
                    MessageBox.Show("Aynı İsimde Sınıf Bulunmakta Lütfen Başka İsim Girin.." ,"HATA!!");
                    bag.Close();

                }
                else
                {
                    bag.Close(); // aşağıdaki method da da veritabanına bağlantı açıldığı için burada bağlantıyı kapattık
                    Kaydet(txtad.Text, int.Parse(txtkapasite.Text));
                }


            }
            catch (Exception err)
            {

                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin : \n" + err, "HATA!!");
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
                button5.Text = "EKLE";
                button1.Visible = false;
                derslikid = -1;
            }

            try
            {
                bag.Open();
                kmt = new MySqlCommand(komut, bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                txtad.Text = "";
                txtkapasite.Text = "";
                MessageBox.Show(mesaj);
            }
            catch (Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin" + err.Message, "HATA!!");
            }
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
            if (e.RowIndex > 0 && e.ColumnIndex > 2) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                derslikid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                switch (e.ColumnIndex)
                {
                    case 3:
                        try
                        {
                            button1.Visible = true;
                            bag.Open();
                            kmt = new MySqlCommand("select * from sinavderslikleri where id=" + derslikid + ";", bag);
                            rd = kmt.ExecuteReader();
                            if (rd.Read())
                            {
                                txtad.Text = rd["derslik"].ToString();
                                txtkapasite.Text = rd["sayi"].ToString();
                                button5.Text = "DEĞİŞTİR";
                            }
                            else
                            {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin" , "HATA!!");
                            }
                            bag.Close();


                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin" + err.Message, "HATA!!");
                            

                        }
                        break;
                    case 4:
                        try
                        {
                            DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);
                            if (uyari == DialogResult.Yes)
                            {
                                bag.Open();
                                kmt = new MySqlCommand("DELETE FROM sinavderslikleri where id=" + derslikid + ";", bag);
                                kmt.ExecuteNonQuery();
                                bag.Close();
                                MessageBox.Show("Silindi.");
                                Listele();

                            }
                        }
                        catch (Exception err)
                        {

                            MessageBox.Show("Hata: " + err);
                        }

                        break;

                }
            }

        }
        #endregion

        #region İptal Butonu

        private void button1_Click(object sender, EventArgs e)
        {
            derslikid = -1;
            button5.Text = "EKLE";
            txtad.Text = "";
            txtkapasite.Text = "";
            button1.Visible = false;

        }
        #endregion

    }
}
