using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ReadMore : System.Web.UI.Page
    {
        string a;
        protected void Page_Load(object sender, EventArgs e)
        {
            a = Request.QueryString["Id"];
            if (String.IsNullOrEmpty(a))
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                GetContent(a);
            }      
        }
        void GetContent(String id) 
        {
            DatabaseMethods db = new DatabaseMethods();
            db.OpenConnection();
            //rpt_Icerik.DataSource = db.GetDataReader("Select Baslik , Icerik from Makale Where MakaleId =" + a);
            rpt_Icerik.DataSource = db.GetDataTable("Select Baslik , Icerik from Makale Where MakaleId =" + a);
            rpt_Icerik.DataBind();
            db.OpenConnection().Close();
        }
    }
}