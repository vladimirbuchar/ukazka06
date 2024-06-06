using EduServices.Route.Dto;
using Model.Tables.System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Route.Convertor
{
    public class RouteConvertor() : IRouteConvertor
    {

        public RouteDbo ConvertToBussinessEntity(RouteCreateDto addAnswerDto, string culture)
        {
            return new RouteDbo()
            {
                Route = addAnswerDto.Route
            };
        }

        public RouteDbo ConvertToBussinessEntity(RouteUpdateDto updateAnswerDto, RouteDbo entity, string culture)
        {
            entity.Route = updateAnswerDto.Route;
            return entity;
        }

        public HashSet<RouteListDto> ConvertToWebModel(HashSet<RouteDbo> getAnswersInQuestions, string culture)
        {
            return getAnswersInQuestions
                .Select(item => new RouteListDto()
                {
                    Id = item.Id,
                    Route = item.Route,
                })
                .ToHashSet();
        }

        public RouteDetailDto ConvertToWebModel(RouteDbo answerDetail, string culture)
        {
            return new RouteDetailDto()
            {
                Id = answerDetail.Id,
                Route = answerDetail.Route
            };
        }


    }
}
