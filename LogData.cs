using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ConfigurationSettingsAlias = System.Configuration.ConfigurationSettings;
using System.Diagnostics;

namespace PublisherCerts2
{
    public static class LogData
    {
        public static void LogLine(string strLogText, string batchId, bool useDate = false)
        {
            var logPath = $"{batchId}.txt";

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

            if(useDate)
                log.WriteLine(String.Format("{0} {1}", (DateTime.Now), strLogText));
            else
                log.WriteLine(String.Format("{0}",  strLogText));


            // Close the stream:
            log.Close();
        }

        public static void PrintFile(string batchId)
        {

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo($"{batchId}.txt");
            psi.Verb = "PRINT";

            Process.Start(psi);
        }
    }
}
