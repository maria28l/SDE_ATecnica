using System;
using System.Web.Security;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["login"] = null;
        FormsAuthentication.SignOut();
        Response.Redirect("~/Login.aspx", true);
    }
}