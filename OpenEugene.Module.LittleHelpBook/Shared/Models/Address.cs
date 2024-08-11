using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OpenEugene.Module.LittleHelpBook.Models;

[Table("Address")]
public partial class Address : ModelBase
{
    [Key]
    public int AddressId { get; set; }

    public int ProviderId { get; set; }

    [StringLength(120)]
    public string Address1 { get; set; }

    [StringLength(120)]
    public string Address2 { get; set; }

    [StringLength(120)]
    public string Address3 { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(2)]
    public string State { get; set; }

    [StringLength(16)]
    public string PostalCode { get; set; }

    public bool HasWheelchairAccess { get; set; }

    public bool HasLanguageSupport { get; set; }

    [StringLength(64)]
    public string Geocoding { get; set; }

    public float? Longitude { get; set; }

    public float? Latitude { get; set; }

    [Required]
    public bool IsActive { get; set; }

   

}