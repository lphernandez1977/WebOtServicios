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

namespace WebOtServicios
{
    public partial class WebFormOrdenTrabajoSeleccion : System.Web.UI.Page
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

        private LGN_Tb_Empresas _lgn_tb_empresas = new LGN_Tb_Empresas();
        private LGN_Tb_Equipos _lgn_Tb_Equipos = new LGN_Tb_Equipos();
        private LGN_Tb_OT_Encabezado _lgn_Tb_OT_Encabezado = new LGN_Tb_OT_Encabezado();
        private LGN_Tb_OT_Detalle _lgn_Tb_OT_Detalle = new LGN_Tb_OT_Detalle();
        private LGN_FechaHoraServer _lgn_FechaHoraServer = new LGN_FechaHoraServer();        
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string UsuarioId = (string)Session["RutUsuario"];
            string NombreUsuario = (string)Session["NombreUsuario"];
            string ApellidoUsuario = (string)Session["ApellidoUsuario"];
            string PerfilUsuario = (string)Session["PerfilUsuario"];

            //USUARIO LOGUEADO
            _ent_Tb_Personal.rut_personal = Convert.ToDouble(UsuarioId);
           
            if (!IsPostBack)
            {
                if (UsuarioId == "" || UsuarioId == null)
                    Response.Redirect("WebFormLogin.aspx");
                //lleno grilla
                LlenarGrid(Convert.ToDouble(Request.QueryString["pRutEmp"]));
            }

            _ent_Tb_Empresas = _lgn_tb_empresas.Selecciona_Empresas(Convert.ToDouble(Request.QueryString["pRutEmp"]));

            LblNomEmp.Text = _ent_Tb_Empresas.nom_empresa;

            //LblUsuario.Text = NombreUsuario + " " + ApellidoUsuario;
        }

        private void LlenarGrid(double pRutEmp)
        {
            ds = _lgn_Tb_Equipos.Selecciona_OrdenesxEquiposP(pRutEmp);
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

        protected void GvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDatos.PageIndex = e.NewPageIndex;
            LlenarGrid(Convert.ToDouble(Request.QueryString["pRutEmp"]));
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

        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            double TecReserOT = 0;

            //seleccion fila de grilla
            GridViewRow row = GvDatos.SelectedRow;
            
            _ent_Tb_Empresas.rut_empresa = Convert.ToDouble(Request.QueryString["pRutEmp"]);
            _ent_Tb_OT_Encabezado.num_ot = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["num_ot"]);
            TecReserOT = Convert.ToDouble(GvDatos.DataKeys[row.RowIndex].Values["rut_personal"]);

            //asigno variables para enviar al otro webform
            double pRutEmp = _ent_Tb_Empresas.rut_empresa;
            double pNumOt = _ent_Tb_OT_Encabezado.num_ot;

            Response.Write("<script language=javascript>confirm('Desea seleccionar OT y realizar sus actividades');</script>");

            //Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + pRutEmp + pNumOt);
            Response.Redirect("WebFormActividadesOT.aspx?pRutEmp=" + pRutEmp + "&pNumOt=" + pNumOt);
        }

        protected void GvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public void RecorreGid() 
        {
            string TecAsig = string.Empty;
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TecAsig = dr[4].ToString();

                if (Convert.ToDouble(TecAsig) == _ent_Tb_Personal.rut_personal)
                {

                }
                else 
                { 
                
                }
            }        
        }

        protected void GvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            ImageButton ImgSelect = (ImageButton)e.Row.FindControl("ImgSelect");
            if (ImgSelect != null)
            {
                // Imagina que es un valor entero. y verificamos que sea 1 para mostrar la imagen
                if (//(Convert.ToDouble(dr["rut_personal"].ToString()) == _ent_Tb_Personal.rut_personal) ||
                    (dr["Nom_Estado"].ToString() == "Cerrada")
                    )
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

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormOrdenTrabajoDetalle.aspx");
        }
    }
}