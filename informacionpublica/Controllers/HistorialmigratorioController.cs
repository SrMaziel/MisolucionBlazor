using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialmigratorioController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public HistorialmigratorioController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<HistorialmigratorioDTO>>();
            var ListaHistorialmigratorioDTO = new List<HistorialmigratorioDTO>();


            try
            {
                foreach (var item in await _dbContext.Historialmigratorios.Include(C => C.CiudadanoNavigation).Include(T => T.TiposdocumentosNavigation).Include(F => F.FronterasalvadoreñaNavigation).ToListAsync())
                {
                    ListaHistorialmigratorioDTO.Add(new HistorialmigratorioDTO
                    {


                        Idhistorialmigratorio = item.Idhistorialmigratorio,
                        Ciudadano = item.Ciudadano,
                        Tiposdocumentos = item.Tiposdocumentos,
                        Fronteraentrada = item.Fronteraentrada,
                        Fronterasalida = item.Fronterasalida,
                        Fechaentrada = item.Fechaentrada,
                        Fechasalida = item.Fechasalida,
                        Procedencia = item.Procedencia,
                        Destino = item.Destino,
                        Fronterasalvadoreña = item.Fronterasalvadoreña,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                            Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanoNavigation!.Idciudadano

                        },

                        Tipodocumento = new TipodocumentosDTO
                        {
                            Tipodocumentos = item.TiposdocumentosNavigation?.Tipodocumentos,
                            Idtipodocumentos = item.TiposdocumentosNavigation!.Idtipodocumentos

                        },


                        Fronterasalvadoreñas = new FronterasalvadoreñaDTO
                        {
                            Fronteras = item.FronterasalvadoreñaNavigation?.Fronteras,
                            Idfronterasalvadoreñas = item.FronterasalvadoreñaNavigation!.Idfronterasalvadoreñas

                        },


                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = ListaHistorialmigratorioDTO;
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
            var responseApi = new ResponseAPI<HistorialmigratorioDTO>();
            var HistorialmigratorioDTO = new HistorialmigratorioDTO();

            try
            {
                var dbHistorialmigratorio = await _dbContext.Historialmigratorios.FirstOrDefaultAsync(x => x.Idhistorialmigratorio == id);

                if (dbHistorialmigratorio != null)
                {

                    HistorialmigratorioDTO.Idhistorialmigratorio = dbHistorialmigratorio.Idhistorialmigratorio;
                    HistorialmigratorioDTO.Ciudadano = dbHistorialmigratorio.Ciudadano;
                    HistorialmigratorioDTO.Tiposdocumentos = dbHistorialmigratorio.Tiposdocumentos;
                    HistorialmigratorioDTO.Fronteraentrada = dbHistorialmigratorio.Fronteraentrada;
                    HistorialmigratorioDTO.Fronterasalida = dbHistorialmigratorio.Fronterasalida;
                    HistorialmigratorioDTO.Fechaentrada = dbHistorialmigratorio.Fechaentrada;
                    HistorialmigratorioDTO.Fechasalida = dbHistorialmigratorio.Fechasalida;
                    HistorialmigratorioDTO.Procedencia = dbHistorialmigratorio.Procedencia;
                    HistorialmigratorioDTO.Destino = dbHistorialmigratorio.Destino;
                    HistorialmigratorioDTO.Fronterasalvadoreña = dbHistorialmigratorio.Fronterasalvadoreña;
                    HistorialmigratorioDTO.Estado = dbHistorialmigratorio.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = HistorialmigratorioDTO;
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

        public async Task<IActionResult> Guardar(HistorialmigratorioDTO historialmigratorio)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbHistorialmigratorio = new Historialmigratorio
                {

                    Idhistorialmigratorio = historialmigratorio.Idhistorialmigratorio,
                    Ciudadano = historialmigratorio.Ciudadano,
                    Tiposdocumentos = historialmigratorio.Tiposdocumentos,
                    Fronteraentrada = historialmigratorio.Fronteraentrada,
                    Fronterasalida = historialmigratorio.Fronterasalida,
                    Fechaentrada = historialmigratorio.Fechaentrada,
                    Fechasalida = historialmigratorio.Fechasalida,
                    Procedencia = historialmigratorio.Procedencia,
                    Destino = historialmigratorio.Destino,
                    Fronterasalvadoreña = historialmigratorio.Fronterasalvadoreña,
                    Estado = historialmigratorio.Estado,

                };

                _dbContext.Historialmigratorios.Add(dbHistorialmigratorio);
                await _dbContext.SaveChangesAsync();

                if (dbHistorialmigratorio.Idhistorialmigratorio != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialmigratorio.Idhistorialmigratorio;

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

        public async Task<IActionResult> Editar(HistorialmigratorioDTO historialmigratorio, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {


                var dbHistorialmigratorio = await _dbContext.Historialmigratorios.FirstOrDefaultAsync(h => h.Idhistorialmigratorio == id);


                if (dbHistorialmigratorio != null)
                {

                    dbHistorialmigratorio.Idhistorialmigratorio = historialmigratorio.Idhistorialmigratorio;
                    dbHistorialmigratorio.Ciudadano = historialmigratorio.Ciudadano;
                    dbHistorialmigratorio.Tiposdocumentos = historialmigratorio.Tiposdocumentos;
                    dbHistorialmigratorio.Fronteraentrada = historialmigratorio.Fronteraentrada;
                    dbHistorialmigratorio.Fronterasalida = historialmigratorio.Fronterasalida;
                    dbHistorialmigratorio.Fechaentrada = historialmigratorio.Fechaentrada;
                    dbHistorialmigratorio.Fechasalida = historialmigratorio.Fechasalida;
                    dbHistorialmigratorio.Procedencia = historialmigratorio.Procedencia;
                    dbHistorialmigratorio.Destino = historialmigratorio.Destino;
                    dbHistorialmigratorio.Fronterasalvadoreña = historialmigratorio.Fronterasalvadoreña;
                    dbHistorialmigratorio.Estado = historialmigratorio.Estado;

                    _dbContext.Historialmigratorios.Update(dbHistorialmigratorio);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialmigratorio.Idhistorialmigratorio;


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

                var dbHistorialmigratorio = await _dbContext.Historialmigratorios.FirstOrDefaultAsync(h => h.Idhistorialmigratorio == id);


                if (dbHistorialmigratorio != null)
                {


                    _dbContext.Historialmigratorios.Remove(dbHistorialmigratorio);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "datos no encontrados";

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


