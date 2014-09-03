using System;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;

public partial class catalogos_Personal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var ctl = this.Master.FindControl("page_title");
            ((HtmlGenericControl)ctl).InnerText = "CATALOGO DE PERSONAL";
            ctl = this.Master.FindControl("page_description");
            ((HtmlGenericControl)ctl).InnerText = "Personal de Servicio de Desarrollo Empresarial";
        }
        catch (Exception ex )
        {
        }
        MostrarListaDePersonal();
        if (!IsPostBack)
        {
            LlenarListadoDeDepartamentos();
            LlenarListadoDeCargo();
            //LlenarListadoDeJefe();
        }
    }
    protected void MostrarListaDePersonal()
    {
        try
        {
            using (var cmd = new SqlCommand())
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ast_tm_Personal";
                cmd.CommandType = CommandType.Text;
                var da = new SqlDataAdapter(cmd);
                var te = new DataTable();
                da.Fill(te);
                this.gvPersonal.DataSource = te;
            }
            this.gvPersonal.DataBind();

        }
        catch (Exception ex)
        {

        }
    }
    protected void LlenarListadoDeDepartamentos()
    {
        var dt = new DataTable();
        dt = Departamento.Obtener_TablaDepartamentosParaDdl();
        ddlDepartamento.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlDepartamento.DataSource = dt;
            ddlDepartamento.DataValueField = "Cod_Departamento";
            ddlDepartamento.DataTextField = "Des_Departamento";
            ddlDepartamento.DataBind();
        }
    }   
     protected void LlenarListadoDeMunicipio(string codDepartamento)
    {
        var dm = new DataTable();
        dm = Municipio.Obtener_TablaMunicipioParaDdl(codDepartamento);
        ddlMunicipio.Items.Clear();        
        if (dm.Rows.Count > 0)
        {
            ddlMunicipio.DataSource = dm;           
            ddlMunicipio.DataValueField = "Cod_Municipio";
            ddlMunicipio.DataTextField = "Des_Municipio";            
            ddlMunicipio.DataBind();
        }
    }

     protected void LlenarListadoDeCargo()
     {
         var dc = new DataTable();
         dc = Cargo.Obtener_TablaCargoParaDdl();
         ddlCargo.Items.Clear();
         if (dc.Rows.Count > 0)
         {
             ddlCargo.DataSource = dc;
             ddlCargo.DataValueField = "Cod_Cargo";
             ddlCargo.DataTextField = "Des_Cargo";
             ddlCargo.DataBind();
         }
     }

     protected void LlenarListadoDeJefe(string codCargo)
     {
         var dj = new DataTable();
         dj = Personal.Obtener_TablaJefeParaDdl(codCargo);
         ddlJefe.Items.Clear();
         if (dj.Rows.Count > 0)
         {
             ddlJefe.DataSource = dj;
             ddlJefe.DataValueField = "Cod_Personal";
             ddlJefe.DataTextField = "Cad_Nombre_Completo";
             ddlJefe.DataBind();
         }
     }

     protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             if (ddlDepartamento.Items.Count > 0)
             {
                 LlenarListadoDeMunicipio(ddlDepartamento.SelectedValue);
             }
             else
             {
                 ddlMunicipio.Items.Clear();
             }

         }
         catch (Exception ex)
         {
             ddlMunicipio.Items.Clear();
         }
     }
     protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             if (ddlCargo.Items.Count > 0)
             {
                 LlenarListadoDeJefe(ddlCargo.SelectedValue);
             }
             else
             {
                 ddlJefe.Items.Clear();
             }

         }
         catch (Exception ex)
         {
             ddlJefe.Items.Clear();
         }
     }
       
         
}