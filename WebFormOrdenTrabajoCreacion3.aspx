<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormOrdenTrabajoCreacion3.aspx.cs" Inherits="WebOtServicios.WebFormOrdenTrabajoCreacion3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="icon" type="image/png" href="../Img/home_32.ico" sizes="32x32" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
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
                        <h3 class="text-center">
                <asp:Label ID="LblNomEmp" runat="server" Text="Label"></asp:Label></h3>
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
                    <asp:GridView ID="GvDatos" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPageIndexChanging="GvDatos_PageIndexChanging" HorizontalAlign="Center">
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
    </form>
</body>
</html>
