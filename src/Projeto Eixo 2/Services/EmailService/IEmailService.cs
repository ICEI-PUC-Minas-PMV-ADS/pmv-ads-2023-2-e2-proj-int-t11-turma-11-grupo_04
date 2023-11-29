using Projeto_Eixo_2.Models;

namespace Projeto_Eixo_2.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
