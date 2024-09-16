using CodebookService.EmailTypeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.EmailTypeDropDown.Convertor
{
    public interface IEmailTypeDropDownConvertor : IBaseDropDownConvertor<EmailTypeDbo, EmailDetailServiceDto>
    {
    }
}