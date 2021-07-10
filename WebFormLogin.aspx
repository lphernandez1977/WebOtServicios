<%@ Page Title="e-MAC Ingeniería Eléctrica y Mantenimiento Industrial" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="WebOtServicios.WebFormLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Custom-Cs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--- Sign in start  -->
    <div class="container">
        <div class="form-horizontal">
            <h2>Control De Usuarios</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Rut"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtuser" CssClass="form-control" runat="server" placeholder="xxxxxxxx" MaxLength="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="El Rut es obligatorio !" ControlToValidate="txtuser"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="IdNumeros"
                        ValidationExpression="^[0-9]*\.?[0-9]+$"
                        runat="server"
                        CssClass="text-danger"
                        ErrorMessage="Digitar Numeros"
                        ControlToValidate="txtuser"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Password"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtpass" CssClass="form-control" runat="server" TextMode="Password" placeholder="xxxx" MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="La Contraseña es obligatorio !" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ValidationExpression="^[0-9]*\.?[0-9]+$"
                        runat="server"
                        CssClass="text-danger"
                        ErrorMessage="Digitar Numeros"
                        ControlToValidate="txtpass"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-default" OnClick="BtnIngresar_Click" />
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/SignUp.aspx">Sign Up</asp:LinkButton>--%>
                </div>
            </div>
        </div>
    </div>

    <hr />

    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
        </div>
    </footer>
    <!--- Footer -->
</asp:Content>


<%--  <div style="text-align: center; width: 100%;">
        <table align="center" id="login" style="text-align: center; border: #C0C0C0 0px solid; width: 70%">
            <tr>
                <td colspan="3" class="cabe_03">&nbsp;INICIO DE SESI&Oacute;N</td>
            </tr>
            <tr>
                <td style="width: 80%;" class="cabe_02">
                    <asp:TextBox ID="txtuser" runat="server" CssClass="text_01" placeholder="Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80%">
                    <asp:TextBox ID="txt_RutError" runat="server" CssClass="error_01" Text="Debe Ingresar Usuario" Width="158px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80%" class="cab_02">
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="text_01" placeholder="Contraseña"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 80%">
                    <asp:TextBox ID="txt_ClaveError" runat="server" CssClass="error_01" Text="Debe Ingresar Contraseña" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" CssClass="bntIng_01" OnClick="BtnIngresar_Click" />
                </td>
            </tr>
        </table>

    </div>--%>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="WebOtServicios.WebFormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- librería que declara la función para validar Rut -->
    <script type="text/javascript" src="../js/validarut.js"></script>

    <script type="text/javascript">
        jQuery(function ($) {
            $("#txtuser").mask("99999999-");
        })
    </script>

    <style>
        input:focus {
            background-color: #FFEBCD;
            border: 2px solid #CB8B07;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>
                Username
            </label>
            <asp:TextBox ID="txtuser" runat="server" MaxLength="10"> </asp:TextBox>
            <label>
                Password
            </label>
            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
            <asp:Button ID="BtnIngresar" runat="server" Text="Aceptar" OnClick="BtnIngresar_Click" />
        </div>
    </form>
</body>
</html>--%>
