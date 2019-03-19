using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Security.AccessControl;
using System.IO;

namespace sp
{
    class PdfYazdir
    {
        private object pdftable;

        public PdfYazdir(DataTable tablo, string Baslik, string yol)
        {


            try
            {
                //Dosya Yoluna Erişim İzni Alınıyor
                DirectorySecurity ds = Directory.GetAccessControl(yol);
                ds.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                Directory.SetAccessControl(yol, ds);
                //----------------

                FileStream fs = new FileStream(yol, FileMode.Create, FileAccess.Write, FileShare.None);
                
                Document dosya = new Document();
                dosya.SetPageSize(PageSize.A4);
                PdfWriter pdf = PdfWriter.GetInstance(dosya, fs);
                dosya.Open();

                BaseFont baslik = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font baslikfont = new Font(baslik, 16, 1);
                Paragraph pbaslik = new Paragraph();
                pbaslik.Alignment = Element.ALIGN_CENTER;
                pbaslik.Add(new Chunk(baslik.ToString().ToUpper(), baslikfont));

                //Çizgi Ekleme
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, -1)));
                dosya.Add(p);

                //sayfada bir alt satıra indirliyor
                dosya.Add(new Chunk("/n", baslikfont));

                //tablo oluşturuluyor
                PdfPTable pdftablo = new PdfPTable(tablo.Columns.Count);

                //tablo başlığı
                BaseFont tablobfont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font tablobfonta = new Font(tablobfont, 10, 1);
                for (int i = 0; i < tablo.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = BaseColor.BLACK;
                    cell.AddElement(new Chunk(tablo.Columns[i].ToString().ToUpper(), tablobfonta));
                    pdftablo.AddCell(cell);
                }
                //tablo içeriği
                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    for (int j = 0; j < tablo.Columns.Count; j++)
                    {
                        pdftablo.AddCell(tablo.Rows[i][j].ToString());
                    }
                }

                dosya.Add(pdftablo);
                dosya.Close();
                pdf.Close();
                fs.Close();

            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Hata!\nHata Kodu:" + err);
            }
        }
    }
}
