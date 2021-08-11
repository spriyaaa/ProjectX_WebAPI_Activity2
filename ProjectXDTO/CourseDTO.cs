using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDTO
{
    public class CourseDTO
    {
        public string CourseID { get; set; }
        public string CourseOwner { get; set; }
        public string CourseTitle { get; set; }
        public int AssessmentMode { get; set; }
        public int HoursAssigned { get; set; }
        public string CourseSyllabus { get; set; }
    }
}
