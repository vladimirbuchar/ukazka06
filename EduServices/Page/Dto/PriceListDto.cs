using Core.Base.Dto;

namespace EduServices.Page.Dto
{
    public class PriceListDto : ListDto
    {
        public int MaximumBranch { get; set; }
        public int MaximumCourse { get; set; }
        public bool CreatePrivateCourse { get; set; }
        public int MaximumUser { get; set; }
        public double MounthPrice { get; set; }
        public double OneYearSale { get; set; }
        public bool SendCourseInquiry { get; set; }
        public string Name { get; set; }
    }
}
