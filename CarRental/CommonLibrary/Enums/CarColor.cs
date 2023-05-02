using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CarRental.Common.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CarColor
{
    Black,
    White,
    Red,
    Blue,
    Green,
    Yellow,
    Orange,
    Purple,
    Brown,
    Gray,
    [EnumMember(Value = "Polymetal Gray Metallic")]
    [Display(Name = "Polymetal Gray Metallic")]
    PolymetalGrayMetallic,
    Silver,
    Gold,
    Beige,
    [EnumMember(Value = "Pearl white")]
    [Display(Name = "Pearl white")]
    PearlWhite,
    Other
}
