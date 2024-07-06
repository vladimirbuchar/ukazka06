using Core.Base.Service;
using EduRepository.StudentEvaluationRepository;
using EduServices.StudentEvaluation.Convertor;
using EduServices.StudentEvaluation.Dto;
using EduServices.StudentEvaluation.Validator;
using Model.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Service
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
