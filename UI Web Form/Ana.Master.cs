using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI_Web_Form
{
    public partial class Ana : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            lblProfil.Text =((DataTable)Session["profil"]).Rows[0]["ograd"].ToString();
        }
    }
}