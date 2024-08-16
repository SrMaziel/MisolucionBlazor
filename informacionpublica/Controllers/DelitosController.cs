using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelitosController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public DelitosController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DelitosDTO>>();
            var listaDelitosDTO = new List<DelitosDTO>();

            try
            {
                foreach (var item in await _dbContext.Delitos.ToListAsync())
                {
                    listaDelitosDTO.Add(new DelitosDTO
                    {

                        Iddelitos = item.Iddelitos,
                        Delitos = item.Delitos,
                        Tiposdelitos = item.Tiposdelitos,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDelitosDTO;
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
