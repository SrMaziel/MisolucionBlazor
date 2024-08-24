using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimaController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public VictimaController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

            [HttpGet]
            [Route("Lista")]

            public async Task<IActionResult> Lista()
            {
                var responseApi = new ResponseAPI<List<VictimaDTO>>();
                var listaVictimasDTO = new List<VictimaDTO>();


                try
                {
                    foreach (var item in await _dbContext.Victimas.Include(C => C.CiudadanoNavigation).ToListAsync())
                    {
                    listaVictimasDTO.Add(new VictimaDTO
                        {


                        Idvictimas = item.Idvictimas,
                        Ciudadano = item.Ciudadano,
                        Accidente = item.Accidente,
                        Heridas = item.Heridas,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                         Ciudadanos =item.CiudadanoNavigation?.Ciudadanos,
                         Idciudadano =item!.CiudadanoNavigation!.Idciudadano
                        }
                    
                    
                    });
                    }

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaVictimasDTO;
                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;
                }

                return Ok(responseApi);
            }



        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<VictimaDTO>();
            var VictimaDTO = new VictimaDTO();

            try
            {
                var dbVictima = await _dbContext.Victimas.FirstOrDefaultAsync(x => x.Idvictimas == id);

                if (dbVictima != null)
                {

                    VictimaDTO.Idvictimas = dbVictima.Idvictimas;
                    VictimaDTO.Ciudadano = dbVictima.Ciudadano;
                    VictimaDTO.Accidente = dbVictima.Accidente;
                    VictimaDTO.Heridas = dbVictima.Heridas;
                    VictimaDTO.Estado = dbVictima.Estado;


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = VictimaDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {


                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }



        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(VictimaDTO victima)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbVictima = new Victima
                {
                    Idvictimas = victima.Idvictimas,
                    Ciudadano = victima.Ciudadano,
                    Accidente = victima.Accidente,
                    Heridas = victima.Heridas,
                    Estado = victima.Estado,
                   
                };


                _dbContext.Victimas.Add(dbVictima);
                await _dbContext.SaveChangesAsync();

                if (dbVictima.Idvictimas != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbVictima.Idvictimas;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";

                }

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Editar/{id}")]

        public async Task<IActionResult> Editar(VictimaDTO victima, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {


                var dbVictima = await _dbContext.Victimas.FirstOrDefaultAsync(v => v.Idvictimas == id);


                if (dbVictima != null)
                {

                    dbVictima.Idvictimas = victima.Idvictimas;
                    dbVictima.Ciudadano = victima.Ciudadano;
                    dbVictima.Accidente = victima.Accidente;
                    dbVictima.Heridas = victima.Heridas;
                    dbVictima.Estado = victima.Estado;


                    _dbContext.Victimas.Update(dbVictima);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbVictima.Idvictimas;


                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Datos no encontrados";


                }


            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public async Task<IActionResult> Eliminar(int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbVictima = await _dbContext.Victimas.FirstOrDefaultAsync(v => v.Idvictimas == id);


                if (dbVictima != null)
                {


                    _dbContext.Victimas.Remove(dbVictima);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Datos no encontrados";

                }

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

