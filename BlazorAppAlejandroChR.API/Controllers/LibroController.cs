using BlazorAppAlejandroChR.API.Models;
using BlazorAppAlejandroChR.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppAlejandroChR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly BdbibliotecaContext bd;
        public LibroController(BdbibliotecaContext _bd)
        {
            bd = _bd;
        }

        [HttpGet]
        public IActionResult listarLibros()
        {
            try
            {
                var lista =(from libro in bd.Libros
                             join tipolibro in bd.TipoLibros
                             on libro.Iidtipolibro equals tipolibro.Iidtipolibro
                             join autor in bd.Autors
                             on libro.Iidautor equals autor.Iidautor
                             where libro.Bhabilitado == 1
                             select new LibroListCLS
                             {
                                 idLibro = libro.Iidlibro,
                                 titulo = libro.Titulo!,
                                 imagen = libro.Fotocaratula,
                                 nombrearchivo = libro.Nombrearchivo!,
                                 nombretipolibro = tipolibro.Nombretipolibro!,
                                 nombreautor = autor.Nombre + " " + autor.Appaterno + " " + autor.Apmaterno
                             }).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{idlibro}")]
        public IActionResult recuperarLibroPorId(int idlibro) {
            try
            {
                var obj = bd.Libros.Where(p => p.Iidlibro == idlibro).FirstOrDefault();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    LibroFormCLS oLibroFormCLS = new LibroFormCLS();
                    oLibroFormCLS.idLibro = obj.Iidlibro;
                    oLibroFormCLS.titulo = obj.Titulo!;
                    oLibroFormCLS.resumen = obj.Resumen!;
                    oLibroFormCLS.idtipolibro = (int)obj.Iidtipolibro!;
                    oLibroFormCLS.nombrearchivo = obj.Nombrearchivo!;
                    oLibroFormCLS.archivo = obj.Libropdf;
                    oLibroFormCLS.image = obj.Fotocaratula;
                    oLibroFormCLS.idautor = (int)obj.Iidautor!;
                    oLibroFormCLS.numeropaginas = (int)obj.Numpaginas!;
                    oLibroFormCLS.stock = (int)obj.Stock!;
                    return Ok(oLibroFormCLS);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{idlibro}")]
        public IActionResult eliminarLibro(int idlibro)
        {
            try
            {
                var obj = bd.Libros.Where(p => p.Iidlibro == idlibro).FirstOrDefault();
                if(obj == null)
                {
                    return NotFound();
                }
                else
                {
                    obj.Bhabilitado = 0;
                    bd.SaveChanges();
                    return Ok("Se elimino correctamente");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public IActionResult guardarLibro([FromBody] LibroFormCLS olibroForm)
        {
            try
            {
                if (olibroForm.idLibro==0)
                {
                    Libro oLibro = new Libro();
                    oLibro.Titulo = olibroForm.titulo;
                    oLibro.Resumen = olibroForm.resumen;
                    oLibro.Numpaginas = olibroForm.numeropaginas;
                    oLibro.Stock = olibroForm.stock;
                    oLibro.Iidtipolibro = olibroForm.idtipolibro;
                    oLibro.Iidautor = olibroForm.idautor;
                    oLibro.Fotocaratula = olibroForm.image;
                    oLibro.Libropdf = olibroForm.archivo;
                    oLibro.Nombrearchivo = olibroForm.nombrearchivo;
                    oLibro.Bhabilitado = 1;
                    bd.Libros.Add(oLibro);
                    bd.SaveChanges();
                }
                else
                {
                    var oLibro = bd.Libros.Where(p => p.Iidlibro == olibroForm.idLibro).FirstOrDefault();
                    if (oLibro == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        oLibro.Titulo = olibroForm.titulo;
                        oLibro.Resumen = olibroForm.resumen;
                        oLibro.Numpaginas = olibroForm.numeropaginas;
                        oLibro.Stock = olibroForm.stock;
                        oLibro.Iidtipolibro = olibroForm.idtipolibro;
                        oLibro.Iidautor = olibroForm.idautor;
                        oLibro.Fotocaratula = olibroForm.image;
                        oLibro.Libropdf = olibroForm.archivo;
                        oLibro.Nombrearchivo = olibroForm.nombrearchivo;
                        bd.SaveChanges();
                    }
                }

                return Ok("se guardo correctamente");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("recuperarArchivo/{idlibro}")]
        public IActionResult recuperararchivoPorId(int idlibro)
        {
            try
            {
                var obj = bd.Libros.Where(p => p.Iidlibro == idlibro).FirstOrDefault();
                if (obj == null)
                {
                    return NotFound();
                }
                else {
                    return Ok(obj.Libropdf);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
