using CodebookService.CourseTypeDropDown.Convertor;
using CodebookService.CourseTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CourseTypeDropDown.Command
{
    public class CourseTypeDropDownService : BaseDropDownCommand<CourseTypeDbo, ICodeBookRepository<CourseTypeDbo>, CourseTypeDropDownDto, ICourseTypeDropDownConvertor>, ICourseTypeDropDownService
    {
        public CourseTypeDropDownService(ICodeBookRepository<CourseTypeDbo> repository, ICourseTypeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
