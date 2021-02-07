using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWorkTutorial.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FkStudentStandard { get; set; }

        public Standard Standard { get; set; }
        public StudentAddress StudentAddress { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
