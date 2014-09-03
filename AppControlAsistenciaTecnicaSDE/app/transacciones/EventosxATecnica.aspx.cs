using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;
using NitlapanTic.Sdeat.transacciones;

public partial class transacciones_EventosxATecnica : System.Web.UI.Page
{
    protected int CodATecnica;
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    //var ctl = this.Master.FindControl("page_title");
        //    //((HtmlGenericControl)ctl).InnerText = "EVENTOS PROGRAMADOS";
        //    //ctl = this.Master.FindControl("page_description");
        //    //((HtmlGenericControl)ctl).InnerText = "Programación de Eventos x Asistencia Técnica";
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}

        //if (!IsPostBack)
        //
        //    LlenarListadoDeFacilitador();
        //}
        if (!String.IsNullOrEmpty((Request.QueryString["Cod_ATecnica"])))
        {
            CodATecnica = Convert.ToInt32(Request.QueryString["Cod_ATecnica"]);
            hfCodATecnica.Value = CodATecnica.ToString();
            LlenarListadoDeTipoEventoxConv(CodATecnica);
            MostrarListaDeEventosProgramados(CodATecnica);
        }
        //MostrarListaDeEventosProgramados();
    }

    protected void MostrarListaDeEventosProgramados(int c_at)
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                //cmd.CommandText = "SELECT * FROM ast_tt_Eventos_AT where Cod_ATecnica = " + c_at;
                cmd.CommandText="SELECT ast_tt_Eventos_AT.*, adm_tc_TipoEvento.Des_TipoEvento " +
                    "FROM ast_tt_Eventos_AT INNER JOIN adm_tc_TipoEvento ON dbo.ast_tt_Eventos_AT.Cod_Empresa = " +
                    "adm_tc_TipoEvento.Cod_Empresa AND ast_tt_Eventos_AT.Cod_TipoEvento = adm_tc_TipoEvento.Cod_TipoEvento " +
                    "WHERE Cod_ATecnica = " + c_at + " ORDER BY ast_tt_Eventos_AT.Fec_Programada";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvEventosProgramados.DataSource = te;
            }
            this.gvEventosProgramados.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void LlenarListadoDeTipoEvento()
    //{
    //    var df = new DataTable();
    //    df = EventosxATecnica.Obtener_TablaTipoEventoParaDdl();
    //    ddlTipoEvento_ep.Items.Clear();
    //    if (df.Rows.Count > 0)
    //    {
    //        ddlTipoEvento_ep.DataSource = df;
    //        ddlTipoEvento_ep.DataValueField = "Cod_TipoEvento";
    //        ddlTipoEvento_ep.DataTextField = "Des_TipoEvento";
    //        ddlTipoEvento_ep.DataBind();
    //    }
    //}

    protected void LlenarListadoDeTipoEventoxConv(int cat)
    {
        var df = new DataTable();
        df = EventosxATecnica.Obtener_TablaTipoEventoxConvParaDdl(cat);
        ddlTipoEvento_ep.Items.Clear();
        if (df.Rows.Count > 0)
        {
            ddlTipoEvento_ep.DataSource = df;
            ddlTipoEvento_ep.DataValueField = "Cod_TipoEvento";
            ddlTipoEvento_ep.DataTextField = "Des_TipoEvento";
            ddlTipoEvento_ep.DataBind();
        }
    }
    protected void btnActualizar_ep_Click(object sender, EventArgs e)
    {
        MostrarListaDeEventosProgramados(CodATecnica);
    }

    protected void gvEventosProgramados_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvEventosProgramados.PageIndex = e.NewPageIndex;
        MostrarListaDeEventosProgramados(CodATecnica);
    }
}