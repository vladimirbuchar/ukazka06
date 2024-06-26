﻿using Core.Base.Validator;
using EduRepository.CourseTestEvaluationRepository;
using EduServices.CourseTestEvaluation.Dto;
using Model.Tables.Edu.CourseTestEvaluation;

namespace EduServices.CourseTestEvaluation.Validator
{
    public interface ICourseTestEvaluationValidator
        : IBaseValidator<CourseTestEvaluationDbo, ICourseTestEvaluationRepository, CourseTestEvaluationCreateDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto> { }
}
