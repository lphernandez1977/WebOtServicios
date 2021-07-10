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
    public partial class WebFormMantenedorEquipos : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataSet DetallePedido = new DataSet();

        public bool flag;
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Equipos _ent_Tb_Equipos = new ENT_Tb_Equipos();

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();        
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Tipo_Dispositivo _lgn_Tb_Tipo_Dispositivo = new LGN_Tb_Tipo_Dispositivo();
        private LGN_Tb_Equipos  _lgn_Tb_Equipos = new LGN_Tb_Equipos();


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
                LlenarGrid(_ent_Tb_Empresas.rut_empresa);
                CargaCboDispo();
                CargaCboEmpresa();
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

            if (varControl == "12")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                ////lleno grilla
                LlenarGrid(Convert.ToDouble((string)Session["RutEmpresaE"]));                
                Session.Remove("RutEmpresaE");
                
            }
            
            if (varControl == "13")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                ////lleno grilla
                LlenarGrid(Convert.ToDouble((string)Session["RutEmpresaE"]));
                Session.Remove("RutEmpresaE");
            }
        }
        #endregion

        private void LlenarGrid(double pRut)
        {
            ds = _lgn_Tb_Equipos.Selecciona_ListaEquiposEmpresa(_ent_Tb_Empresas.rut_empresa);
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
                //_ent_Lista_Mensajes.MsjErrorSql = ex.Message.ToString();
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            LlenarGrid(Convert.ToDouble("0"));
        }

        private void Limpiar()
        {
            CboEmpresa.SelectedValue = "0";
            CboDisp.SelectedValue = "0";
            TxtNcorto.Text = string.Empty;
            TxtEquipo.Text = string.Empty;
            
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int operacion = 0;

            if (CboEmpresa.SelectedValue == "0") 
            {
                info.ShowMessage("Debe seleccionar empresa", controls.informacion.tipoMensaje.Mensaje);
                CboEmpresa.Focus();                
                return;                        
            }

            if (CboDisp.SelectedValue == "0") 
            {
                info.ShowMessage("Debe seleccionar dispositivo", controls.informacion.tipoMensaje.Mensaje);
                CboDisp.Focus();
                return;                        
            }
            
            if (TxtEquipo.Text == string.Empty) 
            {
                info.ShowMessage("Debe ingresar nombre equipo", controls.informacion.tipoMensaje.Mensaje);
                TxtEquipo.Focus();
                return;            
            }

            //if (TxtNcorto.Text == string.Empty) 
            //{
            //    TxtNcorto.Focus();
            //    return;            
            //}

            _ent_Tb_Equipos.rut_empresa = Convert.ToDouble(CboEmpresa.SelectedValue);            
            _ent_Tb_Equipos.nom_equipos = TxtEquipo.Text.TrimEnd();
            _ent_Tb_Equipos.nom_corto = TxtEquipo.Text.TrimEnd();
            int dispo = Convert.ToInt32(CboDisp.SelectedValue);
            Session["RutEmpresaE"] = Convert.ToString(_ent_Tb_Equipos.rut_empresa);
            
            
            string res = string.Empty;

            //crear funcionario
            if ((Session["Editar"] == null) && (Session["Eliminar"] == null))
            {
                //asigno variables
                operacion = 12;
                confirmacion.CrearNuevoEquipo("¿Desea agregar un nuevo equipo?", controls.confirmacion.tipoMensaje.advertencia, operacion, _ent_Tb_Equipos, dispo);                
            }

            //mantenedor
            if (Convert.ToBoolean(Session["Editar"]))
            {
                operacion = 14;
                _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(TxtCodEquipo.Text);
                confirmacion.EditarNuevoEquipo("¿Desea modificar datos del equipo?", controls.confirmacion.tipoMensaje.advertencia, operacion, _ent_Tb_Equipos, dispo);
            }
        }

        //Grilla Limpia
        private void grilla_limpia()
        {
            dt.Clear();
            DataRow row = dt.NewRow();
            //row["Rut"] = "";
            //row["Nombre"] = "";

            row["Pos"] = "";
            row["Equipo"] = "";
            row["Actividad"] = "";
            dt.Rows.Add(row);

            this.GvDatos.DataSource = DetallePedido.Tables[0];
            this.GvDatos.DataBind();
        }

        private void CargaCboEmpresa() 
        {
            DataSet dsemp = new DataSet();
            dsemp = _lgn_tb_empresas.Selecciona_ListaEmpresas();

            if (ds != null)
            {
                this.CboEmpresa.DataSource = dsemp.Tables[0];
                this.CboEmpresa.DataTextField = "nom_empresa";
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
                this.CboDisp.DataSource = dsemp.Tables[0];
                this.CboDisp.DataTextField = "Nom_Disp";
                this.CboDisp.DataValueField = "cod_nom_dispo";
                this.CboDisp.DataBind();
                this.CboDisp.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }

        }

        protected void CboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(CboEmpresa.SelectedValue);
            LlenarGrid(_ent_Tb_Empresas.rut_empresa);
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
            CboEmpresa.SelectedValue = GvDatos.DataKeys[row.RowIndex].Values["rut_empresa"].ToString();
            CboDisp.SelectedValue = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["Cod_Nom_Dispo"]);
            TxtNcorto.Text = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["nom_corto"]);
            TxtEquipo.Text = GvDatos.DataKeys[row.RowIndex].Values["nom_equipos"].ToString();
            TxtCodEquipo.Text = GvDatos.DataKeys[row.RowIndex].Values["cod_equipos"].ToString();
           
            if (e.CommandName == "Editar")
            {
                flag = true;
                Session["Editar"] = flag;
                flag = false;
            }

            if (e.CommandName == "Eliminar")
            {
                operacion = 13;

                //paso valores a las variables
                _ent_Tb_Equipos.rut_empresa = Convert.ToDouble(CboEmpresa.SelectedValue);
                _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(TxtCodEquipo.Text);
                Session["RutEmpresaE"] = Convert.ToString(_ent_Tb_Equipos.rut_empresa);

                confirmacion.EliminarEquipo("¿Desea eliminar equipo seleccionado?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Equipos, operacion);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(CboEmpresa.SelectedValue);

            if (_ent_Tb_Empresas.rut_empresa == 0) 
            {
                info.ShowMessage("Debe seleccionar empresa", controls.informacion.tipoMensaje.Mensaje);
                return;
            }
            
            LlenarGrid(_ent_Tb_Empresas.rut_empresa);
        }
    }
}