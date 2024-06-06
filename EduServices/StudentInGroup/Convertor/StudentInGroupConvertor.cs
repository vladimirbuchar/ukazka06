using EduServices.StudentInGroup.Dto;
using Model.Tables.Link;
using System.Collections.Generic;

namespace EduServices.StudentInGroup.Convertor
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
