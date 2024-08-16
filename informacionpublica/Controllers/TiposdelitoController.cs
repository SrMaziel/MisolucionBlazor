using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposdelitoController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public TiposdelitoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TiposdelitosDTO>>();
            var listaTiposdelitosDTO = new List<TiposdelitosDTO>();


            try
            {
                foreach (var item in await _dbContext.Tiposdelitos.ToListAsync())
                {
                    listaTiposdelitosDTO.Add(new TiposdelitosDTO
                    {

                        Idtiposdelitos = item.Idtiposdelitos,
                        Tiposdelitos = item.Tiposdelitos,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaTiposdelitosDTO;
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
