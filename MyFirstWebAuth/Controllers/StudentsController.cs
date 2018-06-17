using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyStudentDAL.Models;

namespace MyFirstWebAuth.Controllers
{
    [Authorize]
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<Students> Get()
        //{
        //    using (MyWebStudentContext entities = new MyWebStudentContext())
        //    {
        //        return entities.Students.ToList();
        //    }
        //}

        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            using (var db = new MyWebStudentContext())
            {
                var data = (from c in db.Students
                            from e in db.Ratings.Where(x => x.Id == c.Rating).DefaultIfEmpty()
                            select new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                TotalMarks = c.TotalMarks,
                                Rating = c.Rating,
                                Ratings = c.Ratings
                            }).ToList().Select(rec => new Students()
                            {
                                Id = rec.Id,
                                Name = rec.Name,
                                TotalMarks = rec.TotalMarks,
                                Rating = rec.Rating,
                                Ratings = rec.Ratings
                            });
                //return Json(data, JsonRequestBehavior.AllowGet);//Newtonsoft.Json.JsonSerializerSettings);
                return Ok(data.ToList());
            }

        }
    }
}
