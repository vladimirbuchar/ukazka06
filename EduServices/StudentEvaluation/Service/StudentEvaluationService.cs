using Core.Base.Service;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluationRepository;
using Services.StudentEvaluation.Convertor;
using Services.StudentEvaluation.Dto;
using Services.StudentEvaluation.Validator;

namespace Services.StudentEvaluation.Service
{
    public class StudentEvaluationService(IStudentEvaluationRepository courseTermRepository, IStudentEvaluationConvertor courseTermConvertor, IStudentEvaluationValidator validator)
        : BaseService<
            IStudentEvaluationRepository,
            StudentEvaluationDbo,
            IStudentEvaluationConvertor,
            IStudentEvaluationValidator,
            StudentEvaluationCreateDto,
            StudentEvaluationListDto,
            StudentEvaluationDetailDto
        >(courseTermRepository, courseTermConvertor, validator),
            IStudentEvaluationService
    {

    }
}
