using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//agregadas
using Dll_Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dll_Datos
{
    public class ACD_Tb_OT_Encabezado_Manual
    {
        public int Selecciona_CreaFolioOTManual()
        {
            int Resultado = 0;
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_crea_corr_ot_manual", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = vRutEmp;
            try
            {
                cnx.Open();
                SqlDataReader rs = cmd.ExecuteReader();
                rs.Read();
                Resultado = Convert.ToInt32(rs["folio"]);
                cnx.Close();
                cnx.Dispose();
                return Resultado;
            }
            catch (Exception ex)
            {                
                return Resultado;
            }
        }

        public string Inserta_NuevaOrdenTrabajoManual(ENT_Tb_OT_Encabezado_Manual _ent_Tb_OT_Encabezado_Manual, ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Inserta_NuevaOrdenTrabajo_Manual", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNum_Ot", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Encabezado_Manual.num_ot;
                cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Encabezado_Manual.rut_empresa;
                cmd.Parameters.Add("@pNomEmp", System.Data.SqlDbType.VarChar,255).Value = _ent_Tb_OT_Encabezado_Manual.nom_empresa;
                cmd.Parameters.Add("@pPeriodo", System.Data.SqlDbType.VarChar,255).Value = _ent_Tb_OT_Encabezado_Manual.periodo;
                //cmd.Parameters.Add("@pNomEquipo", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Detalle_Manual.nom_equipos;
                //cmd.Parameters.Add("@pDetalleAct", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Detalle_Manual.detalle_actividad;

                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMod_Err_Sp", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                mensaje1 = Convert.ToString(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                mensaje3 = Convert.ToString(cmd.Parameters["@pMod_Err_Sp"].Value);
                cnx.Close();
                cnx.Dispose();
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje2; }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public DataSet Selecciona_DetalleOtMan()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_Listado_OT_Manual", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = pRutEmp;
                        //cmd.Parameters.Add("@pNumOT", System.Data.SqlDbType.Float).Value = pNumOt;
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

        public DataSet Selecciona_DetalleOtManOrdenColum(string in_Columna, string in_Direccion)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_Listado_OT_ManualOrdenColum", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@in_Columna", System.Data.SqlDbType.VarChar, 30).Value = in_Columna;
                        cmd.Parameters.Add("@in_Direccion", System.Data.SqlDbType.VarChar, 30).Value = in_Direccion;
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

        public DataSet Selecciona_Encabezado_OtManual(double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_Selecciona_OT_Manual", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = pRutEmp;
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

        public string Inserta_DetalleNuevaOrdenTrabajoManual( ENT_Tb_OT_Detalle_Manual _ent_Tb_OT_Detalle_Manual)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Inserta_DetalleNuevaOrdenTrabajo_Manual", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNum_Ot", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Detalle_Manual.num_ot;
                cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Detalle_Manual.rut_empresa;
                //cmd.Parameters.Add("@pNomEmp", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Encabezado_Manual.nom_empresa;
                //cmd.Parameters.Add("@pPeriodo", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Encabezado_Manual.periodo;
                cmd.Parameters.Add("@pNomEquipo", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Detalle_Manual.nom_equipos;
                cmd.Parameters.Add("@pDetalleAct", System.Data.SqlDbType.VarChar, 255).Value = _ent_Tb_OT_Detalle_Manual.detalle_actividad;

                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMod_Err_Sp", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                mensaje1 = Convert.ToString(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                mensaje3 = Convert.ToString(cmd.Parameters["@pMod_Err_Sp"].Value);
                cnx.Close();
                cnx.Dispose();
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje2; }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}