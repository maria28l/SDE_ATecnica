using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class catalogos_Empleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE EMPLEADOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Técnicos de campo";
        }
        catch (Exception ex)
        {
        }
        MostrarListaDeEmmpleados();
    }
    protected void MostrarListaDeEmmpleados()
    {
        try
        {
            var cmd = new SqlCommand();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT	e.IdEmpleado,	e.PNombre [Primer Nombre],	e.SNombre [Segundo Nombre],	e.PApellido [Primer Apellido],	e.SApellido [Segundo Apellido] FROM	Empleado e";
            cmd.CommandType = CommandType.Text;

            var da = new SqlDataAdapter(cmd);
            var te = new DataTable();
            da.Fill(te);

            this.gvEmpleados.DataSource = te;
            this.gvEmpleados.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
}