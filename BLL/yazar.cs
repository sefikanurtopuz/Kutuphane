using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class yazar
    {
        //Global
        DAL.Execute exec = new DAL.Execute();
        SQL.yazar sql = new SQL.yazar();
        //Properties
        public int yazarno { get; set; }
        public string yazarad { get; set; }
        public string yazarsoyad { get; set; }

        public string hataMesaji = "";

        public DataTable yazarListele()
        {
            string hataMesaji = "";
            DataTable dtYazar = new DataTable();
            dtYazar = exec.executeDT(sql.yazarListele(), null, false, ref hataMesaji);
            return dtYazar;
        }
        public DataTable yazarListesi()
        {
            string hataMesaji = "";
            DataTable dtYazar = new DataTable();
            dtYazar = exec.executeDT(sql.yazarListesi(), null, false, ref hataMesaji);
            return dtYazar;
        }
        public DataTable yazarSec()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@yazarno", yazarno));
            DataTable dtYazar = new DataTable();
            dtYazar = exec.executeDT(sql.yazarSec(), _params.ToArray(), false, ref hataMesaji);
            return dtYazar;
        }
        public bool yazarEkle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@yazarad", yazarad));
            _params.Add(new SqlParameter("@yazarsoyad", yazarsoyad));

            result = exec.execute(sql.yazarEkle(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
        public bool yazarGuncelle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@yazarno", yazarno));
            _params.Add(new SqlParameter("@yazarad", yazarad));
            _params.Add(new SqlParameter("@yazarsoyad", yazarsoyad));

            result = exec.execute(sql.yazarGuncelle(), _params.ToArray(), false, ref hataMesaji);

            return result;

        }
        public bool yazarSil()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@yazarno", yazarno));

            result = exec.execute(sql.yazarSil(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
    }
}
