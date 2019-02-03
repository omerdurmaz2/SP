using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace sp
{
    public partial class Home : Form
    {
        #region Yapıcı Metot ve Form_Load
        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi

        }
        private void Home_Load(object sender, EventArgs e)
        {
            Login giris = new Login();
            giris.ShowDialog(); //anasayfa açıldığında giris ekranını açma
            if (Login.Session == false)
            {
                this.BeginInvoke(new MethodInvoker(this.Close));// formu zorla kapatma yolu
            }
            else
            {
                if (Login.Yetki!=0)
                {
                    button1.Visible = false;
                    button12.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;

                }
                label1.Text = Login.Ad;
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

        #region Öğretim Elemanları Görüntüleme,Düzenleme ve Yeni Ekleme Butonu

        private void button12_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            OgretimElemanlari ogr = new OgretimElemanlari();
            ogr.ShowDialog();

        }
        #endregion
        #region Anasayfaya Geri Dönüldüğünde Bağlanıyor Yazısı Gitmesi İçin

        private void Home_Activated(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
        #endregion
        #region Derslik Görüntüleme ve Ekleme Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            Derslikler ders = new Derslikler();
            ders.ShowDialog();
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;

        }
    }
}
