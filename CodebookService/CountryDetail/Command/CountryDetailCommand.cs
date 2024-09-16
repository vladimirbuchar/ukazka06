using CodebookService.CountryDetail.Convertor;
using CodebookService.CountryDetail.Dto;
using Core.Base.Command.Detail;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CountryDetail.Command
{
    public class CountryDetailCommand : BaseDetailCommand<CountryDbo, ICodeBookRepository<CountryDbo>, CountryDetailDto, ICountryDetailConvertor>, ICountryDetailCommand
    {
        public CountryDetailCommand(ICodeBookRepository<CountryDbo> repository, ICountryDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
