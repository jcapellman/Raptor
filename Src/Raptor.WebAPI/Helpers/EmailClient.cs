using System;
using System.Net.Mail;
using Raptor.PCL.Common;

namespace Raptor.WebAPI.Helpers {
    public class EmailClient {
        private static string senderAddress;

        private static string stripHTML(string sourceString) {
            if (string.IsNullOrEmpty(sourceString)) {
                return string.Empty;
            }

            var array = new char[sourceString.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var @let in sourceString) {
                switch (@let) {
                    case '<':
                        inside = true;
                        continue;
                    case '>':
                        inside = false;
                        continue;
                }

                if (inside) {
                    continue;
                }

                array[arrayIndex] = @let;
                arrayIndex++;
            }

            return new string(array, 0, arrayIndex);
        }

        public static ReturnSet<bool> SendEmailAsync(string receipient, string subject, string body, bool useHTML = true) {
            try {
                using (var smtpClient = new SmtpClient()) {
                    var emailMessage = new MailMessage(senderAddress, receipient) {
                        Body = (useHTML ? body : stripHTML(body)),
                        Subject = subject,
                        IsBodyHtml = useHTML
                    };

                    smtpClient.SendAsync(emailMessage, null);

                    return new ReturnSet<bool>(true);
                }
            } catch (Exception ex) {
                return new ReturnSet<bool>(ex);
            }
        }
    }
}