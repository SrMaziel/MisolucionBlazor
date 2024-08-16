using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FronterasalvadoreñaController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public FronterasalvadoreñaController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<FronterasalvadoreñaDTO>>();
            var listaFronterasalvadoreñaDTO = new List<FronterasalvadoreñaDTO>();


            try
            {
                foreach (var item in await _dbContext.Fronterasalvadoreñas.ToListAsync())
                {
                    listaFronterasalvadoreñaDTO.Add(new FronterasalvadoreñaDTO
                    {


                        Idfronterasalvadoreñas = item.Idfronterasalvadoreñas,
                        Fronteras = item.Fronteras,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaFronterasalvadoreñaDTO;
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