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
    public class ProjectXDLFaculty
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public ProjectXDLFaculty()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["MiniProjectConStr"].ToString());
        }


        public int AddNewCourse(FacultyDTO inputCourseObj)
        {
            int ret = 0;
            {
                sqlCmdObj = new SqlCommand("dbo.uspInsertFaculty", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@Psnumber", inputCourseObj.Psnumber);
                sqlCmdObj.Parameters.AddWithValue("@EmailId", inputCourseObj.EmailId);
                sqlCmdObj.Parameters.AddWithValue("@Name", inputCourseObj.Name);

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




