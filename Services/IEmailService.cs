namespace VetCare_BackEnd.Services
{
    public interface IEmailService
    {
        void SendPasswordResetEmail(string toEmail, string resetLink);
    }
}
