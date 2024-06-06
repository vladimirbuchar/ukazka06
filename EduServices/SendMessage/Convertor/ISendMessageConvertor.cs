using Core.Base.Convertor;
using EduServices.SendMessage.Dto;
using Model.Tables.Edu.SendMessage;

namespace EduServices.SendMessage.Convertor
{
    public interface ISendMessageConvertor : IBaseConvertor<SendMessageDbo, SendMessageCreateDto, SendMessageListDto, SendMessageDetailDto, SendMessageUpdateDto> { }
}
