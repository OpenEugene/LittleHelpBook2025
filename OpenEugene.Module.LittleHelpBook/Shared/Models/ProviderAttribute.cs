using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OpenEugene.Module.LittleHelpBook.Models;

[Table("ProviderAttribute")]
public partial class ProviderAttribute : ModelBase
{
    [Key]
    public int ProviderAttributeId { get; set; }

    public int ProviderId { get; set; }

    public int AttributeId { get; set; }


}