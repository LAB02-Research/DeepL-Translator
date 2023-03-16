namespace DeepLClient.Functions
{
    public static class Extensions
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
            var key = dictionary.FirstOrDefault(x => x.Value == value).Key;
            return new KeyValuePair<string, string>(key, dictionary[key]);
        }
    }
}
