<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="espere.ascx.cs" Inherits="WebOtServicios.controls.espere" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<script type="text/javascript" language="javascript">
    var ModalProgress = '<%= ModalProgress.ClientID %>'; 
    var botonProgress = '0';
</script>

<script type="text/javascript" src="../controls/jsUpdateProgress.js"></script>
<script type="text/javascript" src="../../controls/jsUpdateProgress.js"></script>

<!-- hoja de estilo de text -->
<link type="text/css" rel="stylesheet" href="../Css/style-textmodal.css" media="screen,projection" />
<link type="text/css" rel="stylesheet" href="../../Css/style-textmodal.css" media="screen,projection" />

<!-- hoja de estilo de modal popup-->
<link type="text/css" rel="stylesheet" href="../Css/style-modalpopup.css" media="screen,projection" />
<link type="text/css" rel="stylesheet" href="../../Css/style-modalpopup.css" media="screen,projection" />

<!-- control para centrar tabla -->
<style type="text/Css">
div.centerTable{
        text-align: center;
}

div.centerTable table {
       margin: 0 auto;
       text-align: left;
}

	
</style>

<asp:ModalPopupExtender ID="ModalProgress" runat="server" BackgroundCssClass="modalBackground"
    TargetControlID="pnlProgress" PopupControlID="pnlProgress" >
</asp:ModalPopupExtender>

<asp:Panel ID="pnlProgress" runat="server" >
   
<%--    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
	<ProgressTemplate>--%>
        <div class="modalBackground-espere">
            <div class="centerTable">
                <table>
                    <tr>
                        <td><asp:Image ID="imgicono" runat="server" ImageUrl="~/Img/loading3.gif" Width="57px" Height="57px" /></td>
                        <td><h1><asp:Label ID="LblTitle" runat="server" Text="Trabajando"  CssClass="text-h1" Width="100%"></asp:Label></h1></td>
                    </tr>
                </table>
            </div>
            <div class="centerTable">
                <asp:Label ID="lblMensaje" runat="server" Text="Espere a que termine ..." CssClass="text-16"></asp:Label>
            </div>                
        </div>	    
<%--    </ProgressTemplate>
	</asp:UpdateProgress>--%>
</asp:Panel>


