using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class kitap
    {
        //Global
        DAL.Execute exec = new DAL.Execute();
        SQL.kitap sql = new SQL.kitap();

        //Properties
        public int kitapno { get; set; }
        public string isbn { get; set; }
        public string kitapadi  { get; set; }
        public string yazar { get; set; }
        public string tur { get; set; }
        public int sayfasayisi { get; set; }

        public string hataMesaji = "";

        public DataTable kitapListele()
        {
            DataTable dtKitaps = new DataTable();
            dtKitaps = exec.executeDT(sql.kitapListele(), null, false, ref hataMesaji);
            return dtKitaps;
        }
        public bool kitapEkle()
        {
            bool result= false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@isbn", isbn));
            _params.Add(new SqlParameter("@kitapadi", kitapadi));
            _params.Add(new SqlParameter("@yazarno", yazar));
            _params.Add(new SqlParameter("@turno", tur));
            _params.Add(new SqlParameter("@sayfasayisi", sayfasayisi));

            result=exec.execute(sql.kitapEkle(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
        public DataTable kitapSec()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kitapno", kitapno));
            DataTable dtKitap = new DataTable();
            dtKitap = exec.executeDT(sql.kitapSec(), _params.ToArray(), false, ref hataMesaji);
            return dtKitap;
        }
        public bool kitapGuncelle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kitapno", kitapno));
            _params.Add(new SqlParameter("@isbn", isbn));
            _params.Add(new SqlParameter("@kitapadi", kitapadi));
            _params.Add(new SqlParameter("@yazarno", yazar));
            _params.Add(new SqlParameter("@turno", tur));
            _params.Add(new SqlParameter("@sayfasayisi", sayfasayisi));

            result = exec.execute(sql.kitapGuncelle(), _params.ToArray(), false, ref hataMesaji);

            return result;

        }
        public bool kitapSil()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kitapno", kitapno));

            result = exec.execute(sql.kitapSil(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
    }
}
