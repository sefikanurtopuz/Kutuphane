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
    public partial class Kategori : System.Web.UI.Page
    {
        tur tur = new tur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //datagridin yüklenmesi
            GridListele();
        }
        protected void GridListele()
        {
            //datagridin yüklenmesi
            GridView1.DataSource =tur.turListele();
            GridView1.DataBind();
        }
        protected void InputBosalt()
        {
            //inputların boşaltılması
            lblKategoriId.Text = "";
            txtKategoriAd.Text = "";
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelBasari.Visible = false;
            PanelHata.Visible = false;

            tur.turno = int.Parse(GridView1.SelectedRow.Cells[1].Text);

            DataTable dtTur = tur.turSec();

            lblKategoriId.Text = dtTur.Rows[0]["turno"].ToString();
            txtKategoriAd.Text = dtTur.Rows[0]["turadi"].ToString();
        }
        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                tur.turadi = txtKategoriAd.Text;

                if (txtKategoriAd.Text != "")
                {
                    bool sonuc = tur.turEkle();
                    if (sonuc == true)
                    {
                        PanelBasari.Visible = true;
                        lblBasarili.Text = "Başarıyla kaydedilmiştir!";

                        GridListele();
                        InputBosalt();
                    }
                    else
                    {
                        lblHata.Text = lblHata.Text + tur.hataMesaji;
                        PanelHata.Visible = true;
                    }
                }
                else
                {
                    lblHata.Text = lblHata.Text + tur.hataMesaji + "Kategori adı boş bırakılamaz!";
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }
        }
        protected void btnKategoriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                tur.turno = int.Parse(lblKategoriId.Text);
                tur.turadi = txtKategoriAd.Text;

                bool sonuc = tur.turGuncelle();
                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla güncellenmiştir!";
                    GridListele();
                    InputBosalt();
                }
                else
                {
                    lblHata.Text = lblHata.Text + tur.hataMesaji;
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }
        }
        protected void btnKategoriSil_Click(object sender, EventArgs e)
        {
            try
            {
                tur.turno = int.Parse(lblKategoriId.Text);

                bool sonuc = tur.turSil();
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
                    lblHata.Text = lblHata.Text + tur.hataMesaji;
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