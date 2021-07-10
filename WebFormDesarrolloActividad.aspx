<%@ Page Title="e-MAC Ingeniería Eléctrica y Mantenimiento Industrial" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormDesarrolloActividad.aspx.cs" Inherits="WebOtServicios.WebFormDesarrolloActividad" %>

<%--enlace con DLL AjaxControl --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--enlace con los controles de usuario--%>
<%@ Register Src="~/controls/informacion.ascx" TagName="informacion" TagPrefix="uc1" %>
<%@ Register Src="~/controls/espere.ascx" TagName="infoespere" TagPrefix="uc2" %>
<%@ Register Src="~/controls/confirmacion.ascx" TagPrefix="uc3" TagName="confirmacion" %>

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
                        <li><a role="menu" tabindex="-1" href="WebFormMenu.aspx">Home</a></li>
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
                                <li><a href="WebFormOrdenTrabajoDetalle.aspx">Resumen de OT</a></li>
                            </ul>
                        </li>
                        <li>
                            <asp:Button ID="BtAdminLogout" runat="server" Class="btn btn-default navbar-btn" Text="Salir" OnClick="BtAdminLogout_Click" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="page-header">
        <h1 class="text-center"><small>Actividades Orden De Trabajo </small></h1>
        <h1 class="text-center"><small>Nº<asp:Label ID="LblNumOT" runat="server" Text="Label"></asp:Label>
        </small></h1>
        <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
            <asp:Button ID="Button2" runat="server" Text="Terminar Tarea" CssClass="btn btn-success" OnClick="BtnFinJob_Click" />
        </small></h1>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="text-center"><small>Orden De Trabajo Nº 
                        <asp:Label ID="LblNumOT_Act" runat="server" CssClass="">
                        </asp:Label>
                    </small></h2>
                </div>
                <div class="panel-body">
                    <%--<h3 class="text-center"><small>
                        <asp:Label ID="LblNumOT_Act" runat="server" CssClass="">
                        </asp:Label>
                    </small></h3>--%>
                    <h2 class="text-center"><small>Actividad Nº
                        <asp:Label ID="LblCod" runat="server" CssClass="">
                        </asp:Label>
                    </small></h2>
                    <h3 class="text-center"><small>
                        <asp:Label ID="LblActividad" runat="server" CssClass="">
                        </asp:Label>
                    </small></h3>
                    <h3 class="text-center"><small>
                        <asp:Label ID="LblComponente" runat="server" CssClass="">
                        </asp:Label>
                    </small></h3>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="text-center"><small>Observación Actividad
                    </small></h2>
                </div>
                <div class="panel-body">
                    <h3 class="text-center"><small>
                        <asp:TextBox ID="TxtObserActividad" Font-Names="TextActividad" CssClass="form-control" runat="server" placeholder="Max 250" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </small></h3>
                </div>
            </div>
        </div>
    </div>

    <%--   <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="text-center"><small>Componente            
                    </small></h2>
                </div>
                <div class="panel-body">
                    <h3 class="text-center"><small>
                        <asp:Label ID="LblComponente" runat="server" CssClass="">
                        </asp:Label>
                    </small></h3>
                </div>
            </div>
        </div>
    </div>--%>

    <%--    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="text-center"><small>Actividad            
                    </small></h2>
                </div>
                <div class="panel-body">
                    <h3 class="text-center"><small>
                        <asp:Label ID="LblActividad" runat="server" CssClass="">
                        </asp:Label>
                    </small></h3>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-6 col-md-offset-3 text-center">
            <%--<asp:Button ID="BtnBack2" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>

            <%--<asp:Button ID="Button2" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>

            <%--<asp:Button ID="BtnFinJob" runat="server" Text="Terminar Tarea" CssClass="btn btn-success" OnClick="BtnFinJob_Click" />--%>
            <%--            <h2 class="text-center"><small>Actividad</small></h2>
            <h3 class="text-center"><small>
                <asp:Label ID="Label2" runat="server" CssClass="">
                </asp:Label>
            </small></h3>--%>
        </div>
    </div>
    <%--        <div class="col-md-10">
            <h3 class="text-left"><small>
                <asp:Label ID="LblActividad" runat="server" CssClass="">
                </asp:Label>
            </small></h3>
        </div>--%>

    <asp:UpdatePanel ID="UpdPnlControls" runat="server">
        <ContentTemplate>
            <%-- Control de Mensaje--%>
            <uc1:informacion ID="info" runat="server" />

            <%--siempre debe ser el ultimo por las variables que utiliza--%>
            <%--Control de Mensaje Espere--%>
            <uc2:infoespere runat="server" ID="infoespere" />

            <uc3:confirmacion runat="server" ID="confirmacion" />

        </ContentTemplate>
    </asp:UpdatePanel>


    <hr />
    <footer>

        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
            <%--            <h3 class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Label">Usuario Conectado</asp:Label>
                <asp:Label ID="LblUsuario" runat="server" Text="Label"></asp:Label>
            </h3>--%>
        </div>
    </footer>

</asp:Content>
