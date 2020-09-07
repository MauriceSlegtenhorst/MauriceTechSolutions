﻿using Microsoft.AspNetCore.Mvc;
using MTS.BL.Infra.Interfaces.Standard.Credit;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.Core.GlobalLibrary;
using MTS.DAL.API.Utils.ExceptionHandler;
using MTS.PL.Infra.Entities.Standard.Credit;
using MTS.PL.Infra.Interfaces.Standard.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.API.Controllers
{
    [ApiController]
    [Route(Constants.APIControllers.CREDITS)]
    public sealed class CreditController : ControllerBase
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ICreditAdapter _creditAdapter;
        public CreditController(
            IExceptionHandler exceptionHandler, 
            ICreditAdapter creditAdapter)
        {
            _exceptionHandler = exceptionHandler;
            _creditAdapter = creditAdapter;
        }

        #region Create

        #endregion

        #region Read
        [Route(Constants.CreditControllerEndPoints.READ_ALL_CREDIT_CATEGORY)]
        [HttpGet]
        public async Task<IActionResult> ReadAllCreditCategoryAsync()
        {
            ICollection<IBLCreditCategory> blCategories = await _creditAdapter.ReadAllAsync();

            ICollection<PLCreditCategory> plCreditCategories = new List<PLCreditCategory>();

            foreach (IBLCreditCategory blCategory in blCategories)
            {
                ICollection<PLCredit> plCredits = new List<PLCredit>();

                foreach (IBLCredit blCredit in blCategory.Credits)
                {
                    plCredits.Add
                        (
                            new PLCredit
                            {
                                Title = blCredit.Title,
                                SubTitle = blCredit.SubTitle,
                                Description = blCredit.Description,
                                GotFrom = blCredit.GotFrom,
                                GotFromWebsite = blCredit.GotFromWebsite,
                                MadeBy = blCredit.MadeBy,
                                MadeByWebsite = blCredit.MadeByWebsite,
                                LinkToImage = blCredit.LinkToImage,
                            }
                        );
                }

                plCreditCategories.Add
                    (
                        new PLCreditCategory
                        {
                            Title = blCategory.Title,
                            SubTitle = blCategory.SubTitle,
                            Description = blCategory.Description,
                            PLCredits = plCredits
                        }
                    );
            }

            return Ok(plCreditCategories);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}