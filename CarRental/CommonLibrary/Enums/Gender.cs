using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CommonLibrary.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Gender
{
    [EnumMember(Value = "M")]
    Male,

    [EnumMember(Value = "F")]
    Female,

    [EnumMember(Value = "O")]
    Other,
}
