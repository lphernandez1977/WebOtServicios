using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;
using System.Data;

namespace Dll_LgNegocios
{
    public class LGN_Tb_DesActxTecnicos
    {
        ACD_Tb_DesActxTecnicos _acd_Tb_DesActxTecnicos = new ACD_Tb_DesActxTecnicos();

        public Int32 Inserta_RegistroActividadesxTecnico(ENT_Tb_DesActxTecnicos _Tb_DesActxTecnicos)
        {
            int res = 0;
            try
            {
                res = _acd_Tb_DesActxTecnicos.Inserta_RegistroActividadesxTecnico(_Tb_DesActxTecnicos);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public DataSet Selecciona_ActividadesxTecnico(double pRutEmpresa, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _acd_Tb_DesActxTecnicos.Selecciona_ActividadesxTecnico(pRutEmpresa, pNumOt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}