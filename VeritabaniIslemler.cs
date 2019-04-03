using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace sp
{
    class VeritabaniIslemler
    {
        public static string ConnectionString()
        {

            return "server=remotemysql.com; database= tDNQ1XRXlu; uid=tDNQ1XRXlu; pwd=F44eHROJZ1;";

            //return "server=localhost; database=sp_test; uid=root; pwd=root;";
        }


        private MySqlConnection bag = new MySqlConnection(ConnectionString()); // tekrar tekrar tanımlamamak için dışarı tanımladık
        private MySqlCommand kmt; // tekrar tekrar tanımlamamak için dışarı tanımladık
        private MySqlDataAdapter adp; // tekrar tekrar tanımlamamak için dışarı tanımladık
        private MySqlDataReader dr; // sorgu methodu için tablo okumaya yarayan class
        private DataTable dt = new DataTable(); //Veritabanından çekilen tablo verileri öncelikle buradaki tabloya aktarılıyor ve ardından methodun çağırıldığı yerdeki tabloya bunun içinden veri gönderiliyor


        public DataTable Al(string komut)
        {
            dt = new DataTable();
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
        public MySqlDataReader Oku(string komut)
        {
            Kapat();
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
