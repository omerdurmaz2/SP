using System;
using System.Data;
using System.Windows.Forms;
namespace sp
{
    class ProgramaEkle
    {
        #region Dışarıda Tanımlananlar

        VeritabaniIslemler islemler = new VeritabaniIslemler();

        DataTable SınavProgramı;
        DataTable Bolumler;
        DataTable Dersler;
        string komut = "";

        string bolumkod = "";
        string bolumad = "";
        string derskod = "";
        string dersad = "";

        bool bolumdersislem = false;
        int bolumdersid = 0;

        #endregion

        public void TablolariCek()
        {
            Bolumler = new DataTable();
            komut = "select * from bolumler";
            Bolumler = islemler.Al(komut);

            Dersler = new DataTable();
            komut = "select * from dersler";
            Dersler = islemler.Al(komut);
        }
        public void YeniKayit(string tablo, string progkod, string progad, string donem, string dkod, string dad)
        {
            try
            {
                komut = "INSERT INTO " + tablo + " (Prg_Ad,Prg_Kod,Ogr_Sekli,donem,Ders_Kodu,Ders_Adi,Ogr_Sayisi,Unvan,Ad_Soyad,Tarih,Saat,Derslik1,Derslik2,Derslik3,Derslik4,Y_Ogr_Sayisi,Gozetmen1,Gozetmen2,Gozetmen3) VALUES ('" + progad + "','" + progkod + "',null,'" + donem + "','" + dkod + "','" + dad + "',null,null,null ,null ,null,null,null ,null,null,0,null ,null,null);";
                islemler.Degistir(komut);
            }
            catch (Exception err)
            {
                MessageBox.Show("Yeni Eklenen Ders Sınav Tablosunda Oluşturulurken Hata! \nHata Kodu: " + err, "HATA!");
            }
        }


        public void VerileriAl()
        {
            string bolumkod = "";
            string bolumad = "";
            string derskod = "";
            string dersad = "";

            try
            {

                if (bolumdersislem)
                {
                    if (bolumdersid != -1)
                    {
                        if (Bolumler.Rows.Count != 0)
                        {
                            for (int i = 0; i < Bolumler.Rows.Count; i++)
                            {
                                if (int.Parse(Bolumler.Rows[i]["id"].ToString()) == bolumdersid)
                                {
                                    bolumad = Bolumler.Rows[i]["program_adi"].ToString();
                                    bolumkod = Bolumler.Rows[i]["program_kodu"].ToString();
                                }
                            }
                        }
                    }

                }
                else
                {
                    if (bolumdersid != -1)
                    {
                        if (Dersler.Rows.Count != 0)
                        {
                            for (int i = 0; i < Dersler.Rows.Count; i++)
                            {
                                if (int.Parse(Dersler.Rows[i]["id"].ToString()) == bolumdersid)
                                {
                                    dersad = Dersler.Rows[i]["ders_adi"].ToString();
                                    derskod = Dersler.Rows[i]["ders_kodu"].ToString();
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Veriler Alınırken Hata! \nHata Kodu:" + err, "HATA!");
            }

        }
    }
}
