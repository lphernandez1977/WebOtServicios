using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_Entidades;
using Dll_LgNegocios;
using System.Web.UI.HtmlControls;

namespace WebOtServicios
{
    public partial class WebFormMenu : System.Web.UI.Page
    {
        private LGN_FechaHoraServer _FechaHoraServidor = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Personal _ENT_Tb_Personal = new ENT_Tb_Personal();

        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("WebFormLogin.aspx");
            }

            _ENT_Tb_Personal.rut_personal = Convert.ToInt32(UsuarioId);
            _ENT_Tb_Personal.nom_empleado = Convert.ToString(NombreUsuario);
            _ENT_Tb_Personal.ape_empleado = Convert.ToString(ApellidoUsuario);
            _ENT_Tb_Personal.cargo = Convert.ToString(PerfilUsuario);

            LblUsuario.Text = NombreUsuario + " " + ApellidoUsuario;

        }

        protected void BtAdminLogout_Click(object sender, EventArgs e)
        {
            //Session["RutUsuario"] = null;
            //Session["NombreUsuario"] = null;
            //Session["ApellidoUsuario"] = null;
            //Session["PerfilUsuario"] = null;            
            bool login = false;
            this.Response.Write("<script language='JavaScript'>window.alert('" + _ENT_Tb_Personal.rut_personal + "');</script>");
            //recupero fecha y hora servidor
            _ent_Tb_Registro_Login.fecha_ter_login = Convert.ToDateTime(_FechaHoraServidor.Selecciona_FechaHoraServer());
            //inserto hora y fecha de registro usuario
            login = _lgn_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(_ENT_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_ter_login);
            Session.Remove("RutUsuario");
            Session.Remove("NombreUsuario");
            Session.Remove("ApellidoUsuario");
            Session.Remove("PerfilUsuario") ;
            Response.Redirect("~/WebFormLogin.aspx");
        }
    }
}