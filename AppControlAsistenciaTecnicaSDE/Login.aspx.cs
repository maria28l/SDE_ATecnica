using System;
using System.Web;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    //string elUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["login"] = null;
    }
    protected void Iniciar(object sender, System.EventArgs e)
    {
        if (ValidateUser(txtUserName.Value, txtUserPass.Value))
        {
            Session["login"] = txtUserName.Value;
            //elUsuario=(string)ViewState[""];
            FormsAuthenticationTicket tkt;
            string cookiestr;
            HttpCookie ck;
            tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
      DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
            cookiestr = FormsAuthentication.Encrypt(tkt);
            ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (chkPersistCookie.Checked)
                ck.Expires = tkt.Expiration;
            ck.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(ck);

            string strRedirect;
            strRedirect = Request["ReturnUrl"];
            if (strRedirect == null)
                strRedirect = "app/Default.aspx";
            Response.Redirect(strRedirect, true);
        }
        else
            Response.Redirect("login.aspx", true);
    }
    private bool ValidateUser(string userName, string passWord)
    {
        SqlConnection conn;
        SqlCommand cmd;
        string lookupPassword = null;

        // Buscar nombre de usuario no válido.
        // el nombre de usuario no debe ser un valor nulo y debe tener entre 1 y 15 caracteres.
        if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
        {
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
            return false;
        }

        // Buscar contraseña no válida.
        // La contraseña no debe ser un valor nulo y debe tener entre 1 y 25 caracteres.
        if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
        {
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
            return false;
        }

        try
        {
            // Consultar con el administrador de SQL Server para obtener una conexión apropiada
            // cadena que se utiliza para conectarse a su SQL Server local.
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SDE_ATConnectionString"].ConnectionString);
            conn.Open();

            // Crear SqlCommand para seleccionar un campo de contraseña desde la tabla de usuarios dado el nombre de usuario proporcionado.
            cmd = new SqlCommand("Select Cad_Clave from adm_tc_Usuario where Cod_Usuario=@userName", conn);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
            cmd.Parameters["@userName"].Value = userName;

            // Ejecutar el comando y capturar el campo de contraseña en la cadena lookupPassword.
            lookupPassword = (string)cmd.ExecuteScalar();

            // Comando de limpieza y objetos de conexión.
            cmd.Dispose();
            conn.Dispose();
        }
        catch (Exception ex)
        {
            // Agregar aquí un control de errores para la depuración.
            // Este mensaje de error no debería reenviarse al que realiza la llamada.
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
        }

        // Si no se encuentra la contraseña, devuelve false.
        if (null == lookupPassword)
        {
            // Para más seguridad, puede escribir aquí los intentos de inicio de sesión con error para el registro de eventos.
            return false;
        }

        // Comparar lookupPassword e introduzca passWord, usando una comparación que distinga mayúsculas y minúsculas.
        return (0 == string.Compare(lookupPassword, passWord, false));

    }
	
}