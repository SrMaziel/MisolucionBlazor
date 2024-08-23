using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialLaboralController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public HistorialLaboralController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<HistoriallaboralDTO>>();
            var listaHistorialLaboralDTO = new List<HistoriallaboralDTO>();

            try
            {
                foreach (var item in await _dbContext.Historiallaborals.Include(c => c.CiudadanoNavigation).Include(t => t.TiposciudadanoNavigation).ToListAsync())
                {
                    listaHistorialLaboralDTO.Add(new HistoriallaboralDTO
                    {
                        Idhistoriallaboral = item.Idhistoriallaboral,
                        Ciudadano = item.Ciudadano,
                        Tiposciudadano = item.Tiposciudadano, 
                        Empleoactual = item.Empleoactual,
                        Empleospasados = item.Empleospasados,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                            Ciudadanos =item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano =item.CiudadanoNavigation!.Idciudadano
 
                        },
                        Tiposciudadanos = new TiposciudadanosDTO
                        {
                            Tiposciudadanos = item.TiposciudadanoNavigation?.Tiposciudadanos,
                            Idtiposciudadanos = item.TiposciudadanoNavigation!.Idtiposciudadanos,

                        }
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaHistorialLaboralDTO;
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
            var responseApi = new ResponseAPI<HistoriallaboralDTO>();

            try
            {
                var dbHistorialLaboral = await _dbContext.Historiallaborals.FirstOrDefaultAsync(x => x.Idhistoriallaboral == id);

                if (dbHistorialLaboral != null)
                {
                    var historialLaboralDTO = new HistoriallaboralDTO
                    {
                        Idhistoriallaboral = dbHistorialLaboral.Idhistoriallaboral,
                        Ciudadano = dbHistorialLaboral.Ciudadano,
                        Tiposciudadano = dbHistorialLaboral.Tiposciudadano,
                        Empleoactual = dbHistorialLaboral.Empleoactual,
                        Empleospasados = dbHistorialLaboral.Empleospasados,
                        Estado = dbHistorialLaboral.Estado
                    };

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = historialLaboralDTO;
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
        public async Task<IActionResult> Guardar(HistoriallaboralDTO historialLaboral)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbHistorialLaboral = new Historiallaboral
                {
                    Idhistoriallaboral = historialLaboral.Idhistoriallaboral,
                    Ciudadano = historialLaboral.Ciudadano,
                    Tiposciudadano = historialLaboral.Tiposciudadano,
                    Empleoactual = historialLaboral.Empleoactual,
                    Empleospasados = historialLaboral.Empleospasados,
                    Estado = historialLaboral.Estado,
                };

                _dbContext.Historiallaborals.Add(dbHistorialLaboral);
                await _dbContext.SaveChangesAsync();

                if (dbHistorialLaboral.Idhistoriallaboral != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialLaboral.Idhistoriallaboral;
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
        public async Task<IActionResult> Editar(Historiallaboral historialLaboral, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbHistorialLaboral = await _dbContext.Historiallaborals.FirstOrDefaultAsync(c => c.Idhistoriallaboral == id);

                if (dbHistorialLaboral != null)
                {
                    dbHistorialLaboral.Ciudadano = historialLaboral.Ciudadano;
                    dbHistorialLaboral.Tiposciudadano = historialLaboral.Tiposciudadano;
                    dbHistorialLaboral.Empleoactual = historialLaboral.Empleoactual;
                    dbHistorialLaboral.Empleospasados = historialLaboral.Empleospasados;
                    dbHistorialLaboral.Estado = historialLaboral.Estado;

                    _dbContext.Historiallaborals.Update(dbHistorialLaboral);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialLaboral.Idhistoriallaboral;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Historial laboral no encontrado";
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
                var dbHistorialLaboral = await _dbContext.Historiallaborals.FirstOrDefaultAsync(c => c.Idhistoriallaboral == id);

                if (dbHistorialLaboral != null)
                {
                    _dbContext.Historiallaborals.Remove(dbHistorialLaboral);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Historial laboral no encontrado";
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

