using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TutorsDataAccess;


namespace api_postman.Controllers
{
        [Authorize(Roles="tutors,students")]

    public class tutorsController : ApiController
    {
      
        [HttpGet]
        [Route("api/tutors")]


        public IEnumerable<tbl_tutors> Get()
        {
            using (dbtutorsEntities entities = new dbtutorsEntities())
            {

                return entities.tbl_tutors.ToList();

            }
            

       

             
    }

         

          public tbl_tutors Get(int id)
          {
              using (dbtutorsEntities entities = new dbtutorsEntities())
              {

                  return entities.tbl_tutors.FirstOrDefault(t => t.ID == id);

              }


          }
            [HttpPost]
            [Route("api/tutors")]


          public HttpResponseMessage Post([FromBody] tbl_tutors tutor)
          {
              try
              {
                  using (dbtutorsEntities entities = new dbtutorsEntities())
                  {

                      entities.tbl_tutors.Add(tutor);
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

                      var entity = entities.tbl_tutors.Remove(entities.tbl_tutors.FirstOrDefault(t => t.ID == id));


                      if (entity == null)
                      {

                          return Request.CreateResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be deleted");
                      }
                      else
                      {
                          entities.tbl_tutors.Remove(entity);
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

          public HttpResponseMessage Put(int id, [FromBody]tbl_tutors tutor)
          {

              try
              {

                  using (dbtutorsEntities entities = new dbtutorsEntities())
                  {

                      var entity = entities.tbl_tutors.FirstOrDefault(t => t.ID == id);

                      if (entity == null)
                      {


                          return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be updated");
                      }


                      else
                      {

                          entity.ID = tutor.ID;
                          entity.Email = tutor.Email;
                          entity.FName = tutor.FName;
                          entity.LName = tutor.LName;
                          entity.Gender = tutor.Gender;
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
