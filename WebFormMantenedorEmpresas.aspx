<%@ Page Title="" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormMantenedorEmpresas.aspx.cs" Inherits="WebOtServicios.WebFormMantenedorEmpresas" %>

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
        <h1 class="text-center"><small>Mantenedor Empresas</small></h1>
        <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
        </small></h1>
    </div>
    <%--Ingreso Datos--%>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <label for="full_name_id" class="control-label">Rut Empresa</label>
                    <div class="form-inline">
                        <!-- Full Name -->
                        <asp:TextBox ID="TxtRut" Font-Names="rut" CssClass="form-control" MaxLength="8" runat="server" placeholder="99.999.999"></asp:TextBox>
                        <%--<asp:TextBox ID="TxtDv"  Font-Names="Dv"  CssClass="form-control" MaxLength="1" runat="server" placeholder="K" Width="50px"></asp:TextBox>--%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ValidationExpression="^[0-9]*\.?[0-9]+$"
                            runat="server"
                            CssClass="text-danger"
                            ErrorMessage="Digitar Numeros"
                            ControlToValidate="TxtRut"></asp:RegularExpressionValidator>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <!-- Full Name -->
                        <label for="full_name_id" class="control-label">Nombre Empresa</label>
                        <asp:TextBox ID="TxtNomEmpresa" CssClass="form-control" runat="server" placeholder="Nombre Empresa"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <%--grilla--%>
    <div class="divgrid">
        <div class="grid">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvDatos" runat="server" DataKeyNames="rut_empresa,nom_empresa"
                        AutoGenerateColumns="False"
                        AllowPaging="True"
                        AllowSorting="True"
                        HorizontalAlign="Center"
                        BackColor="White"
                        BorderColor="#CCCCCC"
                        BorderStyle="Solid"
                        BorderWidth="1px"
                        CaptionAlign="Top"
                        CellPadding="3"
                        CellSpacing="5"
                        EnablePersistedSelection="True" 
                        OnRowDataBound="GvDatos_RowDataBound" 
                        OnRowCommand="GvDatos_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Rut"
                                DataField="rut_empresa"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="120px"
                                Visible="true">
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Empresa"
                                DataField="nom_empresa"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="250px">
                                <HeaderStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Editar"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgSelect1"
                                        runat="server"
                                        ImageUrl="~/iconos/modificar.png"
                                        CommandName="Editar"
                                        CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                                    <asp:ImageButton ID="ImgSelect2"
                                        runat="server"
                                        ImageUrl="~/iconos/eliminar.png"
                                        CommandName="Eliminar"
                                        CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="form-group">
                <!-- Submit Button -->
                <h1 class="text-center"><small>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="BtnLimpiar_Click" />
                </small></h1>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdPnlControls" runat="server">
        <ContentTemplate>
            <%--enlace con los controles de usuario--%>
            <uc1:informacion runat="server" ID="info" />
            <uc2:infoespere runat="server" ID="infoespere" />
            <uc3:confirmacion runat="server" ID="confirmacion" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
        </div>
    </footer>
</asp:Content>
