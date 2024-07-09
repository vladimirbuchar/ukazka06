using Core.Base.Request;

namespace Services.StudentInGroup.Filter
{
    public class StudentInGroupFilter : FilterRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
