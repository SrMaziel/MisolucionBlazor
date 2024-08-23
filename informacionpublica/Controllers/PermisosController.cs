using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] 
    public class PermisosController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public PermisosController (InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<PermisosDTO>>();
            var listaPermisosDTO = new List<PermisosDTO>();

            try
            {
                foreach (var item in await _dbContext.Permisos.ToListAsync())
                {
                    listaPermisosDTO.Add(new PermisosDTO
                    {
                        Idpermisos = item.Idpermisos,
                        Permisos = item.Permisos,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPermisosDTO;
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
