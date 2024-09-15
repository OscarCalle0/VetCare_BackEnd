using System;
using System.Net;
using System.Net.Mail;
using DotNetEnv; // Add this using directive

namespace VetCare_BackEnd.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
            // Load environment variables from the .env file
            Env.Load();
        }

        public void SendPasswordResetEmail(string toEmail, string resetLink)
        {
            // Read environment variables
            var fromEmail = Env.GetString("EMAIL");
            var fromPassword = Env.GetString("PASSWORD");
            var subject = "Password Reset - VetCare";

            // Email message content in HTML
            var body = $@"
            <html>
            <body>
                <div style='font-family: Arial, sans-serif; text-align: center; padding: 20px;'>
                    <img src='https://1drv.ms/i/s!AjnbxFRkOaPRhedV9yK8CHno0pe2Ww?e=CnM8DC' alt='VetCare' style='width: 150px;'/>
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

            // Configure SMTP client
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
                Console.WriteLine("Email sent successfully.");
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
