using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLClient.Models
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            //
        }

        public string SmtpServerAddress { get; set; } = string.Empty;
        public int SmtpServerPort { get; set; } = 25;
        public string SmtpServerUsername { get; set; } = string.Empty;
        public string SmtpServerPassword { get; set; } = string.Empty;
        public bool SmtpUseSsl { get; set; }
        public string SenderEmailAddress { get; set; } = string.Empty;
        public string SenderName { get; set; } = "DeepL Translator";
    }
}
