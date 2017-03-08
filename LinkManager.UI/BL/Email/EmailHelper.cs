using LinkManager.UI.BL.Email.ViewModels;
using LinkManager.UI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LinkManager.UI.BL.Email
{
    public class EmailHelper
    {
        public void SendRiskEstimatesMessage(List<string> receipients, string subject, List<RiskEstimatesItemViewModel> riskEstimates)
        {
            var header = @Resources.RiskEstimatesTableHeader;
            var rows = string.Empty;

            foreach (var riskEstimate in riskEstimates)
            {
                rows += string.Format(@Resources.RiskEstimatesTableRow,
                    riskEstimate.RowColor,
                    riskEstimate.Supervisor,
                    riskEstimate.Project,
                    riskEstimate.SelfCost,
                    riskEstimate.ProposedExternalRate,
                    riskEstimate.CurrentRate);
            }

            foreach(var receipient in receipients)
            {
                SendMessage(receipient, subject, string.Format(header, rows));
            }

        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="receipient">Receipient email</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body</param>
        private void SendMessage(string receipient, string subject, string body)
        {
            try
            {
                //string email =
                //    System.Configuration.ConfigurationManager.AppSettings["smtp_email"].ToString();
                //string password =
                //     System.Configuration.ConfigurationManager.AppSettings["smtp_password"].ToString();

                string email = "oleghsandra@gmail.com";
                string password = "33843795";

                string to = receipient;
                string from = email;
                MailMessage message = new MailMessage(from, to);
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(email, password);
                client.EnableSsl = true;

                client.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}