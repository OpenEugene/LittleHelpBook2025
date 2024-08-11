using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OpenEugene.Module.LittleHelpBook.Repository;
using Oqtane.Controllers;
using System.Net;

namespace OpenEugene.Module.LittleHelpBook.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class LittleHelpBookController : ModuleControllerBase
    {
        private readonly ILittleHelpBookRepository _LittleHelpBookRepository;

        public LittleHelpBookController(ILittleHelpBookRepository LittleHelpBookRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LittleHelpBookRepository = LittleHelpBookRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.LittleHelpBook> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _LittleHelpBookRepository.GetLittleHelpBooks(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.LittleHelpBook Get(int id)
        {
            Models.LittleHelpBook LittleHelpBook = _LittleHelpBookRepository.GetLittleHelpBook(id);
            if (LittleHelpBook != null && IsAuthorizedEntityId(EntityNames.Module, LittleHelpBook.ModuleId))
            {
                return LittleHelpBook;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Get Attempt {LittleHelpBookId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LittleHelpBook Post([FromBody] Models.LittleHelpBook LittleHelpBook)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, LittleHelpBook.ModuleId))
            {
                LittleHelpBook = _LittleHelpBookRepository.AddLittleHelpBook(LittleHelpBook);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LittleHelpBook Added {LittleHelpBook}", LittleHelpBook);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Post Attempt {LittleHelpBook}", LittleHelpBook);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LittleHelpBook = null;
            }
            return LittleHelpBook;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LittleHelpBook Put(int id, [FromBody] Models.LittleHelpBook LittleHelpBook)
        {
            if (ModelState.IsValid && LittleHelpBook.LittleHelpBookId == id && IsAuthorizedEntityId(EntityNames.Module, LittleHelpBook.ModuleId) && _LittleHelpBookRepository.GetLittleHelpBook(LittleHelpBook.LittleHelpBookId, false) != null)
            {
                LittleHelpBook = _LittleHelpBookRepository.UpdateLittleHelpBook(LittleHelpBook);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LittleHelpBook Updated {LittleHelpBook}", LittleHelpBook);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Put Attempt {LittleHelpBook}", LittleHelpBook);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LittleHelpBook = null;
            }
            return LittleHelpBook;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.LittleHelpBook LittleHelpBook = _LittleHelpBookRepository.GetLittleHelpBook(id);
            if (LittleHelpBook != null && IsAuthorizedEntityId(EntityNames.Module, LittleHelpBook.ModuleId))
            {
                _LittleHelpBookRepository.DeleteLittleHelpBook(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LittleHelpBook Deleted {LittleHelpBookId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Delete Attempt {LittleHelpBookId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
