using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public NacionalidadController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<NacionalidadDTO>>();
            var listaNacionalidadDTO = new List<NacionalidadDTO>();


            try
            {
                foreach (var item in await _dbContext.Nacionalidads.ToListAsync())
                {
                    listaNacionalidadDTO.Add(new NacionalidadDTO
                    {


                        Idnacionalidad = item.Idnacionalidad,
                        Nacionalidad1 = item.Nacionalidad1,
                        Estado = item.Estado,
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaNacionalidadDTO;
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
    

