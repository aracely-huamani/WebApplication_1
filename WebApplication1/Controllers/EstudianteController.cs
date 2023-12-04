using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        private readonly DBContext _context;

        public EstudianteController(DBContext context)
        {
            _context = context;
        }

        // endpoint para insertar estudiante

        [HttpPost(Name = "InsertStudent")]
        public void InsertStudent(Student request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "La solicitud no puede estar vacía.");
            }


            // Buscar el grado al que se asignará el estudiante
            Grade grade = _context.Grade.Find(request.IdGrade);

            if (grade == null)
            {
                throw new ArgumentException($"No se encontró el grado con el ID {request.IdGrade}.");
            }

            // Crear una instancia de estudiante y asignar el grado
            var newStudent = new Student
            {
                firstName = request.firstName,
                lastName = request.lastName,
                phone = request.phone,
                email = request.email,
                Grade = grade
            };

            _context.Student.Add(newStudent);
            _context.SaveChanges();
        }


        // endpoint para insertar lista de estudiantes por grado
        [HttpPost(Name = "InsertStudentsByGrade")]
        public void InsertStudentsByGrade(StudentListRequest request)
        {
            if (request == null || request.Student == null || request.Student.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "La solicitud no puede estar vacía y debe contener al menos un estudiante.");
            }

            // Buscar el grado al que se asignarán los estudiantes
            Grade grade = _context.Grade.Find(request.IdGrade);

            if (grade == null)
            {
                throw new ArgumentException($"No se encontró el grado con el ID {request.IdGrade}.");
            }

            // Crear instancias de estudiantes y asignar el grado
            var students = request.Student.Select(x => new Student
            {
                firstName = x.firstName,
                lastName = x.lastName,
                Grade = grade
            }).ToList();

            _context.Student.AddRange(students);
            _context.SaveChanges();
        }

        [HttpPut("{id}", Name = "UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(int id, Student request)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            // Actualizar los datos personales del estudiante
            student.firstName = request.firstName;
            student.lastName = request.lastName;

            _context.Update(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateContactInfo")]
        public async Task<IActionResult> UpdateContactInfo(int id, Student request)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            // Actualizar los datos de contacto del estudiante
            student.phone = request.phone;
            student.email = request.email;

            _context.Update(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost(Name = "EnrollStudent")]
        public async Task<IActionResult> EnrollStudent(StudentRequest request)
        {
            if (request == null || request.Course == null || request.Course.Count == 0)
            {
                return BadRequest("La solicitud no puede estar vacía y debe contener al menos un curso.");
            }

            var student = await _context.Student.FindAsync(request.idStudent);

            if (student == null)
            {
                return NotFound("No se encontró el estudiante con el ID proporcionado.");
            }

            var coursesToEnroll = _context.Course.Where(c => request.Course.Contains(c.IdCourse)).ToList();

            if (coursesToEnroll.Count == 0)
            {
                return NotFound("No se encontraron cursos con los IDs proporcionados.");
            }

            // Matricular al estudiante en los cursos seleccionados
           // student.Course.AddRange(coursesToEnroll);

            _context.Update(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
