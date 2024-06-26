﻿using Core.Base.Convertor;
using EduServices.CourseLessonItem.Dto;
using Model.Tables.Edu.CourseLessonItem;

namespace EduServices.CourseLessonItem.Convertor
{
    public interface ICourseLessonItemConvertor : IBaseConvertor<CourseLessonItemDbo, CourseLessonItemCreateDto, CourseLessonItemListDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto> { }
}
