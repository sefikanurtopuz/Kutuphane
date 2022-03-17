using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class yazar
    {
        public string yazarListele()
        {
            return "select yazarno, (yazarad+yazarsoyad) as Yazar from yazar";
        }
    }
}
