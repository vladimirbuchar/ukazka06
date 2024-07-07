using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;
using System;

namespace Services.CourseLessonItem.Service
{
    public interface ICourseLessonItemService
        : IBaseService<CourseLessonItemDbo, CourseLessonItemCreateDto, CourseLessonItemListDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto, CourseLessonItemFileRepositoryDbo>
    {
        Result UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItem, Guid userId);
    }
}
