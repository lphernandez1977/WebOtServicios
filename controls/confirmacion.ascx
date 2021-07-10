<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="confirmacion.ascx.cs" Inherits="WebOtServicios.controls.confirmacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript" language="javascript">
    var ModalProgress = '';
    var botonProgress = '0';
</script>

<!-- hoja de estilo de Boton -->
<link type="text/css" rel="stylesheet" href="../Css/style.css" media="screen,projection" />
<link type="text/css" rel="stylesheet" href="../../Css/style.css" media="screen,projection" />


<!-- hoja de estilo de text -->
<link type="text/css" rel="stylesheet" href="../Css/style-textmodal.css" media="screen,projection" />
<link type="text/css" rel="stylesheet" href="../../Css/style-textmodal.css" media="screen,projection" />

<!-- hoja de estilo de modal popup-->
<link type="text/css" rel="stylesheet" href="../Css/style-modalpopup.css" media="screen,projection" />
<link type="text/css" rel="stylesheet" href="../../Css/style-modalpopup.css" media="screen,projection" />

<!-- control para centrar tabla -->
<style type="text/css">
div.centerTable{
        text-align: center;
}

div.centerTable table {
       margin: 0 auto;
       text-align: left;
}
</style>
<asp:ModalPopupExtender ID="ModalPopupInfo" runat="server" BackgroundCssClass="modalBackground"
    TargetControlID="pnlPopup" PopupControlID="pnlPopup">
</asp:ModalPopupExtender>


<asp:Panel ID="pnlPopup" runat="server" DefaultButton="btnAceptar" HorizontalAlign="Center">
    <div class="modalBackground-mensaje">
        <div class="centerTable">
            <table style="width: 30%;">
                <tr>
                    <td><asp:Image ID="imgicono" runat="server" ImageUrl="~/Css/images-controls/advertencia.png" Width="52px" Height="52px" /></td>
                    <td>
                        <div id="seccion">
                            <h1><asp:Label ID="LblTitle" runat="server" Text="INFORMACIÓN" CssClass="text-h1"></asp:Label></h1>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text="Mensaje" CssClass="text-16"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"  OnClick="btnAceptar_Click" CssClass="bntIng_01" />

            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  OnClick="btnCancelar_Click" CssClass="bntIng_01" />
            <br />
            <br />
        </div>
    </div>
</asp:Panel>

<!-- controla el evento postback -->
<script type="text/javascript">
    function fnClickOK(sender, e) {
        __doPostBack(sender, e);
    }
</script>
