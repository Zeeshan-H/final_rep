using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TutorsDataAccess;

namespace api_postman.Controllers
{

         [Authoriza]
    public class studentsController : ApiController
    {


   
       [HttpGet]
       [Route("api/students")]
    
        public IEnumerable<tbl_students> Get()
        {
            using (dbtutorsEntities entities = new dbtutorsEntities())
            {

                return entities.tbl_students.ToList();

            }


        }

          public tbl_students Get(int id)
          {
              using (dbtutorsEntities entities = new dbtutorsEntities())
              {

                  return entities.tbl_students.FirstOrDefault(t => t.ID == id);

              }


          }

          [HttpPost]
          [Route("api/students")]

          public HttpResponseMessage Post([FromBody] tbl_students tutor)
          {
              try
              {
                  using (dbtutorsEntities entities = new dbtutorsEntities())
                  {

                      entities.tbl_students.Add(tutor);
                      entities.SaveChanges();
                      var message = Request.CreateResponse(HttpStatusCode.Created, tutor);
                      message.Headers.Location = new Uri(Request.RequestUri + tutor.ID.ToString());
                      return message;
                  }
              }
              catch (Exception e)
              {
                  return Request.CreateResponse(HttpStatusCode.BadRequest, e);

              }

          }
        [HttpDelete]



          public HttpResponseMessage Delete(int id)
          {

              try
              {


                  using (dbtutorsEntities entities = new dbtutorsEntities())
                  {

                      var entity = entities.tbl_students.Remove(entities.tbl_students.FirstOrDefault(t => t.ID == id));


                      if (entity == null)
                      {

                          return Request.CreateResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be deleted");
                      }
                      else
                      {
                          entities.tbl_students.Remove(entity);
                          entities.SaveChanges();
                          return Request.CreateResponse(HttpStatusCode.OK);
                      }


                  }
              }
              catch (Exception e)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

              }

          }


        [HttpPut]

          public HttpResponseMessage Put(int id, [FromBody]tbl_students tutor)
          {

              try
              {

                  using (dbtutorsEntities entities = new dbtutorsEntities())
                  {

                      var entity = entities.tbl_students.FirstOrDefault(t => t.ID == id);

                      if (entity == null)
                      {


                          return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be updated");
                      }


                      else
                      {

                          entity.ID = tutor.ID;
                          entity.StdEmail = tutor.StdEmail;
                          entity.StdFName = tutor.StdFName;
                          entity.StdLName = tutor.StdLName;
                          entity.StdGender = tutor.StdGender;
                          entity.Password = tutor.Password;
                          entity.Confirm = tutor.Confirm;

                          entities.SaveChanges();
                          return Request.CreateResponse(HttpStatusCode.OK);
                      }
                  }
              }

              catch (Exception e)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

              }
          }

    
    
    }
}
