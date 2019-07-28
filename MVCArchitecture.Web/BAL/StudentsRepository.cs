using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<List<Student>> GetAll(string sortOrder = null, int pageNumber = 0, int pageSize = 0)
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await db.Students.FindAsync(id);
        }

        public async Task<IPagedList<Student>> GetSortedPagedList(string sortOrder, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 && pageSize <= 0)
                throw new InvalidOperationException();

            var students = from s in db.Students
                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.FirstName)
                        .ThenByDescending(s => s.LastName);
                    break;
                case "admission_date":
                    students = students.OrderBy(s => s.AdmissionDate);
                    break;
                case "admission_date_desc":
                    students = students.OrderByDescending(s => s.AdmissionDate);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.FirstName)
                        .ThenBy(s => s.LastName);
                    break;
            }

            return await Task.Run(() => students.ToPagedList(pageNumber, pageSize));
        }

        public async Task Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}