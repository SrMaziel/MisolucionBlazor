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
    public class CiudadanoController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public CiudadanoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        
        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<CiudadanosDTO>>();
            var listaCiudadanoDTO = new List<CiudadanosDTO>();

            try
            {
                foreach (var item in await _dbContext.Ciudadanos.Include(T => T.TiposciudadanoNavigation).Include(N => N.NacionalidadNavigation).Include(B => B.BienesNavigation).Include(T => T.TipodedocumentoNavigation).ToListAsync())
                {
                    listaCiudadanoDTO.Add(new CiudadanosDTO
                    {


                        Idciudadano = item.Idciudadano,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Fechanacimiento = item.Fechanacimiento,
                        Dui = item.Dui,
                        Tiposciudadanos = item.Tiposciudadanos,
                        Nacionalidad = item.Nacionalidad,
                        Tipodedocumento = item.Tipodedocumento,
                        Telefonofijio = item.Telefonofijio,
                        Telefonomovil = item.Telefonomovil,
                        Correoelectronico = item.Correoelectronico,
                        Direccionciudadano = item.Direccionciudadano,
                        Bienes = item.Bienes,
                        Estado = item.Estado,
                        Tiposciudadano = new TiposciudadanosDTO

                        {

                            Tiposciudadanos = item.TiposciudadanoNavigation?.Tiposciudadanos,
                            Idtiposciudadanos = item.TiposciudadanoNavigation!.Idtiposciudadanos

                        },
                     
                        Tipodocumento = new TipodocumentosDTO 
                      {
                      
                            Tipodocumentos =item.TipodedocumentoNavigation?.Tipodocumentos,
                            Idtipodocumentos =item.TipodedocumentoNavigation!.Idtipodocumentos,

                      },
                          Biene = new BienesDTO
                          {
                          
                              Bienes =item.BienesNavigation?.Bienes,
                              Idbienes =item.BienesNavigation!.Idbienes
                          
                          },

                        Nacional = new NacionalidadDTO 
                        {
                        
                            Nacionalidad1 =item.NacionalidadNavigation?.Nacionalidad1,
                            Idnacionalidad =item.NacionalidadNavigation!.Idnacionalidad
                        
                        }

                    
                    }); 
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaCiudadanoDTO;
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
            var responseApi = new ResponseAPI<CiudadanosDTO>();
            var CiudadanoDTO = new CiudadanosDTO();

            try
            {

                var dbCiudadano = await _dbContext.Ciudadanos.FirstOrDefaultAsync(x => x.Idciudadano == id);

                if (dbCiudadano != null)
                {
                    CiudadanoDTO.Idciudadano = dbCiudadano.Idciudadano;
                    CiudadanoDTO.Nombre = dbCiudadano.Nombre;
                    CiudadanoDTO.Apellido = dbCiudadano.Apellido;
                    CiudadanoDTO.Fechanacimiento = dbCiudadano.Fechanacimiento;
                    CiudadanoDTO.Dui = dbCiudadano.Dui;
                    CiudadanoDTO.Tiposciudadanos = dbCiudadano.Tiposciudadanos;
                    CiudadanoDTO.Nacionalidad = dbCiudadano.Nacionalidad;
                    CiudadanoDTO.Tipodedocumento = dbCiudadano.Tipodedocumento;
                    CiudadanoDTO.Telefonofijio = dbCiudadano.Telefonofijio;
                    CiudadanoDTO.Telefonomovil = dbCiudadano.Telefonomovil;
                    CiudadanoDTO.Correoelectronico = dbCiudadano.Correoelectronico;
                    CiudadanoDTO.Direccionciudadano = dbCiudadano.Direccionciudadano;
                    CiudadanoDTO.Bienes = dbCiudadano.Bienes;
                    CiudadanoDTO.Estado = dbCiudadano.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = CiudadanoDTO;

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

        public async Task<IActionResult> Guardar(CiudadanosDTO ciudadano)

        {
            var responseApi = new ResponseAPI<int>();
           
            try
            {

                var dbCiudadano = new Ciudadano
                {

                    Idciudadano = ciudadano.Idciudadano,
                    Nombre = ciudadano.Nombre,
                    Apellido = ciudadano.Apellido,
                    Fechanacimiento = ciudadano.Fechanacimiento,
                    Dui = ciudadano.Dui,
                    Tiposciudadanos = ciudadano.Tiposciudadanos,
                    Nacionalidad = ciudadano.Nacionalidad,
                    Tipodedocumento = ciudadano.Tipodedocumento,
                    Telefonofijio = ciudadano.Telefonofijio,
                    Telefonomovil = ciudadano.Telefonomovil,
                    Correoelectronico = ciudadano.Correoelectronico,
                    Direccionciudadano = ciudadano.Direccionciudadano,
                    Bienes = ciudadano.Bienes,
                    Estado = ciudadano.Estado,
                };
               
                _dbContext.Ciudadanos.Add(dbCiudadano);
                await _dbContext.SaveChangesAsync();

                if (dbCiudadano.Idciudadano != 0) 
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbCiudadano.Idciudadano;

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

        public async Task<IActionResult> Editar(CiudadanosDTO ciudadano,int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbCiudadano = await _dbContext.Ciudadanos.FirstOrDefaultAsync(c => c.Idciudadano == id);


                if (dbCiudadano!= null)
                {
                   
                    dbCiudadano.Idciudadano = ciudadano.Idciudadano;
                    dbCiudadano.Nombre = ciudadano.Nombre;
                    dbCiudadano.Apellido = ciudadano.Apellido;
                    dbCiudadano.Fechanacimiento = ciudadano.Fechanacimiento;
                    dbCiudadano.Dui = ciudadano.Dui;
                    dbCiudadano.Tiposciudadanos = ciudadano.Tiposciudadanos;
                    dbCiudadano.Nacionalidad = ciudadano.Nacionalidad;
                    dbCiudadano.Tipodedocumento = ciudadano.Tipodedocumento;
                    dbCiudadano.Telefonofijio = ciudadano.Telefonofijio;
                    dbCiudadano.Telefonomovil = ciudadano.Telefonomovil;
                    dbCiudadano.Correoelectronico = ciudadano.Correoelectronico;
                    dbCiudadano.Direccionciudadano = ciudadano.Direccionciudadano;
                    dbCiudadano.Bienes = ciudadano.Bienes;
                    dbCiudadano.Estado = ciudadano.Estado;

                    _dbContext.Ciudadanos.Update(dbCiudadano);
                    await _dbContext.SaveChangesAsync();
                   
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbCiudadano.Idciudadano;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Ciudadano no encontrado";

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

        public async Task<IActionResult> Eliminar( int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbCiudadano = await _dbContext.Ciudadanos.FirstOrDefaultAsync(c => c.Idciudadano == id);


                if (dbCiudadano != null)
                {

                    _dbContext.Ciudadanos.Remove(dbCiudadano);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                 
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Ciudadano no encontrado";

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
