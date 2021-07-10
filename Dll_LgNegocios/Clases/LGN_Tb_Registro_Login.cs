using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dll_Datos;
using Dll_Entidades;

namespace Dll_LgNegocios
{
    public class LGN_Tb_Registro_Login
    {
        ACD_Tb_Registro_Login _acd_Tb_Registro_Login = new ACD_Tb_Registro_Login();

        public bool Inserta_RegistroLoginUsuario(double pRut, DateTime pFechaReg)
        {
            bool res = false;
            try
            {
                res = _acd_Tb_Registro_Login.Inserta_RegistroLoginUsuario(pRut, pFechaReg);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }

        public bool Actualiza_FinRegistroLoginUsuario(double pRut, DateTime pFechaReg)
        {
            bool res = false;
            try
            {
                res = _acd_Tb_Registro_Login.Actualiza_FinRegistroLoginUsuario(pRut, pFechaReg);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
    }
}