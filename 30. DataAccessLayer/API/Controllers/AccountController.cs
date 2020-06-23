﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using API.Exceptions;
using EmailLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.DAL.API.Database;
using MTS.DAL.API.Models;
using MTS.DataAcces.AccountAPI.Utils;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route(Constants.APIControllers.ACCOUNT)]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountController(
            IConfiguration configuration,
            UserManager<EFUserAccount> userManager,
            IEmailSender emailSender,
            ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _userManager = userManager;
            _emailSender = emailSender;
            _applicationDbContext = applicationDbContext;
        }

        // Account/getbyid
        [Authorize(Roles = 
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_ID)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetById([FromBody] string id)
        {
            return Ok((UserAccount)await _userManager.FindByIdAsync(id));
        }

        // Account/getbyemail
        [Authorize(Roles = 
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_EMAIL)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetByEmail([FromBody] string email)
        {
            return Ok((UserAccount)await _userManager.FindByEmailAsync(email));
        }

        [Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.GET_ALL)]
        [HttpGet]
        public async Task<ActionResult<string[]>> GetAll()
        {
            int count = await _applicationDbContext.UserAccounts.CountAsync();

            UserAccount[] userAccounts = new UserAccount[count];
            
            if (count < 10000)
            {
                int index = 0;
                foreach (var efAccount in _applicationDbContext.UserAccounts) 
                {
                    userAccounts[index] = new UserAccount();
                    PropertyCopier<EFUserAccount, UserAccount>.Copy(efAccount, userAccounts[index]);
                    index++;
                } 
            }
            else
            {
                // TODO rethink this
                //var result = _applicationDbContext.UserAccounts.AsParallel().WithDegreeOfParallelism(10).ToArray();
                //Parallel.For(0, count, async (i) => 
                //{
                //    userAccounts[i] = await EFUserAccount.ConvertFromAsync(result[i]);
                //});
            }

            return Ok(userAccounts);
        }

        // Account/createbycredentials
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS)]
        [HttpPut]
        public async Task<ActionResult> CreateByCredentials([FromBody] CredentialHolder credentialHolder)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                try
                {
                    var efUserAccount = new EFUserAccount
                    {
                        UserName = credentialHolder.Email,
                        Email = credentialHolder.Email
                    };

                    result = await _userManager.CreateAsync(efUserAccount, credentialHolder.Password);
                    if (result != null && result.Succeeded)
                    {
                        var callbackCode = await _userManager.GenerateEmailConfirmationTokenAsync(efUserAccount);
                        callbackCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(callbackCode));
                        var callbackUrl = $"{Constants.BLAZOR_WEB_BASE_ADDRESS}/account/confirmemail/{efUserAccount.Id}/{callbackCode}";

                        await _emailSender.SendEmailAsync(
                            efUserAccount.Email,
                            "Confirm your email",
                            $"Welcome to the Maurice Tech Community!\n" +
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        return new CreatedAtActionResult(
                            actionName: Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS,
                            controllerName: Constants.APIControllers.ACCOUNT,
                            routeValues: RouteData.Values,
                            value: efUserAccount.Id);
                    }
                    else
                    {
                        var errors = new string[result.Errors.Count()];
                        for (int i = 0; i < errors.Length; i++)
                        {
                            errors[i] = result.Errors.ElementAt(i).Description;
                        }

                        return StatusCode(500, errors);
                    }
                }
                catch (Exception ex)
                {
                    return await HandleException(ex);
                }
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        [Authorize(Roles =
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE + "," +
            Constants.Security.EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT)]
        [HttpPut]
        public async Task<ActionResult> CreateByAccount([FromBody] UserAccount userAccount)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                try
                {
                    var efUserAccount = new EFUserAccount();
                    PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

                    result = await _userManager.CreateAsync(efUserAccount, userAccount.PasswordHash);
                    if (result != null && result.Succeeded)
                    {
                        var callbackCode = await _userManager.GenerateEmailConfirmationTokenAsync(efUserAccount);
                        callbackCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(callbackCode));
                        var callbackUrl = $"{Constants.BLAZOR_WEB_BASE_ADDRESS}/account/confirmemail/{efUserAccount.Id}/{callbackCode}";

                        await _emailSender.SendEmailAsync(
                            efUserAccount.Email,
                            "Confirm your email",
                            $"Welcome to the Maurice Tech Community!\n" +
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        return new CreatedAtActionResult(
                            actionName: Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS,
                            controllerName: Constants.APIControllers.ACCOUNT,
                            routeValues: RouteData.Values,
                            value: efUserAccount.Id);
                    }
                    else
                    {
                        var errors = new string[result.Errors.Count()];
                        for (int i = 0; i < errors.Length; i++)
                        {
                            errors[i] = result.Errors.ElementAt(i).Description;
                        }

                        return StatusCode(500, errors);
                    }
                }
                catch (Exception ex)
                {
                    return await HandleException(ex);
                }
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        // Confirm email
        [Route(Constants.AccountControllerEndpoints.CONFIRM_EMAIL)]
        [HttpPut]
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailHolder confirmEmailHolder)
        {
            if (ModelState.IsValid)
            {
                var userAccount = await _userManager.FindByIdAsync(confirmEmailHolder.UserId);

                confirmEmailHolder.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmailHolder.Code));
                var result = await _userManager.ConfirmEmailAsync(userAccount, confirmEmailHolder.Code);

                return Ok(result.Succeeded ? "Succes! Thank you for confirming your email." : "Error confirming your email.");
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        // Delete
        [Authorize]
        [Route(Constants.AccountControllerEndpoints.DELETE_BY_ID)]
        [HttpDelete]
        public async Task<ActionResult> DeleteById([FromBody] string id)
        {
            if (ModelState.IsValid)
            {
                var efUserAccount = await _userManager.FindByIdAsync(id);

                var result = await _userManager.DeleteAsync(efUserAccount);

                return Ok(result.Succeeded ? "Succes! Your account has been deleted" : "Error deleting your account");
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        private async Task<ActionResult> HandleException(Exception ex)
        {
            //LogWriter logWriter = new LogWriter(_configuration.GetValue<string>(WebHostDefaults.ContentRootKey));
//            if (await logWriter.WriteLineAsync(Assembly.GetCallingAssembly().GetName().Name, ex))
//            {
//#if DEBUG
//                return StatusCode(500, new APIException("Exception caught and logged.", ex));
//#else
//                                    return StatusCode(500, new APIException());
//#endif
//            }
//            else
//            {
//#if DEBUG
//                return StatusCode(500, new APIException("Exception caught but writing to the log failed. See API trace for more details.", ex));
//#else
//                                    return StatusCode(500, new APIException());
//#endif
//            }
            return BadRequest(ex.Message);
        }
    }
}
