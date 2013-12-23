using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.General
{
    public partial class Tags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["Tag"]))
                {
                    Response.Redirect("WebForm1.aspx");
                }
                else
                {
                    string tag_id = Request.QueryString["Tag"];

                    PagedDataSource pds = new PagedDataSource();
                    DataTable dt1 = MakaleOzetGetir(tag_id);
                    pds.DataSource = dt1.DefaultView;
                    pds.AllowPaging = true;
                    pds.PageSize = 4;
                    int currentPage;

                    if (Request.QueryString["page"] != null)
                    {
                        currentPage = Int32.Parse(Request.QueryString["page"]);
                    }
                    else
                    {
                        currentPage = 1;
                    }

                    pds.CurrentPageIndex = currentPage - 1;
                    lbl_paging.Text = "Page: " + currentPage + " / " + pds.PageCount;
                    Session["Comment_Page"] = currentPage.ToString();

                    if (!pds.IsFirstPage)
                    {
                        hl_Prev.NavigateUrl = "WebForm1.aspx?page=" + (currentPage - 1);
                    }

                    if (!pds.IsLastPage)
                    {
                        hl_Next.NavigateUrl = "WebForm1.aspx?page=" + (currentPage + 1);
                    }

                    rptMakaleOzet_Tag.DataSource = pds;
                    rptMakaleOzet_Tag.DataBind();
                }

            }
        }

        DataTable MakaleOzetGetir(string tag_id)
        {
            int tag_id_int = int.Parse(tag_id);
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataSet ds = db.GetDataset("SELECT m.MakaleId , m.Baslik , m.Tarih , m.Ozet , Count(y.MakaleID) as Yorum_Count , e.EtiketAd FROM Makale m LEFT JOIN Yorum y ON m.MakaleId = y.MakaleID , Etiket e , MakaleEtiket me WHERE m.MakaleId = me.MakaleId AND me.EtiketId = e.EtiketId AND e.EtiketId = " + tag_id_int +" GROUP BY m.MakaleID , Baslik , m.Tarih , Ozet , e.EtiketAd  ORDER BY m.Tarih DESC");
            rptMakaleOzet_Tag.DataSource = ds.Tables[0];
            rptMakaleOzet_Tag.DataBind();
            db.CloseConnection();
            return ds.Tables[0];
        }

    }
}