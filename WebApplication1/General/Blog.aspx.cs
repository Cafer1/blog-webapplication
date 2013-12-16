using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.General
{
    public partial class Blog : System.Web.UI.Page
    {
        string makale_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            makale_id = Request.QueryString["Id"];
            if (String.IsNullOrEmpty(makale_id))
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                GetContent(makale_id);
                GetTags(makale_id);

                PagedDataSource pds = new PagedDataSource();
                DataTable dt1 = GetComments(makale_id);
                pds.DataSource = dt1.DefaultView;
                pds.AllowPaging = true;
                pds.PageSize = 5;
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
                    hl_Prev.NavigateUrl = "Blog.aspx?id=" + makale_id + "&page=" + (currentPage - 1);
                }

                if (!pds.IsLastPage)
                {
                    hl_Next.NavigateUrl = "Blog.aspx?id=" + makale_id + "&page=" + (currentPage + 1);
                }

                lbl_Comment_Count.Text = GetCommentCount() + " Responses";
                rpt_Comment.DataSource = pds;
                rpt_Comment.DataBind();

            }
            if (Session["Login"] == null)
            {
                pnl_Comment.Visible = false;
            }


        }

        void GetTags(String id)
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataTable dt = db.GetDataTable("SELECT e.EtiketAd FROM Makale m , MakaleEtiket me , Etiket e WHERE me.MakaleId = m.MakaleId AND me.EtiketId = e.EtiketId AND m.MakaleId = " + makale_id);
            dl_Tags.DataSource = dt;
            dl_Tags.DataBind();
            db.OpenConnection().Close();
        }

        string GetCommentCount() 
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataTable dt = db.GetDataTable("Select COUNT(y.MakaleID) as Comment_Count from Yorum y where y.MakaleID = " + makale_id);
            db.OpenConnection().Close();
            return dt.Rows[0]["Comment_Count"].ToString();  
        }

        void GetContent(String id)
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataTable dt = db.GetDataTable("Select * from Makale Where MakaleId =" + makale_id);
            rpt_Makale.DataSource = dt;
            rpt_Makale.DataBind();
            db.OpenConnection().Close();
        }

        DataTable GetComments(String id)
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataTable dt = db.GetDataTable("Select y.YorumId ,  y.YorumIcerik , y.MakaleID , y.Tarih , y.Onay , u.Name from Yorum y , Users u where y.User_id = u.User_Id and y.MakaleId=" + makale_id);
            rpt_Comment.DataSource = dt;
            rpt_Comment.DataBind();
            db.OpenConnection().Close();
            return dt;
        }

        protected void btn_Comment_Click(object sender, ImageClickEventArgs e)
        {
            string yorum = txt_Comment.Text;
            string user_id = Session["User_id"].ToString();
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            db.Insert("Insert into Yorum (YorumIcerik , MakaleID , User_id , Tarih ) values ('" + yorum + "'," + makale_id + "," + user_id + ",GETDATE())");
            txt_Comment.Text = "";
            Response.Redirect("Blog.aspx?id="+makale_id+"&page="+Session["Comment_Page"].ToString());
        }
    }
}