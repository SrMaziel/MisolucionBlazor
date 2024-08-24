using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrestopolicialController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public ArrestopolicialController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }
           
        
        [HttpGet]
        [Route("Lista")]

            public async Task<IActionResult> Lista()
            {
                var responseApi = new ResponseAPI<List<ArrestopolicialDTO>>();
                var ListaArrestopolicialDTO = new List<ArrestopolicialDTO>();


                try
                {
                    foreach (var item in await _dbContext.Arrestopolicials.Include(T => T.TipociudadanoNavigation).Include(C => C.CiudadanoNavigation).Include(P => P.DelitosNavigation).Include(D => D.DenunciaNavigation).Include(D => D.DetencionesNavigation).ToListAsync())
                    {
                    ListaArrestopolicialDTO.Add(new ArrestopolicialDTO
                    {


                        Idarrestopolicial = item.Idarrestopolicial,
                        Tipociudadano = item.Tipociudadano,
                        Ciudadano = item.Ciudadano,
                        Delitos = item.Delitos,
                        Denunciantes = item.Denunciantes,
                        Denunciados = item.Denunciados,
                        Detenciones = item.Detenciones,
                        Denuncia = item.Denuncia,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                            Ciudadanos =item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano =item.CiudadanoNavigation!.Idciudadano

                        },

                        Tiposciudadano  = new TiposciudadanosDTO
                        {
                            Tiposciudadanos = item.TipociudadanoNavigation?.Tiposciudadanos,
                            Idtiposciudadanos = item.TipociudadanoNavigation!.Idtiposciudadanos

                        },


                        Delito = new DelitosDTO
                        {
                            Delitos = item.DelitosNavigation?.Delitos,
                            Iddelitos = item.DelitosNavigation!.Iddelitos

                        },



                        Denuncium = new DenunciaDTO
                        {
                            Denuncia = item.DenunciaNavigation?.Denuncia,
                            Iddenuncia = item.DenunciaNavigation!.Iddenuncia

                        },


                        Detencione = new DetencionesDTO
                        {
                            Detencion = item.DetencionesNavigation?.Detencion,
                            Iddetenciones = item.DetencionesNavigation!.Iddetenciones

                        },




                    });
                    }

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ListaArrestopolicialDTO;
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
            var responseApi = new ResponseAPI<ArrestopolicialDTO>();
            var ArrestopolicialDTO = new ArrestopolicialDTO();

            try
            {
                var dbArrestopolicial = await _dbContext.Arrestopolicials.FirstOrDefaultAsync(x => x.Idarrestopolicial == id);

                if (dbArrestopolicial != null)
                {

                    ArrestopolicialDTO.Idarrestopolicial = dbArrestopolicial.Idarrestopolicial;
                    ArrestopolicialDTO.Tipociudadano = dbArrestopolicial.Tipociudadano;
                    ArrestopolicialDTO.Ciudadano = dbArrestopolicial.Ciudadano;
                    ArrestopolicialDTO.Delitos = dbArrestopolicial.Delitos;
                    ArrestopolicialDTO.Denunciantes = dbArrestopolicial.Denunciantes;
                    ArrestopolicialDTO.Denunciados = dbArrestopolicial.Denunciados;
                    ArrestopolicialDTO.Detenciones = dbArrestopolicial.Detenciones;
                    ArrestopolicialDTO.Denuncia = dbArrestopolicial.Denuncia;
                    ArrestopolicialDTO.Estado = dbArrestopolicial.Estado;
                   
                    
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ArrestopolicialDTO;
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
        public async Task<IActionResult> Guardar(ArrestopolicialDTO arrestopolicial)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbArrestopolicial = new Arrestopolicial
                {
                    Idarrestopolicial = arrestopolicial.Idarrestopolicial,
                    Tipociudadano = arrestopolicial.Tipociudadano,
                    Ciudadano = arrestopolicial.Ciudadano,
                    Delitos = arrestopolicial.Delitos,
                    Denunciantes = arrestopolicial.Denunciantes,
                    Denunciados = arrestopolicial.Denunciados,
                    Detenciones = arrestopolicial.Detenciones,
                    Denuncia = arrestopolicial.Denuncia,
                    Estado = arrestopolicial.Estado,


                };


                _dbContext.Arrestopolicials.Add(dbArrestopolicial);
                await _dbContext.SaveChangesAsync();

                if (dbArrestopolicial.Idarrestopolicial != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbArrestopolicial.Idarrestopolicial;
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
        public async Task<IActionResult> Editar(ArrestopolicialDTO arrestopolicial, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {



                var dbArrestopolicial = await _dbContext.Arrestopolicials.FirstOrDefaultAsync(a => a.Idarrestopolicial == id);


                if (dbArrestopolicial != null)
                {

                    dbArrestopolicial.Idarrestopolicial = arrestopolicial.Idarrestopolicial;
                    dbArrestopolicial.Tipociudadano = arrestopolicial.Tipociudadano;
                    dbArrestopolicial.Ciudadano = arrestopolicial.Ciudadano;
                    dbArrestopolicial.Delitos = arrestopolicial.Delitos;
                    dbArrestopolicial.Denunciantes = arrestopolicial.Denunciantes;
                    dbArrestopolicial.Denunciados = arrestopolicial.Denunciados;
                    dbArrestopolicial.Detenciones = arrestopolicial.Detenciones;
                    dbArrestopolicial.Denuncia = arrestopolicial.Denuncia;
                    dbArrestopolicial.Estado = arrestopolicial.Estado;

                    _dbContext.Arrestopolicials.Update(dbArrestopolicial);
                    await _dbContext.SaveChangesAsync();


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbArrestopolicial.Idarrestopolicial;


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

                var dbArrestopolicial = await _dbContext.Arrestopolicials.FirstOrDefaultAsync(a => a.Idarrestopolicial == id);

                if (dbArrestopolicial != null)
                {

                    _dbContext.Arrestopolicials.Update(dbArrestopolicial);
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

