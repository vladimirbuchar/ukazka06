using Core.Base.Dto;

namespace CourseStudyService.Lector.LectorList.Dto
{
    public class LectorListDto : ListDto
    {
        public Guid UserInOrganizationId { get; set; }
        public Guid CourseTermId { get; set; }

    }


}
