using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposciudadanoController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public TiposciudadanoController(InformacionpublicaContext dbContext)
        {
           _dbContext= dbContext; 
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TiposciudadanosDTO>>();
            var listaTiposciudadanosDTO = new List<TiposciudadanosDTO>();


            try
            {
             foreach(var item in await _dbContext.Tiposciudadanos.ToListAsync())
                {
                    listaTiposciudadanosDTO.Add(new TiposciudadanosDTO
                    {


                        Idtiposciudadanos = item.Idtiposciudadanos,
                        Tiposciudadanos = item.Tiposciudadanos,
                        Estado = item.Estado,
                    });
                  }

                 responseApi.EsCorrecto = true;
                 responseApi.Valor = listaTiposciudadanosDTO;
            }catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }


        



    }
}
