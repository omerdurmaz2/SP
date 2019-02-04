using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data;
namespace sp
{
    public partial class Bolumler : Form
    {
        #region Yapıcı Metot ve Form_Load

        public Bolumler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi

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
        #region Formun Sürüklenmesi
        #region Formun Üzerinde Tıklanınca

        private bool mouseDown;
        private Point _start_point = new Point(0, 0);

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void Home_MouseUp(object sender, MouseEventArgs e)
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

        #endregion

        #region Dışarıda Tanımlananlar
        public int bolumid=-1;
        string komut = "";
        string mesaj = "";
        MySqlDataReader rd;
        DataTable dt = new DataTable();
        VeritabaniIslemler islemler = new VeritabaniIslemler();
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık

        #endregion

        #region Listele
        public void Listele()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            komut = "select id as 'SIRA NO', bolum_adi as 'BÖLÜM ADI' from bolumler";

            if (islemler.Al(komut) != null)
            {
                dataGridView1.DataSource = islemler.Al(komut); ;

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
        }

        #endregion

        #region Kaydet Methodu
        public void Kaydet(string ad)
        {

            if (bolumid == -1)
            {
                komut = "INSERT INTO bolumler (bolum_adi) VALUES ('" + ad + "') ";
                mesaj = "Yeni Kayıt Eklendi";
            }
            else
            {

                komut = "UPDATE bolumler SET bolum_adi = '" + ad + "' WHERE id = " + bolumid + ";";
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
            komut = "select * from bolumler where bolum_adi='" + txtad.Text + "' and id <>" + bolumid + " ;";
            rd = islemler.Oku(komut);
            if (rd.Read())
            {
                MessageBox.Show("Aynı İsimde Sınıf Bulunmakta Lütfen Başka İsim Girin..", "HATA!!");
                islemler.Kapat();
            }
            else
            {
                islemler.Kapat();
                Kaydet(txtad.Text);
            }

        }
        #endregion

        #region Ekle Butonu
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtad.Text != null)
            {
                Sorgu();
            }
            else
            {
                MessageBox.Show("Lütfen Bölüm Adını Giriniz!", "HATA!!");
            }
        }

        #endregion

        #region İptal Butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        #endregion

        #region Temizle
        public void Temizle()
        {
            button2.Visible = false;
            button3.Text = "EKLE";
            bolumid = -1;
            txtad.Text = "";
        }
        #endregion

        #region Değiştir Sil Butonları

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 1) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                bolumid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                switch (e.ColumnIndex)
                {
                    case 2:
                        button2.Visible = true;

                        komut = "select * from bolumler where id=" + bolumid + ";";
                        rd = islemler.Oku(komut);
                        if (rd.Read())
                        {
                            txtad.Text = rd["bolum_adi"].ToString();
                            button3.Text = "DEĞİŞTİR";
                        }
                        else
                        {
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");
                        }
                        islemler.Kapat();
                        rd.Close(); //mysqldatareaderi temizliyoruz
                        break;
                    case 3:
                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);
                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM bolumler where id=" + bolumid + ";";
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

    }
}
