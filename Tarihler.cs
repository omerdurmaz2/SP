using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data;
namespace sp
{
    public partial class Tarihler : Form
    {
        #region Yapıcı Metot ve Form_Load

        public Tarihler()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // border radius
            menuStrip1.Renderer = new MyRenderer(); // menü butonlarının hover rengi

        }
        private void TasarimOrnek_Load(object sender, EventArgs e)
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

        #region Dışarıda Tanımlanan Değişkenler
        DataGridViewButtonColumn sil;// tekrar tekrar tanımlamamak için dışarı tanımladık
        DataTable dt = new DataTable(); // tekrar tekrar tanımlamamak için dışarı tanımladık
        DataGridViewButtonColumn duzenle;// tekrar tekrar tanımlamamak için dışarı tanımladık
        MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        VeritabaniIslemler islemler = new VeritabaniIslemler();


        string komut = "";
        string mesaj = "";
        string kontrol = "";
        int varmisayac = 0; // tabloda değerlerin olup olmamasına göre artacak değere göre ekrana farklı mesajlar gösterilecek
        bool varmi = false; // eğer false ise tabloya kaydedilecek,true ise kaydedilmeyecek

        public int tarihid = -1;

        #endregion

        #region Veritabanından Verilerin Çekilip Listelenmesi
        public void Listele()
        {

            dataGridView1.DataSource = null; // datagridview temizlenir
            dataGridView1.Columns.Clear();// datagridview temizlenir
            dataGridView1.Refresh(); // datagridview yenilenir

            komut = "select id as Sıra_No,tarih as Tarih from sinavtarihleri";
            dataGridView1.DataSource = islemler.Al(komut);

            //değiştir butonu her satır için eklenir
            duzenle = new DataGridViewButtonColumn();
            duzenle.HeaderText = "DÜZENLE";
            duzenle.Text = "DÜZENLE";
            duzenle.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(duzenle);

            //sil butonu her satır için eklenir
            sil = new DataGridViewButtonColumn();
            sil.HeaderText = "SİL";
            sil.Text = "SİL";
            sil.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(sil);

            dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Ascending);

            //Tablodaki Tarihin yanına hangi gün olduğunu yazan kod (Tablo Sıralanmasından Dolayı Hata Veriyor)
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    string gun = dataGridView1.Rows[i].Cells[1].Value.ToString();


            //    string turkce = CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat.DayNames[(int)Convert.ToDateTime(gun).DayOfWeek];
            //    dataGridView1.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value + " (" + turkce + ")";

