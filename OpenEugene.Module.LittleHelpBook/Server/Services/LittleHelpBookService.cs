using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Security;
using Oqtane.Shared;
using OpenEugene.Module.LittleHelpBook.Repository;

namespace OpenEugene.Module.LittleHelpBook.Services
{
    public class ServerLittleHelpBookService : ILittleHelpBookService, ITransientService
    {
        private readonly ILittleHelpBookRepository _LittleHelpBookRepository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerLittleHelpBookService(ILittleHelpBookRepository LittleHelpBookRepository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _LittleHelpBookRepository = LittleHelpBookRepository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public async Task<List<Models.LittleHelpBook>> GetLittleHelpBooksAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return (await _LittleHelpBookRepository.GetLittleHelpBooksAsync(ModuleId)).ToList();
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public async Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return await _LittleHelpBookRepository.GetLittleHelpBookAsync(LittleHelpBookId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Get Attempt {LittleHelpBookId} {ModuleId}", LittleHelpBookId, ModuleId);
                return null;
            }
        }

        public async Task<Models.LittleHelpBook> AddLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, LittleHelpBook.ModuleId, PermissionNames.Edit))
            {
                LittleHelpBook = await _LittleHelpBookRepository.AddLittleHelpBookAsync(LittleHelpBook);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LittleHelpBook Added {LittleHelpBook}", LittleHelpBook);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Add Attempt {LittleHelpBook}", LittleHelpBook);
                LittleHelpBook = null;
            }
            return LittleHelpBook;
        }

        public async Task<Models.LittleHelpBook> UpdateLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, LittleHelpBook.ModuleId, PermissionNames.Edit))
            {
                LittleHelpBook = await _LittleHelpBookRepository.UpdateLittleHelpBookAsync(LittleHelpBook);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LittleHelpBook Updated {LittleHelpBook}", LittleHelpBook);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Update Attempt {LittleHelpBook}", LittleHelpBook);
                LittleHelpBook = null;
            }
            return LittleHelpBook;
        }

        public async Task DeleteLittleHelpBookAsync(int LittleHelpBookId, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                await _LittleHelpBookRepository.DeleteLittleHelpBookAsync(LittleHelpBookId);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LittleHelpBook Deleted {LittleHelpBookId}", LittleHelpBookId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LittleHelpBook Delete Attempt {LittleHelpBookId} {ModuleId}", LittleHelpBookId, ModuleId);
            }
        }
    }
}
