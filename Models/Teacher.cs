using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWorkTutorial.Models
{
    public partial class Teacher
    {
        public int StandardId { get; set; }
        public string TeacherName { get; set; }
        public int FkTeacherStandard { get; set; }
    }
}
