﻿using Core.Base.Validator;
using EduRepository.CourseTermRepository;
using EduServices.CourseTerm.Dto;
using Model.Tables.Edu.CourseTerm;

namespace EduServices.CourseTerm.Validator
{
    public interface ICourseTermValidator : IBaseValidator<CourseTermDbo, ICourseTermRepository, CourseTermCreateDto, CourseTermDetailDto, CourseTermUpdateDto> { }
}
