using Core.Base.Validator;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluationRepository;
using Services.StudentEvaluation.Dto;

namespace Services.StudentEvaluation.Validator
{
    public interface IStudentEvaluationValidator : IBaseValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto, StudentEvaluationDetailDto> { }
}
