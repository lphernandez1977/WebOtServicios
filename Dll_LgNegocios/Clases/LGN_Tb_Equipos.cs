using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Equipos
    {
        ACD_Tb_Equipos _acd_Tb_Equipos = new ACD_Tb_Equipos();

        public DataSet Selecciona_ListaEquipos(double pRutEmpresa,int pCodEqui)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Equipos.Selecciona_ListaEquipos(pRutEmpresa, pCodEqui);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_OrdenesxEquipos(double pRutEmpresa, float pNumOt, int pEstado, string pFecIni, string pFecTer)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Equipos.Selecciona_OrdenesxEquipos(pRutEmpresa, pNumOt, pEstado, pFecIni, pFecTer);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_OrdenesxEquiposP(double pRutEmpresa)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Equipos.Selecciona_OrdenesxEquiposP(pRutEmpresa);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_ListaDeActividades(double pRutEmpresa, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Equipos.Selecciona_ListaDeActividades(pRutEmpresa, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public ENT_Tb_Equipos Selecciona_EquiposOT(double pRutEmpresa, double pNumOt) 
        {
            ENT_Tb_Equipos oEntidad = new ENT_Tb_Equipos();
            try
            {
                oEntidad = _acd_Tb_Equipos.Selecciona_EquiposOT(pRutEmpresa, pNumOt);
                return oEntidad;
            }
            catch (Exception ex)
            {
                return null;
            }        
        }

        public string Inserta_NuevaEquipo(ENT_Tb_Equipos _ent_equipos, int dispo)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Equipos.Inserta_NuevaEquipo(_ent_equipos, dispo);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public string Editar_Equipo(ENT_Tb_Equipos _ent_equipos, int dispo)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Equipos.Editar_Equipo(_ent_equipos, dispo);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public DataSet Selecciona_ListaEquiposEmpresa(double pRutEmpresa)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Equipos.Selecciona_ListaEquiposEmpresa(pRutEmpresa);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public string Elimina_Equipo(ENT_Tb_Equipos _ent_equipos)
        {
            string res = string.Empty;
            try
            {
                res = _acd_Tb_Equipos.Elimina_Equipo(_ent_equipos);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
    }
}