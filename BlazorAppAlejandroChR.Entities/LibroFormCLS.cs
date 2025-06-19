using System.ComponentModel.DataAnnotations;

namespace BlazorAppAlejandroChR.Entities
{
    public class LibroFormCLS
    {
        [Range(0, int.MaxValue, ErrorMessage = "El id del libro no debe ser negativo o cero")]
        public int idLibro { get; set; }

        [Required(ErrorMessage ="Debe ingresar el titulo")]
        [MaxLength(50, ErrorMessage = "El titulo no debe tener mas de 50 caracteres")]
        public string titulo { get; set; } = null!;

        [Required(ErrorMessage ="Debe ingresar el resumen")]
        [MaxLength(2000, ErrorMessage = "El resumen no debe tener mas de 2000 caracteres")]
        [MinLength(5, ErrorMessage = "El titulo no debe tener menos de 5 caracteres")]
        public string resumen { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de libro")]
        public int idtipolibro { get; set; }

        public byte[]? image { get; set; }

        public byte[]? archivo { get; set; }

        public string nombrearchivo { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un AUTOR")]
        public int idautor { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un nuermo de paginas")]
        public int numeropaginas { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un stock")]
        public int stock { get; set; }
    }
}
