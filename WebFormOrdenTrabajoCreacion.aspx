<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoCreacion.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoCreacion" %>--%>

<%@ Page Title="e-MAC Ingeniería Eléctrica y Mantenimiento Industrial" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoCreacion.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoCreacion" %>

<%--enlace con DLL AjaxControl --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--enlace con los controles de usuario--%>
<%@ Register Src="~/controls/informacion.ascx" TagName="informacion" TagPrefix="uc1" %>
<%@ Register Src="~/controls/espere.ascx" TagPrefix="uc2" TagName="espere" %>
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
        
        .auto-style3 {
            width: 67px;
        }

        .auto-style4 {
            width: 285px;
        }

        .auto-style5 {
            width: 151px;
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
                                <li><a href="WebFormOrdenTrabajoDetalle.aspx">Resumen de OT</a></li>
                            </ul>
                        </li>
                        <li>
                            <asp:Button ID="BtAdminLogout" runat="server" CssClass="btn btn-default navbar-btn" Text="Salir" OnClick="BtAdminLogout_Click" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="page-header">
        <h1 class="text-center"><small>Creación Ordenes De Trabajo</small></h1>
    </div>
    <div class="table-responsive">
        <div class="page-header">
            <h1 class="text-center"><small>Lista De Equipos</small></h1>
            <h3 class="text-center">
                <asp:Label ID="LblNomEmp" runat="server" Text="Label"></asp:Label></h3>
        </div>
        <table class="table table-hover">
            <%--            <tr>                
                <td class="auto-style1" colspan="3">Creación Ordenes De Trabajo</td>               
            </tr>--%>
            <tr>
                <td class="auto-style5">Tipo Equipo
                </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="CboTipoOT" runat="server" CssClass="selectpicker"></asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Button ID="BtnEquipos" runat="server" Text="Buscar Equipos" CssClass="btn btn-info" OnClick="BtnEquipos_Click" />
                </td>

            </tr>
            <tr>
                <td class="auto-style3">Periodo</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="CboPeriodos" runat="server" CssClass="selectpicker"></asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Button ID="BtnOt" runat="server" Text="Creación de OT" OnClick="BtnOt_Click" CssClass="btn btn-info"/>
                </td>
            </tr>
        </table>
    </div>
    <div class="divgrid">
        <div class="grid">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvDatos" runat="server" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="True" OnPageIndexChanging="GvDatos_PageIndexChanging" HorizontalAlign="Center" OnDataBound="GvDatos_DataBound" OnRowDataBound="GvDatos_RowDataBound">
                        <Columns>
                            <%--<asp:BoundField HeaderText="Rut Empresa" DataField="rut_empresa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <asp:BoundField HeaderText="Empresa" DataField="nom_empresa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Codigo" DataField="cod_equipos" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nombre" DataField="nom_equipos" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200px">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Style="position: static" TextAlign="Right" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--<asp:BoundField HeaderText="Operativo" DataField="operativo" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                            
                            <asp:TemplateField HeaderText="Periodo">
                                <HeaderTemplate>Periodo OT </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:DropDownList ID="cboCPeriodoGrilla" runat="server" Width="140px"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Rut Empresa"
                                DataField="rut_empresa"
                                HeaderStyle-Width="120px"
                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                            <asp:BoundField
                                HeaderText="Nombre Empresa"
                                DataField="nom_empresa"
                                HeaderStyle-Width="200px"></asp:BoundField>--%>
                            <%--               <asp:HyperLinkField
                                HeaderImageUrl="~/iconos/modificar.png"
                                HeaderStyle-Width="120px"
                                HeaderStyle-HorizontalAlign="Center"
                                DataNavigateUrlFields="rut_empresa"
                                DataNavigateUrlFormatString="WebFormOrdenTrabajoCreacion.aspx?pRut={0}"
                                Text="Nueva OT">
                            </asp:HyperLinkField>--%>
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
            <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
        </small></h1>
    <hr />
    <footer>
        <div class="container">
            <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
            <p>&copy; 2017 www.e-MAC.cl &middot; <a href="www.e-MAC.cl"></a></p>
        </div>
    </footer>
    <%--    <h3 class="text-center">
        <asp:Label ID="Label1" runat="server" Text="Label">Usuario Conectado</asp:Label>
        <asp:Label ID="LblUsuario" runat="server" Text="Label"></asp:Label>
    </h3>--%>
    <asp:UpdatePanel ID="UpdPnlControls" runat="server">
        <ContentTemplate>
            <%-- Control de Mensaje--%>
            <uc1:informacion ID="info" runat="server" />

            <%-- Control de Confirmacion--%>

            <%--siempre debe ser el ultimo por las variables que utiliza--%>
            <%--Control de Mensaje Espere--%>
            <uc2:espere runat="server" id="espere" />

            <uc3:confirmacion runat="server" ID="confirmacion" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
