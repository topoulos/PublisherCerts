using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublisherCerts2
{
    class Request
    {
        public string Type { get; set; }
        public string Student { get; set; }
        public string Dojo { get; set; }
        public string Rank { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
        public string InstructorType { get; set; }
    }
}
