using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KategoriveEtiketleriGetir();

            if (Session["Login"] == null)
            {
                lb_Login.Text = "Log in";
            }
            else if (Session["Login"].ToString() == "0")
            {
                lb_Login.Text = "Log in";
            }
            else
            {
                lb_Login.Text = "Log out";
                if (Session["Admin"].ToString() == "True")
                {
                    lb_Admin.Visible = true;
                }
            }


        }
        void KategoriveEtiketleriGetir()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select KategoriAd + ' ('+ Convert(nvarchar ,  Count(Makale.KategoriID)) + ')' as KategoriAdı , Makale.KategoriID from Makale RIGHT JOIN Kategori ON Kategori.KategoriID = Makale.KategoriID Group by Makale.KategoriID , KategoriAd , Sıra Order by Sıra ; Select Etiket.EtiketId , Etiket.EtiketAd + ' ('+ Convert(nvarchar ,  Count(MakaleEtiket.EtiketId)) + ')' as EtiketAdı from Etiket LEFT JOIN MakaleEtiket ON Etiket.EtiketId = MakaleEtiket.EtiketId Group by Etiket.EtiketId , Etiket.EtiketAd;", cnn);
            cnn.Open();
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            rptKategori.DataSource = ds.Tables[0];
            rptEtiket.DataSource = ds.Tables[1];
            rptKategori.DataBind();
            rptEtiket.DataBind();
            cnn.Close();

            //Select KategoriAd + ' ('+ Convert(nvarchar ,  Count(Makale.KategoriID)) + ')' as KategoriAdı from Makale RIGHT JOIN Kategori ON Kategori.KategoriID = Makale.MakaleId Group by Makale.KategoriID , KategoriAd , Sıra Order by Sıra
        }

        protected void lb_Login_Click(object sender, EventArgs e)
        {
            if (lb_Login.Text == "Log in")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Remove("Login");
                Session.Remove("Admin");
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}