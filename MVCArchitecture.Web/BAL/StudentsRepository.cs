using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using UniversityApp.DAL;
using UniversityApp.Models;

namespace UniversityApp.BAL
{
    public class StudentsRepository : IRepository<Student>
    {
        private readonly CollegeDBContext db;
        public StudentsRepository()
        {
            db = new CollegeDBContext();
        }

        public async Task Create(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Student student = await GetById(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task<List<Student>> GetAll()
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await db.Students.FindAsync(id);
        }

        public async Task Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}