<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html class="bg-white">
    <head>
        <meta charset="UTF-8">
        <title>Nitlapan Sde At | Inicio De Sesi&oacute;n</title>
        <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
        <!-- bootstrap 3.0.2 -->
        <link href="/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- font Awesome -->
        <link href="/assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Theme style -->
        <link href="/assets/css/AdminLTE.css" rel="stylesheet" type="text/css" />

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
</head>
<body class="bg-white">
    <div class="form-box" id="login-box">
        <div class="header">Iniciar Sesi&oacute;n</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <div class="form-group">
                    <input id="txtUserName" type="text" runat="server" class="form-control" placeholder="Usuario"/>
                    <asp:RequiredFieldValidator ControlToValidate="txtUserName"
                       Display="Static" ErrorMessage="*" runat="server" 
                       ID="vUserName" />
                </div>
                <div class="form-group">
                    <input id="txtUserPass" type="password" runat="server" class="form-control" placeholder="Contraseña"/>
                    <asp:RequiredFieldValidator ControlToValidate="txtUserPass"
                      Display="Static" ErrorMessage="*" runat="server" 
                      ID="vUserPass" />
                </div>          
                <div class="form-group">
                    <asp:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /> Recordarme
                </div>
            </div>
            <div class="footer">                                                               
                <button type="submit" class="btn bg-azul-cielo btn-block" runat="server" onserverclick="Iniciar">Entrar</button>
                <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
            </div>
        </form>
    </div>


    <!-- jQuery 2.0.2 -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="/assets/js/bootstrap.min.js" type="text/javascript"></script>     
           

</body>
</html>
