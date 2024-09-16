using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Convertor;
using CourseStudyService.StudentEvaluation.StudentEvaluationList.Dto;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationList.Service
{
    public class StudentEvaluationListService : BaseListCommand<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationListDto, IStudentEvaluationListConvertor, RequestFilter>, IStudentEvaluationListService
    {
        public StudentEvaluationListService(IStudentEvaluationRepository repository, IStudentEvaluationListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
