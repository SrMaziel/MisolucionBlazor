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
    public class HistorialmedicoController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public HistorialmedicoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<HistorialmedicoDTO>>();
            var listaHistorialmedicoDTO = new List<HistorialmedicoDTO>();

            try
            {
                foreach (var item in await _dbContext.Historialmedicos.Include(C => C.CiudadanoNavigation).ToListAsync())
                {
                    listaHistorialmedicoDTO.Add(new HistorialmedicoDTO
                    {

                        Idhistorialmedico = item.Idhistorialmedico,
                        Ciudadano = item.Ciudadano,
                        Contactoemergencia = item.Contactoemergencia,
                        Intervencionesquirurjicas = item.Intervencionesquirurjicas,
                        Padecimientos = item.Padecimientos,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {
                            Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                        }
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaHistorialmedicoDTO;
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
            var responseApi = new ResponseAPI<HistorialmedicoDTO>();
            var HistorialmedicoDTO = new HistorialmedicoDTO();

            try
            {

                var dbHistorialmedico = await _dbContext.Historialmedicos.FirstOrDefaultAsync(x => x.Idhistorialmedico == id);

                if (dbHistorialmedico!= null)
                {
                    HistorialmedicoDTO.Idhistorialmedico = dbHistorialmedico.Idhistorialmedico;
                    HistorialmedicoDTO.Ciudadano = dbHistorialmedico.Ciudadano;
                    HistorialmedicoDTO.Contactoemergencia = dbHistorialmedico.Contactoemergencia;
                    HistorialmedicoDTO.Intervencionesquirurjicas = dbHistorialmedico.Intervencionesquirurjicas;
                    HistorialmedicoDTO.Padecimientos = dbHistorialmedico.Padecimientos;
                    HistorialmedicoDTO.Estado = dbHistorialmedico.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = HistorialmedicoDTO;

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

        public async Task<IActionResult> Guardar(HistorialmedicoDTO historialmedico)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbHistorialmedico = new Historialmedico
                {
                    Idhistorialmedico = historialmedico.Idhistorialmedico,
                    Ciudadano = historialmedico.Ciudadano,
                    Contactoemergencia = historialmedico.Contactoemergencia,
                    Intervencionesquirurjicas = historialmedico.Intervencionesquirurjicas,
                    Padecimientos = historialmedico.Padecimientos,
                    Estado = historialmedico.Estado,
                };

                _dbContext.Historialmedicos.Add(dbHistorialmedico);
                await _dbContext.SaveChangesAsync();

                if (dbHistorialmedico.Idhistorialmedico != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialmedico.Idhistorialmedico;

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

        public async Task<IActionResult> Editar(HistorialmedicoDTO historialmedico, int id)

        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbHistorialmedico = await _dbContext.Historialmedicos.FirstOrDefaultAsync(h => h.Idhistorialmedico == id);

                if (dbHistorialmedico != null)
                {

                    dbHistorialmedico.Idhistorialmedico = historialmedico.Idhistorialmedico;
                    dbHistorialmedico.Ciudadano = historialmedico.Ciudadano;
                    dbHistorialmedico.Contactoemergencia = historialmedico.Contactoemergencia;
                    dbHistorialmedico.Intervencionesquirurjicas = historialmedico.Intervencionesquirurjicas;
                    dbHistorialmedico.Padecimientos = historialmedico.Padecimientos;
                    dbHistorialmedico.Estado = historialmedico.Estado;

                    _dbContext.Historialmedicos.Update(dbHistorialmedico);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbHistorialmedico.Idhistorialmedico;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Informacion no encontrada";

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

                var dbHistorialmedico = await _dbContext.Historialmedicos.FirstOrDefaultAsync(h => h.Idhistorialmedico == id);

                if (dbHistorialmedico != null)
                {

                    _dbContext.Historialmedicos.Remove(dbHistorialmedico);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Informacion no encontrada";

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