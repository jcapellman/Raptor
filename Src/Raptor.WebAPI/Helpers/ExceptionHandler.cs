namespace Raptor.WebAPI.Helpers {
    public class ExceptionHandler {
        private static string errorEmailAddress;

        public static void HandleException(string source, string exception) {
            var emailSent = EmailClient.SendEmailAsync(errorEmailAddress, $"Exception from {source}", exception);

            if (!emailSent.HasError) {
                return;
            }

            //todo handle exception handling when email fails
        }
    }
}