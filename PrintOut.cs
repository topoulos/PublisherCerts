using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Publisher;
using CertData;
using System.Configuration;

namespace PublisherCerts2
{
    public static class PrintOut
    {
        public static string DateFormat => ConfigurationManager.AppSettings.Get("DateFormatString");
        public static string AuthenticityString = "Authenticity Number: ";

        public static void PrintMember(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame schoolFrame = pg.Shapes[3].TextFrame;
            TextFrame stDateFrame = pg.Shapes[5].TextFrame;
            TextFrame edDateFrame = pg.Shapes[4].TextFrame;
            TextFrame authFrame = pg.Shapes[6].TextFrame;

            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";
            
            doc.PrintOutEx();
        }

        public static void PrintSchool(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame schoolFrame = pg.Shapes[2].TextFrame;
            TextFrame stDateFrame = pg.Shapes[4].TextFrame;
            TextFrame edDateFrame = pg.Shapes[3].TextFrame;
            TextFrame authFrame = pg.Shapes[5].TextFrame;


            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintRank(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame schoolFrame = pg.Shapes[4].TextFrame;
            TextFrame stDateFrame = pg.Shapes[5].TextFrame;
            TextFrame rankFrame = pg.Shapes[3].TextFrame;
            TextFrame authFrame = pg.Shapes[6].TextFrame;


            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            rankFrame.TextRange.Text = certificate.RankText;
            rankFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            rankFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintInstructor(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame schoolFrame = pg.Shapes[3].TextFrame;
            TextFrame instructorTypeFrame = pg.Shapes[6].TextFrame;
            TextFrame stDateFrame = pg.Shapes[5].TextFrame;
            TextFrame edDateFrame = pg.Shapes[4].TextFrame;
            TextFrame authFrame = pg.Shapes[7].TextFrame;


            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            instructorTypeFrame.TextRange.Text = certificate.InstructorType;
            instructorTypeFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            instructorTypeFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintTenshiMember(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame schoolFrame = pg.Shapes[5].TextFrame;
            TextFrame stDateFrame = pg.Shapes[4].TextFrame;
            TextFrame edDateFrame = pg.Shapes[3].TextFrame;
            TextFrame authFrame = pg.Shapes[6].TextFrame;

            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintTenshiSchool(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame schoolFrame = pg.Shapes[2].TextFrame;
            TextFrame stDateFrame = pg.Shapes[4].TextFrame;
            TextFrame edDateFrame = pg.Shapes[3].TextFrame;
            TextFrame authFrame = pg.Shapes[5].TextFrame;

            schoolFrame.TextRange.Text = certificate.Dojo;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            schoolFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintTenshiRank(ref Document doc, vwCertificate certificate)
        {
            NumberToEnglish num = new NumberToEnglish();
            Page pg = doc.Pages[1];
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame stDateFrame = pg.Shapes[3].TextFrame;
            TextFrame rankFrame = pg.Shapes[4].TextFrame;
            TextFrame authFrame = pg.Shapes[5].TextFrame;

            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = String.Format("{0:MMMM} {1}{2}", Convert.ToDateTime(certificate.FromDate), num.changeNumericToWords(Convert.ToDateTime(certificate.FromDate).Day), Convert.ToDateTime(certificate.FromDate).Year);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            rankFrame.TextRange.Text = certificate.RankText;
            rankFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            rankFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }

        public static void PrintTenshiInstructor(ref Document doc, vwCertificate certificate)
        {
            Page pg = doc.Pages[1];
            TextFrame studentFrame = pg.Shapes[2].TextFrame;
            TextFrame stDateFrame = pg.Shapes[4].TextFrame;
            TextFrame edDateFrame = pg.Shapes[3].TextFrame;
            TextFrame authFrame = pg.Shapes[5].TextFrame;

            studentFrame.TextRange.Text = certificate.FullName;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            studentFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            stDateFrame.TextRange.Text = Convert.ToDateTime(certificate.FromDate).ToString(DateFormat);
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            stDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            edDateFrame.TextRange.Text = Convert.ToDateTime(certificate.ThruDate).ToString(DateFormat);
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitGrowToFit;
            edDateFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitShrinkOnOverflow;

            authFrame.TextRange.Text = $"{AuthenticityString}{certificate.ID}";

            doc.PrintOutEx();
        }            
    }
}
