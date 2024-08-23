using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraccionesciudadanoController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public InfraccionesciudadanoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<InfraccionesciudadanoDTO>>();
            var listaInfraccionesciudadanoDTO = new List<InfraccionesciudadanoDTO>();

            try
            {
                foreach (var item in await _dbContext.Infraccionesciudadanos.Include(C => C.CiudadanoNavigation).Include(I => I.InfraccionesNavigation).ToListAsync())
                {
                    listaInfraccionesciudadanoDTO.Add(new InfraccionesciudadanoDTO
                    {

                        Idinfraccionesciudadano = item.Idinfraccionesciudadano,
                        Ciudadano = item.Ciudadano,
                        Infracciones = item.Infracciones,
                        Costomulta = item.Costomulta,
                        Estado = item.Estado,
                         Ciudadanos = new CiudadanosDTO
                         {

                             Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                             Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                         },

                         Infraccione = new InfraccionesDTO
                         {

                             Infracciones = item.InfraccionesNavigation?.Infracciones,
                             Idinfracciones = item.InfraccionesNavigation!.Idinfracciones
                         }

                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaInfraccionesciudadanoDTO;
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
            var responseApi = new ResponseAPI<InfraccionesciudadanoDTO>();
            var InfraccionesciudadanoDTO = new InfraccionesciudadanoDTO();

            try
            {

                var dbInfraccionesciudadano = await _dbContext.Infraccionesciudadanos.FirstOrDefaultAsync(x => x.Idinfraccionesciudadano == id);

                if (dbInfraccionesciudadano != null)
                {
                    InfraccionesciudadanoDTO.Idinfraccionesciudadano = dbInfraccionesciudadano.Idinfraccionesciudadano;
                    InfraccionesciudadanoDTO.Ciudadano = dbInfraccionesciudadano.Ciudadano;
                    InfraccionesciudadanoDTO.Infracciones = dbInfraccionesciudadano.Infracciones;
                    InfraccionesciudadanoDTO.Costomulta = dbInfraccionesciudadano.Costomulta;
                    InfraccionesciudadanoDTO.Estado = dbInfraccionesciudadano.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = InfraccionesciudadanoDTO;

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

        public async Task<IActionResult> Guardar(InfraccionesciudadanoDTO infraccionesciudadano)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInfraccionesciudadano = new Infraccionesciudadano
                {

                    Idinfraccionesciudadano = infraccionesciudadano.Idinfraccionesciudadano,
                    Ciudadano = infraccionesciudadano.Ciudadano,
                    Infracciones = infraccionesciudadano.Infracciones,
                    Costomulta = infraccionesciudadano.Costomulta,
                    Estado = infraccionesciudadano.Estado,
                };

                _dbContext.Infraccionesciudadanos.Add(dbInfraccionesciudadano);
                await _dbContext.SaveChangesAsync();

                if (dbInfraccionesciudadano.Idinfraccionesciudadano != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInfraccionesciudadano.Idinfraccionesciudadano;

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

        public async Task<IActionResult> Editar(InfraccionesciudadanoDTO infraccionesciudadano, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInfraccionesciudadano = await _dbContext.Infraccionesciudadanos.FirstOrDefaultAsync(i => i.Idinfraccionesciudadano == id);


                if (dbInfraccionesciudadano != null)
                {

                    dbInfraccionesciudadano.Idinfraccionesciudadano = infraccionesciudadano.Idinfraccionesciudadano;
                    dbInfraccionesciudadano.Ciudadano = infraccionesciudadano.Ciudadano;
                    dbInfraccionesciudadano.Infracciones = infraccionesciudadano.Infracciones;
                    dbInfraccionesciudadano.Costomulta = infraccionesciudadano.Costomulta;
                    dbInfraccionesciudadano.Estado = infraccionesciudadano.Estado;

                    _dbContext.Infraccionesciudadanos.Update(dbInfraccionesciudadano);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInfraccionesciudadano.Idinfraccionesciudadano;

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

                var dbInfraccionesciudadano = await _dbContext.Infraccionesciudadanos.FirstOrDefaultAsync(i => i.Idinfraccionesciudadano == id);


                if (dbInfraccionesciudadano != null)
                {

                    _dbContext.Infraccionesciudadanos.Remove(dbInfraccionesciudadano);
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
