using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public UsuariosController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<UsuarioDTO>>();
            var listaUsuarioDTO = new List<UsuarioDTO>();

            try
            {
                foreach (var item in await _dbContext.Usuarios.ToListAsync())
                {
                    listaUsuarioDTO.Add(new UsuarioDTO
                    {
                        Idusuarios = item.Idusuarios,
                        Usuario1 = item.Usuario1,
                        Tipousuarios = item.Tipousuarios,
                        Estado = item.Estado
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaUsuarioDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<UsuarioDTO>();
            var usuarioDTO = new UsuarioDTO();

            try
            {
                var dbUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Idusuarios == id);

                if (dbUsuario != null)
                {
                    usuarioDTO.Idusuarios = dbUsuario.Idusuarios;
                    usuarioDTO.Usuario1 = dbUsuario.Usuario1;
                    usuarioDTO.Tipousuarios = dbUsuario.Tipousuarios;
                    usuarioDTO.Estado = dbUsuario.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = usuarioDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(UsuarioDTO usuario)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuario = new Usuario
                {
                    Idusuarios = usuario.Idusuarios,
                    Usuario1 = usuario.Usuario1,
                    Tipousuarios = usuario.Tipousuarios,
                    Estado = usuario.Estado,
                };

                _dbContext.Usuarios.Add(dbUsuario);
                await _dbContext.SaveChangesAsync();

                if (dbUsuario.Idusuarios != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuario.Idusuarios;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(UsuarioDTO usuario, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.Idusuarios == id);

                if (dbUsuario != null)
                {
                    dbUsuario.Idusuarios = usuario.Idusuarios;
                    dbUsuario.Usuario1 = usuario.Usuario1;
                    dbUsuario.Tipousuarios = usuario.Tipousuarios;
                    dbUsuario.Estado = usuario.Estado;

                    _dbContext.Usuarios.Update(dbUsuario);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbUsuario.Idusuarios;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(e => e.Idusuarios == id);

                if (dbUsuario != null)
                {
                    _dbContext.Usuarios.Remove(dbUsuario);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
