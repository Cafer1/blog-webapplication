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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PagedDataSource pds = new PagedDataSource();
                DataTable dt1 = MakaleOzetGetir();
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

                rptMakaleOzet.DataSource = pds;
                rptMakaleOzet.DataBind();
            }
        }

        DataTable MakaleOzetGetir()
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataSet ds = db.GetDataset("SELECT m.MakaleId , Baslik , m.Tarih , Ozet , Count(y.MakaleID) " +
                                                " as Yorum_Count FROM Makale m LEFT JOIN Yorum y " +
                                                "ON m.MakaleId = y.MakaleID GROUP BY m.MakaleId , Baslik , m.Tarih , Ozet" +
                                                " ORDER BY m.Tarih DESC");

            rptMakaleOzet.DataSource = ds.Tables[0];
            rptMakaleOzet.DataBind();
            return ds.Tables[0];
        }

        protected void rptMakaleOzet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataList dl1 = (DataList)e.Item.FindControl("dl_Tags");
            dl1.DataSource = db.GetDataTable("SELECT e.EtiketAd FROM Makale m , MakaleEtiket me , Etiket e WHERE me.MakaleId = m.MakaleId AND me.EtiketId = e.EtiketId AND m.MakaleId = " + DataBinder.Eval(e.Item.DataItem, "MakaleId").ToString());
            dl1.DataBind();
            db.OpenConnection().Close();
        }
    }
}