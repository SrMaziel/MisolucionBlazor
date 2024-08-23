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
    public class AntecedentesciudadanoController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public AntecedentesciudadanoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<AntecedentesciudadanoDTO>>();
            var listaAntecedentesciudadanoDTO = new List<AntecedentesciudadanoDTO>();

            try
            {
                foreach (var item in await _dbContext.Antecedentesciudadanos.Include(C => C.CiudadanosNavigation).Include(D => D.DelitosNavigation).Include(T => T.TiposdelitosNavigation).Include(D => D.DetencionesNavigation).Include(P => P.PenaimpuestaNavigation).ToListAsync())
                {
                    listaAntecedentesciudadanoDTO.Add(new AntecedentesciudadanoDTO
                    {
                        Idantecedentesciudadano = item.Idantecedentesciudadano,
                        Ciudadanos = item.Ciudadanos,
                        Delitos = item.Delitos,
                        Tiposdelitos = item.Tiposdelitos,
                        Detenciones = item.Detenciones,
                        Fechadelito = item.Fechadelito,
                        Penaimpuesta = item.Penaimpuesta,
                        Estado = item.Estado,
                        Ciudadano = new CiudadanosDTO
                        {

                            Ciudadanos = item.CiudadanosNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanosNavigation!.Idciudadano,

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


                        Detencione = new DetencionesDTO
                        {

                            Detencion = item.DetencionesNavigation?.Detencion,
                            Iddetenciones = item.DetencionesNavigation!.Iddetenciones,


                        },


                        Penaimpuestum = new PenaimpuestaDTO
                        {

                            Penaimpuesta = item.PenaimpuestaNavigation?.Penaimpuesta,
                            Idpenaimpuesta = item.PenaimpuestaNavigation!.Idpenaimpuesta
                        }


                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaAntecedentesciudadanoDTO;
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
            var responseApi = new ResponseAPI<AntecedentesciudadanoDTO>();
            var AntecedentesciudadanoDTO = new AntecedentesciudadanoDTO();

            try
            {
                var dbAntecedentesciudadanos = await _dbContext.Antecedentesciudadanos.FirstOrDefaultAsync(x => x.Idantecedentesciudadano == id);

                if (dbAntecedentesciudadanos != null)
                {

                    AntecedentesciudadanoDTO.Idantecedentesciudadano = dbAntecedentesciudadanos.Idantecedentesciudadano;
                    AntecedentesciudadanoDTO.Ciudadanos = dbAntecedentesciudadanos.Ciudadanos;
                    AntecedentesciudadanoDTO.Delitos = dbAntecedentesciudadanos.Delitos;
                    AntecedentesciudadanoDTO.Tiposdelitos = dbAntecedentesciudadanos.Tiposdelitos;
                    AntecedentesciudadanoDTO.Detenciones = dbAntecedentesciudadanos.Detenciones;
                    AntecedentesciudadanoDTO.Fechadelito = dbAntecedentesciudadanos.Fechadelito;
                    AntecedentesciudadanoDTO.Penaimpuesta = dbAntecedentesciudadanos.Penaimpuesta;
                    AntecedentesciudadanoDTO.Estado = dbAntecedentesciudadanos.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = AntecedentesciudadanoDTO;
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
        public async Task<IActionResult> Guardar(AntecedentesciudadanoDTO antecedentesciudadano)
        {
            var responseApi = new ResponseAPI<int>();
           
            try
            {
                var dbAntecedentesciudadano = new Antecedentesciudadano
                {
                    Ciudadanos = antecedentesciudadano.Ciudadanos,
                    Delitos = antecedentesciudadano.Delitos,
                    Tiposdelitos = antecedentesciudadano.Tiposdelitos,
                    Detenciones = antecedentesciudadano.Detenciones,
                    Fechadelito = antecedentesciudadano.Fechadelito,
                    Penaimpuesta = antecedentesciudadano.Penaimpuesta,
                    Estado = antecedentesciudadano.Estado,
                };


                _dbContext.Antecedentesciudadanos.Add(dbAntecedentesciudadano);
                await _dbContext.SaveChangesAsync();

                if(dbAntecedentesciudadano.Idantecedentesciudadano!=0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAntecedentesciudadano.Idantecedentesciudadano;
                }else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje ="No guardado";

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
        public async Task<IActionResult> Editar(AntecedentesciudadanoDTO antecedentesciudadano,int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {



                var dbAntecedentesciudadano = await _dbContext.Antecedentesciudadanos.FirstOrDefaultAsync(a => a.Idantecedentesciudadano == id);


                if (dbAntecedentesciudadano != null)
                {

                    dbAntecedentesciudadano.Ciudadanos = antecedentesciudadano.Ciudadanos;
                    dbAntecedentesciudadano.Delitos = antecedentesciudadano.Delitos;
                    dbAntecedentesciudadano.Tiposdelitos = antecedentesciudadano.Tiposdelitos;
                    dbAntecedentesciudadano.Detenciones = antecedentesciudadano.Detenciones;
                    dbAntecedentesciudadano.Fechadelito = antecedentesciudadano.Fechadelito;
                    dbAntecedentesciudadano.Penaimpuesta = antecedentesciudadano.Penaimpuesta;
                    dbAntecedentesciudadano.Estado = antecedentesciudadano.Estado;

                    _dbContext.Antecedentesciudadanos.Update(dbAntecedentesciudadano);
                    await _dbContext.SaveChangesAsync();


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbAntecedentesciudadano.Idantecedentesciudadano;


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

                var dbAntecedentesciudadano = await _dbContext.Antecedentesciudadanos.FirstOrDefaultAsync(a => a.Idantecedentesciudadano == id);
                
                if (dbAntecedentesciudadano != null)
                {

                    _dbContext.Antecedentesciudadanos.Update(dbAntecedentesciudadano);
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




