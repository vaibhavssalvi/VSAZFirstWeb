using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using MyStudentDAL.Models;

namespace MyFirstStudentWebAPI.Controllers
{
    //[Produces("application/json")]
    [RoutePrefix("/api/Students")]
    public class StudentsController : ApiController
    {
        private MyWebStudentContext entities;// = new MyWebStudentContext();

        public StudentsController()
        {
            entities = new MyWebStudentContext();
        }

        public IEnumerable<Students> Get()
        { 
            //using(MyWebStudentContext entities = new MyWebStudentContext())
            {
                    return entities.Students.ToList();
            }
        }

        public Students Get(int  Id)
        {
            //using (MyWebStudentContext entities = new MyWebStudentContext())
            {
                return entities.Students.FirstOrDefault(stud => stud.Id == Id);
            }
        }
    }
}
