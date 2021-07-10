using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_LgNegocios;
using Dll_Entidades;
using System.Data;
using System.Threading;

namespace WebOtServicios
{
    public partial class WebFormOrdenTrabajo : System.Web.UI.Page
    {
        private LGN_FechaHoraServer _FechaHoraServidor = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Personal _ENT_Tb_Personal = new ENT_Tb_Personal();

        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private LGN_Tb_Empresas _lgn_Tb_Empresas = new LGN_Tb_Empresas();
        DataSet ds = new DataSet();
   
        protected void Page_Load(object sender, EventArgs e)
        {            
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("~/WebFormLogin.aspx");

                //valido que atributos
                if (PerfilUsuario == "Tecnico")
                {
                    //Response.Write("<script language=javascript>confirm('No tiene atributos para ver este menu');</script>");                   
                    //info.ShowMessage("No tiene permiso para ver este menu", controls.informacion.tipoMensaje.Mensaje);
                    //Thread.Sleep(2000);
                    Response.Redirect("~/WebFormMenu.aspx");
                }
            }

            //valido usuario
            if (PerfilUsuario == "Tecnico")
            {
                Response.Redirect("WebFormMenu.aspx");
            }

            //LblUsuario.Text = NombreUsuario + " " + ApellidoUsuario;

            //mostrar empresas
            LlenarGrid();           
        }

        private void LlenarGrid() 
        {
            ds = _lgn_Tb_Empresas.Selecciona_ListaEmpresas();

            try 
            {
                if (ds != null) 
                {
                    //llenar gridview
                    this.GvDatos.DataSource = ds.Tables[0];
                    this.GvDatos.DataBind();
                    ds.Dispose();
                }
            
            }
            catch (Exception ex) 
            {            
            
            }               
        }

        protected void BtAdminLogout_Click(object sender, EventArgs e)
        {
            //Session["RutUsuario"] = null;
            //Session["NombreUsuario"] = null;
            //Session["ApellidoUsuario"] = null;
            //Session["PerfilUsuario"] = null;
            bool login = false;
            //recupero fecha y hora servidor
            _ent_Tb_Registro_Login.fecha_ter_login = Convert.ToDateTime(_FechaHoraServidor.Selecciona_FechaHoraServer());
            //inserto hora y fecha de registro usuario
            login = _lgn_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(_ENT_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_ter_login);

            Session.Remove("RutUsuario");
            Session.Remove("NombreUsuario");
            Session.Remove("ApellidoUsuario");
            Session.Remove("PerfilUsuario");
            Response.Redirect("~/WebFormLogin.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/WebFormOrdenTrabajoSeleccion.aspx");
            //Response.Redirect("WebFormOrdenTrabajo.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);

            Response.Redirect("WebFormMenu.aspx");

        }
    }
}