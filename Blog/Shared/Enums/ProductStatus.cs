using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Blog.Shared.Enums
{
    //how enum should be serialized to JSON, represent enum values as string instead of integer
    //typeof instance of Type class, that represent the type that we are interested in. mostly used with metadata,reflectin, or jsonconverter
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductStatus
    {
        [Description("Created")]
        Created = 1,

        [Description("Deleted")]
        Deleted = 0

    }
}
