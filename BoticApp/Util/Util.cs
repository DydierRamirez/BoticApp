using BoticApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BoticApp.Util
{
    public static class Util
    {
        public static System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        //public static SmtpClient servidor = new SmtpClient(configurationAppSettings.GetValue("SMTP", typeof(string)).ToString(), Convert.ToInt32(configurationAppSettings.GetValue("Puerto", typeof(string)).ToString()));
        //public static NetworkCredential credenciales = new NetworkCredential(configurationAppSettings.GetValue("Correo", typeof(string)).ToString(), configurationAppSettings.GetValue("Clave", typeof(string)).ToString());
        //public static boticaapEntities db = new boticaapEntities();
        public static void EnviarCorreo(string Correo)
        {
            boticaapEntities1 db = new boticaapEntities1();
            //Enviar correo
            
            try
            {
                string link = string.Empty;
                string urlbase = configurationAppSettings.GetValue("UrlBaseBoticApp", typeof(string)).ToString();

                var user = (from u in db.USUARIO
                            where u.EMAIL == Correo
                            select u).FirstOrDefault();
                if (user != null)
                {
                    link = urlbase + "/Restaurar.aspx?ID_USUARIO=" + user.ID_USUARIO;
                    string body = "Se ha solicitado Restaurar la contraseña de acceso.<br/> Ingrese al siguiente enlace para cambiarla:   " + link+"<br/> BoticApp.";
                    using (System.Net.Mail.MailMessage oMensaje = new System.Net.Mail.MailMessage())
                    {
                        oMensaje.To.Add(new System.Net.Mail.MailAddress(Correo));
                        oMensaje.From = new System.Net.Mail.MailAddress(configurationAppSettings.GetValue("Correo", typeof(string)).ToString(), "BoticApp");
                        oMensaje.Subject = "Restaurar clave";
                        oMensaje.IsBodyHtml = true;
                        oMensaje.Body = body;

                        if (configurationAppSettings.GetValue("TipoEnvio", typeof(string)).ToString() == "1")
                        {
                            using (System.Net.Mail.MailMessage MailSetup = new System.Net.Mail.MailMessage())
                            {

                                MailSetup.Subject = "Restaurar";
                                MailSetup.To.Add(Correo);
                                MailSetup.From = new System.Net.Mail.MailAddress(configurationAppSettings.GetValue("Correo", typeof(string)).ToString());
                                MailSetup.Body = "hola mundo";

                                using (System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                                {
                                    SMTP.Port = 587;
                                    SMTP.EnableSsl = true;
                                    SMTP.Credentials = new System.Net.NetworkCredential(configurationAppSettings.GetValue("Correo", typeof(string)).ToString(), configurationAppSettings.GetValue("Clave", typeof(string)).ToString());
                                    SMTP.Send(MailSetup);
                                }
                                // SMTP

                            }
                        }
                        else
                        {
                            using (System.Net.Mail.SmtpClient oClienteSmtp = new System.Net.Mail.SmtpClient(configurationAppSettings.GetValue("SMTP", typeof(string)).ToString(), Convert.ToInt32(configurationAppSettings.GetValue("Puerto", typeof(string)).ToString())))
                            {
                                oClienteSmtp.EnableSsl = true;
                                oClienteSmtp.Timeout = 60000;
                                oClienteSmtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                                oClienteSmtp.UseDefaultCredentials = false;
                                oClienteSmtp.Credentials = new System.Net.NetworkCredential(configurationAppSettings.GetValue("Correo", typeof(string)).ToString(), configurationAppSettings.GetValue("Clave", typeof(string)).ToString());

                                try
                                {
                                    oClienteSmtp.Send(oMensaje);
                                }
                                catch (Exception Ex)
                                {

                                }
                            }
                        }
                    }
                }
                else
                    throw new ApplicationException("usuario no existe");
            }
            catch(Exception e)
            {
                db.Dispose();
            }
        }

        public static string Encriptar(string Clave)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(Clave);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}