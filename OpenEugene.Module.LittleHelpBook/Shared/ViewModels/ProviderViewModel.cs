using System.Collections.Generic;
namespace OpenEugene.Module.LittleHelpBook.ViewModels;

public class ProviderViewModel : Models.Provider {
    public List<Models.Address> Addresses { get;set; } = new();
    public List<Models.PhoneNumber> PhoneNumbers { get;set; }=  new();
    public List<ProviderAttributeViewModel> ProviderAttributes { get; set; } = new();
    public ProviderViewModel() { }
    public ProviderViewModel(Models.Provider provider) { 
        ProviderId = provider.ProviderId;
        Name = provider.Name;
        Description = provider.Description;
        WebAddress = provider.WebAddress;
        EmailAddress = provider.EmailAddress;
        HoursOfOperation = provider.HoursOfOperation;
        IsActive = provider.IsActive;
        CreatedBy = provider.CreatedBy;
        CreatedOn = provider.CreatedOn;
        ModifiedBy = provider.ModifiedBy;
        ModifiedOn = provider.ModifiedOn;
    }
}

