﻿using Core.Base.Validator;
using EduRepository.AnswerRepository;
using EduServices.Answer.Dto;
using Model.Tables.Edu.Answer;

namespace EduServices.Answer.Validator
{
    public interface IAnswerValidator : IBaseValidator<AnswerDbo, IAnswerRepository, AnswerCreateDto, AnswerDetailDto, AnswerUpdateDto> { }
}
