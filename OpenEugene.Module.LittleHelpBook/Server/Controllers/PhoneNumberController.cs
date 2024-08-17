using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Controllers;
using System.Net;
using OpenEugene.Module.LittleHelpBook.Models;
using OpenEugene.Module.LittleHelpBook.Repository;

namespace OE.Module.LHB.Controllers;

[Route(ControllerRoutes.ApiRoute)]
public class PhoneNumberController : ModuleControllerBase
{
    private readonly LittleHelpBookRepository _LittleHelpBookRepository;

    public PhoneNumberController(LittleHelpBookRepository LittleHelpBookRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor) { _LittleHelpBookRepository = LittleHelpBookRepository; }

    // POST api/<controller>
    [HttpPost]
    public PhoneNumber Post([FromBody] PhoneNumber item)
    {
        if (ModelState.IsValid)
        {
            item = _LittleHelpBookRepository.AddPhoneNumber(item);
            _logger.Log(LogLevel.Information, this, LogFunction.Create, "PhoneNumber Added {item}", item);
        }
        else
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            item = null;
        }

        return item;
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var item = _LittleHelpBookRepository.GetPhoneNumberByPhoneNumberId(id);
        if (item != null)
        {
            _LittleHelpBookRepository.DeletePhoneNumber(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PhoneNumber Deleted {id}", id);
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad PhoneNumber Delete Attempt {id}", id);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}