using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;
using NitlapanTic.Sdeat.transacciones;

public partial class transacciones_EventosRealizados : System.Web.UI.Page
{
    //protected int CodEvento;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "EVENTOS REALIZADOS";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Eventos Realizados por Facilitadores";
        }
        catch (Exception ex)
        {
            throw ex;
        }
        if (!IsPostBack)
        {
            LlenarListadoDeTipoEvento();
            MostrarListaDeEventosARealizar();
        }

    }

    protected void MostrarListaDeEventosARealizar()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var elUsuario = Session["login"].ToString();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT dbo.v_Prox_Evento_a_Realizar.Cod_Empresa, dbo.v_Prox_Evento_a_Realizar.Cod_ATecnica, " +
                    "dbo.v_Prox_Evento_a_Realizar.Des_Financiador, dbo.v_Prox_Evento_a_Realizar.Des_Facilitador, " +
                    "dbo.v_Prox_Evento_a_Realizar.Des_ProdFinanciero, dbo.v_Prox_Evento_a_Realizar.Des_Cliente, " +
                    "dbo.v_Prox_Evento_a_Realizar.Des_ATecnica, dbo.v_Prox_Evento_a_Realizar.Fec_Inicio_Asistencia, " +
                    "dbo.v_Prox_Evento_a_Realizar.Fec_Programada, dbo.v_Prox_Evento_a_Realizar.Des_Visita, dbo.ast_tt_Eventos_AT.Tip_EstadoReg, " +
                    "dbo.v_Prox_Evento_a_Realizar.Fec_Realizada, dbo.ast_tt_Eventos_AT.Cod_Evento, dbo.ast_tt_Eventos_AT.Cod_TipoEvento, " +
                    "dbo.adm_tc_TipoEvento.Des_TipoEvento, dbo.ast_tt_Eventos_AT.Des_Evento FROM dbo.v_Prox_Evento_a_Realizar INNER JOIN " +
                    "dbo.ast_tt_Eventos_AT ON dbo.v_Prox_Evento_a_Realizar.Cod_Empresa = dbo.ast_tt_Eventos_AT.Cod_Empresa AND " +
                    "dbo.v_Prox_Evento_a_Realizar.Cod_ATecnica = dbo.ast_tt_Eventos_AT.Cod_ATecnica AND " +
                    "dbo.v_Prox_Evento_a_Realizar.Fec_Programada = dbo.ast_tt_Eventos_AT.Fec_Programada INNER JOIN " +
                    "dbo.adm_tc_TipoEvento ON dbo.ast_tt_Eventos_AT.Cod_Empresa = dbo.adm_tc_TipoEvento.Cod_Empresa AND " +
                    "dbo.ast_tt_Eventos_AT.Cod_TipoEvento = dbo.adm_tc_TipoEvento.Cod_TipoEvento WHERE Cod_Usuario='" + elUsuario + "'";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvEventosRealizados.DataSource = te;
            }
            this.gvEventosRealizados.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LlenarListadoDeTipoEvento()
    {
        var df = new DataTable();
        df = EventosxATecnica.Obtener_TablaTipoEventoParaDdl();
        ddlTipoEvento_er.Items.Clear();
        if (df.Rows.Count > 0)
        {
            ddlTipoEvento_er.DataSource = df;
            ddlTipoEvento_er.DataValueField = "Cod_TipoEvento";
            ddlTipoEvento_er.DataTextField = "Des_TipoEvento";
            ddlTipoEvento_er.DataBind();
        }
    }

    protected void gvEventosRealizados_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvEventosRealizados.PageIndex = e.NewPageIndex;
        MostrarListaDeEventosARealizar();
    }

    protected void btnActualizar_er_Click(object sender, EventArgs e)
    {
        MostrarListaDeEventosARealizar();
    }


}