using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace sp
{
    public partial class Tasarim : Form
    {
        #region Yapıcı Metot ve Form_Load
        
        public Tasarim()
        {
            InitializeComponent();

            if (this.WindowState == FormWindowState.Normal)
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius

            }
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi
        }
        private void Tasarim_Load(object sender, EventArgs e)
        {


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
                    Brush arkaplan = new SolidBrush(Color.FromArgb(35, 157, 211)); ;
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    if (e.Item.Tag == "Kapat")
                    {
                        arkaplan = new SolidBrush(Color.FromArgb(219, 72, 72));
                    }
                    else
                    {
                        arkaplan = new SolidBrush(Color.FromArgb(35, 157, 211));
                    }
                    e.Graphics.FillRectangle(arkaplan, rc);
                }
            }
        }
        #endregion
        #region Formun Sürüklenmesi

        private bool mouseDown;
        private Point _start_point = new Point(0, 0);
        #region Formun Üzerine Tıklanınca
        private void Tasarim_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mouseDown = true;
                _start_point = new Point(e.X, e.Y);
            }
        }

        private void Tasarim_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (mouseDown)
                {
                    Point p = PointToScreen(e.Location);
                    Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
                }
            }
        }

        private void Tasarim_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mouseDown = false;
            }
        }
        #endregion
        #region Menü Üzerinde Tıklanınca

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mouseDown = true;
                _start_point = new Point(e.X, e.Y);
            }
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (mouseDown)
                {
                    Point p = PointToScreen(e.Location);
                    Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
                }
            }

        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mouseDown = false;
            }

        }
        #endregion

        #endregion


        #region Form Küçültme, Kapatma ve Büyütme
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #region Tam Ekran
        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0)); // border radius

            }

        }


        #endregion

        #endregion

        #endregion

        public void boyut(int x,int y)
        {
            this.Width = x;
            this.Height = y;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius

        }
    }
}
