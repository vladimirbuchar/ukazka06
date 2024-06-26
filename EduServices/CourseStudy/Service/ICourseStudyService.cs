﻿using System;
using System.Collections.Generic;
using Core.Base.Service;
using Core.DataTypes;
using EduServices.CourseStudy.Dto;
using EduServices.OrganizationRole.Dto;

namespace EduServices.CourseStudy.Service
{
    public interface ICourseStudyService : IBaseService
    {
        void SaveActiveSlide(Guid slideId, Guid userId, Guid courseId);
        void ResetCourse(Guid studentTermId);
        HashSet<CourseMenuItemDto> GetCourseMenu(Guid courseId, Guid userId, string culture);
        HashSet<SlideIdListDto> GetAllSlideId(Guid courseId, Guid userId, string culture);
        UserOrganizationRoleDetailDto CanCourseBrowse(Guid courseId, Guid userId);
        CourseLessonStudyDto CourseMaterialBrowse(Guid courseId, Guid userId, string culture);
        CourseLessonStudyDto GoToSlide(Guid slideId, Guid userId, Guid courseId, string culture);
        Guid StartTest(Guid courseLessonId, Guid userId, Guid courseId);
        EvaluateTestDto EvaluateTest(Guid userTestSummaryId, List<EvaluateQuestionDto> evaluateTestDtos, Guid courseLessonId);
        HashSet<ShowTestResultQuestionDto> ShowTestResult(Guid userTesId);
        UserOrganizationRoleDetailDto CanShowStudentTestResult(Guid courseId, Guid userId);
        HashSet<StudentTestListDto> GetStudentTest(Guid userId, string culture);
        FinishCourseDto FinishCourse(Guid userId, Guid courseStudentId, Guid courseId, Guid organizationId, string culture);
        void UpdateActualTable(ActualTableUpdateDto updateActualTableDto);
        Result<string> GetActualTable(Guid courseTermid);

        HashSet<StudentTestResultListDto> GetAllStudentTestResult(Guid couseId, string culture);
        ShowTestResultDto ShowStudentAnswer(Guid studentTestResultId);
        void SetLectorControl(SetLectorControlDto setLectorControlDto);
    }
}
