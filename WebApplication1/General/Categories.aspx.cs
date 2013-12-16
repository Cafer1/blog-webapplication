using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.General
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                if (string.IsNullOrEmpty(Request.QueryString["Category"]))
                {
                    Response.Redirect("WebForm1.aspx");
                }
                else 
                {
                    string category_id = Request.QueryString["Category"];

                    PagedDataSource pds = new PagedDataSource();
                    DataTable dt1 = MakaleOzetGetir(category_id);
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

                    rptMakaleOzet_Category.DataSource = pds;
                    rptMakaleOzet_Category.DataBind();


                }
                
            }
        }

        DataTable MakaleOzetGetir(string category_id)
        {
            int category_id_int = int.Parse(category_id);
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataSet ds = db.GetDataset("SELECT m.MakaleId , m.Baslik , m.Tarih , m.Ozet , Count(y.MakaleID) as Yorum_Count FROM Makale m LEFT JOIN Yorum y ON m.MakaleId = y.MakaleID WHERE m.KategoriID = " + category_id_int + " GROUP BY m.MakaleId , Baslik , m.Tarih , Ozet ORDER BY m.Tarih DESC");
            rptMakaleOzet_Category.DataSource = ds.Tables[0];
            rptMakaleOzet_Category.DataBind();
            return ds.Tables[0];
        }
    }
}