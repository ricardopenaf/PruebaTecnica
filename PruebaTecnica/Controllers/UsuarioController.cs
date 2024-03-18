using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DTOs;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public readonly string contenedor = "users";

        public UsuarioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Lista todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<usuarioCreacionDTO>>> Get()
        {
            var entidades = await context.Usuarios.ToListAsync();
            var dtos = mapper.Map<List<usuarioCreacionDTO>>(entidades);
            return dtos;
        }

        /// <summary>
        /// Lista un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "obtnerUsuario")]
        public async Task<ActionResult<usuarioCreacionDTO>> Get(int id)
        {
            var entidad = await context.Usuarios.FirstOrDefaultAsync(X => X.Id == id);

            if (entidad == null)
                return NotFound();

            var dto = mapper.Map<usuarioCreacionDTO>(entidad);

            return dto;
        }

        /// <summary>
        /// Realiza el envio de datos hacia la bd
        /// </summary>
        /// <param name="usuarioCreacionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] usuarioCreacionDTO usuarioCreacionDTO)
        {

            var existeAutorConElMismoNombre = await context.Usuarios.AnyAsync(x => x.PrimerNombre == usuarioCreacionDTO.PrimerNombre);
            var existeAutorConElMismoApellido = await context.Usuarios.AnyAsync(x => x.PrimerApellido == usuarioCreacionDTO.PrimerApellido);

            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor en con el nombre{usuarioCreacionDTO.PrimerNombre} y con el apellido {usuarioCreacionDTO.PrimerApellido}");
            }


            var entidad = mapper.Map<Usuario>(usuarioCreacionDTO);

            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;

            if (entidad.Sueldo < 0 || entidad.Sueldo == 0)
                return BadRequest("El valor del sueldo no puede ser 0");

            context.Add(entidad);
            await context.SaveChangesAsync();

            var usuarioDTO = mapper.Map<usuarioCreacionDTO>(entidad);

            return new CreatedAtRouteResult("obtnerUsuario", new { id = usuarioCreacionDTO.Id }, usuarioDTO);
        }

        /// <summary>
        /// Obtener un usuario para su modificación
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioCreacionDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] usuarioCreacionDTO usuarioCreacionDTO)
        {
            var entidad = mapper.Map<Usuario>(usuarioCreacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

      
        /// <summary>
        /// Borra un usuario
        /// </summary>
        /// <param name="id">Id del usuario a borrar</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "borrarUsuariov1")] //api/autores/1
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontró el usuario a eliminar");
            }
            context.Remove(new Usuario() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
            ;
        }
    }
}
