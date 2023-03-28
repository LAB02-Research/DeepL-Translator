using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using DeepLClient.Extensions;
using Serilog;

namespace DeepLClient.Managers
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    internal static class SubscriptionManager
    {
        private static bool _limitReachedWarningShown = false;
        private static bool _limitPendingWarningShown = false;

        /// <summary>
        /// Initialises the background watcher, which will notify when a subscription limit has been reached
        /// </summary>
        internal static void Initialize()
        {
            // start monitoring subscription limits
            _ = Task.Run(MonitorLimits);
        }

        private static async void MonitorLimits()
        {
            while (!Variables.ShuttingDown)
            {
                try
                {
                    // only on free
                    if (!UsingFreeSubscription()) continue;

                    // check if the manager's ready
                    while (!DeepLManager.IsInitialised) await Task.Delay(150);

                    // get the current state
                    var state = await Variables.Translator.GetUsageAsync();
                    if (state.Character == null) continue;

                    // get remaining chars
                    var charsRemaining = state.Character.Limit - state.Character.Count;
                    
                    // anything to warn about?
                    switch (state.AnyLimitReached)
                    {
                        case false when charsRemaining > 10000:
                        {
                            // nope
                            if (!_limitReachedWarningShown && !_limitPendingWarningShown) break;

                            // hide the warnings
                            Variables.MainFormManager?.HideWarningMessage();
                            _limitReachedWarningShown = false;
                            _limitPendingWarningShown = false;

                            break;
                        }
                        case true when !_limitReachedWarningShown:
                        {
                            // we've reached a limit, motify
                            Variables.MainFormManager?.ShowWarningMessage("CHARACTER LIMIT REACHED, PLEASE REVIEW YOUR SUBSCRIPTION");
                            _limitReachedWarningShown = true;

                            break;
                        }
                        default:
                        {
                            if (charsRemaining > 10000) break;
                            
                            // we're near a limit
                            Variables.MainFormManager?.ShowWarningMessage($"YOU HAVE {charsRemaining:N0} CHARACTERS LEFT");
                            _limitPendingWarningShown = true;

                            break;
                        }
                    }
                }
                catch { }
                finally
                {
                    // don't bother the api too much
                    await Task.Delay(TimeSpan.FromMinutes(5));
                }
            }
        }

        /// <summary>
        /// Calculate the projected cost of the translation and returns it as a € #,## string.
        /// <para>In case of a document, the configured minimim characters per document is used</para>
        /// </summary>
        /// <param name="characterCount"></param>
        /// <param name="isDocument"></param>
        /// <returns></returns>
        internal static string CalculateCostString(double characterCount, bool isDocument = true)
        {
            // ignore for free
            if (UsingFreeSubscription()) return "FREE";

            // get the price
            var price = CalculateCost(characterCount, isDocument);

            // any costs?
            if (price == 0) return $"{0:C2}";
            
            // yep, write it out
            var priceString = $"{price:C2}";
            if (price < 0.01) priceString = $"< {0.01:C2}";

            // done
            return priceString;
        }

        /// <summary>
        /// Calculate the projected cost of the translation
        /// </summary>
        /// <param name="characterCount"></param>
        /// <param name="isDocument"></param>
        /// <returns></returns>
        internal static double CalculateCost(double characterCount, bool isDocument = true)
        {
            // ignore for free
            if (UsingFreeSubscription()) return 0d;

            // any chars?
            if (characterCount == 0) return 0d;

            // yep, calculate accordingly
            if (isDocument && characterCount < Variables.AppSettings.MinimumCharactersPerDocument) characterCount = Variables.AppSettings.MinimumCharactersPerDocument;
            var price = characterCount * Variables.AppSettings.PricePerCharacter;

            // done
            return price;
        }

        /// <summary>
        /// Checks for a free subscription domain
        /// </summary>
        /// <returns></returns>
        internal static bool UsingFreeSubscription()
        {
            return !string.IsNullOrEmpty(Variables.AppSettings.DeepLDomain) && Variables.AppSettings.DeepLDomain.ToLower().Contains("free");
        }

        /// <summary>
        /// Returns either free or 0,00
        /// </summary>
        /// <returns></returns>
        internal static string BaseCostNotation()
        {
            return UsingFreeSubscription() ? "FREE" : $"{Variables.CurrencySymbol}0,00";
        }

        /// <summary>
        /// Calculates whether the amount of chars will exceed the subscription limit
        /// </summary>
        /// <param name="characterCount"></param>
        /// <param name="isDocument"></param>
        /// <returns></returns>
        internal static async Task<bool> CharactersWillExceedLimitAsync(double characterCount, bool isDocument = false)
        {
            // only for free
            if (!UsingFreeSubscription()) return false;

            // get the current state
            var state = await Variables.Translator.GetUsageAsync();

            // do we have char info?
            if (state.Character == null)
            {
                Log.Error("[SUBSCRIPTION] Received null character info.");
                return false;
            }

            // is the limit already reached?
            if (state.Character.LimitReached) return true;

            // correct for doc minimum chars
            if (isDocument && characterCount < Variables.AppSettings.MinimumCharactersPerDocument) characterCount = Variables.AppSettings.MinimumCharactersPerDocument;

            // return projected state
            return (state.Character.Limit - state.Character.Count - characterCount) < 0;
        }

        /// <summary>
        /// Returns whether the character limit has been reached
        /// </summary>
        /// <returns></returns>
        internal static async Task<bool> IsLimitReachedAsync()
        {
            // only for free
            if (!UsingFreeSubscription()) return false;

            // get the current state
            var state = await Variables.Translator.GetUsageAsync();

            // do we have char info?
            if (state.Character == null)
            {
                Log.Error("[SUBSCRIPTION] Received null character info.");
                return false;
            }

            // is the limit already reached?
            return state.Character.LimitReached;
        }

        /// <summary>
        /// Returns a subsection of the API key, and a SHA256 hash of the entire key
        /// </summary>
        /// <returns></returns>
        internal static (string apiSection, string apiHash) GetAnonymisedApiKey()
        {
            var key = Variables.AppSettings.DeepLAPIKey;
            if (string.IsNullOrEmpty(key) || key.Length < 6) return (string.Empty, string.Empty);

            // get a section of the key
            var apiSection = $"{key[..6]}..{key.Substring(key.Length - 6, 6)}";

            // get the hash
            using var sha = SHA256.Create();
            var apiHash = sha.GetHash(key);

            // done
            return (apiSection, apiHash);
        }
    }
}
