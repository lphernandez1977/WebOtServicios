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
    public class ACD_Tb_OT_Encabezado
    {
        public ENT_Lista_Mensajes _ent_lista_mensajes = new ENT_Lista_Mensajes();

        public int Selecciona_CreaFolioOT(double vRutEmp)
        {
            int Resultado = 0;
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            SqlCommand cmd = new SqlCommand("sp_crea_corr_ot", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = vRutEmp;
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
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return Resultado;
            }
        }

        
        //public string Inserta_NuevaOrdenTrabajo(ENT_Tb_OT_Encabezado Cabecera, List<ENT_Tb_OT_Detalle> in_lista)
        public string Inserta_NuevaOrdenTrabajo(string xml)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Inserta_NuevaOrdenTrabajo", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@PgDocXml", System.Data.SqlDbType.Xml).Value = xml;
                
                //cmd.Parameters.Add("@pfecha_creacion_ot", SqlDbType.DateTime).Value = Cabecera.fecha_creacion_ot;
                //cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = Cabecera.estado;
                //cmd.Parameters.Add("@prut_crea_ot", SqlDbType.Float).Value = Cabecera.rut_crea_ot;
                //cmd.Parameters.Add("@pperiodo", SqlDbType.Int).Value = Cabecera.periodo;
                //cmd.Parameters.Add("@ptipo_ot", SqlDbType.Int).Value = Cabecera.tipo_ot;
                //cmd.Parameters.Add("@pcod_equipos", SqlDbType.Int).Value = in_lista[0].cod_equipos;
                //cmd.Parameters.Add("@pnum_ot", SqlDbType.Float).Value = in_lista[0].num_ot;
                //cmd.Parameters.Add("@pestado_mantencion", SqlDbType.VarChar, 255).Value = in_lista[0].estado_mantencion;
                //cmd.Parameters.Add("@prut_empresa", SqlDbType.Float).Value = in_lista[0].rut_empresa;
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
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return _ent_lista_mensajes.MsjExepcion;
            }
 
        }

        public bool Inserta_EncabezadoOrdenTrabajoxEquipos(ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado)
        {
            int exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Inserta_NuevaOrdenTrabajoxEquipos", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Encabezado.rut_empresa;
                cmd.Parameters.Add("@pnum_ot", SqlDbType.Float).Value = _ent_Tb_OT_Encabezado.num_ot;
                cmd.Parameters.Add("@pfecha_creacion_ot", SqlDbType.DateTime).Value = _ent_Tb_OT_Encabezado.fecha_creacion_ot;
                cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = _ent_Tb_OT_Encabezado.estado;
                cmd.Parameters.Add("@prut_crea_ot", SqlDbType.Float).Value = _ent_Tb_OT_Encabezado.rut_crea_ot;
                cmd.Parameters.Add("@pperiodo", SqlDbType.Int).Value = _ent_Tb_OT_Encabezado.periodo;
                cmd.Parameters.Add("@ptipo", SqlDbType.Int).Value = _ent_Tb_OT_Encabezado.tipo_ot;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                cnx.Close();
                cnx.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return false;
            }
        }

        public bool Actualiza_AsignacionOT_Tecnico(ENT_Tb_OT_Encabezado _ent_Tb_OT_Encabezado)
        {
            int exe = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_actualiza_TecnicoOT", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = _ent_Tb_OT_Encabezado.rut_empresa;
                cmd.Parameters.Add("@pnum_ot", SqlDbType.Float).Value = _ent_Tb_OT_Encabezado.num_ot;
                cmd.Parameters.Add("@pfecha_reserva_captura", SqlDbType.DateTime).Value = _ent_Tb_OT_Encabezado.fecha_reserva_captura;
                cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = _ent_Tb_OT_Encabezado.estado;
                cmd.Parameters.Add("@pRutTec", SqlDbType.Int).Value = _ent_Tb_OT_Encabezado.rut_personal;
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                cnx.Close();
                cnx.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return false;
            }
        }

        public string Selecciona_OtAsignada(double pRutEmp,double pNumOt,double pRutTec)
        {
            string valor = string.Empty;
            try
            {

                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_validaOTAsignada", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                        //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                        //de entidades...
                        cmd.Parameters.Add("@pRutEmp", SqlDbType.Float).Value = pRutEmp;
                        cmd.Parameters.Add("@pNumOt", SqlDbType.Float).Value = pNumOt;
                        cmd.Parameters.Add("@pRutTec", SqlDbType.Float).Value = pRutTec;
                        //abrimos conexion
                        con.Open();

                        SqlDataReader dataReader = cmd.ExecuteReader();

                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        //ENT_Tb_OT_Encabezado oEncabezado = new ENT_Tb_OT_Encabezado();

                        ////Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            valor = Convert.ToString(dataReader["Lineas"]);
                        }
                        return valor;
                    }
                }
                //se define que si no hay datos envia null
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Actualiza_CerrarOTenTrabajo(double pRutEmp, double pNumOt)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_actualiza_CerrarOrdendeTrabajo", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@prut_empresa", System.Data.SqlDbType.Float).Value = pRutEmp;
                cmd.Parameters.Add("@pnum_ot", System.Data.SqlDbType.Float).Value = pNumOt;                
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
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return _ent_lista_mensajes.MsjExepcion;
            }

        }
    
        public DataSet Selecciona_EncabezadoOtPDF(double pRutEmp,double pNumOt)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_sel_EncabezadoOtPDF", con))
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

        public string Modifica_OrdenTrabajo(ENT_Tb_OT_Encabezado oEncabezado)
        {
            int exe = 0;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;
            string mensaje3 = string.Empty;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Mod_EstadoOT", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pRutEmp", System.Data.SqlDbType.Float).Value = oEncabezado.rut_empresa;
                cmd.Parameters.Add("@pNumOt", System.Data.SqlDbType.Float).Value = oEncabezado.num_ot;
                cmd.Parameters.Add("@pEstado", System.Data.SqlDbType.Int).Value = oEncabezado.estado;

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
                if (mensaje1 == "1") { return mensaje1; } else { return mensaje3; }
            }
            catch (Exception ex)
            {
                _ent_lista_mensajes.MsjExepcion = ex.Message.ToString();
                return _ent_lista_mensajes.MsjExepcion;
            }

        }
    }
}