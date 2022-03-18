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
        public string yazarListesi()
        {
            return "select yazarno as [Yazar No], yazarad as [Yazar Adı], yazarsoyad as [Yazar Soyadı] from yazar";
        }
        public string yazarSec()
        {
            return "select * from yazar where yazarno=@yazarno";
        }
        public string yazarEkle()
        {
            return "insert into yazar (yazarad,yazarsoyad) values (@yazarad,@yazarsoyad)";
        }
        public string yazarGuncelle()
        {
            return "update yazar set yazarad=@yazarad, yazarsoyad=@yazarsoyad where yazarno=@yazarno";
        }
        public string yazarSil()
        {
            return "delete from yazar where yazarno=@yazarno";
        }
    }
}
