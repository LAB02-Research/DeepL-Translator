namespace DeepLClient.Managers
{
    internal static class AccountManager
    {
        /// <summary>
        /// Calculate the projected cost of the translation
        /// <para>In case of a document, the configured minimim characters per document is used</para>
        /// </summary>
        /// <param name="characterCount"></param>
        /// <param name="isDocument"></param>
        /// <returns></returns>
        internal static string CalculateCost(double characterCount, bool isDocument = true)
        {
            if (characterCount == 0) return $"{0:C2}";

            if (isDocument && characterCount < Variables.AppSettings.MinimumCharactersPerDocument) characterCount = Variables.AppSettings.MinimumCharactersPerDocument;
            var price = characterCount * Variables.AppSettings.PricePerCharacter;

            var retval = $"{price:C2}";
            if (price < 0.01) retval = $"< {0.01:C2}";

            return retval;
        }
    }
}
