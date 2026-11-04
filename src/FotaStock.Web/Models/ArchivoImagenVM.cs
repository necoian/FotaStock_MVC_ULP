using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotaStock.Web.Models;

public class ArchivoImagenVM
{

    public int ArchivoImagenId { get; set; }

    [Required]
    public int ImagenId { get; set; }

    [Required]
    public string TipoArchivo { get; set; } = string.Empty;

    [Required]
    public string RutaAlmacenamiento { get; set; } = string.Empty;

    public IFormFile? ImageFile { get; set; }

    [Required]
    public bool TieneMarcaAgua { get; set; }

    
    public string? HashIntegridad { get; set; }

    [Required]
    public DateTime FechaCarga { get; set; }


}