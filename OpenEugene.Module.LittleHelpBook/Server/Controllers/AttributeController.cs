using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Controllers;
using System.Net;

using Oqtane.Models;
using OpenEugene.Module.LittleHelpBook.Models;
using OpenEugene.Module.LittleHelpBook.Repository;

namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class AttributeController : ModuleControllerBase
    {
        private readonly LittleHelpBookRepository _LittleHelpBookRepository;

        public AttributeController(LittleHelpBookRepository LittleHelpBookRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LittleHelpBookRepository = LittleHelpBookRepository;
        }


        // GET: api/<controller>?moduleid=x
        [HttpGet]
        public IEnumerable<Attribute> Get()
        {
            try
            {
                var list = _LittleHelpBookRepository.GetAttributes();
                return list;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, ex, "Get Attributes Failed");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }

        }

    }
}
