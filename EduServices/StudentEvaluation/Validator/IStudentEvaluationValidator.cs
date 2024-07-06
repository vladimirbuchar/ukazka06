using Core.Base.Validator;
using EduRepository.StudentEvaluationRepository;
using EduServices.StudentEvaluation.Dto;
using Model.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Validator
{
    public interface IStudentEvaluationValidator : IBaseValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationCreateDto, StudentEvaluationDetailDto> { }
}
