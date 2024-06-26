﻿using Core.Base.Repository.CodeBookRepository;
using EduServices.StudentGroup.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.StudentGroup;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.StudentGroup.Convertor
{
    public class StudentGroupConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IStudentGroupConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetCodeBookItems();

        public HashSet<StudentGroupInOrganizationListDto> ConvertToWebModel(HashSet<StudentGroupDbo> getStudentGroupInOrganizations, string culture)
        {
            return getStudentGroupInOrganizations.Select(x => new StudentGroupInOrganizationListDto() { Id = x.Id, Name = x.StudentGroupTranslations.FindTranslation(culture)?.Name, }).ToHashSet();
        }

        public StudentGroupDetailDto ConvertToWebModel(StudentGroupDbo getStudentGroupDetail, string culture)
        {
            return new StudentGroupDetailDto() { Id = getStudentGroupDetail.Id, Name = getStudentGroupDetail.StudentGroupTranslations.FindTranslation(culture)?.Name };
        }

        public StudentGroupDbo ConvertToBussinessEntity(StudentGroupCreateDto addStudentGroupDto, string culture)
        {
            StudentGroupDbo studentgroup = new() { OrganizationId = addStudentGroupDto.OrganizationId };
            studentgroup.StudentGroupTranslations = studentgroup.StudentGroupTranslations.PrepareTranslation(addStudentGroupDto.Name, culture, _cultureList);
            return studentgroup;
        }

        public StudentGroupDbo ConvertToBussinessEntity(StudentGroupUpdateDto updateStudentGroupDto, StudentGroupDbo entity, string culture)
        {
            entity.StudentGroupTranslations = entity.StudentGroupTranslations.PrepareTranslation(updateStudentGroupDto.Name, culture, _cultureList);
            return entity;
        }
    }
}
