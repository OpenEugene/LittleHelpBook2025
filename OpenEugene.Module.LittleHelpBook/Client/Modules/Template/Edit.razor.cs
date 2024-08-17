using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using OpenEugene.Module.LittleHelpBook.Services;
using Models = OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.Template
{
    public partial class Edit: ModuleBase
    {
		[Inject] public  ILittleHelpBookService LittleHelpBookService { get; set; }
		[Inject] public  NavigationManager NavigationManager { get; set; }
		[Inject] public IStringLocalizer<Edit> Localizer { get; set; }		

        private MudForm mudform;
        private bool success = false;
        private bool IsLoaded = false;
        private Models.LittleHelpBook LittleHelpBook { get; set; } = new();
        private int _LittleHelpBookId;

		public override SecurityAccessLevel SecurityAccessLevel => SecurityAccessLevel.Edit;

		public override string Actions => "Add,Edit";

		public override string Title => "Manage LittleHelpBook";

        public override List<Resource> Resources => new List<Resource>()
        {
            new Resource { ResourceType = ResourceType.Stylesheet,  Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
            new Resource { ResourceType = ResourceType.Stylesheet,  Url = "_content/MudBlazor/MudBlazor.min.css" },
            new Resource { ResourceType = ResourceType.Stylesheet,  Url = ModulePath() + "Module.css" },
            new Resource { ResourceType = ResourceType.Script,      Url = "_content/MudBlazor/MudBlazor.min.js" },
            new Resource { ResourceType = ResourceType.Script,      Url = ModulePath() + "Module.js" },
        };

        protected override async Task OnInitializedAsync()
	    {
		    try
		    {
			    if (PageState.Action == "Edit")
			    {
				    _LittleHelpBookId = Int32.Parse(PageState.QueryString["id"]);
				    LittleHelpBook = await LittleHelpBookService.GetLittleHelpBookAsync(_LittleHelpBookId, ModuleState.ModuleId);
			    }
                IsLoaded = true;
            }
		    catch (Exception ex)
		    {
			    await logger.LogError(ex, "Error Loading LittleHelpBook {LittleHelpBookId} {Error}", _LittleHelpBookId, ex.Message);
			    AddModuleMessage(Localizer["Message.LoadError"], MessageType.Error);
		    }
	    }

		private async Task Save()
		{
            try
            {
				await mudform.Validate();
				
                if (mudform.IsValid)
                {
                    if (PageState.Action == "Add")
                    {
                    LittleHelpBook.ModuleId = ModuleState.ModuleId;
                    LittleHelpBook = await LittleHelpBookService.AddLittleHelpBookAsync(LittleHelpBook);
                        await logger.LogInformation("LittleHelpBook Added {LittleHelpBook}", LittleHelpBook);
                    }
                    else
                    {
                    Models.LittleHelpBook LittleHelpBookLatest = await LittleHelpBookService.GetLittleHelpBookAsync(_LittleHelpBookId, ModuleState.ModuleId);
                    // update values from the local version of LittleHelpBook
                    LittleHelpBookLatest.Name = LittleHelpBook.Name;
                    // update Database with the latest version of LittleHelpBook
                    await LittleHelpBookService.UpdateLittleHelpBookAsync(LittleHelpBookLatest);
                    await logger.LogInformation("LittleHelpBook Updated {LittleHelpBookLatest}", LittleHelpBookLatest);
                }
                    NavigationManager.NavigateTo(NavigateUrl());
                }
                else
                {
                    AddModuleMessage(Localizer["Message.SaveValidation"], MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                await logger.LogError(ex, "Error Saving LittleHelpBook {Error}", ex.Message);
                AddModuleMessage(Localizer["Message.SaveError"], MessageType.Error);
            }
		}
	}
}
