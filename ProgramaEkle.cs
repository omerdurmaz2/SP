using System;
using System.Data;
using System.Windows.Forms;

namespace sp
{
    class ProgramaEkle
    {
        #region Dışarıda Tanımlananlar

        VeritabaniIslemler islemler = new VeritabaniIslemler();
        MySql.Data.MySqlClient.MySqlDataReader dr;
        DataTable Bolumler;
        string komut = "";

        string derskod = "";
        string dersad = "";


        #endregion

        public void YeniKayit(string tablo, string bolum, string donem, string dkod, string dad)
        {
            Bolumler = new DataTable();
            komut = "select * from bolumler";
            Bolumler = islemler.Al(komut);
            
            string progkod = "", progad = "";
            try
            {

                //Seçilen Döneme Göre Tablo Belirleniyor
                if (tablo == "1. Dönem" || tablo == "3. Dönem")
                {
                    tablo = "guz";
                }
                else
                {
                    tablo = "bahar";
                }

                //Seçilen Bölüme Göre Tabloya Eklenecek Kayıtlar Belirleniyor
                if (bolum == "ORTAK DERS")
                {
                    if (Bolumler.Rows.Count != 0)
                    {
                        for (int i = 0; i < Bolumler.Rows.Count; i++)
                        {
                            progkod = Bolumler.Rows[i]["program_kodu"].ToString();
                            progad = Bolumler.Rows[i]["program_adi"].ToString();


                            komut = "INSERT INTO " + tablo + " (Prg_Ad,Prg_Kod,Ogr_Sekli,donem,Ders_Kodu,Ders_Adi,Ogr_Sayisi,Unvan,Ad_Soyad,Tarih,Saat,Derslik1,Derslik2,Derslik3,Derslik4,Y_Ogr_Sayisi,Gozetmen1,Gozetmen2,Gozetmen3) VALUES ('" + progad + "','" + progkod + "',null,'" + donem + "','" + dkod + "','" + dad + "',null,null,null ,null ,null,null,null ,null,null,0,null ,null,null);";
                            islemler.Degistir(komut);

                        }

                    }
                }
                else
                {

                    for (int i = 0; i < Bolumler.Rows.Count; i++)
                    {
                        string birlesik = Bolumler.Rows[i]["program_kodu"].ToString() + " " + Bolumler.Rows[i]["program_adi"].ToString();
                        if (birlesik == bolum)
                        {
                            progkod = Bolumler.Rows[i]["program_kodu"].ToString();
                            progad = Bolumler.Rows[i]["program_adi"].ToString();
                        }
                    }
                    komut = "INSERT INTO " + tablo + " (Prg_Ad,Prg_Kod,Ogr_Sekli,donem,Ders_Kodu,Ders_Adi,Ogr_Sayisi,Unvan,Ad_Soyad,Tarih,Saat,Derslik1,Derslik2,Derslik3,Derslik4,Y_Ogr_Sayisi,Gozetmen1,Gozetmen2,Gozetmen3) VALUES ('" + progad + "','" + progkod + "',null,'" + donem + "','" + dkod + "','" + dad + "',null,null,null ,null ,null,null,null ,null,null,0,null ,null,null);";
                    islemler.Degistir(komut);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Yeni Eklenen Ders Sınav Tablosunda Oluşturulurken Hata! \nHata Kodu: " + err, "HATA!");
            }
        }
        public void KayitGuncelle(string yenitablo, string eskitablo, string donem, string dkod, string dad, string dersid, string bolum)
        {
            try
            {
                komut = "select * from ders ";
                dr = islemler.Oku(komut);
                while (dr.Read())
                {
                    if (dr.GetString("id") == dersid.ToString())
                    {
                        derskod = dr.GetString("ders_kodu");
                        dersad = dr.GetString("ders_adi");
                        break;
                    }
                }
                islemler.Kapat();

                if (yenitablo == eskitablo)
                {
                    komut = "UPDATE " + yenitablo + " SET Ders_Kodu='" + dkod + "', Ders_Adi='" + dad + "', donem='" + donem + "' WHERE Ders_Kodu='" + derskod + "' and Ders_Adi='" + dersad + "'";
                    islemler.Degistir(komut);

                }
                else if (yenitablo == "guz")
                {
                    KayitSil(int.Parse(dersid), 1);

                    YeniKayit(donem, bolum, donem, dkod, dad);

                }
                else if (yenitablo == "bahar")
                {
                    KayitSil(int.Parse(dersid), 2);

                    YeniKayit(donem, bolum, donem, dkod, dad);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Düzenlenen Ders Sınav Programı Tablosunda Düzenlenilirken Hata! \nHata Kodu: " + err, "HATA!");
            }
        }

        public void KayitSil(int dersid, byte tablo)
        {
            komut = "select * from ders ";
            dr = islemler.Oku(komut);
            while (dr.Read())
            {
                if (dr.GetString("id")==dersid.ToString())
                {
                    derskod = dr.GetString("ders_kodu");
                    dersad = dr.GetString("ders_adi");
                    break;
                }
            }
            islemler.Kapat();

            switch (tablo)
            {
                case 1:
                    komut = "DELETE FROM bahar where Ders_Kodu='" + derskod + "' and Ders_Adi='" + dersad + "'";
                    islemler.Degistir(komut);

                    break;
                case 2:
                    komut = "DELETE FROM guz where Ders_Kodu='" + derskod + "' and Ders_Adi='" + dersad + "'";
                    islemler.Degistir(komut);
                    break;
            }
        }

    }
}
