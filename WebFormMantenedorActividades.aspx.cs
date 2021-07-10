using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_LgNegocios;
using Dll_Entidades;
using System.Data;

namespace WebOtServicios
{
    public partial class WebFormMantenedorActividades : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public bool flag;
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();        
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Actividades _ent_Tb_Actividades = new ENT_Tb_Actividades();

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Tipo_Dispositivo _lgn_Tb_Tipo_Dispositivo = new LGN_Tb_Tipo_Dispositivo();
        private LGN_Tb_Tipo_OT _lgn_Tb_Tipo_OT = new LGN_Tb_Tipo_OT();
        private LGN_Tb_Periodos _LGN_Tb_Periodos = new LGN_Tb_Periodos();


        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            //cargo entidad
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(UsuarioId);
            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(Request.QueryString["pRutEmp"]);

            _ent_Tb_Empresas.fecha_registro = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(UsuarioId);


            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("~/WebFormLogin.aspx");

                //lleno grilla
                LlenarGrid();

                CargaCboEmpresa();

                CargaCboDispo();

                CargaCboFamilia();

                CargaCboPeriodos();
            }

            //valido usuario
            if (PerfilUsuario == "Tecnico")
            {
                Response.Redirect("WebFormMenu.aspx");
            }

            //---- Confirmacion  ----
            //genera un instancia del control hacia el delegado expuesto
            //para capturar la accion, esta llama un void ("info_OkButtonPressed")
            //permitiendo que al hacer postback se pueda capturar el retorno
            confirmacion.AceptarButtonPressed += new WebOtServicios.controls.confirmacion.AceptarButtonPressedHandler(confirmacion_AceptarButtonPressed);

        }

        #region Enlace Controls
        //obtiene el los objetos del control con cual interactuar definiendo el tipo de 
        //cada boton y capturando el postback
        void info_AceptarButtonPressed(object sender, EventArgs args)
        {
        }

        //obtiene el los objetos del control con cual interactuar definiendo el tipo de 
        //cada boton y capturando el postback
        void confirmacion_AceptarButtonPressed(object sender, EventArgs args)
        {
            string varControl = (string)Session["pControl"];
            if (varControl == "15")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                LlenarGrid();
                Session.Remove("Eliminar");
            }
        }
        #endregion

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMenu.aspx");
        }

        private void LlenarGrid()
        {
            ds = _lgn_tb_empresas.Selecciona_ListaEmpresas();
            try
            {
                if (ds != null)
                {
                    //llenar gridview
                    //this.GvDatos.DataSource = ds.Tables[0];
                    //this.GvDatos.DataBind();
                    ds.Dispose();
                }
            }
            catch (Exception ex)
            {
                _ent_Lista_Mensajes.MsjErrorSql = ex.Message.ToString();
            }
        }

        protected void BtAdminLogout_Click(object sender, EventArgs e)
        {
            //Session["RutUsuario"] = null;
            //Session["NombreUsuario"] = null;
            //Session["ApellidoUsuario"] = null;
            //Session["PerfilUsuario"] = null;            
            bool login = false;
            this.Response.Write("<script language='JavaScript'>window.alert('" + _ent_Tb_Personal.rut_personal + "');</script>");
            //recupero fecha y hora servidor
            _ent_Tb_Registro_Login.fecha_ter_login = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());
            //inserto hora y fecha de registro usuario
            login = _lgn_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(_ent_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_ter_login);
            Session.Remove("RutUsuario");
            Session.Remove("NombreUsuario");
            Session.Remove("ApellidoUsuario");
            Session.Remove("PerfilUsuario");
            Response.Redirect("~/WebFormLogin.aspx");
        }

        private void CargaCboEmpresa()
        {
            DataSet dsemp = new DataSet();
            dsemp = _lgn_tb_empresas.Selecciona_ListaEmpresas();

            if (ds != null)
            {
                this.CboEmpresa.DataSource = dsemp.Tables[0];
                this.CboEmpresa.DataTextField = "nom_empresa".ToUpper();
                this.CboEmpresa.DataValueField = "rut_empresa";
                this.CboEmpresa.DataBind();
                this.CboEmpresa.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }

        }

        private void CargaCboDispo()
        {
            DataSet dsemp = new DataSet();
            dsemp = _lgn_Tb_Tipo_Dispositivo.Selecciona_Dispositivos();

            if (ds != null)
            {
                this.CboAccesorio.DataSource = dsemp.Tables[0];
                this.CboAccesorio.DataTextField = "Nom_Disp";
                this.CboAccesorio.DataValueField = "cod_nom_dispo";
                this.CboAccesorio.DataBind();
                this.CboAccesorio.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }

        }

        private void CargaCboFamilia()
        {
            DataSet dsemp = new DataSet();
            dsemp = _lgn_Tb_Tipo_OT.Selecciona_Familias();

            if (ds != null)
            {
                this.CboDispositivo.DataSource = dsemp.Tables[0];
                this.CboDispositivo.DataTextField = "NomTipOt";
                this.CboDispositivo.DataValueField = "CodTipOt";
                this.CboDispositivo.DataBind();
                this.CboDispositivo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }

        }

        private void CargaCboPeriodos()
        {
            DataSet dsemp = new DataSet();
            dsemp = _LGN_Tb_Periodos.Selecciona_Periodos();

            if (ds != null)
            {
                this.CboPeriodo.DataSource = dsemp.Tables[0];
                this.CboPeriodo.DataTextField = "Nom_Periodo";
                this.CboPeriodo.DataValueField = "Cod_Periodo";
                this.CboPeriodo.DataBind();
                this.CboPeriodo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int operacion = 0;


            if ((CboDispositivo.SelectedValue == "0") || (CboEmpresa.SelectedValue == "0") || (CboAccesorio.SelectedValue == "0") || (CboPeriodo.SelectedValue == "0") || (TxtComponente.Text == string.Empty) || (TxtObserActividad.Text == string.Empty) )
            {
                return;                     
            }
            
            _ent_Tb_Actividades.Tipo_Equipo = Convert.ToInt32(CboDispositivo.SelectedValue);
            _ent_Tb_Actividades.Componente = TxtComponente.Text.TrimEnd();
            _ent_Tb_Actividades.Actividad = TxtObserActividad.Text.TrimEnd();
            _ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(CboEmpresa.SelectedValue);
            _ent_Tb_Actividades.Periodo_Actividad = Convert.ToInt32(CboPeriodo.SelectedValue);
            _ent_Tb_Actividades.Nom_Disp = Convert.ToString(CboAccesorio.SelectedItem);
            _ent_Tb_Actividades.Cod_Nom_Dispo = Convert.ToInt32(CboAccesorio.SelectedValue);
            
            //crear funcionario
            if ((Session["Editar"] == null) && (Session["Eliminar"] == null))
            {
                //inserta nueva fucionario
                operacion = 15;
                confirmacion.NuevoActividad("¿Desea agregar nueva actividad?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Actividades, operacion);
                Limpiar();
            }

        }

        private void Limpiar()
        {
            CboEmpresa.SelectedValue = "0";
            CboAccesorio.SelectedValue = "0";
            CboDispositivo.SelectedValue = "0";
            CboPeriodo.SelectedValue = "0";
            TxtComponente.Text = string.Empty;
            TxtObserActividad.Text = string.Empty;
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }






    }
}