<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoSeleccion.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoSeleccion" %>--%>

<%@ Page Title="e-MAC Ingeniería Eléctrica y Mantenimiento Industrial" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoSeleccion.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoSeleccion" %>

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
    <div class="page-header">
        <h1 class="text-center"><small>Seleccionar Orden De Trabajo</small></h1>
        <h3 class="text-center"><small>
            <asp:Label ID="LblNomEmp" runat="server" Text="Label">
            </asp:Label></small></h3>
        <h1 class="text-center"><small>
            <asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />
        </small></h1>
    </div>
    <hr />
    <div class="divgrid">
        <div class="grid">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvDatos" runat="server"
                        DataKeyNames="num_ot"
                        OnRowCommand="GvDatos_RowCommand"
                        AutoGenerateColumns="False"
                        AllowPaging="True"
                        AllowSorting="True"
                        OnPageIndexChanging="GvDatos_PageIndexChanging"
                        HorizontalAlign="Center"
                        OnSelectedIndexChanged="GvDatos_SelectedIndexChanged" OnRowDataBound="GvDatos_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Orden Nº" DataField="num_ot" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Equipos" DataField="Equipos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
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
<%--                            <asp:BoundField HeaderText="Nombre" DataField="nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <%--<asp:BoundField HeaderText="Ord. Pend." DataField="Ordenes_Pendientes" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px"></asp:BoundField>--%>
                            <%--<asp:HyperLinkField 
                                    HeaderImageUrl="~/iconos/manual.png"                                   
                                    DataNavigateUrlFields="rut_empresa" 
                                    DataNavigateUrlFormatString="WebFormOrdenTrabajoEmpresas.aspx?pRut={0}"
                                    HeaderStyle-Width="120px"
                                    text="Seleccionar"/>--%>
                            <%--                           <asp:BoundField HeaderText="Codigo" DataField="cod_equipos" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nombre" DataField="nom_equipos" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>--%>
                            <%--<asp:BoundField HeaderText="Operativo" DataField="operativo" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                            <%--                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Style="position: static" TextAlign="Right" HeaderStyle-Width="120px" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <%--<asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>--%>
                                    <asp:ImageButton ID="ImgSelect"
                                        runat="server"
                                        CommandName="Select"
                                        ImageUrl="~/iconos/modificar.png"
                                        CommandArgument="<%((GridViewRow)Container).RowIndex %>"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField
                                HeaderText="Nombre Empresa"
                                DataField="nom_empresa"
                                HeaderStyle-Width="200px"></asp:BoundField>
                                <asp:BoundField HeaderText="Rut Empresa"
                                DataField="rut_empresa"
                                HeaderStyle-Width="120px"
                                HeaderStyle-HorizontalAlign="Center">
                            </asp:BoundField>
                            <asp:HyperLinkField
                                HeaderImageUrl="~/iconos/modificar.png"
                                HeaderStyle-Width="120px"
                                HeaderStyle-HorizontalAlign="Center"
                                DataNavigateUrlFields="num_ot"
                                DataNavigateUrlFormatString="WebFormOrdenTrabajoDesarrollo.aspx?pNumOt={0}"
                                Text="Seleccionar OT">
                            <HeaderStyle HorizontalAlign="Center" Width="120px" />
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
</asp:Content>







<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divgrid">
            <div class="grid">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="GvDatos" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Rut Empresa" DataField="rut_empresa"></asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Empresa" DataField="nom_empresa" ></asp:BoundField>
                                <asp:BoundField HeaderText="Ordenes Pendientes" DataField="Ordenes_Pendientes" ></asp:BoundField>                             
                                <asp:HyperLinkField 
                                    HeaderImageUrl="~/iconos/manual.png"
                                    DataNavigateUrlFields="rut_empresa" 
                                    DataNavigateUrlFormatString="WebFormOrdenTrabajoEmpresas.aspx?pRut={0}"
                                    text="Seleccionar Orden"/>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>--%>
