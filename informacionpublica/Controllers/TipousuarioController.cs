using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipousuarioController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public TipousuarioController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TipousuariosDTO>>();
            var listaTipousuariosDTO = new List<TipousuariosDTO>();


            try
            {
                foreach (var item in await _dbContext.Tipousuarios.ToListAsync())
                {
                    listaTipousuariosDTO.Add(new TipousuariosDTO
                    {


                        Idtipousuarios = item.Idtipousuarios,
                        Tipousuarios = item.Tipousuarios,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaTipousuariosDTO;
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
