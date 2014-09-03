using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using NitlapanTic.Sdeat.Catalogos;


namespace NitlapanTic.Sdeat.Catalogos
{
    /// <summary>
    /// Summary description for Clientes
    /// </summary>
    public class Clientes : ICloneable
    {

        private string mCod_Empresa = "";
        private string mCod_Cliente = "";
        private int mCod_Registro = 0;
        private string mCad_Primer_Nombre = "";
        private string mCad_Segundo_Nombre = "";
        private string mCad_Primer_Apellido = "";
        private string mCad_Segundo_Apellido = "";   
        private string mCad_Nombre_Completo= "";
        private string mCad_Identificacion= "";
        private string mTip_Genero= "";
        private string mCod_Departamento= "";
        private string mCod_Municipio= "";
        private string mCod_Territorio = "";
        private string mCad_Direccion= "";
        private string mCad_Telefono= ""; 
        private string mTip_EstadoReg = "";
        private string mCod_Usuario_Creo = "";
        private DateTime mFec_Creado = DateTime.Now;
        private string mCod_Usuario_Modifico = "";
        private DateTime mFec_Modificado = DateTime.Now;
        private string mCad_Equipo = "";

        public string Cod_Empresa
        {
            get
            {
                return mCod_Empresa;
            }
            set
            {
                mCod_Empresa = value;
            }
        }

        public string Cod_Cliente
        {
            get
            {
                return mCod_Cliente;
            }
            set
            {
                mCod_Cliente = value;
            }
        }

        public int Cod_Registro
        {
            get
            {
                return mCod_Registro;
            }
            set
            {
                mCod_Registro = value;
            }
        }
        public string Cad_Primer_Nombre
        {
            get
            {
                return mCad_Primer_Nombre;
            }
            set
            {
                mCad_Primer_Nombre = value;
            }
        }

        public string Cad_Segundo_Nombre
        {
            get
            {
                return mCad_Segundo_Nombre;
            }
            set
            {
                mCad_Segundo_Nombre = value;
            }
        }
        public string Cad_Primer_Apellido
        {
            get
            {
                return mCad_Primer_Apellido;
            }
            set
            {
                mCad_Primer_Apellido = value;
            }
        }

        public string Cad_Segundo_Apellido
        {
            get
            {
                return mCad_Segundo_Apellido;
            }
            set
            {
                mCad_Segundo_Apellido = value;
            }
        }


        public string Cad_Nombre_Completo
        {
            get
            {
                return mCad_Nombre_Completo;
            }
            set
            {
                mCad_Nombre_Completo = value;
            }
        }

        public string Cad_Identificacion
        {
            get
            {
                return mCad_Identificacion;
            }
            set
            {
                mCad_Identificacion = value;
            }
        }
        public string Tip_Genero
        {
            get
            {
                return mTip_Genero;
            }
            set
            {
                mTip_Genero = value;
            }
        }
        public string Cod_Departamento
        {
            get
            {
                return mCod_Departamento;
            }
            set
            {
                mCod_Departamento = value;
            }
        }
        public string Cod_Municipio
        {
            get
            {
                return mCod_Municipio;
            }
            set
            {
                mCod_Municipio = value;
            }
        }

        public string Cod_Territorio
        {
            get
            {
                return mCod_Territorio;
            }
            set
            {
                mCod_Territorio = value;
            }
        }


        public string Cad_Direccion
        {
            get
            {
                return mCad_Direccion;
            }
            set
            {
                mCad_Direccion = value;
            }
        }
        
        public string Cad_Telefono
        {
            get
            {
                return mCad_Telefono;
            }
            set
            {
                mCad_Telefono = value;
            }
        }

        public string Tip_EstadoReg
        {
            get
            {
                return mTip_EstadoReg;
            }
            set
            {
                mTip_EstadoReg = value;
            }
        }

        public string Cod_Usuario_Creo
        {
            get
            {
                return mCod_Usuario_Creo;
            }
            set
            {
                mCod_Usuario_Creo = value;
            }
        }

        public DateTime Fec_Creado
        {
            get
            {
                return mFec_Creado;
            }
            set
            {
                mFec_Creado = value;
            }
        }

