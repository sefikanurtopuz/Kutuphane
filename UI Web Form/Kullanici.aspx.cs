using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI_Web_Form
{
    public partial class Kullanici : System.Web.UI.Page
    {
        //Global
        ogrenci ogrenci = new ogrenci();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //kullanici bilgilerinin yüklenmesi

            lblOgrenciId.Text = ((DataTable)Session["profile"]).Rows[0]["ogrno"].ToString();
            ogrenci.ogrno = int.Parse(lblOgrenciId.Text);

            DataTable dtOgrenci = ogrenci.ogrenciListele();

            txtKullaniciAdi.Text = dtOgrenci.Rows[0]["kullaniciadi"].ToString();
            txtSifre.Text = dtOgrenci.Rows[0]["sifre"].ToString();
            
        }

        protected void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                ogrenci.ogrno = int.Parse(lblOgrenciId.Text);
                ogrenci.kullaniciadi = txtKullaniciAdi.Text;
                ogrenci.sifre = txtSifre.Text;

                bool sonuc = ogrenci.kullaniciGuncelle();
                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla güncellenmiştir!";
                }
                else
                {
                    lblHata.Text = lblHata.Text + ogrenci.hataMesaji;
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }
        }
    }
}