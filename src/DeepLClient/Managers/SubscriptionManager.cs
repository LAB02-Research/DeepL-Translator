using System.Diagnostics.CodeAnalysis;
using Serilog;

namespace DeepLClient.Managers
{
    [SuppressMessage("ReSharper", "EmptyGeneralCatchClause")]
    internal static class SubscriptionManager
    {
        private static bool _limitWarningShown = false;
        private static int _checkInterval = 300;

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
                    // check if the manager's ready
                    if (!DeepLManager.IsInitialised) continue;

                    // get the current state
                    var state = await Variables.Translator.GetUsageAsync();

                    if (!state.AnyLimitReached)
                    {
                        if (_limitWarningShown)
                        {
                            // ok again, hide and slow down
                            Variables.MainForm?.ShowLimitWarning(false);
                            _limitWarningShown = false;
                            _checkInterval = 300;
                        }

                        continue;
                    }

                    // we've reached a limit, motify
                    Variables.MainForm?.ShowLimitWarning();
                    _limitWarningShown = true;

                    // increase our recheck time
                    _checkInterval = 15;
                }
                catch { }
                finally
                {
                    await Task.Delay(TimeSpan.FromSeconds(_checkInterval));
                }
            }
        }

        /// <summary>
        /// Calculate the projected cost of the translation
        /// <para>In case of a document, the configured minimim characters per document is used</para>
        /// </summary>
        /// <param name="characterCount"></param>
        /// <param name="isDocument"></param>
        /// <returns></returns>
        internal static string CalculateCost(double characterCount, bool isDocument = true)
        {
            // ignore for free
            if (UsingFreeSubscription()) return "FREE";

            // any chars?
            if (characterCount == 0) return $"{0:C2}";

            // yep, calculate accordingly
            if (isDocument && characterCount < Variables.AppSettings.MinimumCharactersPerDocument) characterCount = Variables.AppSettings.MinimumCharactersPerDocument;
            var price = characterCount * Variables.AppSettings.PricePerCharacter;

            var priceString = $"{price:C2}";
            if (price < 0.01) priceString = $"< {0.01:C2}";

            return priceString;
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
    }
}