        public string Cod_Usuario_Modifico
        {
            get
            {
                return mCod_Usuario_Modifico;
            }
            set
            {
                mCod_Usuario_Modifico = value;
            }
        }

        public DateTime Fec_Modificado
        {
            get
            {
                return mFec_Modificado;
            }
            set
            {
                mFec_Modificado = value;
            }
        }

        public string Cad_Equipo
        {
            get
            {
                return mCad_Equipo;
            }
            set
            {
                mCad_Equipo = value;
            }
        }
        public Clientes()
        {
        }
        public Clientes(string Cad_Nombre_Completo)
        {
            mCad_Nombre_Completo = Cad_Nombre_Completo;
        }

        public Clientes(string Cod_Empresa, int Cod_Registro, string Cod_Cliente, string Cad_Primer_Nombre, string Cad_Segundo_Nombre, string Cad_Primer_Apellido, string Cad_Segundo_Apellido, string Cad_Nombre_Completo, string Cad_Identificacion, string Tip_Genero, string Cod_Departamento, string Cod_Municipio, string Cod_Territorio, string Cad_Direccion, string Cad_Telefono, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Cliente = Cod_Cliente;
            mCad_Primer_Nombre = Cad_Primer_Nombre;
            mCad_Segundo_Nombre = Cad_Segundo_Nombre;
            mCad_Primer_Apellido = Cad_Primer_Apellido;
            mCad_Segundo_Apellido = Cad_Segundo_Apellido;
            mCad_Nombre_Completo = Cad_Nombre_Completo;
            mCad_Identificacion = Cad_Identificacion;
            mTip_Genero= Tip_Genero;
            mCod_Departamento = Cod_Departamento;
            mCod_Municipio = Cod_Municipio;           
            mCod_Registro = Cod_Registro;
            mCod_Territorio = Cod_Territorio;
            mCad_Direccion = Cad_Direccion;
            mCad_Telefono = Cad_Telefono;            
            mTip_EstadoReg = Tip_EstadoReg;
            mCod_Usuario_Creo = Cod_Usuario_Creo;
            mFec_Creado = Fec_Creado;
            mCod_Usuario_Modifico = Cod_Usuario_Modifico;
            mFec_Modificado = Fec_Modificado;
            mCad_Equipo = Cad_Equipo;
        
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }
        public Retorno Registrar_Cliente()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_Cliente", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cad_Primer_Nombre", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Primer_Nombre"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Primer_Nombre"].Value = this.Cad_Primer_Nombre;

                cmd.Parameters.Add("Cad_Segundo_Nombre", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Segundo_Nombre"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Segundo_Nombre"].Value = this.Cad_Segundo_Nombre;

                cmd.Parameters.Add("Cad_Primer_Apellido", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Primer_Apellido"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Primer_Apellido"].Value = this.Cad_Primer_Apellido;

                cmd.Parameters.Add("Cad_Segundo_Apellido", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Segundo_Apellido"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Segundo_Apellido"].Value = this.Cad_Segundo_Apellido;


                cmd.Parameters.Add("Cad_Nombre_Completo", SqlDbType.NVarChar, 100);
                cmd.Parameters["Cad_Nombre_Completo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Nombre_Completo"].Value = this.Cad_Nombre_Completo;

                cmd.Parameters.Add("Cad_Identificacion", SqlDbType.NVarChar, 14);
                cmd.Parameters["Cad_Identificacion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Identificacion"].Value = this.Cad_Identificacion;

                cmd.Parameters.Add("Tip_Genero", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_Genero"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_Genero"].Value = this.Tip_Genero;

