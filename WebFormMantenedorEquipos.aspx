<%@ Page Title="" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormMantenedorEquipos.aspx.cs" Inherits="WebOtServicios.WebFormMantenedorEquipos" %>

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
        <h1 class="text-center"><small>Mantenedor Equipos</small></h1>
        <h1 class="text-center"><small>
            <%--<asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>
        </small></h1>
    </div>
    <%--Ingreso Datos--%>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>--%>
                    <div class="form-group">
                        <label for="full_name_id" class="control-label">Empresa</label>
                        <asp:DropDownList ID="CboEmpresa" runat="server" CssClass="selectpicker"></asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="Button1_Click" />
                    </div>
<%--                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label for="full_name_id" class="control-label">Dispositivo</label>
                        <asp:DropDownList ID="CboDisp" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <%--<label for="full_name_id" class="control-label">Nombre Corto</label>--%>
                        <asp:TextBox ID="TxtCodEquipo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="TxtNcorto" Font-Names="rut" CssClass="form-control" MaxLength="50" runat="server" placeholder="Nom Corto" Visible="false"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <label for="full_name_id" class="control-label">Equipo</label>
                        <asp:TextBox ID="TxtEquipo" CssClass="form-control" MaxLength="50" runat="server" placeholder="Nom Equipo"></asp:TextBox>
                        <asp:TextBox ID="TxtNomDispo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="form-group">
                <!-- Submit Button -->
                <h1 class="text-center"><small>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="BtnLimpiar_Click" />
                    <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
                </small></h1>
            </div>
        </div>
    </div>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <%--grilla--%>
            <div class="divgrid">
                <div class="grid">
                    <asp:GridView ID="GvDatos" runat="server"
                        DataKeyNames="rut_empresa,nom_empresa,cod_equipos,nom_equipos,nom_corto,Nom_Disp,Cod_Nom_Dispo"
                        AutoGenerateColumns="False"
                        AllowPaging="False"
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
                                HeaderStyle-Width="80px"
                                Visible="false">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nombre"
                                DataField="nom_empresa"
                                Visible="false"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="150px">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="CodEquipo"
                                Visible="false"
                                DataField="cod_equipos"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="150px">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Equipo"
                                DataField="nom_equipos"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="150px">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nom Corto" 
                                Visible="false"                    
                                DataField="nom_corto"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="150px">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Dispositivo" 
                                Visible="true"
                                DataField="Nom_Disp"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Cod Disp"
                                Visible="false"
                                DataField="Cod_Nom_Dispo"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Editar"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgSelect1"
                                        runat="server"
                                        ImageUrl="~/iconos/modificar.png"
                                        CommandName="Editar"
                                        CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar"
                                ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                                    <asp:ImageButton ID="ImgSelect2"
                                        runat="server"
                                        ImageUrl="~/iconos/eliminar.png"
                                        CommandName="Eliminar"
                                        CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
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
                </div>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>


    <hr />
    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
        </div>
    </footer>

    <asp:UpdatePanel ID="UpdPnlControls" runat="server">
        <ContentTemplate>
            <%-- Control de Mensaje--%>
            <uc1:informacion ID="info" runat="server" />
            <%-- Control de Confirmacion--%>
            <%--siempre debe ser el ultimo por las variables que utiliza--%>
            <%--Control de Mensaje Espere--%>
            <uc2:infoespere runat="server" ID="infoespere" />

            <uc3:confirmacion runat="server" ID="confirmacion" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
