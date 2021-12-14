using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmailConfirmationController : ApiController
    {
        [HttpGet]
        [Route("Api/SendEmail")]
        public void SendEmail()
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress("fahimfaisal1998@gmail.com"));
            message.From = new MailAddress("buddyhub@fahimfaisal.net");
            //message.Bcc.Add(new MailAddress("Amit Mohanty <amitmohanty@email.com>"));
            message.Subject = "Test Message form ASP";
            message.Body = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("/Assets/Html/EmailTemplate.html"));
            //Body = Body.Replace("#DealerCompanyName#", _lstGetDealerRoleAndContactInfoByCompanyIDResult[0].CompanyName);
            message.IsBodyHtml = true;
            var smtp = new SmtpClient("fahimfaisal.net");
            //smtp.Port = 465;  ///---------**Note**--Time Out when using the port
            smtp.Credentials = new NetworkCredential("buddyhub@fahimfaisal.net", "faisal@123");
            smtp.EnableSsl = true;
            smtp.Send(message);

        }
    }
}
