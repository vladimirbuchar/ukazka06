using CourseStudyService.Lector.LectorCreate.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorCreate.Convertor
{
    public class LectorCreateConvertor : ILectorCreateConvertor
    {
        public Task<CourseLectorDbo> ConvertToBussinessEntity(LectorCreateDto create, string culture)
        {
            return Task.FromResult(new CourseLectorDbo() { CourseTermId = create.CourseTermId, UserInOrganizationId = create.UserInOrganizationId });
        }
    }
}
