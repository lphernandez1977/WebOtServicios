<%@ Page Title="" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormMantenedorActividades.aspx.cs" Inherits="WebOtServicios.WebFormMantenedorActividades" %>

<%--enlace con DLL AjaxControl --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--enlace con los controles de usuario--%>
<%@ Register Src="~/controls/informacion.ascx" TagName="informacion" TagPrefix="uc1" %>
<%@ Register Src="~/controls/espere.ascx" TagName="infoespere" TagPrefix="uc2" %>
<%@ Register Src="~/controls/confirmacion.ascx" TagName="confirmacion" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>e-MAC Ingeniería Eléctrica y Mantenimiento Industrial</title>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Custom-Cs.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--menu--%>
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
                        <li><a role="menu" tabindex="-1" href="WebFormMenu.aspx">Inicio</a></li>
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
    <%--encabezado--%>
    <div class="page-header">
        <h1 class="text-center"><small>Mantenedor Actividades</small></h1>
        <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
        </small></h1>
    </div>

    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <!-- Full Name -->
                        <%--<asp:TextBox ID="TxtCargo" Font-Names="rut" CssClass="form-control" MaxLength="8" runat="server" placeholder="Cargo"></asp:TextBox>--%>
                        <label for="full_name_id" class="control-label">Dispositivo</label>
                        <asp:DropDownList ID="CboDispositivo" CssClass="form-control" runat="server" Width="180px"></asp:DropDownList>
                        <label for="full_name_id" class="control-label">Elemento</label>
                        <asp:DropDownList ID="CboAccesorio" CssClass="form-control" runat="server" Width="180px"></asp:DropDownList>
                        <label for="full_name_id" class="control-label">Empresa</label>
                        <asp:DropDownList ID="CboEmpresa" CssClass="form-control" runat="server" Width="180px"></asp:DropDownList>
                        <label for="full_name_id" class="control-label">Periodo</label>
                        <asp:DropDownList ID="CboPeriodo" CssClass="form-control" runat="server" Width="180px"></asp:DropDownList>
                        <label for="full_name_id" class="control-label">Componente</label>
                        <asp:TextBox ID="TxtComponente" CssClass="form-control" MaxLength="50" runat="server" placeholder="Componente" Width="300px"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <h2 class="text-center"><small>Actividad
            </small></h2>
            <div class="panel-body">
                <h3 class="text-center"><small>
                    <asp:TextBox ID="TxtObserActividad" Font-Names="TextActividad" CssClass="form-control" runat="server" placeholder="Max 250" TextMode="MultiLine" Rows="10"></asp:TextBox>
                </small></h3>
            </div>
        </div>
    </div>
    <h1 class="text-center"><small>
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardar_Click" />
        <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="BtnLimpiar_Click" />
    </small></h1>
    <asp:UpdatePanel ID="UpdPnlControls" runat="server">
        <ContentTemplate>
            <%--enlace con los controles de usuario--%>
            <uc1:informacion runat="server" ID="info" />
            <uc2:infoespere runat="server" ID="infoespere" />
            <uc3:confirmacion runat="server" ID="confirmacion" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
        </div>
    </footer>
</asp:Content>
