﻿using Core.Extension;
using EduServices.Chat.Dto;
using Model.Tables.Edu.Chat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Chat.Convertor
{
    public class ChatConvertor : IChatConvertor
    {
        public ChatConvertor() { }

        public ChatDbo ConvertToBussinessEntity(ChatItemCreateDto addChatItemDto, string culture)
        {
            return new ChatDbo()
            {
                CourseTermId = addChatItemDto.CourseTermId,
                Text = addChatItemDto.Text,
                UserId = addChatItemDto.UserId
            };
        }

        public ChatDbo ConvertToBussinessEntity(ChatItemUpdateDto updateChatItemDto, ChatDbo entity, string culture)
        {
            entity.Text = updateChatItemDto.Text;
            return entity;
        }

        public HashSet<ChatItemListDto> ConvertToWebModel(HashSet<ChatDbo> getAllChatItems, string culture)
        {
            return getAllChatItems
                .Select(x => new ChatItemListDto()
                {
                    Id = x.Id,
                    Text = x.Text,
                    //ParentId = x.ChatId,
                    UserId = x.UserId,
                    IsAvatarUrl = !x.User.Person.AvatarUrl.IsNullOrEmptyWithTrim() && x.User.Person.AvatarUrl.IsValidUri(),
                    Avatar =
                        x.User.Person.AvatarUrl == null
                            ? string.Format("{0}{1}", x.User.Person.FirstName.FirstOrDefault(), x.User.Person.LastName.FirstOrDefault())
                            : x.User.Person.AvatarUrl.IsValidUri()
                                ? x.User.Person.AvatarUrl
                                : string.Format("{0}{1}", x.User.Person.FirstName.FirstOrDefault(), x.User.Person.LastName.FirstOrDefault()),
                    FirstName = x.User.Person.FirstName,
                    LastName = x.User.Person.LastName,
                    SecondName = x.User.Person.SecondName,
                    Date = x.Date,
                    /*IsAuthor = x.,
                    Answers = x.Answers.Select(y => new GetAllChatItemDto()
                    {
                        Id = y.Id,
                        Text = y.Text,
                        ParentId = y.ParentId,
                        UserId = y.UserId,
                        IsAvatarUrl = y.AvatarUrl.IsNullOrEmptyWithTrim() ? false : y.AvatarUrl.IsValidUri(),
                        Avatar = y.AvatarUrl == null ? string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault()) : (y.AvatarUrl.IsValidUri() ? y.AvatarUrl : string.Format("{0}{1}", y.FirstName.FirstOrDefault(), y.LastName.FirstOrDefault())),
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        SecondName = y.SecondName,
                        Date = y.Date,
                        IsAuthor = y.IsAuthor
    
                    }).ToHashSet()*/
                })
                .ToHashSet();
        }

        public ChatItemDetailDto ConvertToWebModel(ChatDbo detail, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
