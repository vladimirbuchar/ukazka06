using Core.Base.Command.Detail;
using Model.Edu.Email;
using Services.Email.EmailDetail.Dto;

namespace Services.Email.EmailDetail.Command
{
    public interface IEmailDetailService : IBaseDetailCommand<EmailDbo, EmailDetailDto>
    {
    }
}