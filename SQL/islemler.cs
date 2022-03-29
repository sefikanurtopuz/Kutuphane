using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public  class islemler
    {
        public string islemListele()
        {
            return "select * from islem where ogrno=@ogrno";
        }
    }
}
