using System;

namespace CommonUtilities.Methods.CustomAttributes
{
    public class EndpointUrlAttribute : Attribute
    {
        public string EndpointUrl { get; }

        public EndpointUrlAttribute(string endpointUrl)
        {
            EndpointUrl = endpointUrl;
        }
    }
}
