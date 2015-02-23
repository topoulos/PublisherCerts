using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ConfigurationSettingsAlias = System.Configuration.ConfigurationSettings;

namespace PublisherCerts2
{
    public static class LogData
    {
        public static void LogLine(string strLogText)
        {
            string logPath = ConfigurationSettingsAlias.AppSettings.Get("CertificateLogFile");

            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists(logPath))
            {
                log = new StreamWriter(logPath);
            }
            else
            {
                log = File.AppendText(logPath);
            }

            // Write to the file:
            log.WriteLine(String.Format("{0} {1}", (DateTime.Now), strLogText));

            // Close the stream:
            log.Close();
        }
    }
}
