<%@ Page Title="" Language="C#" MasterPageFile="~/e-MAC.Master" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoCreacionMan.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoCreacionMan" %>

<%--enlace con DLL AjaxControl --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--enlace con los controles de usuario--%>
<%@ Register Src="~/controls/informacion.ascx" TagName="informacion" TagPrefix="uc1" %>
<%@ Register Src="~/controls/espere.ascx" TagName="infoespere" TagPrefix="uc2" %>
<%@ Register Src="~/controls/confirmacion.ascx" TagName="confirmacion" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>e-MAC Ingeniería Eléctrica y Mantenimiento Industrial</title>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Custom-Cs.css" rel="stylesheet" />
    <link href="Css/Clase_Grilla.css" rel="stylesheet" />
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
        <h1 class="text-center"><small>Creación Ordenes De Trabajo Manual</small></h1>
        <h1 class="text-center"><small>
            <%--<asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>
        </small></h1>
    </div>
    <%--Ingreso Datos--%>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <%--<label for="full_name_id" class="control-label">Rut Empresa</label>--%>
                    <div class="form-inline">
                        <label for="full_name_id" class="control-label">Rut</label>
                        <asp:TextBox ID="TxtRutEmp" Font-Names="rut" CssClass="form-control" MaxLength="8" runat="server" placeholder="99.999.999" Width="100px"></asp:TextBox>
                        <%--<asp:TextBox ID="TxtDv" Font-Names="Dv" CssClass="form-control" MaxLength="1" runat="server" placeholder="K" Width="50px"></asp:TextBox>--%>
                        <label for="full_name_id" class="control-label">Nombre</label>
                        <asp:TextBox ID="TxtNombreEmp" Font-Names="TxtNombreEmp" CssClass="form-control" MaxLength="50" runat="server" placeholder="Empresa"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--<div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <label for="full_name_id" class="control-label">Nombre Empresa</label>
                    <div class="form-group">
                        <!-- Full Name -->
                        <asp:TextBox ID="TxtNombreEmp" Font-Names="TxtNombreEmp" CssClass="form-control" MaxLength="50" runat="server" placeholder="Empresa"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <label for="full_name_id" class="control-label">Periodo</label>
                    <div class="form-group">
                        <asp:TextBox ID="TxtPeriodo" Font-Names="TxtPeriodo" CssClass="form-control" MaxLength="50" runat="server" placeholder="Periodo"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <label for="full_name_id" class="control-label">Nombre Equipo</label>
                    <div class="form-group">
                        <asp:TextBox ID="TxtEquipo" Font-Names="TextEquipo" CssClass="form-control" MaxLength="100" runat="server" placeholder="Equipo"></asp:TextBox>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-md-offset-3">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <label for="full_name_id" class="control-label">Detalle Actividad</label>
                    <div class="form-inline">
                        <asp:TextBox ID="TxtActividad" Font-Names="TextActividad" CssClass="form-control" runat="server" placeholder="Max 250" TextMode="MultiLine" Rows="5" Width="80%"></asp:TextBox>
                        <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" CssClass="btn btn-info" OnClick="BtnAgregar_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
    <div class="page-header">
        <h1 class="text-center"><small>Items Ordenes De Trabajo Manual</small></h1>
        <h1 class="text-center"><small>
            <%--<asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>
        </small></h1>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="divgrid">
                <div class="grid">
                    <asp:GridView ID="grdDatos" runat="server" 
                        Style="border-style: solid; border-width: 1px; font-family: Verdana; font-size: 9pt;"
                        AutoGenerateColumns="false" CssClass="Griddiag" Width="50%"
                        HorizontalAlign="Center"
                        OnRowDataBound="grdDatos_RowDataBound"
                        OnRowCommand="grdDatos_RowCommand" 
                        AllowSorting="True">
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Rut" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblRut" runat="server"
                                    Text='<%# DataBinder.Eval(Container, "DataItem.Rut") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre" HeaderStyle-CssClass="campoDescripcion_01" ItemStyle-CssClass="campoDescripcion_01">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Periodo" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblPeriodo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Periodo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Pos" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblPos" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Pos") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Equipo" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblEquipo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Equipo") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actividad" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblActividad" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Actividad") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="camponumero_01" ItemStyle-CssClass="camponumero_01">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:ImageButton ID="btnEliminar" runat="server" Text="Agregar" ImageUrl="~/iconos/eliminar.png"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="Eliminar" />
                                    </div>
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
    <hr />
    <div class="page-header">
        <h1 class="text-center"><small>Ordenes De Trabajo Manual</small></h1>
        <h1 class="text-center"><small>
            <%--<asp:Button ID="BtnBack" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="BtnBack_Click" />--%>
        </small></h1>
    </div>

    
    <div class="divgrid">
            <asp:GridView ID="GvDatos" runat="server" 
                Style="border-style: solid; border-width: 1px; font-family: Verdana; font-size: 9pt;"
                GridLines="None"                
                DataKeyNames="num_ot,RutEmp"
                AutoGenerateColumns="False"
                AllowPaging="True"
                AllowSorting="True"
                CssClass="Griddiag"
                PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt"
                PageSize="20"
                OnPageIndexChanging="GvDatos_PageIndexChanging"
                HorizontalAlign="Center"
                OnRowCommand="GvDatos_RowCommand"
                OnRowDataBound="GvDatos_RowDataBound" OnSorting="GvDatos_Sorting" CellPadding="4" ForeColor="#333333"
                >
<AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:BoundField DataField="Num_Ot" HeaderText="Orden Nº" SortExpression="Num_Ot" >
                    <HeaderStyle Height="50px" />
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RutEmp" HeaderText="Rut"  SortExpression="RutEmp">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NomEmp" HeaderText="Empresa" SortExpression="NomEmp">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Periodo" HeaderText="Periodo" SortExpression="Periodo">

                    <ItemStyle Width="150px" />
                    </asp:BoundField>

                <%--<asp:BoundField HeaderText="Orden Nº" DataField="Num_Ot" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px" Visible="true">
                <HeaderStyle Width="120px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Rut" DataField="RutEmp" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px" Visible="false">
                <HeaderStyle Width="120px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Empresa" DataField="NomEmp" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                <HeaderStyle Width="120px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Periodo" DataField="Periodo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>--%>

                <asp:TemplateField HeaderText="Exportar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                    <ItemTemplate>                        
                        <asp:ImageButton ID="ImgSelect"
                        runat="server"
                        CommandName="Exportar"
                        ImageUrl="~/iconos/pdf.png"
                        CommandArgument="<%((GridViewRow)Container).RowIndex %>"></asp:ImageButton>
                    </ItemTemplate>

<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                </Columns>

                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Size="Large" Height="50px"></PagerStyle>
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                
            </asp:GridView>
            <%--<asp:GridView ID="GvDatos" runat="server"
                DataKeyNames="num_ot,RutEmp"
                AutoGenerateColumns="False"
                AllowPaging="False"
                AllowSorting="True"
                OnPageIndexChanging="GvDatos_PageIndexChanging"
                HorizontalAlign="Center"
                OnRowCommand="GvDatos_RowCommand"
                OnRowDataBound="GvDatos_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Orden Nº" DataField="Num_Ot" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px" Visible="true">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Rut" DataField="RutEmp" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px" Visible="false">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Empresa" DataField="NomEmp" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <HeaderStyle Width="120px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Periodo" DataField="Periodo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Exportar" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:Button ID="btnButton" runat="server" Text="Detalle" commandname="Select"/>
                            <asp:ImageButton ID="ImgSelect"
                                runat="server"
                                CommandName="Exportar"
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
            </asp:GridView>--%>

            <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
    </div>


    <hr/>
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
