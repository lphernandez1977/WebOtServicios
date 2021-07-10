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
using System.Configuration;
using System.Threading;

namespace WebOtServicios
{
    public partial class WebFormOrdenTrabajoCreacion : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataSet DetallePedido = new DataSet();
        DataTable dt = new DataTable();
        
        public DropDownList Cbo = new DropDownList();
        private ENT_Tb_Empresas _ent_Tb_Empresas = new ENT_Tb_Empresas();
        private ENT_Tb_Equipos _ent_Tb_Equipos = new ENT_Tb_Equipos();
        private ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado = new ENT_Tb_OT_Encabezado();
        private ENT_Tb_OT_Detalle _ent_Tb_OT_Detalle = new ENT_Tb_OT_Detalle();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Personal _ENT_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_Periodos _ent_Tb_Periodos = new ENT_Tb_Periodos();
        private ENT_Tb_Tipo_OT _ent_Tb_Tipo_OT = new ENT_Tb_Tipo_OT();

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();
        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_Tb_Periodos _lgn_Tb_Periodos = new LGN_Tb_Periodos();
        private LGN_Tb_Tipo_OT _lgn_Tb_Tipo_OT = new LGN_Tb_Tipo_OT();


        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(Request.QueryString["pRut"]);
            _ent_Tb_Empresas = _lgn_tb_empresas.Selecciona_Empresas(_ent_Tb_OT_Encabezado.rut_empresa);

            LblNomEmp.Text = _ent_Tb_Empresas.nom_empresa;

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("WebFormLogin.aspx");

                //lleno grilla
                //LlenarGrid(Convert.ToDouble(Request.QueryString["pRut"]));

