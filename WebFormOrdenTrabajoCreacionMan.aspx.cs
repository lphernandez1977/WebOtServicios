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
    public partial class WebFormOrdenTrabajoCreacionMan : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        public DataTable dtpaso = new DataTable();
        DataTable dt = new DataTable();
        DataSet DetallePedido = new DataSet();

        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Tb_Personal _ENT_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_OT_Encabezado_Manual _ent_Tb_OT_Encabezado_Manual = new ENT_Tb_OT_Encabezado_Manual();
        private ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual = new ENT_Tb_OT_Detalle_Manual();
        private LGN_Tb_OT_Encabezado_Manual _lgn_Tb_OT_Encabezado_Manual = new LGN_Tb_OT_Encabezado_Manual();
        private LGN_Tb_OT_Detalle_Manual _lgn_Tb_OT_Detalle_Manual = new LGN_Tb_OT_Detalle_Manual();


        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("WebFormLogin.aspx");

                //lleno grilla
                LlenarGrid();

                Session["dt"] = null;

                //crea el data table               
                DetallePedido.Tables.Add(dt);
                //dt.Columns.Add("Rut", typeof(string));
                //dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Pos", typeof(string));
                dt.Columns.Add("Equipo", typeof(string));
                dt.Columns.Add("Actividad", typeof(string));
                grilla_limpia();
                dt.Clear();
                Session["dt"] = dt;

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

            if (Session["Resultado"] != null)
            {
                info.ShowMessage(Session["Resultado"].ToString(), controls.informacion.tipoMensaje.Mensaje);
                BorrarCajas();
                LlenarGrid();

                //bloque campos 
                TxtRutEmp.Enabled = true;
                TxtRutEmp.BackColor = System.Drawing.Color.White;

                TxtNombreEmp.Enabled = true;
                TxtNombreEmp.BackColor = System.Drawing.Color.White;

                TxtPeriodo.Enabled = true;
                TxtPeriodo.BackColor = System.Drawing.Color.White;

                TxtEquipo.Enabled = true;
                TxtEquipo.BackColor = System.Drawing.Color.White;

                TxtActividad.BackColor = System.Drawing.Color.White;

                Response.Redirect("WebFormOrdenTrabajoCreacionMan.aspx");
            }
        }
        #endregion

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

        private void LlenarGrid()
        {
            ds = _lgn_Tb_OT_Encabezado_Manual.Selecciona_DetalleOtMan();
            
            try
            {
                if (ds != null)
                {
                    //llenar gridview
                    this.GvDatos.DataSource = ds.Tables[0];
                    this.GvDatos.DataBind();
                    //ds.Dispose();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void GvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //_ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);
            GvDatos.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int operacion = 11;

            if (TxtRutEmp.Text == string.Empty)
            {
                info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            if (TxtNombreEmp.Text == string.Empty)
            {
                info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            if (TxtNombreEmp.Text == string.Empty)
            {
                info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            if (TxtPeriodo.Text == string.Empty)
            {
                info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
                return;
            }

            //if (TxtEquipo.Text == string.Empty)
            //{
            //    info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
            //    return;
            //}

            //if (TxtActividad.Text == string.Empty)
            //{
            //    info.ShowMessage("Ingrese un valor válido", controls.informacion.tipoMensaje.Mensaje);
            //    return;
            //}

            //**************encabezado
            _ent_Tb_OT_Encabezado_Manual.rut_empresa = Convert.ToDouble(TxtRutEmp.Text);
            _ent_Tb_OT_Encabezado_Manual.nom_empresa = TxtNombreEmp.Text.TrimEnd().ToUpper();
            _ent_Tb_OT_Encabezado_Manual.periodo = TxtPeriodo.Text.TrimEnd().ToUpper();

            //**************detalle
            //_ent_Tb_OT_Detalle_Manual.nom_equipos = TxtEquipo.Text.TrimEnd().ToUpper();
            //_ent_Tb_OT_Detalle_Manual.detalle_actividad = TxtActividad.Text.TrimEnd().ToUpper();

            //asigno variables
            confirmacion.CrearOrdenTrabajoManual("¿Desea crear ordenes de trabajo manual?", controls.confirmacion.tipoMensaje.advertencia, operacion, _ent_Tb_OT_Encabezado_Manual);
        }

        private void BorrarCajas()
        {
            TxtRutEmp.Text = string.Empty;
            TxtNombreEmp.Text = string.Empty;
            TxtPeriodo.Text = string.Empty;
            TxtEquipo.Text = string.Empty;
            TxtActividad.Text = string.Empty;
            //grilla_limpia();
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarCajas();
        }

        protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect");
                ImgSelect.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }

        protected void GvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int index = 0;
            //index = Convert.ToInt32(e.CommandSource);
            string nombre = e.CommandName;

            if ("Exportar" == nombre)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = GvDatos.Rows[index];

                GridViewRow row = GvDatos.Rows[index];
                _ent_Tb_OT_Encabezado_Manual.num_ot = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["num_ot"].ToString());

                if (e.CommandName == "Exportar")
                {
                    try
                    {
                        //FUNCION EXPORTAR PDF                  
                        GenPdfOT(_ent_Tb_OT_Encabezado_Manual.num_ot);
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message.ToString();
                    }
                }
            }
        }

        public bool GenPdfOT(double pNumOt)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            
            string fCrea = string.Empty;
            string fTerm = string.Empty;
            string path = Server.MapPath("Img/logo-cloud.png");

            //obtengo todos los datos de la OT
            ds = _lgn_Tb_OT_Encabezado_Manual.Selecciona_Encabezado_OtManual(pNumOt);

            if (ds != null)
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    _ent_Tb_OT_Encabezado_Manual.num_ot = Convert.ToDouble(drRow["Num_Ot"]);
                    _ent_Tb_OT_Encabezado_Manual.rut_empresa = Convert.ToDouble(drRow["RutEmp"]);
                    _ent_Tb_OT_Encabezado_Manual.nom_empresa = drRow["NomEmp"].ToString();
                    _ent_Tb_OT_Encabezado_Manual.periodo = drRow["Periodo"].ToString();
                    fCrea = drRow["FecCrea"].ToString();
                    _ent_Tb_OT_Detalle_Manual.nom_equipos = drRow["NomEquipo"].ToString();
                }
            }

            String destino = Server.MapPath($@"\Download\{_ent_Tb_OT_Encabezado_Manual.nom_empresa}_OrdenTrabajoManual_{pNumOt}.pdf");
            FileStream file = new FileStream(destino, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            try
            {
                //PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

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
                cadenaFinal = cadenaFinal + "<td style='text-align:center'width='33%'>" + _ent_Tb_OT_Encabezado_Manual.num_ot + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td>PLANTA</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_OT_Encabezado_Manual.nom_empresa + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + "IMPRESA" + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>PERIODO</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CREACIÓN</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center' BGCOLOR='#A4A4A4'>FECHA CIERRE</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + _ent_Tb_OT_Encabezado_Manual.periodo.ToUpper() + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fCrea + "</td>";
                cadenaFinal = cadenaFinal + "<td style='text-align:center'>" + fTerm + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>DETALLE EQUIPO</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center'>" + _ent_Tb_OT_Detalle_Manual.nom_equipos + "</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "<tr>";
                cadenaFinal = cadenaFinal + "<td colspan='3' style='text-align:center' BGCOLOR='#A4A4A4'>ACTIVIDADES REALIZADAS</td>";
                cadenaFinal = cadenaFinal + "</tr>";
                cadenaFinal = cadenaFinal + "</table>";

                //obtengo todos los datos de las actividades
                DataSet dsd = new DataSet();
                dsd = _lgn_Tb_OT_Detalle_Manual.Selecciona_DetalleOtPDFManual(pNumOt);
                int pos = 1;
                cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";

                if (dsd != null)
                {
                    foreach (DataRow drRow in dsd.Tables[0].Rows)
                    {
                        cadenaFinal = cadenaFinal + "<tr><td>" + pos + ".-" + drRow["DetalleAct"].ToString() + "</td></tr>";
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
                //    cadenaFinal = cadenaFinal + "<table style='width:100%; margin-left: 0px;' border='1'>";
                //    cadenaFinal = cadenaFinal + "<tr><td style='text-align:center' BGCOLOR='#A4A4A4'>TECNICO ACTIVIDAD</td></tr>";
                //    cadenaFinal = cadenaFinal + "</table>";
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

                Response.AddHeader("content-disposition", "attachment; filename=" + _ent_Tb_OT_Encabezado_Manual.nom_empresa + "_" + "OrdenTrabajoManual_" + pNumOt + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                //Response.AddHeader("content-disposition", "attachment; filename=" + LblNomEmp.Text + "_" + "_TareasOrdenTrabajo_" + pNumOt + ".pdf");
                //System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.Close();
                //Response.End();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            int pos = 0;
            //pos = GvDatos.Rows.Count - 1;           
            dt = (DataTable)Session["dt"];
            DataRow fila = dt.NewRow();
            pos = dt.Rows.Count + 1;

            //fila["Rut"] = TxtRutEmp.Text;
            //fila["Nombre"] = TxtNombreEmp.Text;
            fila["Pos"] = pos;
            fila["Equipo"] = TxtEquipo.Text;
            fila["Actividad"] = TxtActividad.Text;
            dt.Rows.Add(fila);
            //dspaso.Tables.Add(dt);

            //cargo gridview
            grdDatos.DataSource = dt;
            grdDatos.DataBind();
                      
            //COPIO DATATABLE
            Session["datos"] = dt;

            //limpio campo            
            TxtActividad.Text = string.Empty;

            //bloque campos 
            TxtRutEmp.Enabled = false;
            TxtRutEmp.BackColor = System.Drawing.Color.LightYellow;

            TxtNombreEmp.Enabled = false;
            TxtNombreEmp.BackColor = System.Drawing.Color.LightYellow;

            TxtPeriodo.Enabled = false;
            TxtPeriodo.BackColor = System.Drawing.Color.LightYellow;

            TxtEquipo.Enabled = false;
            TxtEquipo.BackColor = System.Drawing.Color.LightYellow;

            TxtActividad.Focus();
            TxtActividad.BackColor = System.Drawing.Color.LightGreen;
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

            this.grdDatos.DataSource = DetallePedido.Tables[0];
            this.grdDatos.DataBind();
        }

        protected void grdDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = (GridViewRow)e.Row;            
            //cambia el Color a la Fila
            //e.Row.Attributes.Add("style", "background-color: #39BB9C; color: #fff;");
            //Oculta el Boton 
            ImageButton btnEliminar = (ImageButton)row.FindControl("btnEliminar");
            //btnEliminar.Visible = false;
        }

        protected void grdDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //buscara el control del tipo definido
            Label Pos = new Label();

            //consulta si boton se llama
            if (e.CommandName == "Eliminar")
            {
                // obtiene el argumento de la fila CommandArgument 
                int index = Convert.ToInt32(e.CommandArgument);
                // asigna arow la fila indicada
                GridViewRow row = grdDatos.Rows[index];
                Pos = (Label)row.FindControl("lblPos");

                int indiceTable = Convert.ToInt32(Pos.Text)-1;
                //Boolean EliminaRegistro = false;

                if (string.IsNullOrEmpty(Pos.Text) == false)
                {
                    if (Pos.Text != "0")
                    {
                        //DataTable tableTemp = new DataTable();
                        dt = (DataTable)Session["dt"];


                        dt.Rows[indiceTable].Delete();

                        this.grdDatos.DataSource = dt;
                        this.grdDatos.DataBind();                         
                    }
                }
            }
        }

        protected void GvDatos_Sorting(object sender, GridViewSortEventArgs e)
        {
            string columna = e.SortExpression;
            SortDirection direccion;

            if (ViewState["DIRECCION"] == null)
            {
                direccion = SortDirection.Ascending;
                ViewState["DIRECCION"] = SortDirection.Descending;
            }
            else 
            {
                direccion = (SortDirection)ViewState["DIRECCION"];

                if (direccion == SortDirection.Ascending){
                    ViewState["DIRECCION"] = SortDirection.Descending;
                }
                else{
                    ViewState["DIRECCION"] = SortDirection.Ascending;                                               
                }
            }

            this.LlenarGridOrden(columna, direccion);
            
        }

        private void LlenarGridOrden(string columna, SortDirection direccion) 
        {
            string in_direccion = string.Empty;

            if (direccion == SortDirection.Ascending)
            {
                in_direccion = "ASC";
            }
            else
            {
                in_direccion = "DESC";
            }

            DataSet dsn = new DataSet();
            dsn = _lgn_Tb_OT_Encabezado_Manual.Selecciona_DetalleOtManOrdenColum(columna, in_direccion);

            try
            {
                if (dsn != null)
                {
                    //llenar gridview
                    this.GvDatos.DataSource = dsn.Tables[0];
                    this.GvDatos.DataBind();
                    //ds.Dispose();
                }

            }
            catch (Exception ex)
            {

            }
        
        
        }

}
         
}