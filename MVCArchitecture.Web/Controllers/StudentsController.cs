using MVCArchitecture.Web.BAL;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using UniversityApp.BAL;
using UniversityApp.Models;

namespace MVCArchitecture.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> studentsRepository;

        public StudentsController()
        {
            this.studentsRepository = new StudentsRepository();
        }

        // GET: Students
        public async Task<ActionResult> Index()
        {
            return View(await studentsRepository.GetAll());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await studentsRepository.GetById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([ModelBinder(typeof(StudentCustomBinder))] Student student)
        {
            if (ModelState.IsValid)
            {
                await studentsRepository.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await studentsRepository.GetById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([ModelBinder(typeof(StudentCustomBinder))] Student student)
        {
            if (ModelState.IsValid)
            {
                await studentsRepository.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await studentsRepository.GetById(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await studentsRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                studentsRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
