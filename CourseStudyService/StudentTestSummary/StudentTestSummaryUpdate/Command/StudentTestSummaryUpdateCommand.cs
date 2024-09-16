using Core.Base.Command.Update;
using Core.DataTypes;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Convertor;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Validator;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Command
{
    public class StudentTestSummaryUpdateCommand : BaseUpdateCommand<StudentTestSummaryDbo, IStudentTestSummaryRepository, StudentTestSummaryUpdateDto, IStudentTestSummaryUpdateConvertor, IStudentTestSummaryUpdateValidator>, IStudentTestSummaryUpdateCommand
    {
        public StudentTestSummaryUpdateCommand(IStudentTestSummaryRepository repository, IStudentTestSummaryUpdateConvertor convertor, IStudentTestSummaryUpdateValidator validator) : base(repository, convertor, validator)
        {
        }
        public override async Task<Result> Execute(StudentTestSummaryUpdateDto update, Guid userId, string culture, Result? result = null)
        {

            StudentTestSummaryDbo studentTestSummaryDbo = await _repository.GetEntity(update.Id);
            if (update.IsAutomatic)
            {
                studentTestSummaryDbo.IsAutomaticEvaluate = true;
                int desiredSuccess = studentTestSummaryDbo.CourseTest.DesiredSuccess;
                if (desiredSuccess == 0 || update.SumScore >= desiredSuccess)
                {
                    update.IsSucess = true;
                }
            }
            return await base.Execute(update, userId, culture, result);
        }
    }
}
