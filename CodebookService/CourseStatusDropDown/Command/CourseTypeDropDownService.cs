using CodebookService.CourseStatusDropDown.Convertor;
using CodebookService.CourseStatusDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CourseStatusDropDown.Command
{
    public class CourseStatusDropDownService : BaseDropDownCommand<CourseStatusDbo, ICodeBookRepository<CourseStatusDbo>, CourseStatusDropDownDto, ICourseStatusDropDownConvertor>, ICourseStatusDropDownService
    {
        public CourseStatusDropDownService(ICodeBookRepository<CourseStatusDbo> repository, ICourseStatusDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
