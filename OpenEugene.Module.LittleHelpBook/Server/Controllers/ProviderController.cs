using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Controllers;
using System.Net;
using OpenEugene.Module.LittleHelpBook.ViewModels;
using OpenEugene.Module.LittleHelpBook.Models;
using OpenEugene.Module.LittleHelpBook.Repository;


namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ProviderController : ModuleControllerBase
    {
        private readonly LittleHelpBookRepository _LittleHelpBookRepository;

        public ProviderController(LittleHelpBookRepository LittleHelpBookRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LittleHelpBookRepository = LittleHelpBookRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        public IEnumerable<Provider> Get()
        {
            try { 
                var list = _LittleHelpBookRepository.GetProviders();
                return list;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, ex, "Get Providers Failed");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
           
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Provider Get(int id)
        {
            Provider item = _LittleHelpBookRepository.GetProvider(id);
            return item;
        }

        // GET api/<controller>/5
        [HttpGet("vm/{id}")]
       // [Authorize(Policy = PolicyNames.ViewModule)]
        public ActionResult<ProviderViewModel> GetVM(int id)
        {
            var item = _LittleHelpBookRepository.GetProviderViewModel(id);
            if (item == null) { 
                return NotFound();
            }
            return Ok(item);
        }

        // GET api/<controller>/5
        [HttpGet("ProviderAttributes/{id}")]
        // [Authorize(Policy = PolicyNames.ViewModule)]
        public ActionResult<List<ProviderViewModel>> GetProviderAttributes(int id)
        {
            var item = _LittleHelpBookRepository.GetProviderAttributesByProviderId(id);
            return Ok(item);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Provider Post([FromBody] Provider item)
        {
            if (ModelState.IsValid )
            {
                item = _LittleHelpBookRepository.AddProvider(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Provider Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                item = null;
            }
            return item;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Provider Put(int id, [FromBody] Provider item)
        {
            if (ModelState.IsValid && _LittleHelpBookRepository.GetProvider(item.ProviderId, false) != null)
            {
                item = _LittleHelpBookRepository.UpdateProvider(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Provider Updated {item}",item);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Put Attempt {item}", item);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                item = null;
            }
            return item;
        }

        // PUT api/<controller>/5
        [HttpPut("vm/{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public ProviderViewModel PutVm(int id, [FromBody] ProviderViewModel item)
        {
            if (ModelState.IsValid)
            {
                item = _LittleHelpBookRepository.UpdateProvider(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Provider Updated {item}", item);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Put Attempt {item}", item);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                item = null;
            }
            return item;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Provider item = _LittleHelpBookRepository.GetProvider(id);
            if (item != null )
            {
                _LittleHelpBookRepository.DeleteProvider(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Provider Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public Address Post([FromBody] Address item)
        {
            if (ModelState.IsValid)
            {
                item = _LittleHelpBookRepository.AddAddress(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Address Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                item = null;
            }
            return item;
        } // POST api/<controller>
        [HttpPost("ProviderAttribute")]
        public ProviderAttribute Post([FromBody] ProviderAttribute item)
        {
            if (ModelState.IsValid)
            {
             
                item = _LittleHelpBookRepository.AddProviderAttribute(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "ProviderAttribute Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                item = null;
            }
            return item;
        }

        // DELETE api/<controller>/5
        [HttpDelete("ProviderAttribute/{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void DeleteProviderAttribute(int id)
        {
           var item = _LittleHelpBookRepository.GetProviderAttribute(id);
            if (item != null)
            {
                _LittleHelpBookRepository.DeleteProviderAttribute(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Provider Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
