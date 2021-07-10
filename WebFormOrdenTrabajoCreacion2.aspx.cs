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
    public partial class WebFormOrdenTrabajoCreacion2 : System.Web.UI.Page
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
                    Response.Redirect("~/WebFormLogin.aspx");

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
                    Response.Redirect("~/WebFormMenu.aspx");
                }
            }
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
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebFormOrdenTrabajo.aspx");
        }
        protected void BtnEquipos_Click(object sender, EventArgs e)
        {
            ////lleno grilla
            _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRut"]), _ent_Tb_OT_Encabezado.tipo_ot);
        }
        private void LlenarGrid(double pRutEmpresa, int pCodEqui)
        {
            if (this.CboTipoOT.SelectedValue == Convert.ToString("0"))
            {                
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
                return;
            }
        }
        protected void BtAdminLogout_Click(object sender, EventArgs e)
        {
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

        protected void BtnOt_Click(object sender, EventArgs e)
        {
            List<ENT_Tb_OT_Detalle> ListaDetalleOT = new List<ENT_Tb_OT_Detalle>();

            int cont = 0;

            if ((this.CboPeriodos.SelectedValue == Convert.ToString("0")) || (this.CboTipoOT.SelectedValue == Convert.ToString("0")))
            {
                return;
            }
           
            int operacion = 3;

            //*******************funcion crear ot*******************
            //XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
            ////nodo raiz
            //XElement nodoraiz = new XElement("OrdenTrabajo");
            //documento.Add(nodoraiz);

            //creo folio
            _ent_Tb_OT_Encabezado.num_ot = _lgn_Tb_OT_Encabezado.Selecciona_CreaFolioOT(_ent_Tb_OT_Encabezado.rut_empresa);

            //creacion de ot individuales
            foreach (GridViewRow row in GvDatos.Rows)
            {
                CheckBox check = ((CheckBox)row.FindControl("CheckBox1"));

                if (check.Checked == true)
                {
                    ENT_Tb_OT_Detalle _Detalle = new ENT_Tb_OT_Detalle();

                    //cabecera ot
                    _ent_Tb_OT_Encabezado.fecha_creacion_ot = DateTime.ParseExact(_lgn_FechaHoraServer.Selecciona_FechaHoraServer(), "dd/MM/yyyy H:mm:ss", null);
                    _ent_Tb_OT_Encabezado.estado = 1;
                    _ent_Tb_OT_Encabezado.rut_crea_ot = Convert.ToDouble((string)Session["RutUsuario"]);
                    _ent_Tb_OT_Encabezado.periodo = Convert.ToInt32(this.CboPeriodos.SelectedValue);//perido sem-men-tri
                    _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);//transportado-cctv-incendio

                    //detalle ot                   
                    _Detalle.num_ot = _ent_Tb_OT_Encabezado.num_ot;
                    _Detalle.cod_equipos = Convert.ToInt32(row.Cells[1].Text);
                    _Detalle.estado_mantencion = "P";
                    _Detalle.rut_empresa = _ent_Tb_OT_Encabezado.rut_empresa;
                    _Detalle.variableNum = _ent_Tb_OT_Encabezado.periodo;
                    
                    //lleno lista
                    ListaDetalleOT.Add(_Detalle);                    
                    //Creamos el nodo cabecera
                    //XElement CabCombo = new XElement("CabeceraOrdenTrabajo");
                    //CabCombo.Add(new XElement("num_ot", _ent_Tb_OT_Encabezado.num_ot));
                    //CabCombo.Add(new XElement("rut_empresa", _ent_Tb_OT_Encabezado.rut_empresa));
                    //CabCombo.Add(new XElement("fecha_creacion_ot", _ent_Tb_OT_Encabezado.fecha_creacion_ot));
                    //CabCombo.Add(new XElement("estado", _ent_Tb_OT_Encabezado.estado));
                    //CabCombo.Add(new XElement("rut_crea_ot", _ent_Tb_OT_Encabezado.rut_crea_ot));
                    //CabCombo.Add(new XElement("periodo", _ent_Tb_OT_Encabezado.periodo));
                    //CabCombo.Add(new XElement("tipo", _ent_Tb_OT_Encabezado.tipo_ot));
                    //nodoraiz.Add(CabCombo);

                    //Creamos el nodo Detalle
                    //XElement nododetalle = new XElement("DetalleOT");
                    //CabCombo.Add(nododetalle);

                    //XElement DetCombo = new XElement("DetalleOrdenTrabajo");
                    //DetCombo.Add(new XElement("num_ot", _ent_Tb_OT_Detalle.num_ot));
                    //DetCombo.Add(new XElement("cod_equipos", _ent_Tb_OT_Detalle.cod_equipos));
                    //DetCombo.Add(new XElement("estado_mantencion", _ent_Tb_OT_Detalle.estado_mantencion));
                    //DetCombo.Add(new XElement("rut_empresa", _ent_Tb_OT_Detalle.rut_empresa));
                    //nododetalle.Add(DetCombo);

                    //aumento CORRELATIVO
                    _ent_Tb_OT_Encabezado.num_ot = ++_ent_Tb_OT_Encabezado.num_ot;

                    cont = ++cont;

                    string res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(_ent_Tb_OT_Encabezado,ListaDetalleOT);
                }

                ListaDetalleOT.Clear();
            }
            //string xml = nodoraiz.ToString();
            //if (cont >= 1)
            //{
            //    string res = _lgn_Tb_OT_Encabezado.Inserta_NuevaOrdenTrabajo(ListaDetalleOT);
            //    Response.Redirect("~/WebFormOrdenTrabajoCreacion.aspx");
            //}
            //else
            //{
            //    this.CargaCombo(_ent_Tb_OT_Encabezado.rut_empresa);
            //    this.CargaComboTipo(_ent_Tb_OT_Encabezado.rut_empresa);
            //    return;
            //}
        }

        protected void GvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _ent_Tb_OT_Encabezado.tipo_ot = Convert.ToInt32(this.CboTipoOT.SelectedValue);
            GvDatos.PageIndex = e.NewPageIndex;
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRut"]), _ent_Tb_OT_Encabezado.tipo_ot);
        }
    }
}