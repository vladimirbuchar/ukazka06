using Model.System;
using Services.Route.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Route.Convertor
{
    public class RouteConvertor() : IRouteConvertor
    {
        public Task<RouteDbo> ConvertToBussinessEntity(RouteCreateDto addAnswerDto, string culture)
        {
            return Task.FromResult(new RouteDbo() { Route = addAnswerDto.Route });
        }

        public Task<RouteDbo> ConvertToBussinessEntity(RouteUpdateDto updateAnswerDto, RouteDbo entity, string culture)
        {
            entity.Route = updateAnswerDto.Route;
            return Task.FromResult(entity);
        }

        public Task<List<RouteListDto>> ConvertToWebModel(List<RouteDbo> getAnswersInQuestions, string culture)
        {
            return Task.FromResult(getAnswersInQuestions.Select(item => new RouteListDto() { Id = item.Id, Route = item.Route, }).ToList());
        }

        public Task<RouteDetailDto> ConvertToWebModel(RouteDbo answerDetail, string culture)
        {
            return Task.FromResult(new RouteDetailDto() { Id = answerDetail.Id, Route = answerDetail.Route });
        }
    }
}
