

using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class ArchivoImagen
{
    
    public int IdArchivoImagen { get; set; }

    [Required]
    public int ImagenId { get; set; }

    [Required]
    public string TipoArchivo { get; set; } = string.Empty;

    [Required]
    public string RutaAlmacenamiento { get; set; } = string.Empty;

    [Required]
    public bool TieneMarcaAgua { get; set; }

    [Required]
    public string HashIntegridad { get; set; } = string.Empty;

    [Required]
    public DateTime FechaCarga { get; set; }

    public Imagen? Imagen { get; set; }


}