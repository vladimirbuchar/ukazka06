using System.Collections.Generic;
using System.Linq;
using Model.System;
using Services.Route.Dto;

namespace Services.Route.Convertor
{
    public class RouteConvertor() : IRouteConvertor
    {
        public RouteDbo ConvertToBussinessEntity(RouteCreateDto addAnswerDto, string culture)
        {
            return new RouteDbo() { Route = addAnswerDto.Route };
        }

        public RouteDbo ConvertToBussinessEntity(RouteUpdateDto updateAnswerDto, RouteDbo entity, string culture)
        {
            entity.Route = updateAnswerDto.Route;
            return entity;
        }

        public List<RouteListDto> ConvertToWebModel(List<RouteDbo> getAnswersInQuestions, string culture)
        {
            return getAnswersInQuestions.Select(item => new RouteListDto() { Id = item.Id, Route = item.Route, }).ToList();
        }

        public RouteDetailDto ConvertToWebModel(RouteDbo answerDetail, string culture)
        {
            return new RouteDetailDto() { Id = answerDetail.Id, Route = answerDetail.Route };
        }
    }
}
