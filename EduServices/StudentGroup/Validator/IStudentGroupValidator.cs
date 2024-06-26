﻿using Core.Base.Validator;
using EduRepository.StudentGroupRepository;
using EduServices.StudentGroup.Dto;
using Model.Tables.Edu.StudentGroup;

namespace EduServices.StudentGroup.Validator
{
    public interface IStudentGroupValidator : IBaseValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupCreateDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
