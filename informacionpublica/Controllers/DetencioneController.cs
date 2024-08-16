using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetencioneController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public DetencioneController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DetencionesDTO>>();
            var listaDetencionesDTO = new List<DetencionesDTO>();


            try
            {
                foreach (var item in await _dbContext.Detenciones.ToListAsync())
                {
                    listaDetencionesDTO.Add(new DetencionesDTO
                    {


                        Iddetenciones = item.Iddetenciones,
                        Detencion = item.Detencion,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDetencionesDTO;
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
