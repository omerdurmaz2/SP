using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
namespace sp
{
    public partial class OgretimElemanlari : Form
    {
        public byte islem{ get; set; } //session olarak ekleme formu açıldığına bu formun islem parametresinin true ya da false olmasına bakacak. Eğer true ise yeni ekleme, false ise duzenleme olacak sekilde ekrani duzenleyecek
        public int id { get; set; } // session olarak duzenlenecek uyenin id sini tutuyor

        public string ConnectionString()
        {

            return "server=remotemysql.com; database= tDNQ1XRXlu; uid=tDNQ1XRXlu; pwd=F44eHROJZ1;";
        }
        #region Tablo Elemanları

        MySqlConnection bag;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlCommand kmt;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataAdapter adp;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataTable dt = new DataTable(); // tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık
        #endregion

        public void Listele()
        {
            try
            {

                dt.Rows.Clear();
                dt.Columns.Clear();
                dataGridView1.Columns.Clear();
                bag = new MySqlConnection(ConnectionString());
                bag.Open();
                kmt = new MySqlCommand("select id as Sıra_No,unvan as Unvan,Ad_Soyad,eposta as E_posta,Kendi_Sinav_Sayisi ,Gozetmenlik_Sayisi from OgretimElemani", bag);
                adp = new MySqlDataAdapter(kmt);
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                bag.Close();

                duzenle = new DataGridViewButtonColumn();
                duzenle.HeaderText = "duzenle";
                duzenle.Text = "duzenle";
                duzenle.UseColumnTextForButtonValue = true;
                duzenle.DataPropertyName = "id";
                dataGridView1.Columns.Add(duzenle);

                sil = new DataGridViewButtonColumn();
                sil.HeaderText = "SİL";
                sil.Text = "SİL";
                sil.UseColumnTextForButtonValue = true;
                sil.DataPropertyName = "id";
                dataGridView1.Columns.Add(sil);

            }
            catch (Exception err)
            {

                MessageBox.Show("İşlem Gerçekleştirlemedi" + err.ToString());
            }
        }
        public OgretimElemanlari()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi


        }
        private void OgretimElemanlari_Load(object sender, EventArgs e)
        {
            //session kontrolü
            //Login giris = new Login();
            //if (giris.Session)
            //{

            Listele();

            //}
            //else
            //{
            //    this.Close();
            //}
        }
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
        #region Form Küçültme  ve Kapatma
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            YeniOgretimElemani yogr = new YeniOgretimElemani();
            this.islem = 0; 
            var cevap = yogr.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                Listele();
            }
            else MessageBox.Show("İşlem Gerçekleştirlemedi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 6:
                    this.id = id;
                    this.islem = 1;
                    YeniOgretimElemani yogr = new YeniOgretimElemani();
                    var cevap = yogr.ShowDialog();
                    if (cevap == DialogResult.OK)
                    {
                        Listele();
                    }
                    else MessageBox.Show("İşlem Gerçekleştirlemedi");

                    break;
                case 7:
                    try
                    {
                        MySqlConnection bag;
                        MySqlCommand kmt;
                        bag = new MySqlConnection(ConnectionString());
                        bag.Open();
                        kmt = new MySqlCommand("DELETE FROM OgretimElemani where id=" + id + ";", bag);
                        kmt.ExecuteNonQuery();
                        bag.Close();
                    }
                    catch (Exception err)
                    {

                        MessageBox.Show("Hata: " + err);
                    }
                    Listele();

                    break;

            }
        }


    }
}
