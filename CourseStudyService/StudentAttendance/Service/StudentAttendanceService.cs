using Core.Base.Command;
using Core.Base.Filter;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudentRepository;
using Services.StudentAttendance.Convertor;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Commands.StudentAttendanceCreate.Dto;
using Services.StudentAttendance.Validator;

namespace Services.StudentAttendance.Service
{
    [System.Obsolete]
    public class StudentAttendanceService(
        IAttendanceStudentRepository repository,
        IStudentAttendanceConvertor convertor,
        IStudentAttendanceValidator validator
    )
        : BaseService<
            IAttendanceStudentRepository,
            StudentAttendanceDbo,
            IStudentAttendanceConvertor,
            IStudentAttendanceValidator,
            StudentAttendanceCreateDto,
            StudentAttendanceListDto,
            StudentAttendanceDetailDto,
            RequestFilter
        >(repository, convertor, validator),
            IStudentAttendanceService
    { }
}
