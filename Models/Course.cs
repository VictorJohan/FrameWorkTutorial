using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWorkTutorial.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string NameCourse { get; set; }
        public int FkCourseTeacher { get; set; }
    }
}
