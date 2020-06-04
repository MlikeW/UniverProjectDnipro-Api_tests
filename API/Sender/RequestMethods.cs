using CommonUtilities.Methods;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;

namespace API.Sender
{
    public static class RequestMethods
    {
        private static readonly string UserAgent = ConfigurationManager.AppSettings["UserAgent"];

        public static void AddHeader(this HttpWebRequest request, HttpRequestHeader header, string value)
            => request?.Headers.Add(header, value);

        public static void AddHeaders(this HttpWebRequest request, Dictionary<HttpRequestHeader, string> headers)
            => headers?.Keys.ToList().ForEach(key => request.AddHeader(key, headers[key]));

        public static object TryConvertToJContainer<T>(this string responseString)
        {
            try
            {
                return JToken.Parse(responseString).ToObject<T>();
            }
            catch
            {
                return responseString;
            }
        }

        public static byte[] ToBytes(this string bodyString)
            => Encoding.UTF8.GetBytes(bodyString);

        public static byte[] ToBytesByContentType(this object body,
            HttpWebRequest request, ContentTypes type)
            =>  type switch
            {
                ContentTypes.Bytes => (byte[]) body,
                { } => body.ToStringByContentType(request, type).ToBytes()
            };

        public static string ToStringByContentType(this object body,
            HttpWebRequest request, ContentTypes type)
        {
            var content = type switch
            {
                ContentTypes.Json => JToken.FromObject(body).ToString(),
                ContentTypes.Text => (string)body,
                _ => default
            };
            request.ApplyContentHeaders(type, content);
            return content;
        }

        public static void ApplyContentHeaders(this HttpWebRequest request, ContentTypes contentType, string content)
        {
            request.ContentType = contentType.GetEnumSinglePropertyValue<DescriptionAttribute>();
            request.ContentLength = content.Length;
        }

        public static void ApplyStandardHeaders(this HttpWebRequest request, ContentTypes acceptedContentType)
        {
            request.UserAgent = UserAgent;
            request.Accept = acceptedContentType.GetEnumSinglePropertyValue<DescriptionAttribute>();
        }

        public static object ConvertResponse<T>(this string responseString, ContentTypes acceptedType)
            => acceptedType switch
            {
                ContentTypes.Json => responseString.TryConvertToJContainer<T>(),
                ContentTypes.Bytes => responseString.ToBytes(),
                _ => responseString
            };
    }
}