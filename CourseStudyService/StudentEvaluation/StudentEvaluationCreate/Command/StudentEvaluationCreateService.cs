using Core.Base.Command.Create;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Validator;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Command
{
    public class StudentEvaluationCreateService(IStudentEvaluationRepository repository, IStudentEvaluationCreateConvertor convertor, IStudentEvaluationCreateValidator validator) : BaseCreateCommand<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto, IStudentEvaluationCreateConvertor, IStudentEvaluationCreateValidator>(repository, convertor, validator), IStudentEvaluationCreateService
    {
    }
}
