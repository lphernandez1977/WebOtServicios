using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Personal
    {
        private ACD_Tb_Personal _acd_Tb_Personal = new ACD_Tb_Personal();

        public string Selecciona_Usuario(ENT_Tb_Personal _ent_tb_personal)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Personal.Selecciona_Usuario(_ent_tb_personal);
                return res;
            }
            catch(Exception ex)
            {
                return res;
            }              
        }

        public ENT_Tb_Personal Selecciona_PerfilUsuario(ENT_Tb_Personal _ent_tb_personal)
        {
            ENT_Tb_Personal _Perfil_User = new ENT_Tb_Personal();
            try
            {
                _Perfil_User = _acd_Tb_Personal.Selecciona_PerfilUsuario(_ent_tb_personal);
                return _Perfil_User;
            }
            catch (Exception ex)
            {
                return _Perfil_User;
            }
        }

        public string Actualiza_EstadoPersonal(ENT_Tb_Personal _ent_tb_personal)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Personal.Actualiza_EstadoPersonal(_ent_tb_personal);
                return res;
            }
            catch (Exception ex)
            {
                return  null;
            }
        }

        public string Inserta_NuevoPersonal(ENT_Tb_Personal _ent_tb_personal)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Personal.Inserta_NuevoPersonal(_ent_tb_personal);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet Selecciona_ListaFuncionarios()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Personal.Selecciona_ListaFuncionarios();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string Modifica_Personal(ENT_Tb_Personal _ent_tb_personal)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Personal.Modifica_Personal(_ent_tb_personal);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}


