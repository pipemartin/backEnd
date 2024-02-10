using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private string pathImage = "J:\\angularPruebaTecnica\\backEnd\\backEnd\\image\\";
        public EmpleadoController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var listEmpleados = await _context.Empleado.ToListAsync();
                return Ok(listEmpleados);
            } catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {
            try
            {
                // Decodificar la cadena Base64 en bytes
                byte[] imageBytes = Convert.FromBase64String(empleado.foto);
                // Crear el camino completo del archivo
                string filePath = Path.Combine(pathImage, empleado.cedula.ToString()+".jpg");
                // Escribir los bytes en un archivo
                System.IO.File.WriteAllBytes(filePath, imageBytes);
                // Modificar la propiedad empleado.foto con el camino completo del archivo
                empleado.foto = filePath;
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El empleado se registro con exito!" });

            } catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleado empleado)
        {
            try
            {
                if (id != empleado.Id) { return NotFound(); }
                _context.Update(empleado);
                await _context.SaveChangesAsync();
                return Ok(new {message = "El empleado fue actualizado con exito!"});
            } catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empleado = await _context.Empleado.FindAsync(id);
                if(empleado == null) { return NotFound(); }
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El empleado fue eliminado con exito!" });
            } catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
