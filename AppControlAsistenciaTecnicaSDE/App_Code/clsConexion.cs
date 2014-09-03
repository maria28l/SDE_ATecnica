using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NitlapanTic.Sdeat.Util
{
    /// <summary>
    /// Summary description for clsConexion
    /// </summary>
    public class clsConexion : IDisposable
    {

        #region VariablesPrivadas

        protected DataSet _dset_;
        protected SqlDataAdapter _sda_;
        protected SqlCommand _cmd_;
        protected SqlConnection _con_;
        protected String _Mensaje_;
        protected Retorno retorno;

        #endregion

        #region Propiedades

        public DataSet dset
        {
            get { return _dset_; }
            set { _dset_ = value; }
        }

        public SqlDataAdapter sda
        {
            get { return _sda_; }
            set { _sda_ = value; }
        }

        public SqlCommand cmd
        {
            get { return _cmd_; }
            set { _cmd_ = value; }
        }

        public SqlConnection con
        {
            get { return _con_; }
            set { _con_ = value; }
        }

        public String Mensaje
        {
            get { return _Mensaje_; }
            //set { _Mensaje_ = value; }
        }


        #endregion

        #region Constructores

        public clsConexion()
        {

            this._con_ = new SqlConnection();
            this._con_.ConnectionString = ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString;
            retorno = new Retorno();
        }

        public clsConexion(String CadenaConexion)
        {
            this._con_ = new SqlConnection();
            this._con_.ConnectionString = CadenaConexion;
            retorno = new Retorno();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Abre la conexión.
        /// </summary>
        /// <returns></returns>
        public bool AbrirConexion()
        {
            try
            {
                if (this._con_.State == ConnectionState.Closed)
                {
                    this._con_.Open();
                    return true;
                }
                if (this._con_.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Cierra la conexión.
        /// </summary>
        /// <returns></returns>
        public bool CerrarConexion()
        {
            try
            {
                if (this._con_.State == ConnectionState.Open)
                {
                    this._con_.Close();
                    return true;
                }
                if (this._con_.State == ConnectionState.Closed)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                this._Mensaje_ = ex.Message;
                return false;
            }
        }

        public void CrearDataAdapter()
        {
            _sda_ = new SqlDataAdapter();
        }

        public void CrearSqlCommand()
        {
            _cmd_ = new SqlCommand();
            _cmd_.Connection = this._con_;
        }

        public void CrearDataSet()
        {
            _dset_ = new DataSet();
        }

        #endregion

        #region Funciones SqlCommand
        /// <summary>
        /// Ejecuta consultas de inserción donde se requiere retornar el id del registro creado.
        /// </summary>
        /// <param name="mCmd">SqlCommand con CommandText y Parámetros definidos</param>
        /// <param name="CampoIdRetorno">Nombre del parametro en el que el Id se retornará.</param>
        /// <returns>Clase de retorno, indica true o false si se ha tenido éxito. En caso de que no la propiedad Mensaje indicará
        /// el error debido.</returns>
        public Retorno EjecutarProcedimiento(SqlCommand mCmd, String CampoIdRetorno)
        {
            try
            {
                AbrirConexion();
                mCmd.Connection = this.con;
                mCmd.CommandType = CommandType.StoredProcedure;
                mCmd.CommandTimeout = 5000;
                mCmd.ExecuteNonQuery();

                retorno.id = int.Parse(mCmd.Parameters[CampoIdRetorno].Value.ToString());
                int ret = (int)(byte)mCmd.Parameters["RETURN"].Value;
                retorno.Mensaje = mCmd.Parameters["RETURN_MESSAGE"].Value.ToString();

                retorno.Resultado = ((int)(byte)mCmd.Parameters["RETURN"].Value) == 0 ? true : false;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.id = 0;
                retorno.Mensaje = ex.Message;
                retorno.Resultado = false;
                return retorno;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Ejecuta un procedimiento almacenado que devuelve múltiples tablas (múltiples conjunto de datos)
        /// </summary>
        /// <param name="mCmd"></param>
        /// <returns></returns>
        public DataSet ObtenerDataSet(SqlCommand mCmd)
        {
            try
            {
                AbrirConexion();
                CrearDataSet();
                CrearDataAdapter();
                mCmd.Connection = this.con;
                mCmd.CommandTimeout = 5000;
                sda.SelectCommand = mCmd;

                sda.Fill(dset);
                return dset;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// Ejecuta consultas de inserción o modificación donde se requiere retornar el id del registro creado o modificado.
        /// </summary>
        /// <param name="mCmd">SqlCommand con CommandText y Parámetros definidos</param>
        /// <returns>Clase de retorno, indica true o false si se ha tenido éxito. En caso de que no la propiedad Mensaje indicará
        /// el error debido.</returns>
        public Retorno EjecutarProcedimiento(SqlCommand mCmd)
        {
            try
            {
                AbrirConexion();
                mCmd.Connection = this.con;
                mCmd.CommandType = CommandType.StoredProcedure;
                mCmd.CommandTimeout = 5000;
                mCmd.ExecuteNonQuery();

                retorno.id = 0;
                var ret = (int)(byte)mCmd.Parameters["RETURN"].Value;
                retorno.Mensaje = mCmd.Parameters["RETURN_MESSAGE"].Value.ToString();

                retorno.Resultado = ((int)(byte)mCmd.Parameters["RETURN"].Value) == 0 ? true : false;

                return retorno;

            }
            catch (Exception ex)
            {

                retorno.id = 0;
                retorno.Mensaje = ex.Message;
                retorno.Resultado = false;
                return retorno;
            }
            finally
            {
                CerrarConexion();
            }
        }
        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (this.con.State == ConnectionState.Open)
                {
                    if (_cmd_ != null)
                        _cmd_.Dispose();
                    if (_dset_ != null)
                        _dset_.Dispose();
                    if (_sda_ != null)
                        _sda_.Dispose();

                    this._con_.Close();
                    _con_.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

    }

}