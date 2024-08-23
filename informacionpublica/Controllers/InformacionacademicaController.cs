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
    public class InformacionacademicaController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public InformacionacademicaController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<InformacionacademicaDTO>>();
            var listaInformacionacademicaDTO = new List<InformacionacademicaDTO>();

            try
            {
                foreach (var item in await _dbContext.Informacionacademicas.Include(C => C.CiudadanoNavigation).ToListAsync())
                {
                    listaInformacionacademicaDTO.Add(new InformacionacademicaDTO
                    {

                        Idinformacionacademica = item.Idinformacionacademica,
                        Ciudadano = item.Ciudadano,
                        Escuela = item.Escuela,
                        Educacionmedia = item.Educacionmedia,
                        Universidades = item.Universidades,
                        Estudiaactualmente = item.Estudiaactualmente,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                            Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                        }

                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaInformacionacademicaDTO;
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
            var responseApi = new ResponseAPI<InformacionacademicaDTO>();
            var InformacionacademicaDTO = new InformacionacademicaDTO();

            try
            {

                var dbInformacionacademica = await _dbContext.Informacionacademicas.FirstOrDefaultAsync(x => x.Idinformacionacademica == id);

                if (dbInformacionacademica != null)
                {
                    InformacionacademicaDTO.Idinformacionacademica = dbInformacionacademica.Idinformacionacademica;
                    InformacionacademicaDTO.Ciudadano = dbInformacionacademica.Ciudadano;
                    InformacionacademicaDTO.Escuela = dbInformacionacademica.Escuela;
                    InformacionacademicaDTO.Educacionmedia = dbInformacionacademica.Educacionmedia;
                    InformacionacademicaDTO.Universidades = dbInformacionacademica.Universidades;
                    InformacionacademicaDTO.Estudiaactualmente = dbInformacionacademica.Estudiaactualmente;
                    InformacionacademicaDTO.Estado = dbInformacionacademica.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = InformacionacademicaDTO;

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


        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar(InformacionacademicaDTO informacionacademica)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInformacionacademica = new Informacionacademica
                {

                    Idinformacionacademica = informacionacademica.Idinformacionacademica,
                    Ciudadano = informacionacademica.Ciudadano,
                    Escuela = informacionacademica.Escuela,
                    Educacionmedia = informacionacademica.Educacionmedia,
                    Universidades = informacionacademica.Universidades,
                    Estudiaactualmente = informacionacademica.Estudiaactualmente,
                    Estado = informacionacademica.Estado,
                };

                _dbContext.Informacionacademicas.Add(dbInformacionacademica);
                await _dbContext.SaveChangesAsync();

                if (dbInformacionacademica.Idinformacionacademica != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInformacionacademica.Idinformacionacademica;

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


        [HttpPut]
        [Route("Editar/{id}")]

        public async Task<IActionResult> Editar(InformacionacademicaDTO informacionacademica, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInformacionacademica = await _dbContext.Informacionacademicas.FirstOrDefaultAsync(a => a.Idinformacionacademica == id);


                if (dbInformacionacademica != null)
                {

                    dbInformacionacademica.Idinformacionacademica = informacionacademica.Idinformacionacademica;
                    dbInformacionacademica.Ciudadano = informacionacademica.Ciudadano;
                    dbInformacionacademica.Escuela = informacionacademica.Escuela;
                    dbInformacionacademica.Educacionmedia = informacionacademica.Educacionmedia;
                    dbInformacionacademica.Universidades = informacionacademica.Universidades;
                    dbInformacionacademica.Estudiaactualmente = informacionacademica.Estudiaactualmente;
                    dbInformacionacademica.Estado = informacionacademica.Estado;

                    _dbContext.Informacionacademicas.Update(dbInformacionacademica);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInformacionacademica.Idinformacionacademica;

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

                var dbInformacionacademica = await _dbContext.Informacionacademicas.FirstOrDefaultAsync(a => a.Idinformacionacademica == id);


                if (dbInformacionacademica != null)
                {

                    _dbContext.Informacionacademicas.Remove(dbInformacionacademica);
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