using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Publisher;
using Application = Microsoft.Office.Interop.Publisher.Application;
using System.Threading;

namespace PublisherCerts2
{
    public static class Publisher
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public static bool ShowWindow = true; // bool.Parse(ConfigurationSettings.AppSettings.Get("ShowConsoleWindow"));
#pragma warning restore CS0618 // Type or member is obsolete
        public static string TemplateDirectory = System.IO.Directory.GetCurrentDirectory() + @"\Templates\";
        public static bool isDebugging = false;

        private static void PrintOutCertificate(_Application app, vwCertificate certificate)
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
                PrintOut.PrintMember(ref doc, certificate);
            if (certificate.CertType == CertTypes.ChiefInstructor)
                PrintOut.PrintInstructor(ref doc, certificate);
            if (certificate.CertType == CertTypes.Instructor)
                PrintOut.PrintInstructor(ref doc, certificate);
            if (certificate.CertType == CertTypes.Rank)
                PrintOut.PrintRank(ref doc, certificate);
            if (certificate.CertType == CertTypes.SchoolCharter)
                PrintOut.PrintSchool(ref doc, certificate);
            if (certificate.CertType == CertTypes.TenshiInstructor)
                PrintOut.PrintTenshiInstructor(ref doc, certificate);
            if (certificate.CertType == CertTypes.TenshiMembership)
                PrintOut.PrintTenshiMember(ref doc, certificate);
            if (certificate.CertType == CertTypes.TenshiRank)
                PrintOut.PrintTenshiRank(ref doc, certificate);
            if (certificate.CertType == CertTypes.TenshiSchoolCharter)
                PrintOut.PrintTenshiSchool(ref doc, certificate);

            SaveComplete(certificate.ID);
            doc.Close();
            System.Threading.Thread.Sleep(new TimeSpan(0,0,5));
        }

        public static void RunMsPublisher()
        {
            //Thread.Sleep(40000);
            if (ShowWindow)
            {
                Console.WriteLine("Checking for Certificates");
            }
            var app = new Application();
            app.ActiveWindow.Visible = true;

            using (var dbcontext = new DB_4170_ncmaEntities())
            {
                List<vwCertificate> certs = dbcontext.vwCertificates
                    .Where(c => !c.Completed.Value || !c.Completed.HasValue)
                    .ToList();

                if (ShowWindow)
                {
                    Console.WriteLine(certs.Count() + " Found.");
                }

                foreach (vwCertificate certificate in certs)
                {
                    LogData.LogLine($"{certificate.CertType} {certificate.Dojo} {certificate.FullName} {certificate.ID}");
                    PrintOutCertificate(app, certificate);
                }
            }
            app.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static bool SaveComplete(int id)
        {
            using (var context = new DB_4170_ncmaEntities())
            {
                membercert retCert = context.membercerts.FirstOrDefault(c => c.ID == id);
                if (retCert != null)
                {
                    retCert.Completed = true;
                }
                return context.SaveChanges() == 1;
            }
        }
    }
}