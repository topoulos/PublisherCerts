using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PublisherCerts2
{
    public static class DocumentDictionary
    {
        public static readonly StringDictionary CertDictionary = new StringDictionary
        {
            {
                CertTypes.ChiefInstructor, TemplateNames.ChiefInstructorPub
            },
            {
                CertTypes.Instructor, TemplateNames.InstructorPub
            },
            {
                CertTypes.Membership, TemplateNames.MemberPub
            },
            {
                CertTypes.Rank, TemplateNames.RankPub
            },
            {
                CertTypes.SchoolCharter, TemplateNames.SchoolCharterPub
            },
            {
                CertTypes.TenshiInstructor, TemplateNames.TenshiInstructorPub
            },
            {
                CertTypes.TenshiMembership, TemplateNames.TenshiMembershipPub
            },
            {
                CertTypes.TenshiRank, TemplateNames.TenshiRankPub
            },
            {
                CertTypes.TenshiSchoolCharter, TemplateNames.TenshiSchoolCharterPub
            },

            };
    }
}
