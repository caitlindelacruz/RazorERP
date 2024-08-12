using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace RazorERP.Application.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User = 2
    }
}
