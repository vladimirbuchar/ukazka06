using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using Model.Edu.StudentEvaluation;
using Repository.CourseStudent;
using Repository.CourseTerm;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Validator
{
    public class StudentEvaluationCreateValidator : BaseCreateValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto>, IStudentEvaluationCreateValidator
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly ICourseTermRepository _courseTermRepository;
        public StudentEvaluationCreateValidator(ICourseTermRepository courseTermRepository, ICourseStudentRepository courseStudentRepository, IStudentEvaluationRepository repository) : base(repository)
        {
            _courseTermRepository = courseTermRepository;
            _courseStudentRepository = courseStudentRepository;
        }
        public override async Task<ResultInsert> IsValid(StudentEvaluationCreateDto create)
        {
            ResultInsert validate = new();
            if (await _courseStudentRepository.GetEntity(create.CourseStudentId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_STUDENT, MessageItem.NOT_EXISTS));
            }
            if (await _courseTermRepository.GetEntity(create.CourseTermId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_TERM, MessageItem.NOT_EXISTS));
            }
            return await Task.FromResult(validate);
        }
    }
}
