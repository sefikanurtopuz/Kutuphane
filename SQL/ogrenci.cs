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
            return "select * from ogrenci where kullaniciadi = @kullaniciadi and sifre = @sifre;";
        }
        public string ogrenciGuncelle()
        {
            return "update ogrenci set ograd=@ograd, ogrsoyad=@ogrsoyad, cinsiyet=@cinsiyet, dtarih=@dtarih, sinif=@sinif where ogrno=@ogrno";
        }
        public string kullaniciGuncelle()
        {
            return "update ogrenci set kullaniciadi=@kullaniciadi, sifre=@sifre where ogrno=@ogrno";
        }
        public string ogrenciListele()
        {
            return "select * from ogrenci where ogrno=@ogrno";
        }
    }
}
