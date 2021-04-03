using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CharityApplication.Models
{
    public class Email
    {
        public static async Task<bool> Execute(string email, string name, string password)
        {
			var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User);
			var client = new SendGridClient(apiKey);
			var from = new EmailAddress("saminmomin4@gmail.com", "Samin Momin");
			//var subject = "Sending with SendGrid is Fun";
			var to = new EmailAddress(email, name);
			//var plainTextContent = "and easy to do anywhere, even with C#";
			//var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
			var msg = MailHelper.CreateSingleTemplateEmail(from, to, "d-5a966f4b463449319cbb4277481ea0c3", new { name = password });
			//MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
			var response = await client.SendEmailAsync(msg);
			return response.IsSuccessStatusCode;
		}
    }
}