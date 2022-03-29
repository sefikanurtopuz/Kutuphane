using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ogrenci
    {
        //Globals
        DAL.Execute exec = new DAL.Execute();
        SQL.ogrenci sql = new SQL.ogrenci();

        //Properties
        public int ogrno { get; set; }
        public string ograd { get; set; }
        public string ogrsoyad { get; set; }
        public string cinsiyet { get; set; }
        public DateTime dtarih { get; set; }
        public string sinif { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }

        public string hataMesaji = "";

        public DataTable ogrenciGiris()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullaniciadi", kullaniciadi));
            _params.Add(new SqlParameter("@sifre", sifre));

            DataTable dtOgrenci = new DataTable();
            dtOgrenci = exec.executeDT(sql.ogrenciGiris(), _params.ToArray(), false, ref hataMesaji);

            return dtOgrenci;
        }
        public bool ogrenciGuncelle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@ogrno", ogrno));
            _params.Add(new SqlParameter("@ograd", ograd));
            _params.Add(new SqlParameter("@ogrsoyad", ogrsoyad));
            _params.Add(new SqlParameter("@cinsiyet", cinsiyet));
            _params.Add(new SqlParameter("@dtarih", dtarih));
            _params.Add(new SqlParameter("@sinif", sinif));

            result = exec.execute(sql.ogrenciGuncelle(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
    }
}
