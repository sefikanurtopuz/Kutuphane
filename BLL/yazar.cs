using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable yazarListele()
        {
            string hataMesaji = "";
            DataTable dtYazar = new DataTable();
            dtYazar = exec.executeDT(sql.yazarListele(), null, false, ref hataMesaji);
            return dtYazar;
        }

    }
}
