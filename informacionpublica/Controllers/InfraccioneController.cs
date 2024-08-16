using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraccionesController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public InfraccionesController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<InfraccionesDTO>>();
            var listaInfraccionesDTO = new List<InfraccionesDTO>();


            try
            {
                foreach (var item in await _dbContext.Infracciones.ToListAsync())
                {
                    listaInfraccionesDTO.Add(new InfraccionesDTO
                    {


                        Idinfracciones = item.Idinfracciones,
                        Infracciones = item.Infracciones,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaInfraccionesDTO;
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