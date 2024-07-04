using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseLessonRepository;
using EduServices.CourseLesson.Convertor;
using EduServices.CourseLesson.Dto;
using EduServices.CourseLesson.Validator;
using Microsoft.AspNetCore.Http;
using Model.Tables.CodeBook;
using Model.Tables.Edu.CourseLesson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EduServices.CourseLesson.Service
{
    public class CourseLessonService(
        ICourseLessonRepository courseLessonRepository,
        ICourseLessonConvertor convertor,
        ICourseLessonValidator validator,
        IFileUploadRepository<CourseLessonFileRepositoryDbo> repository,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseService<
            ICourseLessonRepository,
            CourseLessonDbo,
            ICourseLessonConvertor,
            ICourseLessonValidator,
            CourseLessonCreateDto,
            CourseLessonListDto,
            CourseLessonDetailDto,
            CourseLessonUpdateDto,
            CourseLessonFileRepositoryDbo
        >(courseLessonRepository, convertor, validator, repository, culture),
            ICourseLessonService
    {
        public Result UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonDbo entity = _repository.GetEntity(id);
                if (entity != null)
                {
                    entity.Position = position;
                    _ = _repository.UpdateEntity(entity, userId);
                    position++;
                }
            }
            return new Result();
        }

        public override Result FileUpload(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            CourseLessonFileRepositoryDbo model,
            Expression<Func<CourseLessonFileRepositoryDbo, bool>> deleteFiles = null
        )
        {
            Result result = base.FileUpload(parentId, culture, userId, files, model, deleteFiles);
            CourseLessonDbo entity = _repository.GetEntity(parentId);
            if (entity != null)
            {
                entity.Type = CourseLessonType.COURSE_ITEM_POWER_POINT;
                _ = _repository.UpdateEntity(entity, userId);
            }
            return result;
        }
    }
}
