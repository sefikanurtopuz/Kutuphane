using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Execute
    {
        //connection string global sabit olarak tanimlandi (user/windows auth.)
        public const string _cs = @"Server=Z36-11\SQLEXPRESS;Database=SP501Kutuphane;User Id=sa;Password=12345678;";

        public DataTable executeDT(string _sql, SqlParameter[] _params, bool isProcedure, ref string _exceptionMessage)
        {
            //return edilecek degisken olusturuluyor
            DataTable dtResult = new DataTable();

            //hata mesaji degiskeni bosaltiliyor
            _exceptionMessage = "";

            try
            {
                //server baglanti satiri
                SqlConnection _con = new SqlConnection(_cs);

                //server da isletiecek sql metni
                SqlCommand _cmd = new SqlCommand(_sql, _con);

                //sql parameters dolu ise command veriliyor
                if (_params != null) _cmd.Parameters.AddRange(_params);

                //procedure kontrolu
                if (isProcedure == true) _cmd.CommandType = CommandType.StoredProcedure;

                //veriyi aktarma (adapter)
                SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);

                //adapter kullanilarak veri DT' a dolduruluyor
                _adapter.Fill(dtResult);
            }
            catch (Exception ex)
            {
                dtResult = null;
                _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
            }

            //return data
            return dtResult;
        }

        /// <summary>
        /// CRUD işlemlerinden Create, Update, Delete işlemi için kodlanmıştır.
        /// </summary>
        /// <param name="_sql">Çalıştırılacak olan sorgu cümlesidir.</param>
        /// <param name="_exceptionMessage">Hatanın okunacağı değişkendir.</param>
        /// <returns></returns>
        public bool execute(string _sql, SqlParameter[] _params, bool isProcedure, ref string _exceptionMessage)
        {
            //return edilecek degisken tanimlaniyor
            bool result = true;

            //hata mesaji bosaltiliyor
            _exceptionMessage = "";

            //server baglanti satiri
            SqlConnection _con = new SqlConnection(_cs);

            try
            {
                //connection aciliyor
                _con.Open();

                //server da isletiecek sql metni
                SqlCommand _cmd = new SqlCommand(_sql, _con);

                //sql parameters null degilse command e ekleniyor
                if (_params != null) _cmd.Parameters.AddRange(_params);

                //procedure ise
                if (isProcedure == true) _cmd.CommandType = CommandType.StoredProcedure;

                //sql metnini calistirma
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                _exceptionMessage = "Bir hata oluştu. Lütfen sistem yöneticinize haber veriniz! \n [ " + ex.Message + " ]";
            }
            finally
            {
                //connection kapatiliyor
                _con.Close();
            }

            //return
            return result;
        }
    }
}
