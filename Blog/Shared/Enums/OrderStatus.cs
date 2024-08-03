using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Blog.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("Canceled")]
        Canceled=0
    }
}
