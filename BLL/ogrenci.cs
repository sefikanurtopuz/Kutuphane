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
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }

        public void ara(ref string _hataMesaji)
        {
            //Parameters:
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullaniciadi", kullaniciadi));
            _params.Add(new SqlParameter("@sifresi", sifre));
            _params.Add(new SqlParameter("@id", ogrno));

            //database
            _hataMesaji = "";
            DataTable dtOgrenci = exec.executeDT(sql.ogrenciGiris(), _params.ToArray(), false, ref _hataMesaji);

            //class map
            if (_hataMesaji == "" && dtOgrenci != null && dtOgrenci.Rows.Count > 0)
            {
                ogrno = int.Parse(dtOgrenci.Rows[0]["ogrno"].ToString());
                ograd = dtOgrenci.Rows[0]["ograd"].ToString();
                ogrsoyad = dtOgrenci.Rows[0]["ogrsoyad"].ToString();
                kullaniciadi = dtOgrenci.Rows[0]["kullaniciadi"].ToString();
                sifre = dtOgrenci.Rows[0]["sifre"].ToString();
            }
            else
            {
                _hataMesaji = "Kullanıcı bilgisi alınamadı!";

                ogrno = 0;
                ograd = "";
                ogrsoyad = "";
                kullaniciadi = "";
                sifre = "";
            }
        }
    }
}
