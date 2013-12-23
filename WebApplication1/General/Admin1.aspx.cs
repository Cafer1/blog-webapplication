using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.General
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //btn_Deneme2_External = GridViewComments.FindControl("btn_Deneme1") as Button;
                GetComments();
            }
        }

        DataTable GetComments()
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            DataTable dt = db.GetDataTable("Select * from Yorum");
            GridViewComments.DataSource = dt;
            GridViewComments.DataBind();
            db.CloseConnection();
            return dt;
        }

        protected void GridViewComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                ImageButton okBtn = (ImageButton)e.Row.Cells[6].FindControl("btn_Deneme1");
                ImageButton iptalBtn = (ImageButton)e.Row.Cells[6].FindControl("btn_Deneme2");
            }
        }

        protected void btn_Deneme1_Click(object sender, ImageClickEventArgs e)
        {
            decimal basID = Convert.ToDecimal((sender as ImageButton).CommandArgument);
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            db.Update("UPDATE Yorum SET Onay=1 WHERE YorumId = " + basID + ";");
            db.CloseConnection();
            //Response.Redirect("GridViewDeneme.aspx");
            GetComments();
        }

        protected void btn_Deneme2_Click(object sender, ImageClickEventArgs e)
        {
            decimal basID = Convert.ToDecimal((sender as ImageButton).CommandArgument);
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            db.Delete("Delete from Yorum Where YorumId = " + basID + ";");
            db.CloseConnection();
            //Response.Redirect("GridViewDeneme.aspx");
            GetComments();
        }

        protected void GridViewComments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewComments.PageIndex = e.NewPageIndex;
            GetComments();
        }
    }
}