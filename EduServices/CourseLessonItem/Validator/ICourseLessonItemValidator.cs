﻿using Core.Base.Validator;
using EduRepository.CourseLessonItemRepository;
using EduServices.CourseLessonItem.Dto;
using Model.Tables.Edu.CourseLessonItem;

namespace EduServices.CourseLessonItem.Validator
{
    public interface ICourseLessonItemValidator : IBaseValidator<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemCreateDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto> { }
}
