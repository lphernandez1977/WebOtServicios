using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_LgNegocios;
using Dll_Entidades;
using System.Data;
using System.Xml.Linq;
using System.Threading;
namespace WebOtServicios
{
    public partial class WebFormActividadesOT : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Equipos _ent_Tb_Equipos = new ENT_Tb_Equipos();
        private ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado = new ENT_Tb_OT_Encabezado();
        private ENT_Tb_OT_Detalle _ent_Tb_OT_Detalle = new ENT_Tb_OT_Detalle();
        private ENT_Lista_Mensajes _ent_Lista_Mensajes = new ENT_Lista_Mensajes();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_Personal _ENT_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Actividades _ent_Tb_Actividades = new ENT_Tb_Actividades();
        private ENT_Tb_DesActxTecnicos _Tb_DesActxTecnicos = new ENT_Tb_DesActxTecnicos();

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();
        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_Tb_DesActxTecnicos _lgn_DesActxTecnicos = new LGN_Tb_DesActxTecnicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            //cargo entidad
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(UsuarioId);
            _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(Request.QueryString["pRutEmp"]);
            _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(Request.QueryString["pNumOt"]);
            _ent_Tb_OT_Encabezado.estado = 2;
            _ent_Tb_OT_Encabezado.fecha_reserva_captura = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());
            _ent_Tb_OT_Encabezado.rut_personal = Convert.ToDouble(UsuarioId);

            //mostrar ot en trabajo
            this.LblNumOT.Text = Convert.ToString(_ent_Tb_OT_Encabezado.num_ot);

            //consultar si ot se encuentra asignada
            string ValOt = string.Empty;
            ValOt = _lgn_Tb_OT_Encabezado.Selecciona_OtAsignada(_ent_Tb_OT_Encabezado.rut_empresa,
                                                                _ent_Tb_OT_Encabezado.num_ot,
                                                                _ent_Tb_Personal.rut_personal);
            if (ValOt == "1")
            {

            }
            else
            {
                //asignar OT
                bool res = _lgn_Tb_OT_Encabezado.Actualiza_AsignacionOT_Tecnico(_ent_Tb_OT_Encabezado);
            }

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("~/WebFormLogin.aspx");

                //lleno grilla
                LlenarGrid(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);
            }


            ////LblUsuario.Text = NombreUsuario + " " + ApellidoUsuario;

            ////---- mensaje  ----
            ////genera un instancia del control hacia el delegado expuesto
            ////para capturar la accion, esta llama un void ("info_OkButtonPressed")
            ////permitiendo que al hacer postback se pueda capturar el retorno
            //info.AceptarButtonPressed += new WebOtServicios.controls.informacion.AceptarButtonPressedHandler(info_AceptarButtonPressed);

            //---- Confirmacion  ----
            //genera un instancia del control hacia el delegado expuesto
            //para capturar la accion, esta llama un void ("info_OkButtonPressed")
            //permitiendo que al hacer postback se pueda capturar el retorno
            confirmacion.AceptarButtonPressed += new WebOtServicios.controls.confirmacion.AceptarButtonPressedHandler(confirmacion_AceptarButtonPressed);

            ////---- Cargando Espere ----
            ////genera un instancia del control hacia el control de Espera
            //infoespere.ShowMessage("Cargando", "", controls.espere.tipoMensaje.Cargando);

            //infoespere.ShowMessage("Grabando", "Espere por favor", controls.espere.tipoMensaje.Grabando);
            //this.BtnCerrarOt.OnClientClick = String.Format("botonProgress = '1'");

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
            //if (Session["Resultado"] != null)
            if (varControl == "1")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.Mensaje);
                //Thread.Sleep(1000);
                //Response.Redirect("WebFormOrdenTrabajoSeleccion.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa);
            }

            if (varControl == "2")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.Mensaje);
                //Response.Redirect("WebFormOrdenTrabajoSeleccion.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa);
            }

            //if (varControl == "2")
            //{
            //    info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
            //    Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
            //}





        }
        #endregion

        private void LlenarGrid(double pRutEmp, double pNumOt)
        {
            ds = _lgn_Tb_Equipos.Selecciona_ListaDeActividades(pRutEmp, pNumOt);
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
                _ent_Lista_Mensajes.MsjExepcion = ex.Message.ToString();
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
            _ent_Tb_Registro_Login.fecha_ter_login = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());

            //inserto hora y fecha de registro usuario
            login = _lgn_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(_ENT_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_ter_login);

            Session.Remove("RutUsuario");
            Session.Remove("NombreUsuario");
            Session.Remove("ApellidoUsuario");
            Session.Remove("PerfilUsuario");
            Response.Redirect("~/WebFormLogin.aspx");
        }

        protected void GvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDatos.PageIndex = e.NewPageIndex;
            LlenarGrid(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/WebFormOrdenTrabajoSeleccion.aspx");
            Response.Redirect("WebFormOrdenTrabajoSeleccion.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa);
        }

        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seleccion fila de grilla
            GridViewRow row = GvDatos.SelectedRow;

            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(Request.QueryString["pRutEmp"]);
            //_ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["num_ot"]);
            //TecReserOT = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["rut_personal"]);
            _ent_Tb_Actividades.Cod_Act = Convert.ToInt32(GvDatos.DataKeys[row.RowIndex].Values["Cod_Act"]);

            //asigno variables para enviar al otro webform
            double pRutEmp = _ent_Tb_Empresas.rut_empresa;
            double pNumOt = _ent_Tb_OT_Encabezado.num_ot;

            _Tb_DesActxTecnicos.Rut_empresa = _ent_Tb_Empresas.rut_empresa;
            _Tb_DesActxTecnicos.Num_ot = _ent_Tb_OT_Encabezado.num_ot;
            _Tb_DesActxTecnicos.Cod_Act = _ent_Tb_Actividades.Cod_Act;
            _Tb_DesActxTecnicos.Fecha_Asignacion = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());
            _Tb_DesActxTecnicos.Rut_Tecnico = _ent_Tb_Personal.rut_personal;

            int act = 0;
            act = _lgn_DesActxTecnicos.Inserta_RegistroActividadesxTecnico(_Tb_DesActxTecnicos);


            //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + pRutEmp + pNumOt);
            Response.Redirect("WebFormDesarrolloActividad.aspx?pRutEmp=" + pRutEmp + "&pNumOt=" + pNumOt + "&pCodAct=" + _ent_Tb_Actividades.Cod_Act);

            //************************
            //int operacion = 2;
            //asigno variables
            //_ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(_ent_Tb_OT_Encabezado.rut_empresa);
            //_ent_Tb_Actividades.NumOt = _ent_Tb_OT_Encabezado.num_ot;
            //_ent_Tb_Actividades.Cod_Act = Convert.ToInt32(LblCod.Text);
            //confirmacion.CierreTareaOT("¿Desea cerrar la actividad realizada?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Actividades.NumOt, _ent_Tb_Actividades.Rut_Empresa, _ent_Tb_Actividades.Cod_Act, operacion);
            //************************
        }

        protected void GvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect");
            if (ImgSelect != null)
            {
                // Imagina que es un valor entero. y verificamos que sea 1 para mostrar la imagen
                if (dr["Estado_Act"].ToString() == "Y")
                {
                    //ImgSelect.Enabled = true;
                    ImgSelect.Visible = false;
                }
                else
                {
                    //ImgSelect.Enabled = false;
                    ImgSelect.Visible = true;
                }
            }
        }

        protected void BtnCerrarOt_Click(object sender, EventArgs e)
        {
            //1 cierra ot por completo
            //2 cierra tarea
            int operacion = 1;


            //asigno variables
            _ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(_ent_Tb_OT_Encabezado.rut_empresa);
            _ent_Tb_Actividades.NumOt = _ent_Tb_OT_Encabezado.num_ot;


            confirmacion.CierreOT("¿Desea cerrar orden de  trabajo?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Actividades.NumOt, _ent_Tb_Actividades.Rut_Empresa, operacion);

            //info.ShowMessage("Hola", controls.informacion.tipoMensaje.Mensaje);

        }






    }
}