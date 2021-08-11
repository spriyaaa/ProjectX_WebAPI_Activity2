using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBAL
{
    public class ProjectXBL
    {
        ProjectXDLFaculty facDALObj;
        ProjectXDLGrader graDALObj;
        ProjectXDLCourse courseDALObj;
        public ProjectXBL()
        {
            facDALObj = new ProjectXDLFaculty();
            graDALObj = new ProjectXDLGrader();
            courseDALObj = new ProjectXDLCourse();
        }


        public int AddNewCourse(CourseDTO newCourseDetails)
        {
            int retVal = courseDALObj.AddNewCourse(newCourseDetails);
            return retVal;
        }



        public int AddNewGrader(GraderDTO newGraderDetails)
        {
            int retVal = graDALObj.AddNewGrader(newGraderDetails);
            return retVal;
        }



        public int AddNewFaculty(CourseDTO newFacultyDetails)
        {
            int retVal = facDALObj.AddNewFaculty(newFacultyDetails);
            return retVal;
        }

    }
}
