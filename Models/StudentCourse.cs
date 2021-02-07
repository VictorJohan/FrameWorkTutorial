using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWorkTutorial.Models
{
    public partial class StudentCourse
    {
        public int FkStudentCourseCourse { get; set; }
        public int FkStudentCourseStudent { get; set; }
    }
}
