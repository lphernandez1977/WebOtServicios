using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_LgNegocios;
using Dll_Entidades;
using System.Data;

namespace WebOtServicios.controls
{
    public partial class confirmacion : System.Web.UI.UserControl
    {
        private ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado = new ENT_Tb_OT_Encabezado();
        private ENT_Tb_Actividades _ent_Tb_Actividades = new ENT_Tb_Actividades();
        private ENT_Tb_OT_Detalle _ent_Tb_OT_Detalle = new ENT_Tb_OT_Detalle();
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_OT_Encabezado_Manual _ent_Tb_OT_Encabezado_Manual = new ENT_Tb_OT_Encabezado_Manual();
        private ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual = new ENT_Tb_OT_Detalle_Manual();
        private ENT_Tb_Equipos _ent_Tb_Equipos = new ENT_Tb_Equipos();

        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_Actividades _lgn_Tb_Actividades = new LGN_Tb_Actividades();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Personal _lgn_Tb_Personal = new LGN_Tb_Personal();
        private LGN_Tb_OT_Encabezado_Manual _lgn_Tb_OT_Encabezado_Manual = new LGN_Tb_OT_Encabezado_Manual();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();


        protected void Page_Load(object sender, EventArgs e)
        {

            this.btnAceptar.OnClientClick = String.Format("fnClickOK('{0}','{1}')", this.btnAceptar.UniqueID, "");
            this.btnCancelar.OnClientClick = String.Format("fnClickOK('{0}','{1}')", this.btnCancelar.UniqueID, "");

        }

        public enum tipoMensaje
        {
            advertencia = 1,
            Mensaje = 2
        }

        public void CierreOT(string Message, tipoMensaje tipo, double OT, double Rut, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTrabajo"] = OT.ToString();
            Session["OTRut"] = Rut.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void CierreTareaOT(string Message, tipoMensaje tipo, double OT, double Rut, double CodAct, int operacion, string pObserv)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTRut"] = Rut.ToString();
            Session["OTrabajo"] = OT.ToString();
            Session["CodAct"] = CodAct.ToString();
            Session["Oper"] = operacion.ToString();
            Session["pObserActividades"] = pObserv.ToString();

            this.ModalPopupInfo.Show();
        }

        public void ModificarOT(string Message, tipoMensaje tipo, int operacion, ENT_Tb_OT_Encabezado oEncabezado)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTRut"] = oEncabezado.rut_empresa.ToString();
            Session["OTrabajo"] = oEncabezado.num_ot.ToString();
            Session["OEstado"] = oEncabezado.estado.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void CrearOrdenTrabajo(string Message, tipoMensaje tipo, int operacion, string xml)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }
            
            Session["Oper"] = operacion.ToString();
            Session["Xml"] = xml.ToString();

