using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Publisher;
using System.Reflection;
using System.Security.Permissions;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace PublisherCerts2
{
    public static class Publisher
    {
        public static string templateDirectory = System.Configuration.ConfigurationSettings.AppSettings.Get("CertificatePathWithTrailingSlash");
        public static bool ShowWindow = bool.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("ShowConsoleWindow"));
        public static void RunMSPublisher()
        {
           
            if(ShowWindow)Console.WriteLine("Checking for Certificates");
            Application app = new Application();
            app.ActiveWindow.Visible = false;
            Document doc;
            DB_4170_ncmaEntities dbcontext = new DB_4170_ncmaEntities();

            var query = from c in dbcontext.vwCertificates
                        where c.Completed != true || c.Completed == null
                        select c;

            IEnumerable<vwCertificate> certs = query.ToList();

            if(ShowWindow)Console.WriteLine(certs.Count() + " Found.");

            foreach (vwCertificate certificate in certs)
            {
                LogData.LogLine(String.Format("{0} {1} {2}", certificate.CertType, certificate.Dojo, certificate.FullName));
                switch (certificate.CertType)
                {
                    case "Membership":
                        doc = app.Open(templateDirectory + "member.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintMember(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "School Charter":
                        doc = app.Open(templateDirectory + "school.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintSchool(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Rank":
                        doc = app.Open(templateDirectory + "rank.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintRank(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        //dbcontext.SaveChanges();
                        doc.Close();
                        break;
                    case "Instructor":
                        doc = app.Open(templateDirectory + "instructor.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        certificate.InstructorType = "Instructor";
                        PrintOut.PrintInstructor(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Chief Instructor":
                        doc = app.Open(templateDirectory + "instructor.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        certificate.InstructorType = "Chief Instructor";
                        PrintOut.PrintInstructor(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Tenshi Membership":
                        doc = app.Open(templateDirectory + "tenshimember.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintTenshiMember(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Tenshi School Charter":
                        doc = app.Open(templateDirectory + "tenshischool.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintTenshiSchool(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Tenshi Rank":
                        doc = app.Open(templateDirectory + "tenshirank.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintTenshiRank(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;
                    case "Tenshi Instructor":
                        doc = app.Open(templateDirectory + "tenshiinstructor.pub", true, true, PbSaveOptions.pbDoNotSaveChanges);
                        PrintOut.PrintTenshiInstructor(ref doc, certificate);
                        SaveComplete(certificate.ID);
                        doc.Close();
                        break;

                }


            }
            app.Quit();
            GC.Collect();
        }
        public static bool SaveComplete(int id)
        {
            DB_4170_ncmaEntities context = new DB_4170_ncmaEntities();
            var query = from c in context.membercerts
                        where c.ID == id
                        select c;
            IEnumerable<membercert> certs = query.ToList();
            membercert RetCert = certs.SingleOrDefault();
            RetCert.Completed = true;
            return context.SaveChanges() == 1 ? true : false;

        }

    }
}
