<%@ Page Title="" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormMantenedorOTDetalle.aspx.cs" Inherits="WebOtServicios.WebFormMantenedorOTDetalle" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 260px;
            height: 84px;
        }
    </style>
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
                        <li><a role="menu" tabindex="-1" href="WebFormMenu.aspx">Inicio</a></li>
                        <%--enlace con DLL AjaxControl --%>                        <%--enlace con los controles de usuario--%>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Generar Ordenes De Trabajo<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <%--<li><a href="WebFormOrdenTrabajo.aspx">Generar Ordenes De Trabajo</a></li>--%>
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
                                <%--<li><a href="WebFormEquipos.aspx">Lista De Equipos</a></li>--%>                                <%--<li class="dropdown-header">Men</li>
                                <li role="separator" class="divider"></li>--%>
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
        <h1 class="text-center"><small>Seleccionar Orden De Trabajo</small></h1>
        <h3 class="text-center"><small>
            <asp:Label ID="LblNomEmp" runat="server" Text="Label">
            </asp:Label></small></h3>
        <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
        </small></h1>
    </div>

    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <%--<label for="full_name_id" class="control-label">Orden De Trabajo</label>--%>
                    <div class="form-group">
                        <!-- Full Name -->

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label for="full_name_id" class="control-label">Orden De Trabajo</label>
                        <asp:TextBox ID="TxtOT" CssClass="form-control" MaxLength="50" runat="server" placeholder="OT" Width="120px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="IdNumeros"
                            ValidationExpression="^[0-9]*\.?[0-9]+$"
                            runat="server"
                            CssClass="text-danger"
                            ErrorMessage="Digitar Sólo Números"
                            ControlToValidate="TxtOT"></asp:RegularExpressionValidator>
                        </p>
                        <label for="full_name_id" class="control-label">Estado</label>
                        <asp:DropDownList ID="CboEstado" CssClass="form-control" runat="server" Width="150px"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-inline">
                        <label for="full_name_id" class="control-label">F.Inicio</label>
                        <asp:TextBox ID="TxtFecIni" CssClass="form-control" MaxLength="50" runat="server" placeholder="Inicio" Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFecIni" FirstDayOfWeek="Monday"></asp:CalendarExtender>
                        <label for="full_name_id" class="control-label">F.Termino</label>
                        <asp:TextBox ID="TxtFecTer" CssClass="form-control" MaxLength="50" runat="server" placeholder="Termino" Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtFecTer" FirstDayOfWeek="Monday"></asp:CalendarExtender>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="form-group">
                <!-- Submit Button -->
                <h1 class="text-right"><small>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Modificar" CssClass="btn btn-info" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="BtnBuscar_Click" />
                    <asp:Button ID="BtnLimpiar" runat="server" Text="Borrar" CssClass="btn btn-info" OnClick="BtnLimpiar_Click" />
                </small></h1>
            </div>
        </div>
    </div>
    <hr />
    <div class="divgrid">
        <div class="grid">
            <%--<li role="separator" class="divider"></li>--%>
            <asp:GridView ID="GvDatos" runat="server"
                DataKeyNames="num_ot,Nom_Estado"
                AutoGenerateColumns="False"
                AllowPaging="False"
                AllowSorting="True"
                OnPageIndexChanging="GvDatos_PageIndexChanging"
                HorizontalAlign="Center"
                OnRowCommand="GvDatos_RowCommand"
                OnRowDataBound="GvDatos_RowDataBound"
                PageSize="12">
                <Columns>
                    <asp:BoundField HeaderText="Fec Creación" DataField="fecha_creacion_ot" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Orden Nº" DataField="num_ot" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Equipos" DataField="Equipos" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Periodo" DataField="Nom_Periodo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Estado" DataField="Nom_Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tecnico" DataField="rut_personal" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tecnico" DataField="rut_personal" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tarea" DataField="TareaPend" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                            <asp:ImageButton ID="ImgSelect1"
                                runat="server"
                                CommandName="Editar"
                                ImageUrl="~/iconos/modificar.png"
                                CommandArgument="<%((GridViewRow)Container).RowIndex %>"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exportar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                            <asp:ImageButton ID="ImgSelect2"
                                runat="server"
                                CommandName="Exportar"
                                ImageUrl="~/iconos/pdf.png"
                                CommandArgument="<%((GridViewRow)Container).RowIndex %>"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tareas Pendientes" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                            <asp:ImageButton ID="ImgSelect3"
                                runat="server"
                                CommandName="TareasPendientes"
                                ImageUrl="~/iconos/pdf.png"
                                CommandArgument="<%((GridViewRow)Container).RowIndex %>"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <%--<asp:TextBox ID="TxtCargo" Font-Names="rut" CssClass="form-control" MaxLength="8" runat="server" placeholder="Cargo"></asp:TextBox>--%>
        </div>
    </div>

    <hr />
    <footer>
        <div class="container">
            <%--            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; /a></p>
        </div>
    </footer>
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
</asp:Content>
