using System.Collections.Generic;
using System.Linq;

namespace CommonUtilities.Methods
{
    public static class DictionaryMethods
    {
        public static TValue IfKeyExists<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            => dictionary.ContainsKey(key) ? dictionary[key] : default;

        public static bool AreDictionariesEqual<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary1, 
            Dictionary<TKey, TValue> dictionary2)
            => dictionary1.Count == dictionary2.Count
               && dictionary1.Keys.All(key => dictionary2.IfKeyExists(key).Equals(dictionary1[key]));

        public static Dictionary<string, string> ToDictionary(this object obj)
            => obj.ToCustomDictionary<string>();

        public static Dictionary<string, T> ToCustomDictionary<T>(this object obj)
            => obj.GetType().GetProperties().ToDictionary(
                property => property.Name,
                property => (T)property.GetValue(obj, null)
            );

        public static Dictionary<TKey, TValue> AddDictionary<TKey, TValue>(
            this Dictionary<TKey, TValue> finalDictionary,
            Dictionary<TKey, TValue> dictionaryToAdd)
        {
            foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionaryToAdd)
            {
                finalDictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return finalDictionary;
        }

        public static Dictionary<TKey, TValue> AddPair<TKey, TValue>(
            this Dictionary<TKey, TValue> finalDictionary,
            TKey key, TValue value)
        {
            finalDictionary.Add(key, value);
            return finalDictionary;
        }
    }
}
