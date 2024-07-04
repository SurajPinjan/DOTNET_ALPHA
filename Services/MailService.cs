using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Aspose.Email;
using Aspose.Email.Clients.Smtp;
using System.IO;

namespace AutomateLIMS.Services
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<String> Attachment { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    static class MailService
    {
        public static string AllToReceiversList(string[] receiversLists)
        {
            HashSet<string> receiverSet = new HashSet<string>();

            foreach (var receivers in receiversLists)
            {
                string[] receiversList = receivers.Split(@";");

                foreach (var item in receiversList)
                {
                    if (item != "")
                        receiverSet.Add(item);
                }
            }

            string newReceiversList = "";

            foreach (var item in receiverSet)
            {
                newReceiversList = newReceiversList + item + @";";
            }

            return newReceiversList;
        }

        public static void SendMail(EmailModel model)
        {

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            IConfigurationSection mailConfigurations = configuration.GetSection("MailConfigurations");
            string host = mailConfigurations.GetValue<string>("Host");
            string username = mailConfigurations.GetValue<string>("Username");
            string password = mailConfigurations.GetValue<string>("Password");
            int port = mailConfigurations.GetValue<int>("Port");

            using (MailMessage mailMessage = new MailMessage(model.Email, model.To))
            {
                mailMessage.Subject = model.Subject;
                mailMessage.Body = model.Body;
                if (model.Attachment.Count > 0)
                {
                    for (int i = 0; i < model.Attachment.Count; i++)
                    {
                        mailMessage.AddAttachment(new Attachment(model.Attachment[i]));
                    }

                    mailMessage.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = host;
                        smtp.Username = username;
                        smtp.Password = password;
                        smtp.Port = port;
                        smtp.SecurityOptions = Aspose.Email.Clients.SecurityOptions.SSLExplicit;
                        smtp.Send(mailMessage);
                    }
                }
            }
        }
    }
}
