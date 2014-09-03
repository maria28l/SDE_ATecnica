using System;
using System.Web;
using System.Linq;
using System.Web.Services;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;
using System.Data;
using NitlapanTic.Sdeat.Catalogos;
using NitlapanTic.Sdeat.transacciones;
using System.Collections.Generic;

/// <summary>
/// Summary description for SdeAtWebService
/// </summary>
[WebService(Namespace = "http://localhost/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class SdeAtWebService : System.Web.Services.WebService {

    public SdeAtWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public Retorno Registrar_Departamento(string des_departamento)
    {
        Retorno ret;
        Departamento d = new Departamento(des_departamento);
        ret = d.Registrar_Departamento();
        return ret;
    }
    [WebMethod]
    public Retorno Editar_Departamento(string cod_empresa, string cod_departamento, int cod_Registro, string des_departamento, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Departamento d = new Departamento();
        d.Cod_Empresa = cod_empresa;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Registro = cod_Registro;
        d.Des_Departamento = des_departamento;
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Departamento();
        return ret;
    }
   [WebMethod]
    public Retorno Eliminar_Departamento(int cod_Registro)
    {
        Retorno ret = new Retorno();
        Departamento d = new Departamento();
        d.Cod_Registro = cod_Registro;
        ret = d.Eliminar_Departamento();
        return ret;
    }

    [WebMethod]
    public Retorno Registrar_Municipio(string cod_Departamento,string des_Municipio)
    {
        Retorno ret;
        Municipio d = new Municipio(des_Municipio);
        d.Cod_Departamento = cod_Departamento;
        ret = d.Registrar_Municipio();
        return ret;
    }
    [WebMethod]
    public Retorno Editar_Municipio(string cod_empresa, string cod_Departamento, string cod_Municipio, int cod_Registro, string des_Municipio, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Municipio d = new Municipio();
        d.Cod_Empresa = cod_empresa;
        d.Cod_Departamento = cod_Departamento;
        d.Des_Municipio = des_Municipio;
        d.Cod_Registro = cod_Registro;
        d.Cod_Municipio = cod_Municipio;
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Municipio();
        return ret;
    }

    [WebMethod]
    public Retorno Registrar_Cargo(string des_cargo)
    {
        Retorno ret;
        Cargo d = new Cargo(des_cargo);
        ret = d.Registrar_Cargo();
        return ret;
    }
    [WebMethod]
    public Retorno Editar_Cargo(string cod_empresa, string cod_cargo, int cod_Registro, string des_cargo, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Cargo d = new Cargo();
        d.Cod_Empresa = cod_empresa;
        d.Cod_Cargo = cod_cargo;
        d.Cod_Registro = cod_Registro;
        d.Des_Cargo = des_cargo;
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Cargo();
        return ret;
    }
    [WebMethod]
    public Retorno Eliminar_Cargo(int cod_Registro)
    {
        Retorno ret = new Retorno();
        Cargo d = new Cargo();
        d.Cod_Registro = cod_Registro;
        ret = d.Eliminar_Cargo();
        return ret;
    }

    [WebMethod]
    //Clientes_ARegionales
    public Retorno Clientes_ARegionales(string cod_personal_asigna, string cod_cliente, string cod_facilitador, string cod_sucursal)
    {
        Retorno ret = new Retorno();
        AsignarClientes a = new AsignarClientes();
        a.Cod_Personal_Asigna = cod_personal_asigna;
        a.Cod_Cliente = cod_cliente;
        a.Cod_Sucursal = cod_sucursal;
        a.Cod_Personal_Asignado = cod_facilitador;
        ret = a.Clientes_ARegionales();
        return ret;
   }

    [WebMethod]
    //Clientes_AFacilitadores
    public Retorno Clientes_AFacilitadores(string cod_personal_asigna, string cod_cliente, string cod_facilitador, string cod_sucursal)
    {
        Retorno ret = new Retorno();
        AsignarClientes a = new AsignarClientes();
        a.Cod_Personal_Asigna = cod_personal_asigna;
        a.Cod_Cliente = cod_cliente;
        a.Cod_Sucursal = cod_sucursal;
        a.Cod_Personal_Asignado = cod_facilitador;
        ret = a.Clientes_AFacilitadores();
        return ret;
    }

    [WebMethod]
    public Retorno Registrar_Personal(string cod_cargo,string cad_nombre_completo,string cad_identificacion,string cod_departamento,
        string cod_municipio, string cad_direccion, string cad_telefono, int bit_brinda_asistencia, string tip_contratacion, string tip_genero, string cod_jefe)
    {
        Retorno ret = new Retorno();
        Personal d = new Personal();
        d.Cod_Cargo = cod_cargo;
        d.Cad_Nombre_Completo = cad_nombre_completo;
        d.Cad_Identificacion = cad_identificacion;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cad_Direccion = cad_direccion;
        d.Cad_Telefono = cad_telefono;
        d.Bit_Brinda_Asistencia = bit_brinda_asistencia;       
        d.Tip_Contratacion = tip_contratacion;
        d.Tip_Genero = tip_genero;
        d.Cod_Jefe = cod_jefe;      
        ret = d.Registrar_Personal();
        return ret;

        
    }
    [WebMethod]
    public Retorno Editar_Personal(int cod_Registro, string cod_empresa, string cod_personal, string cod_cargo, string cad_nombre_completo, string cad_identificacion, string tip_genero, string cod_departamento, string cod_municipio, string cad_direccion, string cad_telefono, string cod_jefe, string tip_contratacion, int bit_brinda_asistencia, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Personal d = new Personal();
        d.Cod_Empresa = cod_empresa;        
        d.Cod_Registro = cod_Registro;
        d.Cod_Personal = cod_personal;
        d.Cod_Cargo = cod_cargo;
        d.Cad_Nombre_Completo = cad_nombre_completo;
        d.Cad_Identificacion = cad_identificacion;
        d.Tip_Genero = tip_genero;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cad_Direccion = cad_direccion;
        d.Cad_Telefono = cad_telefono;
        d.Cod_Jefe = cod_jefe;
        d.Tip_Contratacion = tip_contratacion;
        d.Bit_Brinda_Asistencia = bit_brinda_asistencia;
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Personal();
        return ret;
    }
    [WebMethod]
    public Retorno Eliminar_Personal(int cod_Registro)
    {
        Retorno ret = new Retorno();
        Personal d = new Personal();
        d.Cod_Registro = cod_Registro;
        ret = d.Eliminar_Personal();
        return ret;
    }


    [WebMethod]
    public Retorno Registrar_Cliente(  string cad_primer_nombre, string cad_segundo_nombre, string cad_primer_apellido, string cad_segundo_apellido, string cad_nombre_completo, string cad_identificacion, string cod_departamento, string cod_municipio, string cod_territorio, string tip_genero, string cad_direccion, string cad_telefono)
    {


        Retorno ret = new Retorno();
        Clientes d = new Clientes();
        d.Cad_Primer_Nombre = cad_primer_nombre;
        d.Cad_Segundo_Nombre = cad_segundo_nombre;
        d.Cad_Primer_Apellido = cad_primer_apellido;
        d.Cad_Segundo_Apellido = cad_segundo_apellido;
        d.Cad_Nombre_Completo = cad_nombre_completo;
        d.Cad_Identificacion = cad_identificacion;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cod_Territorio = cod_territorio;
        d.Tip_Genero = tip_genero;
        d.Cad_Direccion = cad_direccion;
        d.Cad_Telefono = cad_telefono;       
        ret = d.Registrar_Cliente();
        return ret;


    }
    [WebMethod]
    public Retorno Editar_Cliente(string cod_empresa, int cod_Registro, string cad_primer_nombre, string cad_segundo_nombre, string cad_primer_apellido, string cad_segundo_apellido, string cad_nombre_completo, string cad_identificacion,string tip_genero, string cod_departamento, string cod_municipio, string cod_territorio, string cad_direccion, string cad_telefono, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Clientes d = new Clientes(); 
        d.Cod_Empresa = cod_empresa;
        d.Cod_Registro = cod_Registro;
        d.Cad_Primer_Nombre = cad_primer_nombre;
        d.Cad_Segundo_Nombre = cad_segundo_nombre;
        d.Cad_Primer_Apellido = cad_primer_apellido;
        d.Cad_Segundo_Apellido = cad_segundo_apellido;
        d.Cad_Nombre_Completo = cad_nombre_completo;
        d.Cad_Identificacion = cad_identificacion;
        d.Tip_Genero = tip_genero;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cod_Territorio = cod_territorio;
        d.Cad_Direccion = cad_direccion;
        d.Cad_Telefono = cad_telefono;       
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Cliente();
        return ret;
    }
    [WebMethod]
    public Retorno Eliminar_Cliente(int cod_Registro)
    {
        Retorno ret = new Retorno();
        Clientes d = new Clientes();
        d.Cod_Registro = cod_Registro;
        ret = d.Eliminar_Cliente();
        return ret;
    }

    [WebMethod]
    public Retorno Registrar_ATecnica(string cod_financiador, string cod_cliente, string cod_credito_financiador, string cod_facilitador,
        string cod_productofinanciero, string des_atecnica, string des_propiedad, string cod_departamento, string cod_municipio,
        string cod_sucursal, string cod_territorio, string cad_direccion, float val_coordx, float val_coordy, int val_eventos,
        DateTime fec_inicio_asistencia)
    {

        Retorno ret = new Retorno();
        ATecnica d = new ATecnica();
        d.Cod_Financiador = cod_financiador;
        d.Cod_Cliente = cod_cliente;
        d.Cod_Credito_Financiador = cod_credito_financiador;
        d.Cod_Facilitador = cod_facilitador;
        d.Cod_ProductoFinanciero = cod_productofinanciero;
        d.Des_ATecnica = des_atecnica;
        d.Des_Propiedad = des_propiedad;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cod_Sucursal = cod_sucursal;
        d.Cod_Territorio = cod_territorio;
        d.Cad_Direccion = cad_direccion;
        d.Val_CoordX = val_coordx;
        d.Val_CoordY = val_coordy;
        d.Val_Eventos = val_eventos;
        d.Fec_Inicio_Asistencia = fec_inicio_asistencia;
        
        ret = d.Registrar_ATecnica();
        return ret;
    }
    //5555
    [WebMethod]
    public Retorno Registrar_Evento(int cod_atecnica, DateTime fec_programada, string cod_tipoevento, string des_evento)
    {
      Retorno ret = new Retorno();
      EventosxATecnica e = new EventosxATecnica();
      e.Cod_ATecnica = cod_atecnica;
      e.Fec_Programada = fec_programada;
      e.Cod_TipoEvento = cod_tipoevento;
      e.Des_Evento = des_evento;

      ret = e.Registrar_EventosxATecnica();
        return ret;
    }

    [WebMethod]
    public Retorno Eliminar_Evento(int cod_evento)
    {
        Retorno ret = new Retorno();
        EventosxATecnica e = new EventosxATecnica();
        //e.Cod_ATecnica = cod_atecnica;
        e.Cod_Evento = cod_evento;

        ret = e.Eliminar_Eventos_Programados();
        return ret;
    }

    [WebMethod]
    public Retorno Editar_EventoProgramado(int cod_atecnica, int cod_evento, DateTime fec_programada, string cod_tipoevento, string des_evento, string tip_estado)
    {
        Retorno ret = new Retorno();
        EventosxATecnica e = new EventosxATecnica();
        e.Cod_ATecnica = cod_atecnica;
        e.Cod_Evento = cod_evento;
        e.Fec_Programada = fec_programada;
        e.Cod_TipoEvento = cod_tipoevento;
        e.Des_Evento = des_evento;
        //e.Tip_Estado_Evento = tip_estadoevento;
        e.Tip_EstadoReg = tip_estado;
        ret = e.Editar_Eventos_Programados();
        return ret;
    }

    [WebMethod]
    public Retorno Editar_EventoRealizado(int cod_evento, DateTime fec_realizada, string des_visita, string tip_estado)
    {
        Retorno ret = new Retorno();
        EventosxATecnica e = new EventosxATecnica();
        e.Cod_Evento = cod_evento;
        e.Fec_Programada = fec_realizada;
        e.Des_Visita = des_visita;
        e.Tip_EstadoReg = tip_estado;
        ret = e.Editar_Eventos_Realizados();
        return ret;
    }
    //5555
    [WebMethod]
    public Retorno Editar_ATecnica(string cod_empresa, int cod_registro, string cod_financiador, string cod_cliente,
        string cod_credito_financiador, string cod_facilitador, string cod_productofinanciero, string des_atecnica, string des_propiedad,
        string cod_departamento, string cod_municipio, string cod_sucursal, string cod_territorio, string cad_direccion, float val_coordx,
        float val_coordy, int val_eventos, DateTime fec_inicio_asistencia, string tipo_estado, int cod_atecnica)
    {
        Retorno ret = new Retorno();
        ATecnica d = new ATecnica();
        d.Cod_Empresa = cod_empresa;
        d.Cod_Financiador = cod_financiador;
        d.Cod_Cliente = cod_cliente;
        d.Cod_Credito_Financiador = cod_credito_financiador;
        d.Cod_Facilitador = cod_facilitador;
        d.Cod_ProductoFinanciero = cod_productofinanciero;
        d.Des_ATecnica = des_atecnica;
        d.Des_Propiedad = des_propiedad;
        d.Cod_Departamento = cod_departamento;
        d.Cod_Municipio = cod_municipio;
        d.Cod_Sucursal = cod_sucursal;
        d.Cod_Territorio = cod_territorio;
        d.Cad_Direccion = cad_direccion;
        d.Val_CoordX = val_coordx;
        d.Val_CoordY = val_coordy;
        d.Val_Eventos = val_eventos;
        d.Fec_Inicio_Asistencia = fec_inicio_asistencia;
        d.Tip_EstadoReg = tipo_estado;
        d.Cod_ATecnica = cod_atecnica;
        d.Cod_Registro = cod_registro;
        ret = d.Editar_ATecnica();
        return ret;
    }

    [WebMethod]
    public Retorno Eliminar_ATecnica(int cod_atecnica)
    {
        Retorno ret = new Retorno();
        ATecnica d = new ATecnica();
        d.Cod_ATecnica = cod_atecnica;
        ret = d.Eliminar_ATecnica();
        return ret;
    }

    [WebMethod]
    public Retorno Registrar_Financiador(string des_financiador)
    {
        Retorno ret;
        Financiador d = new Financiador(des_financiador);
        ret = d.Registrar_Financiador();
        return ret;
    }


     [WebMethod]
    public Retorno Editar_Financiador(string cod_empresa, string cod_financiador, int cod_Registro, string des_financiador, string tipo_estado)
    {
        Retorno ret = new Retorno();
        Financiador d = new Financiador();
        d.Cod_Empresa = cod_empresa;
        d.Cod_Financiador = cod_financiador;
        d.Cod_Registro = cod_Registro;
        d.Des_Financiador = des_financiador;
        d.Tip_EstadoReg = tipo_estado;
        ret = d.Editar_Financiador();
        return ret;
    }
   [WebMethod]
    public Retorno Eliminar_Financiador(int cod_Registro)
    {
        Retorno ret = new Retorno();
        Financiador d = new Financiador();
        d.Cod_Registro = cod_Registro;
        ret = d.Eliminar_Financiador();
        return ret;
    }
    [WebMethod]
   public List<Municipio> ObtenerMunicipiosxDepartamento(string departamento)    
    {
        DataTable dm = Municipio.Obtener_TablaMunicipioParaDdl(departamento);
        dm.TableName = "municipios";
        var lmunicipios = from item in dm.AsEnumerable()
                    select new Municipio
                    {
                        Cod_Municipio = Convert.ToString(item["Cod_Municipio"]),
                        Des_Municipio = Convert.ToString(item["Des_Municipio"])
                    };
        return lmunicipios.ToList<Municipio>();
    }

    [WebMethod]
    public List<Territorio> ObtenerTerritoriosxMunicipio(string municipio)
    {
        DataTable dm = Territorio.Obtener_TablaTerritorioParaDdl(municipio);
        dm.TableName = "territorios";
        var lterritorios = from item in dm.AsEnumerable()
                          select new Territorio
                          {
                              Cod_Territorio = Convert.ToString(item["Cod_Territorio"]),
                              Des_Territorio = Convert.ToString(item["Des_Territorio"])
                          };
        return lterritorios.ToList<Territorio>();
    }

    [WebMethod]
    public List<Sucursal> ObtenerSucursalesxMunicipio(string municipio)
    {
        DataTable dt=Sucursal.Obtener_TablaSucursalxMunicParaDdl(municipio);
        dt.TableName="sucursales";
        var lsucursales=from item in dt.AsEnumerable()
                              select new Sucursal 
                              {
                                  Cod_Sucursal = Convert.ToString(item["Cod_Sucursal"]),
                                  Des_Sucursal = Convert.ToString(item["Des_Sucursal"])
                              };
        return lsucursales.ToList<Sucursal>();
    }

    [WebMethod]
    public List<Clientes> ObtenerClientesxFinanciador(string financiador, string cod_usuario)
    {
        DataTable dt = Clientes.Obtener_TablaClientexFinanciadorParaDdl(financiador, cod_usuario);
        dt.TableName = "clientes";
        var lclientes = from item in dt.AsEnumerable()
                          select new Clientes
                          {
                              Cod_Cliente = Convert.ToString(item["Cod_Cliente"]),
                              Cad_Nombre_Completo = Convert.ToString(item["Cad_Nombre_Completo"])
                          };
        return lclientes.ToList<Clientes>();
    }

    [WebMethod]
    public List<Personal> ObtenerFacilitadoresxSucursal(string sucursal)
    {
        DataTable dt = Personal.Obtener_TablaPersonalxSucursalParaDdl(sucursal);
        dt.TableName = "facilitadores";
        var lfacilitadores = from item in dt.AsEnumerable()
                        select new Personal
                        {
                            Cod_Personal = Convert.ToString(item["Cod_Personal"]),
                            Cad_Nombre_Completo = Convert.ToString(item["Cad_Nombre_Completo"])
                        };
        return lfacilitadores.ToList<Personal>();
    }

    [WebMethod]
    public List<Personal> ObtenerFacilitadoresxSucursalyCargo(string sucursal, string cargo)
    {
        DataTable dt = Personal.Obtener_TablaPersonalxSucursalyCargoParaDdl(sucursal, cargo);
        dt.TableName = "facilitadores";
        var lfacilitadores = from item in dt.AsEnumerable()
                             select new Personal
                             {
                                 Cod_Personal = Convert.ToString(item["Cod_Personal"]),
                                 Cad_Nombre_Completo = Convert.ToString(item["Cad_Nombre_Completo"])
                             };
        return lfacilitadores.ToList<Personal>();
    }


    [WebMethod]
    public List<ProdFinanciero> ObtenerProdFinxFinanciador(string financiador)
    {
        DataTable dt = ProdFinanciero.Obtener_TablaProdFinxFinanciadorParaDdl(financiador);
        dt.TableName = "productos";
        var lproductos = from item in dt.AsEnumerable()
                             select new ProdFinanciero
                             {
                                 Cod_ProdFinanciero = Convert.ToString(item["Cod_ProductoFinanciero"]),
                                 Des_ProdFinanciero = Convert.ToString(item["Des_ProdFinanciero"])
                             };
        return lproductos.ToList<ProdFinanciero>();
    }

    [WebMethod]
    public int ObtenerEventosAProgramar(string financiador, string prodfinanciero)
    {
        int ev = ATecnica.Obtener_EventosAProgramar(financiador, prodfinanciero);
        return ev;
    }
    [WebMethod]
    public List<Personal> ObtenerJefexCargo(string cargo)
    {
        DataTable dm = Personal.Obtener_TablaJefeParaDdl(cargo);
        dm.TableName = "personals";
        var lpersonals = from item in dm.AsEnumerable()
                        select new Personal
                           {
                               Cod_Personal = Convert.ToString(item["Cod_Personal"]),
                               Cad_Nombre_Completo = Convert.ToString(item["Cad_Nombre_Completo"])
                           };
        return lpersonals.ToList<Personal>();
    }



}



