using CodebookService.TimeTableDropDown.Convertor;
using CodebookService.TimeTableDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.TimeTableDropDown.Command
{
    public class TimeTableDropDownService : BaseDropDownCommand<TimeTableDbo, ICodeBookRepository<TimeTableDbo>, TimeTableDropDownDto, ITimeTableDropDownConvertor>, ITimeTableDropDownService
    {
        public TimeTableDropDownService(ICodeBookRepository<TimeTableDbo> repository, ITimeTableDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
