using ProjectXBAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectX_API_Activity2.Controllers
{
    public class FacultyController : ApiController
    {
            
        blObj1 = new ProjectXBL();

        [HttpPost]
        [ActionName("AddFaculties")]
        public HttpResponseMessage AddCoures(FacultyDTO inputFacultyObj)
        {
            try
            {

                if (inputFacultyObj != null && inputFacultyObj.EmailId!= null && inputFacultyObj.Name != null)
                {
                    blObj1 = new ProjectXBL();
                    int retVal = blObj1.AddNewCourse(inputFacultyObj);
                    if (retVal == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Course Details Added Successfully");
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Course Details Not Added");
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("Input not sufficient");
                    return response;
                }

            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(" SomeThing went wrong on the server side");
                return response;
            }
        }
    }
}
}
