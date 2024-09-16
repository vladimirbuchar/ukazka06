using Core.Base.Command.Update;
using CourseStudyService.CourseTable.CourseTableUpdate.Convertor;
using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using CourseStudyService.CourseTable.CourseTableUpdate.Validator;
using Model.Edu.CourseTable;
using Repository.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Command
{
    public class CourseTableUpdateCommand : BaseUpdateCommand<CourseTableDbo, ICourseTableRepository, CourseTableUpdateDto, ICourseTableUpdateConvertor, ICourseTableUpdateValidator>, ICourseTableUpdateCommand
    {
        public CourseTableUpdateCommand(ICourseTableRepository repository, ICourseTableUpdateConvertor convertor, ICourseTableUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
