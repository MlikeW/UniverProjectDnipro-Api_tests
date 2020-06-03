using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CommonUtilities.Methods.CustomAttributes;

namespace CommonUtilities.Methods
{
    public static class EnumMethods
    {
        public static T[] GetFieldAttributes<T>(this FieldInfo field)
            => (T[]) Convert.ChangeType(field.GetCustomAttributes(typeof(T), false), typeof(T[]));

        public static T GetFieldAttribute<T>(this FieldInfo field)
            => (T) Convert.ChangeType(field.GetCustomAttributes(typeof(T), false).First(), typeof(T));

        public static IEnumerable<string> GetEnumPropertyValues<T>(this Enum value)
            => value.GetType()
                .GetField(value.ToString())
                .GetFieldAttributes<T>()
                .Select(
                    field => field.GetType()
                        .GetProperties().First()
                        .GetValue(field).ToString());

        public static string GetEnumSinglePropertyValue<T>(this Enum value)
            => value.GetEnumPropertyValues<T>().First();

        public static string GetEnumValueByDescription<T>(this string description)
            => typeof(T)
                .GetFields()
                .First(field => field
                    .GetFieldAttributes<DescriptionAttribute>()
                    .Any(attribute => attribute
                        .Description.Equals(description)))
                .GetValue(null)
                .ToString();

        public static bool IfPropertyWithAttributeExists<T>(this object obj)
            => obj.GetType().GetProperties().Any(pr => pr.GetCustomAttribute(typeof(AddSingleParameterToUrlAttribute)) != null);

        public static T GetEnumByDescription<T>(this string description)
            => description.GetEnumValueByDescription<T>().ParseEnum<T>();

        public static T ParseEnum<T>(this string value)
        {
            try
            {
                return (T) Enum.Parse(typeof(T), value);
            }
            catch
            {
                throw new NotImplementedException($"Cannot find '{value}' field in enum '{typeof(T).Name}'.");
            }
        }
    }
}
