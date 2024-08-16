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
    public class DenunciumController : ControllerBase
    {

        private readonly InformacionpublicaContext _dbContext;

        public DenunciumController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DenunciaDTO>>();
            var listaDenunciaDTO = new List<DenunciaDTO>();


            try
            {
                foreach (var item in await _dbContext.Denuncia.ToListAsync())
                {
                    int? Tipodenuncia = item.Tipodenuncia;
                    listaDenunciaDTO.Add(new DenunciaDTO
                    {


                        Iddenuncia = item.Iddenuncia,
                        Denuncia = item.Denuncia,
                        Tipodenuncia = item.Tipodenuncia,
                        Denunciante = item.Denunciante,
                        Denunciado = item.Denunciado,
                        Estado = item.Estado
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDenunciaDTO;
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
            var responseApi = new ResponseAPI<DenunciaDTO>();
            var DenunciaDTO = new DenunciaDTO();


            try
            {
                var dbDenuncia = await _dbContext.Denuncia.FirstOrDefaultAsync(x => x.Iddenuncia == id);

                if (dbDenuncia != null)
                {

                    DenunciaDTO.Iddenuncia = dbDenuncia.Iddenuncia;
                    DenunciaDTO.Denuncia = dbDenuncia.Denuncia;
                    DenunciaDTO.Tipodenuncia = dbDenuncia.Tipodenuncia;
                    DenunciaDTO.Denunciante = dbDenuncia.Denunciante;
                    DenunciaDTO.Denunciado = dbDenuncia.Denunciado;
                    DenunciaDTO.Estado = dbDenuncia.Estado;


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = DenunciaDTO;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No Encontrado";

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

        public async Task<IActionResult> Guardar(DenunciaDTO Denuncia)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {
                var dbDenuncia = new Denuncium
                {
                    Iddenuncia = Denuncia.Iddenuncia,
                    Denuncia = Denuncia.Denuncia,
                    Tipodenuncia = Denuncia.Tipodenuncia,
                    Denunciante = Denuncia.Denunciante,
                    Denunciado = Denuncia.Denunciado,
                    Estado = Denuncia.Estado,
                };


                _dbContext.Denuncia.Add(dbDenuncia);
                await _dbContext.SaveChangesAsync();

                if (dbDenuncia.Iddenuncia != 0)
                {

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbDenuncia.Iddenuncia;
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

        public async Task<IActionResult> Editar(DenunciaDTO Denuncia, int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {

                var dbDenuncia = await _dbContext.Denuncia.FirstOrDefaultAsync(e => e.Iddenuncia == id);


                if (dbDenuncia != null)
                {

                    dbDenuncia.Iddenuncia = Denuncia.Iddenuncia;
                    dbDenuncia.Denuncia = Denuncia.Denuncia;
                    dbDenuncia.Tipodenuncia = Denuncia.Tipodenuncia;
                    dbDenuncia.Denunciado = Denuncia.Denunciado;
                    dbDenuncia.Estado = Denuncia.Estado;

                    _dbContext.Denuncia.Add(dbDenuncia);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbDenuncia.Iddenuncia;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No  Encontrado";
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

        public async Task<IActionResult> Eleminar(int id)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {

                var dbDenuncia = await _dbContext.Denuncia.FirstOrDefaultAsync(e => e.Iddenuncia == id);


                if (dbDenuncia != null)
                {


                    _dbContext.Denuncia.Remove(dbDenuncia);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No  Encontrado";
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
