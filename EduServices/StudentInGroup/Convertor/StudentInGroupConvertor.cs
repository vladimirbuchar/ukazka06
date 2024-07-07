using System.Collections.Generic;
using Model.Link;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Convertor
{
    public class StudentInGroupConvertor : IStudentInGroupConvertor
    {
        public StudentInGroupConvertor() { }

        public StudentInGroupDbo ConvertToBussinessEntity(StudentInGroupCreateDto create, string culture)
        {
            return new StudentInGroupDbo() { };
        }

        public HashSet<StudentInGroupListDto> ConvertToWebModel(HashSet<StudentInGroupDbo> list, string culture)
        {
            throw new System.NotImplementedException();
        }

        public StudentInGroupDetailDto ConvertToWebModel(StudentInGroupDbo detail, string culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
