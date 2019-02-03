using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace sp
{
    class VeritabaniIslemler
    {
        public MySqlConnection bag = new MySqlConnection(ConnectionString.Al()); // tekrar tekrar tanımlamamak için dışarı tanımladık
        public MySqlCommand kmt; // tekrar tekrar tanımlamamak için dışarı tanımladık
        public MySqlDataAdapter adp; // tekrar tekrar tanımlamamak için dışarı tanımladık
        public MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        public DataTable dt = new DataTable();
        public DataTable Al(string komut)
        {
            dt.Clear();
            try
            {
                
                bag.Open();
                kmt = new MySqlCommand(komut, bag);
                adp = new MySqlDataAdapter(kmt);
                adp.Fill(dt);
                bag.Close();
                return dt;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin: \n" + err, "HATA!");
                return null;
            }
        }
        public  MySqlDataReader Oku(string komut)
        {
            try
            {
                bag.Open();
                
                kmt = new MySqlCommand(komut, bag);
                dr = kmt.ExecuteReader();
                return dr;

            }
            catch (System.Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin: \n" + err, "HATA!");
                return null;
            }

        }
        public void Kapat()
        {
            try
            {

                bag.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin: \n" + err, "HATA!");
            }

        }
        public void Degistir(string komut)
        {
            try
            {
                bag.Open();
                kmt = new MySqlCommand(komut, bag);
                kmt.ExecuteNonQuery();
                bag.Close();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi. Lütfen Daha Sonra Tekrar Deneyin: \n" + err, "HATA!");
            }
        }
    }
}
