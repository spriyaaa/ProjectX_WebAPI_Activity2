using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDAL
{
    public class ProjectXDLCourse
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public ProjectXDLCourse()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MiniProjectConStr"].ToString());
        }


        public int AddNewCourse(CourseDTO inputCourseObj)
        {
            int ret = 0;
            {
                sqlCmdObj = new SqlCommand("dbo.uspInsertCourse", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@CourseID", inputCourseObj.CourseID);
                sqlCmdObj.Parameters.AddWithValue("@CourseOwner", inputCourseObj.CourseOwner);
                sqlCmdObj.Parameters.AddWithValue("@CourseTitle", inputCourseObj.CourseTitle);
                sqlCmdObj.Parameters.AddWithValue("@AssessmentMode", inputCourseObj.AssessmentMode);
                sqlCmdObj.Parameters.AddWithValue("@HoursAssigned", inputCourseObj.HoursAssigned);
                sqlCmdObj.Parameters.AddWithValue("@CourseSyllabus", inputCourseObj.CourseSyllabus);
                try
                {
                    sqlConObj.Open();
                    SqlParameter returnManager = sqlCmdObj.Parameters.Add("RetVal", SqlDbType.Int);
                    returnManager.Direction = ParameterDirection.ReturnValue;
                    sqlCmdObj.ExecuteNonQuery();
                    int returnValue = (int)returnManager.Value;
                    return returnValue;
                }


                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
