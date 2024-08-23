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
    public class InformacionfinancieraController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public InformacionfinancieraController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<InformacionfinancieraDTO>>();
            var listaInformacionfinancieraDTO = new List<InformacionfinancieraDTO>();

            try
            {
                foreach (var item in await _dbContext.Informacionfinancieras.Include(C => C.CiudadanoNavigation).Include(T => T.TipoingresosNavigation).ToListAsync())
                {
                    listaInformacionfinancieraDTO.Add(new InformacionfinancieraDTO
                    {

                        Idinformacionfinanciera = item.Idinformacionfinanciera,
                        Ciudadano = item.Ciudadano,
                        Profesion = item.Profesion,
                        Oficio = item.Oficio,
                        Salariomensual = item.Salariomensual,
                        Salarioanual = item.Salarioanual,
                        Tipoingresos = item.Tipoingresos,
                        Procedenciaingresos = item.Procedenciaingresos,
                        Declaracionimpuestos = item.Declaracionimpuestos,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {

                            Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                        },
                         Tiposingresos = new TiposingresosDTO
                         {

                             Tiposingresos = item.TipoingresosNavigation?.Tiposingresos,
                             Idtiposingresos =item.TipoingresosNavigation!.Idtiposingresos

                         }
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaInformacionfinancieraDTO;
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
            var responseApi = new ResponseAPI<InformacionfinancieraDTO>();
            var InformacionfinancieraDTO = new InformacionfinancieraDTO();

            try
            {

                var dbInformacionfinanciera = await _dbContext.Informacionfinancieras.FirstOrDefaultAsync(x => x.Idinformacionfinanciera == id);

                if (dbInformacionfinanciera != null)
                {
                    InformacionfinancieraDTO.Idinformacionfinanciera = dbInformacionfinanciera.Idinformacionfinanciera;
                    InformacionfinancieraDTO.Ciudadano = dbInformacionfinanciera.Ciudadano;
                    InformacionfinancieraDTO.Profesion = dbInformacionfinanciera.Profesion;
                    InformacionfinancieraDTO.Oficio = dbInformacionfinanciera.Oficio;
                    InformacionfinancieraDTO.Salariomensual = dbInformacionfinanciera.Salariomensual;
                    InformacionfinancieraDTO.Salarioanual = dbInformacionfinanciera.Salarioanual;
                    InformacionfinancieraDTO.Tipoingresos = dbInformacionfinanciera.Tipoingresos;
                    InformacionfinancieraDTO.Procedenciaingresos = dbInformacionfinanciera.Procedenciaingresos;
                    InformacionfinancieraDTO.Declaracionimpuestos = dbInformacionfinanciera.Declaracionimpuestos;
                    InformacionfinancieraDTO.Estado = dbInformacionfinanciera.Estado;


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = InformacionfinancieraDTO;

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

        public async Task<IActionResult> Guardar(InformacionfinancieraDTO informacionfinanciera)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInformacionfinanciera = new Informacionfinanciera
                {

                    Idinformacionfinanciera = informacionfinanciera.Idinformacionfinanciera,
                    Ciudadano = informacionfinanciera.Ciudadano,
                    Profesion = informacionfinanciera.Profesion,
                    Oficio = informacionfinanciera.Oficio,
                    Salariomensual = informacionfinanciera.Salariomensual,
                    Salarioanual = informacionfinanciera.Salarioanual,
                    Tipoingresos = informacionfinanciera.Tipoingresos,
                    Procedenciaingresos = informacionfinanciera.Procedenciaingresos,
                    Declaracionimpuestos = informacionfinanciera.Declaracionimpuestos,
                    Estado = informacionfinanciera.Estado,
                };

                _dbContext.Informacionfinancieras.Add(dbInformacionfinanciera);
                await _dbContext.SaveChangesAsync();

                if (dbInformacionfinanciera.Idinformacionfinanciera != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInformacionfinanciera.Idinformacionfinanciera;

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

        public async Task<IActionResult> Editar(InformacionfinancieraDTO informacionfinanciera, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbInformacionfinanciera = await _dbContext.Informacionfinancieras.FirstOrDefaultAsync(f => f.Idinformacionfinanciera == id);


                if (dbInformacionfinanciera!= null)
                {

                    dbInformacionfinanciera.Idinformacionfinanciera = informacionfinanciera.Idinformacionfinanciera;
                    dbInformacionfinanciera.Ciudadano = informacionfinanciera.Ciudadano;
                    dbInformacionfinanciera.Profesion = informacionfinanciera.Profesion;
                    dbInformacionfinanciera.Oficio = informacionfinanciera.Oficio;
                    dbInformacionfinanciera.Salariomensual = informacionfinanciera.Salariomensual;
                    dbInformacionfinanciera.Salarioanual = informacionfinanciera.Salarioanual;
                    dbInformacionfinanciera.Tipoingresos = informacionfinanciera.Tipoingresos;
                    dbInformacionfinanciera.Procedenciaingresos = informacionfinanciera.Procedenciaingresos;
                    dbInformacionfinanciera.Declaracionimpuestos = informacionfinanciera.Declaracionimpuestos;
                    dbInformacionfinanciera.Estado = informacionfinanciera.Estado;

                    _dbContext.Informacionfinancieras.Update(dbInformacionfinanciera);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbInformacionfinanciera.Idinformacionfinanciera;

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

                var dbInformacionfinanciera = await _dbContext.Informacionfinancieras.FirstOrDefaultAsync(f => f.Idinformacionfinanciera == id);


                if (dbInformacionfinanciera != null)
                {

                    _dbContext.Informacionfinancieras.Remove(dbInformacionfinanciera);
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