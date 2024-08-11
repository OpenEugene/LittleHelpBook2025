using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OpenEugene.Module.LittleHelpBook.ViewModels;

public partial class ProviderAttributeViewModel : Models.ProviderAttribute
{
   public Models.Attribute Attribute { get; set; }
}