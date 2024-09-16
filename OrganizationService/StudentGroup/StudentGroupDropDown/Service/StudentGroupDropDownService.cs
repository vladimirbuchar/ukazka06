using Core.Base.Command.DropDown;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDropDown.Convertor;
using OrganizationService.StudentGroup.StudentGroupDropDown.Dto;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupDropDown.Service
{
    public class StudentGroupDropDownService : BaseDropDownCommand<StudentGroupDbo, IStudentGroupRepository, StudentGroupDropDownDto, IStudentGroupDropDownConvertor>, IStudentGroupDropDownService
    {
        public StudentGroupDropDownService(IStudentGroupRepository repository, IStudentGroupDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
