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
    public class AntecedentespenaleController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public AntecedentespenaleController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            {
                var responseApi = new ResponseAPI<List<AntecedentespenalesDTO>>();
                var listaAntecedentespenalesDTO = new List<AntecedentespenalesDTO>();


                try
                {
                    foreach (var item in await _dbContext.Antecedentespenales.Include(C => C.CiudadanoNavigation).Include(D => D.DelitosNavigation).Include(T => T.TiposdelitosNavigation).Include(P => P.PenaimpuestaNavigation).ToListAsync())
                    {
                        listaAntecedentespenalesDTO.Add(new AntecedentespenalesDTO
                        {
                            Idantecedentespenales = item.Idantecedentespenales,
                            Ciudadano = item.Ciudadano,
                            Delitos = item.Delitos,
                            Tiposdelitos = item.Tiposdelitos,
                            Penaimpuesta = item.Penaimpuesta,
                            Estado = item.Estado,
                            Ciudadanos = new CiudadanosDTO
                            {
                                Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                                Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                            },


                            Delito = new DelitosDTO
                            {

                                Delitos = item.DelitosNavigation?.Delitos,
                                Iddelitos = item.DelitosNavigation!.Iddelitos,

                            },


                            Tiposdelito = new TiposdelitosDTO
                            {

                                Tiposdelitos = item.TiposdelitosNavigation?.Tiposdelitos,
                                Idtiposdelitos = item.TiposdelitosNavigation!.Idtiposdelitos,

                            },


                            Penaimpuestum = new PenaimpuestaDTO
                            {

                                Penaimpuesta = item.PenaimpuestaNavigation?.Penaimpuesta,
                                Idpenaimpuesta = item.PenaimpuestaNavigation!.Idpenaimpuesta
                            }


                        });
                    }

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = listaAntecedentespenalesDTO;

                }
                catch (Exception ex)
                {

                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;
                }

                return Ok(responseApi);
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        private async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<AntecedentespenalesDTO>();
            var AntecedentespenalesDTO = new AntecedentespenalesDTO();

            try
            {
                var dbAntecedentespenales = await _dbContext.Antecedentespenales.FirstOrDefaultAsync(x => x.Idantecedentespenales == id);

                if (dbAntecedentespenales != null)
                {

                    AntecedentespenalesDTO.Idantecedentespenales = dbAntecedentespenales.Idantecedentespenales;
                    AntecedentespenalesDTO.Ciudadano = dbAntecedentespenales.Ciudadano;
                    AntecedentespenalesDTO.Delitos = dbAntecedentespenales.Delitos;
                    AntecedentespenalesDTO.Tiposdelitos = dbAntecedentespenales.Tiposdelitos;
                    AntecedentespenalesDTO.Penaimpuesta = dbAntecedentespenales.Penaimpuesta;
                    AntecedentespenalesDTO.Estado = dbAntecedentespenales.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = AntecedentespenalesDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No es encontrado";
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
        public async Task<IActionResult> Guardar(AntecedentespenalesDTO antecedentespenales)
        {

            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAntecedentespenales = new Antecedentespenale
                {
                    Ciudadano = antecedentespenales.Ciudadano,
                    Delitos = antecedentespenales.Delitos,
                    Tiposdelitos = antecedentespenales.Tiposdelitos,
                    Penaimpuesta = antecedentespenales.Penaimpuesta,
                    Estado = antecedentespenales.Estado,
                };


                _dbContext.Antecedentespenales.Add(dbAntecedentespenales);
                await _dbContext.SaveChangesAsync();

                if (dbAntecedentespenales.Idantecedentespenales != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAntecedentespenales.Idantecedentespenales;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No guardado";

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
        public async Task<IActionResult> Editar(AntecedentespenalesDTO antecedentespenales, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAntecedentespenales = await _dbContext.Antecedentespenales.FirstOrDefaultAsync(a => a.Idantecedentespenales == id);


                if (dbAntecedentespenales != null)
                {
                    dbAntecedentespenales.Ciudadano = antecedentespenales.Ciudadano;
                    dbAntecedentespenales.Delitos = antecedentespenales.Delitos;
                    dbAntecedentespenales.Tiposdelitos = antecedentespenales.Tiposdelitos;
                    dbAntecedentespenales.Penaimpuesta = antecedentespenales.Penaimpuesta;
                    dbAntecedentespenales.Estado = antecedentespenales.Estado;

                    _dbContext.Antecedentespenales.Update(dbAntecedentespenales);
                    await _dbContext.SaveChangesAsync();


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAntecedentespenales.Idantecedentespenales;

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

                var dbAntecedentespenales = await _dbContext.Antecedentespenales.FirstOrDefaultAsync(a => a.Idantecedentespenales == id);

                if (dbAntecedentespenales != null)
                {

                    _dbContext.Antecedentespenales.Update(dbAntecedentespenales);
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
