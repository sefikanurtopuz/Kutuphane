using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class islemler
    {
        //Global
        DAL.Execute exec = new DAL.Execute();
        SQL.islemler sql = new SQL.islemler();

        public int islemno { get; set; }
        public int ogrno { get; set; }
        public int kitapno { get; set; }
        public DateTime atarih { get; set; }
        public DateTime vtarih { get; set; }

        public string hataMesaji = "";

        public DataTable islemListele()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@ogrno", ogrno));

            DataTable dtIslem = new DataTable();
            dtIslem = exec.executeDT(sql.islemListele(), _params.ToArray(), false, ref hataMesaji);

            return dtIslem;
        }
    }
}
