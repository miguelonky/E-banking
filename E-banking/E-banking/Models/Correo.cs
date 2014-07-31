using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
namespace E_banking.Models
{
    public class Correo
    {

        string destinatario { set; get; }
        string mensaje { set; get; }
        string subject { set; get; }
        string remitente { set; get; }
        string pass { set; get; }

        public void EnviarCorreo()
        {

            MailMessage msj = new MailMessage();


            msj.To.Add(destinatario);




            msj.Subject = subject;
            msj.SubjectEncoding = System.Text.Encoding.UTF8;

            //para recibir una copia del mensaje
            msj.Bcc.Add(remitente);


            msj.Body = mensaje;

            msj.BodyEncoding = System.Text.Encoding.UTF8;

            msj.IsBodyHtml = false; //para que no se envíe como HTML


            msj.From = new MailAddress(remitente);



            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(remitente, pass);

            // para enviar  el mensaje desde Gmail

            cliente.Port = 587;
            cliente.EnableSsl = true;
            /*-----------------------------*/

            cliente.Host = "smtp.gmail.com"; //Para Gmail 


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Envio del mensaje      
                cliente.Send(msj);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //para los errores algun mensaje
            }
        }
    
    }
}