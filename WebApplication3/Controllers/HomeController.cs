using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly databaseContext _context;

        public HomeController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public IEnumerable<Student> Students()
        {
            return _context.Students.Include(x => x.Subjects).Include(x => x.Grades);
        }

        [HttpGet]
        [Route("GetByEmail")]
        public Student Email(string email)
        {
            if (email != null && email != "")
            {
                return _context.Students.Include(x => x.Subjects).Include(x => x.Grades).First(x => x.Email == email);
            }
            else return null;
        }

        [HttpGet]
        [Route("StudentGrades")]
        public IEnumerable<Grade> Grades(int? id)
        {
            if (id != null)
            {
                return _context.Grades.Where(x => x.StudentId == id);
            }
            else return null;
        }
    }
}
