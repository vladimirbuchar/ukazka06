using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.DataTypes;
using EduRepository.CourseLessonItemRepository;
using EduServices.CourseLessonItem.Convertor;
using EduServices.CourseLessonItem.Dto;
using EduServices.CourseLessonItem.Validator;
using Model.Tables.CodeBook;
using Model.Tables.Edu.CourseLessonItem;
using System;

namespace EduServices.CourseLessonItem.Service
{
    public class CourseLessonItemService(
        ICourseLessonItemRepository courseLessonItemRepository,
        ICourseLessonItemValidator validator,
        ICourseLessonItemConvertor courseLessonItemConvertor,
        IFileUploadRepository<CourseLessonItemFileRepositoryDbo> repository,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseService<
            ICourseLessonItemRepository,
            CourseLessonItemDbo,
            ICourseLessonItemConvertor,
            ICourseLessonItemValidator,
            CourseLessonItemCreateDto,
            CourseLessonItemListDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto,
            CourseLessonItemFileRepositoryDbo
        >(courseLessonItemRepository, courseLessonItemConvertor, validator, repository, culture),
            ICourseLessonItemService
    {
        public Result UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLesson, Guid userId)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonItemDbo courseLessonItemDbo = _repository.GetEntity(id);
                if (courseLessonItemDbo != null)
                {
                    courseLessonItemDbo.Position = position;
                    _ = _repository.UpdateEntity(courseLessonItemDbo, userId);
                }
                position++;
            }
            return new Result();
        }
    }
}
