using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTermRepository;
using EduServices.CourseTermStudent.Dto;
using Model.Edu.CourseTerm;
using Model.Link;
using System;

namespace EduServices.CourseTermStudent.Validator
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
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE, Constants.ADD_MORE_STUDENTS_THAN_MAXIMUM));
                }
            }
        }
    }
}
