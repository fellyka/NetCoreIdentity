using System;
using System.Web;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace IdentityApp.Services
{
    public class ConsoleEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string emailAddress, string subject, string message)
        {
            Console.WriteLine("---New Email-----");
            Console.WriteLine($"To: {emailAddress}");
            Console.WriteLine($"Subect: {subject}");
            Console.WriteLine(HttpUtility.HtmlDecode(message));
            Console.WriteLine("------------");

            return Task.CompletedTask;
        }
    }
}
