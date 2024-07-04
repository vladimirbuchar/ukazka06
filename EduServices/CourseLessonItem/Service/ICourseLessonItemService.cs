using Core.Base.Service;
using Core.DataTypes;
using EduServices.CourseLessonItem.Dto;
using Model.Tables.Edu.CourseLessonItem;
using System;

namespace EduServices.CourseLessonItem.Service
{
    public interface ICourseLessonItemService
        : IBaseService<CourseLessonItemDbo, CourseLessonItemCreateDto, CourseLessonItemListDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto, CourseLessonItemFileRepositoryDbo>
    {
        Result UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItem, Guid userId);
    }
}
