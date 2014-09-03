using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;


namespace NitlapanTic.Sdeat.Catalogos
{
    /// <summary>
    /// Summary description for Personal
    /// </summary>
    public class Personal : ICloneable
    {

        private string mCod_Empresa = "";
        private string mCod_Personal = "";
        private int mCod_Registro = 0;
        private string mCad_Nombre_Completo = "";
        private string mCad_Identificacion = "";
        private string mTip_Genero = "";
        private string mCod_Departamento = "";
        private string mCod_Municipio = "";
        private string mCad_Direccion = "";
        private string mCad_Telefono = "";
        private string mCod_Cargo = "";
        private string mCod_Jefe = "";
        private string mTip_Contratacion = "";
        private int mBit_Brinda_Asistencia;
        private string mDes_Departamento = "";
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

        public string Cod_Personal
        {
            get
            {
                return mCod_Personal;
            }
            set
            {
                mCod_Personal = value;
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

        public string Cod_Cargo
        {
            get
            {
                return mCod_Cargo;
            }
            set
            {
                mCod_Cargo = value;
            }
        }
        public string Cod_Jefe
        {
            get
            {
                return mCod_Jefe;
            }
            set
            {
                mCod_Jefe = value;
            }
        }
        public string Tip_Contratacion
        {
            get
            {
                return mTip_Contratacion;
            }
            set
            {
                mTip_Contratacion = value;
            }
        }
        public int Bit_Brinda_Asistencia
        {
            get
            {
                return mBit_Brinda_Asistencia;
            }
            set
            {
                mBit_Brinda_Asistencia = value;
            }
        }


        public string Des_Departamento
        {
            get
            {
                return mDes_Departamento;
            }
            set
            {
                mDes_Departamento = value;
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
        public Personal()
        {
        }
        public Personal(string Des_Departamento)
        {
            mDes_Departamento = Des_Departamento;
        }

        public Personal(string Cod_Empresa, string Cod_Personal, string Cad_Nombre_Completo, string Cad_Identificacion, string Tip_Genero, string Cod_Municipio, string Cad_Direccion, string Cad_Telefono, int Bit_Brinda_Asistencia, string Cod_Cargo, string Cod_Jefe, string Tip_Contratacion, string Cod_Departamento, int Cod_Registro, string Des_Departamento, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Personal = Cod_Personal;
            mCad_Nombre_Completo = Cad_Nombre_Completo;
            mCad_Identificacion = Cad_Identificacion;
            mTip_Genero = Tip_Genero;
            mCod_Departamento = Cod_Departamento;
            mCod_Municipio = Cod_Municipio;
            mCod_Registro = Cod_Registro;
            mDes_Departamento = Des_Departamento;
            mCod_Municipio = Cod_Municipio;
            mCad_Direccion = Cad_Direccion;
            mCad_Telefono = Cad_Telefono;
            mCod_Cargo = Cod_Cargo;
            mCod_Jefe = Cod_Jefe;
            mTip_Contratacion = Tip_Contratacion;
            mBit_Brinda_Asistencia = Bit_Brinda_Asistencia;
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
        public Retorno Registrar_Personal()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_Personal", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cad_Nombre_Completo", SqlDbType.NVarChar, 70);
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

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;

                cmd.Parameters.Add("Cad_Telefono", SqlDbType.NVarChar, 50);
                cmd.Parameters["Cad_Telefono"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Telefono"].Value = this.Cad_Telefono;

                cmd.Parameters.Add("Cod_Cargo", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Cargo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cargo"].Value = this.Cod_Cargo;

                cmd.Parameters.Add("Cod_Jefe", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Jefe"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Jefe"].Value = this.Cod_Jefe;

                cmd.Parameters.Add("Tip_Contratacion", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_Contratacion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_Contratacion"].Value = this.Tip_Contratacion;

                cmd.Parameters.Add("Bit_Brinda_Asistencia", SqlDbType.Int);
                cmd.Parameters["Bit_Brinda_Asistencia"].Direction = ParameterDirection.Input;
                cmd.Parameters["Bit_Brinda_Asistencia"].Value = this.Bit_Brinda_Asistencia;

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

        public Retorno Editar_Personal()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Editar_Personal";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Cod_Empresa", SqlDbType.Char, 2);
                cmd.Parameters["Cod_Empresa"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Empresa"].Value = this.mCod_Empresa;

                cmd.Parameters.Add("Cod_Personal", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Personal"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Personal"].Value = this.mCod_Personal;

                cmd.Parameters.Add("Cad_Nombre_Completo", SqlDbType.NVarChar, 70);
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

                cmd.Parameters.Add("Cad_Direccion", SqlDbType.NVarChar, 150);
                cmd.Parameters["Cad_Direccion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Direccion"].Value = this.Cad_Direccion;

                cmd.Parameters.Add("Cad_Telefono", SqlDbType.NVarChar, 50);
                cmd.Parameters["Cad_Telefono"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cad_Telefono"].Value = this.Cad_Telefono;

                cmd.Parameters.Add("Cod_Cargo", SqlDbType.Char, 3);
                cmd.Parameters["Cod_Cargo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cargo"].Value = this.Cod_Cargo;

                cmd.Parameters.Add("Cod_Jefe", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Jefe"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Jefe"].Value = this.Cod_Jefe;

                cmd.Parameters.Add("Tip_Contratacion", SqlDbType.NVarChar, 10);
                cmd.Parameters["Tip_Contratacion"].Direction = ParameterDirection.Input;
                cmd.Parameters["Tip_Contratacion"].Value = this.Tip_Contratacion;

                cmd.Parameters.Add("Bit_Brinda_Asistencia", SqlDbType.Int);
                cmd.Parameters["Bit_Brinda_Asistencia"].Direction = ParameterDirection.Input;
                cmd.Parameters["Bit_Brinda_Asistencia"].Value = this.Bit_Brinda_Asistencia;

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
        public Retorno Eliminar_Personal()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.usp_Eliminar_Personal";
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

        public static DataTable Obtener_TablaJefeParaDdl(string codCargo)
        {
            DataTable dj;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerJefeParaDdl", CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("cod_Cargo", SqlDbType.Char, 3);
                cmd.Parameters["cod_Cargo"].Value = codCargo;
                using (clsConexion con = new clsConexion())
                {
                    dj = con.ObtenerDataSet(cmd).Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dj;
        }

        public static DataTable Obtener_TablaPersonalParaDdl()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerPersonalParaDdl", CommandType = CommandType.StoredProcedure };

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

        public static DataTable Obtener_TablaPersonalxSucursalParaDdl(string codSucursal)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerPersonalxSucursalParaDdl", CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("cod_Sucursal", SqlDbType.Char, 3);
                cmd.Parameters["cod_Sucursal"].Value = codSucursal;

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

        public static DataTable Obtener_TablaPersonalxSucursalyCargoParaDdl(string codSucursal, string codCargo)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_ObtenerPersonalxSucursalyCargoParaDdl", CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("cod_Sucursal", SqlDbType.Char, 3);
                cmd.Parameters["cod_Sucursal"].Value = codSucursal;
                cmd.Parameters.Add("cod_Cargo", SqlDbType.Char, 3);
                cmd.Parameters["cod_Cargo"].Value = codCargo;

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
