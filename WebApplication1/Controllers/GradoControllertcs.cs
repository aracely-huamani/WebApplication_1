using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly DBContext _context;

        public GradoController(DBContext context)
        {
            _context = context;
        }

       
        private static List<Grade> grades = new List<Grade>();


        // Endpoint para insertar un grado
        [HttpPost(Name = "InsertGrade")]
        public void InsertarGrado(Grade request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "La solicitud no puede estar vacía");
            }

            // Aquí puedes realizar la lógica para insertar el curso en tu base de datos o en la lista de cursos
            Grade nuevoGrado = new Grade
            {
                IdGrade = grades.Count + 1, // Generar un nuevo ID (podrías usar una estrategia diferente en un entorno real)
                name = request.name,
                description = request.description
            };

            grades.Add(nuevoGrado);
            _context.SaveChanges();
        }

        // Endpoint para eliminar grado
        // POST: Courses/Delete/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (_context.Course == null)
            {
                return NotFound();
            }
            var grade = await _context.Grade.FindAsync(id);
            if (grade != null)
            {
                return NotFound();
            }
            _context.Entry(grade).State = EntityState.Modified;
            //grade.Active = false;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
