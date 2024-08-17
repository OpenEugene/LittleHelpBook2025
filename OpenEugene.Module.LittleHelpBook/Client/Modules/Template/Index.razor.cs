using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using Models = OpenEugene.Module.LittleHelpBook.Models;

using OpenEugene.Module.LittleHelpBook.Services;

namespace OpenEugene.Module.Template;

public partial class Index : ModuleBase
{
    List<Models.LittleHelpBook> _LittleHelpBooks;
		
    [Inject] public  LittleHelpBookService LittleHelpBookService { get; set; }
    [Inject] public  NavigationManager NavigationManager { get; set; }
    [Inject] public  IStringLocalizer<Index> Localizer { get; set; }
	
    public override List<Resource> Resources => new List<Resource>()
    {
        new Resource { ResourceType = ResourceType.Stylesheet,  Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
        new Resource { ResourceType = ResourceType.Stylesheet,  Url = "_content/MudBlazor/MudBlazor.min.css" },
        new Resource { ResourceType = ResourceType.Stylesheet,  Url = ModulePath() + "Module.css" },
        new Resource { ResourceType = ResourceType.Script,      Url = "_content/MudBlazor/MudBlazor.min.js" },
        new Resource { ResourceType = ResourceType.Script,      Url = ModulePath() + "Module.js" },
    };	
    private bool IsLoaded;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _LittleHelpBooks = await LittleHelpBookService.GetLittleHelpBooksAsync(ModuleState.ModuleId);
			
            IsLoaded = true;
        }
        catch (Exception ex)
        {
            await logger.LogError(ex, "Error Loading LittleHelpBook {Error}", ex.Message);
            AddModuleMessage(Localizer["Message.LoadError"], MessageType.Error);
        }
    }

    private async Task Delete(Models.LittleHelpBook LittleHelpBook)
    {
        try
        {
            await LittleHelpBookService.DeleteLittleHelpBookAsync(LittleHelpBook.LittleHelpBookId, ModuleState.ModuleId);
            await logger.LogInformation("LittleHelpBook Deleted {LittleHelpBook}", LittleHelpBook);
            _LittleHelpBooks = await LittleHelpBookService.GetLittleHelpBooksAsync(ModuleState.ModuleId);
            StateHasChanged();
        }
        catch (Exception ex)
        {
            await logger.LogError(ex, "Error Deleting LittleHelpBook {LittleHelpBook} {Error}", LittleHelpBook, ex.Message);
            AddModuleMessage(Localizer["Message.DeleteError"], MessageType.Error);
        }
    }
}

