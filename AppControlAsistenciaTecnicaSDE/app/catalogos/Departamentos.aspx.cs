using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class catalogos_Departamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE DEPARTAMENTOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Departamentos del país";
        }
        catch (Exception ex )
        {
        }
        MostrarListaDeDepartamentos();
    }
    protected void MostrarListaDeDepartamentos()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM adm_tc_Departamento";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvDepartamento.DataSource = te;
            }
            this.gvDepartamento.DataBind();

        }
        catch (Exception ex)
        {

        }
    }

}