using System;
using System.Linq;
using CommonUtilities.Methods.CustomAttributes;
using Newtonsoft.Json.Linq;

namespace CommonUtilities.Methods
{
    public static class UrlMethods
    {
        public static string AddParametersToUrl(this string baseUrl, object parameters = null)
        {
            if (parameters == null || !parameters.IfPropertyWithAttributeExists<AddSingleParameterToUrlAttribute>())
            {
                return baseUrl;
            }

            var jObj = JObject.FromObject(parameters);
            var query = string.Join("&",
                jObj.Children().Cast<JProperty>()
                    .Where(jp => !string.IsNullOrEmpty(jp.Value.ToString()))
                    .Select(jp => $"{jp.Name}={jp.Value}"));
            parameters = null;
            return $"{baseUrl}?{query}";
        }
    }
}
