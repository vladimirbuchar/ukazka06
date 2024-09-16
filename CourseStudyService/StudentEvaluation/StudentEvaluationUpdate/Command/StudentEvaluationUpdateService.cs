using Core.Base.Command.Update;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Validator;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Command
{
    public class StudentEvaluationUpdateService : BaseUpdateCommand<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationUpdateDto, IStudentEvaluationUpdateConvertor, IStudentEvaluationUpdateValidator>, IStudentEvaluationUpdateService
    {
        public StudentEvaluationUpdateService(IStudentEvaluationRepository repository, IStudentEvaluationUpdateConvertor convertor, IStudentEvaluationUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
