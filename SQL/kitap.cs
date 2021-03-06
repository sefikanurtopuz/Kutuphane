using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class kitap
    {
        public string kitapListele()
        {
            return "select k.kitapno [Kitap No], k.isbnno as ISBN, k.kitapadi [Kitap Adı], (y.yazarad+y.yazarsoyad) as Yazar, t.turadi as [Tür], k.sayfasayisi as [Sayfa Sayısı] from kitap as k inner join yazar as y on k.yazarno = y.yazarno inner join tur as t on k.turno = t.turno";
        }
        public string kitapEkle()
        {
            return "insert into kitap (isbnno,kitapadi, yazarno, turno, sayfasayisi) values (@isbn,@kitapadi,@yazarno,@turno,@sayfasayisi)";
        }
        public string kitapSec()
        {
            return "select * from kitap where kitapno=@kitapno";
        }
        public string kitapGuncelle()
        {
            return "update kitap set isbnno=@isbn, kitapadi=@kitapadi, yazarno=@yazarno, turno=@turno, sayfasayisi=@sayfasayisi where kitapno=@kitapno";
        }
        public string kitapSil()
        {
            return "delete from kitap where kitapno=@kitapno";
        }
    }
}
