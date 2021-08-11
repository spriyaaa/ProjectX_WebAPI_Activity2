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
    public class ProjectXDLGrader
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public ProjectXDLGrader()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MiniProjectConStr"].ToString());
        }


        public int AddNewCourse(GraderDTO inputCourseObj)
        {
            int ret = 0;
            {
                sqlCmdObj = new SqlCommand("dbo.uspInsertGrader", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@NewBatchID", inputCourseObj.NewBatchID);
                sqlCmdObj.Parameters.AddWithValue("@CourseId", inputCourseObj.CourseId);
                sqlCmdObj.Parameters.AddWithValue("@NResult", inputCourseObj.Result);

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







