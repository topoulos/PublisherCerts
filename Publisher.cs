using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Publisher;
using Application = Microsoft.Office.Interop.Publisher.Application;
using System.Threading;
using CertData;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PublisherCerts2
{
    public static class Publisher
    {
        public static bool ShowWindow =  bool.Parse(ConfigurationManager.AppSettings["ShowConsoleWindow"]);
        public static string TemplateDirectory = System.IO.Directory.GetCurrentDirectory() + @"\Templates\";
        public static bool isDebugging = bool.Parse(ConfigurationManager.AppSettings["isDebugging"]);

        private static async Task PrintOutCertificateAsync(_Application app, vwCertificate certificate)
        {
            if (isDebugging)
            {
                MessageBox.Show("In Printout Certificates", "debugging", MessageBoxButtons.OK);
                Debugger.Break();

            }
            string fileName = DocumentDictionary.CertDictionary[certificate.CertType];

            Document doc = app.Open(TemplateDirectory + fileName, true, true, PbSaveOptions.pbDoNotSaveChanges);


            if (certificate.CertType == CertTypes.ChiefInstructor)
            {
                certificate.InstructorType = InstructorTypes.ChiefInstructor;
            }

            if (certificate.CertType == CertTypes.Instructor)
            {
                certificate.InstructorType = InstructorTypes.Instructor;
            }

            if (certificate.CertType == CertTypes.Membership)
            {
                PrintOut.PrintMember(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.ChiefInstructor)
            {
                PrintOut.PrintInstructor(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.Instructor)
            {
                PrintOut.PrintInstructor(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.Rank)
            {
                PrintOut.PrintRank(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.SchoolCharter)
            {
                PrintOut.PrintSchool(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.TenshiInstructor)
            {
                PrintOut.PrintTenshiInstructor(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.TenshiMembership)
            {
                PrintOut.PrintTenshiMember(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.TenshiRank)
            {
                PrintOut.PrintTenshiRank(ref doc, certificate);
            }

            if (certificate.CertType == CertTypes.TenshiSchoolCharter)
            {
                PrintOut.PrintTenshiSchool(ref doc, certificate);
            }

            await CertRepository.SaveCompleteAsync(certificate.ID);

            doc.Close();
            Thread.Sleep(new TimeSpan(0,0,5));
        }

        public static async Task RunMsPublisher()
        {
            //Thread.Sleep(40000);
            if (ShowWindow)
            {
                Console.WriteLine("Checking for Certificates");
            }

            var certs = await CertRepository.GetNewCertificatesAsync();
            var batchId = DateTime.Now.ToString("yyyyMMdd-HHmm");

            if (ShowWindow)
            {
                Console.WriteLine(certs.Count() + " Found.  Batch Id = " + batchId);
            }

            if (!certs.Any())
                return;


            LogData.LogLine("FOUND:" + batchId + "=================================================================================");
            foreach(var cert in certs)
            {
                Console.WriteLine(cert.ID + " - " + cert.CertType + " - " + cert.Dojo + " = "  + cert.FullName + " = " + batchId);
                LogData.LogLine($"{cert.CertType} - {cert.Dojo} - {cert.FullName} - {cert.ID} - {batchId}");

            }
            LogData.LogLine($" ");
            LogData.LogLine($" ");

            var app = new Application();
            app.ActiveWindow.Visible = true;


            LogData.LogLine("PRINTING:" + batchId + "=================================================================================");
            foreach (vwCertificate certificate in certs)
            {
                await PrintOutCertificateAsync(app, certificate);
                LogData.LogLine($"{certificate.CertType} - {certificate.Dojo} - {certificate.FullName} - {certificate.ID}");
            }
            LogData.LogLine($" ");
            LogData.LogLine($" ");

            app.Quit();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}