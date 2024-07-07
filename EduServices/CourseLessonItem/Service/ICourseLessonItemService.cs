using System;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;

namespace Services.CourseLessonItem.Service
{
    public interface ICourseLessonItemService
        : IBaseService<CourseLessonItemDbo, CourseLessonItemCreateDto, CourseLessonItemListDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto, CourseLessonItemFileRepositoryDbo>
    {
        Result UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItem, Guid userId);
    }
}
