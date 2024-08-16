using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposingresoController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public TiposingresoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TiposingresosDTO>>();
            var listaTiposingresosDTO = new List<TiposingresosDTO>();


            try
            {
                foreach (var item in await _dbContext.Tiposingresos.ToListAsync())
                {
                    listaTiposingresosDTO.Add(new TiposingresosDTO
                    {


                        Idtiposingresos = item.Idtiposingresos,
                        Tiposingresos = item.Tiposingresos,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaTiposingresosDTO;
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