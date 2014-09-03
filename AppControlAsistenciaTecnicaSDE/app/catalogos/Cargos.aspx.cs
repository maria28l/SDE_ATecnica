using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class catalogos_Cargos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE CARGOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Cargos de Servicios de Desarrollo Empresarial";
        }
        catch (Exception ex)
        {
        }
        MostrarListaDeCargos();
    }
    protected void MostrarListaDeCargos()
    {
        try
        {
            var cmd = new SqlCommand();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM adm_tc_Cargo";
            cmd.CommandType = CommandType.Text;

            var da = new SqlDataAdapter(cmd);
            var te = new DataTable();
            da.Fill(te);

            this.gvCargos.DataSource = te;
            this.gvCargos.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
   
}