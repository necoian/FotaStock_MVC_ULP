using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FotaStock.Web.Models;

public class imagenVM {

    public int ImagenId { get; set; }

    public UsuarioVM Usuario {get;set;}

    public List<SelectListItem> Usuarios { get; set; }

    public CategoriaVM Categoria {get;set;}

    public List<SelectListItem> Categorias { get; set; }

    [Required]
    public string Titulo { get; set; } = string.Empty;

    
    public string? Descripcion { get; set; }  = null;

    public string? Ubicacion { get; set; } = null;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    public DateTime FechaPublicacion { get; set; }
    
    
}