using Core.DAL;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Core.Services {
    public class StudentService {
        private SchoolContext context;

        public StudentService(SchoolContext ctx) {
            context = ctx;
        }

        public Student AddStudent(string ln, string fn) {
            var std = context.Students.Add(new Student { LastName = ln, FirstMidName = fn, EnrollmentDate = DateTime.Now });
            context.SaveChanges();
            return std;
        }

        public List<Student> ListAllStudents() {
            var query = from s in context.Students
                        orderby s.LastName
                        select s;
            return query.ToList();
        }

        public async Task<List<Student>> ListAllStudentsAsync() {
            var query = from s in context.Students
                        orderby s.LastName
                        select s;
            return await query.ToListAsync();
        }
    }
}
