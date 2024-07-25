using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.Constants;
using Model.CodeBook;
using Services.CodeBookData.Convertor;
using Services.CodeBookData.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CodeBookData.Service
{
    public class CodeBookRepository(
        ICodeBookRepository<LicenseDbo> licenseCodebook,
        ICodeBookRepository<CourseTypeDbo> courseTypeCodebook,
        ICodeBookRepository<CourseStatusDbo> courseStatusCodebook,
        ICodeBookRepository<TimeTableDbo> timeTableCodebook,
        ICodeBookRepository<CountryDbo> countryCodebook,
        ICodeBookRepository<AddressTypeDbo> addressTypeCodebook,
        ICodeBookRepository<AnswerModeDbo> answerModeCodebook,
        ICodeBookRepository<CourseLessonItemTemplateDbo> courseLessonItemTemplateCodebook,
        ICodeBookRepository<CultureDbo> cultureCodebook,
        ICodeBookRepository<SendMessageTypeDbo> sendMessageTypeCodebook,
        ICodeBookRepository<QuestionModeDbo> questionModeCodebook,
        ICodeBookRepository<NoteTypeDbo> noteTypeCodebook,
        ICodeBookConvertor codeBookConvertor
    ) : BaseService<ICodeBookConvertor>(codeBookConvertor), ICodebookService
    {
        private readonly ICodeBookRepository<LicenseDbo> _licenseCodebook = licenseCodebook;
        private readonly ICodeBookRepository<CourseTypeDbo> _courseTypeCodebook = courseTypeCodebook;
        private readonly ICodeBookRepository<CourseStatusDbo> _courseStatusCodebook = courseStatusCodebook;
        private readonly ICodeBookRepository<TimeTableDbo> _timeTableCodebook = timeTableCodebook;
        private readonly ICodeBookRepository<CountryDbo> _countryCodebook = countryCodebook;
        private readonly ICodeBookRepository<AddressTypeDbo> _addressTypeCodebook = addressTypeCodebook;
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModeCodebook = answerModeCodebook;
        private readonly ICodeBookRepository<CourseLessonItemTemplateDbo> _courseLessonItemTemplateCodebook = courseLessonItemTemplateCodebook;
        private readonly ICodeBookRepository<CultureDbo> _cultureCodebook = cultureCodebook;
        private readonly ICodeBookRepository<SendMessageTypeDbo> _sendMessageTypeCodebook = sendMessageTypeCodebook;
        private readonly ICodeBookRepository<QuestionModeDbo> _questionModeCodebook = questionModeCodebook;
        private readonly ICodeBookRepository<NoteTypeDbo> _noteTypeCodebook = noteTypeCodebook;

        public async Task<List<CodeBookListDto>> GetCodeBookItems(string codeBookName, bool isLogged)
        {
            switch (codeBookName)
            {
                case CodebookValue.CB_LICENSE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _licenseCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<LicenseDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_COURSE_TYPE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _courseTypeCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<CourseTypeDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<CourseTypeDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_COURSE_STATUS:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _courseStatusCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<CourseStatusDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<CourseStatusDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_TIME_TABLE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _timeTableCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<TimeTableDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<TimeTableDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_COUNTRY:
                    {
                        return _convertor.ConvertToWebModel(await _countryCodebook.GetEntities(false, null, null,
                        [

                            new Core.Base.Sort.BaseSort<CountryDbo>()
                            {
                                Sort = x => x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<CountryDbo>()
                            {
                                Sort = x => x.Name,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            },

                        ]));
                    }
                case CodebookValue.CB_ADDRESS_TYPE:
                    {
                        return _convertor.ConvertToWebModel(await _addressTypeCodebook.GetEntities(false, null, null,
                            [
                            new Core.Base.Sort.BaseSort<AddressTypeDbo>()
                            {
                                Sort = x => x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                                new Core.Base.Sort.BaseSort<AddressTypeDbo>()
                                {
                                    Sort = x => x.Priority
                                }
                            ]
                            ));
                    }
                case CodebookValue.CB_ANSWER_MODE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _answerModeCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<AnswerModeDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<AnswerModeDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_COURSE_LESSON_ITEM_TEMPLATE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _courseLessonItemTemplateCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<CourseLessonItemTemplateDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection  = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<CourseLessonItemTemplateDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_ENV_CULTURE:
                    {
                        List<CultureDbo> data = await
                            _cultureCodebook.GetEntities(false, x => x.IsEnvironmentCulture, null,
                            [
                                new Core.Base.Sort.BaseSort<CultureDbo>()
                                {
                                    Sort = x => x.Priority
                                }
                            ]);


                        foreach (CultureDbo item in data)
                        {
                            if (item.SystemIdentificator == Constants.DEFAULT_CULTURE)
                            {
                                item.IsDefault = true;
                            }
                        }
                        data = data.OrderByDescending(x => x.IsDefault).ThenBy(x => x.Priority).ToList();
                        List<CodeBookListDto> culture = _convertor.ConvertToWebModel(data);
                        return culture;
                    }
                case CodebookValue.CB_CULTURE:
                    {
                        if (isLogged)
                        {
                            List<CultureDbo> data = await _cultureCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<CultureDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            },
                            new Core.Base.Sort.BaseSort<CultureDbo>()
                            {
                                Sort = x=>x.Value,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ]);
                            foreach (CultureDbo item in data)
                            {
                                item.Name = item.Value == CodebookValue.CODEBOOK_SELECT_VALUE
                                    ? string.Format("{0}", item.Value)
                                    : string.Format("{0} ({1})", item.Value, item.Name);
                            }
                            return _convertor.ConvertToWebModel(data);
                        }
                        return null;
                    }
                case CodebookValue.CB_SEND_MESSAGE_TYPE:
                    {
                        if (isLogged)
                        {
                            List<CodeBookListDto> sendmessagetype = _convertor.ConvertToWebModel(
                                await _sendMessageTypeCodebook.GetEntities(false, null, null,
                                [
                                    new Core.Base.Sort.BaseSort<SendMessageTypeDbo>()
                                    {
                                        Sort = x => x.Priority
                                    }
                                ])
                            );
                            foreach (CodeBookListDto item in sendmessagetype)
                            {
                                item.Disabled = item.SystemIdentificator == SendMessageType.SMS;
                            }
                            return sendmessagetype;
                        }
                        return null;
                    }
                case CodebookValue.CB_QUESTION_MODE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _questionModeCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<QuestionModeDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            }, new Core.Base.Sort.BaseSort<QuestionModeDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
                case CodebookValue.CB_NOTE_TYPE:
                    {
                        return isLogged ? _convertor.ConvertToWebModel(await _noteTypeCodebook.GetEntities(false, null, null,
                        [
                            new Core.Base.Sort.BaseSort<NoteTypeDbo>()
                            {
                                Sort = x=>x.IsDefault,
                                SortDirection = System.Web.Helpers.SortDirection.Descending
                            }, new Core.Base.Sort.BaseSort<NoteTypeDbo>()
                            {
                                Sort = x=>x.Priority,
                                SortDirection = System.Web.Helpers.SortDirection.Ascending
                            }
                        ])) : null;
                    }
            }
            return null;
        }
    }
}
