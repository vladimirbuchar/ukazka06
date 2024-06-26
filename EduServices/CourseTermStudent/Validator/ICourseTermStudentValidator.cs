﻿using Core.Base.Validator;
using EduRepository.CourseStudentRepository;
using EduServices.CourseTermStudent.Dto;
using Model.Tables.Link;

namespace EduServices.CourseTermStudent.Validator
{
    public interface ICourseTermStudentValidator : IBaseValidator<CourseStudentDbo, ICourseStudentRepository, CourseTermStudentCreateDto, CourseTermStudentDetailDto> { }
}
