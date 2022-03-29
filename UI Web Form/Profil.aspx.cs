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
    public partial class Profil : System.Web.UI.Page
    {
        //Global

        ogrenci ogrenci = new ogrenci();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //öğrenci bilgilerinin yüklenmesi

            lblOgrenciId.Text = ((DataTable)Session["profile"]).Rows[0]["ogrno"].ToString();
            txtAd.Text= ((DataTable)Session["profile"]).Rows[0]["ograd"].ToString();
            txtSoyad.Text = ((DataTable)Session["profile"]).Rows[0]["ogrsoyad"].ToString();
            txtCinsiyet.Text = ((DataTable)Session["profile"]).Rows[0]["cinsiyet"].ToString();
            txtDTarih.Text = ((DataTable)Session["profile"]).Rows[0]["dtarih"].ToString();
            txtSinif.Text= ((DataTable)Session["profile"]).Rows[0]["sinif"].ToString();
        }

        protected void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                ogrenci.ogrno = int.Parse(lblOgrenciId.Text);
                ogrenci.ograd = txtAd.Text;
                ogrenci.ogrsoyad = txtSoyad.Text;
                ogrenci.cinsiyet = txtCinsiyet.Text;
                ogrenci.dtarih = DateTime.Parse(txtDTarih.Text);
                ogrenci.sinif = txtSinif.Text;

                bool sonuc = ogrenci.ogrenciGuncelle();
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