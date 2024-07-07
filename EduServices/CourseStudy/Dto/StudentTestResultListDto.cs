using System;
using Core.Base.Dto;
using Core.Extension;

namespace Services.CourseStudy.Dto
{
    public class StudentTestResultListDto : ListDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FullName =>
            FirstName.IsNullOrEmptyWithTrim() && SecondName.IsNullOrEmptyWithTrim() && LastName.IsNullOrEmptyWithTrim()
                ? string.Empty
                : SecondName.IsNullOrEmptyWithTrim()
                    ? string.Format("{0} {1}", FirstName.Trim(), LastName.Trim())
                    : string.Format("{0} {1} {2}", FirstName.Trim(), SecondName.Trim(), LastName.Trim());
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public DateTime? Finish { get; set; }
        public double Score { get; set; }
        public bool TestCompleted { get; set; }
    }
}
