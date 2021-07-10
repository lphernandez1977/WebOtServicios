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
//EMAIL
using System.Net;
using System.Net.Mail;
using System.Text;

namespace WebOtServicios
{
    public partial class WebFormDesarrolloActividad : System.Web.UI.Page
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

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();
        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_Tb_Actividades _lgn_Tb_Actividades = new LGN_Tb_Actividades();

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
            _ent_Tb_Actividades.Cod_Act = Convert.ToInt32(Request.QueryString["pCodAct"]);
            _ent_Tb_OT_Encabezado.estado = 2;
            _ent_Tb_OT_Encabezado.fecha_reserva_captura = Convert.ToDateTime(_lgn_FechaHoraServer.Selecciona_FechaHoraServer());
            _ent_Tb_OT_Encabezado.rut_personal = Convert.ToDouble(UsuarioId);

            //mostrar ot en trabajo
            this.LblNumOT.Text = Convert.ToString(_ent_Tb_OT_Encabezado.num_ot);

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("~/WebFormLogin.aspx");

                //lleno grilla
                LlenarGrid(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot, _ent_Tb_Actividades.Cod_Act);
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
            string varControl = (string)Session["pControl"];

            if (varControl == "1")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
            }

            if (varControl == "2")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);    
            }
        }

        //obtiene el los objetos del control con cual interactuar definiendo el tipo de 
        //cada boton y capturando el postback
        void confirmacion_AceptarButtonPressed(object sender, EventArgs args)
        {
            string varControl = (string)Session["pControl"];

            if (varControl == "1")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
            }

            if (varControl == "2")
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
                Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);    
            }
        }
        #endregion

        private void LlenarGrid(double pRutEmp, double pNumOt, int CodAct)
        {
            ENT_Tb_Actividades oActividades = new ENT_Tb_Actividades();

            try
            {
                oActividades = _lgn_Tb_Actividades.Selecciona_ActividadDesarrollo(pRutEmp, pNumOt, CodAct);

                LblNumOT_Act.Text =  oActividades.NumOt.ToString();
                LblCod.Text = oActividades.Cod_Act.ToString();
                LblComponente.Text = oActividades.Componente.ToString();
                LblActividad.Text = oActividades.Actividad.ToString();                
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/WebFormOrdenTrabajoSeleccion.aspx");
            Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
        }

        protected void BtnFinJob_Click(object sender, EventArgs e)
        {
            //1 cierra ot por completo
            //2 cierra tarea

            int operacion = 2;

            //asigno variables
            _ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(_ent_Tb_OT_Encabezado.rut_empresa);
            _ent_Tb_Actividades.NumOt = _ent_Tb_OT_Encabezado.num_ot;
            _ent_Tb_Actividades.Cod_Act = Convert.ToInt32(LblCod.Text);
            _ent_Tb_Actividades.ObservacionAct = TxtObserActividad.Text.TrimEnd().ToUpper();

            //consultar estado actividad
            string ValEstado = string.Empty;
            ValEstado = _lgn_Tb_Actividades.Valida_EstadoActividadOt(_ent_Tb_Actividades);

            //if (ValEstado == "N")
            //{
                confirmacion.CierreTareaOT("¿Desea cerrar la actividad realizada?", controls.confirmacion.tipoMensaje.advertencia, _ent_Tb_Actividades.NumOt, _ent_Tb_Actividades.Rut_Empresa, _ent_Tb_Actividades.Cod_Act, operacion,_ent_Tb_Actividades.ObservacionAct);
            //}
            //else
            //{
            //    info.ShowMessage("Actividad se encuentra finalizada", controls.informacion.tipoMensaje.Mensaje);                        
            //}
         }

        public bool EnviarCorreo()
        {
            MailMessage _mensage = new MailMessage();
            SmtpClient _smtp = new SmtpClient();

            _smtp.Credentials = new NetworkCredential("phernandez@casaroyal.cl", "phernandezroyal");
            _smtp.Host = "mail.casaroyal.cl";
            _smtp.Port = 25;
            _smtp.EnableSsl = false;

            //' CONFIGURACION DEL MENSAJE
            //_mensage.To.Add("mescalona@casaroyal.cl");
            _mensage.To.Add("cgermain@casaroyal.cl");
            _mensage.CC.Add("rbarrientos@casaroyal.cl");
            _mensage.From = new MailAddress("phernandez@casaroyal.cl");
            _mensage.Subject = "Stock Web";
            _mensage.SubjectEncoding = UTF8Encoding.UTF8;
            _mensage.Body = "Se informa que Orden de trabajo fue cerrada"; // + LblFecha.Text;           
            _mensage.BodyEncoding = UTF8Encoding.UTF8;
            //_mensage.Attachments.Add(new Attachment(namefile));
            _mensage.Priority = MailPriority.Normal;
            _mensage.IsBodyHtml = false;

            try
            {
                _smtp.Send(_mensage);
                //ListTareas.Items.Add(LblFecha.Text + " : " + LblHora.Text + " Correo enviado en forma correcta");
                return true;
            }
            catch (Exception ex)
            {
                //ListTareas.Items.Add(LblFecha.Text + " : " + LblHora.Text + ex.Message.ToString());
                return false;
            }
        }
    
    
    }



}