using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dll_Entidades;
using Dll_LgNegocios;

namespace WebOtServicios
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        private ENT_Tb_Personal _ent_Tb_Personal = new ENT_Tb_Personal();
        private ENT_Tb_Registro_Login _ent_Tb_Registro_Login = new ENT_Tb_Registro_Login();
        private ENT_Lista_Mensajes _ent_lista_mensajes = new ENT_Lista_Mensajes();

        private LGN_Tb_Personal _lgn_Tb_Personal = new LGN_Tb_Personal();
        private LGN_FechaHoraServer _FechaHoraServidor = new LGN_FechaHoraServer();
        private LGN_Tb_Registro_Login _lgn_Tb_Registro_Login = new LGN_Tb_Registro_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuser.Text)) 
            {            
                return;
            }

             if (string.IsNullOrEmpty(txtpass.Text)) 
            {        
                return;
            }


             string res = string.Empty;
            bool login = false;
            ENT_Tb_Personal _perfilUser = new ENT_Tb_Personal();

            _ent_Tb_Personal.rut_personal = Convert.ToDouble(this.txtuser.Text);
            _ent_Tb_Personal.contrasenia = this. txtpass.Text.TrimEnd();
            _ent_Tb_Registro_Login.fecha_login = Convert.ToDateTime(_FechaHoraServidor.Selecciona_FechaHoraServer());


            try
            {
                res = _lgn_Tb_Personal.Selecciona_Usuario(_ent_Tb_Personal);
                _perfilUser = _lgn_Tb_Personal.Selecciona_PerfilUsuario(_ent_Tb_Personal);

                if (res == "1")
                {
                    //asigno valores a entidades
                    Session["RutUsuario"] = Convert.ToString(_ent_Tb_Personal.rut_personal);
                    Session["NombreUsuario"] = Convert.ToString(_perfilUser.nom_empleado);
                    Session["ApellidoUsuario"] = Convert.ToString(_perfilUser.ape_empleado);
                    Session["PerfilUsuario"] = Convert.ToString(_perfilUser.cargo);
                    
                    //inserto hora y fecha de registro usuario
                    login = _lgn_Tb_Registro_Login.Inserta_RegistroLoginUsuario(_ent_Tb_Personal.rut_personal, _ent_Tb_Registro_Login.fecha_login);

                    if (login) 
                    {
                        Response.Redirect("WebFormMenu.aspx", false);
                    }                    
                    
                }
                else
                {                 
                    Response.Write("<script language=javascript>alert('Ingrese una contraseña valida');</script>");          
                }
            }
            catch (Exception ex) 
            {
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                Response.Write("<script language=javascript>alert('" + _ent_lista_mensajes.MsjExepcion + "');</script>");
            }

        }
    }
}