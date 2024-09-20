using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Services
{
    public interface IEmailService
    {
        void SendPasswordResetEmail(string toEmail, string resetLink);
        void SendPasswordChangedEmail(string toEmail);
        Task SendAppointmentNotificationEmail(string toEmail, string petName, Appointment appointment); //
    }
}
