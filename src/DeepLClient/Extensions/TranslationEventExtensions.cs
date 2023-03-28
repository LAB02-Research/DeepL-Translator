using DeepLClient.Models;
using DeepLClient.Enums;
using DeepLClient.Managers;

namespace DeepLClient.Extensions
{
    public static class TranslationEventExtensions
    {
        /// <summary>
        /// Sets the translation event to a 'text' translation
        /// </summary>
        /// <param name="translationEvent"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static TranslationEvent SetTextEvent(this TranslationEvent translationEvent, double characters)
        {
            return SetEvent(translationEvent, TranslationEventType.Text, characters);
        }

        /// <summary>
        /// Sets the translation event to a 'document' translation
        /// </summary>
        /// <param name="translationEvent"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static TranslationEvent SetDocumentEvent(this TranslationEvent translationEvent, double characters)
        {
            return SetEvent(translationEvent, TranslationEventType.Document, characters);
        }

        /// <summary>
        /// Sets the translation event to a 'webpag' translation
        /// </summary>
        /// <param name="translationEvent"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static TranslationEvent SetWebpageEvent(this TranslationEvent translationEvent, double characters)
        {
            return SetEvent(translationEvent, TranslationEventType.Webpage, characters);
        }

        private static TranslationEvent SetEvent(TranslationEvent translationEvent, TranslationEventType type, double characters)
        {
            var user = string.IsNullOrEmpty(Variables.AppSettings.User)
                ? Environment.UserName
                : Variables.AppSettings.User;

            var (apiSection, apiHash) = SubscriptionManager.GetAnonymisedApiKey();

            translationEvent.Name = user;
            translationEvent.MomentUtc = DateTime.UtcNow;
            translationEvent.Type = type;
            translationEvent.Characters = characters;
            translationEvent.EstimatedCost = SubscriptionManager.CalculateCost(characters, false);
            translationEvent.ApiKeySegment = apiSection;
            translationEvent.ApiKeyHash = apiHash;
            translationEvent.Domain = Variables.AppSettings.DeepLDomain;

            return translationEvent;
        }
    }
}
