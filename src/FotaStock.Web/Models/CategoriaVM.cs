using System.ComponentModel.DataAnnotations;

namespace FotaStock.Web.Models;


public class CategoriaVM
{
    
    public int CategoriaId { get; set; }


    [Required(ErrorMessage ="Debes completar con un nombre en la categoria")]
    [StringLength(maximumLength:100, ErrorMessage = "Solamente tienes un maximo de 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

   
    [Required(ErrorMessage ="Debes completar con una descripcion de esta categoria")]
    [StringLength(maximumLength:500, ErrorMessage = "Solamente tienes un maximo de 500 caracteres")]
    public string Descripcion { get; set; } = string.Empty;




}