using CodebookService.AddressTypeDropDown.Command;
using CodebookService.AnswerModeDropDown.Command;
using CodebookService.CountryDropDown.Command;
using CodebookService.CourseLessonItemTemplateDropDown.Command;
using CodebookService.CourseStatusDropDown.Command;
using CodebookService.CourseTypeDropDown.Command;
using CodebookService.CultureDropDown.Command;
using CodebookService.CultureDropDown.Dto;
using CodebookService.EmailTypeDropDown.Command;
using CodebookService.LicenseDropDown.Command;
using CodebookService.LicenseDropDown.Dto;
using CodebookService.NoteTypeDropDown.Command;
using CodebookService.QuestionModeDropDown.Command;
using CodebookService.SendMessageTypeDropDown.Command;
using CodebookService.TimeTableDropDown.Command;
using Core.Base.Controller;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CodeBook
{
    [ApiExplorerSettings(GroupName = "Codebook")]
    public class CodeBookController : BaseClientZoneController
    {
        private readonly ILicenseDropDownService _licenseDropDownService;
        private readonly ICourseTypeDropDownService _courseTypeDropDownService;
        private readonly ICourseStatusDropDownService _courseStatusDropDownService;
        private readonly ITimeTableDropDownService _timeTableDropDownService;
        private readonly ICountryDropDownService _countryDropDownService;
        private readonly IAnswerModeDropDownService _answerModeDropDownService;
        private readonly IAddressTypeDropDownService _addressTypeDropDownService;
        private readonly ICourseLessonItemTemplateDropDownService _courseLessonItemTemplateDropDownService;
        private readonly ICultureDropDownService _cultureDropDownService;
        private readonly ISendMessageTypeDropDownService _sendMessageTypeDropDownService;
        private readonly IQuestionModeDropDownService _questionModeDropDownService;
        private readonly INoteTypeDropDownService _noteTypeDropDownService;
        private readonly IEmailTypeDropDownService _emailTypeDropDownService;
        public CodeBookController(
            ILogger<CodeBookController> logger,
            EduDbContext organizationRoleService,
            ILicenseDropDownService licenseDropDownService,
            ICourseTypeDropDownService courseTypeDropDownService,
            ICourseStatusDropDownService courseStatusDropDownService,
            ITimeTableDropDownService timeTableDropDownService,
            ICountryDropDownService countryDropDownService,
            IAnswerModeDropDownService answerModeDropDownService,
            IAddressTypeDropDownService addressTypeDropDownService,
            ICourseLessonItemTemplateDropDownService courseLessonItemTemplateDropDownService,
            ICultureDropDownService cultureDropDownService,
            ISendMessageTypeDropDownService sendMessageTypeDropDownService,
            IQuestionModeDropDownService questionModeDropDownService,
            INoteTypeDropDownService noteTypeDropDownService,
            IEmailTypeDropDownService emailTypeDropDownService
        )
            : base(logger, organizationRoleService)
        {
            _licenseDropDownService = licenseDropDownService;
            _courseTypeDropDownService = courseTypeDropDownService;
            _courseStatusDropDownService = courseStatusDropDownService;
            _timeTableDropDownService = timeTableDropDownService;
            _countryDropDownService = countryDropDownService;
            _answerModeDropDownService = answerModeDropDownService;
            _addressTypeDropDownService = addressTypeDropDownService;
            _courseLessonItemTemplateDropDownService = courseLessonItemTemplateDropDownService;
            _cultureDropDownService = cultureDropDownService;
            _sendMessageTypeDropDownService = sendMessageTypeDropDownService;
            _questionModeDropDownService = questionModeDropDownService;
            _noteTypeDropDownService = noteTypeDropDownService;
            _emailTypeDropDownService = emailTypeDropDownService;
        }

        [HttpGet("{codeBookName}")]
        [ProducesResponseType(typeof(IEnumerable<LicenseDropDownDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> DropDown(string codeBookName)
        {
            try
            {
                switch (codeBookName)
                {
                    case CodebookValue.CB_LICENSE:
                        {
                            return await SendResponse(await _licenseDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<LicenseDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<LicenseDbo>()
                                {
                                    Sort = x =>x.Priority,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending,
                                }
                            }));

                        }
                    case CodebookValue.CB_COURSE_TYPE:
                        {
                            return await SendResponse(await _courseTypeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CourseTypeDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<CourseTypeDbo>()
                                {
                                    Sort = x=>x.IsDefault,
                                    SortDirection = System.Web.Helpers.SortDirection.Descending
                                },
                                new Core.Base.Sort.BaseSort<CourseTypeDbo>()
                                {
                                    Sort = x => x.Priority,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }
                            }));

                        }
                    case CodebookValue.CB_COURSE_STATUS:
                        {
                            return await SendResponse(await _courseStatusDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CourseStatusDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<CourseStatusDbo>()
                                {
                                    Sort = x=> x.IsDefault,
                                    SortDirection = System.Web.Helpers.SortDirection.Descending
                                }, new Core.Base.Sort.BaseSort<CourseStatusDbo>()
                                {
                                    Sort = x=>x.Priority,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }
                            }));

                        }
                    case CodebookValue.CB_TIME_TABLE:
                        {

                            return await SendResponse(await _timeTableDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<TimeTableDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<TimeTableDbo>()
                                {
                                     Sort = x => x.IsDefault,
                                        SortDirection = System.Web.Helpers.SortDirection.Descending
                                },
                                new Core.Base.Sort.BaseSort<TimeTableDbo>()
                                {
                                    Sort = x => x.Priority,
                                        SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }
                            }));
                        }
                    case CodebookValue.CB_COUNTRY:
                        {
                            return await SendResponse(await _countryDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CountryDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<CountryDbo>()
                                {
                                    Sort = x => x.IsDefault,
                                    SortDirection = System.Web.Helpers.SortDirection.Descending
                                },
                                new Core.Base.Sort.BaseSort<CountryDbo>()
                                {
                                    Sort = x => x.Priority,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                },
                                new Core.Base.Sort.BaseSort<CountryDbo>()
                                {
                                    Sort = x => x.Name,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }

                            }));
                        }
                    case CodebookValue.CB_ADDRESS_TYPE:
                        {

                            return await SendResponse(await _addressTypeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<AddressTypeDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<AddressTypeDbo>()
                                {
                                    Sort = x => x.IsDefault,
                                    SortDirection = System.Web.Helpers.SortDirection.Descending
                                },
                                new Core.Base.Sort.BaseSort<AddressTypeDbo>() { Sort = x => x.Priority }
                            }));
                        }
                    case CodebookValue.CB_ANSWER_MODE:
                        {
                            return await SendResponse(await _answerModeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<AnswerModeDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<AnswerModeDbo>()
                                    {
                                        Sort = x => x.IsDefault,
                                        SortDirection = System.Web.Helpers.SortDirection.Descending
                                    },
                                    new Core.Base.Sort.BaseSort<AnswerModeDbo>()
                                    {
                                        Sort = x => x.Priority,
                                        SortDirection = System.Web.Helpers.SortDirection.Ascending
                                    }
                            }));

                        }
                    case CodebookValue.CB_COURSE_LESSON_ITEM_TEMPLATE:
                        {
                            return await SendResponse(await _courseLessonItemTemplateDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CourseLessonItemTemplateDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<CourseLessonItemTemplateDbo>()
                                {
                                    Sort = x => x.IsDefault,
                                    SortDirection = System.Web.Helpers.SortDirection.Descending
                                },
                                new Core.Base.Sort.BaseSort<CourseLessonItemTemplateDbo>()
                                {
                                    Sort = x => x.Priority,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }
                            }));
                        }
                    case CodebookValue.CB_ENV_CULTURE:
                        {
                            List<CultureDropDownDto> data = await _cultureDropDownService.Execute(x => x.IsEnvironmentCulture, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CultureDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<CultureDbo>() { Sort = x => x.Priority }
                            });

                            foreach (CultureDropDownDto item in data)
                            {
                                if (item.SystemIdentificator == Constants.DEFAULT_CULTURE)
                                {
                                    item.IsDefault = true;
                                }
                            }
                            data = data.OrderByDescending(x => x.IsDefault).ThenBy(x => x.Priority).ToList();
                            return await SendResponse(data);
                        }
                    case CodebookValue.CB_CULTURE:
                        {
                            return await SendResponse(await _cultureDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<CultureDbo>>()
                            {

                                       new Core.Base.Sort.BaseSort<CultureDbo>()
                                       {
                                           Sort = x => x.IsDefault,
                                           SortDirection = System.Web.Helpers.SortDirection.Descending
                                       },
                                new Core.Base.Sort.BaseSort<CultureDbo>()
                                {
                                    Sort = x => x.Value,
                                    SortDirection = System.Web.Helpers.SortDirection.Ascending
                                }}));
                        }
                    case CodebookValue.CB_SEND_MESSAGE_TYPE:
                        {
                            return await SendResponse(await _sendMessageTypeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<MessageTemplateTypeDbo>>()
                            {
                                new Core.Base.Sort.BaseSort<MessageTemplateTypeDbo>() { Sort = x => x.Priority }
                            }));
                        }
                    case CodebookValue.CB_QUESTION_MODE:
                        {
                            return await SendResponse(await _questionModeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<QuestionModeDbo>>()
                            {
                                       new Core.Base.Sort.BaseSort<QuestionModeDbo>()
                                    {
                                        Sort = x => x.IsDefault,
                                        SortDirection = System.Web.Helpers.SortDirection.Descending
                                    },
                                    new Core.Base.Sort.BaseSort<QuestionModeDbo>()
                                    {
                                        Sort = x => x.Priority,
                                        SortDirection = System.Web.Helpers.SortDirection.Ascending
                                    }
                            }));

                        }
                    case CodebookValue.CB_NOTE_TYPE:
                        {
                            return await SendResponse(await _noteTypeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<NoteTypeDbo>>()
                            {
                                             new Core.Base.Sort.BaseSort<NoteTypeDbo>()
                                    {
                                        Sort = x => x.IsDefault,
                                        SortDirection = System.Web.Helpers.SortDirection.Descending
                                    },
                                    new Core.Base.Sort.BaseSort<NoteTypeDbo>()
                                    {
                                        Sort = x => x.Priority,
                                        SortDirection = System.Web.Helpers.SortDirection.Ascending
                                    }

                            }));
                        }
                    case CodebookValue.CB_EMAIL_TYPE:
                        {
                            return await SendResponse(await _emailTypeDropDownService.Execute(null, false, new List<string>() { GetClientCulture() }, new List<Core.Base.Sort.BaseSort<EmailTypeDbo>>()
                            {
                                 new Core.Base.Sort.BaseSort<EmailTypeDbo>()
                                    {
                                        Sort = x => x.IsDefault,
                                        SortDirection = System.Web.Helpers.SortDirection.Descending
                                    },
                                    new Core.Base.Sort.BaseSort<EmailTypeDbo>()
                                    {
                                        Sort = x => x.Priority,
                                        SortDirection = System.Web.Helpers.SortDirection.Ascending
                                    }
                            }));
                        }
                }
                return await SendResponse(null);
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
