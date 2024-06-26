﻿using Core.Base.Convertor;
using EduServices.StudentGroup.Dto;
using Model.Tables.Edu.StudentGroup;

namespace EduServices.StudentGroup.Convertor
{
    public interface IStudentGroupConvertor : IBaseConvertor<StudentGroupDbo, StudentGroupCreateDto, StudentGroupInOrganizationListDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
