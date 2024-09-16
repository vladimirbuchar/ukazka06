using CodebookService.AddressTypeDropDown.Command;
using CodebookService.CountryDropDown.Command;
using CodebookService.CultureDropDown.Command;
using CodebookService.CultureDropDown.Dto;
using CodebookService.LicenseDropDown.Dto;
using Core.Base.Controller;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicApi.Controllers.CodeBook
{
    public class CodeBookController : BaseWebController
    {
        private readonly ICountryDropDownService _countryDropDownService;
        private readonly ICultureDropDownService _cultureDropDownService;
        private readonly IAddressTypeDropDownService _addressTypeDropDownService;
        public CodeBookController(ILogger<CodeBookController> logger, ICountryDropDownService countryDropDownService, ICultureDropDownService cultureDropDownService, IAddressTypeDropDownService addressTypeDropDownService)
            : base(logger)
        {
            _countryDropDownService = countryDropDownService;
            _cultureDropDownService = cultureDropDownService;
            _addressTypeDropDownService = addressTypeDropDownService;
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
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
