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
    public partial class Yazar : System.Web.UI.Page
    {
        //Global
        yazar yazar = new yazar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            //datagridin yüklenmesi
            GridListele();

        }
        protected void GridListele()
        {
            //datagridin yüklenmesi
            GridView1.DataSource = yazar.yazarListesi();
            GridView1.DataBind();
        }
        protected void InputBosalt()
        {
            //inputların boşaltılması
            lblYazarId.Text = "";
            txtYazarAd.Text = "";
            txtYazarSoyad.Text = "";

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelBasari.Visible = false;
            PanelHata.Visible = false;

            yazar.yazarno = int.Parse(GridView1.SelectedRow.Cells[1].Text);

            DataTable dtYazar = yazar.yazarSec();

            lblYazarId.Text = dtYazar.Rows[0]["yazarno"].ToString();
            txtYazarAd.Text = dtYazar.Rows[0]["yazarad"].ToString();
            txtYazarSoyad.Text = dtYazar.Rows[0]["yazarsoyad"].ToString();
            
        }
        protected void btnYazarEkle_Click(object sender, EventArgs e)
        {
            try
            {
                yazar.yazarad = txtYazarAd.Text;
                yazar.yazarsoyad = txtYazarSoyad.Text;

                
                if (txtYazarAd.Text !="" && txtYazarSoyad.Text !="")
                {
                    bool sonuc = yazar.yazarEkle();
                    if (sonuc == true)
                    {
                        PanelBasari.Visible = true;
                        lblBasarili.Text = "Başarıyla kaydedilmiştir!";

                        GridListele();
                        InputBosalt();
                    }
                    else
                    {
                        lblHata.Text = lblHata.Text + yazar.hataMesaji;
                        PanelHata.Visible = true;
                    }    
                }
                else
                {
                    lblHata.Text = lblHata.Text + yazar.hataMesaji + "Yazar Adı Soyadı boş bırakılamaz!";
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }

        }
        protected void btnYazarGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                yazar.yazarno = int.Parse(lblYazarId.Text);
                yazar.yazarad = txtYazarAd.Text;
                yazar.yazarsoyad = txtYazarSoyad.Text;

                bool sonuc = yazar.yazarGuncelle();
                if (sonuc == true)
                {
                    PanelBasari.Visible = true;
                    lblBasarili.Text = "Başarıyla güncellenmiştir!";
                    GridListele();
                    InputBosalt();
                }
                else
                {
                    lblHata.Text = lblHata.Text + yazar.hataMesaji;
                    PanelHata.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblHata.Text = lblHata.Text + " " + ex.Message;
                PanelHata.Visible = true;
            }
        }
        protected void btnYazarSil_Click(object sender, EventArgs e)
        {
            try
            {
                yazar.yazarno = int.Parse(lblYazarId.Text);

                bool sonuc = yazar.yazarSil();
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
                    lblHata.Text = lblHata.Text + yazar.hataMesaji;
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