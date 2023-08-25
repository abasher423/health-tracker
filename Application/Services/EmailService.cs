using Application.Abstractions;
using Application.Abstractions.Services;
using Application.API.V1.Register.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Services;

public class EmailService : IEmailService
{
    private readonly IEmailVerificationProvider _emailVerificationProvider;
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config, IEmailVerificationProvider emailVerificationProvider)
    {
        _config = config;
        _emailVerificationProvider = emailVerificationProvider;
    }

    public async Task SendEmailAsync(string emailAddress, string subject, string body)
    {
        var emailSection = _config.GetSection("Email");
        
        try
        {
            var apiKey = emailSection["Apikey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailSection["Username"], "Health Tracker");
            var to = new EmailAddress(emailAddress, "Unverified User");
            var plainTextContent = "Sending with sendgrid is fun";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, body);
            var response = await client.SendEmailAsync(msg);
        }
        catch (Exception e)
        {
            throw new Exception($"Error sending email: {e.Message}");
        }
    }
    
    public EmailVerificationToken GenerateEmailToken()
    {
        var expiration = DateTime.UtcNow.AddHours(2);
            
        var token = new EmailVerificationToken()
        {
            Token = _emailVerificationProvider.GenerateEmailVerificationToken(expiration),
            Expiration = expiration
        };

        return token;
    }
    
    public string GenerateVerificationLink(string token)
    {
        var baseUrl = _config.GetSection("Email").GetSection("BaseUrl").Value;
        return $"{baseUrl}/verify/{token}";
    }
}