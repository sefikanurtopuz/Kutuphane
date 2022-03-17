using BLL;
using System;
using System.Collections.Generic;
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelBasari.Visible = false;
            PanelHata.Visible = false;

            lblKitapId.Text= GridView1.SelectedRow.Cells[1].Text;
            txtIsbn.Text = GridView1.SelectedRow.Cells[2].Text;
            txtKitapAd.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text);
            ddlYazar.SelectedValue = "5";
            ddlTur.SelectedItem.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
            txtSayfa.Text = GridView1.SelectedRow.Cells[6].Text;

            kitap.yazar = ddlYazar.SelectedItem.Value;
            kitap.tur = ddlTur.SelectedItem.Value;
        }

        protected void btnKitapEkle_Click(object sender, EventArgs e)
        {
            kitap.isbn=txtIsbn.Text;
            kitap.kitapadi=txtKitapAd.Text;
            kitap.yazar = ddlYazar.SelectedValue;
            kitap.tur= ddlTur.SelectedValue;
            kitap.sayfasayisi = int.Parse(txtSayfa.Text);

            bool sonuc = kitap.kitapEkle();
            if (sonuc == true)
            {
                PanelBasari.Visible = true;
                GridListele();
            }
            else
            {
                lblHata.Text = lblHata.Text + kitap.hataMesaji;
                PanelHata.Visible = true;
            }
        }
    }
}