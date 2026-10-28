using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class Categoria
{
    
    public int CategoriaId { get; set; }

    [Required]

    public string Nombre { get; set; } = string.Empty;

    [Required]

    public string Descripcion { get; set; } = string.Empty;

    public ICollection<Imagen>? Imagenes { get; set; }


}