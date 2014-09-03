using System;
using System.Web.Security;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["login"]==null) {
             FormsAuthentication.SignOut();
             FormsAuthentication.RedirectToLoginPage();
            return;
         }
    }
    protected string ObtenerNombreUsuario()
    {
        return Session["login"].ToString();
    }
}