                cmd.Parameters.Add("Cod_Departamento", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Departamento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Departamento"].Value = this.Cod_Departamento;

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Municipio"].Value = this.Cod_Municipio;

                cmd.Parameters.Add("Cod_Territorio", SqlDbType.NVarChar, 5);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.Cod_Territorio;

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;

                cmd.Parameters.Add("Cad_Telefono", SqlDbType.NVarChar, 50);
                cmd.Parameters["Cad_Telefono"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Telefono"].Value = this.Cad_Telefono;

                cmd.Parameters.Add("Cod_Usuario_Creo", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cod_Usuario_Creo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Usuario_Creo"].Value = "REBECA";//HttpContext.Current.User.Identity.Name;        

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;


                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd, "Cod_Registro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public Retorno Editar_Cliente()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Empresa", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Empresa"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Empresa"].Value = this.mCod_Empresa;

                cmd.Parameters.Add("Cad_Primer_Nombre", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Primer_Nombre"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Primer_Nombre"].Value = this.Cad_Primer_Nombre;

                cmd.Parameters.Add("Cad_Segundo_Nombre", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Segundo_Nombre"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Segundo_Nombre"].Value = this.Cad_Segundo_Nombre;

                cmd.Parameters.Add("Cad_Primer_Apellido", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Primer_Apellido"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Primer_Apellido"].Value = this.Cad_Primer_Apellido;

                cmd.Parameters.Add("Cad_Segundo_Apellido", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cad_Segundo_Apellido"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Segundo_Apellido"].Value = this.Cad_Segundo_Apellido;


                cmd.Parameters.Add("Cad_Nombre_Completo", SqlDbType.NVarChar, 100);
                cmd.Parameters["Cad_Nombre_Completo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Nombre_Completo"].Value = this.Cad_Nombre_Completo;

                cmd.Parameters.Add("Cad_Identificacion", SqlDbType.NVarChar, 14);
                cmd.Parameters["Cad_Identificacion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Identificacion"].Value = this.Cad_Identificacion;

                cmd.Parameters.Add("Tip_Genero", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_Genero"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_Genero"].Value = this.Tip_Genero;

                cmd.Parameters.Add("Cod_Departamento", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Departamento"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Departamento"].Value = this.Cod_Departamento;

                cmd.Parameters.Add("Cod_Municipio", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Municipio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Municipio"].Value = this.Cod_Municipio;

                cmd.Parameters.Add("Cod_Territorio", SqlDbType.NVarChar, 5);
                cmd.Parameters["Cod_Territorio"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Territorio"].Value = this.Cod_Territorio;

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;               

                cmd.Parameters.Add("Cad_Telefono", SqlDbType.NVarChar, 50);
                cmd.Parameters["Cad_Telefono"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Telefono"].Value = this.Cad_Telefono;

                cmd.Parameters.Add("Tip_EstadoReg", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_EstadoReg"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_EstadoReg"].Value = this.mTip_EstadoReg;

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.mCod_Registro;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;

                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        public Retorno Eliminar_Cliente()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Eliminar_Cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Registro", SqlDbType.Int);
                cmd.Parameters["Cod_Registro"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Registro"].Value = this.mCod_Registro;

                cmd.Parameters.Add("RETURN", SqlDbType.TinyInt);
                cmd.Parameters["RETURN"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("RETURN_MESSAGE", SqlDbType.NVarChar, 500);
                cmd.Parameters["RETURN_MESSAGE"].Direction = ParameterDirection.Output;

                using (clsConexion con = new clsConexion())
                {
                    ret = con.EjecutarProcedimiento(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        public static DataTable Obtener_TablaClienteParaDdl()
        {
            DataTable ds;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerClienteParaDdl", CommandType = CommandType.StoredProcedure };

                using (clsConexion con = new clsConexion())
                {
                    ds = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable Obtener_TablaClientexFinanciadorParaDdl(string codFinanciador, string codUsuario)
        {
            DataTable ds;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerClientesxFinanciadorParaDdl", CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("Cod_Financiador", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Financiador"].Value = codFinanciador;
                cmd.Parameters.Add("Cod_Usuario", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Usuario"].Value = codUsuario;

                using (clsConexion con = new clsConexion())
                {
                    ds = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable Obtener_TablaDepartamentosParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerDepartamentosParaDdl", CommandType = CommandType.StoredProcedure };
     
                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable Obtener_TablaMunicipioParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerMunicicpioParaDdl", CommandType = CommandType.StoredProcedure };

                using (clsConexion con = new clsConexion())
                {
                    dt = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
    
   



}
