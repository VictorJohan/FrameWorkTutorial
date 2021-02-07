using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWorkTutorial.Models
{
    public partial class StudentAddress
    {
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int FkStudentAddressStudent { get; set; }
    }
}
