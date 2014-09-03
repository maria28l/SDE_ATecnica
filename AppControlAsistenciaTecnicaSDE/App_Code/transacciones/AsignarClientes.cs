using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NitlapanTic.Sdeat.Util;
using System.Data.SqlClient;

namespace NitlapanTic.Sdeat.transacciones
{
    /// <summary>
    /// Descripción breve de AsignarClientes
    /// </summary>
    public class AsignarClientes : ICloneable
    {

        private string mCod_Empresa = "";
        private int mCod_Registro = 0;
        private string mCod_Personal_Asigna = "";
        private string mCod_Cliente = "";
        private string mCod_Sucursal = "";
        private string mCod_Personal_Asignado = "";
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

        public string Cod_Personal_Asigna
        {
            get
            {
                return mCod_Personal_Asigna;
            }
            set
            {
                mCod_Personal_Asigna = value;
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

        public string Cod_Personal_Asignado
        {
            get
            {
                return mCod_Personal_Asignado;
            }
            set
            {
                mCod_Personal_Asignado = value;
            }
        }

        public string Cod_Sucursal
        {
            get
            {
                return mCod_Sucursal;
            }
            set
            {
                mCod_Sucursal = value;
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


        public AsignarClientes(string Cod_Empresa, int Cod_Registro, string Cod_Personal_Asigna, string Cod_Cliente, string Cod_Sucursal, string Cod_Personal_Asignado, string Tip_EstadoReg, string Cod_Usuario_Creo, DateTime Fec_Creado, string Cod_Usuario_Modifico, DateTime Fec_Modificado, string Cad_Equipo)
        {
            mCod_Empresa = Cod_Empresa;
            mCod_Registro = Cod_Registro;
            mCod_Personal_Asigna = Cod_Personal_Asigna;
            mCod_Cliente = Cod_Cliente;
            mCod_Sucursal = Cod_Sucursal;
            mCod_Personal_Asignado = Cod_Personal_Asignado;
            mTip_EstadoReg = Tip_EstadoReg;
            mCod_Usuario_Creo = Cod_Usuario_Creo;
            mFec_Creado = Fec_Creado;
            mCod_Usuario_Modifico = Cod_Usuario_Modifico;
            mFec_Modificado = Fec_Modificado;
            mCad_Equipo = Cad_Equipo; 

        }

        public AsignarClientes()
        {
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public Retorno Clientes_ARegionales()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_ClientesARegionales", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cod_Personal_Asigna", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Personal_Asigna"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Personal_Asigna"].Value = this.Cod_Personal_Asigna;

                cmd.Parameters.Add("Cod_Cliente", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Cliente"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cliente"].Value = this.Cod_Cliente;

                cmd.Parameters.Add("Cod_Sucursal", SqlDbType.NVarChar, 3);
                cmd.Parameters["Cod_Sucursal"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Sucursal"].Value = this.Cod_Sucursal;

                cmd.Parameters.Add("Cod_Personal_Asignado", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Personal_Asignado"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Personal_Asignado"].Value = this.Cod_Personal_Asignado;

                cmd.Parameters.Add("Cod_Usuario_Creo", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cod_Usuario_Creo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Usuario_Creo"].Value = "";//HttpContext.Current.User.Identity.Name;        

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

        public Retorno Clientes_AFacilitadores()
        {
            Retorno ret = new Retorno();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = "dbo.usp_Insert_ClientesAFacilitadores", CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("Cod_Personal_Asigna", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Personal_Asigna"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Personal_Asigna"].Value = this.Cod_Personal_Asigna;

                cmd.Parameters.Add("Cod_Cliente", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Cliente"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Cliente"].Value = this.Cod_Cliente;

                cmd.Parameters.Add("Cod_Sucursal", SqlDbType.NVarChar, 3);
                cmd.Parameters["Cod_Sucursal"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Sucursal"].Value = this.Cod_Sucursal;

                cmd.Parameters.Add("Cod_Personal_Asignado", SqlDbType.NVarChar, 8);
                cmd.Parameters["Cod_Personal_Asignado"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Personal_Asignado"].Value = this.Cod_Personal_Asignado;

                cmd.Parameters.Add("Cod_Usuario_Creo", SqlDbType.NVarChar, 20);
                cmd.Parameters["Cod_Usuario_Creo"].Direction = ParameterDirection.Input;
                cmd.Parameters["Cod_Usuario_Creo"].Value = "";//HttpContext.Current.User.Identity.Name;        

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

    }
}