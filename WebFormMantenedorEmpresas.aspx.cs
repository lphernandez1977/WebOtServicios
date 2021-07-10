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
    public partial class WebFormMantenedorEmpresas : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public bool flag;
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();
        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();


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

            if (varControl == "5")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                LlenarGrid();
            }
            
            if (varControl == "6")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                ////lleno grilla
                LlenarGrid();
                Session.Remove("Editar");
            }

            if (varControl == "7")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                ////lleno grilla
                LlenarGrid();
                Session.Remove("Eliminar");
            }
        }
        #endregion

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
             int operacion = 0;
            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(TxtRut.Text); 
            _ent_Tb_Empresas.nom_empresa = TxtNomEmpresa.Text.ToUpper();

            //crear empresa
            if ((Session["Editar"] == null) && (Session["Eliminar"] == null))
            {
                operacion = 5;
                confirmacion.NuevaEmpresa("¿Desea agregar una empresa nueva?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Empresas, operacion);                
            }

            //mantenedor
            if (Convert.ToBoolean(Session["Editar"]))
            {
                operacion = 6;
                confirmacion.EditarEmpresa("¿Desea agregar una empresa nueva?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Empresas, operacion);
                LlenarGrid();
            }

        }

        private void LlenarGrid()
        {
            ds = _lgn_tb_empresas.Selecciona_ListaEmpresas();
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
                _ent_Lista_Mensajes.MsjErrorSql = ex.Message.ToString();
            }
        }

        protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect1");
                ImgSelect.CommandArgument = Convert.ToString(e.Row.RowIndex);            
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect2");
                ImgSelect.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }

        protected void GvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int operacion = 0;

            GridViewRow row = GvDatos.Rows[index];
            TxtRut.Text = GvDatos.DataKeys[row.RowIndex].Values["rut_empresa"].ToString();            
            TxtNomEmpresa.Text = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["nom_empresa"]);

            if (e.CommandName == "Editar")
            {              
                flag = true;
                Session["Editar"] = flag;
                flag = false;
            }

            if (e.CommandName == "Eliminar")
            {
                operacion = 7;
                //paso valores a las variables
                _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(TxtRut.Text.Replace(".", ""));                
                _ent_Tb_Empresas.nom_empresa = TxtNomEmpresa.Text.ToUpper();
                confirmacion.EliminarEmpresa("¿Desea eliminar empresa seleccionada?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Empresas, operacion);
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar() 
        {
            TxtRut.Text = string.Empty;
            TxtNomEmpresa.Text = string.Empty;                
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMenu.aspx");
        }
    }
}