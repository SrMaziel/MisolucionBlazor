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
    public class DocumentosciudadanoController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public DocumentosciudadanoController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DocumentosciudadanoDTO>>();
            var listaDocumentosciudadanoDTO = new List<DocumentosciudadanoDTO>();


            try
            {
                foreach (var item in await _dbContext.Documentosciudadanos.Include(C => C.CiudadanoNavigation).Include(T => T.TipodocumentoNavigation).ToListAsync())
                {
                    listaDocumentosciudadanoDTO.Add(new DocumentosciudadanoDTO
                    {
                        Iddocumentosciudadanos = item.Iddocumentosciudadanos,
                        Ciudadano = item.Ciudadano,
                        Tipodocumento = item.Tipodocumento,
                        Estado = item.Estado,
                        Ciudadanos = new CiudadanosDTO
                        {

                            Ciudadanos = item.CiudadanoNavigation?.Ciudadanos,
                            Idciudadano = item.CiudadanoNavigation!.Idciudadano,

                        },

                        Tipodocumentos = new TipodocumentosDTO
                        {

                            Tipodocumentos = item.TipodocumentoNavigation?.Tipodocumentos,
                            Idtipodocumentos = item.TipodocumentoNavigation!.Idtipodocumentos
                        },


                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDocumentosciudadanoDTO;
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
            var responseApi = new ResponseAPI<DocumentosciudadanoDTO>();
            var DocumentosciudadanoDTO = new DocumentosciudadanoDTO();

            try
            {
                var dbDocumentosciudadanos = await _dbContext.Documentosciudadanos.FirstOrDefaultAsync(x => x.Iddocumentosciudadanos == id);

                if (dbDocumentosciudadanos != null)
                {

                    DocumentosciudadanoDTO.Iddocumentosciudadanos = dbDocumentosciudadanos.Iddocumentosciudadanos;
                    DocumentosciudadanoDTO.Ciudadano = dbDocumentosciudadanos.Ciudadano;
                    DocumentosciudadanoDTO.Tipodocumento = dbDocumentosciudadanos.Tipodocumento;
                    DocumentosciudadanoDTO.Estado = dbDocumentosciudadanos.Estado;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = DocumentosciudadanoDTO;
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
        public async Task<IActionResult> Guardar(DocumentosciudadanoDTO documentosciudadanos)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbDocumentosciudadanos = new Documentosciudadano
                {
                    Iddocumentosciudadanos = documentosciudadanos.Iddocumentosciudadanos,
                    Ciudadano = documentosciudadanos.Ciudadano,
                    Tipodocumento = documentosciudadanos.Tipodocumento,
                    Estado = documentosciudadanos.Estado,
                };

                _dbContext.Documentosciudadanos.Add(dbDocumentosciudadanos);
                await _dbContext.SaveChangesAsync();

                if (dbDocumentosciudadanos.Iddocumentosciudadanos != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbDocumentosciudadanos.Iddocumentosciudadanos;

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
        public async Task<IActionResult> Editar(DocumentosciudadanoDTO documentosciudadanos, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbDocumentosciudadanos = await _dbContext.Documentosciudadanos.FirstOrDefaultAsync(d => d.Iddocumentosciudadanos == id);


                if (dbDocumentosciudadanos != null)
                {

                    dbDocumentosciudadanos.Iddocumentosciudadanos = documentosciudadanos.Iddocumentosciudadanos;
                    dbDocumentosciudadanos.Ciudadano = documentosciudadanos.Ciudadano;
                    dbDocumentosciudadanos.Tipodocumento = documentosciudadanos.Tipodocumento;
                    dbDocumentosciudadanos.Estado = documentosciudadanos.Estado;

                    _dbContext.Documentosciudadanos.Update(dbDocumentosciudadanos);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbDocumentosciudadanos.Iddocumentosciudadanos;


                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Documento no encontrado";

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

                var dbDocumentosciudadanos = await _dbContext.Documentosciudadanos.FirstOrDefaultAsync(d => d.Iddocumentosciudadanos== id);


                if (dbDocumentosciudadanos != null)
                {


                    _dbContext.Documentosciudadanos.Remove(dbDocumentosciudadanos);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Documento no encontrado";

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
