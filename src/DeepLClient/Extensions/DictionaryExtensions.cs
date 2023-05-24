using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLClient.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Fetch a KeyValuePair by key
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static KeyValuePair<TKey, TValue> GetEntry<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
        }

        /// <summary>
        /// Fetch a KeyValuePair by entry
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string> GetKeyByEntry(this IDictionary<string, string> dictionary, string value)
        {
            var searchVal = value;

            if (dictionary.All(x => x.Value != value))
            {
                // is it a combined language?
                if (value.Contains("-"))
                {
                    // yep, try again without parenthesis by splitting the string
                    var split = value.Split('-').First().Trim();

                    // if found, set the search value to the split value, otherwise set it to "AUTO DETECT"
                    searchVal = dictionary.Any(x => x.Value == split) ? split : "AUTO DETECT";
                }
                else
                {
                    // nope, search for the first value in the dictionary that starts with the value
                    // if not found, set the search value to "AUTO DETECT"
                    searchVal = dictionary.FirstOrDefault(x => x.Value.StartsWith(value)).Value ?? "AUTO DETECT";
                }
            }

            // fetch the key by value
            var key = dictionary.FirstOrDefault(x => x.Value == searchVal).Key;

            // done
            return new KeyValuePair<string, string>(key, dictionary[key]);
        }
    }
}
