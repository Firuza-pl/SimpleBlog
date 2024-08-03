using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Blog.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TagStatus
    {
        [Description("Created")]
        Created = 1,

        [Description("Deleted")]
        Deleted = 0
    }
}
