
using NegocioEMC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Application
{
    public class NotificacionMail : INotificacionMail
    {
     
        public bool EnviarMailNotificacion(string asunto, List<string> emailsDestino, string cuerpo = "", string pathTemplate = "")
        {
            bool result = false;
            var cuerpoHTML = string.IsNullOrEmpty(pathTemplate)? ConstruccionNotificacion(pathTemplate) : string.Empty;

            try
            {
                MailMessage mensaje = new MailMessage();
                SmtpClient servidor = new SmtpClient();
                mensaje.From = new MailAddress("www.tuidentidad.com <tuidentidad@gmail.com>");
                mensaje.Subject = asunto;
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                mensaje.Body = string.IsNullOrEmpty(cuerpoHTML)?cuerpo:cuerpoHTML;
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                foreach ( var email in emailsDestino)
                    mensaje.To.Add(new MailAddress(email));
                //if (pathAdjunto != string.Empty) { mensaje.Attachments.Add(new Attachment(pathAdjunto)); }
                servidor.Credentials = new System.Net.NetworkCredential("tuidentidad@gmail.com", "12345678");
                servidor.Port = 587;
                servidor.Host = "smtp.gmail.com";
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                mensaje.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }

            return result;
        }


        private string ConstruccionNotificacion(string pathTemplate)
        {
            var body = string.Empty;
            body = File.ReadAllText(pathTemplate);
            body = body.Replace("@Model.Saludo", "Hola Congratulaciones.");
            body = body.Replace("@Model.Fecha", DateTime.Now.Date.ToString());
            body = body.Replace("@Model.EmailDestinatario", "Usuario de www.tuidentidad.com");
            body = body.Replace("@Model.Observacion", "Registro exitoso de su empresa");
            body = body.Replace("@Model.Descripcion", "");
            body = body.Replace("@Model.ClickAqui", "");
            body = body.Replace("@Model.Link", "");
            body = body.Replace("@Model.CodigoResetPassword","");
            return body;
        }

    }
}
