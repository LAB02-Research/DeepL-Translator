using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLClient.Enums;

namespace DeepLClient.Models
{
    public class TranslationEvent
    {
        public TranslationEvent()
        {
            //
        }

        public TranslationEvent(string name, DateTime momentUtc, TranslationEventType type, double characters, double estimatedCost, string apiKeySegment, string apiKeyHash, string domain)
        {
            Name = name;
            MomentUtc = momentUtc;
            Type = type;
            Characters = characters;
            EstimatedCost = estimatedCost;
            ApiKeySegment = apiKeySegment;
            ApiKeyHash = apiKeyHash;
            Domain = domain;
        }

        public string Name { get; set; }
        public DateTime MomentUtc { get; set; }
        public TranslationEventType Type { get; set; }
        public double Characters { get; set; }
        public double EstimatedCost { get; set; }
        public string ApiKeySegment { get; set; }
        public string ApiKeyHash { get; set; }
        public string Domain { get; set; }
        public bool Mailed { get; set; }
    }
}