            //}



        }

        #endregion

        #region Tarih Kontrol
        public void Kontrol(DateTime tarih1, DateTime tarih2)
        {
            #region Eğer Yeni Ekleme Yapılıyorsa

            if (tarihid == -1)
            {
                //select komutu için girilen tarih ararlığının yazılması
                if (tarih1.ToShortDateString() != tarih2.ToShortDateString())//kullanıcı tarih aralığı belirlediyse tabloya ekleyecek,belirlemediyse belirlemesi istenecek
                {

                    kontrol = "SELECT tarih FROM sinavtarihleri WHERE ";

                    for (DateTime i = Convert.ToDateTime(tarih1.ToString("yyyy-MM-dd")); i <= Convert.ToDateTime(tarih2.ToString("yyyy-MM-dd")); i = i.AddDays(1))
                    {
                        if (i.DayOfWeek.ToString() == "Saturday" || i.DayOfWeek.ToString() == "Sunday") { }
                        else
                        {
                            string format = i.ToString("yyyy-MM-dd");
                            kontrol += "tarih = '" + format + "' OR ";
                        }

                    }
                    //komut sonunda ki fazlalık OR alınır ve noktalı virgül eklenir
                    kontrol = kontrol.Substring(0, kontrol.Length - 3);
                    kontrol += ";";

                    dataGridView1.DataSource = null; // datagridview kaynak temizlenir
                    dataGridView1.Columns.Clear();// datagridview temizlenir
                    dataGridView1.Refresh(); // datagridview yenilenir

                    dt = islemler.Al(kontrol);

                    komut = "INSERT  INTO sinavtarihleri (tarih) values ";
                    if (dt.Rows.Count == 0)
                    {
                        for (DateTime i = Convert.ToDateTime(tarih1.ToShortDateString()); i <= Convert.ToDateTime(tarih2.ToShortDateString()); i = i.AddDays(1)) // böyle yapılmasının sebebi saatler uyuşmadığı için saatleri sıfırlıyoruz
                        {
                            if (i.DayOfWeek.ToString() == "Saturday" || i.DayOfWeek.ToString() == "Sunday") { }
                            else
                            {
                                string format = i.ToString("yyyy-MM-dd");
                                komut += "('" + format + "'), ";
                            }
                        }
                    }
                    else
                    {
                        for (DateTime i = Convert.ToDateTime(tarih1.ToShortDateString()); i <= Convert.ToDateTime(tarih2.ToShortDateString()); i = i.AddDays(1)) // böyle yapılmasının sebebi saatler uyuşmadığı için saatleri sıfırlıyoruz
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (i.ToString() == dt.Rows[j]["tarih"].ToString())
                                {
                                    varmisayac++;
                                    varmi = true;
                                }
                            }
                            if (varmi == false)
                            {
                                if (i.DayOfWeek.ToString() == "Saturday" || i.DayOfWeek.ToString() == "Sunday") { }
                                else
                                {
                                    string format = i.ToString("yyyy-MM-dd");
                                    komut += "('" + format + "'), ";
                                }
                            }
                            else varmi = false; //tekrar kullanılmak için false yapılıyor

                        }

                    }

                    if (komut == "INSERT  INTO sinavtarihleri (tarih) values ")
                    {
                        MessageBox.Show("Seçilen aralıktaki Tarihler Zaten Kayıtlı ", "HATA!!");
                        Listele();
                        return;
                    }
                    else
                    {
                        komut = komut.Substring(0, komut.Length - 2); //sondaki fazlalık virgülü alma
                        komut += ";"; //komutu bitirmek sona noktalı virgül
                        mesaj = "Tarihler Kaydedildi. Lütfen Aşağıdaki Tablodan Seçtiğiniz Tarih Aralığındaki Milli Tatil (Bayram) Günlerini Çıkarınız!";
                        Kaydet(tarih1, tarih2);
                        if (varmisayac != 0) // eğer tabloda hiç aynı değer yok ise ekrana bu mesaj gösterilmeyecek
                        {
                            MessageBox.Show("Seçilen Aralıktaki Tarihlerden Bazıları Tabloda Önceden Kaydedildiği için Tekrar Kaydedilmemiştir", "UYARI!");
                        }


                    }

                }
                else//1. tarih ve 2. tarih aynı ise uyarıyor
                {
                    MessageBox.Show("Lütfen Tarih Aralığı Seçin", "HATA!!!");
                    return;

                }

            }
            #endregion
            #region Eğer Değiştirme Yapılıyorsa

            else //eğer işlem yeni kayıt ekleme değil eski bir kayıt düzenleme yapılıyorsa bu alanda aynı tarih olup olmamasına bakılır
            {

                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Saturday" || dateTimePicker1.Value.DayOfWeek.ToString() == "Sunday")
                {
                    MessageBox.Show("Seçilen Tarih Haftasonudur Lütfen Başka Bir Tarih Giriniz!", "UYARI!");
                }
                else
                {
                    string format = dateTimePicker1.Value.ToString("yyyyMMdd"); // veritabanı için tarih formatını değiştiriyoruz
                    komut = "select * from sinavtarihleri where tarih='" + format + "';";

                    dr = islemler.Oku(komut);
                    if (dr.Read())
                    {
                        islemler.Kapat();
                        MessageBox.Show("Seçilen Tarih Zaten Kayıtlı!", "UYARI!");
                    }
                    else
                    {
                        islemler.Kapat();
                        Kaydet(tarih1, tarih2);
                    }
                }
            }
            #endregion

        }
        #endregion

        #region Kaydet Methodu
        public void Kaydet(DateTime tarih1, DateTime tarih2)
        {

            if (tarihid != -1)
            {
                string format = dateTimePicker1.Value.ToString("yyyyMMdd");

                komut = "UPDATE sinavtarihleri SET tarih='" + format + "' WHERE id=" + tarihid + ";";
                mesaj = "Tarihler Güncellendi.";

            }
            else { }
            islemler.Degistir(komut);
            Listele();
            Temizle();
            MessageBox.Show(mesaj, "UYARI");
        }
        #endregion


        #region Ekle Butonu
        private void button5_Click(object sender, EventArgs e)
        {
            Kontrol(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        #endregion

        //dateTimePicker1 de tarih değiştiğinde dateTimePicker2 de başlangıç tarihi ayarlama
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (tarihid == -1)
            {
                dateTimePicker2.MinDate = dateTimePicker1.Value;
            }
        }

        #region Temizle Methodu
        public void Temizle()
        {
            button1.Visible = false;
            button5.Text = "EKLE";
            dateTimePicker2.Visible = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            tarihid = -1;
            label1.Visible = true;
            label2.Text = "Başlangıç Tarihi:";

        }
        #endregion

        #region Düzenle ve Sil Butonları
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 1) // sütun başlığına tıklayınca hata vermesini önlemek için...
            {
                tarihid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //seçilen verinin idsini atıyor

                switch (e.ColumnIndex)
                {
                    case 2: //değiştir

                        komut = "select * from sinavtarihleri where id=" + tarihid + ";";

                        dr = islemler.Oku(komut);
                        if (dr.Read())
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(dr["tarih"].ToString());

                            dateTimePicker2.Visible = false;
                            button1.Visible = true; //iptal butonu görünür
                            label1.Visible = false;
                            label2.Text = "Tarih Seç:";
                            button5.Text = "GÜNCELLE";
                        }
                        else
                        { // eğer kayıt buluanmazsa hata verir
                            MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin", "HATA!!");
                            Temizle(); // ekranı temizler
                        }

                        islemler.Kapat();

                        break;
                    case 3:
                        DialogResult uyari = MessageBox.Show("Silmek İstiyor musunuz? ", "DİKKAT!", MessageBoxButtons.YesNo);// silmek istenip istenmediği sorulur

                        if (uyari == DialogResult.Yes)
                        {
                            komut = "DELETE FROM sinavtarihleri where id=" + tarihid + ";";
                            islemler.Degistir(komut);

                            MessageBox.Show("Silindi.");

                            Temizle(); // tarihid sıfırlansın diye ekledik
                            Listele(); //tablo tekrar listelenir

                        }
                        break;

                }

            }

        }
        #endregion

        #region İptal Butonu

        private void button1_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        #endregion


    }
}
