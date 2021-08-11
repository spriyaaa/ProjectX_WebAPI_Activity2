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
    public class GraderController : ApiController
    {

        blObj2 = new ProjectXBL();

        [HttpPost]
        [ActionName("AddGrader")]
        public HttpResponseMessage AddGrader(GraderDTO inputGraderObj)
        {
            try
            {

                if (inputGraderObj != null && inputGraderObj.NewBatchID != null && inputGraderObj.CourseId != null && inputGraderObj.Result != null)
                {
                    blObj2 = new ProjectXBL();
                    int retVal = blObj2.AddNewGrader(inputGraderObj);
                    if (retVal == 1)
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Grader Details Added Successfully");
                        return response;
                    }
                    else
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StringContent("Grader Details Not Added since some values pre-exist");
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

