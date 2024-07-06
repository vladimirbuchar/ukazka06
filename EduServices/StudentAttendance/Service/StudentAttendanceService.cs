using Core.Base.Service;
using EduRepository.AttendanceStudentRepository;
using EduServices.StudentAttendance.Convertor;
using EduServices.StudentAttendance.Dto;
using EduServices.StudentAttendance.Validator;
using Model.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Service
{
    public class StudentAttendanceService(IAttendanceStudentRepository repository, IStudentAttendanceConvertor convertor, IStudentAttendanceValidator validator)
        : BaseService<
            IAttendanceStudentRepository,
            AttendanceStudentDbo,
            IStudentAttendanceConvertor,
            IStudentAttendanceValidator,
            StudentAttendanceCreateDto,
            StudentAttendanceListDto,
            StudentAttendanceDetailDto
        >(repository, convertor, validator),
            IStudentAttendanceService { }
}
