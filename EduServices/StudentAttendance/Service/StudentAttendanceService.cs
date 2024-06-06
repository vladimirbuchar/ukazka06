using Core.Base.Service;
using EduRepository.AttendanceStudentRepository;
using EduServices.StudentAttendance.Convertor;
using EduServices.StudentAttendance.Dto;
using EduServices.StudentAttendance.Validator;
using Model.Tables.Edu.AttendanceStudent;

namespace EduServices.StudentAttendance.Service
{
    public class StudentAttendanceService(IStudentAttendanceRepository repository, IStudentAttendanceConvertor convertor, IStudentAttendanceValidator validator)
        : BaseService<
            IStudentAttendanceRepository,
            StudentAttendanceDbo,
            IStudentAttendanceConvertor,
            IStudentAttendanceValidator,
            StudentAttendanceCreateDto,
            StudentAttendanceListDto,
            StudentAttendanceDetailDto
        >(repository, convertor, validator),
            IStudentAttendanceService { }
}
