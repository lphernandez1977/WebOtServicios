<%@ Page Title="e-MAC Ingeniería Eléctrica y Mantenimiento Industrial" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormMenu.aspx.cs" Inherits="WebOtServicios.WebFormMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>e-MAC Ingeniería Eléctrica y Mantenimiento Industrial</title>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Custom-Cs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="navbar navbar-default navbar-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                        <li role="presentation">
                            <a role="menuitem" tabindex="-1" href="#">Acción</a>
                        </li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right ">
                        <li><a href="WebFormMenu.aspx">Inicio</a></li>
                        <%--<li><a href="WebFormOrdenTrabajo.aspx">Generar Ordenes De Trabajo</a></li>--%>
                        <%--<li><a href="WebFormEquipos.aspx">Lista De Equipos</a></li>--%>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Generar Ordenes De Trabajo<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <%--<li class="dropdown-header">Men</li>
                                <li role="separator" class="divider"></li>--%>
                                <li><a href="WebFormOrdenTrabajo.aspx">Creación De OT</a></li>
                                <li><a href="WebFormOrdenTrabajoCreacionMan.aspx">Creación De OT Manuales</a></li>
                                <li><a href="WebFormMantenedorEmpresas.aspx">Mantenedor Empresas</a></li>
                                <li><a href="WebFormMantenedorPersonal.aspx">Mantenedor Personal</a></li>
                                <li><a href="WebFormMantenedorEquipos.aspx">Mantenedor Equipos</a></li>
                                <li><a href="WebFormMantenedorActividades.aspx">Mantenedor Actividades</a></li>
                                <li><a href="WebFormMantenedorOT.aspx">Mantenedor de Ordenes</a></li> 
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Actividades por OT<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <%--<li class="dropdown-header">Men</li>--%>
                                <%--<li role="separator" class="divider"></li>--%>
                                <li id="restringir2" runat="server"><a href="WebFormOrdenTrabajoDetalle.aspx">Resumen de OT</a></li>
                            </ul>
                        </li>
                        <li>
                            <asp:Button ID="BtAdminLogout" runat="server" Class="btn btn-default navbar-btn" Text="Salir" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div>
        <div style="text-align: center; width: 100%; float: left;">
            <img alt="" src="../Img/logo-cloud.png" />
        </div>
    </div>
    <hr />
    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>
                &copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a>               
            </p>
            <p>
                <asp:Label ID="LblUsuario" runat="server" Text="Label" CssClass="text-right"></asp:Label>
            </p>
        </div>
    </footer>
</asp:Content>
