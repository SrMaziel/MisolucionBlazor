using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BieneController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public BieneController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<BienesDTO>>();
            var listaBienesDTO = new List<BienesDTO>();


            try
            {
                foreach (var item in await _dbContext.Bienes.ToListAsync())
                {
                    listaBienesDTO.Add(new BienesDTO
                    {


                        Idbienes = item.Idbienes,
                        Bienes = item.Bienes,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaBienesDTO;
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
    

