using Core.Base.Service;
using EduServices.CourseLessonItem.Dto;
using Model.Tables.Edu.CourseLessonItem;
using System;

namespace EduServices.CourseLessonItem.Service
{
    public interface ICourseLessonItemService
        : IBaseService<CourseLessonItemDbo, CourseLessonItemCreateDto, CourseLessonItemListDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto, CourseLessonItemFileRepositoryDbo>
    {
        void UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItem, Guid userId);
    }
}
