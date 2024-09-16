using CourseStudyService.Lector.LectorList.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorList.Convertor
{
    public class LectorListConvertor : ILectorListConvertor
    {
        public Task<List<LectorListDto>> ConvertToWebModel(List<CourseLectorDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new LectorListDto()
                {
                    CourseTermId = x.CourseTermId,
                    Id = x.Id,
                    UserInOrganizationId = x.UserInOrganizationId,

                })
                    .ToList()
            );
        }
    }
}
