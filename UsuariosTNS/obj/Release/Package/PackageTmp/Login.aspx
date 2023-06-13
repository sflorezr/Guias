<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UsuariosTNS.Login" %>    

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>COOMULPINORT</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0,maximum.scale=1.0,minimum-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <style type="text/css">
        #form1 {
            height: 201px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div id="login">        
        <h3 class="text-center text-white pt-5">INICIAR SESION</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                            <h3 class="text-center text-info">Login</h3>                             
                            <div class="form-group">
                                <label for="username" class="text-info">Usuario:</label><br>
                                <asp:TextBox ID="Username" cssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info">Contraseña:</label><br>
                                <asp:TextBox ID="Password" name="password" CssClass="form-control" type="password" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" runat="server" Text="Entrar" CssClass="btn btn-info btn-md" CommandName="Login" OnClick="Button1_Click" />
                            </div>   
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
