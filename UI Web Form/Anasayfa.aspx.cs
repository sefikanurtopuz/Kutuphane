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
    public partial class Anasayfa : System.Web.UI.Page
    {
        //Global
        kitap kitap = new kitap();
        yazar yazar = new yazar();
        tur tur = new tur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //datagridin yüklenmesi
            GridListele();

            //dropdownlist yazarın yüklenmesi
            ddlYazar.DataValueField = "yazarno";
            ddlYazar.DataTextField = "Yazar";
            ddlYazar.DataSource = yazar.yazarListele();
            ddlYazar.DataBind();
            ddlYazar.Items.Insert(0, new ListItem("Seçiniz...", "0"));


            //dropdownlist türün yüklenmesi
            ddlTur.DataValueField = "turno";
            ddlTur.DataTextField = "turadi";
            ddlTur.DataSource = tur.turListele();
            ddlTur.DataBind();
            ddlTur.Items.Insert(0, new ListItem("Seçiniz...", "0"));
        }

        protected void GridListele()
        {
            //datagridin yüklenmesi
            GridView1.DataSource = kitap.kitapListele();
            GridView1.DataBind();
        }
        protected void InputBosalt()
        {
            //inputların boşaltılması
            lblKitapId.Text = "";
            txtIsbn.Text = "";
            txtKitapAd.Text = "";
            ddlYazar.SelectedValue = "0";
            ddlTur.SelectedValue = "0";
            txtSayfa.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelBasari.Visible = false;
            PanelHata.Visible = false;

            kitap.kitapno= int.Parse(GridView1.SelectedRow.Cells[1].Text);

            DataTable dtKitap= kitap.kitapSec();

            lblKitapId.Text = dtKitap.Rows[0]["kitapno"].ToString();
            txtIsbn.Text = dtKitap.Rows[0]["isbnno"].ToString();
            txtKitapAd.Text = dtKitap.Rows[0]["kitapadi"].ToString();
            ddlYazar.SelectedValue = dtKitap.Rows[0]["yazarno"].ToString();
            ddlTur.SelectedValue = dtKitap.Rows[0]["turno"].ToString();
            txtSayfa.Text = dtKitap.Rows[0]["sayfasayisi"].ToString();
        }

        protected void btnKitapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                kitap.isbn = txtIsbn.Text;
                kitap.kitapadi = txtKitapAd.Text;
                kitap.yazar = ddlYazar.SelectedValue;
                kitap.tur = ddlTur.SelectedValue;
                kitap.sayfasayisi = int.Parse(txtSayfa.Text);

                bool sonuc = kitap.kitapEkle();
                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla kaydedilmiştir!";

                    GridListele();
                    InputBosalt();
                }
                else
                {
                    lblHata.Text = lblHata.Text + kitap.hataMesaji;
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }       
        }

        protected void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                kitap.kitapno = int.Parse(lblKitapId.Text);
                kitap.isbn = txtIsbn.Text;
                kitap.kitapadi = txtKitapAd.Text;
                kitap.yazar = ddlYazar.SelectedValue;
                kitap.tur = ddlTur.SelectedValue;
                kitap.sayfasayisi = int.Parse(txtSayfa.Text);

                bool sonuc = kitap.kitapGuncelle();
                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla güncellenmiştir!";
                    GridListele();
                    InputBosalt();
                }
                else
                {
                    lblHata.Text = lblHata.Text + kitap.hataMesaji;
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }
        }

        protected void btnKitapSil_Click(object sender, EventArgs e)
        {
            try
            {
                kitap.kitapno = int.Parse(lblKitapId.Text);

                bool sonuc = kitap.kitapSil();
                // Silmek istediğinize emin misiniz alert eklenecek
                // eğer evet derse aşağıdaki if çalışacak

                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla silinmiştir!";
                    GridListele();
                    InputBosalt();
                }
                else
                {
                    lblHata.Text = lblHata.Text + kitap.hataMesaji;
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