using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        DatabaseMethods db;

        protected void Page_Load(object sender, EventArgs e)
        {

            db = new DatabaseMethods();

            if (Session["Login"] == null)
            {
                if (db.OpenConnection() != null)
                {
                    lbl_Error.Visible = false;
                }
                else
                {
                    lbl_Error.Visible = true;
                    lbl_Error.Text = "SQL Connection Error";
                }
            }
            else
            {
                if (Session["Login"].ToString() != "1")
                {
                    lbl_Error.Visible = true;
                    lbl_Error.Text = "Session State Error";

                }
                else
                {
                    Response.Redirect("WebForm1.aspx");
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            DataTable dt = db.GetDataTable("Select * from Users Where User_Name = '"+ txtUserId.Text +"' and Password = '" + txt_Password.Text +"'" );

            
            try 
            {
                if (dt.Rows.Count == 0)
                {
                    this.lbl_Error.Text = "Login Error !";
                    this.lbl_Error.Visible = true;
                }
                else
                {
                    Session["User_id"] = dt.Rows[0]["User_Id"].ToString();
                    Session["Login"] = "1";
                    Session["Admin"] = dt.Rows[0]["Is_Admin"].ToString();
                    Response.Redirect("WebForm1.aspx");
                }
            }
            catch(SqlException ex)
            {
                lbl_Error.Text = ex.StackTrace.ToString();
            }
        }
    }
}