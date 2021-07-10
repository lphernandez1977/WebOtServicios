using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebOtServicios.Funciones
{
    public class EnviarMail
    {
        public bool SendMail(string in_Adjunto,string in_NumOt,string in_Empresa)
        {
            try
            {
                string MailUser = "phernandez@e-mac.cl";
                string MailPass = "phernandez1";

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(MailUser, "Servidor Ordenes De Trabajo", System.Text.Encoding.UTF8);//Correo de salida
                correo.To.Add("marotino@gmail.com"); //Correo destino?
                correo.CC.Add("marotino@gmail.com");
                correo.Subject = $"El Servidor Ordenes De Trabajo esta enviando OT confeccionada: {in_NumOt},Empresa: {in_Empresa}"; //"Correo de prueba"; //Asunto
                correo.Body = $"Se adjunta la siguiente OT:{in_NumOt},Empresa: {in_Empresa} "; //Mensaje del correo       

                if (in_Adjunto != null)
                {
                    correo.Attachments.Add(new Attachment(in_Adjunto));
                }

                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida                
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(MailUser, MailPass);//Cuenta de correo

                //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };                
                //smtp.Send(correo);

                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
                return false;                
            }
        }
    }
}