using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace CommonLibrary.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Gender
{
    M,
    F,
    O,
}