                //Cargo Combo
                CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
                CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);

                DetallePedido.Tables.Add(dt);
                dt.Columns.Add("nom_empresa", typeof(string));
                dt.Columns.Add("cod_equipos", typeof(string));
                dt.Columns.Add("nom_equipos", typeof(string));
                grilla_limpia();

                //valido usuario
                if (PerfilUsuario == "Tecnico")
                {
                    //Response.Write("<script language=javascript>confirm('No tiene atributos para ver este menu');</script>");
                    //info.ShowMessage("No tiene permiso para ver este menu", controls.informacion.tipoMensaje.Mensaje); 
                    Response.Redirect("WebFormMenu.aspx");
                }
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

            if (Session["Resultado"] != null)
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.Mensaje);
            }
        }
        #endregion

        private void LlenarGrid(double pRutEmpresa, int pCodEqui)
        {
            if (this.CboTipoOT.SelectedValue == Convert.ToString("0"))
            {
                info.ShowMessage("Debe seleccionar tipo de equipo", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            ds = _lgn_Tb_Equipos.Selecciona_ListaEquipos(pRutEmpresa, pCodEqui);
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
                //Response.Write("<script language=javascript>confirm('" + ex.Message.ToString()+"');</script>");
                //info.ShowMessage(ex.Message.ToString(), controls.informacion.tipoMensaje.Mensaje); 
                return;
            }
        }

        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvDatos.Rows)
            {
                //CheckBox check = row.FindControl("CheckBox1") as CheckBox;
                CheckBox check = ((CheckBox)row.FindControl("CheckBox1"));

                if (check.Checked == true)
                {
                    check.Checked = false;
                }
                else
                {
                    check.Checked = true;
                }

            }
        }

        protected void GvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);
            GvDatos.PageIndex = e.NewPageIndex;
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRut"]), _ent_Tb_OT_Encabezado.tipo_ot);
        }

        //crea ordenes de trabajo
        protected void BtnOt_Click(object sender, EventArgs e)
        {

            //---- Cargando Espere ----
            //genera un instancia del control hacia el control de Espera
            //infoespere.ShowMessage("Cargando", "", controls.espere.tipoMensaje.Cargando);

            int cont = 0;

            if (this.CboPeriodos.SelectedValue == Convert.ToString("0"))
            {
                info.ShowMessage("Debe asignar periodo a Ordenes De Trabajo", controls.informacion.tipoMensaje.Mensaje);
                //Response.Write("<script language=javascript>confirm('Debe asignar periodo a Ordenes De Trabajo');</script>");
                return;
            }

            if (this.CboTipoOT.SelectedValue == Convert.ToString("0"))
            {
                info.ShowMessage("Debe asignar el tipo de OT", controls.informacion.tipoMensaje.Mensaje);
                //Response.Write("<script language=javascript>confirm('Debe asignar el tipo de OT');</script>");
                return;
            }

            int operacion = 3;

            //*******************funcion crear ot*******************
            XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
            //nodo raiz
            XElement nodoraiz = new XElement("OrdenTrabajo");
            documento.Add(nodoraiz);

            //creo folio
            _ent_Tb_OT_Encabezado.num_ot = _lgn_Tb_OT_Encabezado.Selecciona_CreaFolioOT(_ent_Tb_OT_Encabezado.rut_empresa);

            //creacion de ot individuales
            foreach (GridViewRow row in GvDatos.Rows)
            {
                CheckBox check = ((CheckBox)row.FindControl("CheckBox1"));

                if (check.Checked == true)
                {

                    //cabecera ot
                    _ent_Tb_OT_Encabezado.fecha_creacion_ot = DateTime.Now;//DateTime.ParseExact(_lgn_FechaHoraServer.Selecciona_FechaHoraServer(), "dd/MM/yyyy H:mm:ss", null);
                    _ent_Tb_OT_Encabezado.estado = 1;
                    _ent_Tb_OT_Encabezado.rut_crea_ot = Convert.ToDouble((string)Session["RutUsuario"]);
                    _ent_Tb_OT_Encabezado.periodo = Convert.ToInt32(this.CboPeriodos.SelectedValue);//perido sem-men-tri
                    _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);//transportado-cctv-incendio

                    //detalle ot
                    _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(row.Cells[1].Text);
                    _ent_Tb_OT_Detalle.num_ot = _ent_Tb_OT_Encabezado.num_ot;
                    _ent_Tb_OT_Detalle.cod_equipos = _ent_Tb_Equipos.cod_equipos;
                    _ent_Tb_OT_Detalle.estado_mantencion = "P";
                    _ent_Tb_OT_Detalle.rut_empresa = _ent_Tb_OT_Encabezado.rut_empresa;
                    _ent_Tb_OT_Detalle.variableNum = _ent_Tb_OT_Encabezado.periodo;


                    //Creamos el nodo cabecera
                    XElement CabCombo = new XElement("CabeceraOrdenTrabajo");
                    CabCombo.Add(new XElement("num_ot", _ent_Tb_OT_Encabezado.num_ot));
                    CabCombo.Add(new XElement("rut_empresa", _ent_Tb_OT_Encabezado.rut_empresa));
                    CabCombo.Add(new XElement("fecha_creacion_ot", _ent_Tb_OT_Encabezado.fecha_creacion_ot));
                    CabCombo.Add(new XElement("estado", _ent_Tb_OT_Encabezado.estado));
                    CabCombo.Add(new XElement("rut_crea_ot", _ent_Tb_OT_Encabezado.rut_crea_ot));
                    CabCombo.Add(new XElement("periodo", _ent_Tb_OT_Encabezado.periodo));
                    CabCombo.Add(new XElement("tipo", _ent_Tb_OT_Encabezado.tipo_ot));
                    nodoraiz.Add(CabCombo);

                    //Creamos el nodo Detalle
                    XElement nododetalle = new XElement("DetalleOT");
                    CabCombo.Add(nododetalle);

                    XElement DetCombo = new XElement("DetalleOrdenTrabajo");
                    DetCombo.Add(new XElement("num_ot", _ent_Tb_OT_Detalle.num_ot));
                    DetCombo.Add(new XElement("cod_equipos", _ent_Tb_OT_Detalle.cod_equipos));
                    DetCombo.Add(new XElement("estado_mantencion", _ent_Tb_OT_Detalle.estado_mantencion));
                    DetCombo.Add(new XElement("rut_empresa", _ent_Tb_OT_Detalle.rut_empresa));
                    nododetalle.Add(DetCombo);

                    //aumento CORRELATIVO
                    _ent_Tb_OT_Encabezado.num_ot = ++_ent_Tb_OT_Encabezado.num_ot;

                    cont = ++cont;
                }
            }
            string xml = nodoraiz.ToString();

            if (cont >= 1)
            {
                //asigno variables
                confirmacion.CrearOrdenTrabajo("¿Desea crear ordenes de trabajo, Para los equipos seleccionados?", controls.confirmacion.tipoMensaje.advertencia, operacion, xml);
                //this.CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
                //this.CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);
            }
            else
            {
                //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
                //Response.Write("<script language=javascript>alert('Problemas para crear Ordenes De Trabajo');</script>");
                this.CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
                this.CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);
                return;
            }  


            //if (cont >= 1)
            //{
            //    string res = string.Empty;
            //    res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(xml);

            //    if (res == "1") 
            //    {                 
            //        //Response.Write("<script language=javascript>alert('Fueron Creadas las Ordenes De Trabajo');</script>");
            //        //info.ShowMessage("Fueron Creadas las Ordenes De Trabajo", controls.informacion.tipoMensaje.Mensaje);                    
            //        this.CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
            //        this.CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);
            //        return;
            //    }
            //    else
            //    {
            //        //info.ShowMessage(res, controls.informacion.tipoMensaje.Mensaje);
            //        //Response.Write("<script language=javascript>alert('Problemas para crear Ordenes De Trabajo');</script>");
            //        this.CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
            //        this.CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);
            //        return;
            //    }                
            //}
            //else
            //{
            //    //info.ShowMessage("Seleccione Equipos para crear Ordenes de Trabajo", controls.informacion.tipoMensaje.Mensaje);
            //    //Response.Write("<script language=javascript>alert('Seleccione Equipos para crear Orden de Trabajo');</script>");
            //}                                                                    
        }

        //public bool GeneraXml(ENT_Tb_OT_Encabezado _oEncabezadoOt, ENT_Tb_OT_Detalle _oDetalleOt)
        //{
        //    try
        //    {
        //        XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
        //        //nodo raiz
        //        XElement nodoraiz = new XElement("OrdenTrabajo");
        //        documento.Add(nodoraiz);

        //        //Creamos el nodo cabecera
        //        XElement CabCombo = new XElement("CabeceraOrdenTrabajo");
        //        CabCombo.Add(new XElement("num_ot", _oEncabezadoOt.num_ot));
        //        CabCombo.Add(new XElement("rut_empresa", _oEncabezadoOt.rut_empresa));
        //        CabCombo.Add(new XElement("fecha_creacion_ot", _oEncabezadoOt.fecha_creacion_ot));
        //        CabCombo.Add(new XElement("estado", _oEncabezadoOt.estado));
        //        CabCombo.Add(new XElement("rut_crea_ot", _oEncabezadoOt.rut_crea_ot));
        //        nodoraiz.Add(CabCombo);

        //        //Creamos el nodo Detalle
        //        XElement DetCombo = new XElement("DetalleOrdenTrabajo");
        //        DetCombo.Add(new XElement("num_ot", _oDetalleOt.num_ot));
        //        DetCombo.Add(new XElement("cod_equipos", _oDetalleOt.cod_equipos));
        //        DetCombo.Add(new XElement("estado_mantencion", _oDetalleOt.estado_mantencion));
        //        nodoraiz.Add(DetCombo);


        //        string xml = nodoraiz.ToString();
        //        //genera archivo xml                
        //        //nodoraiz.Save(@"E:\Fichero.xml");

        //        //bool res = false;
        //        //res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(xml);

        //        //if (res)
        //        //{
        //        return true;
        //        //}
        //        //else
        //        //{
        //        //    return false;
        //        //}
        //    }

        //    catch (Exception ex)
        //    {
        //        return false;
        //    }


        //}

        //protected void BtnOTxEquipos_Click(object sender, EventArgs e)
        //{
        //    int cont = 0;
        //    //recupero rut empresa
        //    _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(Request.QueryString["pRut"]);


        //    //valido que todos los periodos esten selecionados
        //    foreach (GridViewRow row in GvDatos.Rows)
        //    {
        //        CheckBox valcheck = ((CheckBox)row.FindControl("CheckBox1"));

        //        if (valcheck.Checked == true)
        //        {
        //            string validar = ((DropDownList)row.FindControl("cboCPeriodoGrilla")).SelectedValue;

        //            if (validar == "0")
        //            {
        //                Response.Write("<script language=javascript>alert('Debe seleccionar periodo a equipo');</script>");
        //                return;
        //                //break;                    
        //            }
        //        }
        //    }

        //    //creacion de ot individuales
        //    foreach (GridViewRow row in GvDatos.Rows)
        //    {
        //        CheckBox check = ((CheckBox)row.FindControl("CheckBox1"));

        //        if (check.Checked == true)
        //        {            
        //            //creo folio
        //            _ent_Tb_OT_Encabezado.num_ot = _lgn_Tb_OT_Encabezado.Selecciona_CreaFolioOT(_ent_Tb_OT_Encabezado.rut_empresa);
        //            _ent_Tb_OT_Encabezado.fecha_creacion_ot = DateTime.ParseExact(_lgn_FechaHoraServer.Selecciona_FechaHoraServer(), "dd/MM/yyyy H:mm:ss", null);
        //            _ent_Tb_OT_Encabezado.estado = 1;
        //            _ent_Tb_OT_Encabezado.rut_crea_ot = Convert.ToDouble((string)Session["RutUsuario"]);

        //            //valor del cbo box
        //            string valor = ((DropDownList)row.FindControl("cboCPeriodoGrilla")).SelectedValue;
        //            _ent_Tb_OT_Encabezado.periodo = Convert.ToInt32(valor);

        //            //inserto encabezado de OT
        //            bool res = false;
        //            res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajoxEquipos(_ent_Tb_OT_Encabezado);

        //            if (res)
        //            {
        //                _ent_Tb_Equipos.cod_equipos = Convert.ToInt32(row.Cells[1].Text);
        //                _ent_Tb_OT_Detalle.num_ot = _ent_Tb_OT_Encabezado.num_ot;
        //                _ent_Tb_OT_Detalle.cod_equipos = _ent_Tb_Equipos.cod_equipos;
        //                _ent_Tb_OT_Detalle.estado_mantencion = "P";

        //                bool det = false;
        //                det = _lgn_Tb_OT_Detalle.Inserta_DetalleOrdenTrabajoxEquipos(_ent_Tb_OT_Detalle);

        //                //incremento folio
        //                _ent_Tb_OT_Encabezado.num_ot = ++_ent_Tb_OT_Encabezado.num_ot;

        //                cont = ++ cont;
        //            }
        //            else 
        //            {
        //                Response.Write("<script language=javascript>alert('Error al crear Orden de Trabajo');</script>");
        //                return;
        //                //break;
        //            }
        //        }
        //    }

        //    if (cont >= 1)
        //    {
        //        Response.Write("<script language=javascript>alert('Fueron Creadas las Ordenes De Trabajo');</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script language=javascript>alert('Error al crear Orden de Trabajo');</script>");
        //    }

        //}

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

        protected void GvDatos_DataBound(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //ds =  _lgn_Tb_Periodos.Selecciona_ListaPeriodos();

            //DropDownList drp = ((DropDownList) row.FindControl("cboComboPrueba"));
            //drp =  row.FindControl("cboCPeriodo") as DropDownList;

            //if (drp != null)
            //{
            //    string x = e.Row.Cells[0].Text; // me devuelve el campo clave delg gridview para 
            //    // realizar mi consulta
            //    // aqui rellenarias el dropdown list de la columna

            //    drp.DataSource = ds.Tables[0];
            //    drp.DataTextField = "Nom_Periodo";
            //    drp.DataValueField = "Cod_Periodo";
            //    drp.DataBind();
            //}
        }

        private void CargaCombo(double pRutEmp)
        {
            DataSet ds = new DataSet();
            ds = _lgn_Tb_Periodos.Selecciona_ListaPeriodos(pRutEmp);

            if (ds != null)
            {
                this.CboPeriodos.DataSource = ds.Tables[0];
                this.CboPeriodos.DataTextField = "Nom_Periodo";
                this.CboPeriodos.DataValueField = "Cod_Periodo";
                this.CboPeriodos.DataBind();
                this.CboPeriodos.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }
        }

        private void CargaComboTipo(double pRutEmp)
        {
            DataSet ds = new DataSet();
            ds = _lgn_Tb_Tipo_OT.Selecciona_ListaTipoOT(pRutEmp);

            if (ds != null)
            {
                this.CboTipoOT.DataSource = ds.Tables[0];
                this.CboTipoOT.DataTextField = "NomTipOt";
                this.CboTipoOT.DataValueField = "CodTipOt";
                this.CboTipoOT.DataBind();
                this.CboTipoOT.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            }
        }

        protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataSet ds = new DataSet();
            //    ds = _lgn_Tb_Periodos.Selecciona_ListaPeriodos();

            //    if (ds != null)
            //    {
            //        Cbo = (DropDownList)e.Row.FindControl("cboCPeriodoGrilla");
            //        Cbo.DataSource = ds.Tables[0];
            //        Cbo.DataTextField = "Nom_Periodo";
            //        Cbo.DataValueField = "Cod_Periodo";
            //        Cbo.DataBind();
            //        Cbo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            //    }
            //}


        }

        protected void BtnEquipos_Click(object sender, EventArgs e)
        {
            ////lleno grilla
            _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRut"]), _ent_Tb_OT_Encabezado.tipo_ot);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/WebFormOrdenTrabajoSeleccion.aspx");
            //Response.Redirect("WebFormOrdenTrabajo.aspx?pRutEmp=" + _ent_Tb_OT_Encabezado.rut_empresa + "&pNumOt=" + _ent_Tb_OT_Encabezado.num_ot);

            Response.Redirect("WebFormOrdenTrabajo.aspx");

        }

        private void grilla_limpia()
        {
            
            dt.Clear();
            DataRow row = dt.NewRow();
            //row["Rut"] = "";
            //row["Nombre"] = "";

            row["nom_empresa"] = "";
            row["cod_equipos"] = "";
            row["nom_equipos"] = "";
            dt.Rows.Add(row);

            this.GvDatos.DataSource = DetallePedido.Tables[0];
            this.GvDatos.DataBind();
        }
    }


}