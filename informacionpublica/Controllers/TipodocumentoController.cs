using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipodocuemntoController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public TipodocuemntoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TipodocumentosDTO>>();
            var listaTipodocumentosDTO = new List<TipodocumentosDTO>();


            try
            {
                foreach (var item in await _dbContext.Tipodocumentos.ToListAsync())
                {
                    listaTipodocumentosDTO.Add(new TipodocumentosDTO
                    {


                        Idtipodocumentos = item.Idtipodocumentos,
                        Tipodocumentos = item.Tipodocumentos,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaTipodocumentosDTO;
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

