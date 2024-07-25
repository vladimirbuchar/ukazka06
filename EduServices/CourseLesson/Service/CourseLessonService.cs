using Core.Base.Filter;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Repository.CourseLessonRepository;
using Repository.CourseMaterialRepository;
using Services.CourseLesson.Convertor;
using Services.CourseLesson.Dto;
using Services.CourseLesson.Validator;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.CourseLesson.Service
{
    public class CourseLessonService(
        ICourseLessonRepository courseLessonRepository,
        ICourseLessonConvertor convertor,
        ICourseLessonValidator validator,
        IFileUploadRepository<CourseLessonFileRepositoryDbo> repository,
        ICodeBookRepository<CultureDbo> culture,
        ICourseMaterialRepository courseMaterialRepository
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
            CourseLessonFileRepositoryDbo,
            FilterRequest
        >(courseLessonRepository, convertor, validator, repository, culture),
            ICourseLessonService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;
        public async Task<Result> UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId)
        {
            int position = 0;
            foreach (string item in updatePositionCourseLesson.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonDbo entity = await _repository.GetEntity(id);
                if (entity != null)
                {
                    entity.Position = position;
                    _ = await _repository.UpdateEntity(entity, userId);
                    position++;
                }
            }
            return new Result();
        }

        public override async Task<Result> FileUpload(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            CourseLessonFileRepositoryDbo model,
            Expression<Func<CourseLessonFileRepositoryDbo, bool>> deleteFiles = null
        )
        {
            Result result = await base.FileUpload(parentId, culture, userId, files, model, deleteFiles);
            CourseLessonDbo entity = await _repository.GetEntity(parentId);
            if (entity != null)
            {
                entity.Type = CourseLessonType.COURSE_ITEM_POWER_POINT;
                _ = await _repository.UpdateEntity(entity, userId);
            }
            return result;
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseMaterialRepository.GetOrganizationId(objectId);
        }
    }
}
