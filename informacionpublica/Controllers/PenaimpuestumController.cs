using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaimpuestumController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public PenaimpuestumController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<PenaimpuestaDTO>>();
            var listaPenaimpuestaDTO = new List<PenaimpuestaDTO>();


            try
            {
                foreach (var item in await _dbContext.Penaimpuesta.ToListAsync())
                {
                    listaPenaimpuestaDTO.Add(new PenaimpuestaDTO
                    {

                        Idpenaimpuesta = item.Idpenaimpuesta,
                        Delitos = item.Delitos,
                        Tiposdelitos = item.Tiposdelitos,
                        Penaimpuesta = item.Penaimpuesta,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaPenaimpuestaDTO;
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
