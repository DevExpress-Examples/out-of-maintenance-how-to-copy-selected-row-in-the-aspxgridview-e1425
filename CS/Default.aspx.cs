using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication10
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["InitialData"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Data", typeof(string));
                for (int i = 0; i < 5; i++)
                {
                    dt.Rows.Add(new object[] { i, "Data_" + i.ToString() });
                    Session["InitialData"] = dt;
                }

            }

            if (Session["TargetData"] == null)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ID", typeof(int));
                dt1.Columns.Add("Data", typeof(string));
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt1.Columns["ID"];
                dt1.PrimaryKey = keys;


                Session["TargetData"] = dt1;

            }
            ASPxGridView1.DataSource = Session["InitialData"] as DataTable;
            ASPxGridView1.DataBind();

            ASPxGridView2.DataSource = Session["TargetData"] as DataTable;
            ASPxGridView2.DataBind();
        }

        protected void AddRow(DataRow row)
        {

            DataRow rw = (Session["TargetData"] as DataTable).NewRow();
            rw[0] = row[0];
            rw[1] = row[1];
            (Session["TargetData"] as DataTable).Rows.Add(rw);
            ASPxGridView2.DataBind();
        }
        protected void DeleteRow(DataRow row)
        {

            DataTable currentDT = Session["TargetData"] as DataTable;
            DataRow rw = currentDT.Rows.Find(row[0]);
            for (int i = 0; i < currentDT.Rows.Count; i++)
            {
                if (Convert.ToInt32(currentDT.Rows[i][0]) == Convert.ToInt32(row[0]))
                {
                    currentDT.Rows[i].Delete();
                    break;
                }
            }
            Session["TargetData"] = currentDT;

            ASPxGridView2.DataBind();

        }

        protected void ASPxCallbackPanel1_Callback(object source, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] pars = e.Parameter.Split(';');
            int index = Convert.ToInt32(pars[0]);
            if (pars[1] == "y")
            {

                AddRow(ASPxGridView1.GetDataRow(index));
            }
            if (pars[1] == "n")
            {

                DeleteRow(ASPxGridView1.GetDataRow(index));
            }

        }
    }
}

