using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable turListele()
        {
            string hataMesaji = "";
            DataTable dtTur = new DataTable();
            dtTur = exec.executeDT(sql.turListele(), null, false, ref hataMesaji);
            return dtTur;
        }
    }
}
