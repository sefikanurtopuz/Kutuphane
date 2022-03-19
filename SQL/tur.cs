using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class tur
    {
        public string turListele()
        {
            return "select turno as [Kategori No], turadi as [Kategori Adı]   from tur";
        }
        public string turSec()
        {
            return "select * from tur where turno=@turno";
        }
        public string turEkle()
        {
            return "insert into tur (turadi) values (@turadi)";
        }
        public string turGuncelle()
        {
            return "update tur set turadi=@turadi  where turno=@turno";
        }
        public string turSil()
        {
            return "delete from tur where turno=@turno";
        }
    }
}
