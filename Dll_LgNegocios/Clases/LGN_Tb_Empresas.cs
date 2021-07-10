using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Empresas
    {
        ACD_Tb_Empresas _acd_Tb_Empresas = new ACD_Tb_Empresas();

        public DataSet Selecciona_ListaEmpresas()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Empresas.Selecciona_ListaEmpresas();
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_Lista_OT_Empresas()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Empresas.Selecciona_Lista_OT_Empresas();
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public DataSet Selecciona_Lista_OT_EmpresasMant()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Empresas.Selecciona_Lista_OT_EmpresasMant();
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }

        public ENT_Tb_Empresas Selecciona_Empresas(double pRut)
        {
            ENT_Tb_Empresas _listaEmp = new ENT_Tb_Empresas();
            try
            {
                _listaEmp = _acd_Tb_Empresas.Selecciona_Empresas(pRut);
                return _listaEmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Inserta_NuevaEmpresa(ENT_Tb_Empresas _oEmpresa)
        {
            string exe = string.Empty;
            try
            {
                exe = _acd_Tb_Empresas.Inserta_NuevaEmpresa(_oEmpresa);
                return exe;
            }
            catch (Exception ex)
            {
                return exe;
            }
        }

        public string Actualiza_Empresas(ENT_Tb_Empresas _oEmpresa)
        {
            string exe = string.Empty;
            try
            {
                exe = _acd_Tb_Empresas.Actualiza_Empresas(_oEmpresa);
                return exe;
            }
            catch (Exception ex)
            {
                return exe;
            }
        }

        public string Actualiza_EstadoEmpresas(ENT_Tb_Empresas _oEmpresa)
        {
            string exe = string.Empty;
            try
            {
                exe = _acd_Tb_Empresas.Actualiza_EstadoEmpresas(_oEmpresa);
                return exe;
            }
            catch (Exception ex)
            {
                return exe;
            }
        }
    }
}