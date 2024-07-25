using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.SendEmail;
using Model.Edu.SendEmailAttachment;
using Repository.SendEmailRepository;
using Services.SystemService.SendMailService.Convertor;
using Services.SystemService.SendMailService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.SystemService.SendMailService.Service
{
    public class SendMailService(
        ISendEmailRepository emailRepository,
        ICodeBookRepository<EduEmailDbo> codeBookRepository,
        ISendMailConvertor sendMailConvertor
    ) : BaseService<ISendEmailRepository, SendEmailDbo, ISendMailConvertor>(emailRepository, sendMailConvertor), ISendMailService
    {
        private readonly ICodeBookRepository<EduEmailDbo> _email = codeBookRepository;

        public async Task AddEmailToQueue(
            string subject,
            string html,
            List<string> attachment,
            EmailAddress emailAddressTo,
            Guid organizationId,
            string reply
        )
        {
            _ = await _repository.CreateEntity(
                new SendEmailDbo()
                {
                    Body = html,
                    Subject = subject,
                    SendEmailAttachments = attachment.Select(x => new SendEmailAttachmentDbo() { Attachment = x }).ToList()
                },
                Guid.Empty
            );
        }

        public async Task AddEmailToQueue(
            string emailIdentificator,
            string culture,
            EmailAddress emailAddressTo,
            Dictionary<string, string> replaceData,
            Guid? organizationId = null,
            string reply = ""
        )
        {
            EduEmailDbo eduEmail = await _email.GetEntity(false, x => x.SystemIdentificator == string.Format("{0}_{1}", emailIdentificator, culture));
            if (eduEmail == null)
            {
                culture = "en";
                eduEmail = await _email.GetEntity(false, x => x.SystemIdentificator == string.Format("{0}_{1}", emailIdentificator, culture));
            }
            if (eduEmail != null)
            {
                string emailBodyHtml = eduEmail.EmailBodyHtml;
                string emailBodyPlainText = eduEmail.EmailBodyPlainText;
                foreach (KeyValuePair<string, string> item in replaceData)
                {
                    emailBodyHtml = emailBodyHtml.Replace("{" + item.Key + "}", item.Value);
                    emailBodyPlainText = emailBodyPlainText.Replace("{" + item.Key + "}", item.Value);
                }
                _ = await _repository.CreateEntity(
                    new SendEmailDbo()
                    {
                        Body = emailBodyHtml,
                        PlainTextBody = emailBodyPlainText,
                        Subject = eduEmail.Subject,
                        EmailFrom = eduEmail.From,
                        IsHtml = true,
                        IsSended = false,
                        OrganizationId = organizationId,
                        EmailTo = emailAddressTo.Email,
                        EmailToName = emailAddressTo.Name,
                        Reply = reply
                    },
                    Guid.Empty
                );
            }
        }

        public async Task<List<SendMailListDto>> GetList(Guid orgranizationId)
        {
            return _convertor.ConvertToWebModel(await _repository.GetEntities(false, x => x.OrganizationId == orgranizationId));
        }

        public async Task<SendMaiDetailDto> GetDetail(Guid id)
        {
            return _convertor.ConvertToWebModel(await _repository.GetEntity(id));
        }

        public async Task<SendMaiDetailDto> Update(SendMailUpdateDto updateDto, Guid userId)
        {
            SendEmailDbo email = await _repository.GetEntity(updateDto.Id);
            email.IsSended = updateDto.IsSended;
            _ = await _repository.UpdateEntity(email, userId);
            return await GetDetail(updateDto.Id);
        }
    }
}
