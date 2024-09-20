using System;
using System.Net;
using System.Net.Mail;
using DotNetEnv; // Ensure this is present
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Env.Load(); // Load environment variables
        }

        public void SendPasswordResetEmail(string toEmail, string resetLink)
        {
            // Read environment variables
            var fromEmail = Env.GetString("EMAIL");
            var fromName = "VetCare";
            var fromPassword = Env.GetString("PASSWORD");
            var subject = "Password Reset - VetCare";

            // Email message content in HTML
            var body = $@"
            <html>
            <body>
                <div style='font-family: Arial, sans-serif; text-align: center; padding: 20px;'>
                    <img src='https://i.imgur.com/BnB3gyq.jpg' alt='VetCare' style='width: 400px;'/>
                    <h2>Hello!</h2>
                    <p>We have received a request to reset your password at <strong>VetCare</strong>.</p>
                    <p>To proceed with resetting your password, please click the following link:</p>
                    <a href='{resetLink}' style='display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px;'>Reset Password</a>
                    <p>This link is valid for 5 minutes.</p>
                    <p>If you did not request this change, you can ignore this email.</p>
                    <br />
                    <p>Thank you for trusting us!</p>
                    <p>VetCare Team</p>
                </div>
            </body>
            </html>";

            // Configure the SMTP client
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            // Create the email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Password reset email sent successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}, StatusCode: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }

        public void SendPasswordChangedEmail(string toEmail)
        {
            // Read environment variables
            var fromEmail = Env.GetString("EMAIL");
            var fromPassword = Env.GetString("PASSWORD");
            var subject = "Your Password Has Been Changed - VetCare";

            // Email message content in HTML
            var body = $@"
            <html>
            <body>
                <div style='font-family: Arial, sans-serif; text-align: center; padding: 20px;'>
                    <img src='https://i.imgur.com/BnB3gyq.jpg' alt='VetCare' style='width: 400px;'/>
                    <h2>Hello!</h2>
                    <p>This is a notification that your password has been successfully changed.</p>
                    <p>If you did not request this change, please contact our support team immediately.</p>
                    <br />
                    <p>Thank you for trusting us!</p>
                    <p>VetCare Team</p>
                </div>
            </body>
            </html>";

            // Configure the SMTP client
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            // Create the email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Password change notification email sent successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}, StatusCode: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }

        public async Task SendAppointmentNotificationEmail(string toEmail, string petName, Appointment appointment)
        {
            var fromEmail = Env.GetString("EMAIL");
            var fromName = "VetCare";
            var subject = "New Appointment Scheduled - VetCare";

            // Correct format for appointment time
            var startTime = appointment.EndDate.ToString("yyyyMMddTHHmm00Z"); // Format for Google Calendar
            var endTime = appointment.EndDate.AddHours(1).ToString("yyyyMMddTHHmm00Z"); // Add 1 hour for end time

            // Email content in HTML
            var body = $@"
    <html>
    <body>
        <div style='font-family: Arial, sans-serif; text-align: center; padding: 20px; border: 1px solid #e0e0e0; border-radius: 5px; background-color: #f9f9f9;'>
            <img src='https://i.imgur.com/BnB3gyq.jpg' alt='VetCare' style='width: 400px; margin-bottom: 20px;'/>
            <h2 style='color: #4CAF50;'>New Appointment Scheduled!</h2>
            <p style='font-size: 16px;'>You have scheduled an appointment for: <strong>{petName}</strong></p>
            <p><strong>Appointment Type:</strong> {appointment.AppointmentType?.Name ?? "Appointment"}</p>
            <p><strong>Appointment Date:</strong> {appointment.EndDate:dd/MM/yyyy}</p>
            <p><strong>Appointment Time:</strong> {appointment.EndDate:HH:mm}</p>
            <p><strong>Description:</strong> {appointment.Description}</p>
            <p>We remind you that you can add this appointment to your Google calendar to receive reminders.</p>
            <a href='https://calendar.google.com/calendar/r/eventedit?text=Veterinary%20Visit%20for%20{petName}&dates={startTime}/{endTime}&details={appointment.Description}&location=VetCare' 
                style='display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; margin-top: 10px;'>Add to Calendar</a>
            <br />
            <p style='margin-top: 20px;'>Thank you for trusting us!</p>
            <p>VetCare Team</p>
        </div>
    </body>
    </html>";

            // Configure the SMTP client
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, Env.GetString("PASSWORD")),
                EnableSsl = true
            };

            // Create the email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Appointment notification sent successfully.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}, StatusCode: {ex.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }
}
