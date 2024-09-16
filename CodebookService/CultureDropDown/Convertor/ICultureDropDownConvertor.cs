using CodebookService.CultureDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.CultureDropDown.Convertor
{
    public interface ICultureDropDownConvertor : IBaseDropDownConvertor<CultureDbo, CultureDropDownDto>
    {
    }
}