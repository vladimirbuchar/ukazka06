using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseTerm;
using Model.Link;
using Repository.CourseStudentRepository;
using Repository.CourseTermRepository;
using Services.CourseTermStudent.Dto;
using System;

namespace Services.CourseTermStudent.Validator
{
    public class CourseTermStudentValidator(ICourseStudentRepository repository, ICourseTermRepository courseTermRepository)
        : BaseValidator<CourseStudentDbo, ICourseStudentRepository, CourseTermStudentCreateDto, CourseTermStudentDetailDto>(repository),
            ICourseTermStudentValidator
    {
        private readonly ICourseTermRepository _courseTermRepository = courseTermRepository;

        public override Result<CourseTermStudentDetailDto> IsValid(CourseTermStudentCreateDto create)
        {
            Result<CourseTermStudentDetailDto> result = new();
            IsValidStudentCount(create.CourseTermId, result);
            return result;
        }

        public void IsValidStudentCount(Guid termId, Result result)
        {
            CourseTermDbo term = _courseTermRepository.GetEntity(termId);
            int maximumStudent = term?.MaximumStudent ?? 0;
            if (maximumStudent > 0)
            {
                if (maximumStudent < _repository.GetEntities(false, x => x.CourseTermId == termId).Count + 1)
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.ADD_MORE_STUDENTS_THAN_MAXIMUM));
                }
            }
        }
    }
}
