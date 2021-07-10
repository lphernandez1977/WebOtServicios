using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Cargos
    {

        ACD_Tb_Cargos _acd_Tb_Cargos = new ACD_Tb_Cargos();

        public DataSet Selecciona_ListaCargosFuncionario()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_Cargos.Selecciona_ListaCargoFuncionarios();
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return ds;
            }
        }
    }
}