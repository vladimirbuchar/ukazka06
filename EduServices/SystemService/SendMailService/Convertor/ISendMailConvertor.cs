using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.SendEmail;
using Services.SystemService.SendMailService.Dto;

namespace Services.SystemService.SendMailService.Convertor
{
    public interface ISendMailConvertor : IBaseConvertor
    {
        List<SendMailListDto> ConvertToWebModel(List<SendEmailDbo> sendEmail);
        SendMaiDetailDto ConvertToWebModel(SendEmailDbo sendEmail);
    }
}
