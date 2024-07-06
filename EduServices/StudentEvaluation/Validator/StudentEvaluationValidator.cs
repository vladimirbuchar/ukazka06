using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTermRepository;
using EduRepository.StudentEvaluationRepository;
using EduServices.StudentEvaluation.Dto;
using Model.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Validator
{
    public class StudentEvaluationValidator(IStudentEvaluationRepository repository, ICourseStudentRepository courseStudentRepository, ICourseTermRepository courseTermRepository)
        : BaseValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto, StudentEvaluationDetailDto>(repository),
            IStudentEvaluationValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository = courseStudentRepository;
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public override Result<StudentEvaluationDetailDto> IsValid(StudentEvaluationCreateDto create)
        {
            Result<StudentEvaluationDetailDto> validate = new();
            if (_courseStudentRepository.GetEntity(create.CourseStudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_STUDENT, GlobalValue.NOT_EXISTS));
            }
            if (_courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_TERM, GlobalValue.NOT_EXISTS));
            }
            return validate;
        }
    }
}
