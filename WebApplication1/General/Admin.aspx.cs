using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.General
{
    public partial class Admin : System.Web.UI.Page
    {

        DatabaseMethods db;
        Dictionary<int, string> Tags = new Dictionary<int, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null) 
            {
                if (Convert.ToBoolean(Session["Admin"]))
                {
                    if (!Page.IsPostBack)
                    {
                        if (lb_Tags.Items.Count == 0)
                        {
                            db = new DatabaseMethods();

                            DataSet ds = db.GetDataset("Select * From Etiket");
                            lb_Tags.DataSource = ds;
                            lb_Tags.DataTextField = "EtiketAd";
                            lb_Tags.DataValueField = "EtiketId";
                            lb_Tags.DataBind();
                            ds.Clear();

                            ds = db.GetDataset("Select KategoriID , KategoriAd From Kategori");
                            ddl_Category.DataSource = ds;
                            ddl_Category.DataTextField = "KategoriAd";
                            ddl_Category.DataValueField = "KategoriID";
                            ddl_Category.DataBind();
                            ds.Clear();
                        }
                    }
                }
                else
                {
                    Response.Redirect("WebForm1.aspx");
                }
            }
            else
            {
                Response.Redirect("WebForm1.aspx");
            }
        }

        protected void btn_Submit_Click(object sender, ImageClickEventArgs e)
        {
            db = new DatabaseMethods();
            int a = db.InsertWithLastId("Insert into Makale (Baslik , Tarih , Icerik , KategoriID , Ozet) values ( '" + txt_Title.Text + "' , GETDATE() , '" + txt_main.Text + "' , " + ddl_Category.SelectedItem.Value + " , '" + txt_abstract.Text + "'); SELECT SCOPE_IDENTITY() as LastInsertedId;");
            foreach (ListItem item in lb_Selected.Items)
            {
                db.Insert("Insert into MakaleEtiket values(" + a + "," + item.Value + ")");
            }
            //Response.Redirect("Admin.aspx");

        }

        protected void btn_right_Click(object sender, EventArgs e)
        {
            ListItem li = new ListItem();
            li.Value = lb_Tags.SelectedItem.Value;
            li.Text = lb_Tags.SelectedItem.Text;
            lb_Selected.Items.Add(li);
            int i = 0;
            i = lb_Tags.SelectedIndex;
            lb_Tags.Items.RemoveAt(i);

        }

        protected void btn_left_Click(object sender, EventArgs e)
        {

            ListItem li = new ListItem();
            li.Value = lb_Selected.SelectedItem.Value;
            li.Text = lb_Selected.SelectedItem.Text;
            lb_Tags.Items.Add(li);
            int i = 0;
            i = lb_Selected.SelectedIndex;
            lb_Selected.Items.RemoveAt(i);
        }

    }
}