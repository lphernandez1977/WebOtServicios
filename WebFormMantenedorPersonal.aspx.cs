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
    public partial class WebFormMantenedorPersonal : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public bool flag;
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();
        private ENT_Tb_Cargos _ent_Tb_Cargos = new ENT_Tb_Cargos();        
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();

        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Cargos _lgn_Tb_Cargos = new LGN_Tb_Cargos();
        private LGN_Tb_Personal _lgn_Tb_Personal = new LGN_Tb_Personal();
        private LGN_FechaHoraServer _FechaHoraServidor = new LGN_FechaHoraServer();

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
                //llenar cbo
                LLenarCbo();
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

            if (varControl == "8")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                LlenarGrid();
                Session.Remove("Eliminar");
            }

            if (varControl == "9")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Limpiar();
                //lleno grilla
                LlenarGrid();
            }

            if (varControl == "10")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);                
                Limpiar();
                //lleno grilla
                LlenarGrid();
                Session.Remove("Editar");
            }
        }
        #endregion

        private void LlenarGrid()
        {
            ds = _lgn_Tb_Personal.Selecciona_ListaFuncionarios();
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

        private void LLenarCbo() 
        {
            DataSet ds = new DataSet();
            ds = _lgn_Tb_Cargos.Selecciona_ListaCargosFuncionario();

            if (ds != null)
            {
                this.CboCargo.DataSource = ds.Tables[0];
                this.CboCargo.DataTextField = "Nom_Cargo";
                this.CboCargo.DataValueField = "Cod_Cargo";
                this.CboCargo.DataBind();
                this.CboCargo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
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
            TxtRut.Text = GvDatos.DataKeys[row.RowIndex].Values["rut_personal"].ToString();
            TxtNombreTec.Text = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["nom_empleado"]);
            TextApeTec.Text = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["ape_empleado"]);
            CboCargo.SelectedValue = GvDatos.DataKeys[row.RowIndex].Values["cod_cargo"].ToString();
            TxtPass.Text = Convert.ToString(GvDatos.DataKeys[row.RowIndex].Values["contrasenia"]);

            if (e.CommandName == "Editar")
            {
                flag = true;
                Session["Editar"] = flag;
                flag = false;
            }

            if (e.CommandName == "Eliminar")
            {
                operacion = 8;

                //paso valores a las variables
                _ent_Tb_Personal.rut_personal = Convert.ToDouble(TxtRut.Text);
                _ent_Tb_Personal.nom_empleado = TxtNombreTec.Text;
                _ent_Tb_Personal.ape_empleado = TextApeTec.Text;
                _ent_Tb_Personal.cargo = CboCargo.SelectedValue;
                _ent_Tb_Personal.contrasenia = TxtPass.Text;

                confirmacion.EliminarPersonal("¿Desea eliminar tecnico seleccionado?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Personal, operacion);          
               //lleno grilla
                LlenarGrid();
                LLenarCbo();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {                    
            int operacion = 0;
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(TxtRut.Text);
            //_ent_Tb_Personal.dv = Convert.ToChar(TxtDv.Text); 
            _ent_Tb_Personal.nom_empleado = TxtNombreTec.Text;
            _ent_Tb_Personal.ape_empleado = TextApeTec.Text;
            _ent_Tb_Personal.Cod_Cargo = Convert.ToInt32(CboCargo.SelectedValue);
            _ent_Tb_Personal.contrasenia = TxtPass.Text;

            //crear funcionario
            if ((Session["Editar"] == null) && (Session["Eliminar"] == null))
            {
                //inserta nueva fucionario
                operacion = 9;
                confirmacion.NuevoPersonal("¿Desea agregar nuevo funcionario?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Personal, operacion);          
            }

            //mantenedor
            if (Convert.ToBoolean(Session["Editar"]))
            {
                //actualizo empresa 
                //res = _lgn_tb_empresas.Actualiza_Empresas(_ent_Tb_Empresas);

                operacion = 10;
                confirmacion.EditarPersonal("¿Desea modificar datos del funcionario?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Personal, operacion);                          
                //lleno grilla
                //LlenarGrid();
                //lleno combo
                //LLenarCbo();
                //Session.Remove("Editar");
            }
        }

        protected void BtAdminLogout_Click(object sender, EventArgs e)
        {            
            bool login = false;           
            //recupero fecha y hora servidor
            _ent_Tb_Registro_Login.fecha_ter_login = Convert.ToDateTime(_FechaHoraServidor.Selecciona_FechaHoraServer());
            //inserto hora y fecha de registro usuario
            login = _lgn_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(_ent_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_ter_login);
            Session.Remove("RutUsuario");
            Session.Remove("NombreUsuario");
            Session.Remove("ApellidoUsuario");
            Session.Remove("PerfilUsuario");
            Response.Redirect("~/WebFormLogin.aspx");
        }

        private void Limpiar() 
        {
            TxtRut.Text = string.Empty;
            //TxtDv.Text = string.Empty;
            TxtNombreTec.Text = string.Empty;
            TextApeTec.Text = string.Empty;
            TxtPass.Text = string.Empty;
        
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMenu.aspx");
        }
    }
}