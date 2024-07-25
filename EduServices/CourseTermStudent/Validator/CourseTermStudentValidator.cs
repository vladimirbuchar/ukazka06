using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseTerm;
using Model.Link;
using Repository.CourseStudentRepository;
using Repository.CourseTermRepository;
using Services.CourseTermStudent.Dto;
using System;
using System.Threading.Tasks;

namespace Services.CourseTermStudent.Validator
{
    public class CourseTermStudentValidator(ICourseStudentRepository repository, ICourseTermRepository courseTermRepository)
        : BaseValidator<CourseStudentDbo, ICourseStudentRepository, CourseTermStudentCreateDto>(repository),
            ICourseTermStudentValidator
    {
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public override Task<Result> IsValid(CourseTermStudentCreateDto create)
        {
            Result result = new();
            IsValidStudentCount(create.CourseTermId, result);
            return Task.FromResult(result);
        }

        public async void IsValidStudentCount(Guid termId, Result result)
        {
            CourseTermDbo term = await _courseTermRepository.GetEntity(termId);
            int maximumStudent = term?.MaximumStudent ?? 0;
            if (maximumStudent > 0)
            {
                if (maximumStudent < (await _repository.GetTotalCount(false, x => x.CourseTermId == termId)) + 1)
                {
                    result.AddResultStatus(
                        new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.ADD_MORE_STUDENTS_THAN_MAXIMUM)
                    );
                }
            }
        }
    }
}
