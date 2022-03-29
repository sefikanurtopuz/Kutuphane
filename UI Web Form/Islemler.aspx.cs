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
    public partial class Islemler : System.Web.UI.Page
    {
        // Global
        islemler islem = new islemler();
        kitap kitap = new kitap();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //datagridin yüklenmesi
            islem.ogrno= int.Parse(((DataTable)Session["profile"]).Rows[0]["ogrno"].ToString());
            GridView1.DataSource =islem.islemListele();
            GridView1.DataBind();
            
            //ddl yüklenmesi
            ddlKitap.DataValueField = "Kitap No";
            ddlKitap.DataTextField = "Kitap Adı";
            ddlKitap.DataSource =kitap.kitapListele();
            ddlKitap.DataBind();
            ddlKitap.Items.Insert(0, new ListItem("Seçiniz...", "0"));

        }
    }
}