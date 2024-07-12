using Core.Base.Filter;
using Core.Base.Service;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudentRepository;
using Services.StudentAttendance.Convertor;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Validator;

namespace Services.StudentAttendance.Service
{
    public class StudentAttendanceService(
        IAttendanceStudentRepository repository,
        IStudentAttendanceConvertor convertor,
        IStudentAttendanceValidator validator
    )
        : BaseService<
            IAttendanceStudentRepository,
            AttendanceStudentDbo,
            IStudentAttendanceConvertor,
            IStudentAttendanceValidator,
            StudentAttendanceCreateDto,
            StudentAttendanceListDto,
            StudentAttendanceDetailDto,
            FilterRequest
        >(repository, convertor, validator),
            IStudentAttendanceService { }
}
