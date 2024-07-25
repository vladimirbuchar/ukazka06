using Core.Base.Filter;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;
using System;
using System.Threading.Tasks;

namespace Services.CourseLessonItem.Service
{
    public interface ICourseLessonItemService
        : IBaseService<
            CourseLessonItemDbo,
            CourseLessonItemCreateDto,
            CourseLessonItemListDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto,
            CourseLessonItemFileRepositoryDbo,
            FilterRequest
        >
    {
        Task<Result> UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItem, Guid userId);
    }
}
