using System;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;
using System.Web.UI;


public partial class catalogos_Financiador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE FINANCIADOR";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Financiador del prestamo";
        }
        catch (Exception ex )
        {
        }
        MostrarListaDeDeFinanciador();
    }
    protected void MostrarListaDeDeFinanciador()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM adm_tc_Financiador";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvFinanciador.DataSource = te;
            }
            this.gvFinanciador.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
     

    private void openWindow(string _windowName)
    {
        var _cs = Page.ClientScript;
        var ClientScript = String.Format("<script type=\"text/javascript\">window.open('{0}', 'Metas', ' width=800,height=400,menubar=no,Location=no,toolbar=no,resizable=1,scrollbars=1')</script>", _windowName);
        if (!_cs.IsStartupScriptRegistered("WOpen"))
        {
            _cs.RegisterStartupScript(typeof(Page), "WOpen", ClientScript);
        }
    }


    protected void gvFinanciador_SelectedIndexChanged(object sender, EventArgs e)
    {
        //comentariar esta sección de codigo si deseas que solamente seleccione.
        var Cod_Financiador = gvFinanciador.SelectedRow.Cells[3].Text;
        openWindow("FinanciadorMetas.aspx?Cod_Fianciador=" + Cod_Financiador);
    }
}