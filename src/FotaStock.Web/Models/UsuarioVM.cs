using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Models;

public class UsuarioVM
{
    

    [Required(ErrorMessage ="Debes colocar un nombre de usuario")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes colocar un email asociar al usuario")]
    [StringLength(maximumLength:150,ErrorMessage ="Puede colocar maximo 150 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes estar completa la contraseña")]
    [StringLength(maximumLength:100,ErrorMessage ="Puede colocar maximo 100 caracteres")]

    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage ="Debes estar completo el rol del usuario")]
    public string rol { get; set; } = string.Empty;

    public IFormFile? Avatar { get; set; }




}