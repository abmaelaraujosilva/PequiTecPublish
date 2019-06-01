using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PequiTec
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            MailMessage mailMessage = new MailMessage();
            //Endereço que irá aparecer no e-mail do usuário 
            mailMessage.From = new MailAddress("nerds@itpac.com", "N.E.R.D.S.");
            //destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula  
            mailMessage.To.Add(message.Destination);
            mailMessage.Subject = message.Subject;
            mailMessage.IsBodyHtml = true;
            //conteudo do corpo do e-mail 
            mailMessage.Body = message.Body;
            mailMessage.Priority = MailPriority.High;


            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            //credenciais da conta que utilizará para enviar o e-mail 
            client.Credentials = new NetworkCredential("nerds@itpac.br", "Nerds8102");
            return client.SendMailAsync(mailMessage);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class IdentityUserManager : UserManager<IdentityUser, Guid>
    {
        public IdentityUserManager(IUserStore<IdentityUser, Guid> store)
            : base(store)
        {
        }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            var manager = new IdentityUserManager(new UserStore<IdentityUser>(context.Get<IdentityConnection>().Connection.ConnectionString));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<IdentityUser, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUser, Guid>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUser, Guid>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<IdentityUser, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class IdentitySignInManager : SignInManager<IdentityUser, Guid>
    {
        public IdentitySignInManager(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            return user.GenerateUserIdentityAsync((IdentityUserManager)UserManager, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static IdentitySignInManager Create(IdentityFactoryOptions<IdentitySignInManager> options, IOwinContext context)
        {
            return new IdentitySignInManager(context.GetUserManager<IdentityUserManager>(), context.Authentication);
        }
    }
}
