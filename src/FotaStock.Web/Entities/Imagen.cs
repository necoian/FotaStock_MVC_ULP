using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class Imagen
{
    

    public int IdImagen { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    public string Titulo { get; set; } = string.Empty;

    
    public string? Descripcion { get; set; }  = null;

    public string? Ubicacion { get; set; } = null;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    public DateTime FechaPublicacion { get; set; }

    public Usuario? Usuario { get; set; }

    public Categoria? Categoria { get; set; }

    public ICollection<ArchivoImagen>? ArchivoImagenes { get; set; }


}