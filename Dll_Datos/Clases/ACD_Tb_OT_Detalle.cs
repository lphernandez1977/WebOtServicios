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
    public class ACD_Tb_OT_Detalle
    {
        ENT_Lista_Mensajes _ent_lista_mensajes = new ENT_Lista_Mensajes();

        public bool Inserta_DetalleOrdenTrabajoxEquipos(ENT_Tb_OT_Detalle _ent_Tb_OT_Detalle)
        {
            int exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Inserta_NuevoDetalleOrdenTrabajoxEquipos", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pnum_ot", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Detalle.num_ot;
                cmd.Parameters.Add("@pcod_equipos", SqlDbType.Float).Value = _ent_Tb_OT_Detalle.cod_equipos;
                cmd.Parameters.Add("@pestado_mantencion", SqlDbType.Char,1).Value = _ent_Tb_OT_Detalle.estado_mantencion;
                cmd.Parameters.Add("@prut_empresa", SqlDbType.Float).Value = _ent_Tb_OT_Detalle.rut_empresa;
                cmd.Parameters.Add("@pPeriodo", SqlDbType.Int).Value = _ent_Tb_OT_Detalle.variableNum;
                

                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                cnx.Close();
                //if (mensaje1 == 1) { return true; } else { return false; }
                return true;
            }
            catch (Exception ex)
            {
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return false;
            }
        }

        public DataSet Selecciona_DetalleOtPDF(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_DetalleOtPDF", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = pRutEmp;
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

        public DataSet Selecciona_DetalleObservacionPDF(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_ObservacionesOtPDF", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = pRutEmp;
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

        public DataSet Selecciona_DetalleOtPDFPendiente(double pRutEmp, double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_DetalleOtPDFTareasPendientes", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = pRutEmp;
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