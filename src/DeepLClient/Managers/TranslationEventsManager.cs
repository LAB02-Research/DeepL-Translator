using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLClient.Extensions;
using DeepLClient.Models;
using Newtonsoft.Json;
using Serilog;

namespace DeepLClient.Managers
{
    internal static class TranslationEventsManager
    {
        /// <summary>
        /// Initialises the translation events manager, loading stored events and periodically mailing the logs (if configured)
        /// </summary>
        internal static void Initialize()
        {
            //not implemented yet
            return;

            try
            {
                // either load or remove all events
                if (!Variables.AppSettings.EnableUsageLogging) PermanentlyPurgeAllEvents(true);
                else LoadStoredEvents();

                // enable the periodic mailer
                Task.Run(PeriodicallyMailTranslationEvents);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEM] Error initialising: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Add and store a new text translation event
        /// </summary>
        /// <param name="characters"></param>
        internal static void StoreTextTranslationEvent(double characters)
        {
            //not implemented yet
            return;

            if (!Variables.AppSettings.EnableUsageLogging) return;

            Task.Run(delegate
            {
                var translationEvent = new TranslationEvent().SetTextEvent(characters);
                Variables.TranslationEvents.Add(translationEvent);

                StoreAllEvents();
            });
        }

        /// <summary>
        /// Add and store a new document translation event
        /// </summary>
        /// <param name="characters"></param>
        internal static void StoreDocumentTranslationEvent(double characters)
        {
            //not implemented yet
            return;

            if (!Variables.AppSettings.EnableUsageLogging) return;

            Task.Run(delegate
            {
                var translationEvent = new TranslationEvent().SetDocumentEvent(characters);
                Variables.TranslationEvents.Add(translationEvent);

                StoreAllEvents();
            });
        }

        /// <summary>
        /// Add and store a new webpage translation event
        /// </summary>
        /// <param name="characters"></param>
        internal static void StoreWebpageTranslationEvent(double characters)
        {
            //not implemented yet
            return;

            if (!Variables.AppSettings.EnableUsageLogging) return;

            Task.Run(delegate
            {
                var translationEvent = new TranslationEvent().SetWebpageEvent(characters);
                Variables.TranslationEvents.Add(translationEvent);

                StoreAllEvents();
            });
        }

        private static void LoadStoredEvents()
        {
            //not implemented yet
            return;

            try
            {
                // check if there's a log found
                if (!Directory.Exists(Variables.ConfigPath) || !File.Exists(Variables.TranslationEventsLogFile)) return;

                // yep, load it
                var logStr = File.ReadAllText(Variables.TranslationEventsLogFile);

                // content?
                if (string.IsNullOrWhiteSpace(logStr)) return;

                // yep, try to parse
                Variables.TranslationEvents = JsonConvert.DeserializeObject<List<TranslationEvent>>(logStr);
                if (Variables.TranslationEvents == null)
                {
                    Log.Error("[TEM] Parsing stored event logs returned a null object");
                    Variables.TranslationEvents = new List<TranslationEvent>();
                    return;
                }

                // done
                Log.Information("[TEM] Found {count} translation events", Variables.TranslationEvents.Count);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEM] Error loading stored events: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Stores all translation events to disk
        /// </summary>
        internal static void StoreAllEvents()
        {
            //not implemented yet
            return;

            try
            {
                // check the path
                if (!Directory.Exists(Variables.ConfigPath)) Directory.CreateDirectory(Variables.ConfigPath);

                // store values
                var events = JsonConvert.SerializeObject(Variables.TranslationEvents, Formatting.Indented);
                File.WriteAllText(Variables.TranslationEventsLogFile, events);

                // done
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEM] Error storing translation events: {err}", ex.Message);
            }
        }

        /// <summary>
        /// This will clear ALL translation events
        /// </summary>
        internal static void PermanentlyPurgeAllEvents(bool areYouSureEverythingWillBeCleared)
        {
            //not implemented yet
            return;

            try
            {
                if (!areYouSureEverythingWillBeCleared) return;

                // remove all events
                Variables.TranslationEvents?.Clear();

                // delete the logfile
                if (File.Exists(Variables.TranslationEventsLogFile)) File.Delete(Variables.TranslationEventsLogFile);
                
                // done
                Log.Information("[TEM] All stored events purged");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEM] Error purging all translation events: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Purges all events that are older than the configured amount of days
        /// </summary>
        internal static void PurgeOldEvents()
        {
            //not implemented yet
            return;

            try
            {
                if (Variables.AppSettings.RemoveUsageLogEntriesOlderThanDays < 0) return;
                if (Variables.AppSettings.RemoveUsageLogEntriesOlderThanDays == 0)
                {
                    // 0 means always clear everything
                    PermanentlyPurgeAllEvents(true);
                    return;
                }

                var oldCount = Variables.TranslationEvents.Count;
                if (oldCount == 0) return;

                var now = DateTime.UtcNow;

                // fetch new events
                var newEvents = Variables.TranslationEvents.Where(translationEvent => 
                    (now - translationEvent.MomentUtc).TotalDays <= Variables.AppSettings.RemoveUsageLogEntriesOlderThanDays).ToList();

                // any change?
                if (newEvents.Count == oldCount) return;

                // yep, current events
                Variables.TranslationEvents.Clear();

                // add the remaining events
                foreach (var translationEvent in newEvents) Variables.TranslationEvents.Add(translationEvent);

                // store it
                StoreAllEvents();

                // done
                Log.Information("[TEM] Old event purging complete, removed {count} events", oldCount - newEvents.Count);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[TEM] Error purging old translation events: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Continuously checks whether a mail containing the translation event logs needs to be sent
        /// </summary>
        private static async void PeriodicallyMailTranslationEvents()
        {
            //not implemented yet
            return;

            while (!Variables.ShuttingDown)
            {
                try
                {
                    // does the user want it?
                    if (!Variables.AppSettings.EnablePeriodicUsageMail) continue;

                    // how long ago since our last mail?
                    var elapsed = DateTime.Now - SettingsManager.GetTranslationEventsLastMailed();
                    if (elapsed.TotalDays < Variables.AppSettings.SendUsageLogMailEveryDays)
                    {
                        // too soon
                        continue;
                    }

                    // period elapsed, time to mail

                    // fetch the relevant (not yet mailed) events
                    var mailEvents = new List<TranslationEvent>();

                    // prepare the horizon (latest relevant moment)
                    var horizon = DateTime.UtcNow.AddDays(-Variables.AppSettings.SendUsageLogMailEveryDays);
                    foreach (var translationEvent in Variables.TranslationEvents.Where(x => !x.Mailed))
                    {
                        // relevant?
                        if (translationEvent.MomentUtc < horizon) continue;

                        // yep
                        mailEvents.Add(translationEvent);

                        // flag as mailed
                        translationEvent.Mailed = true;
                    }

                    if (!mailEvents.Any())
                    {
                        // nothing to do!
                        continue;
                    }

                    // ok we have some info to mail
                    // todo: mail

                    // store the 'mailed' flags
                    StoreAllEvents();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[TEM] Error preparing events log e-mail: {err}", ex.Message);
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromMinutes(30));
                }
            }
        }
    }
}
