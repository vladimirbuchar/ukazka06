using CodebookService.CountryDropDown.Convertor;
using CodebookService.CountryDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CountryDropDown.Command
{
    public class CountryDropDownService : BaseDropDownCommand<CountryDbo, ICodeBookRepository<CountryDbo>, CountryDropDownDto, ICountryDropDownConvertor>, ICountryDropDownService
    {
        public CountryDropDownService(ICodeBookRepository<CountryDbo> repository, ICountryDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
