using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//agregadas
using Dll_Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dll_Datos
{
    public class ACD_Tb_DesActxTecnicos
    {
        public Int32 Inserta_RegistroActividadesxTecnico(ENT_Tb_DesActxTecnicos oTb_DesActxTecnicos)
        {
            Int32 exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ins_DesarrolloActxTecnico", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRut_empresa", System.Data.SqlDbType.Float).Value = oTb_DesActxTecnicos.Rut_empresa ;
                cmd.Parameters.Add("@pNum_ot", System.Data.SqlDbType.Int).Value = oTb_DesActxTecnicos.Num_ot;
                cmd.Parameters.Add("@pRut_Tecnico", SqlDbType.Int).Value = oTb_DesActxTecnicos.Rut_Tecnico;
                cmd.Parameters.Add("@pCod_Act", SqlDbType.Int).Value = oTb_DesActxTecnicos.Cod_Act;
                cmd.Parameters.Add("@pFecha_Asignacion", SqlDbType.DateTime).Value = oTb_DesActxTecnicos.Fecha_Asignacion;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();              
                cnx.Close();
                cnx.Dispose();
                return exe;
            }
            catch (Exception ex)
            {
                return exe;
            }
        }

        public DataSet Selecciona_ActividadesxTecnico(double pRutEmpresa, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_TecnicosOT", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRutEm", System.Data.SqlDbType.Float).Value = pRutEmpresa;
                        cmd.Parameters.Add("@pNumOT", System.Data.SqlDbType.Float).Value = pNumOt;
                        //abrimos conexion
                        con.Open();
                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);
                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {                
                return null;
            }

        }

    }
}