            this.ModalPopupInfo.Show();
        }

        public void NuevaEmpresa(string Message, tipoMensaje tipo, ENT_Tb_Empresas oEmpresa, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTRut"] = oEmpresa.rut_empresa.ToString();
            Session["NOMEMP"] = oEmpresa.nom_empresa.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void EditarEmpresa(string Message, tipoMensaje tipo, ENT_Tb_Empresas oEmpresa, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTRut"] = oEmpresa.rut_empresa.ToString();
            Session["NOMEMP"] = oEmpresa.nom_empresa.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void EliminarEmpresa(string Message, tipoMensaje tipo, ENT_Tb_Empresas oEmpresa, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["OTRut"] = oEmpresa.rut_empresa.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void EliminarPersonal(string Message, tipoMensaje tipo, ENT_Tb_Personal oPersonal, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["PRut"] = oPersonal.rut_personal.ToString();
            Session["PNombre"] = oPersonal.nom_empleado.ToString();
            Session["PApellido"] = oPersonal.ape_empleado.ToString();
            Session["PCargo"] = oPersonal.Cod_Cargo.ToString();
            Session["PContrasenia"] = oPersonal.contrasenia.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void NuevoPersonal(string Message, tipoMensaje tipo, ENT_Tb_Personal oPersonal, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["PRut"] = oPersonal.rut_personal.ToString();
            Session["PNombre"] = oPersonal.nom_empleado.ToString();
            Session["PApellido"] = oPersonal.ape_empleado.ToString();
            Session["PCargo"] = oPersonal.Cod_Cargo.ToString();
            Session["PContrasenia"] = oPersonal.contrasenia.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void EditarPersonal(string Message, tipoMensaje tipo, ENT_Tb_Personal oPersonal, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["PRut"] = oPersonal.rut_personal.ToString();
            Session["PNombre"] = oPersonal.nom_empleado.ToString();
            Session["PApellido"] = oPersonal.ape_empleado.ToString();
            Session["PCargo"] = oPersonal.Cod_Cargo.ToString();
            Session["PContrasenia"] = oPersonal.contrasenia.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        public void CrearOrdenTrabajoManual(string Message, tipoMensaje tipo, int operacion, ENT_Tb_OT_Encabezado_Manual _ent__Tb_OT_Encabezado_Manual)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["Oper"] = operacion.ToString();
            Session["rut_empresa"] = Convert.ToString(_ent__Tb_OT_Encabezado_Manual.rut_empresa);
            Session["nom_empresa"] = _ent__Tb_OT_Encabezado_Manual.nom_empresa;
            Session["periodo"] = _ent__Tb_OT_Encabezado_Manual.periodo;

            //Session["nom_equipos"] = _ent_Tb_OT_Detalle_Manual.nom_equipos;
            //Session["detalle_actividad"] = _ent_Tb_OT_Detalle_Manual.detalle_actividad;

            this.ModalPopupInfo.Show();
        }

        public void CrearNuevoEquipo(string Message, tipoMensaje tipo, int operacion, ENT_Tb_Equipos _ent_Tb_Equipos, int dispo)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["Oper"] = operacion.ToString();
            Session["rut_empresa"] = Convert.ToString(_ent_Tb_Equipos.rut_empresa);
            Session["nom_equipos"] = _ent_Tb_Equipos.nom_equipos;
            Session["nom_corto_eq"] = _ent_Tb_Equipos.nom_corto;
            Session["dispo"] = Convert.ToString(dispo);

            this.ModalPopupInfo.Show();
        }

        public void EliminarEquipo(string Message, tipoMensaje tipo, ENT_Tb_Equipos oEquipos, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["Oper"] = operacion.ToString();
            Session["rut_empresa"] = Convert.ToString(oEquipos.rut_empresa);
            Session["cod_equipo"] = Convert.ToString(oEquipos.cod_equipos);

            this.ModalPopupInfo.Show();
        }

        public void EditarNuevoEquipo(string Message, tipoMensaje tipo, int operacion, ENT_Tb_Equipos _ent_Tb_Equipos, int dispo)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["Oper"] = operacion.ToString();
            Session["rut_empresa"] = Convert.ToString(_ent_Tb_Equipos.rut_empresa);
            Session["nom_equipos"] = _ent_Tb_Equipos.nom_equipos;
            Session["nom_corto_eq"] = _ent_Tb_Equipos.nom_corto;
            Session["dispo"] = Convert.ToString(dispo);
            Session["cod_equipo"] = Convert.ToString(_ent_Tb_Equipos.cod_equipos);

            this.ModalPopupInfo.Show();
        }

        public void NuevoActividad(string Message, tipoMensaje tipo, ENT_Tb_Actividades oActividad, int operacion)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "ADVERTENCIA";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/css/images-controls/Informacion.jpg";
            }
            else
            {
                imgicono.ImageUrl = "~/css/images-controls/mensaje.png";
            }

            Session["pTipo_Equipo"] = oActividad.Tipo_Equipo.ToString();
            Session["pComponente"] = oActividad.Componente.ToString();
            Session["pActividad"] = oActividad.Actividad.ToString();
            Session["rut_empresa"] = oActividad.Rut_Empresa.ToString();
            Session["pPeriodo_Actividad"] = oActividad.Periodo_Actividad.ToString();
            Session["pNom_Disp"] = oActividad.Nom_Disp.ToString();
            Session["pCod_Nom_Dispo"] = oActividad.Cod_Nom_Dispo.ToString();
            Session["Oper"] = operacion.ToString();

            this.ModalPopupInfo.Show();
        }

        private void Hide()
        {
            LblTitle.Text = "";
            lblMensaje.Text = "";
            this.ModalPopupInfo.Hide();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            string rut = (string)Session["OTRut"];
            string ot = (string)Session["OTrabajo"];
            string cod = (string)Session["CodAct"];
            string ope = (string)Session["Oper"];
            string pXml = (string)Session["Xml"];
            string pEstado = (string)Session["OEstado"];
            string pNomEMP = (string)Session["NOMEMP"];
            string PRut = (string)Session["PRut"];
            string PNombre = (string)Session["PNombre"];
            string PApellido = (string)Session["PApellido"];
            string PCargo = (string)Session["PCargo"];
            string PContrasenia = (string)Session["PContrasenia"];
            string prut_empresa = (string)Session["rut_empresa"];
            string pnom_empresa = (string)Session["nom_empresa"];
            string pperiodo = (string)Session["periodo"];
            string pnom_equipos = (string)Session["nom_equipos"];
            string pdetalle_actividad = (string)Session["detalle_actividad"];
            string pObserActividades = (string)Session["pObserActividades"];
            string pNomEqui = (string)Session["nom_equipos"];
            string pNomEquiCorto = (string)Session["nom_corto_eq"];
            string pTipDispo = (string)Session["dispo"];
            string pCodEquipo = (string)Session["cod_equipo"];

            string pTipo_Equipo = (string)Session["pTipo_Equipo"];
            string pComponente = (string)Session["pComponente"];
            string pActividad = (string)Session["pActividad"];
            string pPeriodo_Actividad = (string)Session["pPeriodo_Actividad"];
            string pNom_Disp = (string)Session["pNom_Disp"];
            string pCod_Nom_Dispo = (string)Session["pCod_Nom_Dispo"];




            //********************************
            //********************************
            //Cerrar OT
            //if ((rut != null) && (ot != null) && (ope == "1"))
            if ((ope == "1"))
            {

                _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(rut);
                _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(ot);

                //funcion ejecuta en bd
                res = _lgn_Tb_OT_Encabezado.Actualiza_CerrarOTenTrabajo(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "1";
                    Session["Resultado"] = "Orden de trabajo cerrada en forma correcta";
                    //info.ShowMessage("Orden de trabajo cerrada en forma correcta", controls.informacion.tipoMensaje.Mensaje);
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
                }
                else
                {
                    Session["pControl"] = "1";
                    Session["Resultado"] = res;
                    //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
                }

            }

            //********************************
            //********************************
            //Cerrar Actividad
            //if ((rut != null) && (ot != null) && (ope == "2"))
            if ((ope == "2"))
            {
                _ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(rut);
                _ent_Tb_Actividades.NumOt = Convert.ToDouble(ot);
                _ent_Tb_Actividades.Cod_Act = Convert.ToInt32(cod);
                _ent_Tb_Actividades.ObservacionAct = pObserActividades;

                res = _lgn_Tb_Actividades.Actualiza_EstadoActividadOt(_ent_Tb_Actividades);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "2";
                    Session["Resultado"] = "Actividad fue cerrada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "2";
                    Session["Resultado"] = "No fue cerrada la actividad en forma correcta";
                    //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
                }

            }

            //********************************
            //********************************
            //Crear OT
            if ((ope == "3"))
            {

                res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(pXml);

                //Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["Resultado"] = "Orden fue creada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "3";
                    Session["Resultado"] = res;
                    //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
                }

            }

            //********************************
            //********************************
            //Modifica OT
            if ((ope == "4"))
            {
                _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(rut);
                _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(ot);
                _ent_Tb_OT_Encabezado.estado = Convert.ToInt32(pEstado);


                res = _lgn_Tb_OT_Encabezado.Modifica_OrdenTrabajo(_ent_Tb_OT_Encabezado);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["Resultado"] = "Orden modificada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "3";
                    Session["Resultado"] = res;
                    //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);            
                }

            }

            //********************************
            //********************************
            //Crea nueva empresa
            if ((ope == "5"))
            {
                _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(rut);
                _ent_Tb_Empresas.nom_empresa = pNomEMP;


                //inserta nueva empresa
                res = _lgn_tb_empresas.Inserta_NuevaEmpresa(_ent_Tb_Empresas);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "5";
                    Session["Resultado"] = "Empresa fue agregada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "5";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //Modifica empresa
            if ((ope == "6"))
            {
                _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(rut);
                _ent_Tb_Empresas.nom_empresa = pNomEMP;


                //actualiza empresa
                res = _lgn_tb_empresas.Actualiza_Empresas(_ent_Tb_Empresas);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "6";
                    Session["Resultado"] = "Empresa fue actualizada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "6";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //eliminar empresa
            if ((ope == "7"))
            {
                _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(rut);

                //desactivo empresa
                res = _lgn_tb_empresas.Actualiza_EstadoEmpresas(_ent_Tb_Empresas);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "7";
                    Session["Resultado"] = "Empresa fue eliminada en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "7";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //eliminar personal
            if ((ope == "8"))
            {
                _ent_Tb_Personal.rut_personal = Convert.ToDouble(PRut);
                _ent_Tb_Personal.nom_empleado = PNombre;
                _ent_Tb_Personal.ape_empleado = PApellido;
                _ent_Tb_Personal.Cod_Cargo = Convert.ToInt32(PCargo);
                _ent_Tb_Personal.contrasenia = PContrasenia;

                //desactivo funcionario
                res = _lgn_Tb_Personal.Actualiza_EstadoPersonal(_ent_Tb_Personal);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "8";
                    Session["Resultado"] = "Funcionario fue eliminado en forma correcta";
                    //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);
                }
                else
                {
                    Session["pControl"] = "8";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //agregar personal
            if ((ope == "9"))
            {
                _ent_Tb_Personal.rut_personal = Convert.ToDouble(PRut);
                _ent_Tb_Personal.nom_empleado = PNombre;
                _ent_Tb_Personal.ape_empleado = PApellido;
                _ent_Tb_Personal.Cod_Cargo = Convert.ToInt32(PCargo);
                _ent_Tb_Personal.contrasenia = PContrasenia;

                //desactivo funcionario
                res = _lgn_Tb_Personal.Inserta_NuevoPersonal(_ent_Tb_Personal);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "9";
                    Session["Resultado"] = "Funcionario agregado en forma correcta";
                }
                else
                {
                    Session["pControl"] = "9";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //editar personal
            if ((ope == "10"))
            {
                _ent_Tb_Personal.rut_personal = Convert.ToDouble(PRut);
                _ent_Tb_Personal.nom_empleado = PNombre;
                _ent_Tb_Personal.ape_empleado = PApellido;
                _ent_Tb_Personal.Cod_Cargo = Convert.ToInt32(PCargo);
                _ent_Tb_Personal.contrasenia = PContrasenia;

                //desactivo funcionario
                res = _lgn_Tb_Personal.Modifica_Personal(_ent_Tb_Personal);

                Session["Resultado"] = null;

                if (res == "1")
                {
                    Session["pControl"] = "10";
                    Session["Resultado"] = "Datos del funcionario fueron modificados en forma correcta";
                }
                else
                {
                    Session["pControl"] = "10";
                    Session["Resultado"] = res;
                }

            }

            //********************************
            //********************************
            //crear orden manual
            if ((ope == "11"))
            {
                string det = string.Empty;

                int folioOTMan = _lgn_Tb_OT_Encabezado_Manual.Selecciona_CreaFolioOT();

                _ent_Tb_OT_Encabezado_Manual.num_ot = folioOTMan;
                _ent_Tb_OT_Encabezado_Manual.rut_empresa = Convert.ToDouble(prut_empresa);
                _ent_Tb_OT_Encabezado_Manual.nom_empresa = pnom_empresa;
                _ent_Tb_OT_Encabezado_Manual.periodo = pperiodo;

                //inserto encabezado
                res = _lgn_Tb_OT_Encabezado_Manual.Inserta_NuevaOrdenTrabajo(_ent_Tb_OT_Encabezado_Manual, _ent_Tb_OT_Detalle_Manual);
                Session["Resultado"] = null;

                if (res == "1")
                {
                    DataTable ds1 = Session["datos"] as DataTable;
                    //DataSet ds1 = (DataSet)Session["ds"];
                    int dscount = ds1.Rows.Count;
                    int row = 0;
                    foreach (DataRow fila in ds1.Rows)
                    {
                        _ent_Tb_OT_Detalle_Manual.num_ot = folioOTMan;
                        _ent_Tb_OT_Detalle_Manual.rut_empresa = _ent_Tb_OT_Encabezado_Manual.rut_empresa;
                        _ent_Tb_OT_Detalle_Manual.nom_equipos = fila[1].ToString();
                        _ent_Tb_OT_Detalle_Manual.detalle_actividad = fila[2].ToString();

                        det = _lgn_Tb_OT_Encabezado_Manual.Inserta_DetalleNuevaOrdenTrabajoManual(_ent_Tb_OT_Detalle_Manual);
                        row = row + 1;
                    }

                    if (dscount == row)
                    {
                        Session["pControl"] = "11";
                        Session["Resultado"] = "Orden fue creada en forma correcta";
                    }
                    else
                    {
                        Session["pControl"] = "11";
                        Session["Resultado"] = res;
                    }
                    //al hacer click sobre el boton okay llama al siguiente delegado
                    OnAceptarButtonPressed(e);

                }
            }

                //********************************
                //********************************
                //CREAR EQUIPO
                if ((ope == "12"))
                {
                    _ent_Tb_Equipos.rut_empresa = Convert.ToDouble(prut_empresa);
                    _ent_Tb_Equipos.nom_equipos = pNomEqui;
                    _ent_Tb_Equipos.nom_corto = pNomEquiCorto;

                    //inserto nuevo equipo
                    res = _lgn_Tb_Equipos.Inserta_NuevaEquipo(_ent_Tb_Equipos, Convert.ToInt32(pTipDispo));

                    Session["Resultado"] = null;

                    if (res == "1")
                    {

                        Session["pControl"] = "12";
                        Session["Resultado"] = "Equipo fue creado en forma correcta";
                    }
                    else
                    {
                        Session["pControl"] = "12";
                        Session["Resultado"] = res;
                    }
                    //al hacer click sobre el boton okay llama al siguiente delegado
                    OnAceptarButtonPressed(e);

                }

                //********************************
                //********************************
                //eliminar EQUIPO
                if ((ope == "13"))
                {
                    _ent_Tb_Equipos.rut_empresa = Convert.ToDouble(prut_empresa);
                    _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(pCodEquipo);
                    

                    //inserto nuevo equipo
                    res = _lgn_Tb_Equipos.Elimina_Equipo(_ent_Tb_Equipos);

                    Session["Resultado"] = null;

                    if (res == "1")
                    {

                        Session["pControl"] = "13";
                        Session["Resultado"] = "Equipo fue eliminado en forma correcta";
                    }
                    else
                    {
                        Session["pControl"] = "13";
                        Session["Resultado"] = res;
                    }
  
                }

                //********************************
                //********************************
                //editar EQUIPO
                if ((ope == "14"))
                {
                    _ent_Tb_Equipos.rut_empresa = Convert.ToDouble(prut_empresa);
                    _ent_Tb_Equipos.nom_equipos = pNomEqui;
                    _ent_Tb_Equipos.nom_corto = pNomEquiCorto;
                    _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(pCodEquipo);

                    //edito equipo
                    res = _lgn_Tb_Equipos.Editar_Equipo(_ent_Tb_Equipos, Convert.ToInt32(pTipDispo));

                    Session["Resultado"] = null;

                    if (res == "1")
                    {

                        Session["pControl"] = "14";
                        Session["Resultado"] = "Equipo fue modificado en forma correcta";
                    }
                    else
                    {
                        Session["pControl"] = "14";
                        Session["Resultado"] = res;
                    }

                }


                //********************************
                //********************************
                //crear actividad
                if ((ope == "15"))
                {
                    _ent_Tb_Actividades.Tipo_Equipo = Convert.ToInt32(pTipo_Equipo);
                    _ent_Tb_Actividades.Componente = Convert.ToString(pComponente);
                    _ent_Tb_Actividades.Actividad = Convert.ToString(pActividad);
                    _ent_Tb_Actividades.Rut_Empresa = Convert.ToDouble(prut_empresa);
                    _ent_Tb_Actividades.Periodo_Actividad = Convert.ToInt32(pPeriodo_Actividad);
                    _ent_Tb_Actividades.Nom_Disp = Convert.ToString(pNom_Disp);
                    _ent_Tb_Actividades.Cod_Nom_Dispo = Convert.ToInt32(pCod_Nom_Dispo);
                        
                    //inserto nueva actividad
                    res = _lgn_Tb_Actividades.Inserta_NuevaActividad(_ent_Tb_Actividades);

                    Session["Resultado"] = null;

                    if (res == "1")
                    {

                        Session["pControl"] = "15";
                        Session["Resultado"] = "Actividad fue creada en forma correcta";
                    }
                    else
                    {
                        Session["pControl"] = "15";
                        Session["Resultado"] = res;
                    }

                }


                //al hacer click sobre el boton okay llama al siguiente delegado
                OnAceptarButtonPressed(e);
            
        }

        //Delegado del Boton
        public delegate void AceptarButtonPressedHandler(object sender, EventArgs args);
        public event AceptarButtonPressedHandler AceptarButtonPressed;
        protected virtual void OnAceptarButtonPressed(EventArgs e)
        {
            if (AceptarButtonPressed != null)
                AceptarButtonPressed(this.btnAceptar, e);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}