using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//****************************
using Dll_LgNegocios;
using Dll_Entidades;
using System.Data;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Configuration;
using System.Threading;




namespace WebOtServicios
{
    public partial class WebFormMantenedorOTDetalle : System.Web.UI.Page
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
        private ENT_Tb_EstadosOT _ent_Tb_EstadosOT = new ENT_Tb_EstadosOT();
        private ENT_Tb_Periodos _ent_Tb_Periodos = new ENT_Tb_Periodos();

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();
        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private LGN_Tb_DesActxTecnicos _lgn_Tb_DesActxTecnicos = new LGN_Tb_DesActxTecnicos();
        private LGN_Tb_Estados_OT _lgn_Tb_Estados_OT = new LGN_Tb_Estados_OT();

        Funciones.EnviarMail Mail = new Funciones.EnviarMail();

        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            //USUARIO LOGUEADO
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(UsuarioId);
            //empresa


            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("WebFormLogin.aspx");

                //lleno grilla
                LlenarGrid(Convert.ToDouble(Request.QueryString["pRutEmp"]), 0, 0,"1/1/1900","12/31/2100"); ;

                CargaCombo();
            }

            _ent_Tb_Empresas = _lgn_tb_empresas.Selecciona_Empresas(Convert.ToDouble(Request.QueryString["pRutEmp"]));

            LblNomEmp.Text = _ent_Tb_Empresas.nom_empresa;

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
            info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.advertencia);
            //Response.Redirect("WebFormMantenedorOT.aspx");
        }
        #endregion

        private void LlenarGrid(double pRutEmp, float pNumOt, int pEstado, string pFecIni, string pFecTer)
        {
            ds = _lgn_Tb_Equipos.Selecciona_OrdenesxEquipos(pRutEmp, pNumOt, pEstado, pFecIni, pFecTer);
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormMantenedorOT.aspx");
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
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRutEmp"]), 0, 0, "1/1/1900", "12/31/2100");
        }

        //protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DataRowView dr = (DataRowView)e.Row.DataItem;
        //    ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect");
        //    if (ImgSelect != null)
        //    {
        //        // Imagina que es un valor entero. y verificamos que sea 1 para mostrar la imagen
        //        if (//(Convert.ToDouble(dr["rut_personal"].ToString()) == _ent_Tb_Personal.rut_personal) ||
        //            (dr["Nom_Estado"].ToString() == "Cerrada")
        //            )
        //        {
        //            //ImgSelect.Enabled = true;
        //            ImgSelect.Visible = false;
        //        }
        //        else
        //        {
        //            //ImgSelect.Enabled = false;
        //            ImgSelect.Visible = true;
        //        }
        //    }
        //}

        protected void GvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GvDatos.Rows[index];

            _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["num_ot"]);
            string cbo = GvDatos.DataKeys[row.RowIndex].Values["Nom_Estado"].ToString();

            if (e.CommandName == "Editar")
            {
                int val = 0;
                switch (cbo)
                {
                    case "Creado":
                        val = 1;
                        break;
                    case "En Trabajo":
                        val = 2;
                        break;
                    case "Cerrada":
                        val = 3;
                        break;
                    case "Anulada":
                        val = 4;
                        break;
                }

                TxtOT.Text = Convert.ToString(_ent_Tb_OT_Encabezado.num_ot);
                this.CboEstado.SelectedValue = val.ToString();
            }

            if (e.CommandName == "Exportar")
            {
                //FUNCION EXPORTAR PDF  
                GenPdfOT(Convert.ToDouble(Request.QueryString["pRutEmp"]), _ent_Tb_OT_Encabezado.num_ot);
            }

            if (e.CommandName == "TareasPendientes")
            {
                //FUNCION EXPORTAR PDF  
                GenPdfOTActPend(Convert.ToDouble(Request.QueryString["pRutEmp"]), _ent_Tb_OT_Encabezado.num_ot);
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


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect3");
                ImgSelect.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }

            DataRowView dr = (DataRowView)e.Row.DataItem;
            ImageButton ImgSelect3 = (ImageButton)e.Row.FindControl("ImgSelect3");
            if (ImgSelect3 != null)
            {
                // Imagina que es un valor entero. y verificamos que sea 1 para mostrar la imagen
                if (//(Convert.ToDouble(dr["rut_personal"].ToString()) == _ent_Tb_Personal.rut_personal) ||
                    (dr["TareaPend"].ToString() == "Y")
                    )
                {
                    //ImgSelect.Enabled = true;
                    ImgSelect3.Visible = true;
                }
                else
                {
                    //ImgSelect.Enabled = false;
                    ImgSelect3.Visible = false;
                }
            }
        }

        public bool GenPdfOT(double pRutEmp, double pNumOt)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            String destino = Server.MapPath($@"\Download\{LblNomEmp.Text}_TareasOrdenTrabajo_{pNumOt}.pdf");
            FileStream file = new FileStream(destino, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            string fCrea = string.Empty;
            string fTerm = string.Empty;
            string path = Server.MapPath("Img/logo-cloud.png");

            //obtengo todos los datos de la OT
            ds = _lgn_Tb_OT_Encabezado.Selecciona_EncabezadoOtPDF(pRutEmp, pNumOt);

            //obtengo todos los datos del equipo
            _ent_Tb_Equipos = _lgn_Tb_Equipos.Selecciona_EquiposOT(pRutEmp, pNumOt);

            if (ds != null)
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(drRow["num_ot"]);
                    _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(drRow["rut_empresa"]);
                    _ent_Tb_Empresas.nom_empresa = drRow["nom_empresa"].ToString();
                    _ent_Tb_OT_Encabezado.estado = Convert.ToInt32(drRow["estado"]);
                    _ent_Tb_EstadosOT.NomEstado = drRow["Nom_Estado"].ToString();
                    _ent_Tb_OT_Encabezado.periodo = Convert.ToInt32(drRow["periodo"]);
                    _ent_Tb_Periodos.Nom_Periodo = drRow["Nom_Periodo"].ToString();
                    fCrea = drRow["Fecha_Creacion"].ToString();
                    fTerm = drRow["Fecha_Cierre"].ToString();
                }
            }

            try
            {
                //descargar
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                PdfWriter.GetInstance(pdfDoc, file);

                //Open PDF Document to write data 
                pdfDoc.Open();

                string cadenaFinal = "";
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                cadenaFinal = cadenaFinal + "<tr style='text-align:left'>";
                cadenaFinal = cadenaFinal + "<td colspan='3'><img src='" + path + "'/></td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:left'width='33%'>ORDEN DE TRABAJO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'width='33%'>FOLIO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'width='33%'>" + _ent_Tb_OT_Encabezado.num_ot + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td>PLANTA</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_Empresas.nom_empresa + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_EstadosOT.NomEstado + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>PERIODO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CREACIÓN</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CIERRE</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_Periodos.Nom_Periodo.ToUpper() + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fCrea + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fTerm + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>DETALLE EQUIPO</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center'>" + _ent_Tb_Equipos.nom_equipos + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>ACTIVIDADES REALIZADAS</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "</table>";

                //obtengo todos los datos de las actividades
                DataSet dsd = new DataSet();
                dsd = _lgn_Tb_OT_Detalle.Selecciona_DetalleOtPDF(pRutEmp, pNumOt);
                int pos = 1;
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";

                if (dsd != null)
                {
                    foreach (DataRow drRow in dsd.Tables[0].Rows)
                    {
                        cadenaFinal = cadenaFinal + "<tr><td>" + pos + ".-" + drRow["actividad"].ToString() + "</td></tr>";
                        pos = pos + 1;
                    }
                }

                cadenaFinal = cadenaFinal + "</table>";

                //***************************************************
                //***************************************************
                //TECNICO REALIZA ACTIVIDADES
                //***************************************************
                //***************************************************

                //si ot esta cerrada genero este codigo
                if (_ent_Tb_OT_Encabezado.estado == 3)
                {
                    DataSet dt = new DataSet();
                    dt = _lgn_Tb_DesActxTecnicos.Selecciona_ActividadesxTecnico(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);

                    cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                    cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>TECNICO ACTIVIDAD</td></tr>";

                    if (dt != null)
                    {
                        foreach (DataRow drRow in dt.Tables[0].Rows)
                        {
                            cadenaFinal = cadenaFinal + "<tr><td>" + drRow["tecnico"].ToString() + "</td></tr>";
                        }
                    }

                    cadenaFinal = cadenaFinal + "</table>";


                    //***************************************************
                    //OBSERVACIONES A LAS ACTIVIDADES
                    cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                    cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>OBSERVACIONES</td></tr>";

                    DataSet dtObservaciones = new DataSet();
                    dtObservaciones = _lgn_Tb_OT_Detalle.Selecciona_DetalleObservacionPDF(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);
                    int num = 1;

                    if (dtObservaciones != null)
                    {
                        foreach (DataRow drRow in dtObservaciones.Tables[0].Rows)
                        {
                            //cadenaFinal = cadenaFinal + "<tr><td>" + drRow["Observacion"].ToString() + "</td></tr>";
                            cadenaFinal = cadenaFinal + "<tr><td>" + num + ".-" + drRow["Observacion"].ToString() + "</td></tr>";
                            num = num + 1;
                        }
                    }  
                    cadenaFinal = cadenaFinal + "</table>";
                }
                else
                {
                    cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                    cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>TECNICO ACTIVIDAD</td></tr>";
                    cadenaFinal = cadenaFinal + "<tr><td>SIN TÉCNICO ASOCIADO</td></tr>";
                    cadenaFinal = cadenaFinal + "</table>";
                }

                //Assign Html content in a string to write in PDF 
                string strContent = cadenaFinal;

                //Read string contents using stream reader and convert html to parsed conent 
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document 
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF 
                pdfDoc.Close();

                Process.Start(destino);

                //Response.ContentType = "application/pdf";
                //Set default file Name as current datetime 
                Response.AddHeader("content-disposition", "attachment; filename=" + LblNomEmp.Text + "_" + "_TareasOrdenTrabajo_" + pNumOt + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);                

                Response.Flush();
                Response.Close();

                //Mail.SendMail(destino, pNumOt.ToString(), LblNomEmp.Text);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (TxtOT.Text == string.Empty)
            {
                info.ShowMessage("Selecciones orden válida", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            if (this.CboEstado.SelectedValue == "0")
            {
                info.ShowMessage("Selecciones estado válido", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            //4 modificacion ot

            int operacion = 4;

            //asigno variables
            _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(Request.QueryString["pRutEmp"]);
            _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(TxtOT.Text);
            _ent_Tb_OT_Encabezado.estado = Convert.ToInt32(this.CboEstado.SelectedValue);

            confirmacion.ModificarOT("¿Desea modificar el estado de la OT?", controls.confirmacion.tipoMensaje.advertencia, operacion, _ent_Tb_OT_Encabezado);
        }

        private void CargaCombo()
        {
            DataSet ds = new DataSet();
            ds = _lgn_Tb_Estados_OT.Selecciona_EstadosOT();

            if (ds != null)
            {
                this.CboEstado.DataSource = ds.Tables[0];
                this.CboEstado.DataTextField = "Nom_Estado";
                this.CboEstado.DataValueField = "Cod_Estado_Ot";
                this.CboEstado.DataBind();
                this.CboEstado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opcion..", "0"));
            }
        }

        public bool GenPdfOTActPend(double pRutEmp, double pNumOt)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            
            String destino = Server.MapPath($@"\Download\{LblNomEmp.Text}_TareasPendientesOT_{pNumOt}.pdf");
            FileStream file = new FileStream(destino, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            string fCrea = string.Empty;
            string fTerm = string.Empty;
            string path = Server.MapPath("Img/logo-cloud.png");

            //obtengo todos los datos de la OT
            ds = _lgn_Tb_OT_Encabezado.Selecciona_EncabezadoOtPDF(pRutEmp, pNumOt);

            //obtengo todos los datos del equipo
            _ent_Tb_Equipos = _lgn_Tb_Equipos.Selecciona_EquiposOT(pRutEmp, pNumOt);



            if (ds != null)
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {

                    _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(drRow["num_ot"]);
                    _ent_Tb_OT_Encabezado.rut_empresa = Convert.ToDouble(drRow["rut_empresa"]);
                    _ent_Tb_Empresas.nom_empresa = drRow["nom_empresa"].ToString();
                    _ent_Tb_OT_Encabezado.estado = Convert.ToInt32(drRow["estado"]);
                    _ent_Tb_EstadosOT.NomEstado = drRow["Nom_Estado"].ToString();
                    _ent_Tb_OT_Encabezado.periodo = Convert.ToInt32(drRow["periodo"]);
                    _ent_Tb_Periodos.Nom_Periodo = drRow["Nom_Periodo"].ToString();
                    fCrea = drRow["Fecha_Creacion"].ToString();
                    fTerm = drRow["Fecha_Cierre"].ToString();
                }
            }

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

                //Open PDF Document to write data 
                pdfDoc.Open();

                string cadenaFinal = "";
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                cadenaFinal = cadenaFinal + "<tr style='text-align:left'>";
                cadenaFinal = cadenaFinal + "<td colspan='3'><img src='" + path + "'/></td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:left'width='33%'>ORDEN DE TRABAJO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'width='33%'>FOLIO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'width='33%'>" + _ent_Tb_OT_Encabezado.num_ot + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td>PLANTA</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_Empresas.nom_empresa + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_EstadosOT.NomEstado + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>PERIODO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CREACIÓN</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CIERRE</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_Periodos.Nom_Periodo.ToUpper() + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fCrea + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fTerm + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>DETALLE EQUIPO</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center'>" + _ent_Tb_Equipos.nom_equipos + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>ACTIVIDADES NO REALIZADAS</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "</table>";

                //obtengo todos los datos de las actividades
                DataSet dsd = new DataSet();
                dsd = _lgn_Tb_OT_Detalle.Selecciona_DetalleOtPDFPendiente(pRutEmp, pNumOt);
                int pos = 1;
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";

                if (dsd != null)
                {
                    foreach (DataRow drRow in dsd.Tables[0].Rows)
                    {
                        cadenaFinal = cadenaFinal + "<tr><td>" + pos + ".-" + drRow["actividad"].ToString() + "</td></tr>";
                        pos = pos + 1;
                    }
                }

                cadenaFinal = cadenaFinal + "</table>";


                //si ot esta cerrada genero este codigo
                //if (_ent_Tb_OT_Encabezado.estado == 3)
                //{
                //    DataSet dt = new DataSet();
                //    dt = _lgn_Tb_DesActxTecnicos.Selecciona_ActividadesxTecnico(_ent_Tb_OT_Encabezado.rut_empresa, _ent_Tb_OT_Encabezado.num_ot);

                //    cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                //    cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>TECNICO ACTIVIDAD</td></tr>";

                //    if (dt != null)
                //    {
                //        foreach (DataRow drRow in dt.Tables[0].Rows)
                //        {
                //            cadenaFinal = cadenaFinal + "<tr><td>" + drRow["tecnico"].ToString() + "</td></tr>";
                //        }
                //    }

                //    cadenaFinal = cadenaFinal + "</table>";
                //}
                //else
                //{
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>TECNICO ACTIVIDAD</td></tr>";
                cadenaFinal = cadenaFinal + "</table>";
                //}

                //Assign Html content in a string to write in PDF 
                string strContent = cadenaFinal;

                //Read string contents using stream reader and convert html to parsed conent 
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document 
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF 
                pdfDoc.Close();


                Process.Start(destino);

                //Response.ContentType = "application/pdf";
                //Set default file Name as current datetime 
                Response.AddHeader("content-disposition", "attachment; filename=" + LblNomEmp.Text + "_" + "_TareasPendientesOT_" + pNumOt + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.Close();

                Mail.SendMail(destino, pNumOt.ToString(), LblNomEmp.Text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            float varOtNum = 0;
            int varEstado = 0;


            if (TxtOT.Text == string.Empty)
            {
                varOtNum = 0;
            }
            else
            {
                varOtNum = Convert.ToInt32(TxtOT.Text);
            }


            varEstado = Convert.ToInt32(CboEstado.SelectedValue);

            if (varEstado == 0)
            {
                varEstado = 0;
            }
            else
            {
                varEstado = Convert.ToInt32(Convert.ToInt32(CboEstado.SelectedValue));
            }

            string FecIni = string.Format("{0:MM/dd/yyyy}", TxtFecIni.Text);
            string FecTer = string.Format("{0:MM/dd/yyyy}", TxtFecTer.Text);

            if ((TxtFecIni.Text == string.Empty) && (TxtFecTer.Text == string.Empty)) 
            {
                FecIni = "01/01/1900";
                FecTer = "12/31/2100";                     
            }

            LlenarGrid(Convert.ToDouble(Request.QueryString["pRutEmp"]), varOtNum, varEstado, FecIni,FecTer);

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CboEstado.SelectedValue = "0";
            TxtOT.Text = string.Empty;
            TxtFecIni.Text = string.Empty;
            TxtFecTer.Text = string.Empty;
        }

   
    }
}