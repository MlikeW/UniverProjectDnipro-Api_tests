using System.ComponentModel;

namespace API.Sender
{
    public enum ContentTypes
    {
        [Description("application/json")]
        Json,
        [Description("application/octet-stream")]
        Bytes,
        [Description("text/plain; charset=UTF-8")]
        Text
    }
}