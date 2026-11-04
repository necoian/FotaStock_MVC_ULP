using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Models;

public class UsuarioVM
{
    
    public int UsuarioId { get; set; }

    [Required(ErrorMessage ="Debes colocar un nombre de usuario")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes colocar un email asociar al usuario")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 150 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes estar completa la contraseña")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 255 caracteres")]

    public string PasswordHash { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes estar completo el rol del usuario")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 30 caracteres")]
    public string rol { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes estar completa la ruta del avatar")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 500 caracteres")]

    public string AvatarRuta { get; set; } = string.Empty;

    
    public DateTime FechaAlta { get; set; }



}