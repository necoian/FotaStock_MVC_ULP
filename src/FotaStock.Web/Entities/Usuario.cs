using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Entities;


public class Usuario
{
    
    public int IdUsuario {get;set;}

    [Required]
    public string Nombre {get;set;} = string.Empty;

    [Required]
    public string Email {get;set;} = string.Empty;

    [Required]
    public string PasswordHash {get;set;} = string.Empty;

    [Required]
    public string Rol {get;set;} = string.Empty;

    public string? Avatar {get;set;} = null;

    [Required]
    public DateTime FechaAlta {get;set;}

    public ICollection<Imagen>? Imagenes {get;set;}

    public ICollection<Compra>? Compras {get;set;}
}