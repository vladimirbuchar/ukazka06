using Core.Base.Convertor;
using Model.Edu.Email;
using Services.Email.EmailDetail.Dto;

namespace SystemServices.Email.EmailDetail.Convertor
{
    public interface IEmailDetailConvertor : IBaseDetailConvertor<EmailDbo, EmailDetailDto>
    {
    }
}