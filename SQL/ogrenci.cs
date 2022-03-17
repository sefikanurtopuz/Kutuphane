using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class ogrenci
    {
        public string ogrenciGiris()
        {
            return "select * from ogrenci where (kullaniciadi = @kullaniciadi and sifre = @sifre) or ogrno = @id;";
        }
    }
}
