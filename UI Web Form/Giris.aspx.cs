using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI_Web_Form
{
    public partial class Giris : System.Web.UI.Page
    {
        //Global
        ogrenci ogrenci = new ogrenci();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //kontroller temizleniyor
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Focus();
        }
        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            ogrenci.kullaniciadi = txtKullaniciAdi.Text;
            ogrenci.sifre = txtSifre.Text;
            DataTable dtOgrenci = ogrenci.ogrenciGiris();

            if (dtOgrenci.Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(ogrenci.kullaniciadi, false);
                Session["profile"]=dtOgrenci;
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                lblHata.Text = lblHata.Text + ogrenci.hataMesaji;
                PanelHata.Visible = true;
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                txtKullaniciAdi.Focus();
            }

        }
    }
}