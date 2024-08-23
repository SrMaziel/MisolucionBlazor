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
    public class PermisostipousuariosController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public PermisostipousuariosController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<PermisostipousuarioDTO>>();
            var listaPermisostipousuariosDTO = new List<PermisostipousuarioDTO>();

            try
            {
                foreach (var item in await _dbContext.Permisostipousuarios.ToListAsync())
                {
                    listaPermisostipousuariosDTO.Add(new PermisostipousuarioDTO
                    {
                        Idpermisostipousuario = item.Idpermisostipousuario,
                        Usuarios = item.Usuarios,
                        Tipousuarios = item.Tipousuarios,
                        Permisos = item.Permisos,
                        Estado = item.Estado,
                        
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPermisostipousuariosDTO;
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
            var responseApi = new ResponseAPI<PermisostipousuarioDTO>();
            var permisostipousuariosDTO = new PermisostipousuarioDTO();

            try
            {
                var dbPermisostipousuarios = await _dbContext.Permisostipousuarios.FirstOrDefaultAsync(x => x.Idpermisostipousuario == id);

                if (dbPermisostipousuarios != null)
                {
                    permisostipousuariosDTO.Idpermisostipousuario = dbPermisostipousuarios.Idpermisostipousuario;
                    permisostipousuariosDTO.Usuarios = dbPermisostipousuarios.Usuarios;
                    permisostipousuariosDTO.Tipousuarios = dbPermisostipousuarios.Tipousuarios;
                    permisostipousuariosDTO.Permisos = dbPermisostipousuarios.Permisos;
                    permisostipousuariosDTO.Estado = dbPermisostipousuarios.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = permisostipousuariosDTO;
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
        public async Task<IActionResult> Guardar(PermisostipousuarioDTO permisostipousuarios)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPermisostipousuarios = new Permisostipousuario
                {
                    Idpermisostipousuario = permisostipousuarios.Idpermisostipousuario,
                    Usuarios = permisostipousuarios.Usuarios,
                    Tipousuarios = permisostipousuarios.Tipousuarios,
                    Permisos = permisostipousuarios.Permisos,
                    Estado = permisostipousuarios.Estado,
                };

                _dbContext.Permisostipousuarios.Add(dbPermisostipousuarios);
                await _dbContext.SaveChangesAsync();

                if (dbPermisostipousuarios.Idpermisostipousuario != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPermisostipousuarios.Idpermisostipousuario;
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
        public async Task<IActionResult> Editar(PermisostipousuarioDTO permisostipousuarios, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbPermisostipousuarios = await _dbContext.Permisostipousuarios.FirstOrDefaultAsync(e => e.Idpermisostipousuario == id);

                if (dbPermisostipousuarios != null)
                {
                    dbPermisostipousuarios.Idpermisostipousuario = permisostipousuarios.Idpermisostipousuario;
                    dbPermisostipousuarios.Usuarios = permisostipousuarios.Usuarios;
                    dbPermisostipousuarios.Tipousuarios = permisostipousuarios.Tipousuarios;
                    dbPermisostipousuarios.Permisos = permisostipousuarios.Permisos;
                    dbPermisostipousuarios.Estado = permisostipousuarios.Estado;

                    _dbContext.Permisostipousuarios.Update(dbPermisostipousuarios);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPermisostipousuarios.Idpermisostipousuario;
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
                var dbPermisostipousuarios = await _dbContext.Permisostipousuarios.FirstOrDefaultAsync(e => e.Idpermisostipousuario == id);

                if (dbPermisostipousuarios != null)
                {
                    _dbContext.Permisostipousuarios.Remove(dbPermisostipousuarios);
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
