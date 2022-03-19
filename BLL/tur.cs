using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class tur
    {
        //Global
        DAL.Execute exec = new DAL.Execute();
        SQL.tur sql = new SQL.tur();

        //Properties
        public int turno { get; set; }
        public string turadi { get; set; }

        public string hataMesaji = "";

        public DataTable turListele()
        {
            string hataMesaji = "";
            DataTable dtTur = new DataTable();
            dtTur = exec.executeDT(sql.turListele(), null, false, ref hataMesaji);
            return dtTur;
        }
        public DataTable turSec()
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@turno", turno));
            DataTable dtTur = new DataTable();
            dtTur = exec.executeDT(sql.turSec(), _params.ToArray(), false, ref hataMesaji);
            return dtTur;
        }
        public bool turEkle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@turadi", turadi));

            result = exec.execute(sql.turEkle(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
        public bool turGuncelle()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@turno", turno));
            _params.Add(new SqlParameter("@turadi", turadi));

            result = exec.execute(sql.turGuncelle(), _params.ToArray(), false, ref hataMesaji);

            return result;

        }
        public bool turSil()
        {
            bool result = false;

            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@turno", turno));

            result = exec.execute(sql.turSil(), _params.ToArray(), false, ref hataMesaji);

            return result;
        }
    }
}
